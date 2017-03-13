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
    public class PrestamoDictamenFilesComposeBusiness : EntityComposeBusiness<PrestamoDictamenFilesCompose, PrestamoDictamen, PrestamoDictamenFilter, PrestamoDictamenResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenFilesComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoDictamenFilesComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenFilesComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<PrestamoDictamen, PrestamoDictamenFilter, PrestamoDictamenResult, int> EntityBusinessBase
        {
            get { return PrestamoDictamenBusiness.Current; }
        }

        protected override IEntityData<PrestamoDictamenFilesCompose, PrestamoDictamenFilter, PrestamoDictamenResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoDictamenFilesCompose GetNew(PrestamoDictamenResult example)
        {
            PrestamoDictamenFilesCompose compose = base.GetNew();
            compose.PrestamoDictamen = null;
            compose.PrestamoDictamenFiles = new List<PrestamoDictamenFileResult>();
            return compose;
        }
        public override PrestamoDictamenFilesCompose GetNew()
        {
            PrestamoDictamenFilesCompose compose = base.GetNew();
            compose.PrestamoDictamen = null;
            compose.PrestamoDictamenFiles = new List<PrestamoDictamenFileResult>();
            return compose;
        }
        public override int GetId(PrestamoDictamenFilesCompose entity)
        {
            return entity.IdPrestamoDictamen;
        }
        public override PrestamoDictamenFilesCompose GetById(int id)
        {
            PrestamoDictamenFilesCompose compose = new PrestamoDictamenFilesCompose();
            compose.PrestamoDictamen = PrestamoDictamenBusiness.Current.GetResultFromList(new PrestamoDictamenFilter() { IdPrestamoDictamen = id }).FirstOrDefault(); ;
            compose.PrestamoDictamenFiles = PrestamoDictamenFileBusiness.Current.GetResult(new PrestamoDictamenFileFilter() { IdPrestamoDictamen = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoDictamenFilesCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (PrestamoDictamenFileResult pfr in entity.PrestamoDictamenFiles)
                {
                    PrestamoDictamenFile pf = pfr.ToEntity();
                    pf.IdPrestamoDictamen = entity.IdPrestamoDictamen;
                    pfr.IdPrestamoDictamenFile = 0;
                    PrestamoDictamenFileBusiness.Current.Add(pf, contextUser);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(PrestamoDictamenFilesCompose entity, IContextUser contextUser)
        {
            List<PrestamoDictamenFileResult> copy1 = PrestamoDictamenFileBusiness.Current.CopiesResult(entity.PrestamoDictamenFiles);
            try
            {
                // Elimina los que ya no estan
                List<int> actualIdsArch = (from o in entity.PrestamoDictamenFiles where o.IdPrestamoDictamenFile > 0 select o.IdPrestamoDictamenFile).ToList();
                List<PrestamoDictamenFile> oldDetailArch = PrestamoDictamenFileBusiness.Current.GetList(new PrestamoDictamenFileFilter() { IdPrestamoDictamen = entity.IdPrestamoDictamen });
                List<PrestamoDictamenFile> deletesArch = (from o in oldDetailArch where !actualIdsArch.Contains(o.IdPrestamoDictamenFile) select o).ToList();

                List<int> deletedFilesArch = (from f in deletesArch select (Int32)f.IdFile).ToList();
                FileInfoBusiness.Current.Delete(deletedFilesArch.ToArray(), contextUser);
                PrestamoDictamenFileBusiness.Current.Delete(deletesArch, contextUser);

                foreach (PrestamoDictamenFileResult pfr in entity.PrestamoDictamenFiles)
                {
                    PrestamoDictamenFile pf = pfr.ToEntity();
                    pf.IdPrestamoDictamen = entity.IdPrestamoDictamen;
                    if (pfr.IdPrestamoDictamenFile <= 0)
                    {
                        pf.IdPrestamoDictamenFile = 0;
                        PrestamoDictamenFileBusiness.Current.Add(pf, contextUser);
                    }
                    else
                        PrestamoDictamenFileBusiness.Current.Update(pf, contextUser);
                    pfr.IdPrestamoDictamenFile = pf.IdPrestamoDictamenFile;
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.PrestamoDictamenFiles = copy1;
                throw exception;
            }
        }
        public override void Delete(PrestamoDictamenFilesCompose entity, IContextUser contextUser)
        {
            List<int> actualIdsArch = (from o in entity.PrestamoDictamenFiles where o.IdPrestamoDictamenFile > 0 select o.IdPrestamoDictamenFile).ToList();
            PrestamoDictamenFileBusiness.Current.Delete(actualIdsArch.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(PrestamoDictamenFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            foreach (PrestamoDictamenFileResult pfr in entity.PrestamoDictamenFiles)
            {
                DataHelper.Validate(pfr.Fecha != null, "InvalidField", "InvalidField");
                DataHelper.Validate(pfr.Nombre != "", "InvalidField", "InvalidField");
            }
        }

        public override bool Can(PrestamoDictamenFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(PrestamoDictamenFilesCompose source, PrestamoDictamenFilesCompose target)
        {
            bool eq = source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen); 


            if(source.PrestamoDictamenFiles.Count() != target.PrestamoDictamenFiles.Count()) return false;

            foreach (PrestamoDictamenFileResult pfr in source.PrestamoDictamenFiles)
            {
                if (target.PrestamoDictamenFiles.Where(t => t.IdPrestamoDictamenFile == pfr.IdPrestamoDictamenFile).Count() > 0)
                    eq = eq && pfr.Comparar(target.PrestamoDictamenFiles.Where(t => t.IdPrestamoDictamenFile == pfr.IdPrestamoDictamenFile).Single());
                else
                    eq = false;
            }

            return eq;
        }
        #endregion
    }
}