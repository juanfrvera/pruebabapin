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
    public partial class WebControl_PrintPrestamo: WebControlPopup
    {
        
        PrestamoReportInfo reportInfo;
        public PrestamoReportInfo  ReportInfo
        {
            get {
                if (reportInfo == null)
                    if (ViewState["reportInfo"] != null)
                        reportInfo = ViewState["reportInfo"] as PrestamoReportInfo;
                    else
                    {
                        reportInfo = new PrestamoReportInfo();
                        ViewState["reportInfo"] = reportInfo;
                    }
                return reportInfo;
            }
            set {
                reportInfo = value;
                ViewState["reportInfo"] = value;
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
            chkConvenio.Checked = true;
            chkComponentes.Checked = true;
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
            UIHelper.Clear (chkSolapaGeneral );
            UIHelper.Clear (chkAlcanceGeografico);
            UIHelper.Clear (chkObjetivos);
            UIHelper.Clear (chkIncluyeEvolucionDeIndicadoresObjetivos);
            UIHelper.Clear (chkConvenio);
            UIHelper.Clear (chkComponentes);
            UIHelper.Clear (chkProducto);
            UIHelper.Clear (chkIncluyeDetalleDeEtapas);
            UIHelper.Clear (chkIntervencionDNIP);
            UIHelper.Clear (chkAdjuntos );
        }
        protected void GetValue()
        {
            ReportInfo.SolapaGeneral = UIHelper.GetBoolean(chkSolapaGeneral);
            ReportInfo.AlcanceGeografico = UIHelper.GetBoolean(chkAlcanceGeografico);
            ReportInfo.Objetivos = UIHelper.GetBoolean(chkObjetivos);
            ReportInfo.IncluyeEvolucionDeIndicadoresObjetivos = UIHelper.GetBoolean(chkIncluyeEvolucionDeIndicadoresObjetivos);
            ReportInfo.Convenio = UIHelper.GetBoolean(chkConvenio);
            ReportInfo.Componente = UIHelper.GetBoolean(chkComponentes);
            ReportInfo.Producto= UIHelper.GetBoolean(chkProducto);
            ReportInfo.IntervencionDNIP = UIHelper.GetBoolean(chkIntervencionDNIP);
            ReportInfo.Adjuntos = UIHelper.GetBoolean(chkAdjuntos);
            ReportInfo.IdPrestamo= Int32.Parse(CommandValue);
            
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


