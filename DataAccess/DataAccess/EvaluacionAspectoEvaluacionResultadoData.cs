using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EvaluacionAspectoEvaluacionResultadoData : _EvaluacionAspectoEvaluacionResultadoData
    {
	   #region Singleton
	   private static volatile EvaluacionAspectoEvaluacionResultadoData current;
	   private static object syncRoot = new Object();

	   //private EvaluacionAspectoEvaluacionResultadoData() {}
	   public static EvaluacionAspectoEvaluacionResultadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionAspectoEvaluacionResultadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEvaluacionAspectoEvaluacionResultado"; } }  
    }
}
