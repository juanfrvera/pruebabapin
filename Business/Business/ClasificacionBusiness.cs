using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ClasificacionBusiness : _ClasificacionBusiness 
    {   
	   #region Singleton
	   private static volatile ClasificacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ClasificacionBusiness() {}
	   public static ClasificacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Clasificacion GetNew()
       {
           Clasificacion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Clasificacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
