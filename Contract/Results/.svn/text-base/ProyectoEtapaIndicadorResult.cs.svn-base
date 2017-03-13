using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoEtapaIndicadorResult : _ProyectoEtapaIndicadorResult
    {
        public string MedioDeVerificacion { set; get; }
        public int? IdMedioVerificacion { set; get; }

        public bool Equals(ProyectoEtapaIndicadorResult entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoEtapaIndicador.Equals(this.IdProyectoEtapaIndicador)) return false;
            if (!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa)) return false;
            if (!entity.Descripcion.Equals(this.Descripcion)) return false;
            if ((entity.IdUnidadMedia == null) ? this.IdUnidadMedia != null : !entity.IdUnidadMedia.Equals(this.IdUnidadMedia)) return false;
            if ((entity.IdIndicador == null) ? (this.IdIndicador.HasValue && this.IdIndicador.Value > 0) : !entity.IdIndicador.Equals(this.IdIndicador)) return false;
            if ((entity.NroExpediente == null) ? this.NroExpediente != null : !entity.NroExpediente.Equals(this.NroExpediente)) return false;
            if ((entity.FechaLicitacion == null) ? this.FechaLicitacion != null : !entity.FechaLicitacion.Equals(this.FechaLicitacion)) return false;
            if ((entity.FechaContratacion == null) ? this.FechaContratacion != null : !entity.FechaContratacion.Equals(this.FechaContratacion)) return false;
            if ((entity.Contratista == null) ? this.Contratista != null : !entity.Contratista.Equals(this.Contratista)) return false;
            if ((entity.FechaInicioObra == null) ? this.FechaInicioObra != null : !entity.FechaInicioObra.Equals(this.FechaInicioObra)) return false;
            if ((entity.PlazoEjecucion == null) ? this.PlazoEjecucion != null : !entity.PlazoEjecucion.Equals(this.PlazoEjecucion)) return false;
            if ((entity.IdMoneda == null) ? this.IdMoneda != null : !entity.IdMoneda.Equals(this.IdMoneda)) return false;
            if ((entity.Magnitud == null) ? this.Magnitud != null : !entity.Magnitud.Equals(this.Magnitud)) return false;
            if ((entity.MontoContrato == null) ? this.MontoContrato != null : !entity.MontoContrato.Equals(this.MontoContrato)) return false;
            if ((entity.MontoVigente == null) ? this.MontoVigente != null : !entity.MontoVigente.Equals(this.MontoVigente)) return false;
            if (this.MedioDeVerificacion != entity.MedioDeVerificacion) return false;

            return true;
        }
    }
}
