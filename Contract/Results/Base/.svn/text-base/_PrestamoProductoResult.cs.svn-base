using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
    [Serializable]
    public abstract class _PrestamoProductoResult : IResult<int>
    {
        public virtual int ID { get { return IdPrestamoProducto; } }
        public int IdPrestamoProducto { get; set; }
        public int IdPrestamoComponente { get; set; }
        public int? IdPrestamoSubComponente { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal MontoContraparte { get; set; }
        public bool? InicioGestion { get; set; }
        public bool? NegociarAutorizacion { get; set; }
        public bool? Ejecucion { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdProyectoOrigenFinanciamiento { get; set; }

        public int PrestamoComponente_IdPrestamo { get; set; }
        public int PrestamoComponente_IdObjetivo { get; set; }
        public int? PrestamoSubComponente_IdPrestamoComponente { get; set; }
        public string PrestamoSubComponente_Descripcion { get; set; }
        public int? Proyecto_IdTipoProyecto { get; set; }
        public int? Proyecto_IdSubPrograma { get; set; }
        public int? Proyecto_Codigo { get; set; }
        public string Proyecto_ProyectoDenominacion { get; set; }
        public string Proyecto_ProyectoSituacionActual { get; set; }
        public string Proyecto_ProyectoDescripcion { get; set; }
        public string Proyecto_ProyectoObservacion { get; set; }
        public int? Proyecto_IdEstado { get; set; }
        public int? Proyecto_IdProceso { get; set; }
        public int? Proyecto_IdModalidadContratacion { get; set; }
        public int? Proyecto_IdFinalidadFuncion { get; set; }
        public int? Proyecto_IdOrganismoPrioridad { get; set; }
        public int? Proyecto_SubPrioridad { get; set; }
        public bool? Proyecto_EsBorrador { get; set; }
        public bool? Proyecto_EsProyecto { get; set; }
        public int? Proyecto_NroProyecto { get; set; }
        public int? Proyecto_AnioCorriente { get; set; }
        public DateTime? Proyecto_FechaInicioEjecucionCalculada { get; set; }
        public DateTime? Proyecto_FechaFinEjecucionCalculada { get; set; }
        public DateTime? Proyecto_FechaAlta { get; set; }
        public DateTime? Proyecto_FechaModificacion { get; set; }
        public int? Proyecto_IdUsuarioModificacion { get; set; }
        public int? Proyecto_IdProyectoPlan { get; set; }
        public bool? Proyecto_EvaluarValidaciones { get; set; }

        public virtual PrestamoProducto ToEntity()
        {
            PrestamoProducto _PrestamoProducto = new PrestamoProducto();
            _PrestamoProducto.IdPrestamoProducto = this.IdPrestamoProducto;
            _PrestamoProducto.IdPrestamoComponente = this.IdPrestamoComponente;
            _PrestamoProducto.IdPrestamoSubComponente = this.IdPrestamoSubComponente;
            _PrestamoProducto.Descripcion = this.Descripcion;
            _PrestamoProducto.MontoPrestamo = this.MontoPrestamo;
            _PrestamoProducto.MontoContraparte = this.MontoContraparte;
            _PrestamoProducto.InicioGestion = this.InicioGestion;
            _PrestamoProducto.NegociarAutorizacion = this.NegociarAutorizacion;
            _PrestamoProducto.Ejecucion = this.Ejecucion;
            _PrestamoProducto.IdProyecto = this.IdProyecto;
            _PrestamoProducto.IdProyectoOrigenFinanciamiento = (this.IdProyectoOrigenFinanciamiento.HasValue) ? this.IdProyectoOrigenFinanciamiento.Value : 0;
            

            return _PrestamoProducto;
        }
        public virtual void Set(PrestamoProducto entity)
        {
            this.IdPrestamoProducto = entity.IdPrestamoProducto;
            this.IdPrestamoComponente = entity.IdPrestamoComponente;
            this.IdPrestamoSubComponente = entity.IdPrestamoSubComponente;
            this.Descripcion = entity.Descripcion;
            this.MontoPrestamo = entity.MontoPrestamo;
            this.MontoContraparte = entity.MontoContraparte;
            this.InicioGestion = entity.InicioGestion;
            this.NegociarAutorizacion = entity.NegociarAutorizacion;
            this.Ejecucion = entity.Ejecucion;
            this.IdProyecto = entity.IdProyecto;
            this.IdProyectoOrigenFinanciamiento = entity.IdProyectoOrigenFinanciamiento;

        }
        public virtual bool Equals(PrestamoProducto entity)
        {
            if (entity == null) return false;
            if (!entity.IdPrestamoProducto.Equals(this.IdPrestamoProducto)) return false;
            if (!entity.IdPrestamoComponente.Equals(this.IdPrestamoComponente)) return false;
            if ((entity.IdPrestamoSubComponente == null) ? (this.IdPrestamoSubComponente.HasValue && this.IdPrestamoSubComponente.Value > 0) : !entity.IdPrestamoSubComponente.Equals(this.IdPrestamoSubComponente)) return false;
            if (!entity.Descripcion.Equals(this.Descripcion)) return false;
            if (!entity.MontoPrestamo.Equals(this.MontoPrestamo)) return false;
            if (!entity.MontoContraparte.Equals(this.MontoContraparte)) return false;
            if ((entity.InicioGestion == null) ? this.InicioGestion != null : !entity.InicioGestion.Equals(this.InicioGestion)) return false;
            if ((entity.NegociarAutorizacion == null) ? this.NegociarAutorizacion != null : !entity.NegociarAutorizacion.Equals(this.NegociarAutorizacion)) return false;
            if ((entity.Ejecucion == null) ? this.Ejecucion != null : !entity.Ejecucion.Equals(this.Ejecucion)) return false;
            if ((entity.IdProyecto == null) ? (this.IdProyecto.HasValue && this.IdProyecto.Value > 0) : !entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if ((entity.IdProyectoOrigenFinanciamiento == null) ? (this.IdProyectoOrigenFinanciamiento.HasValue && this.IdProyectoOrigenFinanciamiento.Value > 0) : !entity.IdProyectoOrigenFinanciamiento.Equals(this.IdProyectoOrigenFinanciamiento)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("PrestamoProducto", new List<DataColumnMapping>(new DataColumnMapping[]{
		     new DataColumnMapping("PrestamoComponente","PrestamoComponente_IdPrestamoComponente")
			,new DataColumnMapping("PrestamoSubComponente","PrestamoSubComponente_Descripcion")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("MontoPrestamo","MontoPrestamo")
			,new DataColumnMapping("MontoContraparte","MontoContraparte")
			,new DataColumnMapping("InicioGestion","InicioGestion")
			,new DataColumnMapping("NegociarAutorizacion","NegociarAutorizacion")
			,new DataColumnMapping("Ejecucion","Ejecucion")
			,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
            ,new DataColumnMapping("ProyectoOrigenFinanciamiento","Proyecto_OrigenFinanciamiento")
			}));
        }
    }
}
