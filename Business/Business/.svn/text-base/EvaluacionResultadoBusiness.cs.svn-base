using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EvaluacionResultadoBusiness : _EvaluacionResultadoBusiness 
    {   
	   #region Singleton
	   private static volatile EvaluacionResultadoBusiness current;
	   private static object syncRoot = new Object();

	   //private EvaluacionResultadoBusiness() {}
	   public static EvaluacionResultadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionResultadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override EvaluacionResultado GetNew()
       {
           EvaluacionResultado entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(EvaluacionResultado entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
