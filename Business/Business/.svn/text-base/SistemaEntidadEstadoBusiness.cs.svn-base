using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SistemaEntidadEstadoBusiness : _SistemaEntidadEstadoBusiness 
    {   
	   #region Singleton
	   private static volatile SistemaEntidadEstadoBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadEstadoBusiness() {}
	   public static SistemaEntidadEstadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadEstadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(SistemaEntidadEstado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
