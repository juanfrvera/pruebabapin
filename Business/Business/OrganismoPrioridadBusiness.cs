using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OrganismoPrioridadBusiness : _OrganismoPrioridadBusiness 
    {   
	   #region Singleton
	   private static volatile OrganismoPrioridadBusiness current;
	   private static object syncRoot = new Object();

	   //private OrganismoPrioridadBusiness() {}
	   public static OrganismoPrioridadBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoPrioridadBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override OrganismoPrioridad GetNew()
       {
           OrganismoPrioridad entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(OrganismoPrioridad entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
