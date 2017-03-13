using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class IndicadorEvolucionResult : _IndicadorEvolucionResult
    {
        public decimal? MontoEstimadoCalc { get; set; }
        public decimal? MontoRealizadoCalc { get; set; }

        private bool validarCantidadEstados = true;
        public bool ValidarCantidadEstados 
        {
            get { return validarCantidadEstados; }
            set { validarCantidadEstados = value; } 
        }

        public string Orden
        {
            get
            {
                return this.ClasificacionGeografica_Descripcion + " " + this.NroExpediente + " " + ((this.FechaEstimada!=null)? ((DateTime)this.FechaEstimada).ToShortDateString() : "");
            }
        }

        public bool Equals(IndicadorEvolucionResult entity)
        {
            if (entity == null) return false;
            if (!entity.IdIndicadorEvolucion.Equals(this.IdIndicadorEvolucion)) return false;
            if (!entity.IdIndicador.Equals(this.IdIndicador)) return false;
            if (!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica)) return false;
            if (!entity.IdIndicadorEvolucionInstancia.Equals(this.IdIndicadorEvolucionInstancia)) return false;
            if ((entity.FechaEstimada == null) ? this.FechaEstimada != null : !entity.FechaEstimada.Equals(this.FechaEstimada)) return false;
            if ((entity.CantidadEstimada == null) ? this.CantidadEstimada != null : !entity.CantidadEstimada.Equals(this.CantidadEstimada)) return false;
            if ((entity.PrecioUnitarioEstimado == null) ? this.PrecioUnitarioEstimado != null : !entity.PrecioUnitarioEstimado.Equals(this.PrecioUnitarioEstimado)) return false;
            if ((entity.FechaReal == null) ? this.FechaReal != null : !entity.FechaReal.Equals(this.FechaReal)) return false;
            if ((entity.CantidadReal == null) ? this.CantidadReal != null : !entity.CantidadReal.Equals(this.CantidadReal)) return false;
            if ((entity.PrecioUnitarioReal == null) ? this.PrecioUnitarioReal != null : !entity.PrecioUnitarioReal.Equals(this.PrecioUnitarioReal)) return false;
            if ((entity.CertificadoNumero == null) ? this.CertificadoNumero != null : !entity.CertificadoNumero.Equals(this.CertificadoNumero)) return false;
            if ((entity.CertificadoFechaPago == null) ? this.CertificadoFechaPago != null : !entity.CertificadoFechaPago.Equals(this.CertificadoFechaPago)) return false;
            if ((entity.CertificadoFechaVencimiento == null) ? this.CertificadoFechaVencimiento != null : !entity.CertificadoFechaVencimiento.Equals(this.CertificadoFechaVencimiento)) return false;
            if ((entity.IdCertificadoEstado == null) ? (this.IdCertificadoEstado.HasValue && this.IdCertificadoEstado.Value > 0) : !entity.IdCertificadoEstado.Equals(this.IdCertificadoEstado)) return false;
            if ((entity.CantidadAcumuladaEstimada == null) ? this.CantidadAcumuladaEstimada != null : !entity.CantidadAcumuladaEstimada.Equals(this.CantidadAcumuladaEstimada)) return false;
            if ((entity.CantidadAcumuladaRealizada == null) ? this.CantidadAcumuladaRealizada != null : !entity.CantidadAcumuladaRealizada.Equals(this.CantidadAcumuladaRealizada)) return false;
            if ((entity.MontoEstimado == null) ? this.MontoEstimado != null : !entity.MontoEstimado.Equals(this.MontoEstimado)) return false;
            if ((entity.MontoRealizado == null) ? this.MontoRealizado != null : !entity.MontoRealizado.Equals(this.MontoRealizado)) return false;
            if ((entity.Observacion == null) ? this.Observacion != null : !entity.Observacion.Equals(this.Observacion)) return false;
            if ((entity.Cotizacion == null) ? this.Cotizacion != null : !entity.Cotizacion.Equals(this.Cotizacion)) return false;
            if ((entity.NumeroDesembolso == null) ? this.NumeroDesembolso != null : !entity.NumeroDesembolso.Equals(this.NumeroDesembolso)) return false;
            if ((entity.NroExpediente == null) ? this.NroExpediente != null : !entity.NroExpediente.Equals(this.NroExpediente)) return false;

            return true;
        }
    }
}
