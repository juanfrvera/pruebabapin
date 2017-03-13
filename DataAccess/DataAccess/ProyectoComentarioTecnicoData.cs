using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoComentarioTecnicoData : _ProyectoComentarioTecnicoData 
    {
	   #region Singleton
	   private static volatile ProyectoComentarioTecnicoData current;
	   private static object syncRoot = new Object();


       private string TipoProyectoInversion = SolutionContext.Current.TextManager.Translate("Inversión");
       private string TipoProyectoPrestamo = SolutionContext.Current.TextManager.Translate("Préstamo");
        //private ProyectoComentarioTecnicoData() {}
	   public static ProyectoComentarioTecnicoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoComentarioTecnicoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoComentarioTecnico"; } }

        

       protected override IQueryable<ProyectoComentarioTecnicoResult> QueryResult(ProyectoComentarioTecnicoFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.ComentarioTecnicos on o.IdComentarioTecnico equals t1.IdComentarioTecnico
                   join _t2 in this.Context.Prestamos on o.IdPrestamo equals _t2.IdPrestamo into tt2
                   from t2 in tt2.DefaultIfEmpty()
                   join _t3 in this.Context.Proyectos on o.IdProyecto equals _t3.IdProyecto into tt3
                   from t3 in tt3.DefaultIfEmpty()
                   join t4 in this.Context.Personas on o.IdUsuario equals t4.IdPersona
                   join _t5 in this.Context.ProyectoTipos on t3.IdTipoProyecto  equals _t5.IdProyectoTipo into tt5
                   from t5 in tt5.DefaultIfEmpty()
                   where (filter.Numero == null || filter.Numero == 0 || t3.Codigo==filter.Numero || t2.Numero==filter.Numero)
					  
                   select new ProyectoComentarioTecnicoResult()
                   {
                       IdProyectoComentarioTecnico = o.IdProyectoComentarioTecnico
                       ,IdProyecto = o.IdProyecto
                       ,IdComentarioTecnico = o.IdComentarioTecnico
                       ,Observacion = o.Observacion
                       ,IdUsuario = o.IdUsuario
                       ,Fecha = o.Fecha
                       ,FechaAlta = o.FechaAlta
                       ,IdPrestamo = o.IdPrestamo
                       ,ComentarioTecnico_Nombre = t1.Nombre
                       ,ComentarioTecnico_Activo = t1.Activo
                       //,Prestamo_IdPrograma = t2 != null ? (int?)t2.IdPrograma : null
                       //,Prestamo_Numero = t2 != null ? (int?)t2.Numero : null
                       //,Prestamo_Denominacion = t2 != null ? (string)t2.Denominacion : null
                       //,Prestamo_Descripcion = t2 != null ? (string)t2.Descripcion : null
                       //,Prestamo_Observacion = t2 != null ? (string)t2.Observacion : null
                       //,Prestamo_FechaAlta = t2 != null ? (DateTime?)t2.FechaAlta : null
                       //,Prestamo_FechaModificacion = t2 != null ? (DateTime?)t2.FechaModificacion : null
                       //,Prestamo_IdUsuarioModificacion = t2 != null ? (int?)t2.IdUsuarioModificacion : null
                       //,Prestamo_IdEstadoActual = t2 != null ? (int?)t2.IdEstadoActual : null
                       //,Prestamo_ResponsablePolitico = t2 != null ? (string)t2.ResponsablePolitico : null
                       //,Prestamo_ResponsableTecnico = t2 != null ? (string)t2.ResponsableTecnico : null
                       //,Prestamo_CodigoVinculacion1 = t2 != null ? (string)t2.CodigoVinculacion1 : null
                       //,Prestamo_CodigoVinculacion2 = t2 != null ? (string)t2.CodigoVinculacion2 : null
                       //,Proyecto_IdTipoProyecto = t3 != null ? (int?)t3.IdTipoProyecto : null
                       //,Proyecto_IdSubPrograma = t3 != null ? (int?)t3.IdSubPrograma : null
                       //,Proyecto_Codigo = t3 != null ? (int?)t3.Codigo : null
                       //,Proyecto_ProyectoDenominacion = t3 != null ? (string)t3.ProyectoDenominacion : null
                       //,Proyecto_ProyectoSituacionActual = t3 != null ? (string)t3.ProyectoSituacionActual : null
                       //,Proyecto_ProyectoDescripcion = t3 != null ? (string)t3.ProyectoDescripcion : null
                       //,Proyecto_ProyectoObservacion = t3 != null ? (string)t3.ProyectoObservacion : null
                       //,Proyecto_IdEstado = t3 != null ? (int?)t3.IdEstado : null
                       //,Proyecto_IdProceso = t3 != null ? (int?)t3.IdProceso : null
                       //,Proyecto_IdModalidadContratacion = t3 != null ? (int?)t3.IdModalidadContratacion : null
                       //,Proyecto_IdFinalidadFuncion = t3 != null ? (int?)t3.IdFinalidadFuncion : null
                       //,Proyecto_IdOrganismoPrioridad = t3 != null ? (int?)t3.IdOrganismoPrioridad : null
                       //,Proyecto_SubPrioridad = t3 != null ? (int?)t3.SubPrioridad : null
                       //,Proyecto_EsBorrador = t3 != null ? (bool?)t3.EsBorrador : null
                       //,Proyecto_EsProyecto = t3 != null ? (bool?)t3.EsProyecto : null
                       //,Proyecto_NroProyecto = t3 != null ? (int?)t3.NroProyecto : null
                       //,Proyecto_AnioCorriente = t3 != null ? (int?)t3.AnioCorriente : null
                       //,Proyecto_FechaInicioEjecucionCalculada = t3 != null ? (DateTime?)t3.FechaInicioEjecucionCalculada : null
                       //,Proyecto_FechaFinEjecucionCalculada = t3 != null ? (DateTime?)t3.FechaFinEjecucionCalculada : null
                       //,Proyecto_FechaAlta = t3 != null ? (DateTime?)t3.FechaAlta : null
                       //,Proyecto_FechaModificacion = t3 != null ? (DateTime?)t3.FechaModificacion : null
                       //,Proyecto_IdUsuarioModificacion = t3 != null ? (int?)t3.IdUsuarioModificacion : null
                       //,Proyecto_IdProyectoPlan = t3 != null ? (int?)t3.IdProyectoPlan : null
                       //,Proyecto_EvaluarValidaciones = t3 != null ? (bool?)t3.EvaluarValidaciones : null
                       ,Numero = o.IdProyecto != null ? t3.Codigo : t2.Numero
                       ,Denominacion = o.IdProyecto != null ? t3.ProyectoDenominacion : t2.Denominacion
                       ,TipoProyecto = o.IdProyecto != null ? TipoProyectoInversion : TipoProyectoPrestamo
                       ,NombreCompleto = t4.NombreCompleto
                       ,Proyecto_ProyectoTipoNombre =  t5 != null ?  t5.Nombre :null 
                   }
                     ).AsQueryable();
       }

    }
}
