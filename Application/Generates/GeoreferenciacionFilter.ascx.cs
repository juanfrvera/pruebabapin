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
    public partial class GeoreferenciacionFilter : WebControlFilter<nc.GeoreferenciacionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revTipo.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			  revTipo.ErrorMessage = TranslateFormat("InvalidField", "Tipo");	
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtTipo);
			txtTipo.Focus();
					
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue(txtTipo, Filter.IdGeoreferenciacionTipo);
						txtTipo.Focus();
					
        }	
        protected override void GetValue()
        {
            Filter.IdGeoreferenciacionTipo = UIHelper.GetIntNullable(txtTipo);
				
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
