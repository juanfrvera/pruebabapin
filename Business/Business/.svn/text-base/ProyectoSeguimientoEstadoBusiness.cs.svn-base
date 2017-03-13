using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoSeguimientoEstadoBusiness : _ProyectoSeguimientoEstadoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoSeguimientoEstadoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoEstadoBusiness() {}
	   public static ProyectoSeguimientoEstadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoEstadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoSeguimientoEstado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
       
    }
}
