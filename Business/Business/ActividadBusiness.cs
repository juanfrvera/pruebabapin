using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;
using System.Runtime.Serialization;

namespace Business
{
    public static class SingletonsBusiness
    {
        public static int COUNT_CHANGES;
    }
    public class ActividadComposeBusiness : EntityComposeBusiness<ActividadCompose, Actividad, ActividadFilter, ActividadResult, int>
    {
        #region Singleton
        private static volatile ActividadComposeBusiness current;
        private static object syncRoot = new Object();

        public ActividadComposeBusiness()
        {
            SingletonsBusiness.COUNT_CHANGES = 0;
        }
        
        public static ActividadComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ActividadComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Actividad, ActividadFilter, ActividadResult, int> EntityBusinessBase
        {
            get { return ActividadBusiness.Current; }
        }
        #region Gets
        public override ActividadCompose GetNew(ActividadResult example)
        {
            ActividadCompose compose = base.GetNew();
            compose.Actividad = example;
            compose.ActividadPermisos = ToActividadPermisos(PermisoBusiness.Current.GetResult(new PermisoFilter() { Activo = true }));
            return compose;
        }
         public override ActividadCompose GetNew()
        {
            ActividadResult example = new ActividadResult();
            example.Activo = true;
            ActividadBusiness.Current.Set(ActividadBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(ActividadCompose entity)
        {
            return entity.Actividad.IdActividad;
        }
        public override ActividadCompose GetById(int id)
        {
            ActividadCompose compose = new ActividadCompose();
            compose.Actividad = ActividadBusiness.Current.GetResult(new ActividadFilter() { IdActividad = id }).FirstOrDefault();
            //obtiene los permisos asociados y los que no estan asociados
            List<PermisoResult> permisos = PermisoBusiness.Current.GetResult(new PermisoFilter(){ Activo = true});
            List<ActividadPermisoResult> actividadPermisos = ActividadPermisoBusiness.Current.GetResult(new ActividadPermisoFilter() { IdActividad = id, Activo = true });
            List<ActividadPermisoResult> unselected = (from p in permisos
                                                       where !(from ap in actividadPermisos select ap.IdPermiso).Contains(p.IdPermiso)
                                                       select ToActividadPermiso(p)).ToList();
            
            actividadPermisos.AddRange(unselected);
            compose.ActividadPermisos = actividadPermisos;

            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ActividadCompose entity, IContextUser contextUser)
        {
            ActividadPermiso actividadPermiso;          
            try
            {
                Actividad actividad = entity.Actividad.ToEntity();
                ActividadBusiness.Current.Add(actividad, contextUser);
                entity.Actividad.IdActividad = actividad.IdActividad;

                foreach (ActividadPermisoResult permiso in entity.ActividadPermisos)
                {
                    if (permiso.Selected && permiso.IdActividadPermiso < 1)
                    {
                       actividadPermiso = ActividadPermisoBusiness.Current.GetNew();
                       actividadPermiso.IdActividad = actividad.IdActividad;
                       actividadPermiso.IdPermiso = permiso.IdPermiso;
                       ActividadPermisoBusiness.Current.Add(actividadPermiso, contextUser);
                       permiso.IdActividadPermiso = actividadPermiso.IdActividadPermiso;  
                    }
                }
                SolutionContext.Current.AuthorizationManager.Refresh();
            }
            catch (Exception exception)
            {
                entity.Actividad.IdActividad = 0;
                entity.ActividadPermisos.ForEach(p => p.IdActividadPermiso = 0);
                throw exception;
            }
        }
        public override void Update(ActividadCompose entity, IContextUser contextUser)
        {
            ActividadPermiso actividadPermiso;
            List<ActividadPermisoResult> copyActividadPermisos = ActividadPermisoBusiness.Current.CopiesResult(entity.ActividadPermisos);
            try
            {                
                //Matias 20131031 - Tarea 0 - Solucionar tema Guardar en Perfiles (Ver si corresponde a la tarea 0 - Duda 20131031)
                //Actividad actividad = entity.Actividad.ToEntity();
                Actividad actividad = ActividadBusiness.Current.GetById(entity.Actividad.ID);
                actividad.IdActividad = entity.Actividad.IdActividad;
                actividad.Activo = entity.Actividad.Activo;
                actividad.Nombre = entity.Actividad.Nombre;
                //ActividadBusiness.Current.Set(entity.Actividad, actividad);//Matias 20120703 - Agregado ahora (no es original)
                //FinMatias 20131031 - Tarea 0 (Ver si corresponde a la tarea 0 - Duda 20131031)
                ActividadBusiness.Current.Update(actividad, contextUser);
               
                foreach (ActividadPermisoResult permiso in entity.ActividadPermisos)
                {
                    if (permiso.Selected && permiso.IdActividadPermiso < 1)
                    {
                        actividadPermiso = ActividadPermisoBusiness.Current.GetNew();
                        actividadPermiso.IdActividad = actividad.IdActividad;
                        actividadPermiso.IdPermiso = permiso.IdPermiso;
                        ActividadPermisoBusiness.Current.Add(actividadPermiso, contextUser);
                        permiso.IdActividadPermiso = actividadPermiso.IdActividadPermiso;
                        
                    }
                    if (!permiso.Selected && permiso.IdActividadPermiso > 1)
                    {
                        ActividadPermisoBusiness.Current.Delete(permiso.IdActividadPermiso, contextUser);
                    }
                }
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                SolutionContext.Current.AuthorizationManager.Refresh();
                Singletons.COUNT_CHANGES=0;
                
                
            }
            catch (Exception exception)
            {
                entity.ActividadPermisos = copyActividadPermisos;
                throw exception;
            }
        }

        public override void Delete(ActividadCompose entity, IContextUser contextUser)
        {
            ActividadBusiness.Current.Delete(entity.Actividad.IdActividad, contextUser);
        }
        #endregion

        #region protected Methods
        protected List<ActividadPermisoResult> ToActividadPermisos(List<PermisoResult> permisos)
        {
            List<ActividadPermisoResult> target = new List<ActividadPermisoResult>(permisos.Count);
            foreach (PermisoResult permiso in permisos)
                target.Add(ToActividadPermiso(permiso));
            return target;
        }
        protected ActividadPermisoResult ToActividadPermiso(PermisoResult permiso)
        {
            ActividadPermisoResult target = new ActividadPermisoResult();
            target.IdPermiso = permiso.IdPermiso;
            target.Selected = false;
            //target.IdActividad = 0;
            //target.Actividad_Nombre = "";
            //target.Actividad_Activo = false;
            target.Permiso_Nombre = permiso.Nombre;
            target.Permiso_IdSistemaEntidad = permiso.IdSistemaEntidad;
            target.Permiso_IdSistemaAccion = permiso.IdSistemaAccion;
            target.Permiso_IdSistemaEstado = permiso.IdSistemaEstado;
            target.Permiso_SistemaAccion_Nombre = permiso.SistemaAccion_Nombre;
            target.Permiso_SistemaEntidad_Nombre = permiso.SistemaEntidad_Nombre;
            target.Permiso_SistemaEstado_Nombre = permiso.SistemaEstado_Nombre;
            target.Permiso_SistemaAccion_IncluirEstado = permiso.SistemaAccion_IncluirEstado.HasValue ? permiso.SistemaAccion_IncluirEstado.Value : true;
            target.Permiso_Activo = permiso.Activo;
            return target;
        }
        #endregion

        #region Validations
        public override void Validate(ActividadCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            ActividadBusiness.Current.Validate(ActividadBusiness.Current.ToEntity(entity.Actividad), actionName, contextUser, args);
        }
        public override bool Can(ActividadCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            if (entity == null || entity.Actividad==null) return false;
            return ActividadBusiness.Current.Can(ActividadBusiness.Current.ToEntity(entity.Actividad), actionName, contextUser, args);
        }
        #endregion
    }
    
    public class ActividadBusiness : _ActividadBusiness 
    {   
	   #region Singleton
	   private static volatile ActividadBusiness current;
	   private static object syncRoot = new Object();

	   //private ActividadBusiness() {}
	   public static ActividadBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       public override Actividad GetNew()
       {
           Actividad entity= base.GetNew();
           entity.Activo = true;
           return entity;
       }

       public override void Delete(Actividad entity, IContextUser contextUser)
       {
           Delete(entity.IdActividad, contextUser);
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           ActividadPermisoBusiness.Current.Delete(new ActividadPermisoFilter() { IdActividad = id }, contextUser);
           base.Delete(id, contextUser);
       }
    }
}
