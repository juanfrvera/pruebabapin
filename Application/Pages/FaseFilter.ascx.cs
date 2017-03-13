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
    public partial class FaseFilter : WebControlFilter<nc.FaseFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");

            chkActivo.CheckedValue = true;
        }
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtOrden);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(txtOrden, Filter.Orden);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Orden=UIHelper.GetIntNullable(txtOrden);
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
