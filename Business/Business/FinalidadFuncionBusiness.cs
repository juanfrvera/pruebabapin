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
    public class FinalidadFuncionBusiness : _FinalidadFuncionBusiness 
    {   
	   #region Singleton
	   private static volatile FinalidadFuncionBusiness current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionBusiness() {}
	   public static FinalidadFuncionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override FinalidadFuncion GetNew()
       {
           FinalidadFuncion entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public ListPaged<NodeResult> GetNodesResult(FinalidadFuncionFilter filter)
       {
           return Data.GetNodesResult(filter);
       }
       #region Actions
       public override void Add(FinalidadFuncion entity, IContextUser contextUser)
       {

           base.Add(entity, contextUser);
           Data.RefreshFinalidadFuncion(entity.IdFinalidadFuncionPadre);
       }
       public override void Update(FinalidadFuncion entity, IContextUser contextUser)
       {
           FinalidadFuncion finalidadFuncion = FinalidadFuncionBusiness.Current.GetById(entity.IdFinalidadFuncion);
           if ((!entity.Activo) && finalidadFuncion.Activo)
           {
               Data.ActiveCascadaFinalidadFuncion(entity.IdFinalidadFuncion, false);
           }
           Set(entity, finalidadFuncion);
           base.Update(finalidadFuncion, contextUser);
           Data.RefreshFinalidadFuncion(finalidadFuncion.IdFinalidadFuncionPadre);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
       #endregion
       #region Validations
       public override void Validate(FinalidadFuncion entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           DataHelper.Validate(entity.IdFinalidadFunciontipo!= 0, "La Finalidad - Función Padre debe ser de un nivel superior ");
           base.Validate(entity, actionName, contextUser, args);
           if (entity.IdFinalidadFuncionPadre != null)
           {
               DataHelper.Validate((entity.Activo) ? FinalidadFuncionBusiness.Current.GetList(new FinalidadFuncionFilter() { IdFinalidadFuncion = entity.IdFinalidadFuncionPadre }).FirstOrDefault().Activo : true, "Para activar la Finalidad - Función Actual, la Finalidad - Función Padre debe estar activa");
           }
       }
       #endregion
    }
}
