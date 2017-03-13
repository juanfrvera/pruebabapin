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
    public partial class WebControl_ThreeStatesCheckbox : WebControlBase, UI.Web.IWebControl_ThreeStatesCheckbox
    {

        protected override void _Initialize()
        {
            TagCheckedFalse = "No";
            TagCheckedTrue = "Si";
            TagOff = "Todos";
            CheckedValue = null;
            base._Initialize();
        }



        #region Propiedades        
        public Boolean? CheckedValue
        {
            get
            {
                Boolean? retval = null;

                if (rbOff.Checked)
                    retval = null;
                else if (rbCheckedTrue.Checked)
                    retval = true;
                else if (rbCheckedFalse.Checked)
                    retval = false;

                return retval;
            }
            set
            {
                rbOff.Checked = value == null;
                rbCheckedFalse.Checked = value != null && !(bool)value;
                rbCheckedTrue.Checked = value != null && (bool)value;
            }
        }
        public string TagOff
        {
            set { rbOff.Text = value; }
        }
        public string TagCheckedTrue
        {
            set { rbCheckedTrue.Text = value; }
        }
        public string TagCheckedFalse
        {
            set { rbCheckedFalse.Text = value; }
        }
        public TextAlign TextAlign
        {
            set 
            { 
                rbOff.TextAlign = value;
                rbCheckedFalse.TextAlign = value;
                rbCheckedTrue.TextAlign = value; 
            }
        }
        public bool ShowOffOption
        {
            set
            {
                rbOff.Visible = value;
            }
        }
        public string ValidationGroup
        {
            set
            {
                rbOff.ValidationGroup = value;
                rbCheckedFalse.ValidationGroup = value;
                rbCheckedTrue.ValidationGroup = value; 
            }
        }

        public bool Enable
        {
            set
            {
                rbOff.Enabled = value;
                rbCheckedFalse.Enabled = value;
                rbCheckedTrue.Enabled = value;
            }
        }


        

        public string CssClass
        {
            set 
            {
                rbOff.CssClass = value;
                rbCheckedFalse.CssClass = value;
                rbCheckedTrue.CssClass = value; 
            }
        }
        #endregion
    }
}