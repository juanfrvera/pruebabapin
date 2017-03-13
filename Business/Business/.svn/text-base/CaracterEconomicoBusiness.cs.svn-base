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
    public class CaracterEconomicoBusiness : _CaracterEconomicoBusiness 
    {   
	   #region Singleton
	   private static volatile CaracterEconomicoBusiness current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoBusiness() {}
	   public static CaracterEconomicoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       public override CaracterEconomico GetNew()
       {
           CaracterEconomico entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public ListPaged<NodeResult> GetNodesResult(CaracterEconomicoFilter filter)
       {
           return Data.GetNodesResult(filter);
       }
       #region Actions
       public override void Add(CaracterEconomico entity, IContextUser contextUser)
       {

           base.Add(entity, contextUser);
           Data.RefreshCaracterEconomico(entity.IdCaracterEconomicoPadre);
       }
       public override void Update(CaracterEconomico entity, IContextUser contextUser)
       {
           CaracterEconomico caracterEconomico = CaracterEconomicoBusiness.Current.GetById(entity.IdCaracterEconomico);
           if ((!entity.Activo) && caracterEconomico.Activo)
           {
               Data.ActiveCascadaCaracterEconomico(entity.IdCaracterEconomico, false);
           }
           Set(entity, caracterEconomico);
           base.Update(caracterEconomico, contextUser);
           Data.RefreshCaracterEconomico(entity.IdCaracterEconomicoPadre);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       #endregion
       #region Validations
       public override void Validate(CaracterEconomico entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           DataHelper.Validate(entity.IdCaracterEconomicoTipo != 0, "El Caracter Económico Padre debe ser de un nivel superior ");
           base.Validate(entity, actionName, contextUser, args);
           if (entity.IdCaracterEconomicoPadre != null)
           {
               DataHelper.Validate((entity.Activo) ? CaracterEconomicoBusiness.Current.GetList(new CaracterEconomicoFilter() { IdCaracterEconomico = entity.IdCaracterEconomicoPadre }).FirstOrDefault().Activo : true, "Para activar el Caracter Económico Actual, el Caracter Económico debe estar activa");
           }
       }
       #endregion
    }
}
