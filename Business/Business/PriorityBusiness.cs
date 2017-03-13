using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PriorityBusiness : _PriorityBusiness 
    {   
	   #region Singleton
	   private static volatile PriorityBusiness current;
	   private static object syncRoot = new Object();

	   //private PriorityBusiness() {}
	   public static PriorityBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PriorityBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(Priority entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
