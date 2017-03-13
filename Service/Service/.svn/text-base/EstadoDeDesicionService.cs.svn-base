using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EstadoDeDesicionService : _EstadoDeDesicionService 
    {	  
	   #region Singleton
	   private static volatile EstadoDeDesicionService current;
	   private static object syncRoot = new Object();

	   //private EstadoDeDesicionService() {}
	   public static EstadoDeDesicionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoDeDesicionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
