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
    public partial class PrioridadFilter : WebControlFilter<nc.PrioridadFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(10);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
	//		revPuntaje.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
     //       revPuntaje.ErrorMessage = TranslateFormat("InvalidField", "Puntaje");

            chkActivo.CheckedValue = true;
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtOrden);
	//		UIHelper.Clear(txtPuntaje);
			UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
						txtSigla.Focus();
				UIHelper.SetValue(txtOrden, Filter.Orden);
						UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
			Filter.Orden=UIHelper.GetIntNullable(txtOrden);
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
