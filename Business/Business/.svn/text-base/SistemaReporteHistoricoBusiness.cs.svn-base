using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SistemaReporteHistoricoBusiness : _SistemaReporteHistoricoBusiness 
    {   
	   #region Singleton
	   private static volatile SistemaReporteHistoricoBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteHistoricoBusiness() {}
	   public static SistemaReporteHistoricoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteHistoricoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
