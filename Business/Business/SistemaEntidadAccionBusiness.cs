using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SistemaEntidadAccionBusiness : _SistemaEntidadAccionBusiness 
    {   
	   #region Singleton
	   private static volatile SistemaEntidadAccionBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadAccionBusiness() {}
	   public static SistemaEntidadAccionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadAccionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(SistemaEntidadAccion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
