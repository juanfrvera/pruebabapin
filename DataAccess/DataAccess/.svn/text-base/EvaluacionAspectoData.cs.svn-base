using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EvaluacionAspectoData : _EvaluacionAspectoData
    {
	   #region Singleton
	   private static volatile EvaluacionAspectoData current;
	   private static object syncRoot = new Object();

	   //private EvaluacionAspectoData() {}
	   public static EvaluacionAspectoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionAspectoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEvaluacionAspecto"; } }  
    }
}
