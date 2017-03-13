using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EvaluacionAspectoEvaluacionResultadoService : _EvaluacionAspectoEvaluacionResultadoService 
    {	  
	   #region Singleton
	   private static volatile EvaluacionAspectoEvaluacionResultadoService current;
	   private static object syncRoot = new Object();

	   //private EvaluacionAspectoEvaluacionResultadoService() {}
	   public static EvaluacionAspectoEvaluacionResultadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionAspectoEvaluacionResultadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
