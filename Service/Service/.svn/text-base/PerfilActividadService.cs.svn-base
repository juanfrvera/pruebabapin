using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PerfilActividadService : _PerfilActividadService 
    {	  
	   #region Singleton
	   private static volatile PerfilActividadService current;
	   private static object syncRoot = new Object();

	   //private PerfilActividadService() {}
	   public static PerfilActividadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilActividadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
