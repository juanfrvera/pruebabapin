using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Service;
using Contract;
using UI.Web;

namespace Application
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Global));
        protected void Application_Start(object sender, EventArgs e)
        {
            //log4net.Config.XmlConfigurator.Configure();
            Log.Info("Startup application.");
            UIContext.Current.LoadManagers();
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //UIContext.Current.LoadManagers();
            //decimal maxFileSize = SolutionContext.Current.RequestMaxLength;
            //if (Request.ContentLength > maxFileSize)
            //{
            //    string url = "~" + Request.Url.PathAndQuery + (Request.Url.PathAndQuery.Contains("?") ? "&" : "?") + PageBase.PARAMETER_ACTION + "=" + Command.SHOW_ERROR + "&" + PageBase.PARAMETER_VALUE + "=" + "ERROR_REQUEST_SIZE_OVERFLOW";
            //    HttpContext.Current.Response.Redirect(url);
            //}
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
         
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Redirect("~/frmError.aspx");
        }
        protected void Session_End(object sender, EventArgs e)
        {
            UIContext.Current.UnRegisterUser(AuditMandateEnum.TimeOut, "");
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}