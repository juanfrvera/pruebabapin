using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
    [Serializable]
    public abstract class _ProyectoDictamenResult : IResult<int>
    {
        public _ProyectoDictamenResult()
        { }

        public virtual int ID { get { return IdProyectoDictamen; } }
        public int IdProyectoDictamen { get; set; }
        public int? IdProyectoCalificacion { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? IdPlanPeriodo { get; set; }
        public decimal? Monto { get; set; }
        public int? Ejercicio { get; set; }
        public int? DuracionMeses { get; set; }
        public string InformeTecnico { get; set; }
        public DateTime? FechaComiteTecnico { get; set; }
        public string Observacion { get; set; }
        public string Recomendacion { get; set; }
        public string RespuestaOrganismo { get; set; }
        public DateTime? FechaRepuesta { get; set; }
        public DateTime FechaEstado { get; set; }
        public string Numero { get; set; }
        public string Denominacion { get; set; }
        public int? IdProyectoDictamenEstadoUltimo { get; set; }

        public int? PlanPeriodo_IdPlanTipo { get; set; }
        public string PlanPeriodo_Nombre { get; set; }
        public string PlanPeriodo_Sigla { get; set; }
        public int? PlanPeriodo_AnioInicial { get; set; }
        public int? PlanPeriodo_AnioFinal { get; set; }
        public bool? PlanPeriodo_Activo { get; set; }
        public string ProyectoCalificacion_Nombre { get; set; }
        public bool? ProyectoCalificacion_Activo { get; set; }
        public int? ProyectoDictamenEstadoUltimo_IdProyectoDictamen { get; set; }
        public int? ProyectoDictamenEstadoUltimo_IdEstado { get; set; }
        public DateTime? ProyectoDictamenEstadoUltimo_Fecha { get; set; }
        public string ProyectoDictamenEstadoUltimo_Observacion { get; set; }
        public int? ProyectoDictamenEstadoUltimo_IdUsuario { get; set; }

        public virtual ProyectoDictamen ToEntity()
        {
            ProyectoDictamen _ProyectoDictamen = new ProyectoDictamen();
            _ProyectoDictamen.IdProyectoDictamen = this.IdProyectoDictamen;
            _ProyectoDictamen.IdProyectoCalificacion = this.IdProyectoCalificacion;
            _ProyectoDictamen.Fecha = this.Fecha;
            _ProyectoDictamen.FechaVencimiento = this.FechaVencimiento;
            _ProyectoDictamen.IdPlanPeriodo = this.IdPlanPeriodo;
            _ProyectoDictamen.Monto = this.Monto;
            _ProyectoDictamen.Ejercicio = this.Ejercicio;
            _ProyectoDictamen.DuracionMeses = this.DuracionMeses;
            _ProyectoDictamen.InformeTecnico = this.InformeTecnico;
            _ProyectoDictamen.FechaComiteTecnico = this.FechaComiteTecnico;
            _ProyectoDictamen.Observacion = this.Observacion;
            _ProyectoDictamen.Recomendacion = this.Recomendacion;
            _ProyectoDictamen.RespuestaOrganismo = this.RespuestaOrganismo;
            _ProyectoDictamen.FechaRepuesta = this.FechaRepuesta;
            _ProyectoDictamen.FechaEstado = this.FechaEstado;
            _ProyectoDictamen.Numero = this.Numero;
            _ProyectoDictamen.Denominacion = this.Denominacion;
            _ProyectoDictamen.IdProyectoDictamenEstadoUltimo = this.IdProyectoDictamenEstadoUltimo;

            return _ProyectoDictamen;
        }
        public virtual void Set(ProyectoDictamen entity)
        {
            this.IdProyectoDictamen = entity.IdProyectoDictamen;
            this.IdProyectoCalificacion = entity.IdProyectoCalificacion;
            this.Fecha = entity.Fecha;
            this.FechaVencimiento = entity.FechaVencimiento;
            this.IdPlanPeriodo = entity.IdPlanPeriodo;
            this.Monto = entity.Monto;
            this.Ejercicio = entity.Ejercicio;
            this.DuracionMeses = entity.DuracionMeses;
            this.InformeTecnico = entity.InformeTecnico;
            this.FechaComiteTecnico = entity.FechaComiteTecnico;
            this.Observacion = entity.Observacion;
            this.Recomendacion = entity.Recomendacion;
            this.RespuestaOrganismo = entity.RespuestaOrganismo;
            this.FechaRepuesta = entity.FechaRepuesta;
            this.FechaEstado = entity.FechaEstado;
            this.Numero = entity.Numero;
            this.Denominacion = entity.Denominacion;
            this.IdProyectoDictamenEstadoUltimo = entity.IdProyectoDictamenEstadoUltimo;

        }
        public virtual bool Equals(ProyectoDictamen entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoDictamen.Equals(this.IdProyectoDictamen)) return false;
            if ((entity.IdProyectoCalificacion == null) ? (this.IdProyectoCalificacion.HasValue && this.IdProyectoCalificacion.Value > 0) : !entity.IdProyectoCalificacion.Equals(this.IdProyectoCalificacion)) return false;
            if ((entity.Fecha == null) ? (this.Fecha.HasValue) : !entity.Fecha.Equals(this.Fecha)) return false;
            if ((entity.FechaVencimiento == null) ? (this.FechaVencimiento.HasValue) : !entity.FechaVencimiento.Equals(this.FechaVencimiento)) return false;
            if ((entity.IdPlanPeriodo == null) ? (this.IdPlanPeriodo.HasValue && this.IdPlanPeriodo.Value > 0) : !entity.IdPlanPeriodo.Equals(this.IdPlanPeriodo)) return false;
            if ((entity.Monto == null) ? (this.Monto.HasValue) : !entity.Monto.Equals(this.Monto)) return false;
            if ((entity.Ejercicio == null) ? (this.Ejercicio.HasValue) : !entity.Ejercicio.Equals(this.Ejercicio)) return false;
            if ((entity.DuracionMeses == null) ? (this.DuracionMeses.HasValue) : !entity.DuracionMeses.Equals(this.DuracionMeses)) return false;
            if ((entity.InformeTecnico == null) ? this.InformeTecnico != null : !((this.InformeTecnico == String.Empty && entity.InformeTecnico == null) || (this.InformeTecnico == null && entity.InformeTecnico == String.Empty)) && !entity.InformeTecnico.Trim().Replace("\r", "").Equals(this.InformeTecnico.Trim().Replace("\r", ""))) return false;
            if ((entity.FechaComiteTecnico == null) ? (this.FechaComiteTecnico.HasValue) : !entity.FechaComiteTecnico.Equals(this.FechaComiteTecnico)) return false;
            if ((entity.Observacion == null) ? this.Observacion != null : !((this.Observacion == String.Empty && entity.Observacion == null) || (this.Observacion == null && entity.Observacion == String.Empty)) && !entity.Observacion.Trim().Replace("\r", "").Equals(this.Observacion.Trim().Replace("\r", ""))) return false;
            if ((entity.Recomendacion == null) ? this.Recomendacion != null : !((this.Recomendacion == String.Empty && entity.Recomendacion == null) || (this.Recomendacion == null && entity.Recomendacion == String.Empty)) && !entity.Recomendacion.Trim().Replace("\r", "").Equals(this.Recomendacion.Trim().Replace("\r", ""))) return false;
            if ((entity.RespuestaOrganismo == null) ? this.RespuestaOrganismo != null : !((this.RespuestaOrganismo == String.Empty && entity.RespuestaOrganismo == null) || (this.RespuestaOrganismo == null && entity.RespuestaOrganismo == String.Empty)) && !entity.RespuestaOrganismo.Trim().Replace("\r", "").Equals(this.RespuestaOrganismo.Trim().Replace("\r", ""))) return false;
            if ((entity.FechaRepuesta == null) ? (this.FechaRepuesta.HasValue) : !entity.FechaRepuesta.Equals(this.FechaRepuesta)) return false;
            if (!entity.FechaEstado.Equals(this.FechaEstado)) return false;
            if ((entity.Numero == null) ? this.Numero != null : !((this.Numero == String.Empty && entity.Numero == null) || (this.Numero == null && entity.Numero == String.Empty)) && !entity.Numero.Trim().Replace("\r", "").Equals(this.Numero.Trim().Replace("\r", ""))) return false;
            if ((entity.Denominacion == null) ? this.Denominacion != null : !((this.Denominacion == String.Empty && entity.Denominacion == null) || (this.Denominacion == null && entity.Denominacion == String.Empty)) && !entity.Denominacion.Trim().Replace("\r", "").Equals(this.Denominacion.Trim().Replace("\r", ""))) return false;
            if ((entity.IdProyectoDictamenEstadoUltimo == null) ? (this.IdProyectoDictamenEstadoUltimo.HasValue && this.IdProyectoDictamenEstadoUltimo.Value > 0) : !entity.IdProyectoDictamenEstadoUltimo.Equals(this.IdProyectoDictamenEstadoUltimo)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoDictamen", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("ProyectoCalificacion","ProyectoCalificacion_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaVencimiento","FechaVencimiento","{0:dd/MM/yyyy}")
			,new DataColumnMapping("PlanPeriodo","PlanPeriodo_Nombre")
			,new DataColumnMapping("Monto","Monto")
			,new DataColumnMapping("Ejercicio","Ejercicio")
			,new DataColumnMapping("DuracionMeses","DuracionMeses")
			,new DataColumnMapping("InformeTecnico","InformeTecnico")
			,new DataColumnMapping("FechaComiteTecnico","FechaComiteTecnico","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Recomendacion","Recomendacion")
			,new DataColumnMapping("RespuestaOrganismo","RespuestaOrganismo")
			,new DataColumnMapping("FechaRepuesta","FechaRepuesta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaEstado","FechaEstado","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Numero","Numero")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("File","IdFile")
			,new DataColumnMapping("ProyectoDictamenEstadoUltimo","ProyectoDictamenEstado_Observacion")
			}));
        }
    }
}
