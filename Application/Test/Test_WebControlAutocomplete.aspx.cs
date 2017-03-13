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
using Contract;

namespace UI.Web
{
    public partial class Test_WebControlAutocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (wcAutocomplete1.IsSelectionItemPostBack)
                {
                    SimpleResult<int?> resu = wcAutocomplete1.SelecttedValue;
                }

                if (wcAutocomplete2.IsSelectionItemPostBack)
                {
                    SimpleResult<int?> resu2 = wcAutocomplete2.SelecttedValue;
                }
            }
            else
            {
                this.mensaje.Text = "";
                wcAutocomplete1.ValueId = 33;
                wcAutocomplete1.ValueText = "Texto Texto";
            }



            wcAutocomplete1.WebServiceName = "~/Services/WebServiceMedio.asmx";
            wcAutocomplete1.ServiceMethod = "GetMedios";
            wcAutocomplete1.AutoPostback = true;
            wcAutocomplete1.ValueChanged += new EventHandler(this.AutocompletePostBack);
            wcAutocomplete1.Tag = "WC1 in 3";            

            wcAutocomplete2.WebServiceName = "~/Services/WebServiceMedio.asmx";
            wcAutocomplete2.ServiceMethod = "GetMedios";
            wcAutocomplete2.AutoPostback = true;
            wcAutocomplete2.ValueChanged += new EventHandler(this.AutocompletePostBack);
            wcAutocomplete2.MinimumPrefixLength = 1;
            wcAutocomplete2.Tag = "WC2 in 1";
            wcAutocomplete2.ClearControl += new EventHandler(this.ClearControl);
            wcAutocomplete2.ShowClearButton = true;
        }

        private void AutocompletePostBack(object sender, EventArgs e)
        {
            this.mensaje.Text = "Se seleccionó " +
                                ((wcAutocomplete1.IsSelectionItemPostBack) ? wcAutocomplete1.SelecttedValue.Text :
                                 (wcAutocomplete2.IsSelectionItemPostBack) ? wcAutocomplete2.SelecttedValue.Text : "");
        }
        private void ClearControl(object sender, EventArgs e)
        {
            wcAutocomplete1.Clear();
        }
    }
}
