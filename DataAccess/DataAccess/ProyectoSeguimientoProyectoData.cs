using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoSeguimientoProyectoData : _ProyectoSeguimientoProyectoData 
    { 
	   #region Singleton
	   private static volatile ProyectoSeguimientoProyectoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoProyectoData() {}
	   public static ProyectoSeguimientoProyectoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoProyectoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoSeguimientoProyecto"; } } 


       protected override IQueryable<ProyectoSeguimientoProyectoResult> QueryResult(ProyectoSeguimientoProyectoFilter filter)
       {
           return
               (from o in base.QueryResult(filter)
                join _proyectoSeguimiento in this.Context.ProyectoSeguimientos
                on
                   o.IdProyectoSeguimiento equals _proyectoSeguimiento.IdProyectoSeguimiento
                into tproyectoSeguimiento from proyectoSeguimiento in tproyectoSeguimiento.DefaultIfEmpty()
                join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos
                on
                    proyectoSeguimiento.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento
                into tproyectoDictamenSeguimiento from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
                where (
                    (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen)
                    && (filter.IdsProyectoSeguimiento == null || filter.IdsProyectoSeguimiento.Count == 0 || filter.IdsProyectoSeguimiento.Contains(o.IdProyectoSeguimiento))
                )
                select o
            ).AsQueryable();
       }
       public List<ProyectoSeguimientoProyectoResult> ProyectoSeguimientoConProvincias(ProyectoSeguimientoProyectoFilter filter)
       {
           var query = (from o in Query(filter)
                   join t1 in this.Context.Proyectos on o.IdProyecto equals t1.IdProyecto
//                   join t2 in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento
                   join t2 in this.Context.ProyectoDictamenSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento
                   where filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == null || t2.IdProyectoDictamen == filter.IdProyectoDictamen

                   select new ProyectoSeguimientoProyectoResult()
                   {
                       IdProyectoSeguimientoProyecto = o.IdProyectoSeguimientoProyecto
                       ,IdProyectoSeguimiento = o.IdProyectoSeguimiento
                       ,IdProyecto = o.IdProyecto
                       ,Proyecto_Codigo = t1.Codigo
                       ,Proyecto_ProyectoDenominacion = t1.ProyectoDenominacion
                       ,Proyecto_ProvinciasConcatenadas = Context.fnGetProyectoLocalidadDetalladaPorProyecto(o.IdProyecto).Select (i=> i.Provincia).SingleOrDefault()
                   }
                     ).AsQueryable();
           return query.ToList();
       }


    }
}
