﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect(System.Web.Security.FormsAuthentication.LoginUrl, false);
        }
    }
}
