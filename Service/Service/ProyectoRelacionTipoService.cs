using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoRelacionTipoService : _ProyectoRelacionTipoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoRelacionTipoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoRelacionTipoService() {}
	   public static ProyectoRelacionTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoRelacionTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
