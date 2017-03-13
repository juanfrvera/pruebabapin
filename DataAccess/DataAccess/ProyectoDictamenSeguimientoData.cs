using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoDictamenSeguimientoData : _ProyectoDictamenSeguimientoData 
    { 
	   #region Singleton
	   private static volatile ProyectoDictamenSeguimientoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenSeguimientoData() {}
	   public static ProyectoDictamenSeguimientoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenSeguimientoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoDictamenSeguimiento"; } }


        protected override IQueryable<ProyectoDictamenSeguimientoResult> QueryResult(ProyectoDictamenSeguimientoFilter filter)
        {
		  return (from o in Query(filter)					
					join t1  in this.Context.ProyectoDictamens on o.IdProyectoDictamen equals t1.IdProyectoDictamen   
				    join t2  in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento   
                    where ( filter.IdProyecto == null || filter.IdProyecto == 0 
                        || (from  psp in this.Context.ProyectoSeguimientoProyectos where psp.IdProyecto == filter.IdProyecto  select psp.IdProyectoSeguimiento ).Contains ( o.IdProyectoSeguimiento)
                    )
				   select new ProyectoDictamenSeguimientoResult(){
					 IdProyectoDictamenSeguimiento=o.IdProyectoDictamenSeguimiento
					 ,IdProyectoDictamen=o.IdProyectoDictamen
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
                    //,ProyectoDictamen_IdProyectoCalificacion= t1.IdProyectoCalificacion	
                    //    ,ProyectoDictamen_Fecha= t1.Fecha	
                    //    ,ProyectoDictamen_FechaVencimiento= t1.FechaVencimiento	
                    //    ,ProyectoDictamen_IdPlanPeriodo= t1.IdPlanPeriodo	
                    //    ,ProyectoDictamen_Monto= t1.Monto	
                    //    ,ProyectoDictamen_Ejercicio= t1.Ejercicio	
                    //    ,ProyectoDictamen_DuracionMeses= t1.DuracionMeses	
                    //    ,ProyectoDictamen_InformeTecnico= t1.InformeTecnico	
                    //    ,ProyectoDictamen_FechaComiteTecnico= t1.FechaComiteTecnico	
                    //    ,ProyectoDictamen_Observacion= t1.Observacion	
                    //    ,ProyectoDictamen_Recomendacion= t1.Recomendacion	
                    //    ,ProyectoDictamen_RespuestaOrganismo= t1.RespuestaOrganismo	
                    //    ,ProyectoDictamen_FechaRepuesta= t1.FechaRepuesta	
                    //    ,ProyectoDictamen_IdEstado= t1.IdEstado	
                    //    ,ProyectoDictamen_FechaEstado= t1.FechaEstado	
                    //    ,ProyectoDictamen_Numero= t1.Numero	
                    //    ,ProyectoDictamen_Denominacion= t1.Denominacion	
                    //    ,ProyectoSeguimiento_IdSaf= t2.IdSaf	
                    //    ,ProyectoSeguimiento_Denominacion= t2.Denominacion	
                    //    ,ProyectoSeguimiento_Ruta= t2.Ruta	
                    //    ,ProyectoSeguimiento_Malla= t2.Malla	
                    //    ,ProyectoSeguimiento_IdAnalista= t2.IdAnalista	
                    //    ,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= t2.IdProyectoSeguimientoAnterior	
						}
                    ).AsQueryable();
        }
    }
}
