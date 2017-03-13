using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OrganismoTipoBusiness : _OrganismoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile OrganismoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private OrganismoTipoBusiness() {}
	   public static OrganismoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override OrganismoTipo GetNew()
       {
           OrganismoTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(OrganismoTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
