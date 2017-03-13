using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class TransferenciaBusiness : _TransferenciaBusiness 
    {   
	   #region Singleton
	   private static volatile TransferenciaBusiness current;
	   private static object syncRoot = new Object();

	   //private TransferenciaBusiness() {}
	   public static TransferenciaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Transferencia GetNew()
       {
           Transferencia entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Transferencia entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
