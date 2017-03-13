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
using System.IO;


namespace UI.Web
{
    public abstract partial class WebControl_ReportBase : WebControlBase
    {
        #region Properties
        public ReportInfo ReportInfo { get; set; }
        #endregion

        protected ReportViewer ReportViewer { get; set; } 
        
        #region Overrides
        protected override void _Initialize()
        {
            base._Initialize();
            ReportViewer.Reset();
        }
        public virtual void ShowReport()
        {
            ReportViewerManager.Setvalue(ReportViewer, ReportInfo);
        }
        public virtual void PrintReport()
        {
            ReportViewerManager.Setvalue(ReportViewer, ReportInfo);
            ReportViewerManager.SaveReportExcel (ReportInfo);
        }

        #endregion

        #region Events
        protected void btCancel_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CANCEL);
        }
        #endregion

    }

    public partial class WebControl_Report : WebControl_ReportBase
    {
        protected override void _SetControls()
        {
            base._SetControls();
            this.ReportViewer = reportView;
        }

    }
}