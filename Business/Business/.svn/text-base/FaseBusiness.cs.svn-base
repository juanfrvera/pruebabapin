using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class FaseBusiness : _FaseBusiness 
    {   
	   #region Singleton
	   private static volatile FaseBusiness current;
	   private static object syncRoot = new Object();

	   //private FaseBusiness() {}
	   public static FaseBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FaseBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Fase GetNew()
       {
           Fase entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Fase entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
