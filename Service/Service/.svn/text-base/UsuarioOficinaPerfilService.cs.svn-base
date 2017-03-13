using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class UsuarioOficinaPerfilService : _UsuarioOficinaPerfilService 
    {	  
	   #region Singleton
	   private static volatile UsuarioOficinaPerfilService current;
	   private static object syncRoot = new Object();

	   //private UsuarioOficinaPerfilService() {}
	   public static UsuarioOficinaPerfilService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioOficinaPerfilService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<UsuarioOficinaPerfilSimpleResult> GetResultSimple(UsuarioOficinaPerfilFilter filter)
       {
           return Business.GetResultSimple(filter);
       }
    }
}
