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
    public partial class MonedaFilter : WebControlFilter<nc.MonedaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(5);
            revNombre.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(20);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
			UIHelper.Clear(chkBase);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
						txtSigla.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
						UIHelper.SetValue(chkBase, Filter.Base);
							
        }	
        protected override void GetValue()
        {
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.Base=UIHelper.GetBooleanNullable(chkBase);

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
