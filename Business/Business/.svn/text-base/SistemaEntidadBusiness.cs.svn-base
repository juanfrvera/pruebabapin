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
    public class SistemaEntidadComposeBusiness : EntityComposeBusiness<SistemaEntidadCompose, SistemaEntidad, SistemaEntidadFilter, SistemaEntidadResult, int> 
    {   
	   #region Singleton
       private static volatile SistemaEntidadComposeBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadBusiness() {}
       public static SistemaEntidadComposeBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null)
                       current = new SistemaEntidadComposeBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       protected override EntityBusiness<SistemaEntidad, SistemaEntidadFilter, SistemaEntidadResult, int> EntityBusinessBase
       {
           get { return SistemaEntidadBusiness.Current; }
       }
       #region Gets
       public override SistemaEntidadCompose GetNew(SistemaEntidadResult example)
       {
           SistemaEntidadCompose compose = base.GetNew();
           compose.Entidad = example;
           compose.Acciones = ToSistemaEntidadAcciones(SistemaAccionBusiness.Current.GetResult(new SistemaAccionFilter() { Activo = true }));
           compose.Estados = ToSistemaEntidadEstados(EstadoBusiness.Current.GetResult(new EstadoFilter() { Activo = true }));
           return compose;
       }
       public override SistemaEntidadCompose GetNew()
       {
           SistemaEntidadResult example = new SistemaEntidadResult();
           example.Activo = true;
           SistemaEntidadBusiness.Current.Set(SistemaEntidadBusiness.Current.GetNew(), example);
           return GetNew(example);
       }
       public override int GetId(SistemaEntidadCompose entity)
       {
           return entity.Entidad.IdSistemaEntidad;
       }
       public override SistemaEntidadCompose GetById(int id)
       {
           SistemaEntidadCompose compose = new SistemaEntidadCompose();
           compose.Entidad = SistemaEntidadBusiness.Current.GetResult(new SistemaEntidadFilter() { IdSistemaEntidad = id }).FirstOrDefault();
           //obtiene los acciones y estados asociados y los que no estan asociados
           List < SistemaAccionResult > acciones = SistemaAccionBusiness.Current.GetResult(new SistemaAccionFilter() { Activo = true });
           List < EstadoResult > estados = EstadoBusiness.Current.GetResult(new EstadoFilter() { Activo = true });
           List < SistemaEntidadAccionResult > entidadAcciones = SistemaEntidadAccionBusiness.Current.GetResult(new SistemaEntidadAccionFilter() { IdSistemaEntidad = id });
           List < SistemaEntidadEstadoResult > entidadEstados = SistemaEntidadEstadoBusiness.Current.GetResult(new SistemaEntidadEstadoFilter() { IdSistemaEntidad = id });
           entidadAcciones.ForEach(p => p.Selected = true);
           entidadEstados.ForEach(p => p.Selected = true);       

           List<SistemaEntidadAccionResult> unselectedAcciones = (from a in acciones
                                                          where !(from ea in entidadAcciones select ea.IdSistemaAccion).Contains(a.IdSistemaAccion)
                                                          select ToSistemaEntidadAcciones(a)).ToList();
           List<SistemaEntidadEstadoResult> unselectedEstados = (from e in estados
                                                          where !(from ee in entidadEstados select ee.IdEstado).Contains(e.IdEstado)
                                                          select ToSistemaEntidadEstados(e)).ToList();

           entidadAcciones.AddRange(unselectedAcciones);
           compose.Acciones = entidadAcciones;
           entidadEstados.AddRange(unselectedEstados);
           compose.Estados = entidadEstados;
           return compose;
       }
       #endregion
       #region Actions
       public override void Add(SistemaEntidadCompose entity, IContextUser contextUser)
       {           
           SistemaEntidad entidad = entity.Entidad.ToEntity();
           SistemaEntidadBusiness.Current.Add(entidad, contextUser);
           entity.Entidad.IdSistemaEntidad = entidad.IdSistemaEntidad;

           foreach (SistemaEntidadAccionResult accion in entity.Acciones)
           {
               if (accion.Selected && accion.IdSistemaEntidadAccion < 1)
               {
                   SistemaEntidadAccion entidadAccion = SistemaEntidadAccionBusiness.Current.GetNew();
                   entidadAccion.IdSistemaAccion = accion.IdSistemaAccion;
                   entidadAccion.IdSistemaEntidad = entidad.IdSistemaEntidad;
                   entidadAccion.Nombre = accion.Nombre;
                   SistemaEntidadAccionBusiness.Current.Add(entidadAccion, contextUser);
                   accion.IdSistemaEntidadAccion = entidadAccion.IdSistemaEntidadAccion;
               }
           }
           foreach (SistemaEntidadEstadoResult estado in entity.Estados)
           {
               if (estado.Selected && estado.IdSistemaEntidadEstado < 1)
               {
                   SistemaEntidadEstado entidadEstado = SistemaEntidadEstadoBusiness.Current.GetNew();
                   entidadEstado.IdEstado = estado.IdEstado;
                   entidadEstado.IdSistemaEntidad = entidad.IdSistemaEntidad;
                   entidadEstado.Nombre = estado.Nombre;
                   SistemaEntidadEstadoBusiness.Current.Add(entidadEstado, contextUser);
                   estado.IdSistemaEntidadEstado = entidadEstado.IdSistemaEntidadEstado;
               }
           }
           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad(entity.Entidad.IdSistemaEntidad);
           SolutionContext.Current.AuthorizationManager.Refresh();           
       }
       public override void Update(SistemaEntidadCompose entity, IContextUser contextUser)
       {
           SistemaEntidad entidad = SistemaEntidadBusiness.Current.GetById(entity.Entidad.IdSistemaEntidad);
           SistemaEntidadBusiness.Current.Set(entity.Entidad, entidad);
           SistemaEntidadBusiness.Current.Update(entidad, contextUser);
       
           foreach (SistemaEntidadAccionResult accion in entity.Acciones)
           {
               if (accion.Selected && accion.IdSistemaEntidadAccion < 1)
               {
                   SistemaEntidadAccion entidadAccion = SistemaEntidadAccionBusiness.Current.GetNew();
                   entidadAccion.IdSistemaAccion = accion.IdSistemaAccion;
                   entidadAccion.IdSistemaEntidad = entidad.IdSistemaEntidad;
                   entidadAccion.Nombre = accion.Nombre;
                   SistemaEntidadAccionBusiness.Current.Add(entidadAccion, contextUser);
                   accion.IdSistemaEntidadAccion = entidadAccion.IdSistemaEntidadAccion;
               }
               if (!accion.Selected && accion.IdSistemaEntidadAccion > 1)
               {
                   SistemaEntidadAccionBusiness.Current.Delete(accion.IdSistemaEntidadAccion, contextUser);
               }
           }
           foreach (SistemaEntidadEstadoResult estado in entity.Estados)
           {
               if (estado.Selected && estado.IdSistemaEntidadEstado < 1)
               {
                   SistemaEntidadEstado entidadEstado = SistemaEntidadEstadoBusiness.Current.GetNew();
                   entidadEstado.IdEstado = estado.IdEstado;
                   entidadEstado.IdSistemaEntidad = entidad.IdSistemaEntidad;
                   entidadEstado.Nombre = estado.Nombre;
                   SistemaEntidadEstadoBusiness.Current.Add(entidadEstado, contextUser);
                   estado.IdSistemaEntidadEstado = entidadEstado.IdSistemaEntidadEstado;
               }
               if (!estado.Selected && estado.IdSistemaEntidadEstado > 1)
               {
                   SistemaEntidadEstadoBusiness.Current.Delete(estado.IdSistemaEntidadEstado, contextUser);
               }
           }

           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad(entity.Entidad.IdSistemaEntidad);
           SolutionContext.Current.AuthorizationManager.Refresh();

           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       public override void Delete(SistemaEntidadCompose entity, IContextUser contextUser)
       {
           SistemaEntidadBusiness.Current.Delete(entity.Entidad.IdSistemaEntidad, contextUser);
       }
       #endregion

       #region protected Methods
       protected List<SistemaEntidadAccionResult> ToSistemaEntidadAcciones(List<SistemaAccionResult> acciones)
       {
           List<SistemaEntidadAccionResult> target = new List<SistemaEntidadAccionResult>(acciones.Count);
           foreach (SistemaAccionResult accion in acciones)
               target.Add(ToSistemaEntidadAcciones(accion));
           return target;
       }
       protected SistemaEntidadAccionResult ToSistemaEntidadAcciones(SistemaAccionResult accion)
       {
           SistemaEntidadAccionResult target = new SistemaEntidadAccionResult();
           target.IdSistemaAccion = accion.IdSistemaAccion;
           target.SistemaAccion_Activo = accion.Activo;
           target.SistemaAccion_Nombre = accion.Nombre;
           target.Selected = false;
           target.Nombre = accion.Nombre;
           return target;
       }
       protected List<SistemaEntidadEstadoResult> ToSistemaEntidadEstados(List<EstadoResult> estados)
       {
           List<SistemaEntidadEstadoResult> target = new List<SistemaEntidadEstadoResult>(estados.Count);
           foreach (EstadoResult estado in estados)
               target.Add(ToSistemaEntidadEstados(estado));
           return target;
       }
       protected SistemaEntidadEstadoResult ToSistemaEntidadEstados(EstadoResult estado)
       {
           SistemaEntidadEstadoResult target = new SistemaEntidadEstadoResult();
           target.IdEstado = estado.IdEstado;
           target.Estado_Activo = estado.Activo;
           target.Estado_Nombre = estado.Nombre;
           target.Selected = false;
           target.Nombre = estado.Nombre;
           return target;
       }
       #endregion

       #region Validations
       public override void Validate(SistemaEntidadCompose entity, string actionName, IContextUser contextUser,Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           SistemaEntidadBusiness.Current.Validate(SistemaEntidadBusiness.Current.ToEntity(entity.Entidad), actionName, contextUser, args);
       }
       public override bool Can(SistemaEntidadCompose entity, string actionName, IContextUser contextUser,Hashtable args)
       {
           return SistemaEntidadBusiness.Current.Can(SistemaEntidadBusiness.Current.ToEntity(entity.Entidad), actionName, contextUser, args);
       }
       #endregion
    }
    public class SistemaEntidadBusiness : _SistemaEntidadBusiness
    {
        #region Singleton
        private static volatile SistemaEntidadBusiness current;
        private static object syncRoot = new Object();

        //private SistemaEntidadBusiness() {}
        public static SistemaEntidadBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new SistemaEntidadBusiness();
                    }
                }
                return current;
            }
        }
        #endregion
        public override SistemaEntidad GetNew()
        {
            SistemaEntidad   entity = base.GetNew();
            entity.Activo = true;
            return entity;
        }
        public override void Delete(SistemaEntidad entity, IContextUser contextUser)
        {
            Delete(entity.IdSistemaEntidad, contextUser);
        }
        public override void Delete(int id, IContextUser contextUser)
        {
            SistemaEntidadAccionBusiness.Current.Delete(new SistemaEntidadAccionFilter() { IdSistemaEntidad = id }, contextUser);
            SistemaEntidadEstadoBusiness.Current.Delete(new SistemaEntidadEstadoFilter() { IdSistemaEntidad = id }, contextUser);
            base.Delete(id, contextUser);
        }

        #region Procedures
        public void RefreshPermisosPorEntidad()
        {
            Data.RefreshPermisosPorEntidad(null);
        }
        public void RefreshPermisosPorEntidad(int? idEntidad)
        {
            Data.RefreshPermisosPorEntidad(idEntidad);
        }
        #endregion
    }
}
