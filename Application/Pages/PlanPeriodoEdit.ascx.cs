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
    public partial class PlanPeriodoEdit : WebControlEdit<nc.PlanPeriodo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(new nc.PlanTipoFilter() { Activo = true }), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione PlanTipo" });
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(20);
			revAnioInicial.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revAnioFinal.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revAnioInicial.ErrorMessage = TranslateFormat("InvalidField", "Año Inicial");
            revAnioFinal.ErrorMessage = TranslateFormat("InvalidField", "Año Final");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvAnioInicial.ErrorMessage = TranslateFormat("FieldIsNull", "Año Inicial");
            rfvAnioFinal.ErrorMessage = TranslateFormat("FieldIsNull", "Año Final");

			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlPlanTipo);
			ddlPlanTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtAnioInicial);
			UIHelper.Clear(txtAnioFinal);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue<PlanTipo,int>(ddlPlanTipo, Entity.IdPlanTipo, PlanTipoService.Current.GetById);
			ddlPlanTipo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			UIHelper.SetValue(txtAnioInicial, Entity.AnioInicial);
			UIHelper.SetValue(txtAnioFinal, Entity.AnioFinal);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.IdPlanTipo =UIHelper.GetInt(ddlPlanTipo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.AnioInicial=UIHelper.GetInt(txtAnioInicial);
			Entity.AnioFinal=UIHelper.GetInt(txtAnioFinal);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
