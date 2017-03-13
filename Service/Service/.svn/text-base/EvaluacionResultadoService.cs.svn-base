using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EvaluacionResultadoService : _EvaluacionResultadoService 
    {	  
	   #region Singleton
	   private static volatile EvaluacionResultadoService current;
	   private static object syncRoot = new Object();

	   //private EvaluacionResultadoService() {}
	   public static EvaluacionResultadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionResultadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
