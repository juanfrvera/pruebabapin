using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoSeguimientoLocalizacionBusiness : _ProyectoSeguimientoLocalizacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoSeguimientoLocalizacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoLocalizacionBusiness() {}
	   public static ProyectoSeguimientoLocalizacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoLocalizacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoSeguimientoLocalizacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
