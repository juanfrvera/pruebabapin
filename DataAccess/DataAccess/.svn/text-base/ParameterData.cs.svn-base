using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ParameterData : _ParameterData
    {
	   #region Singleton
	   private static volatile ParameterData current;
	   private static object syncRoot = new Object();

	   //private ParameterData() {}
	   public static ParameterData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ParameterData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdParameter"; } }
    }
}
