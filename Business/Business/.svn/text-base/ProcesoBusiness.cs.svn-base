using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProcesoBusiness : _ProcesoBusiness 
    {   
	   #region Singleton
	   private static volatile ProcesoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProcesoBusiness() {}
	   public static ProcesoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProcesoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Proceso GetNew()
       {
           Proceso entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(Proceso entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
