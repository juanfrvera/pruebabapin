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
    public class FuenteFinanciamientoBusiness : _FuenteFinanciamientoBusiness 
    {   
	   #region Singleton
	   private static volatile FuenteFinanciamientoBusiness current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoBusiness() {}
	   public static FuenteFinanciamientoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override FuenteFinanciamiento GetNew()
       {
           FuenteFinanciamiento entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public ListPaged<NodeResult> GetNodesResult(FuenteFinanciamientoFilter filter)
       {
           return Data.GetNodesResult(filter);
       }
       #region Actions
       public override void Add(FuenteFinanciamiento entity, IContextUser contextUser)
       {

           base.Add(entity, contextUser);
           Data.RefreshFuenteFinanciamiento(entity.IdFuenteFinanciamientoPadre);
       }
       public override void Update(FuenteFinanciamiento entity, IContextUser contextUser)
       {
           FuenteFinanciamiento fuenteFinanciamiento = FuenteFinanciamientoBusiness.Current.GetById(entity.IdFuenteFinanciamiento);
           if ((!entity.Activo) && fuenteFinanciamiento.Activo)
           {
               Data.ActiveCascadaFuenteFinanciamiento(entity.IdFuenteFinanciamiento, false);
           }
           Set(entity, fuenteFinanciamiento);
           base.Update(fuenteFinanciamiento, contextUser);
           Data.RefreshFuenteFinanciamiento(fuenteFinanciamiento.IdFuenteFinanciamientoPadre);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       #endregion
       #region Validations
       public override void Validate(FuenteFinanciamiento entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           DataHelper.Validate(entity.IdFuenteFinanciamientoTipo != 0, "La Fuente de Financiamiento Padre debe ser de un nivel superior ");
           base.Validate(entity, actionName, contextUser, args);
           if (entity.IdFuenteFinanciamientoPadre != null)
           {
               DataHelper.Validate((entity.Activo) ? FuenteFinanciamientoBusiness.Current.GetList(new FuenteFinanciamientoFilter() { IdFuenteFinanciamiento = entity.IdFuenteFinanciamientoPadre }).FirstOrDefault().Activo : true, "Para activar la Fuente de Financiamiento Actual, la Fuente de Financiamiento Padre debe estar activa");
           }
       }
       #endregion
    }
}
