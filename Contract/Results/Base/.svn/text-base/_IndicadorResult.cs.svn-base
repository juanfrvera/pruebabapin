using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
    [Serializable]
    public abstract class _IndicadorResult : IResult<int>
    {
        public virtual int ID { get { return IdIndicador; } }
        public int IdIndicador { get; set; }
        public int? IdMedioVerificacion { get; set; }
        public string Observacion { get; set; }
        public string DetalleMedioVerificacion { get; set; }
        public string MedioVerificacion_Sigla { get; set; }
        public string MedioVerificacion_Nombre { get; set; }

        public virtual Indicador ToEntity()
		{
		   Indicador _Indicador = new Indicador();
		_Indicador.IdIndicador = this.IdIndicador;
		 _Indicador.IdMedioVerificacion = this.IdMedioVerificacion;
		 _Indicador.Observacion = this.Observacion;
         _Indicador.DetalleMedioVerificacion = this.DetalleMedioVerificacion;
		 
		  return _Indicador;
		}
        public virtual void Set(Indicador entity)
        {
            this.IdIndicador = entity.IdIndicador;
            this.IdMedioVerificacion = entity.IdMedioVerificacion;
            this.Observacion = entity.Observacion;
            this.DetalleMedioVerificacion = entity.DetalleMedioVerificacion;
        }
        public virtual bool Equals(Indicador entity)
        {
            if (entity == null) return false;
            if (!entity.IdIndicador.Equals(this.IdIndicador)) return false;
            if ((entity.IdMedioVerificacion == null) ? (this.IdMedioVerificacion.HasValue && this.IdMedioVerificacion.Value > 0) : !entity.IdMedioVerificacion.Equals(this.IdMedioVerificacion)) return false;
            if ((entity.Observacion == null) ? this.Observacion != null : !entity.Observacion.Equals(this.Observacion)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("Indicador", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("MedioVerificacion","MedioVerificacion_Nombre")
			,new DataColumnMapping("Observacion","Observacion")
            ,new DataColumnMapping("_detalleMedioVerificacion", "DetalleMedioVerificacion")
			}));
        }
    }
}
