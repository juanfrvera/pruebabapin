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
    public class ClasificacionGeograficaBusiness : _ClasificacionGeograficaBusiness 
    {   
	   #region Singleton
	   private static volatile ClasificacionGeograficaBusiness current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGeograficaBusiness() {}
	   public static ClasificacionGeograficaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGeograficaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override ClasificacionGeografica GetNew()
       {
           ClasificacionGeografica entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }
       public ListPaged<NodeResult> GetNodesResult(ClasificacionGeograficaFilter filter)
       {
           return Data.GetNodesResult(filter);
       }
       #region Actions
       public override void Add(ClasificacionGeografica entity, IContextUser contextUser)
       {

           base.Add(entity, contextUser);
           Data.RefreshClasificacionGeografica(entity.IdClasificacionGeograficaPadre);
       }
       public override void Update(ClasificacionGeografica entity, IContextUser contextUser)
       {
           ClasificacionGeografica clasificacionGeografica = ClasificacionGeograficaBusiness.Current.GetById(entity.IdClasificacionGeografica);
           if ((!entity.Activo) && clasificacionGeografica.Activo)
           {
               Data.ActiveCascadaClasificacionGeografica(entity.IdClasificacionGeografica, false);
           }
           Set(entity, clasificacionGeografica);
           base.Update(clasificacionGeografica, contextUser);
           Data.RefreshClasificacionGeografica(clasificacionGeografica.IdClasificacionGeograficaPadre);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }

       public override void Validate(ClasificacionGeografica entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           DataHelper.Validate(entity.IdClasificacionGeograficaTipo != 0, "La Clasificación Geográfica Padre debe ser de un nivel superior ");
           base.Validate(entity, actionName, contextUser, args);
           if (entity.IdClasificacionGeograficaPadre != null)
           {
               DataHelper.Validate((entity.Activo) ? ClasificacionGeograficaBusiness.Current.GetList(new ClasificacionGeograficaFilter() { IdClasificacionGeografica = entity.IdClasificacionGeograficaPadre }).FirstOrDefault().Activo : true, "Para activar la Clasificación Geográfica actual, la Clasificación Geográfica Padre debe estar activa");
           }
       }
       #endregion
    }
}
