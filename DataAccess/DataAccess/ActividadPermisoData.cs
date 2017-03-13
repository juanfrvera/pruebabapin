using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ActividadPermisoData : _ActividadPermisoData
    {
	   #region Singleton
	   private static volatile ActividadPermisoData current;
	   private static object syncRoot = new Object();

	   //private ActividadPermisoData() {}
	   public static ActividadPermisoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadPermisoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdActividadPermiso"; } }


       protected override IQueryable<ActividadPermiso> Query(ActividadPermisoFilter filter)
       {
           return (from o in this.Table
                   join p in this.Context.Permisos on o.IdPermiso equals p.IdPermiso
                   where (filter.IdActividadPermiso == null || o.IdActividadPermiso >= filter.IdActividadPermiso) && (filter.IdActividadPermiso_To == null || o.IdActividadPermiso <= filter.IdActividadPermiso_To)
                   && (filter.IdPermiso == null || filter.IdPermiso == 0 || o.IdPermiso == filter.IdPermiso)
                   && (filter.IdActividad == null || filter.IdActividad == 0 || o.IdActividad == filter.IdActividad)
                   && (filter.Activo == null || p.Activo == filter.Activo )
                   select o
                   ).AsQueryable();
       }

        protected override IQueryable<ActividadPermisoResult> QueryResult(ActividadPermisoFilter filter)
        {
		  return (from o in Query(filter)					
				  join t1  in this.Context.Actividads on o.IdActividad equals t1.IdActividad   
				  join t2  in this.Context.Permisos on o.IdPermiso equals t2.IdPermiso
                  join _sa in this.Context.SistemaAccions on t2.IdSistemaAccion equals _sa.IdSistemaAccion into tsa
                  from sa in tsa.DefaultIfEmpty()
                  join _se in this.Context.SistemaEntidads on t2.IdSistemaEntidad equals _se.IdSistemaEntidad into tse
                  from se in tse.DefaultIfEmpty()
                  join _e in this.Context.Estados on t2.IdSistemaEstado equals _e.IdEstado into te
                  from e in te.DefaultIfEmpty()				      
                  select new ActividadPermisoResult(){
                            IdActividadPermiso=o.IdActividadPermiso
                            ,IdPermiso=o.IdPermiso
                            ,Permiso_Codigo = t2.Codigo
                            ,IdActividad=o.IdActividad
                            ,Actividad_Nombre= t1.Nombre	
                            ,Actividad_Activo= t1.Activo	
                            ,Permiso_Nombre= t2.Nombre	
                            ,Permiso_IdSistemaEntidad= t2.IdSistemaEntidad	
                            ,Permiso_IdSistemaAccion= t2.IdSistemaAccion
	                        ,Permiso_SistemaAccion_IncluirEstado = sa!=null?sa.IncluirEstado:false
                            ,Permiso_IdSistemaEstado= t2.IdSistemaEstado	
                            ,Permiso_Activo= t2.Activo
	                        ,Permiso_SistemaAccion_Nombre = sa !=null?sa.Nombre:""
                            ,Permiso_SistemaEntidad_Nombre = se != null? se.Nombre:""
                            ,Permiso_SistemaEstado_Nombre = e !=null?e.Nombre:""
                            ,Selected = true                            
						}
                    ).AsQueryable();
        }
    }
}
