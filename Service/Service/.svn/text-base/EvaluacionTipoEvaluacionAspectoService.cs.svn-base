using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EvaluacionTipoEvaluacionAspectoService : _EvaluacionTipoEvaluacionAspectoService 
    {	  
	   #region Singleton
	   private static volatile EvaluacionTipoEvaluacionAspectoService current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoEvaluacionAspectoService() {}
	   public static EvaluacionTipoEvaluacionAspectoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoEvaluacionAspectoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
