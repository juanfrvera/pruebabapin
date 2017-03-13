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

namespace Application.Test
{
    public partial class TestTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //treeOficina.ValueChanged += new EventHandler(treeOficina_ValueChanged);
        }

        void treeOficina_ValueChanged(object sender, EventArgs e)
        {
            //string s = treeOficina.ValueId.Value.ToString();
        }



    }
}
