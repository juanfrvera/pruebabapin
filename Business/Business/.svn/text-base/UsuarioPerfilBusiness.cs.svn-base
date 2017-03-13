using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class UsuarioPerfilBusiness : _UsuarioPerfilBusiness 
    {   
	   #region Singleton
	   private static volatile UsuarioPerfilBusiness current;
	   private static object syncRoot = new Object();

	   //private UsuarioPerfilBusiness() {}
	   public static UsuarioPerfilBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioPerfilBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(UsuarioPerfil entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
