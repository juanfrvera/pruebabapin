using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OrganismoBusiness : _OrganismoBusiness 
    {   
	   #region Singleton
	   private static volatile OrganismoBusiness current;
	   private static object syncRoot = new Object();

	   //private OrganismoBusiness() {}
	   public static OrganismoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Organismo GetNew()
       {
           Organismo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(Organismo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
