using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoFinalidadFuncionBusiness : _PrestamoFinalidadFuncionBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoFinalidadFuncionBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoFinalidadFuncionBusiness() {}
	   public static PrestamoFinalidadFuncionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFinalidadFuncionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoFinalidadFuncion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
