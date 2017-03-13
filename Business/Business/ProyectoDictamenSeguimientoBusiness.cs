using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoDictamenSeguimientoBusiness : _ProyectoDictamenSeguimientoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoDictamenSeguimientoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenSeguimientoBusiness() {}
	   public static ProyectoDictamenSeguimientoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenSeguimientoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoDictamenSeguimiento entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
