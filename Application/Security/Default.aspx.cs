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
using Service;
using nc = Contract;

namespace UI.Web.Security
{
    public partial class Default : System.Web.UI.Page
    {
        string redirectPageInitial;
        public string RedirectPageInitial
        {
            get
            {
                if (redirectPageInitial == null)
                    redirectPageInitial = "../General/MessageSendPageList.aspx";
                return redirectPageInitial;
            }
            set
            {
                redirectPageInitial = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                redirectPageInitial = "../General/MessageSendPageList.aspx";
                var result = MessageSendService.Current.GetResult(new nc.MessageSendFilter() { IsRead = false, IdUserTo = UIContext.Current.ContextUser.User.ID }).ToList();
                if (result.Count <= 0)
                    redirectPageInitial = "../Proyecto/ProyectoPageList.aspx";
            }
        }
    }
}
