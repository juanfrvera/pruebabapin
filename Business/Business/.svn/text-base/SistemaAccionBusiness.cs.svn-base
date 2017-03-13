using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SistemaAccionBusiness : _SistemaAccionBusiness 
    {   
	   #region Singleton
	   private static volatile SistemaAccionBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaAccionBusiness() {}
	   public static SistemaAccionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaAccionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override SistemaAccion GetNew()
       {
           SistemaAccion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions
       public override void Add(SistemaAccion entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad();
           SolutionContext.Current.AuthorizationManager.Refresh();  
           SolutionContext.Current.AccionesCache.Refresh();
       }
       public override void Update(SistemaAccion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad();
           SolutionContext.Current.AuthorizationManager.Refresh();  
           SolutionContext.Current.AccionesCache.Refresh();
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           base.Delete(id, contextUser);
           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad();
           SolutionContext.Current.AuthorizationManager.Refresh();  
           SolutionContext.Current.AccionesCache.Refresh();
       }
       public override void Delete(SistemaAccion entity, IContextUser contextUser)
       {
           base.Delete(entity, contextUser);
           SistemaEntidadBusiness.Current.RefreshPermisosPorEntidad();
           SolutionContext.Current.AuthorizationManager.Refresh();  
           SolutionContext.Current.AccionesCache.Refresh();
       }
       #endregion
    }
}
