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

namespace Application.Test
{
    public partial class Test_WebControlNumericRange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wcNumericRangeInput.TagFrom = "De";
            wcNumericRangeInput.TagTo = "A";

            wcNumericRangeInput.ErrorMessageNumericFrom = "solo numeros";
            wcNumericRangeInput.ErrorMessageNumericTo = "solo numeros (.,)";
            wcNumericRangeInput.ErrorMessageRequiredFrom = "obli";
            wcNumericRangeInput.ErrorMessageRequiredTo = "gatorio";
            wcNumericRangeInput.ErrorMessageValidator = " mal <>!!!";

            wcNumericRangeInput.RequiredFrom = true;
            wcNumericRangeInput.RequiredTo = true;

            if (!this.IsPostBack)
            {
                wcNumericRangeInput.ValueFrom = 50;
                wcNumericRangeInput.ValueTo = 51;
            }
            else
            {
                decimal? de = wcNumericRangeInput.ValueFrom;
                decimal? a = wcNumericRangeInput.ValueTo;
            }
        }
    }
}
