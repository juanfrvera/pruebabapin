using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class LanguageData : _LanguageData 
    {  
	   #region Singleton
	   private static volatile LanguageData current;
	   private static object syncRoot = new Object();

	   //private LanguageData() {}
	   public static LanguageData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new LanguageData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdLanguage"; } }  
    }
}
