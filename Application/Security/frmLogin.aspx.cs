using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Service;
using nc=Contract;
using System.IO;

namespace UI.Web
{
    public partial class frmLogin : PageBase
    {
        protected override void _Initialize()
        {            
            base._Initialize();
            UIContext.Current.Logout();
        }
        protected override void _Load()
        {
            UIHelper.Clear(lblMessage);
            base._Load();
            this.txtUserName.Focus();
        }
        protected void btLogin_Click(object sender, EventArgs e)
        {
           try
            {
                string userName = UIHelper.GetString(txtUserName);
                string password = UIHelper.GetString(txtPassword);

                UIContext.Current.Login(userName, password);
                
                //FormsAuthentication.SetAuthCookie(userName, false);

                bool isPersistent = false;
                string userData = "App Specific data for this user";
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                                        1,
                                                        userName,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes((int)Contract.SolutionContext.Current.ParameterManager.GetNumberValue("USER_SESSION_TIMEOUT")),
                                                        isPersistent,
                                                        userData,
                                                        FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

               Response.Redirect("Default.aspx"); 
            }            
            catch (Exception exception)
            {
                UIHelper.SetValue(lblMessage, exception.Message);
            }
        }        
    }
}
