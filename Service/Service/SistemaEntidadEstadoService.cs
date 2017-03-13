using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaEntidadEstadoService : _SistemaEntidadEstadoService 
    {	  
	   #region Singleton
	   private static volatile SistemaEntidadEstadoService current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadEstadoService() {}
	   public static SistemaEntidadEstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadEstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
