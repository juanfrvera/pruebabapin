using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class CargoBusiness : _CargoBusiness 
    {   
	   #region Singleton
	   private static volatile CargoBusiness current;
	   private static object syncRoot = new Object();

	   //private CargoBusiness() {}
	   public static CargoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CargoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Cargo GetNew()
       {
           Cargo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Cargo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
