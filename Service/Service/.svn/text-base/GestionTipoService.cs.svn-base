using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class GestionTipoService : _GestionTipoService 
    {	  
	   #region Singleton
	   private static volatile GestionTipoService current;
	   private static object syncRoot = new Object();

	   //private GestionTipoService() {}
	   public static GestionTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GestionTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
