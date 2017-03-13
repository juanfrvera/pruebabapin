using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ReportingServices.ReportRendering;
using Microsoft.Reporting.WebForms;
using rwf=Microsoft.Reporting.WebForms;
using Contract;


namespace UI.Web
{
    public partial class WebControl_ReportPopup : WebControl_ReportBase
    {
        protected override void _SetControls()
        {
            base._SetControls();
            this.ReportViewer = reportView;
        }
        #region public
        public void Show()
        {
            if (mpeWindow != null && ReportInfo!=null)
            {
                lblTitulo.Text = ReportInfo.Title;
                upDatos.Update();
                mpeWindow.Show();
                this.ShowReport();
            }
        }
        public void Hide()
        {
            if (mpeWindow != null)
                mpeWindow.Hide();
        }
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set {lblTitulo.Text = value;}
        }
        public void SetDisplayNone()
        {
            this.PanelPopupAcciones.Attributes.CssStyle.Add("display", "none");
        }
        #endregion
    }
}