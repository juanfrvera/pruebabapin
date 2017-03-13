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
    public partial class HeaderGeneral : System.Web.UI.UserControl  
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
            set{ UIHelper.SetValue(liUser, value);}
        } 
        protected virtual void Logout_Click(object sender, EventArgs e)
        {
            UIContext.Current.Logout();
            HttpContext.Current.Response.Redirect("~/Security/frmLogin.aspx", false);
        }
        protected virtual void Password_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Security/frmChangePassword.aspx", false);            
        }
        //Matias 20140114 - Tarea 106
        protected virtual void Logo_Click(object sender, EventArgs e)
        {
            //Parche para solucionar el BUG que al oprimir ejecuta el primer metodo de esta pagina! RARISIMO
        }
        //FinMatias 20140114 - Tarea 106
    }
}