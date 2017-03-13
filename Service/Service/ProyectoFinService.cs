using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoFinService : _ProyectoFinService 
    {	  
	   #region Singleton
	   private static volatile ProyectoFinService current;
	   private static object syncRoot = new Object();

	   //private ProyectoFinService() {}
	   public static ProyectoFinService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFinService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
