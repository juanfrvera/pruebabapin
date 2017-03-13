using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class AdministracionTipoService : _AdministracionTipoService 
    {	  
	   #region Singleton
	   private static volatile AdministracionTipoService current;
	   private static object syncRoot = new Object();

	   //private AdministracionTipoService() {}
	   public static AdministracionTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AdministracionTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
