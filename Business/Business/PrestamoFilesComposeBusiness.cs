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
    public class PrestamoFilesComposeBusiness : EntityComposeBusiness<PrestamoFilesCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoFilesComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoFilesComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoFilesComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }

        protected override IEntityData<PrestamoFilesCompose, PrestamoFilter, PrestamoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoFilesCompose GetNew(PrestamoResult example)
        {
            PrestamoFilesCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.PrestamoFiles = new List<PrestamoFileResult>();
            return compose;
        }
        public override PrestamoFilesCompose GetNew()
        {
            PrestamoFilesCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.PrestamoFiles = new List<PrestamoFileResult>();
            return compose;
        }
        public override int GetId(PrestamoFilesCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoFilesCompose GetById(int id)
        {
            PrestamoFilesCompose compose = new PrestamoFilesCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter(){ IdPrestamo= id}).FirstOrDefault();
            compose.PrestamoFiles = PrestamoFileBusiness.Current.GetResult(new PrestamoFileFilter(){ IdPrestamo = id});
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoFilesCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (PrestamoFileResult pfr in entity.PrestamoFiles)
                {
                    PrestamoFile pf = pfr.ToEntity();
                    pf.IdPrestamo = entity.IdPrestamo;
                    pfr.IdPrestamoFile = 0;
                    PrestamoFileBusiness.Current.Add(pf, contextUser);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(PrestamoFilesCompose entity, IContextUser contextUser)
        {
            List<PrestamoFileResult> copy1 = PrestamoFileBusiness.Current.CopiesResult(entity.PrestamoFiles);
            try
            {
                // Elimina los que ya no estan
                List<int> actualIdsArch = (from o in entity.PrestamoFiles where o.IdPrestamoFile > 0 select o.IdPrestamoFile).ToList();
                List<PrestamoFile> oldDetailArch = PrestamoFileBusiness.Current.GetList(new PrestamoFileFilter() { IdPrestamo = entity.IdPrestamo });
                List<PrestamoFile> deletesArch = (from o in oldDetailArch where !actualIdsArch.Contains(o.IdPrestamoFile) select o).ToList();

                List<int> deletedFilesArch = (from f in deletesArch select (Int32)f.IdFile).ToList();
                PrestamoFileBusiness.Current.Delete(deletesArch, contextUser);
                FileInfoBusiness.Current.Delete(deletedFilesArch.ToArray(), contextUser);
                
                foreach (PrestamoFileResult pfr in entity.PrestamoFiles)
                {
                    PrestamoFile pf = pfr.ToEntity();
                    pf.IdPrestamo = entity.IdPrestamo;
                    if (pfr.IdPrestamoFile <= 0)
                    {
                        pf.IdPrestamoFile = 0;
                        PrestamoFileBusiness.Current.Add(pf, contextUser);
                    }
                    else
                        PrestamoFileBusiness.Current.Update(pf, contextUser);
                    pfr.IdPrestamoFile = pf.IdPrestamoFile;
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.PrestamoFiles = copy1;
                throw exception;
            }
        }
        public override void Delete(PrestamoFilesCompose entity, IContextUser contextUser)
        {
            List<int> actualIdsArch = (from o in entity.PrestamoFiles where o.IdPrestamoFile > 0 select o.IdPrestamoFile).ToList();
            PrestamoFileBusiness.Current.Delete(actualIdsArch.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(PrestamoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            foreach (PrestamoFileResult pfr in entity.PrestamoFiles)
            {
                DataHelper.Validate(pfr.Fecha != null, "InvalidField", "InvalidField");
                DataHelper.Validate(pfr.Nombre != "", "InvalidField", "InvalidField");
            }
        }

        public override bool Can(PrestamoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(PrestamoFilesCompose source, PrestamoFilesCompose target)
        {
            bool eq = source.IdPrestamo.Equals(target.IdPrestamo);

            if(source.PrestamoFiles.Count() != target.PrestamoFiles.Count()) return false;

            foreach (PrestamoFileResult pfr in source.PrestamoFiles)
            {
                if (target.PrestamoFiles.Where(t => t.IdPrestamoFile == pfr.IdPrestamoFile).Count() > 0)
                    eq = eq && pfr.Comparar(target.PrestamoFiles.Where(t => t.IdPrestamoFile == pfr.IdPrestamoFile).Single());
                else
                    eq = false;
            }

            return eq;
        }
        #endregion
    }
}