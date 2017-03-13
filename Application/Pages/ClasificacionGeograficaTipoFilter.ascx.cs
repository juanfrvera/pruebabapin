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
    public partial class ClasificacionGeograficaTipoFilter : WebControlFilter<nc.ClasificacionGeograficaTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
	        revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();			
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
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
