using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EntidadTipoService : _EntidadTipoService 
    {	  
	   #region Singleton
	   private static volatile EntidadTipoService current;
	   private static object syncRoot = new Object();

	   //private EntidadTipoService() {}
	   public static EntidadTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EntidadTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
