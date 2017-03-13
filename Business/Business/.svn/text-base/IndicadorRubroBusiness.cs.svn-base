using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorRubroBusiness : _IndicadorRubroBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorRubroBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorRubroBusiness() {}
	   public static IndicadorRubroBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorRubroBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override IndicadorRubro GetNew()
       {
           IndicadorRubro entity= base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(IndicadorRubro entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
