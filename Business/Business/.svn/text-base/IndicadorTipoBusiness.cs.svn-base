using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorTipoBusiness : _IndicadorTipoBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorTipoBusiness() {}
	   public static IndicadorTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override IndicadorTipo GetNew()
       {
           IndicadorTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(IndicadorTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
