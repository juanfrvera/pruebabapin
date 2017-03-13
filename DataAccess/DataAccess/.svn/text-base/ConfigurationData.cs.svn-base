using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ConfigurationData : _ConfigurationData
    {
	   #region Singleton
	   private static volatile ConfigurationData current;
	   private static object syncRoot = new Object();

	   //private ConfigurationData() {}
	   public static ConfigurationData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ConfigurationData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdConfiguration"; } } 
    }
}
