using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EvaluacionTipoService : _EvaluacionTipoService 
    {	  
	   #region Singleton
	   private static volatile EvaluacionTipoService current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoService() {}
	   public static EvaluacionTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
