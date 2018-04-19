using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
using System.Data;
namespace Contract
{
	[Serializable]
    public class ProyectoEtapaInformacionPresupuestariaResult : IResult<int>
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
        public decimal TotalInformacionPresupuestaria
        {
            get
            { 
                decimal rv = 0;
                /*foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult e in this.Periodos)
                    rv += e.MontoCalculado;*/
                return rv;
            }
        }

        public List<ProyectoEtapaInformacionPresupuestariaPeriodoResult> Periodos = new List<ProyectoEtapaInformacionPresupuestariaPeriodoResult>();
        public List<ProyectoEtapaInformacionPresupuestariaPeriodoResult> PeriodosUtilizados
        {
            get 
            {
                List<ProyectoEtapaInformacionPresupuestariaPeriodoResult> usados = new List<ProyectoEtapaInformacionPresupuestariaPeriodoResult>();
                /*foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult p in this.Periodos)
                {
                    if (p.MontoCalculado > 0)
                        usados.Add(p);
                }*/
                return usados;
            }
        }


        public virtual int ID { get { return IdProyectoEtapaInformacionPresupuestaria; } }
        public int IdProyectoEtapaInformacionPresupuestaria { get; set; }
        public int IdProyectoEtapa { get; set; }
        public int IdClasificacionGasto { get; set; }
        public int IdFuenteFinanciamiento { get; set; }
        public int IdMoneda { get; set; }

        public string ClasificacionGasto_Codigo { get; set; }
        public string ClasificacionGasto_Nombre { get; set; }
        public string ClasificacionGasto_CodigoCompleto { get; set; }

        public string FuenteFinanciamiento_Nombre { get; set; }


        public virtual ProyectoEtapaInformacionPresupuestaria ToEntity()
        {
            ProyectoEtapaInformacionPresupuestaria _ProyectoEtapaInformacionPresupuestaria = new ProyectoEtapaInformacionPresupuestaria();
            _ProyectoEtapaInformacionPresupuestaria.IdProyectoEtapaInformacionPresupuestaria = this.IdProyectoEtapaInformacionPresupuestaria;
            _ProyectoEtapaInformacionPresupuestaria.IdProyectoEtapa = this.IdProyectoEtapa;
            _ProyectoEtapaInformacionPresupuestaria.IdClasificacionGasto = this.IdClasificacionGasto;
            _ProyectoEtapaInformacionPresupuestaria.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
            _ProyectoEtapaInformacionPresupuestaria.IdMoneda = this.IdMoneda;

            return _ProyectoEtapaInformacionPresupuestaria;
        }
        public virtual void Set(ProyectoEtapaInformacionPresupuestaria entity)
        {
            this.IdProyectoEtapaInformacionPresupuestaria = entity.IdProyectoEtapaInformacionPresupuestaria;
            this.IdProyectoEtapa = entity.IdProyectoEtapa;
            this.IdClasificacionGasto = entity.IdClasificacionGasto;
            this.IdFuenteFinanciamiento = entity.IdFuenteFinanciamiento;
            this.IdMoneda = entity.IdMoneda;

        }
        public virtual bool Equals(ProyectoEtapaInformacionPresupuestaria entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoEtapaInformacionPresupuestaria.Equals(this.IdProyectoEtapaInformacionPresupuestaria)) return false;
            if (!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa)) return false;
            if (!entity.IdClasificacionGasto.Equals(this.IdClasificacionGasto)) return false;
            if (!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento)) return false;
            if (!entity.IdMoneda.Equals(this.IdMoneda)) return false;

            return true;
        }
        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoEtapaInformacionPresupuestaria", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapa","ProyectoEtapa_Nombre")
			,new DataColumnMapping("ClasificacionGasto","ClasificacionGasto_Nombre")
			,new DataColumnMapping("FuenteFinanciamiento","FuenteFinanciamiento_Nombre")
			,new DataColumnMapping("Moneda","Moneda_Nombre")
			}));
        }
    }
}
