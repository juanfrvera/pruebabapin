using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoBeneficiarioIndicadorData : _ProyectoBeneficiarioIndicadorData 
    {
	   #region Singleton
	   private static volatile ProyectoBeneficiarioIndicadorData current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficiarioIndicadorData() {}
	   public static ProyectoBeneficiarioIndicadorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficiarioIndicadorData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoBeneficiarioIndicador"; } }

       protected override IQueryable<ProyectoBeneficiarioIndicadorResult> QueryResult(ProyectoBeneficiarioIndicadorFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.Indicadors on o.IdIndicador equals t1.IdIndicador
                   join t2 in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto
                   join _t3 in this.Context.MedioVerificacions on t1.IdMedioVerificacion equals _t3.IdMedioVerificacion into tt3
                   from t3 in tt3.DefaultIfEmpty()
                   select new ProyectoBeneficiarioIndicadorResult()
                   {
                       IdProyectoBeneficiarioIndicador = o.IdProyectoBeneficiarioIndicador
                       ,
                       IdProyecto = o.IdProyecto
                       ,
                       Beneficiario = o.Beneficiario
                       ,
                       Indirecto = o.Indirecto
                       ,
                       IdIndicador = o.IdIndicador
                       ,
                       Indicador_IdMedioVerificacion = t1.IdMedioVerificacion
                       ,
                       Indicador_Observacion = t1.Observacion
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
                       Indicador_MedioVerificacion = t3.Nombre
                   }
                     ).AsQueryable();
       }

    }
}
