using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EvaluacionAspectoService : _EvaluacionAspectoService 
    {	  
	   #region Singleton
	   private static volatile EvaluacionAspectoService current;
	   private static object syncRoot = new Object();

	   //private EvaluacionAspectoService() {}
	   public static EvaluacionAspectoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionAspectoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
