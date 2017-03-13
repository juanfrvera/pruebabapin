using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrioridadBusiness : _PrioridadBusiness 
    {   
	   #region Singleton
	   private static volatile PrioridadBusiness current;
	   private static object syncRoot = new Object();

	   //private PrioridadBusiness() {}
	   public static PrioridadBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrioridadBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Prioridad GetNew()
       {
           Prioridad entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(Prioridad entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
