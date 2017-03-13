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
    public partial class SistemaAccionFilter : WebControlFilter<nc.SistemaAccionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNombre.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "C�digo");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
            txtCodigo.Focus();
			UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(chkIncluirEstado);				
        }		
		protected override void SetValue()
        { 
            UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
			txtCodigo.Focus();
			UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
			UIHelper.SetValue(chkActivo, Filter.Activo);
            UIHelper.SetValue(chkIncluirEstado, Filter.IncluirEstado);							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            Filter.IncluirEstado = UIHelper.GetBooleanNullable(chkIncluirEstado);	
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
