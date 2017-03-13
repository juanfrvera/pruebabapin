using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EstadoTipoService : _EstadoTipoService 
    {	  
	   #region Singleton
	   private static volatile EstadoTipoService current;
	   private static object syncRoot = new Object();

	   //private EstadoTipoService() {}
	   public static EstadoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
