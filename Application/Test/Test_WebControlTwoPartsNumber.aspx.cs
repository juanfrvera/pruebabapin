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
    public partial class Test_WebControlTwoPartsNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wcTwoPartsNumber.Complete = true;
            wcTwoPartsNumber.Focus();


            if (this.IsPostBack)
            {
                mensaje.Text = wcTwoPartsNumber.Value + " ||| " + wcTwoPartsNumber2.Value;
            }            
        }
    }
}
