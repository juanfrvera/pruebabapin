using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorRubroData : _IndicadorRubroData 
    {  
	   #region Singleton
	   private static volatile IndicadorRubroData current;
	   private static object syncRoot = new Object();

	   //private IndicadorRubroData() {}
	   public static IndicadorRubroData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorRubroData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorRubro"; } }  
    }
}
