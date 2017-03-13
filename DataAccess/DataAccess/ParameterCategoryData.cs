using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ParameterCategoryData : _ParameterCategoryData 
    { 
	   #region Singleton
	   private static volatile ParameterCategoryData current;
	   private static object syncRoot = new Object();

	   //private ParameterCategoryData() {}
	   public static ParameterCategoryData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ParameterCategoryData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdParameterCategory"; } }
    }
}
