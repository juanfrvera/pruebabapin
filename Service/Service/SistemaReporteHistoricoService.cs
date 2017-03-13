using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaReporteHistoricoService : _SistemaReporteHistoricoService 
    {	  
	   #region Singleton
	   private static volatile SistemaReporteHistoricoService current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteHistoricoService() {}
	   public static SistemaReporteHistoricoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteHistoricoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
