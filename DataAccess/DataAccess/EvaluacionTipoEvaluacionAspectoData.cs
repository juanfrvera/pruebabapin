using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EvaluacionTipoEvaluacionAspectoData : _EvaluacionTipoEvaluacionAspectoData
    {
	   #region Singleton
	   private static volatile EvaluacionTipoEvaluacionAspectoData current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoEvaluacionAspectoData() {}
	   public static EvaluacionTipoEvaluacionAspectoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoEvaluacionAspectoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEvaluacionTipoEvaluacionAspecto"; } }
    }
}
