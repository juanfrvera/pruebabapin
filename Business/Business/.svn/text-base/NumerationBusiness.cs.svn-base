using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class NumerationBusiness : _NumerationBusiness 
    {   
	   #region Singleton
	   private static volatile NumerationBusiness current;
	   private static object syncRoot = new Object();

	   //private NumerationBusiness() {}
	   public static NumerationBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new NumerationBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       public int GetNext(string code)
       {
           return this.Data.GetNext(code);
       }

       #region Actions

       public override void Update(Numeration entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
