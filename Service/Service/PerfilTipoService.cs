using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PerfilTipoService : _PerfilTipoService 
    {	  
	   #region Singleton
	   private static volatile PerfilTipoService current;
	   private static object syncRoot = new Object();

	   //private PerfilTipoService() {}
	   public static PerfilTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
