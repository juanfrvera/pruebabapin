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
    public partial class CaracterEconomicoFilter : WebControlFilter<nc.CaracterEconomicoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toCaracterEconomicoPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.CaracterEconomicoTipo>(ddlCaracterEconomicoTipo, CaracterEconomicoTipoService.Current.GetList(),"Nombre","IdCaracterEconomicoTipo",new nc.CaracterEconomicoTipo(){IdCaracterEconomicoTipo=0, Nombre= "Seleccione CaracterEconomicoTipo"});


            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlCaracterEconomicoTipo);
            chkActivo.CheckedValue = true;
			UIHelper.Clear(toCaracterEconomicoPadre);
            UIHelper.Clear(chkIncluirSubCaracteresEconomicos);	
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                UIHelper.SetValue(ddlCaracterEconomicoTipo, Filter.IdCaracterEconomicoTipo);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
                UIHelper.SetValue(chkActivo, Filter.Activo);
                UIHelper.SetValue(chkIncluirSubCaracteresEconomicos, Filter.IncluirSubCaracteres);
							
        }	
        protected override void GetValue()
        {
			Filter.Codigo =UIHelper.GetStringFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdCaracterEconomicoTipo =UIHelper.GetIntNullable(ddlCaracterEconomicoTipo);
            Filter.Activo = UIHelper.GetBooleanNullable(chkActivo);
            Filter.IncluirSubCaracteres = UIHelper.GetBooleanNullable(chkIncluirSubCaracteresEconomicos);	
			Filter.IdCaracterEconomicoPadre =UIHelper.GetIntNullable(toCaracterEconomicoPadre);

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
