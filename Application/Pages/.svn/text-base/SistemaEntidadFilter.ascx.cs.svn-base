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
    public partial class SistemaEntidadFilter : WebControlFilter<nc.SistemaEntidadFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntidadClase.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revEntidadClaseBase.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revEntidadClase.ErrorMessage = TranslateFormat("InvalidField", "Entidad Clase");
            revEntidadClaseBase.ErrorMessage = TranslateFormat("InvalidField", "Entidad Clase Base");

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtEntidadClase);
			UIHelper.Clear(txtEntidadClaseBase);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(chkIncluirSeguridad);
            UIHelper.Clear(chkIncluirConfiguracion);				
        }		
		protected override void SetValue()
        {
            UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
            txtCodigo.Focus();
            UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
            UIHelper.SetValueFilter(txtEntidadClase, Filter.EntidadClase);
            UIHelper.SetValueFilter(txtEntidadClaseBase, Filter.EntidadClaseBase);
            UIHelper.SetValue(chkActivo, Filter.Activo);
            UIHelper.SetValue(chkIncluirSeguridad, Filter.IncluirSeguridad);
            UIHelper.SetValue(chkIncluirConfiguracion, Filter.IncluirConfiguracion);							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
            Filter.EntidadClase = UIHelper.GetStringBetweenFilter(txtEntidadClase);
            Filter.EntidadClaseBase = UIHelper.GetStringBetweenFilter(txtEntidadClaseBase);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            Filter.IncluirSeguridad = UIHelper.GetBooleanNullable(chkIncluirSeguridad);
            Filter.IncluirConfiguracion = UIHelper.GetBooleanNullable(chkIncluirConfiguracion);
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
