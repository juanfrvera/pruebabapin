using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class PrestamoComponenteCompose
    {
        public PrestamoResult Prestamo { get; set; }
        public Int32 IdPrestamo
        {
            get { return Prestamo != null ? Prestamo.IdPrestamo : 0; }
        }
        public List<PrestamoObjetivoComponenteCompose> Componentes = new List<PrestamoObjetivoComponenteCompose>();
        public List<PrestamoSubComponenteResult> Subcomponentes = new List<PrestamoSubComponenteResult>();
        public List<PrestamoFinanciamientoResult> Financiamientos = new List<PrestamoFinanciamientoResult>();
        public List<PrestamoDesembolsoResult> Desembolsos = new List<PrestamoDesembolsoResult>();
        public PrestamoConvenioResult Convenio = new PrestamoConvenioResult();


        public decimal GetPorcentajeConvenio(decimal monto)
        {
            decimal porcentaje = 0;

            if (this.Convenio != null && this.Convenio.IdPrestamoConvenio > 0 && this.Convenio.MontoTotal > 0)
                //Matias 20140319 - Tarea 127
                porcentaje = (monto * 100) / this.Convenio.MontoPrestamo; /*this.Convenio.MontoTotal;*/
                //FinMatias 20140319 - Tarea 127

            return porcentaje;
        }

        public bool ValidoMontoTotal()
        {
            decimal total = 0;
            foreach (PrestamoFinanciamientoResult f in this.Financiamientos)
                total += f.Monto;
            return (this.Convenio == null && total == 0) || (this.Convenio != null && this.Convenio.MontoTotal >= total);
        }
    }

    [Serializable]
    public class PrestamoObjetivoComponenteCompose : ObjetivoCompose
    {
        private PrestamoComponenteResult componente;
        public PrestamoComponenteResult Componente 
        {
            get 
            { 
                if(componente ==null)
                    componente = new PrestamoComponenteResult();
                return componente;
            }
            set { componente = value;}
        }

        public Int32 ID
        {
            get { return Componente.ID; }
        }
        public string Descripcion
        {
            get
            {
                return Componente.Objetivo_Nombre;
            }
        }
        public decimal Monto {get;set;}
        public string Orden
        {
            get 
            {
                return Componente.Objetivo_Nombre;
            }
        }
    }
}
