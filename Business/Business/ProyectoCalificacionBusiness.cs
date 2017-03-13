using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoCalificacionBusiness : _ProyectoCalificacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoCalificacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalificacionBusiness() {}
	   public static ProyectoCalificacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalificacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ProyectoCalificacion GetNew()
       {
           ProyectoCalificacion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(ProyectoCalificacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
