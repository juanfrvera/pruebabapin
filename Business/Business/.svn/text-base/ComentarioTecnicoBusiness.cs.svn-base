using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ComentarioTecnicoBusiness : _ComentarioTecnicoBusiness 
    {   
	   #region Singleton
	   private static volatile ComentarioTecnicoBusiness current;
	   private static object syncRoot = new Object();

	   //private ComentarioTecnicoBusiness() {}
	   public static ComentarioTecnicoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ComentarioTecnicoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ComentarioTecnico GetNew()
       {
           ComentarioTecnico entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(ComentarioTecnico entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
