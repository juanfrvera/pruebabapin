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
using Service;
using System.Collections.Generic;
//http://localhost:59231/Test/TestReport.aspx
namespace Application.Test
{
    public partial class TestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            rpTest.ReportInfo = ProyectoService.Current.GetReport("Test",1676);
            rpTest.ShowReport();
        }
    }
}
