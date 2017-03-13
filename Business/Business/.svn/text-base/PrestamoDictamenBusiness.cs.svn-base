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
    public class PrestamoDictamenBusiness : _PrestamoDictamenBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoDictamenBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenBusiness() {}
	   public static PrestamoDictamenBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<PrestamoDictamenResult> QueryResultExcel(PrestamoDictamenFilter filter)
       {
           return PrestamoDictamenData.Current.QueryResultExcel(filter);
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           PrestamoDictamenEstadoBusiness.Current.Delete(new PrestamoDictamenEstadoFilter() { IdPrestamoDictamen = id }, contextUser);
           PrestamoDictamenFileBusiness.Current.Delete(new PrestamoDictamenFileFilter() { IdPrestamoDictamen = id }, contextUser);
           //PrestamoDictamenBusiness.Current.Delete(entity.Dictamen.ID, contextUser);
           base.Delete(id, contextUser);
       }
    }
    

    public class PrestamoEditDictamenComposeBusiness : EntityComposeBusiness<PrestamoEditDictamenCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoEditDictamenComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoEditDictamenComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoEditDictamenComposeBusiness();
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

        protected override IEntityData<PrestamoEditDictamenCompose, PrestamoFilter, PrestamoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoEditDictamenCompose GetNew(PrestamoResult example)
        {
            return GetNew();
        }
        public override PrestamoEditDictamenCompose GetNew()
        {
            return new PrestamoEditDictamenCompose(); 
        }
        public override int GetId(PrestamoEditDictamenCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoEditDictamenCompose GetById(int id)
        {
            PrestamoEditDictamenCompose compose = new PrestamoEditDictamenCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter(){ IdPrestamo= id}).FirstOrDefault();
            compose.Dictamenes = PrestamoDictamenBusiness.Current.GetResult(new PrestamoDictamenFilter() { IdPrestamo = id });
            compose.ProyectoComentarioTecnico = ProyectoComentarioTecnicoBusiness.Current.GetResult(new ProyectoComentarioTecnicoFilter() { IdPrestamo = id });
            return compose;
        }
        #endregion 

        #region Actions
        public override void Add(PrestamoEditDictamenCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override void Update(PrestamoEditDictamenCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override void Delete(PrestamoEditDictamenCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(PrestamoEditDictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            throw new NotImplementedException();
        }

        public override bool Can(PrestamoEditDictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion
    }

    public class PrestamoDictamenComposeBusiness : EntityComposeBusiness<PrestamoDictamenCompose, PrestamoDictamen, PrestamoDictamenFilter, PrestamoDictamenResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoDictamenComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(PrestamoDictamenCompose entity)
        {
            return entity.IdPrestamoDictamen;
        }

        public override PrestamoDictamenCompose GetById(int id)
        {
            // PrestamoDictamenCompose

            PrestamoDictamenCompose PrestamoDictamenCompose = new PrestamoDictamenCompose();

            // PrestamoDictamens

            PrestamoDictamenCompose.Dictamen =
                PrestamoDictamenBusiness.Current.GetResult(new PrestamoDictamenFilter() { IdPrestamoDictamen = id }).FirstOrDefault();

            // PrestamoDictamenEstados

            PrestamoDictamenCompose.Estados =
                PrestamoDictamenEstadoBusiness.Current.GetResult(new PrestamoDictamenEstadoFilter() { IdPrestamoDictamen = id }).ToList();

            //PrestamoDictamenCompose.IdPrestamoDictamen = id;


            return PrestamoDictamenCompose;
        }

        #region Actions
        public override void Add(PrestamoDictamenCompose entity, IContextUser contextUser)
        {
            entity.Dictamen.FechaAlta = DateTime.Now;
            entity.Dictamen.FechaModificacion = DateTime.Now;
            entity.Dictamen.IDUsuarioModificacion = contextUser.User.IdUsuario;



            PrestamoDictamen prestamoDictamen = entity.Dictamen.ToEntity();
            PrestamoDictamenBusiness.Current.Add(prestamoDictamen, contextUser);
            //entity.IdPrestamoDictamen = PrestamoDictamen.IdPrestamoDictamen;
            //entity.Dictamen.IdPrestamoDictamen = entity.IdPrestamoDictamen;
            entity.Dictamen.IdPrestamoDictamen = prestamoDictamen.IdPrestamoDictamen;



            foreach (PrestamoDictamenEstadoResult pder in entity.Estados)
            {
                pder.IdPrestamoDictamen = entity.IdPrestamoDictamen;
                PrestamoDictamenEstado pde = pder.ToEntity();
                PrestamoDictamenEstadoBusiness.Current.Add(pde, contextUser);
                pder.IdPrestamoDictamenEstado = pde.IdPrestamoDictamenEstado;
            }

            if (entity.Estados.Count > 0)
            {
                PrestamoDictamenEstadoResult result = entity.Estados.Last();
                entity.Dictamen.IdPrestamoDictamenEstado = result.IdPrestamoDictamenEstado;
                prestamoDictamen.IdPrestamoDictamenEstado = result.IdPrestamoDictamenEstado;
                PrestamoDictamenBusiness.Current.Update(prestamoDictamen, contextUser);
                //entity.Dictamen.FechaEstado = result.Fecha;
            }

            
        }
        public override void Update(PrestamoDictamenCompose entity, IContextUser contextUser)
        {

            // Actualizo los PrestamoDictamens
            entity.Dictamen.FechaModificacion = DateTime.Now;
            entity.Dictamen.IDUsuarioModificacion = contextUser.User.IdUsuario;

            PrestamoDictamen pd = PrestamoDictamenBusiness.Current.GetById(entity.Dictamen.IdPrestamoDictamen );
            PrestamoDictamenBusiness.Current.Set(entity.Dictamen, pd);

            PrestamoDictamenBusiness.Current.Update(pd, contextUser);

            // Actualizo los PrestamoDictamenEstados

            List<int> actualPrestamoDictamenEstadoIds = (from o in entity.Estados
                                    where o.IdPrestamoDictamenEstado > 0
                                    select o.IdPrestamoDictamenEstado).ToList();

            List<PrestamoDictamenEstado> oldPrestamoDictamenEstadoDetail =
                PrestamoDictamenEstadoBusiness.Current.GetList(new PrestamoDictamenEstadoFilter() { IdPrestamoDictamen = entity.IdPrestamoDictamen });
            List<int> deletePrestamoDictamenEstadoIds = (from o in oldPrestamoDictamenEstadoDetail
                                                      where !actualPrestamoDictamenEstadoIds.Contains(o.IdPrestamoDictamenEstado)
                                                      select o.IdPrestamoDictamenEstado).ToList();

            foreach (int id in deletePrestamoDictamenEstadoIds)
            {
                PrestamoDictamenEstado sb = PrestamoDictamenEstadoBusiness.Current.GetById(id);
                PrestamoDictamenEstadoBusiness.Current.Delete(sb, contextUser);
            }


            foreach (PrestamoDictamenEstadoResult spr in entity.Estados)
            {
                if (spr.IdPrestamoDictamenEstado < 1)
                {
                    spr.IdPrestamoDictamen = entity.IdPrestamoDictamen;
                    //spr.Fecha = DateTime.Now;
                    PrestamoDictamenEstado PrestamoDictamenEstado = spr.ToEntity();
                    PrestamoDictamenEstadoBusiness.Current.Add(PrestamoDictamenEstado, contextUser);
                    //spr.Set(PrestamoDictamenEstado);
                    spr.IdPrestamoDictamenEstado = PrestamoDictamenEstado.IdPrestamoDictamenEstado;


                }
                else
                {
                    PrestamoDictamenEstado pde = PrestamoDictamenEstadoBusiness.Current.GetById(spr.IdPrestamoDictamenEstado);
                    PrestamoDictamenEstadoBusiness.Current.Set(spr, pde);
                    PrestamoDictamenEstadoBusiness.Current.Update(pde, contextUser);
                }
            }

            if (entity.Estados.Count > 0)
            {
                PrestamoDictamenEstadoResult result = entity.Estados.Last();
                entity.Dictamen.IdPrestamoDictamenEstado = result.IdPrestamoDictamenEstado;
                //entity.Dictamen.FechaEstado = result.Fecha;
            }

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }

        public override PrestamoDictamenCompose GetNew()
        {
            PrestamoDictamenCompose pdc = new PrestamoDictamenCompose();
            pdc.Dictamen = new PrestamoDictamenResult();
            return pdc;
        }


        public override void Delete(PrestamoDictamenCompose entity, IContextUser contextUser)
        {

            //entity.Estados.ForEach(p => PrestamoDictamenEstadoBusiness.Current.Delete(p.ID, contextUser));
            PrestamoDictamenEstadoBusiness.Current.Delete(new PrestamoDictamenEstadoFilter() { IdPrestamoDictamen = entity.Dictamen.IdPrestamoDictamen }, contextUser);
            PrestamoDictamenBusiness.Current.Delete(entity.Dictamen.ID, contextUser);

        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<PrestamoDictamen, PrestamoDictamenFilter, PrestamoDictamenResult, int> EntityBusinessBase
        {
            get { return PrestamoDictamenBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(PrestamoDictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            DataHelper.Validate(entity.Estados.Count > 0, "Debe Asignar un Estado al Dictamen");
            DataHelper.Validate(entity.Dictamen.IdPrestamo != null && entity.Dictamen.IdPrestamo > 0, "Por favor especifique un prestamo valido");

            PrestamoDictamenResult pd = PrestamoDictamenBusiness.Current.GetResult(new PrestamoDictamenFilter() {
                IdGestionTipo = entity.Dictamen.IdGestionTipo, IdPrestamo = entity.Dictamen.IdPrestamo }).FirstOrDefault();           
            if (pd != null)
                DataHelper.Validate(pd.ID == entity.Dictamen.ID, "Puede existir solo un dictamen por préstamo y tipo de gestión");            




        }

        public override bool Can(PrestamoDictamenCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(PrestamoDictamenCompose source, PrestamoDictamenCompose target)
        {
            bool eq = PrestamoDictamenBusiness.Current.Equals(source.Dictamen, target.Dictamen);
            if (eq)
            {
                if (source.Estados.Count() != target.Estados.Count()) return false;
                bool eqSet = true;
                foreach (PrestamoDictamenEstadoResult pde in source.Estados)
                {
                    PrestamoDictamenEstadoResult pdeTarget = target.Estados.Where(p => p.IdPrestamoDictamenEstado == pde.IdPrestamoDictamenEstado).SingleOrDefault();

                    if (pdeTarget == null) return false;

                    if (!PrestamoDictamenEstadoBusiness.Current.Equals(pde, pdeTarget)) return false;
                }
                if (!eqSet) return eqSet;
                eqSet = true;
            }
            return eq;
        }



    }





}
