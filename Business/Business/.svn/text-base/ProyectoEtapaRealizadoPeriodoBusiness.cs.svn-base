using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaRealizadoPeriodoBusiness : _ProyectoEtapaRealizadoPeriodoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoEtapaRealizadoPeriodoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaRealizadoPeriodoBusiness() {}
	   public static ProyectoEtapaRealizadoPeriodoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaRealizadoPeriodoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoEtapaRealizadoPeriodo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
