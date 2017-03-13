using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class TransferenciaDetalleBusiness : _TransferenciaDetalleBusiness 
    {   
	   #region Singleton
	   private static volatile TransferenciaDetalleBusiness current;
	   private static object syncRoot = new Object();

	   //private TransferenciaDetalleBusiness() {}
	   public static TransferenciaDetalleBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaDetalleBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(TransferenciaDetalle entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
