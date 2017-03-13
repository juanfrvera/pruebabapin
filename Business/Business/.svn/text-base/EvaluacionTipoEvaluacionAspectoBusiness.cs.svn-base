using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EvaluacionTipoEvaluacionAspectoBusiness : _EvaluacionTipoEvaluacionAspectoBusiness 
    {   
	   #region Singleton
	   private static volatile EvaluacionTipoEvaluacionAspectoBusiness current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoEvaluacionAspectoBusiness() {}
	   public static EvaluacionTipoEvaluacionAspectoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoEvaluacionAspectoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
