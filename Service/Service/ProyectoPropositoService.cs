using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoPropositoService : _ProyectoPropositoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoPropositoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoPropositoService() {}
	   public static ProyectoPropositoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPropositoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
