using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEvaluacionService : _ProyectoEvaluacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEvaluacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEvaluacionService() {}
	   public static ProyectoEvaluacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEvaluacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
