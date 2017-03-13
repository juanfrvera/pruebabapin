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

namespace UI.Web
{
    public partial class Test_WebControlThreeStatesCheckbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wcThreeStatesCheckbox.TagOff = "Todos";
            wcThreeStatesCheckbox.TagCheckedTrue = "Encendidos";
            wcThreeStatesCheckbox.TagCheckedFalse = "Apagados";

            if (!this.IsPostBack)
            {
                wcThreeStatesCheckbox.ShowOffOption = true;
                wcThreeStatesCheckbox.CheckedValue = false;
                wcThreeStatesCheckbox.TextAlign = TextAlign.Right;
            }
            else
            {
                mensaje.Text = wcThreeStatesCheckbox.CheckedValue == null? "Is Null" : wcThreeStatesCheckbox.CheckedValue.ToString();
            }
        }
    }
}
