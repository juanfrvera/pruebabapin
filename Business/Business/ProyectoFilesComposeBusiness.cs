using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class ProyectoFilesComposeBusiness : EntityComposeBusiness<ProyectoFilesCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoFilesComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoFilesComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoFilesComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }

        protected override IEntityData<ProyectoFilesCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoFilesCompose GetNew(ProyectoResult example)
        {
            ProyectoFilesCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.ProyectoFiles = new List<ProyectoFileResult>();
            return compose;
        }
        public override ProyectoFilesCompose GetNew()
        {
            ProyectoFilesCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.ProyectoFiles = new List<ProyectoFileResult>();
            return compose;
        }
        public override int GetId(ProyectoFilesCompose entity)
        {
            return entity.IdProyecto;
        }
        public override ProyectoFilesCompose GetById(int id)
        {
            ProyectoFilesCompose compose = new ProyectoFilesCompose();
            compose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            compose.ProyectoFiles = ProyectoFileBusiness.Current.GetResult(new ProyectoFileFilter() { IdProyecto = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoFilesCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (ProyectoFileResult pfr in entity.ProyectoFiles)
                {
                    ProyectoFile pf = pfr.ToEntity();
                    pf.IdProyecto = entity.IdProyecto;
                    pfr.IdProyectoFile = 0;
                    ProyectoFileBusiness.Current.Add(pf, contextUser);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(ProyectoFilesCompose entity, IContextUser contextUser)
        {
            List<ProyectoFileResult> copy1 = ProyectoFileBusiness.Current.CopiesResult(entity.ProyectoFiles);
            try
            {
                // Elimina los que ya no estan
                List<int> actualIdsArch = (from o in entity.ProyectoFiles where o.IdProyectoFile > 0 select o.IdProyectoFile).ToList();
                List<ProyectoFile> oldDetailArch = ProyectoFileBusiness.Current.GetList(new ProyectoFileFilter() { IdProyecto = entity.IdProyecto });
                List<ProyectoFile> deletesArch = (from o in oldDetailArch where !actualIdsArch.Contains(o.IdProyectoFile) select o).ToList();

                List<int> deletedFilesArch = (from f in deletesArch select (Int32)f.IdFile).ToList();
                ProyectoFileBusiness.Current.Delete(deletesArch, contextUser);
                FileInfoBusiness.Current.Delete(deletedFilesArch.ToArray(), contextUser);
                

                foreach (ProyectoFileResult pfr in entity.ProyectoFiles)
                {
                    ProyectoFile pf = pfr.ToEntity();
                    pf.IdProyecto = entity.IdProyecto;
                    if (pfr.IdProyectoFile <= 0)
                    {
                        pf.IdProyectoFile = 0;
                        ProyectoFileBusiness.Current.Add(pf, contextUser);
                    }
                    else
                        ProyectoFileBusiness.Current.Update(pf, contextUser);
                    pfr.IdProyectoFile = pf.IdProyectoFile;
                }
                //Matias 20131106 - Tarea 80
                ProyectoBusiness.Current.updateFechaUltimaModificacion(entity.IdProyecto, contextUser);
                //FinMatias 20131106 - Tarea 80
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.ProyectoFiles = copy1;
                throw exception;
            }
        }
        public override void Delete(ProyectoFilesCompose entity, IContextUser contextUser)
        {
            List<int> actualIdsArch = (from o in entity.ProyectoFiles where o.IdProyectoFile > 0 select o.IdProyectoFile).ToList();
            ProyectoFileBusiness.Current.Delete(actualIdsArch.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(ProyectoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            foreach (ProyectoFileResult pfr in entity.ProyectoFiles)
            {
                DataHelper.Validate(pfr.File_Date != null, "InvalidField", "InvalidField");
                DataHelper.Validate(pfr.File_FileName != "", "InvalidField", "InvalidField");
            }
        }

        public override bool Can(ProyectoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(ProyectoFilesCompose source, ProyectoFilesCompose target)
        {
            bool eq = source.IdProyecto.Equals(target.IdProyecto);

            if( source.ProyectoFiles.Count != target.ProyectoFiles.Count) return false;

            foreach (ProyectoFileResult pfr in source.ProyectoFiles)
            {
                if (target.ProyectoFiles.Where(t => t.IdProyectoFile == pfr.IdProyectoFile).Count() > 0)
                    eq = eq && pfr.Comparar(target.ProyectoFiles.Where(t => t.IdProyectoFile == pfr.IdProyectoFile).Single());
                else
                    eq = false;
            }

            return eq;
        }
        #endregion
    }
}