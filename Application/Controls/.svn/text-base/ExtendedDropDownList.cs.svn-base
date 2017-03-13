using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;

namespace UI.Web
{

    public class ExtendedDropDownList: DropDownList
    {
        #region Properties
        public string Tag
        {
            get
            {
                object o = ViewState["Tag"];
                if ((o == null))return "";
                return (string)o;
            }
            set
            {
                ViewState["Tag"] = value;
            }
        }
        public string DataInactiveSelected
        {
            get
            {                
                object o = ViewState["InactiveSelected"];
                if ((o == null)) return "";
                return (string)o;
            }
            set
            {
                ViewState["InactiveSelected"] = value;
            }
        }
        public override short TabIndex
        {
            set { base.TabIndex = value; }
            get { return base.TabIndex; }
        }

        #endregion

                    



    }
}
