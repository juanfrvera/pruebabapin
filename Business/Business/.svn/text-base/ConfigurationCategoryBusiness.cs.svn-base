using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ConfigurationCategoryBusiness : _ConfigurationCategoryBusiness 
    {   
	   #region Singleton
	   private static volatile ConfigurationCategoryBusiness current;
	   private static object syncRoot = new Object();

	   //private ConfigurationCategoryBusiness() {}
	   public static ConfigurationCategoryBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ConfigurationCategoryBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ConfigurationCategory entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
