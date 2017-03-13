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
    public partial class ProgramaFilter : WebControlFilter<nc.ProgramaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();

            if (UIContext.Current.ContextUser.User.AccesoTotal)
                UIHelper.Load<SafResult>(ddlSAF, SafService.Current.GetResultFromList(new nc.SafFilter()), "CodigoDenominacion", "IdSaf", new nc.SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" });
            else
                UIHelper.Load<SafResult>(ddlSAF, SafService.Current.GetResultFromList(new nc.SafFilter { IdUsusario = UIContext.Current.ContextUser.User.ID }), "CodigoDenominacion", "IdSaf", new nc.SafResult() { IdSaf = 0,Codigo="", Denominacion = "Seleccione Saf" });
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(255);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            UIHelper.Load<UsuarioResult>(ddlSectorialista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Sectorialista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            
            chkActivo.CheckedValue = true;
        }
		protected override void Clear()
        {			
			UIHelper.Clear(ddlSAF);
			ddlSAF.Focus();
				UIHelper.Clear(txtCodigo);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(rdFechaAlta);
			UIHelper.Clear(rdFechaBaja);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(ddlSectorialista);	
        }		
		protected override void SetValue()
        {ddlSAF.Focus();
				UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
                UIHelper.SetValue(ddlSAF, Filter.IdSAF);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
				UIHelper.SetValue<DateTime?>(rdFechaAlta, Filter.FechaAlta, Filter.FechaAlta_To);
				UIHelper.SetValue<DateTime?>(rdFechaBaja, Filter.FechaBaja, Filter.FechaBaja_To);
				UIHelper.SetValue(chkActivo, Filter.Activo);
                UIHelper.SetValue(ddlSectorialista, Filter.IdSectorialista);				
        }	
        protected override void GetValue()
        {

            if (!UIContext.Current.ContextUser.User.AccesoTotal)
                Filter.IdUsuarioSaf = UIContext.Current.ContextUser.User.ID;
            else
                Filter.IdUsuarioSaf = 0;
			Filter.IdSAF =UIHelper.GetIntNullable(ddlSAF);
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.FechaAlta =UIHelper.GetValueFromDate(rdFechaAlta);
            Filter.FechaAlta_To = UIHelper.GetValueToDate(rdFechaAlta);
			Filter.FechaBaja =UIHelper.GetValueFromDate(rdFechaBaja);
            Filter.FechaBaja_To = UIHelper.GetValueToDate(rdFechaBaja);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            Filter.IdSectorialista = UIHelper.GetIntNullable(ddlSectorialista);

        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
