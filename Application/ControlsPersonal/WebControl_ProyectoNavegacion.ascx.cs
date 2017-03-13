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
using UI.Web;
using nc=Contract;

namespace UI.Web
{
    public partial class WebControl_ProyectoNavegacion : WebControlPageTabPanel<nc.ProyectoResult,nc.ProyectoFilter,int>
    {        
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            RaiseControlCommand(Command.CONFIRM_CHANGE_PAGE, e.CommandArgument);
        }
    }
}