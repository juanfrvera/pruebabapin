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
    public partial class EstadoTipoFilter : WebControlFilter<nc.EstadoTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			
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
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
