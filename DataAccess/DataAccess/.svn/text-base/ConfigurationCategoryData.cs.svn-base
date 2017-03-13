using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ConfigurationCategoryData : _ConfigurationCategoryData 
    {
        #region Singleton
	   private static volatile ConfigurationCategoryData current;
	   private static object syncRoot = new Object();

	   //private ConfigurationCategoryData() {}
	   public static ConfigurationCategoryData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ConfigurationCategoryData();
				}
			 }
			 return current;
		  }
	   }
        #endregion
       public override string IdFieldName { get { return "IdConfigurationCategory"; } }
    }
}
