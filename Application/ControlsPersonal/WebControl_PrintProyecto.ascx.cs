using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Contract;
using nc = Contract;
using System.Collections.Generic;
using Service;

namespace UI.Web
{
    public partial class WebControl_PrintProyecto : WebControlPopup
    {
        ProyectoPrintFilter filtro;
        public ProyectoPrintFilter Filtro
        {
            get {
                if (filtro == null)
                    if (ViewState["filtro"] != null)
                        filtro = ViewState["filtro"] as ProyectoPrintFilter;
                    else
                    {
                        filtro = new ProyectoPrintFilter();
                        ViewState["filtro"] = filtro;
                    }
                return filtro;
            }
            set {
                filtro = value;
                ViewState["filtro"] = value;
            }
        }

        #region Methods

        public override void HidePopup()
        {
            Clear();
            mpePopupImprimirReporte.Hide();
        }
        public override void ShowPopup()
        {
            Clear();
            chkSolapaGeneral.Checked = true;
            chkAlcanceGeografico.Checked = true;
            chkCronograma.Checked = true;
            //Matias 20170216 - Ticket #REQ792885
            chkIncluyeDatosSecundarios.Checked = true;
            chkObjetivos.Checked = true;
            chkIncluyeEvolucionDeIndicadoresObjetivos.Checked = true;
            chkProductoIntermedio.Checked = true;
            chkIncluyeDetalleDeEtapas.Checked = true;
            chkIncluyeDetallePorObjetoDelGastoYAnios.Checked = true;
            chkEvaluacion.Checked = true;
            chkIncluyeEvolucionDeIndicadoresEvaluacion.Checked = true;            
            chkIntervencionDNIP.Checked = true;
            chkAdjuntos.Checked = true;
            chkCalidad.Checked = false;
            //FinMatias 20170216 - Ticket #REQ792885
            
            upControls.Update();
            mpePopupImprimirReporte.Show();

            
        }
        public void Aceptar()
        {
            GetValue();
            RaiseControlCommand (Command.PRINT );
        }
        public void Exportar()
        {
            GetValue();
            RaiseControlCommand(Command.EXPORT);
        }
        protected void Clear()
        {
            UIHelper.Clear ( chkSolapaGeneral );
            UIHelper.Clear (chkIncluyeDatosSecundarios);
            UIHelper.Clear (chkAlcanceGeografico);
            UIHelper.Clear (chkObjetivos);
            UIHelper.Clear (chkIncluyeEvolucionDeIndicadoresObjetivos);
            UIHelper.Clear (chkProductoIntermedio);
            UIHelper.Clear (chkIncluyeDetalleDeEtapas);
            UIHelper.Clear (chkCronograma);
            UIHelper.Clear (chkIncluyeDetallePorObjetoDelGastoYAnios);
            UIHelper.Clear (chkEvaluacion);
            UIHelper.Clear (chkIncluyeEvolucionDeIndicadoresEvaluacion);
            UIHelper.Clear (chkIntervencionDNIP);
            UIHelper.Clear (chkAdjuntos );
            UIHelper.Clear(chkCalidad); //Matias 20170216 - Ticket #REQ792885
        }
        protected void GetValue()
        {
            Filtro.SolapaGeneral = UIHelper.GetBoolean( chkSolapaGeneral);
            Filtro.IncluyeDatosSecundarios = UIHelper.GetBoolean (chkIncluyeDatosSecundarios);
            Filtro.AlcanceGeografico = UIHelper.GetBoolean (chkAlcanceGeografico);
            Filtro.Objetivos = UIHelper.GetBoolean (chkObjetivos);
            Filtro.IncluyeEvolucionDeIndicadoresObjetivos= UIHelper.GetBoolean (chkIncluyeEvolucionDeIndicadoresObjetivos);
            Filtro.ProductoIntermedio = UIHelper.GetBoolean (chkProductoIntermedio);
            Filtro.IncluyeDetalleDeEtapas = UIHelper.GetBoolean (chkIncluyeDetalleDeEtapas);
            Filtro.Cronograma=UIHelper.GetBoolean (chkCronograma);
            Filtro.IncluyeDetallePorObjetoDelGastoYAnios = UIHelper.GetBoolean (chkIncluyeDetallePorObjetoDelGastoYAnios);
            Filtro.Evaluacion=UIHelper.GetBoolean (chkEvaluacion);
            Filtro.IncluyeEvolucionDeIndicadoresEvaluacion= UIHelper.GetBoolean (chkIncluyeEvolucionDeIndicadoresEvaluacion);
            Filtro.IntervencionDNIP= UIHelper.GetBoolean (chkIntervencionDNIP);
            Filtro.Adjuntos  = UIHelper.GetBoolean (chkAdjuntos );
            Filtro.IdProyecto = Int32.Parse(CommandValue);
            Filtro.Calidad = UIHelper.GetBoolean(chkCalidad); //Matias 20170216 - Ticket #REQ792885            
        }
        #endregion

        #region Events

        protected void btImprimir_Click(object sender, EventArgs e)
        {
            Aceptar();
            HidePopup();
        }

        protected void btExportar_Click(object sender, EventArgs e)
        {
            Exportar();
            HidePopup();

        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion




    }
}


