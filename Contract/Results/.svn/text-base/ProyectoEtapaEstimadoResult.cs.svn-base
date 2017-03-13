using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
using System.Data;
namespace Contract
{
	[Serializable]
    public class ProyectoEtapaEstimadoResult : IResult<int>
    {
        public string CodigoGasto
        {
            get { return this.ClasificacionGasto_Codigo; }
            set { this.ClasificacionGasto_Codigo = value; }
        }
        public string CodigoCompletoGasto
        {
            get { return this.ClasificacionGasto_CodigoCompleto; }
            set { this.ClasificacionGasto_CodigoCompleto = value; }
        }
        public string ObjetoGasto
        {
            get { return this.ClasificacionGasto_Nombre; }
            set { this.ClasificacionGasto_Nombre = value; }
        }
        public string FuenteFinanciemiento
        {
            get { return this.FuenteFinanciamiento_Nombre; }
            set { this.FuenteFinanciamiento_Nombre = value; }
        }
        public string OrigenFinanciemiento { get; set; }
        public decimal TotalEstimado
        {
            get
            { 
                decimal rv = 0;
                foreach (ProyectoEtapaEstimadoPeriodoResult e in this.Periodos)
                    rv += e.MontoCalculado;
                return rv;
            }
        }

        public List<ProyectoEtapaEstimadoPeriodoResult> Periodos = new List<ProyectoEtapaEstimadoPeriodoResult>();
        public List<ProyectoEtapaEstimadoPeriodoResult> PeriodosUtilizados
        {
            get 
            {
                List<ProyectoEtapaEstimadoPeriodoResult> usados = new List<ProyectoEtapaEstimadoPeriodoResult>();
                foreach (ProyectoEtapaEstimadoPeriodoResult p in this.Periodos)
                {
                    if (p.MontoCalculado > 0)
                        usados.Add(p);
                }
                return usados;
            }
        }


        public virtual int ID { get { return IdProyectoEtapaEstimado; } }
        public int IdProyectoEtapaEstimado { get; set; }
        public int IdProyectoEtapa { get; set; }
        public int IdClasificacionGasto { get; set; }
        public int IdFuenteFinanciamiento { get; set; }
        public int IdMoneda { get; set; }

        public string ClasificacionGasto_Codigo { get; set; }
        public string ClasificacionGasto_Nombre { get; set; }
        public string ClasificacionGasto_CodigoCompleto { get; set; }

        public string FuenteFinanciamiento_Nombre { get; set; }


        public virtual ProyectoEtapaEstimado ToEntity()
        {
            ProyectoEtapaEstimado _ProyectoEtapaEstimado = new ProyectoEtapaEstimado();
            _ProyectoEtapaEstimado.IdProyectoEtapaEstimado = this.IdProyectoEtapaEstimado;
            _ProyectoEtapaEstimado.IdProyectoEtapa = this.IdProyectoEtapa;
            _ProyectoEtapaEstimado.IdClasificacionGasto = this.IdClasificacionGasto;
            _ProyectoEtapaEstimado.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
            _ProyectoEtapaEstimado.IdMoneda = this.IdMoneda;

            return _ProyectoEtapaEstimado;
        }
        public virtual void Set(ProyectoEtapaEstimado entity)
        {
            this.IdProyectoEtapaEstimado = entity.IdProyectoEtapaEstimado;
            this.IdProyectoEtapa = entity.IdProyectoEtapa;
            this.IdClasificacionGasto = entity.IdClasificacionGasto;
            this.IdFuenteFinanciamiento = entity.IdFuenteFinanciamiento;
            this.IdMoneda = entity.IdMoneda;

        }
        public virtual bool Equals(ProyectoEtapaEstimado entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoEtapaEstimado.Equals(this.IdProyectoEtapaEstimado)) return false;
            if (!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa)) return false;
            if (!entity.IdClasificacionGasto.Equals(this.IdClasificacionGasto)) return false;
            if (!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento)) return false;
            if (!entity.IdMoneda.Equals(this.IdMoneda)) return false;

            return true;
        }
        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoEtapaEstimado", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapa","ProyectoEtapa_Nombre")
			,new DataColumnMapping("ClasificacionGasto","ClasificacionGasto_Nombre")
			,new DataColumnMapping("FuenteFinanciamiento","FuenteFinanciamiento_Nombre")
			,new DataColumnMapping("Moneda","Moneda_Nombre")
			}));
        }
    }
}
