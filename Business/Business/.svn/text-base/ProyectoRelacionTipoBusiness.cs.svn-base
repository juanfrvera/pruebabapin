using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoRelacionTipoBusiness : _ProyectoRelacionTipoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoRelacionTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoRelacionTipoBusiness() {}
	   public static ProyectoRelacionTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoRelacionTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ProyectoRelacionTipo GetNew()
       {
           ProyectoRelacionTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(ProyectoRelacionTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
