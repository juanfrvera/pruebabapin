using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoRelacionService : _ProyectoRelacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoRelacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoRelacionService() {}
	   public static ProyectoRelacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoRelacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
