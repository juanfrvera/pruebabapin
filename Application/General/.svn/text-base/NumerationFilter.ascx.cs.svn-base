using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class NumerationFilter : WebControlFilter<nc.NumerationFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revLastvalue.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revLastvalue.ErrorMessage = TranslateFormat("InvalidField", "Último Valor");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCode);
			txtCode.Focus();
				UIHelper.Clear(txtLastvalue);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCode, Filter.Code);
						txtCode.Focus();
				UIHelper.SetValue(txtLastvalue, Filter.Lastvalue);
							
        }	
        protected override void GetValue()
        {
            Filter.Code = UIHelper.GetStringBetweenFilter(txtCode);
			Filter.Lastvalue=UIHelper.GetIntNullable(txtLastvalue);

        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
