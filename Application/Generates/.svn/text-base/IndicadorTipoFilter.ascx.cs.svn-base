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
    public partial class IndicadorTipoFilter : WebControlFilter<nc.IndicadorTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(20);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(chkActivo);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
				
        }
		//protected void btSearch_Click(object sender, EventArgs e)
        //{
        //    RaiseControlCommand(Command.SEARCH);
        //}
    }
}
