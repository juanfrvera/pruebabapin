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
    public partial class PlanVersionEdit : WebControlEdit<nc.PlanVersion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(new nc.PlanTipoFilter() { Activo = true }), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione PlanTipo" });
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
            rfvPlanTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Plan");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlPlanTipo);
			ddlPlanTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtOrden);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue<PlanTipo,int>(ddlPlanTipo, Entity.IdPlanTipo, PlanTipoService.Current.GetById);
			ddlPlanTipo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.IdPlanTipo =UIHelper.GetInt(ddlPlanTipo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Orden=UIHelper.GetInt(txtOrden);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
