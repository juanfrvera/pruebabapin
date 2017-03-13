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
    public class ProyectoDictamenFilesComposeBusiness : EntityComposeBusiness<ProyectoDictamenFilesCompose, ProyectoDictamen, ProyectoDictamenFilter, ProyectoDictamenResult, int>
    {
        #region Singleton
        private static volatile ProyectoDictamenFilesComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoDictamenFilesComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoDictamenFilesComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<ProyectoDictamen, ProyectoDictamenFilter, ProyectoDictamenResult, int> EntityBusinessBase
        {
            get { return ProyectoDictamenBusiness.Current; }
        }

        protected override IEntityData<ProyectoDictamenFilesCompose, ProyectoDictamenFilter, ProyectoDictamenResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoDictamenFilesCompose GetNew(ProyectoDictamenResult example)
        {
            ProyectoDictamenFilesCompose compose = base.GetNew();
            compose.ProyectoDictamen = null;
            compose.ProyectoDictamenFiles = new List<ProyectoDictamenFileResult>();
            return compose;
        }
        public override ProyectoDictamenFilesCompose GetNew()
        {
            ProyectoDictamenFilesCompose compose = base.GetNew();
            compose.ProyectoDictamen = null;
            compose.ProyectoDictamenFiles = new List<ProyectoDictamenFileResult>();
            return compose;
        }
        public override int GetId(ProyectoDictamenFilesCompose entity)
        {
            return entity.IdProyectoDictamen;
        }
        public override ProyectoDictamenFilesCompose GetById(int id)
        {
            ProyectoDictamenFilesCompose compose = new ProyectoDictamenFilesCompose();
            compose.ProyectoDictamen = ProyectoDictamenBusiness.Current.GetResultFromList(new ProyectoDictamenFilter() { IdProyectoDictamen = id }).FirstOrDefault(); ;
            compose.ProyectoDictamenFiles = ProyectoDictamenFileBusiness.Current.GetResult(new ProyectoDictamenFileFilter() { IdProyectoDictamen = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoDictamenFilesCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (ProyectoDictamenFileResult pfr in entity.ProyectoDictamenFiles)
                {
                    ProyectoDictamenFile pf = pfr.ToEntity();
                    pf.IdProyectoDictamen = entity.IdProyectoDictamen;
                    pfr.IdProyectoDictamenFile = 0;
                    ProyectoDictamenFileBusiness.Current.Add(pf, contextUser);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(ProyectoDictamenFilesCompose entity, IContextUser contextUser)
        {
            List<ProyectoDictamenFileResult> copy1 = ProyectoDictamenFileBusiness.Current.CopiesResult(entity.ProyectoDictamenFiles);
            try
            {
                // Elimina los que ya no estan
                List<int> actualIdsArch = (from o in entity.ProyectoDictamenFiles where o.IdProyectoDictamenFile > 0 select o.IdProyectoDictamenFile).ToList();
                List<ProyectoDictamenFile> oldDetailArch = ProyectoDictamenFileBusiness.Current.GetList(new ProyectoDictamenFileFilter() { IdProyectoDictamen = entity.IdProyectoDictamen });
                List<ProyectoDictamenFile> deletesArch = (from o in oldDetailArch where !actualIdsArch.Contains(o.IdProyectoDictamenFile) select o).ToList();

                List<int> deletedFilesArch = (from f in deletesArch select (Int32)f.IdFile).ToList();
                ProyectoDictamenFileBusiness.Current.Delete(deletesArch, contextUser);
                FileInfoBusiness.Current.Delete(deletedFilesArch.ToArray(), contextUser);
                

                foreach (ProyectoDictamenFileResult pfr in entity.ProyectoDictamenFiles)
                {
                    ProyectoDictamenFile pf = pfr.ToEntity();
                    pf.IdProyectoDictamen = entity.IdProyectoDictamen;
                    if (pfr.IdProyectoDictamenFile <= 0)
                    {
                        pf.IdProyectoDictamenFile = 0;
                        ProyectoDictamenFileBusiness.Current.Add(pf, contextUser);
                    }
                    else
                        ProyectoDictamenFileBusiness.Current.Update(pf, contextUser);
                    pfr.IdProyectoDictamenFile = pf.IdProyectoDictamenFile;
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.ProyectoDictamenFiles = copy1;
                throw exception;
            }
        }
        public override void Delete(ProyectoDictamenFilesCompose entity, IContextUser contextUser)
        {
            List<int> actualIdsArch = (from o in entity.ProyectoDictamenFiles where o.IdProyectoDictamenFile > 0 select o.IdProyectoDictamenFile).ToList();
            ProyectoDictamenFileBusiness.Current.Delete(actualIdsArch.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(ProyectoDictamenFilesCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            foreach (ProyectoDictamenFileResult pfr in entity.ProyectoDictamenFiles)
            {
                DataHelper.Validate(pfr.Fecha != null, "InvalidField", "InvalidField");
                DataHelper.Validate(pfr.Nombre != "", "InvalidField", "InvalidField");
            }
        }

        public override bool Can(ProyectoDictamenFilesCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return true;
        }

        public override bool Equals(ProyectoDictamenFilesCompose source, ProyectoDictamenFilesCompose target)
        {
            bool eq = source.IdProyectoDictamen.Equals(target.IdProyectoDictamen);


            if (source.ProyectoDictamenFiles.Count() != target.ProyectoDictamenFiles.Count()) return false;

            foreach (ProyectoDictamenFileResult pfr in source.ProyectoDictamenFiles)
            {
                if (target.ProyectoDictamenFiles.Where(t => t.IdProyectoDictamenFile == pfr.IdProyectoDictamenFile).Count() > 0)
                    eq = eq && pfr.Comparar(target.ProyectoDictamenFiles.Where(t => t.IdProyectoDictamenFile == pfr.IdProyectoDictamenFile).Single());
                else
                    eq = false;
            }

            return eq;
        }
        #endregion
    }
}
