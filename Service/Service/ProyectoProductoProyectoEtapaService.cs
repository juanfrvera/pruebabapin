using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoProductoProyectoEtapaService : _ProyectoProductoProyectoEtapaService 
    {	  
	   #region Singleton
	   private static volatile ProyectoProductoProyectoEtapaService current;
	   private static object syncRoot = new Object();

	   //private ProyectoProductoProyectoEtapaService() {}
	   public static ProyectoProductoProyectoEtapaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoProductoProyectoEtapaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
