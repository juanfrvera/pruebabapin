using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class UnidadMedidaService : _UnidadMedidaService 
    {	  
	   #region Singleton
	   private static volatile UnidadMedidaService current;
	   private static object syncRoot = new Object();

	   //private UnidadMedidaService() {}
	   public static UnidadMedidaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UnidadMedidaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
