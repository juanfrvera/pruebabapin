using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoPlanService : _ProyectoPlanService 
    {	  
	   #region Singleton
	   private static volatile ProyectoPlanService current;
	   private static object syncRoot = new Object();

	   //private ProyectoPlanService() {}
	   public static ProyectoPlanService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPlanService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
