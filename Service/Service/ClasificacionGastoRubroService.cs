using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionGastoRubroService : _ClasificacionGastoRubroService 
    {	  
	   #region Singleton
	   private static volatile ClasificacionGastoRubroService current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoRubroService() {}
	   public static ClasificacionGastoRubroService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoRubroService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
