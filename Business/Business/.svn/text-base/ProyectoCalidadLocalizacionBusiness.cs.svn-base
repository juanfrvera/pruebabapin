using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoCalidadLocalizacionBusiness : _ProyectoCalidadLocalizacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoCalidadLocalizacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalidadLocalizacionBusiness() {}
	   public static ProyectoCalidadLocalizacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalidadLocalizacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoCalidadLocalizacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
