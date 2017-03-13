using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorData : _IndicadorData
    {  
	   #region Singleton
	   private static volatile IndicadorData current;
	   private static object syncRoot = new Object();

	   //private IndicadorData() {}
	   public static IndicadorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicador"; } }  
    }
}
