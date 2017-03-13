using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaReporteService : _SistemaReporteService 
    {	  
	   #region Singleton
	   private static volatile SistemaReporteService current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteService() {}
	   public static SistemaReporteService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
