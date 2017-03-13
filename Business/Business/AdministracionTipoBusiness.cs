using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class AdministracionTipoBusiness : _AdministracionTipoBusiness 
    {   
	   #region Singleton
	   private static volatile AdministracionTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private AdministracionTipoBusiness() {}
	   public static AdministracionTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AdministracionTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override AdministracionTipo GetNew()
       {
           AdministracionTipo entity= base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(AdministracionTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
