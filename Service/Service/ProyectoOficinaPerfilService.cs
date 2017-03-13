using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoOficinaPerfilService : _ProyectoOficinaPerfilService 
    {	  
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilService current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilService() {}
	   public static ProyectoOficinaPerfilService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
