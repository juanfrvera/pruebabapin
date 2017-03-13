using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoFileService : _ProyectoFileService 
    {	  
	   #region Singleton
	   private static volatile ProyectoFileService current;
	   private static object syncRoot = new Object();

	   //private ProyectoFileService() {}
	   public static ProyectoFileService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFileService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
