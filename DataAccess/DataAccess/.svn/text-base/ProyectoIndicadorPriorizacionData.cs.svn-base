using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoIndicadorPriorizacionData : _ProyectoIndicadorPriorizacionData 
    { 
	   #region Singleton
	   private static volatile ProyectoIndicadorPriorizacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorPriorizacionData() {}
	   public static ProyectoIndicadorPriorizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorPriorizacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoIndicadorPriorizacion"; } }

       protected override IQueryable<ProyectoIndicadorPriorizacionResult> QueryResult(ProyectoIndicadorPriorizacionFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.IndicadorClases on o.IdIndicadorClase equals t1.IdIndicadorClase
                   join t2 in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto
                   join t3 in this.Context.UnidadMedidas on t1.IdUnidad equals t3.IdUnidadMedida
                   select new ProyectoIndicadorPriorizacionResult()
                   {
                       IdProyectoIndicadorPriorizacion = o.IdProyectoIndicadorPriorizacion
                       ,
                       IdProyecto = o.IdProyecto
                       ,
                       IdIndicadorClase = o.IdIndicadorClase
                       ,
                       Valor = o.Valor
                       ,
                       Anio = o.Anio
                       ,
                       Observacion = o.Observacion
                       ,
                       IndicadorClase_IdIndicadorTipo = t1.IdIndicadorTipo
                       ,
                       IndicadorClase_Sigla = t1.Sigla
                       ,
                       IndicadorClase_Nombre = t1.Nombre
                       ,
                       IndicadorClase_IdUnidad = t1.IdUnidad
                       ,
                       IndicadorClase_RangoInicial = t1.RangoInicial
                       ,
                       IndicadorClase_RangoFinal = t1.RangoFinal
                       ,
                       IndicadorClase_Activo = t1.Activo
                       ,
                       Proyecto_IdTipoProyecto = t2.IdTipoProyecto
                       ,
                       Proyecto_IdSubPrograma = t2.IdSubPrograma
                       ,
                       Proyecto_Codigo = t2.Codigo
                       ,
                       Proyecto_ProyectoDenominacion = t2.ProyectoDenominacion
                       ,
                       Proyecto_ProyectoSituacionActual = t2.ProyectoSituacionActual
                       ,
                       Proyecto_ProyectoDescripcion = t2.ProyectoDescripcion
                       ,
                       Proyecto_ProyectoObservacion = t2.ProyectoObservacion
                       ,
                       Proyecto_IdEstado = t2.IdEstado
                       ,
                       Proyecto_IdProceso = t2.IdProceso
                       ,
                       Proyecto_IdModalidadContratacion = t2.IdModalidadContratacion
                       ,
                       Proyecto_IdFinalidadFuncion = t2.IdFinalidadFuncion
                       ,
                       Proyecto_IdOrganismoPrioridad = t2.IdOrganismoPrioridad
                       ,
                       Proyecto_SubPrioridad = t2.SubPrioridad
                       ,
                       Proyecto_EsBorrador = t2.EsBorrador
                       ,
                       Proyecto_EsProyecto = t2.EsProyecto
                       ,
                       Proyecto_NroProyecto = t2.NroProyecto
                       ,
                       Proyecto_AnioCorriente = t2.AnioCorriente
                       ,
                       Proyecto_FechaInicioEjecucionCalculada = t2.FechaInicioEjecucionCalculada
                       ,
                       Proyecto_FechaFinEjecucionCalculada = t2.FechaFinEjecucionCalculada
                       ,
                       Proyecto_FechaAlta = t2.FechaAlta
                       ,
                       Proyecto_FechaModificacion = t2.FechaModificacion
                       ,
                       Proyecto_IdUsuarioModificacion = t2.IdUsuarioModificacion
                       ,
                       Proyecto_IdProyectoPlan = t2.IdProyectoPlan
                       ,
                       IndicadorClase_Unidad = t3.Nombre
                   }
                     ).AsQueryable();
       }
    }
}
