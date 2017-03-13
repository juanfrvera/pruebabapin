using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoOficinaPerfilService : _PrestamoOficinaPerfilService 
    {	  
	   #region Singleton
	   private static volatile PrestamoOficinaPerfilService current;
	   private static object syncRoot = new Object();

	   //private PrestamoOficinaPerfilService() {}
	   public static PrestamoOficinaPerfilService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoOficinaPerfilService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
