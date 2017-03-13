using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoDictamenEstadoBusiness : _ProyectoDictamenEstadoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoDictamenEstadoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenEstadoBusiness() {}
	   public static ProyectoDictamenEstadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenEstadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoDictamenEstado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
