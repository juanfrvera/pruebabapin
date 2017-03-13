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
using nc = Contract;
using ns = Service;
namespace UI.Web
{
    public partial class WebControlHeaderGeneral : System.Web.UI.UserControl  
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }      

        public String UserName 
        {
            set {UIHelper.SetValue(liUserName, value);}        
        }
        public String User
        {
            set{UIHelper.SetValue(liUser, value);}
        }

        protected void lnkStatistics_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Statistics.aspx", false);
        }

        protected virtual void Logout_Click(object sender, EventArgs e)
        {
            UIContext.Current.Logout();
            
        }
    }
}