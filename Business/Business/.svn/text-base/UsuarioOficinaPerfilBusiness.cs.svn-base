using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class UsuarioOficinaPerfilBusiness : _UsuarioOficinaPerfilBusiness 
    {   
	   #region Singleton
	   private static volatile UsuarioOficinaPerfilBusiness current;
	   private static object syncRoot = new Object();

	   //private UsuarioOficinaPerfilBusiness() {}
	   public static UsuarioOficinaPerfilBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioOficinaPerfilBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override UsuarioOficinaPerfil GetNew()
       {
           UsuarioOficinaPerfil entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public List<UsuarioOficinaPerfilSimpleResult> GetResultSimple(UsuarioOficinaPerfilFilter filter)
       {
           return Data.GetResultSimple(filter);
       }

       #region Actions

       public override void Update(UsuarioOficinaPerfil entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
