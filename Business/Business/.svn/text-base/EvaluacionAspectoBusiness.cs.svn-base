using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EvaluacionAspectoBusiness : _EvaluacionAspectoBusiness 
    {   
	   #region Singleton
	   private static volatile EvaluacionAspectoBusiness current;
	   private static object syncRoot = new Object();

	   //private EvaluacionAspectoBusiness() {}
	   public static EvaluacionAspectoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionAspectoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override EvaluacionAspecto GetNew()
       {
           EvaluacionAspecto entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(EvaluacionAspecto entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
