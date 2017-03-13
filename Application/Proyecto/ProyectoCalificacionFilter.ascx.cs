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
    public partial class ProyectoCalificacionFilter : WebControlFilter<nc.ProyectoCalificacionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);

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
