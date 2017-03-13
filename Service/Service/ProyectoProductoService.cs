using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoProductoService : _ProyectoProductoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoProductoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoProductoService() {}
	   public static ProyectoProductoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoProductoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
 
}
