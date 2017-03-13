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
    public partial class LanguageFilter : WebControlFilter<nc.LanguageFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(10);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtCode);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
				UIHelper.SetValueFilter(txtCode, Filter.Code);
							
        }	
        protected override void GetValue()
        {
			Filter.Name =UIHelper.GetStringFilter(txtName);
			Filter.Code =UIHelper.GetStringFilter(txtCode);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
