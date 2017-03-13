using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EntidadTipoBusiness : _EntidadTipoBusiness 
    {   
	   #region Singleton
	   private static volatile EntidadTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private EntidadTipoBusiness() {}
	   public static EntidadTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EntidadTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override EntidadTipo GetNew()
       {
           EntidadTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
      
        #region Actions

       public override void Update(EntidadTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    
    }
}
