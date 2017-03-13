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
    public class PerfilComposeBusiness : EntityComposeBusiness<PerfilCompose, Perfil, PerfilFilter, PerfilResult, int>
    {
        #region Singleton
        private static volatile PerfilComposeBusiness current;
        private static object syncRoot = new Object();
        public static PerfilComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PerfilComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Perfil, PerfilFilter, PerfilResult, int> EntityBusinessBase
        {
            get { return PerfilBusiness.Current; }
        }
        #region Gets
        public override PerfilCompose GetNew(PerfilResult example)
        {
            PerfilCompose compose = base.GetNew();
            compose.Perfil = example;
            compose.Actividades = ToPerfilActividades(ActividadBusiness.Current.GetResult(new ActividadFilter() { Activo = true}));
            return compose;
        }
        public override PerfilCompose GetNew()
        {
            PerfilResult example = new PerfilResult();
            example.Activo = true;
            PerfilBusiness.Current.Set(PerfilBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(PerfilCompose entity)
        {
            return entity.Perfil.IdPerfil;
        }
        public override PerfilCompose GetById(int id)
        {
            PerfilCompose compose = new PerfilCompose();
            compose.Perfil = PerfilBusiness.Current.GetResult(new PerfilFilter() { IdPerfil = id }).FirstOrDefault();
            //obtiene los permisos asociados y los que no estan asociados
            List<ActividadResult> actividades = ActividadBusiness.Current.GetResult(new ActividadFilter() { Activo = true});
            List<PerfilActividadResult> perfilActividades = PerfilActividadBusiness.Current.GetResult(new PerfilActividadFilter() { IdPerfil = id});
            List<PerfilActividadResult> unselected = (from a in actividades
                                                       where !(from pa in perfilActividades select pa.IdActividad).Contains(a.IdActividad)
                                                      select ToPerfilActividades(a)).ToList();

            perfilActividades.AddRange(unselected);
            compose.Actividades = perfilActividades;

            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PerfilCompose entity, IContextUser contextUser)
        {
            try
            {
                Perfil perfil = entity.Perfil.ToEntity();
                PerfilBusiness.Current.Add(perfil, contextUser);
                entity.Perfil.IdPerfil = perfil.IdPerfil;
                foreach (PerfilActividadResult actividad in entity.Actividades)
                {
                    if (actividad.Selected && actividad.IdPerfilActividad < 1)
                    {
                        PerfilActividad perfilActividad = PerfilActividadBusiness.Current.GetNew();
                        perfilActividad.IdActividad = actividad.IdActividad;
                        perfilActividad.IdPerfil = perfil.IdPerfil;
                        PerfilActividadBusiness.Current.Add(perfilActividad, contextUser);
                        actividad.IdPerfilActividad = perfilActividad.IdPerfilActividad;
                    }
                    if (!actividad.Selected && actividad.IdPerfilActividad > 1)
                    {
                        PerfilActividadBusiness.Current.Delete(actividad.IdPerfilActividad, contextUser);
                    }
               
                  {
                        PerfilActividad perfilActividad = PerfilActividadBusiness.Current.GetNew();
                        perfilActividad.IdActividad = actividad.IdActividad;
                        perfilActividad.IdPerfil = perfil.IdPerfil;
                        PerfilActividadBusiness.Current.Add(perfilActividad, contextUser);
                        actividad.IdPerfilActividad = perfilActividad.IdPerfilActividad;
                    }
                }
                SolutionContext.Current.AuthorizationManager.Refresh();
            }
            catch (Exception exception)
            {
                entity.Perfil.IdPerfil = 0;
                entity.Actividades.ForEach(p => p.IdPerfilActividad = 0);
                throw exception;
            }
        }
        public override void Update(PerfilCompose entity, IContextUser contextUser)
        {
            List<PerfilActividadResult> copy = PerfilActividadBusiness.Current.CopiesResult(entity.Actividades);
            try
            {
                Perfil perfil =  PerfilBusiness.Current.GetById(entity.Perfil.IdPerfil);
                PerfilBusiness.Current.Set(entity.Perfil, perfil);
                PerfilBusiness.Current.Update(perfil, contextUser);

                foreach (PerfilActividadResult actividad in entity.Actividades)
                {
                    if (actividad.Selected && actividad.IdPerfilActividad < 1)
                    {
                        PerfilActividad perfilActividad = PerfilActividadBusiness.Current.GetNew();
                        perfilActividad.IdActividad = actividad.IdActividad;
                        perfilActividad.IdPerfil = perfil.IdPerfil;
                        PerfilActividadBusiness.Current.Add(perfilActividad, contextUser);
                        actividad.IdPerfilActividad = perfilActividad.IdPerfilActividad;
                    }
                    if (!actividad.Selected && actividad.IdPerfilActividad > 1)
                    {
                        PerfilActividadBusiness.Current.Delete(actividad.IdPerfilActividad, contextUser);
                    }
                }
                SolutionContext.Current.AuthorizationManager.Refresh();
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.Actividades = copy;
                throw exception;
            }
        }
        public override void Delete(PerfilCompose entity, IContextUser contextUser)
        {
            PerfilBusiness.Current.Delete(entity.Perfil.IdPerfil, contextUser);
        }
        #endregion

        #region protected Methods
        protected List<PerfilActividadResult> ToPerfilActividades(List<ActividadResult> actividades)
        {
            List<PerfilActividadResult> target = new List<PerfilActividadResult>(actividades.Count);
            foreach (ActividadResult actividad in actividades)
                target.Add(ToPerfilActividades(actividad));
            return target;
        }
        protected PerfilActividadResult ToPerfilActividades(ActividadResult actividad)
        {
            PerfilActividadResult target = new PerfilActividadResult();
            target.IdActividad = actividad.IdActividad;
            target.Actividad_Activo = actividad.Activo;
            target.Actividad_Nombre = actividad.Nombre;
            target.Selected = false;           
            return target;
        }
        #endregion

        #region Validations
        public override void Validate(PerfilCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            PerfilBusiness.Current.Validate(PerfilBusiness.Current.ToEntity(entity.Perfil), actionName, contextUser, args);
        }
        public override bool Can(PerfilCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PerfilBusiness.Current.Can(PerfilBusiness.Current.ToEntity(entity.Perfil), actionName, contextUser, args);
        }
        #endregion
    }
    
   

    public class PerfilBusiness : _PerfilBusiness 
    {   
	   #region Singleton
	   private static volatile PerfilBusiness current;
	   private static object syncRoot = new Object();

	   //private PerfilBusiness() {}
	   public static PerfilBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Perfil GetNew()
       {
           Perfil entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       #region Deleted
       public override void Delete(Perfil entity, IContextUser contextUser)
       {
           Delete(entity.IdPerfil, contextUser);
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           PerfilActividadBusiness.Current.Delete(new PerfilActividadFilter() { IdPerfil = id }, contextUser);
           base.Delete(id, contextUser);
       }
       #endregion
       #region Validations
       public override void Validate(Perfil entity, string actionName, IContextUser contextUser,Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           switch (actionName)
           {
               case ActionConfig.CREATE:
                   DataHelper.Validate(entity.EsDefault == false || (from m in PerfilBusiness.Current.GetResult(new PerfilFilter() { EsDefault = true, IdPerfilTipo= entity.IdPerfilTipo}) select 1).Count() == 0, "Solo debe existir un Perfil default por tipo de Perfil");
                   break;
               case ActionConfig.UPDATE:
                   DataHelper.Validate(entity.EsDefault == false || (from m in PerfilBusiness.Current.GetResult(new PerfilFilter() { EsDefault = true, IdPerfilTipo = entity.IdPerfilTipo }) select 1).Count() == 0
                       || (from m in PerfilBusiness.Current.GetResult(new PerfilFilter() { EsDefault = true, IdPerfilTipo = entity.IdPerfilTipo, IdPerfil = entity.IdPerfil }) select 1).Count() == 1, "Solo debe existir un Perfil default por tipo de Perfil");
                   break;
               case ActionConfig.READ:
               case ActionConfig.DELETE:
                   break;
           }

       }
       #endregion
    }
}
