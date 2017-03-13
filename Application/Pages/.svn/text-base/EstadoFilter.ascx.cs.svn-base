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
    public partial class EstadoFilter : WebControlFilter<nc.EstadoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revDescripcion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revDescripcion.ErrorMessage = TranslateFormat("InvalidField", "Descripción");


            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
			UIHelper.Clear(txtOrden);
			UIHelper.Clear(txtDescripcion);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(txtOrden, Filter.Orden);
						UIHelper.SetValueFilter(txtDescripcion, Filter.Descripcion);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Orden=UIHelper.GetIntNullable(txtOrden);
            Filter.Descripcion = UIHelper.GetStringBetweenFilter(txtDescripcion);
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
