using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoDemoraService : _ProyectoDemoraService 
    {	  
	   #region Singleton
	   private static volatile ProyectoDemoraService current;
	   private static object syncRoot = new Object();

	   //private ProyectoDemoraService() {}
	   public static ProyectoDemoraService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDemoraService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
