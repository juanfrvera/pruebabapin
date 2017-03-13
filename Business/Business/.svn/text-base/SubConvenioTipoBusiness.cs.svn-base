using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SubConvenioTipoBusiness : _SubConvenioTipoBusiness 
    {   
	   #region Singleton
	   private static volatile SubConvenioTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private SubConvenioTipoBusiness() {}
	   public static SubConvenioTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubConvenioTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override SubConvenioTipo GetNew()
       {
           SubConvenioTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(SubConvenioTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
