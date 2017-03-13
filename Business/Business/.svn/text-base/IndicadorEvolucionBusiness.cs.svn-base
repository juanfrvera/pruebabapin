using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorEvolucionBusiness : _IndicadorEvolucionBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorEvolucionBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionBusiness() {}
	   public static IndicadorEvolucionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(IndicadorEvolucion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion

    }
}
