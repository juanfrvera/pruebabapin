using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SafBusiness : _SafBusiness 
    {   
	   #region Singleton
	   private static volatile SafBusiness current;
	   private static object syncRoot = new Object();

	   //private SafBusiness() {}
	   public static SafBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SafBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Saf GetNew()
       {
           Saf entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public virtual SafResult GetResultById(int id)
       {
           return GetResult(new SafFilter() { IdSaf = id }).FirstOrDefault();
       }

       #region Actions

       public override void Update(Saf entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
