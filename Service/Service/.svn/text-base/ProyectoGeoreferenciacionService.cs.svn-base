using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoGeoreferenciacionService : _ProyectoGeoreferenciacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoGeoreferenciacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoGeoreferenciacionService() {}
	   public static ProyectoGeoreferenciacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoGeoreferenciacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
