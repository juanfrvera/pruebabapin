using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class GestionTipoBusiness : _GestionTipoBusiness 
    {   
	   #region Singleton
	   private static volatile GestionTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private GestionTipoBusiness() {}
	   public static GestionTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GestionTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override GestionTipo GetNew()
       {
           GestionTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(GestionTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion

    }
}
