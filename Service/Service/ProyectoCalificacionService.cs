using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoCalificacionService : _ProyectoCalificacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoCalificacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalificacionService() {}
	   public static ProyectoCalificacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalificacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
