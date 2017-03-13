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
    public partial class ProyectoTipoFilter : WebControlFilter<nc.ProyectoTipoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);

            chkActivo.CheckedValue = true;
            ddlTipo.Items.Add("Seleccione Tipo");
            ddlTipo.Items.Add("I");
            ddlTipo.Items.Add("T");
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
			UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
            ddlTipo.SelectedIndex = 0;
				
        }		
		protected override void SetValue()
        {   UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
			txtSigla.Focus();
			UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
			UIHelper.SetValue(chkActivo, Filter.Activo);
            if (Filter.Tipo != "")
            {
                UIHelper.SetValue(ddlTipo, Filter.Tipo);
            }
            else
            {
                ddlTipo.SelectedIndex = 0;
            }
        }	
        protected override void GetValue()
        {
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            if (ddlTipo.SelectedIndex != 0)
            {
                Filter.Tipo = UIHelper.GetString(ddlTipo);
            }
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
