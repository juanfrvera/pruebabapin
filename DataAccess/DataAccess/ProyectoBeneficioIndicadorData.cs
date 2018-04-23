using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoBeneficioIndicadorData : _ProyectoBeneficioIndicadorData 
    {
	   #region Singleton
	   private static volatile ProyectoBeneficioIndicadorData current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficioIndicadorData() {}
	   public static ProyectoBeneficioIndicadorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficioIndicadorData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoBeneficioIndicador"; } }

       protected override IQueryable<ProyectoBeneficioIndicadorResult> QueryResult(ProyectoBeneficioIndicadorFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.Indicadors on o.IdIndicador equals t1.IdIndicador
                   join t2 in this.Context.IndicadorClases on o.IdIndicadorClase equals t2.IdIndicadorClase
                   join t3 in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto
                   join _t4 in this.Context.MedioVerificacions on t1.IdMedioVerificacion equals _t4.IdMedioVerificacion into tt4
                   from t4 in tt4.DefaultIfEmpty()
                   join _t5 in this.Context.UnidadMedidas on t2.IdUnidad equals _t5.IdUnidadMedida into tt5
                   from t5 in tt5.DefaultIfEmpty()
                   select new ProyectoBeneficioIndicadorResult()
                   {
                       IdProyectoBeneficioIndicador = o.IdProyectoBeneficioIndicador
                       ,
                       IdProyecto = o.IdProyecto
                       ,
                       IdIndicadorClase = o.IdIndicadorClase
                       ,
                       Indirecto = o.Indirecto
                       ,
                       Valor = o.Valor
                       ,
                       IdIndicador = o.IdIndicador
                       ,
                       Indicador_IdMedioVerificacion = t1.IdMedioVerificacion
                       ,
                       Indicador_Observacion = t1.Observacion
                       ,
                       IndicadorClase_IdIndicadorTipo = t2.IdIndicadorTipo
                       ,
                       IndicadorClase_Sigla = t2.Sigla
                       ,
                       IndicadorClase_Nombre = t2.Nombre
                       ,
                       IndicadorClase_IdUnidad = t2.IdUnidad
                       ,
                       IndicadorClase_RangoInicial = t2.RangoInicial
                       ,
                       IndicadorClase_RangoFinal = t2.RangoFinal
                       ,
                       IndicadorClase_Activo = t2.Activo
                       ,
                       Proyecto_IdTipoProyecto = t3.IdTipoProyecto
                       ,
                       Proyecto_IdSubPrograma = t3.IdSubPrograma
                       ,
                       Proyecto_Codigo = t3.Codigo
                       ,
                       Proyecto_ProyectoDenominacion = t3.ProyectoDenominacion
                       ,
                       Proyecto_ProyectoSituacionActual = t3.ProyectoSituacionActual
                       ,
                       Proyecto_ProyectoDescripcion = t3.ProyectoDescripcion
                       ,
                       Proyecto_ProyectoObservacion = t3.ProyectoObservacion
                       ,
                       Proyecto_IdEstado = t3.IdEstado
                       ,
                       Proyecto_IdProceso = t3.IdProceso
                       ,
                       Proyecto_IdModalidadContratacion = t3.IdModalidadContratacion
                       ,
                       Proyecto_IdFinalidadFuncion = t3.IdFinalidadFuncion
                       ,
                       Proyecto_IdOrganismoPrioridad = t3.IdOrganismoPrioridad
                       ,
                       Proyecto_SubPrioridad = t3.SubPrioridad
                       ,
                       Proyecto_EsBorrador = t3.EsBorrador
                       ,
                       Proyecto_EsProyecto = t3.EsProyecto
                       ,
                       Proyecto_NroProyecto = t3.NroProyecto
                       ,
                       Proyecto_AnioCorriente = t3.AnioCorriente
                       ,
                       Proyecto_FechaInicioEjecucionCalculada = t3.FechaInicioEjecucionCalculada
                       ,
                       Proyecto_FechaFinEjecucionCalculada = t3.FechaFinEjecucionCalculada
                       ,
                       Proyecto_FechaAlta = t3.FechaAlta
                       ,
                       Proyecto_FechaModificacion = t3.FechaModificacion
                       ,
                       Proyecto_IdUsuarioModificacion = t3.IdUsuarioModificacion
                       ,
                       Proyecto_IdProyectoPlan = t3.IdProyectoPlan
                       ,
                       Indicador_MedioVerificacion = t4.Nombre
                       ,
                       IndicadorClase_Unidad = t5.Nombre
                       //German 20140511 - Tarea 124
                       ,
                       IdIndicadorRubro = t1.IdIndicadorRubro
                       //German 20140511 - Tarea 124
                      
                   }
                     ).AsQueryable();
       }

    }
}
