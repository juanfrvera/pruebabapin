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
    public partial class PlanVersionFilter : WebControlFilter<nc.PlanVersionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(),"Nombre","IdPlanTipo",new nc.PlanTipo(){IdPlanTipo=0, Nombre= "Seleccione PlanTipo"});
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");

            chkActivo.CheckedValue = true;
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlPlanTipo);
			ddlPlanTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtOrden);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {ddlPlanTipo.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
                UIHelper.SetValue(ddlPlanTipo, Filter.IdPlanTipo);
						UIHelper.SetValue(txtOrden, Filter.Orden);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.IdPlanTipo =UIHelper.GetIntNullable(ddlPlanTipo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.Orden=UIHelper.GetIntNullable(txtOrden);
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
