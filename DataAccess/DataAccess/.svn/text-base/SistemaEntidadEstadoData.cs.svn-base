using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaEntidadEstadoData : _SistemaEntidadEstadoData 
    { 
	   #region Singleton
	   private static volatile SistemaEntidadEstadoData current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadEstadoData() {}
	   public static SistemaEntidadEstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadEstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaEntidadEstado"; } } 
       #region Query
       protected override IQueryable<SistemaEntidadEstado> Query(SistemaEntidadEstadoFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdSistemaEntidadEstado == null || o.IdSistemaEntidadEstado >= filter.IdSistemaEntidadEstado) && (filter.IdSistemaEntidadEstado_To == null || o.IdSistemaEntidadEstado <= filter.IdSistemaEntidadEstado_To)
                   && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad == filter.IdSistemaEntidad)
                   && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado == filter.IdEstado)
                   && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%" || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%", ""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%", ""))) || o.Nombre == filter.Nombre)
                   && (filter.Activo == null || (from estados in this.Context.Estados where estados.IdEstado == o.IdEstado && filter.Activo == estados.Activo select 1).Count() >0)
					  
                   select o
                   ).AsQueryable();
       }
       #endregion
    }
}
