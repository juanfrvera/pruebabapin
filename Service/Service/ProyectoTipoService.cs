using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoTipoService : _ProyectoTipoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoTipoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoTipoService() {}
	   public static ProyectoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
