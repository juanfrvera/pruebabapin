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
    public partial class AdministracionTipoFilter : WebControlFilter<nc.AdministracionTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(4);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.Codigo =UIHelper.GetStringFilter(txtCodigo);
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
