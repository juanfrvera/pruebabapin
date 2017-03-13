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
    public partial class PlanPeriodoFilter : WebControlFilter<nc.PlanPeriodoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(),"Nombre","IdPlanTipo",new nc.PlanTipo(){IdPlanTipo=0, Nombre= "Seleccione PlanTipo"});
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(20);
			revAnioInicial.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revAnioFinal.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revAnioInicial.ErrorMessage = TranslateFormat("InvalidField", "Año Inicial");
            revAnioFinal.ErrorMessage = TranslateFormat("InvalidField", "Año Final");

            chkActivo.CheckedValue = true;
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlPlanTipo);
			ddlPlanTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtAnioInicial);
			UIHelper.Clear(txtAnioFinal);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {ddlPlanTipo.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
                UIHelper.SetValue(ddlPlanTipo, Filter.IdPlanTipo);
						UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
						UIHelper.SetValue(txtAnioInicial, Filter.AnioInicial);
						UIHelper.SetValue(txtAnioFinal, Filter.AnioFinal);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.IdPlanTipo =UIHelper.GetIntNullable(ddlPlanTipo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
			Filter.AnioInicial=UIHelper.GetIntNullable(txtAnioInicial);
			Filter.AnioFinal=UIHelper.GetIntNullable(txtAnioFinal);
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
