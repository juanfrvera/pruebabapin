using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ObjetivoIndicadorBusiness : _ObjetivoIndicadorBusiness 
    {   
	   #region Singleton
	   private static volatile ObjetivoIndicadorBusiness current;
	   private static object syncRoot = new Object();

	   //private ObjetivoIndicadorBusiness() {}
	   public static ObjetivoIndicadorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoIndicadorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ObjetivoIndicador entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
