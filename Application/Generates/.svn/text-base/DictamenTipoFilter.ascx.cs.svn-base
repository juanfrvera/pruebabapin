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
    public partial class DictamenTipoFilter : WebControlFilter<nc.DictamenTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revNivel.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(txtNivel);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(txtNivel, Filter.Nivel);
							
        }	
        protected override void GetValue()
        {
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.Nivel=UIHelper.GetIntNullable(txtNivel);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
