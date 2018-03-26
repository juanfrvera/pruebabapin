using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoComposes
    {
       public bool General { get; set; }
       public bool AlcanceGeografico { get; set; }
       public bool Objetivos { get; set; }
       public bool ProductosIntermedios { get; set; }
       public bool Cronograma { get; set; }
       public bool Evaluacion { get; set; }
    }

    [Serializable]
    public class ProyectCopy
    {
        public int IdProject { get; set; }
        public string Rename { get; set; }
        public int Offset { get; set; }
		public string Codigo { get; set; } //Matias 20140331 - Tarea 131

        private ProyectoComposes solapas;
        public ProyectoComposes Solapas
        {
            get
            {
                if (solapas == null) solapas = new ProyectoComposes(); 
                return solapas; }
            set { solapas = value; }
        }
    }

    [Serializable]
    public class CambioEstructuraDestino
    {
        public int IdSAF { get; set; }
        public int IdPrograma { get; set; }
        public int IdSubPrograma { get; set; }
        public int IdOficinaIniciador { get; set; }
        public int IdOficinaEjecutor { get; set; }
        public int IdOficinaResponsable { get; set; }

        public bool IsChanged
        {
            get
            {
                return IdSAF > 0 || IdPrograma > 0 || IdSubPrograma > 0 || IdOficinaIniciador > 0 || IdOficinaEjecutor > 0 || IdOficinaResponsable > 0;
            }
        }
    }

	[Serializable]
    public class ProyectoResult : IResult<int>
    {

        #region ClaseBase
        public virtual int ID { get { return IdProyecto; } }
        public int IdProyecto { get; set; }
        public int IdTipoProyecto { get; set; }
        public int IdSubPrograma { get; set; }
        public int Codigo { get; set; }
        public string ProyectoDenominacion { get; set; }
        public string ProyectoSituacionActual { get; set; }
        public string ProyectoDescripcion { get; set; }
        public string ProyectoObservacion { get; set; }
        public int IdEstado { get; set; }
        public int OldIdEstado { get; set; } //Matias 20170201- Ticket #REQ571729
        public int? IdProceso { get; set; }
        public int? IdModalidadContratacion { get; set; }
        public int? IdFinalidadFuncion { get; set; }
        public int? IdOrganismoPrioridad { get; set; }
        public int? SubPrioridad { get; set; }
        public bool EsBorrador { get; set; }
        public bool? EsProyecto { get; set; }
        public int? NroProyecto { get; set; }
        public int? AnioCorriente { get; set; }
        public DateTime? FechaInicioEjecucionCalculada { get; set; }
        public DateTime? FechaFinEjecucionCalculada { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public int? IdProyectoPlan { get; set; }
        public bool EvaluarValidaciones { get; set; }
        public bool Activo { get; set; }
        public int? IdEstadoDeDesicion { get; set; }
        public bool? EsPPP { get; set; }
        public int? NroActividad { get; set; }
        public int? NroObra { get; set; }
        public int? NroProyectoEjecucion { get; set; }
        public int? NroActividadEjecucion { get; set; }
        public int? NroObraEjecucion { get; set; }

        public string Estado_Nombre { get; set; }
        //public string Estado_Codigo { get; set; }
        //public int Estado_Orden { get; set; }
        //public string Estado_Descripcion { get; set; }
        //public bool Estado_Activo { get; set; }
        //public string EstadoDeDesicion_Nombre { get; set; }
        //public string EstadoDeDesicion_Codigo { get; set; }
        //public int? EstadoDeDesicion_Orden { get; set; }
        //public string EstadoDeDesicion_Descripcion { get; set; }
        //public bool? EstadoDeDesicion_Activo { get; set; }
        //public string FinalidadFuncion_Codigo { get; set; }
        //public string FinalidadFuncion_Denominacion { get; set; }
        //public bool? FinalidadFuncion_Activo { get; set; }
        //public int? FinalidadFuncion_IdFinalidadFunciontipo { get; set; }
        //public int? FinalidadFuncion_IdFinalidadFuncionPadre { get; set; }
        //public string FinalidadFuncion_BreadcrumbId { get; set; }
        //public string FinalidadFuncion_BreadcrumbOrden { get; set; }
        //public int? FinalidadFuncion_Nivel { get; set; }
        //public int? FinalidadFuncion_Orden { get; set; }
        //public string FinalidadFuncion_Descripcion { get; set; }
        //public string FinalidadFuncion_DescripcionInvertida { get; set; }
        //public bool? FinalidadFuncion_Seleccionable { get; set; }
        //public string FinalidadFuncion_BreadcrumbCode { get; set; }
        //public string FinalidadFuncion_DescripcionCodigo { get; set; }
        //public string ModalidadContratacion_Nombre { get; set; }
        //public bool? ModalidadContratacion_Activo { get; set; }
        //public string OrganismoPrioridad_Nombre { get; set; }
        //public bool? OrganismoPrioridad_Activo { get; set; }
        //public int? Proceso_IdProyectoTipo { get; set; }
        public string Proceso_Nombre { get; set; } //Matias 20170125 - Ticket TP y Pr
        //public bool? Proceso_Activo { get; set; }
        //public string TipoProyecto_Sigla { get; set; }
        public string TipoProyecto_Nombre { get; set; }
        //public bool TipoProyecto_Activo { get; set; }
        //public string TipoProyecto_Tipo { get; set; }
        //public int SubPrograma_IdPrograma { get; set; }
        public string SubPrograma_Codigo { get; set; }
        public string SubPrograma_Nombre { get; set; } /*Matias 20170302 - Ticket #REQ792885*/
        //public DateTime SubPrograma_FechaAlta { get; set; }
        //public DateTime? SubPrograma_FechaBaja { get; set; }
        //public bool SubPrograma_Activo { get; set; }	
        #endregion

        public string ModalidadContratacion_Nombre { get; set; } /*Matias 20170302 - Ticket #REQ792885*/
        public string FinalidadFuncion_DescripcionInvertida { get; set; }  /*Matias 20170302 - Ticket #REQ792885*/
        public string FinalidadFuncion_BreadcrumbCode { get; set; }  /*Matias 20170302 - Ticket #REQ792885*/
        public string OrganismoPrioridad_Nombre { get; set; }  /*Matias 20170302 - Ticket #REQ792885*/
        public int IdSAF { get; set; }
        public int IdPrograma { get; set; }
        public bool RequiereDictamen { get; set; }
        public int IdPrioridad { get; set; }
        public int IdOficina_Usuario{ get; set; }
        public string Programa_Nombre { get; set; }
        public string Programa_Codigo { get; set; }
        public string Saf_Nombre { get; set; }
        public string Saf_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public int? Programa_IdSectorialista { get; set; }
        public int Estado_IdEstadoTipo { get; set; }
        public int IdUsuario { get; set; }
        public string Plan_Ultimo { get; set; }
        public string Apertura { get; set; }
        public System.Drawing.Color Color { get; set; }
        public bool CalidadACorregir { get; set; }
        private List<PerfilOficina> perfilOficinas;
        public List<PerfilOficina> PerfilOficinas
        {
            get {
                if (perfilOficinas == null) perfilOficinas = new List<PerfilOficina>(); 
                return perfilOficinas; }
            set { perfilOficinas = value; }
        }

        public string Saf_SectorNombre { get; set; }
        public string Saf_AdministracionTipoNombre { get; set; }
        public string Saf_EntidadTipoNombre { get; set; }
        public string CodigoString { get { return Codigo.ToString(); } }

        //Matias 20140512 - Tarea 133
        public string Localizacion { get; set; }
        public string FinalidadFuncion { get; set; }
        public string Proceso { get; set; }
        public string ModalidadContratacion { get; set; }
        public string Plan { get; set; }
        public string Prestamo { get; set; }
        private string partido = string.Empty;
        public string Partido 
        {
            get { return partido; }
            set { partido = value; }
        }
        //FinMatias 20140512 - Tarea 133
        //public bool GenerateHistoryCopy { get; set; } //Matias 20170201 - Ticket #REQ571729                
        
        public  DataTableMapping ToMapping()
        {
            return new DataTableMapping("Proyecto", new List<DataColumnMapping>(new DataColumnMapping[]
                {new DataColumnMapping("JU","Jurisdiccion_Codigo")
                ,new DataColumnMapping("SAF","Saf_Codigo")
                ,new DataColumnMapping("PR","Programa_Codigo")
                ,new DataColumnMapping("SP","SubPrograma_Codigo")                
                ,new DataColumnMapping("BAPIN","Codigo")
                ,new DataColumnMapping("Denominación","ProyectoDenominacion")
                ,new DataColumnMapping("Estado","Estado_Nombre")
                ,new DataColumnMapping("Plan","Plan_Ultimo")
                ,new DataColumnMapping("Tipo de Proyecto","TipoProyecto_Nombre")
                ,new DataColumnMapping("Apertura Presupuestaria","Apertura") /*Matias 20130210 - Tarea 116*/
                }));
        }



        public virtual Proyecto ToEntity()
        {
            Proyecto _Proyecto = new Proyecto();
            _Proyecto.IdProyecto = this.IdProyecto;
            _Proyecto.IdTipoProyecto = this.IdTipoProyecto;
            _Proyecto.IdSubPrograma = this.IdSubPrograma;
            _Proyecto.Codigo = this.Codigo;
            _Proyecto.ProyectoDenominacion = this.ProyectoDenominacion;
            _Proyecto.ProyectoSituacionActual = this.ProyectoSituacionActual;
            _Proyecto.ProyectoDescripcion = this.ProyectoDescripcion;
            _Proyecto.ProyectoObservacion = this.ProyectoObservacion;
            _Proyecto.IdEstado = this.IdEstado;
            _Proyecto.IdProceso = this.IdProceso;
            _Proyecto.IdModalidadContratacion = this.IdModalidadContratacion;
            _Proyecto.IdFinalidadFuncion = this.IdFinalidadFuncion;
            _Proyecto.IdOrganismoPrioridad = this.IdOrganismoPrioridad;
            _Proyecto.SubPrioridad = this.SubPrioridad;
            _Proyecto.EsBorrador = this.EsBorrador;
            _Proyecto.EsProyecto = this.EsProyecto;
            _Proyecto.NroProyecto = this.NroProyecto;
            _Proyecto.AnioCorriente = this.AnioCorriente;
            _Proyecto.FechaInicioEjecucionCalculada = this.FechaInicioEjecucionCalculada;
            _Proyecto.FechaFinEjecucionCalculada = this.FechaFinEjecucionCalculada;
            _Proyecto.FechaAlta = this.FechaAlta;
            _Proyecto.FechaModificacion = this.FechaModificacion;
            _Proyecto.IdUsuarioModificacion = this.IdUsuarioModificacion;
            _Proyecto.IdProyectoPlan = this.IdProyectoPlan;
            _Proyecto.EvaluarValidaciones = this.EvaluarValidaciones;
            _Proyecto.Activo = this.Activo;
            _Proyecto.IdEstadoDeDesicion = this.IdEstadoDeDesicion;
            _Proyecto.EsPPP = this.EsPPP;
            _Proyecto.NroActividad = this.NroActividad;
            _Proyecto.NroObra = this.NroObra;
            _Proyecto.NroProyectoEjecucion = this.NroProyectoEjecucion;
            _Proyecto.NroActividadEjecucion = this.NroActividadEjecucion;
            _Proyecto.NroObraEjecucion = this.NroObraEjecucion;

            return _Proyecto;
        }
        public virtual void Set(Proyecto entity)
        {
            this.IdProyecto = entity.IdProyecto;
            this.IdTipoProyecto = entity.IdTipoProyecto;
            this.IdSubPrograma = entity.IdSubPrograma;
            this.Codigo = entity.Codigo;
            this.ProyectoDenominacion = entity.ProyectoDenominacion;
            this.ProyectoSituacionActual = entity.ProyectoSituacionActual;
            this.ProyectoDescripcion = entity.ProyectoDescripcion;
            this.ProyectoObservacion = entity.ProyectoObservacion;
            this.IdEstado = entity.IdEstado;
            this.IdProceso = entity.IdProceso;
            this.IdModalidadContratacion = entity.IdModalidadContratacion;
            this.IdFinalidadFuncion = entity.IdFinalidadFuncion;
            this.IdOrganismoPrioridad = entity.IdOrganismoPrioridad;
            this.SubPrioridad = entity.SubPrioridad;
            this.EsBorrador = entity.EsBorrador;
            this.EsProyecto = entity.EsProyecto;
            this.NroProyecto = entity.NroProyecto;
            this.AnioCorriente = entity.AnioCorriente;
            this.FechaInicioEjecucionCalculada = entity.FechaInicioEjecucionCalculada;
            this.FechaFinEjecucionCalculada = entity.FechaFinEjecucionCalculada;
            this.FechaAlta = entity.FechaAlta;
            this.FechaModificacion = entity.FechaModificacion;
            this.IdUsuarioModificacion = entity.IdUsuarioModificacion;
            this.IdProyectoPlan = entity.IdProyectoPlan;
            this.EvaluarValidaciones = entity.EvaluarValidaciones;
            this.Activo = entity.Activo;
            this.IdEstadoDeDesicion = entity.IdEstadoDeDesicion;
            this.EsPPP = entity.EsPPP;
            this.NroActividad = entity.NroActividad;
            this.NroObra = entity.NroObra;
            this.NroProyectoEjecucion = entity.NroProyectoEjecucion;
            this.NroActividadEjecucion = entity.NroActividadEjecucion;
            this.NroObraEjecucion = entity.NroObraEjecucion;

        }
        public virtual bool Equals(Proyecto entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if (!entity.IdTipoProyecto.Equals(this.IdTipoProyecto)) return false;
            if (!entity.IdSubPrograma.Equals(this.IdSubPrograma)) return false;
            if (!entity.Codigo.Equals(this.Codigo)) return false;
            if (!entity.ProyectoDenominacion.Equals(this.ProyectoDenominacion)) return false;
            if ((entity.ProyectoSituacionActual == null) ? this.ProyectoSituacionActual != null : !entity.ProyectoSituacionActual.Equals(this.ProyectoSituacionActual)) return false;
            if ((entity.ProyectoDescripcion == null) ? this.ProyectoDescripcion != null : !entity.ProyectoDescripcion.Equals(this.ProyectoDescripcion)) return false;
            if ((entity.ProyectoObservacion == null) ? this.ProyectoObservacion != null : !entity.ProyectoObservacion.Equals(this.ProyectoObservacion)) return false;
            if (!entity.IdEstado.Equals(this.IdEstado)) return false;
            if ((entity.IdProceso == null) ? (this.IdProceso.HasValue && this.IdProceso.Value > 0) : !entity.IdProceso.Equals(this.IdProceso)) return false;
            if ((entity.IdModalidadContratacion == null) ? (this.IdModalidadContratacion.HasValue && this.IdModalidadContratacion.Value > 0) : !entity.IdModalidadContratacion.Equals(this.IdModalidadContratacion)) return false;
            if ((entity.IdFinalidadFuncion == null) ? (this.IdFinalidadFuncion.HasValue && this.IdFinalidadFuncion.Value > 0) : !entity.IdFinalidadFuncion.Equals(this.IdFinalidadFuncion)) return false;
            if ((entity.IdOrganismoPrioridad == null) ? (this.IdOrganismoPrioridad.HasValue && this.IdOrganismoPrioridad.Value > 0) : !entity.IdOrganismoPrioridad.Equals(this.IdOrganismoPrioridad)) return false;
            if ((entity.SubPrioridad == null) ? this.SubPrioridad != null : !entity.SubPrioridad.Equals(this.SubPrioridad)) return false;
            if (!entity.EsBorrador.Equals(this.EsBorrador)) return false;
            if ((entity.EsProyecto == null) ? this.EsProyecto != null : !entity.EsProyecto.Equals(this.EsProyecto)) return false;
            if ((entity.NroProyecto == null) ? this.NroProyecto != null : !entity.NroProyecto.Equals(this.NroProyecto)) return false;
            if ((entity.AnioCorriente == null) ? this.AnioCorriente != null : !entity.AnioCorriente.Equals(this.AnioCorriente)) return false;
            if ((entity.FechaInicioEjecucionCalculada == null) ? this.FechaInicioEjecucionCalculada != null : !entity.FechaInicioEjecucionCalculada.Equals(this.FechaInicioEjecucionCalculada)) return false;
            if ((entity.FechaFinEjecucionCalculada == null) ? this.FechaFinEjecucionCalculada != null : !entity.FechaFinEjecucionCalculada.Equals(this.FechaFinEjecucionCalculada)) return false;
            if (!entity.FechaAlta.Equals(this.FechaAlta)) return false;
            if (!entity.FechaModificacion.Equals(this.FechaModificacion)) return false;
            if (!entity.IdUsuarioModificacion.Equals(this.IdUsuarioModificacion)) return false;
            if ((entity.IdProyectoPlan == null) ? this.IdProyectoPlan != null : !entity.IdProyectoPlan.Equals(this.IdProyectoPlan)) return false;
            if (!entity.EvaluarValidaciones.Equals(this.EvaluarValidaciones)) return false;
            if (!entity.Activo.Equals(this.Activo)) return false;
            if ((entity.IdEstadoDeDesicion == null) ? (this.IdEstadoDeDesicion.HasValue && this.IdEstadoDeDesicion.Value > 0) : !entity.IdEstadoDeDesicion.Equals(this.IdEstadoDeDesicion)) return false;
            if ((entity.EsPPP == null) ? this.EsPPP != null : !entity.EsPPP.Equals(this.EsPPP)) return false;
            if ((entity.NroActividad == null) ? this.NroActividad != null : !entity.NroActividad.Equals(this.NroActividad)) return false;
            if ((entity.NroObra == null) ? this.NroObra != null : !entity.NroObra.Equals(this.NroObra)) return false;
            if ((entity.NroProyectoEjecucion == null) ? this.NroProyectoEjecucion != null : !entity.NroProyectoEjecucion.Equals(this.NroProyectoEjecucion)) return false;
            if ((entity.NroActividadEjecucion == null) ? this.NroActividadEjecucion != null : !entity.NroActividadEjecucion.Equals(this.NroActividadEjecucion)) return false;
            if ((entity.NroObraEjecucion == null) ? this.NroObraEjecucion != null : !entity.NroObraEjecucion.Equals(this.NroObraEjecucion)) return false;

            return true;
        }
    }

    #region Reports
    [Serializable]
    public class ProyectoReportResult : IResult<int>
    {
        public virtual int ID { get { return IdProyecto; } }
        public int IdProyecto { get; set; }
        public int IdSubPrograma { get; set; }
        public int Codigo { get; set; }
        public string ProyectoDenominacion { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoProyecto { get; set; }
        public int? IdProceso { get; set; }
        public int? IdFinalidadFuncion { get; set; }
        public int? NroProyecto { get; set; }
        public DateTime? FechaInicioEjecucionCalculada { get; set; }
        public DateTime? FechaFinEjecucionCalculada { get; set; }
        public int? IdProyectoPlan { get; set; }
        public int? NroBienUso { get; set; }
        //public int? NroObra { get; set; }
        public int? NroProyectoPresupuestario { get; set; }
        public string Estado_Nombre { get; set; }
        public string Plan_Nombre { get; set; }

        public int? NroActividad { get; set; }
        public int? NroObra { get; set; }
        public int? NroProyectoEjecucion { get; set; }
        public int? NroActividadEjecucion { get; set; }
        public int? NroObraEjecucion { get; set; }

        public DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
        
    }
    [Serializable]
    public class ProyectoReportEstimadoRealizado : ProyectoReportResult
    {
        public int Periodo { get; set; }
        public int IdProyecto { get; set; }
        public string Tipo { get; set; }
        public decimal? SaldoPrevio { get; set; }
        public decimal? SaldoDelAnio { get; set; }
        public decimal? SaldoDelAnioSiguiente { get; set; }
        public decimal? SaldoDosAniosFuturos { get; set; }
        public decimal? SaldoAniosFuturos { get; set; }
        //Matias 20131107 - Tarea 72
        public decimal? SaldoPrevioEstimado { get; set; }
        public decimal? SaldoDelAnioEstimado { get; set; }
        public decimal? SaldoDelAnioSiguienteEstimado { get; set; }
        public decimal? SaldoDosAniosFuturosEstimado { get; set; }
        public decimal? SaldoAniosFuturosEstimado { get; set; }
        public decimal? SaldoPrevioRealizado { get; set; }
        public decimal? SaldoDelAnioRealizado { get; set; }
        public decimal? SaldoDelAnioSiguienteRealizado { get; set; }
        public decimal? SaldoDosAniosFuturosRealizado { get; set; }
        public decimal? SaldoAniosFuturosRealizado { get; set; }
        //FinMatias 20131107 - Tarea 72

    }
    public class ProyectoReportFuenteEstimadoRealizado : ProyectoReportEstimadoRealizado
    {
        public int Fuente_Id { get; set; }
        public string Fuente_Codigo { get; set; }
        public string Fuente_Nombre { get; set; }
    }
    [Serializable]
    public class ProyectoReportJurisdiccionResult : ProyectoReportEstimadoRealizado
    { 
        public string SubPrograma_Codigo { get; set; }
        public string SubPrograma_Nombre { get; set; }
        public int IdPrograma { get; set; }
        public string Programa_Codigo { get; set; }
        public string Programa_Nombre { get; set; }
        public int IdSaf { get; set; }
        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
    }
    [Serializable]
    public class ProyectoReportFuenteFinanciamientoResult : ProyectoReportFuenteEstimadoRealizado
    {
        public string SubPrograma_Codigo { get; set; }
        public string SubPrograma_Nombre { get; set; }
        public int IdPrograma { get; set; }
        public string Programa_Codigo { get; set; }
        public string Programa_Nombre { get; set; }
        public int IdSaf { get; set; }
        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
    }
    [Serializable]
    public class ProyectoReportFinalidadFuncionResult : ProyectoReportEstimadoRealizado
    {
        public string SubPrograma_Codigo { get; set; }
        public string SubPrograma_Nombre { get; set; }
        public int IdPrograma { get; set; }
        public string Programa_Codigo { get; set; }
        public string Programa_Nombre { get; set; }
        public int IdSaf { get; set; }
        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
        public string FinalidadFuncion_Codigo { get; set; }
        public string FinalidadFuncion_Denominacion { get; set; }
    }
    [Serializable]
    public class ProyectoReportTipoProyectoResult : ProyectoReportEstimadoRealizado
    {
        public string SubPrograma_Codigo { get; set; }
        public string SubPrograma_Nombre { get; set; }
        public int IdPrograma { get; set; }
        public string Programa_Codigo { get; set; }
        public string Programa_Nombre { get; set; }
        public int IdSaf { get; set; }
        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
        public string TipoProyecto_Nombre { get; set; }
        public string Proceso_Nombre { get; set; }
    }
    [Serializable]
    public class ProyectoReportProvinciaResult : ProyectoReportEstimadoRealizado
    {
        public string SubPrograma_Codigo  { get; set; }
        public string SubPrograma_Nombre { get; set; }
        public int IdPrograma { get; set; }
        public string Programa_Codigo { get; set; }
        public string Programa_Nombre { get; set; }
        public int IdSaf { get; set; }
        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Jurisdiccion_Codigo { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
        public int IdProvincia{ get; set; }
        public string Provincia_Codigo { get; set; }
        public string Provincia_Denominacion { get; set; }

        public string Codigo_Prov {
            get {

                if (Provincia_Codigo == null || Provincia_Codigo.Trim() == string.Empty)
                    return string.Empty;
                string x;
                x = Provincia_Codigo.Split('.')[1];
                return x;
            }

        }

        public string Denominacion_Prov
        {
            get
            {

                if (Provincia_Denominacion == null || Provincia_Denominacion.Trim() == string.Empty)
                    return string.Empty;
                string x;
                x = Provincia_Denominacion.Split('/')[0];
                return x;
            }
        }

    }
    [Serializable]
    public class ProyectoObjetivoReportResult 
    {
        //Proposito/Producto
        public int    ProyectoObjetivo_ID { get; set; }
        public string ProgramaObjetivo_Nombre { get; set; }
        public string ProyectoObjetivo_Nombre { get; set; }
        public int ObjetivoSupuesto_Id { get; set; }
        public string ObjetivoSupuesto_Descripcion { get; set; }
        //Indicador
        public string Indicador_Sigla { get; set; }
        public string Indicador_Descripcion { get; set; }
        public string Unidad_Sigla { get; set; }
        public string Unidad_Descripcion { get; set; }
        public string Indicador_Observacion { get; set; }
        public string MedioVerificacion_Sigla { get; set; }
        public string MedioVerificacion_Nombre { get; set; }



        public string ClasificacionGeografica_Descripcion { get; set; }
        public int ClasificacionGeografica_ID { get; set; }
        public string IndicadorEvolucionInstancia_Nombre { get; set; }
        public int IndicadorEvolucionInstancia_ID { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public decimal? CantidadEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public decimal? CantidadReal { get; set; }
        public int IdIndicadorEvolucion { get; set; }
        public int IdIndicador { get; set; }
    }
    [Serializable]
    public class ProyectoEtapaReportResult
    {
        //Etapa
        public string Etapa_Nombre { get; set; }
        public int Etapa_Orden { get; set; }
        public int ProyectoEtapa_ID { get; set; }
        public string ProyectoEtapa_Nombre { get; set; }
        public int Proyecto_Nro{ get; set; }
        public int? NroEtapa { get; set; }
        public string CodigoVinculacion { get; set; }
        public string Apertura { get; set; }
        //Indicador
        public int IdIndicador { get; set; }
        public string Descripcion { get; set; }
        public string Unidad_Nombre { get; set; }
        public string NroExpediente { get; set; }
        public DateTime? FechaLicitacion { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public string Contratista { get; set; }
        public DateTime? FechaInicioObra { get; set; }
        public string PlazoEjecucion { get; set; }
        public string MonedaNombre { get; set; }
        public int? Magnitud { get; set; }
        public decimal? MontoContrato { get; set; }
        public decimal? MontoVigente { get; set; }
        public string Indicador_Observacion { get; set; }
        public string MedioVerificacion_Sigla { get; set; }
        public string MedioVerificacion_Nombre { get; set; }
        //Evolucion
        public int IdIndicadorEvolucion { get; set; }
        public string ClasificacionGeografica_Descripcion { get; set; }
        public int ClasificacionGeografica_ID { get; set; }
        public string IndicadorEvolucionInstancia_Nombre { get; set; }
        public int IndicadorEvolucionInstancia_ID { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public decimal? CantidadEstimada { get; set; }
        public decimal? PrecioUnitarioEstimado { get; set; }
        public DateTime? FechaReal { get; set; }
        public decimal? CantidadReal { get; set; }
        public decimal? PrecioUnitarioReal { get; set; }
        public string CertificadoNumero { get; set; }
        public DateTime? CertificadoFecha { get; set; }
        public DateTime? CertificadoVto { get; set; }
        public string CertificadoEstado_Nombre { get; set; }
        public decimal? CantidadAcumuladaEstimada{ get; set; }
        public decimal? CantidadAcumuladaRealizada { get; set; }
        public decimal? MontoEstimado { get; set; }
        public decimal? MontoRealizado { get; set; }
        public string EvolucionObservacion { get; set; }
        public decimal? Cotizacion { get; set; }
        public string EvolucionNroDesembolso { get; set; }
        public string EvolucionNroExpediente { get; set; }
        
        
        

    }
    [Serializable]
    public class ProyectoCronogramaReportResult
    {
        public int? IdProyectoEtapa { get; set; }
        public int? Periodo { get; set; }
        public string ProyectoAnioReferencia { get; set; }
        //ProyectoEtapa
        public string Nombre { get; set; }
        public DateTime? FechaInicioEstimada {get;set;}
        public DateTime? FechaFinEstimada{get;set;}
        public DateTime? FechaInicioRealizada{get;set;}
        public DateTime? FechaFinRealizada { get; set; }



        //Estado
        public string Estado_Nombre { get; set; }


        public decimal Estimado { get; set; }
        public decimal Realizado { get; set; }

        //Clasificacion Gasto
        public string ClasificacionGasto_Codigo{ get; set; }
        public string ClasificacionGasto_Nombre{ get; set; }

        //Fuente Financiamiento
        public string FuenteFinanciamiento_Codigo{ get; set; }
        public string FuenteFinanciamiento_Nombre{ get; set; }

        public string Obra { get; set; }
        public string Actividad { get; set; }
        public string Proyecto_Nro {get;set;}

        public int IdFase { get; set; }
        public string Fase_Nombre { get; set; }
        public int Fase_Orden { get; set; }
        public int Etapa_Orden { get; set; }

        public int? AnioCorriente { get; set; }
    }
    [Serializable]
    public class ProyectoEtapaEstimadoRealizado
    { 
        public int Tipo {get;set;}
        public int IdProyectoEtapa {get;set;}
        public int Id{get;set;}
        public int IdClasificacionGasto{get;set;}
        public int IdFuenteFinanciamiento{get;set;}
    }
    [Serializable]
    public class ProyectoBeneficiosReportResult
    {

        public string  IndicadorClase_Sigla{ get; set; }
        public string IndicadorClase_Nombre{ get; set; }
        public string IndicadorClase_Unidad{ get; set; }
        public bool Indirecto{ get; set; }
        public string Indicador_MedioVerificacion { get; set; }

        public string ClasificacionGeografica_Descripcion { get; set; }
        public string IndicadorEvolucionInstancia_Nombre { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public decimal? CantidadEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public decimal? CantidadReal { get; set; }
        public int IdIndicadorEvolucion { get; set; }
        public int IdIndicador { get; set; }
    }
    [Serializable]
    public class ProyectoBeneficiarioReportResult
    {

        public string Descripcion { get; set; }
        public string ClasificacionGeografica_Descripcion { get; set; }
        public string IndicadorEvolucionInstancia_Nombre { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public decimal? CantidadEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public decimal? CantidadReal { get; set; }
        public int IdIndicadorEvolucion { get; set; }
        public int IdIndicador { get; set; }
    }

    #endregion
}
