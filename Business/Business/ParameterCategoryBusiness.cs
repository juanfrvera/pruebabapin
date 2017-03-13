using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ParameterCategoryBusiness : _ParameterCategoryBusiness 
    {   
	   #region Singleton
	   private static volatile ParameterCategoryBusiness current;
	   private static object syncRoot = new Object();

	   //private ParameterCategoryBusiness() {}
	   public static ParameterCategoryBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ParameterCategoryBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ParameterCategory entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
