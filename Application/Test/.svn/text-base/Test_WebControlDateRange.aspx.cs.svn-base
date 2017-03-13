using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;

namespace UI.Web
{
    public partial class TestNewControlDateRange : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wcDateRangeInput.TagFrom = "Desde";
            wcDateRangeInput.TagTo = "Hasta";
            wcDateRangeInput.ErrorMessageValidator = "Mal rango de fechas!";            

            if (!this.IsPostBack)
            {
                //wcDateRangeInput.ValueFrom = DateTime.Now.AddDays(-5);
                //wcDateRangeInput.ValueTo = DateTime.Now;
                //wcDateRangeInput.Clear();
            }
            else
            {
                DateTime? desde = wcDateRangeInput.ValueFrom;
                DateTime? hasta = wcDateRangeInput.ValueTo;
            }
        }
        
    }
}
