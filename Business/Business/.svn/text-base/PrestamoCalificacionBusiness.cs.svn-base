using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoCalificacionBusiness : _PrestamoCalificacionBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoCalificacionBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoCalificacionBusiness() {}
	   public static PrestamoCalificacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoCalificacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override PrestamoCalificacion GetNew()
       {
           PrestamoCalificacion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }


       #region Actions

       public override void Update(PrestamoCalificacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
