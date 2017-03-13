using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorMedioVerificacionBusiness : _IndicadorMedioVerificacionBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorMedioVerificacionBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorMedioVerificacionBusiness() {}
	   public static IndicadorMedioVerificacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorMedioVerificacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(IndicadorMedioVerificacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
