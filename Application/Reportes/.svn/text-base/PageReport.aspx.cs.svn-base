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
using Service;
using Contract;

namespace UI.Web
{
    public partial class PageReport : PageBase 
    {  
        protected override void _Load()
        {
            ucReport.ControlCommand += new ControlCommandHandler(ControlCommand);  
        }
        #region Commands
        protected override void ControlCommand(object sender, string name, object value)
        {
            base.ControlCommand(sender, name, value);
            try
            {
                switch (CommandName)
                {
                    case Command.SHOW_REPORT:
                    case Command.PRINT :
                        CommandShowReport();
                        break;
                    //case Command.CANCEL:
                    //    CommandCancel();
                    //    break;
                }
            }
            catch (Exception exception)
            {
                this.Manage(exception);
            }
        }
        protected void CommandShowReport()
        {
            ReportInfo reportInfo = CommandValue as ReportInfo;
            if (reportInfo == null) return;
            ucReport.ReportInfo = reportInfo;
            ucReport.ShowReport();
        }
        //protected void CommandCancel()
        //{
        //    ScriptManager.RegisterStartupScript(this,typeof (string) ,  "close", "windows.close()", true); 
        //}
        #endregion

    }
}
