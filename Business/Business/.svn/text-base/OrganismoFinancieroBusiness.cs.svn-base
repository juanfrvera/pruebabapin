using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OrganismoFinancieroBusiness : _OrganismoFinancieroBusiness 
    {   
	   #region Singleton
	   private static volatile OrganismoFinancieroBusiness current;
	   private static object syncRoot = new Object();

	   //private OrganismoFinancieroBusiness() {}
	   public static OrganismoFinancieroBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoFinancieroBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override OrganismoFinanciero GetNew()
       {
           OrganismoFinanciero entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(OrganismoFinanciero entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
