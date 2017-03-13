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
    public class ProyectoSeguimientoFileBusiness : _ProyectoSeguimientoFileBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoSeguimientoFileBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoFileBusiness() {}
	   public static ProyectoSeguimientoFileBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoFileBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<ProyectoSeguimientoFileResult> GetWithFileInfo(Int32 IdProyectoSeguimiento)
       {
           return ProyectoSeguimientoFileData.Current.GetWithFileInfo(IdProyectoSeguimiento);
       }
    }
    public class ProyectoSeguimientoFilesComposeBusiness : EntityComposeBusiness<ProyectoSeguimientoFilesCompose, ProyectoSeguimiento, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
    {
        #region Singleton
        private static volatile ProyectoSeguimientoFilesComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoSeguimientoFilesComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoSeguimientoFilesComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<ProyectoSeguimiento, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int> EntityBusinessBase
        {
            get { return ProyectoSeguimientoBusiness.Current; }
        }

        protected override IEntityData<ProyectoSeguimientoFilesCompose, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoSeguimientoFilesCompose GetNew(ProyectoSeguimientoResult example)
        {
            ProyectoSeguimientoFilesCompose compose = base.GetNew();
            compose.ProyectoSeguimiento = null;
            compose.ProyectoSeguimientoFiles = new List<ProyectoSeguimientoFileResult>();
            return compose;
        }
        public override ProyectoSeguimientoFilesCompose GetNew()
        {
            ProyectoSeguimientoFilesCompose compose = base.GetNew();
            compose.ProyectoSeguimiento = null;
            compose.ProyectoSeguimientoFiles = new List<ProyectoSeguimientoFileResult>();
            return compose;
        }
        public override int GetId(ProyectoSeguimientoFilesCompose entity)
        {
            return entity.IdProyectoSeguimiento;
        }
        public override ProyectoSeguimientoFilesCompose GetById(int id)
        {
            ProyectoSeguimientoFilesCompose compose = new ProyectoSeguimientoFilesCompose();
            compose.ProyectoSeguimiento = ProyectoSeguimientoBusiness.Current.GetResult(new ProyectoSeguimientoFilter() { IdProyectoSeguimiento = id }).FirstOrDefault(); ;
            compose.ProyectoSeguimientoFiles = ProyectoSeguimientoFileBusiness.Current.GetResult(new ProyectoSeguimientoFileFilter() { IdProyectoSeguimiento = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoSeguimientoFilesCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (ProyectoSeguimientoFileResult pfr in entity.ProyectoSeguimientoFiles)
                {
                    ProyectoSeguimientoFile pf = pfr.ToEntity();
                    pf.IdProyectoSeguimiento = entity.IdProyectoSeguimiento;
                    pfr.IdProyectoSeguimientoFile = 0;
                    ProyectoSeguimientoFileBusiness.Current.Add(pf, contextUser);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(ProyectoSeguimientoFilesCompose entity, IContextUser contextUser)
        {
            List<ProyectoSeguimientoFileResult> copy1 = ProyectoSeguimientoFileBusiness.Current.CopiesResult(entity.ProyectoSeguimientoFiles);
            try
            {
                // Elimina los que ya no estan
                List<int> actualIdsArch = (from o in entity.ProyectoSeguimientoFiles where o.IdProyectoSeguimientoFile > 0 select o.IdProyectoSeguimientoFile).ToList();
                List<ProyectoSeguimientoFile> oldDetailArch = ProyectoSeguimientoFileBusiness.Current.GetList(new ProyectoSeguimientoFileFilter() { IdProyectoSeguimiento = entity.IdProyectoSeguimiento });
                List<ProyectoSeguimientoFile> deletesArch = (from o in oldDetailArch where !actualIdsArch.Contains(o.IdProyectoSeguimientoFile) select o).ToList();

                List<int> deletedFilesArch = (from f in deletesArch select (Int32)f.IdFile).ToList();
                FileInfoBusiness.Current.Delete(deletedFilesArch.ToArray(), contextUser);
                ProyectoSeguimientoFileBusiness.Current.Delete(deletesArch, contextUser);

                foreach (ProyectoSeguimientoFileResult pfr in entity.ProyectoSeguimientoFiles)
                {
                    ProyectoSeguimientoFile pf = pfr.ToEntity();
                    pf.IdProyectoSeguimiento = entity.IdProyectoSeguimiento;
                    if (pfr.IdProyectoSeguimientoFile <= 0)
                    {
                        pf.IdProyectoSeguimientoFile = 0;
                        ProyectoSeguimientoFileBusiness.Current.Add(pf, contextUser);
                    }
                    else
                        ProyectoSeguimientoFileBusiness.Current.Update(pf, contextUser);
                    pfr.IdProyectoSeguimientoFile = pf.IdProyectoSeguimientoFile;
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.ProyectoSeguimientoFiles = copy1;
                throw exception;
            }
        }
        public override void Delete(ProyectoSeguimientoFilesCompose entity, IContextUser contextUser)
        {
            List<int> actualIdsArch = (from o in entity.ProyectoSeguimientoFiles where o.IdProyectoSeguimientoFile > 0 select o.IdProyectoSeguimientoFile).ToList();
            ProyectoSeguimientoFileBusiness.Current.Delete(actualIdsArch.ToArray(), contextUser);
        }
        #endregion

        #region Validations

        public override void Validate(ProyectoSeguimientoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            foreach (ProyectoSeguimientoFileResult pfr in entity.ProyectoSeguimientoFiles)
            {
                DataHelper.Validate(pfr.Fecha != null, "InvalidField", "InvalidField");
                DataHelper.Validate(pfr.Nombre != "", "InvalidField", "InvalidField");
            }
        }

        public override bool Can(ProyectoSeguimientoFilesCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(ProyectoSeguimientoFilesCompose source, ProyectoSeguimientoFilesCompose target)
        {
            bool eq = source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento);

            if(source.ProyectoSeguimientoFiles.Count() != target.ProyectoSeguimientoFiles.Count()) return false;

            foreach (ProyectoSeguimientoFileResult pfr in source.ProyectoSeguimientoFiles)
            {
                if (target.ProyectoSeguimientoFiles.Where(t => t.IdProyectoSeguimientoFile == pfr.IdProyectoSeguimientoFile).Count() > 0)
                    eq = eq && pfr.Comparar(target.ProyectoSeguimientoFiles.Where(t => t.IdProyectoSeguimientoFile == pfr.IdProyectoSeguimientoFile).Single());
                else
                    eq = false;
            }

            return eq;
        }
        #endregion
    }
}
