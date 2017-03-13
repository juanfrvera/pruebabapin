using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EvaluacionTipoBusiness : _EvaluacionTipoBusiness 
    {   
	   #region Singleton
	   private static volatile EvaluacionTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoBusiness() {}
	   public static EvaluacionTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override EvaluacionTipo GetNew()
       {
           EvaluacionTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(EvaluacionTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
