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
    public partial class ParameterCategoryFilter : WebControlFilter<nc.ParameterCategoryFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtDescription);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
				UIHelper.SetValueFilter(txtDescription, Filter.Description);
							
        }	
        protected override void GetValue()
        {
            Filter.Name = UIHelper.GetStringBetweenFilter(txtName);
            Filter.Description = UIHelper.GetStringBetweenFilter(txtDescription);

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
