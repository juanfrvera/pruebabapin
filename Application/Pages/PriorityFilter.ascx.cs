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
    public partial class PriorityFilter : WebControlFilter<nc.PriorityFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revImg.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revImg.ErrorMessage = TranslateFormat("InvalidField", "Imagen");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtImg);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
				UIHelper.SetValueFilter(txtImg, Filter.Img);
							
        }	
        protected override void GetValue()
        {
            Filter.Name = UIHelper.GetStringBetweenFilter(txtName);
            Filter.Img = UIHelper.GetStringBetweenFilter(txtImg);

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
