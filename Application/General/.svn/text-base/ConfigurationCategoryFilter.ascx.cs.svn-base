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
    public partial class ConfigurationCategoryFilter : WebControlFilter<nc.ConfigurationCategoryFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
					
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
					
        }	
        protected override void GetValue()
        {
            Filter.Name = UIHelper.GetStringBetweenFilter(txtName);

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
