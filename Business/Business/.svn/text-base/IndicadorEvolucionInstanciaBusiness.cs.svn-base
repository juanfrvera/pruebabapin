using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorEvolucionInstanciaBusiness : _IndicadorEvolucionInstanciaBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorEvolucionInstanciaBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionInstanciaBusiness() {}
	   public static IndicadorEvolucionInstanciaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionInstanciaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(IndicadorEvolucionInstancia entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
