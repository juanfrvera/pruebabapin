using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EstadoService : _EstadoService 
    {	  
	   #region Singleton
	   private static volatile EstadoService current;
	   private static object syncRoot = new Object();

	   //private EstadoService() {}
	   public static EstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
