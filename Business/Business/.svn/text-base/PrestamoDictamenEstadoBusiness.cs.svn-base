using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoDictamenEstadoBusiness : _PrestamoDictamenEstadoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoDictamenEstadoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenEstadoBusiness() {}
	   public static PrestamoDictamenEstadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenEstadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoDictamenEstado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
