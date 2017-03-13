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
    public partial class HeaderWihtoutLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btContact_OnClick(object sender, EventArgs e)
        {
            ExecuteCommand("~/Pages/ContactoPageEdit.aspx", Command.ADD_NEW);
        }
        protected void btRegistracion_OnClick(object sender, EventArgs e)
        {
            ExecuteCommand("~/Pages/RegistracionPage.aspx", Command.ADD_NEW);
        }
        
        #region Base
        public const string PARAMETER_ACTION = "Action";
        public const string PARAMETER_VALUE = "Value";
        public const string PARAMETER_FILTER = "Filter";
        public const string PARAMETER_TABINDEX = "TabIndex";
        protected virtual void ExecuteCommand(string pathPage, string command)
        {
            ExecuteCommand(pathPage, command, null);
        }
        protected virtual void ExecuteCommand(string pathPage, string command, string CommandValue)
        {
            SetParameter(pathPage, PARAMETER_ACTION, command);
            if (CommandValue != null) SetParameter(pathPage, PARAMETER_VALUE, CommandValue);
            Response.Redirect(pathPage, false);
        }
        protected string PageName
        {
            get { return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath); }
        }
        public void SetParameter(string parameter, object value)
        {
            SetParameter(PageName, parameter, value);
        }
        public void SetParameter(string page, string parameter, object value)
        {
            UIContext.Current.SetValue(System.IO.Path.GetFileName(page), parameter, value);
        }
        #endregion
    }
}