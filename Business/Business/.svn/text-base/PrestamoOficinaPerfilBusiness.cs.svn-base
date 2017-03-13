using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoOficinaPerfilBusiness : _PrestamoOficinaPerfilBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoOficinaPerfilBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoOficinaPerfilBusiness() {}
	   public static PrestamoOficinaPerfilBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoOficinaPerfilBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoOficinaPerfil entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
