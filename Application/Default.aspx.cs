using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class _Default : PageBase
    {
        protected override void _Initialize()
        {
            lbMsjBienvenida.Text = Translate("MsgWelcome");
        }
    }
}
