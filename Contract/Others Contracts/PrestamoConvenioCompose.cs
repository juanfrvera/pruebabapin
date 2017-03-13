using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
   [Serializable]
    public class PrestamoConvenioCompose
    {
        public PrestamoResult Prestamo { get; set; }
        public Int32 IdPrestamo
        {
            get { return Prestamo != null ? Prestamo.IdPrestamo : 0; }
        }

       private PrestamoConvenioResult convenio;
       private List<PrestamoSubConvenioResult> subConvenios;

       public List<PrestamoFinanciamientoResult> Financiamientos = new List<PrestamoFinanciamientoResult>(); //Matias 20140428 - Tarea 140
       public List<PrestamoDesembolsoResult> Desembolsos = new List<PrestamoDesembolsoResult>(); //Matias 20140428 - Tarea 141

       #region Properties
       public PrestamoConvenioResult Convenio
        {
           get {
               if (convenio == null) convenio = new PrestamoConvenioResult();
               return convenio;
           }
            set { convenio = value; }
        }
       public List<PrestamoSubConvenioResult> SubConvenios
        {
            get
            {
                if (subConvenios == null) subConvenios = new List<PrestamoSubConvenioResult>();
                return subConvenios;
            }
            set { subConvenios = value; }
        }
       #endregion

       

    }
   
}
