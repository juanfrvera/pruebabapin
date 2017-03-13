using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public partial class WebControlListButtons : WebControlBase, IListButtons
    {        
        public bool EnableAddNew
        {
            get { return this.btAddNew.Enabled; }
            set { this.btAddNew.Enabled = value; }
        }
        protected virtual void btAddNew_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.ADD_NEW);
        }

        public string ValidationGroup
        {
            get
            {
                return "";
            }
            set
            {                
            }
        }
                
    }
}