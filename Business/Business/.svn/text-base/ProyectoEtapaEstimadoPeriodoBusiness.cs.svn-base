using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaEstimadoPeriodoBusiness : _ProyectoEtapaEstimadoPeriodoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoEtapaEstimadoPeriodoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaEstimadoPeriodoBusiness() {}
	   public static ProyectoEtapaEstimadoPeriodoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaEstimadoPeriodoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoEtapaEstimadoPeriodo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
