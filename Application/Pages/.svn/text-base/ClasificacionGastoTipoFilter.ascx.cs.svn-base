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
    public partial class ClasificacionGastoTipoFilter : WebControlFilter<nc.ClasificacionGastoTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revNivel.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revNivel.ErrorMessage = TranslateFormat("InvalidField", "Nivel");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
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
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Nivel=UIHelper.GetIntNullable(txtNivel);

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
