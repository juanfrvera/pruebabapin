using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoIndicadorEconomicoBusiness : _ProyectoIndicadorEconomicoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoIndicadorEconomicoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorEconomicoBusiness() {}
	   public static ProyectoIndicadorEconomicoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorEconomicoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoIndicadorEconomico entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
