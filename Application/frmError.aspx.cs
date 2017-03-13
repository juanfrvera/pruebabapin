using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Service;

namespace UI.Web
{
    public partial class frmError : PageBase
    {
        protected override void _Initialize()
        {
            base._Initialize();           

            if (Parameters.ContainsKey(UIContext.Current.PARAMETER_ERROR_MESSAGE) != false)
                UIHelper.SetValue(MessageLabel, Parameters[UIContext.Current.PARAMETER_ERROR_MESSAGE].ToString());
            else
                UIHelper.SetValue(MessageLabel, Translate("SystemError"));                    
        }
        protected virtual void btOk_Click(object sender, EventArgs e)
        {
            UIContext.Current.UnRegisterUser(); 
            Response.Redirect("~/Security/frmLogin.aspx",false);

            
        }
    }
}
