using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoPrincipiosFormulacionBusiness : _ProyectoPrincipiosFormulacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoPrincipiosFormulacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoPrincipiosFormulacionBusiness() {}
	   public static ProyectoPrincipiosFormulacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPrincipiosFormulacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoPrincipiosFormulacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
