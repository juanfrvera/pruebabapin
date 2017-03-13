using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
    [Serializable]
    public abstract class _ObjetivoIndicadorResult : IResult<int>
    {
        public virtual int ID { get { return IdObjetivoIndicador; } }
        public int IdObjetivoIndicador { get; set; }
        public int IdObjetivo { get; set; }
        public int IdIndicadorClase { get; set; }
        public int IdIndicador { get; set; }

        public int? Indicador_IdMedioVerificacion { get; set; }
        public string Indicador_Observacion { get; set; }
        public int IndicadorClase_IdIndicadorTipo { get; set; }
        public string IndicadorClase_Sigla { get; set; }
        public string IndicadorClase_Nombre { get; set; }
        public int IndicadorClase_IdUnidad { get; set; }
        public int? IndicadorClase_RangoInicial { get; set; }
        public int? IndicadorClase_RangoFinal { get; set; }
        public bool IndicadorClase_Activo { get; set; }
        public string Objetivo_Nombre { get; set; }
        public string Indicador_DetalleMedioVerificacion { get; set; }


        public virtual ObjetivoIndicador ToEntity()
        {
            ObjetivoIndicador _ObjetivoIndicador = new ObjetivoIndicador();
            _ObjetivoIndicador.IdObjetivoIndicador = this.IdObjetivoIndicador;
            _ObjetivoIndicador.IdObjetivo = this.IdObjetivo;
            _ObjetivoIndicador.IdIndicadorClase = this.IdIndicadorClase;
            _ObjetivoIndicador.IdIndicador = this.IdIndicador;

            return _ObjetivoIndicador;
        }
        public virtual void Set(ObjetivoIndicador entity)
        {
            this.IdObjetivoIndicador = entity.IdObjetivoIndicador;
            this.IdObjetivo = entity.IdObjetivo;
            this.IdIndicadorClase = entity.IdIndicadorClase;
            this.IdIndicador = entity.IdIndicador;

        }
        public virtual bool Equals(ObjetivoIndicador entity)
        {
            if (entity == null) return false;
            if (!entity.IdObjetivoIndicador.Equals(this.IdObjetivoIndicador)) return false;
            if (!entity.IdObjetivo.Equals(this.IdObjetivo)) return false;
            if (!entity.IdIndicadorClase.Equals(this.IdIndicadorClase)) return false;
            if (!entity.IdIndicador.Equals(this.IdIndicador)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ObjetivoIndicador", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Objetivo","Objetivo_Nombre")
			,new DataColumnMapping("IndicadorClase","IndicadorClase_Nombre")
			,new DataColumnMapping("Indicador","Indicador_Observacion")
            	,new DataColumnMapping("Indicador","Indicador_DetalleMedioVerificacion")
			}));
        }
    }
}
