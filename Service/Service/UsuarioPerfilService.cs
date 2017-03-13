using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class UsuarioPerfilService : _UsuarioPerfilService 
    {	  
	   #region Singleton
	   private static volatile UsuarioPerfilService current;
	   private static object syncRoot = new Object();

	   //private UsuarioPerfilService() {}
	   public static UsuarioPerfilService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioPerfilService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
