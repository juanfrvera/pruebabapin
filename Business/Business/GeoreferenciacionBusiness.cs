using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class GeoreferenciacionBusiness : _GeoreferenciacionBusiness 
    {   
	   #region Singleton
	   private static volatile GeoreferenciacionBusiness current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionBusiness() {}
	   public static GeoreferenciacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(Georeferenciacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
