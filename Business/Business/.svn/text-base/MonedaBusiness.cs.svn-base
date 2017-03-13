using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class MonedaBusiness : _MonedaBusiness 
    {   
	   #region Singleton
	   private static volatile MonedaBusiness current;
	   private static object syncRoot = new Object();

	   //private MonedaBusiness() {}
	   public static MonedaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MonedaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Moneda GetNew()
       {
           Moneda entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       #region Validations
       public override void Validate(Moneda entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           switch (actionName)
           {
               case ActionConfig.CREATE:
                   DataHelper.Validate(entity.Base == false || (from m in MonedaBusiness.Current.GetResult(new MonedaFilter() { Base = true }) select 1).Count() == 0, "Solo debe existir una moneda base");
                    break;
               case ActionConfig.UPDATE:
                    DataHelper.Validate(entity.Base == false || (from m in MonedaBusiness.Current.GetResult(new MonedaFilter() { Base = true }) select 1).Count() == 0 || (from m in MonedaBusiness.Current.GetResult(new MonedaFilter() { Base = true, IdMoneda = entity.IdMoneda }) select 1).Count()==1, "Solo debe existir una moneda base");
                   break;
               case ActionConfig.READ:
               case ActionConfig.DELETE:
                   break;
           }
     
       }
       #endregion

       #region Actions

       public override void Update(Moneda entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
