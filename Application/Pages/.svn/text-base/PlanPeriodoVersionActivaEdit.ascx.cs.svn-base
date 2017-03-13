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
    public partial class PlanPeriodoVersionActivaEdit : WebControlEdit<nc.PlanPeriodoVersionActiva>
    {
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(new nc.PlanTipoFilter() { Activo = true }), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione Tipo" }, true, "Orden");
            rfvPlanPeriodo.ErrorMessage = TranslateFormat("FieldIsNull", "Período");
            rfvPlanVersion.ErrorMessage = TranslateFormat("FieldIsNull", "Versión");
        }
		public override void Clear()
        {
            ddlPlanPeriodo.Focus();
            UIHelper.Clear(ddlPlanTipo);
            UIHelper.ClearItems(ddlPlanPeriodo);
            ddlPlanPeriodo.Enabled = false;
            UIHelper.ClearItems(ddlPlanVersion);
            ddlPlanVersion.Enabled = false;
				
        }		
		public override void SetValue()
        {
            ddlPlanPeriodo.Focus();
            if(Entity.PlanVersion!=null)
                UIHelper.SetValue<PlanTipo, int>(ddlPlanTipo, Entity.PlanVersion.IdPlanTipo, PlanTipoService.Current.GetById);
            BuscarPlan();
            UIHelper.SetValue<PlanPeriodo, int>(ddlPlanPeriodo, Entity.IdPlanPeriodo, PlanPeriodoService.Current.GetById);
            UIHelper.SetValue<PlanVersion, int>(ddlPlanVersion, Entity.IdPlanVersion, PlanVersionService.Current.GetById);
               
                
        }	
        public override void GetValue()
        {
			Entity.IdPlanPeriodo =UIHelper.GetInt(ddlPlanPeriodo);
			Entity.IdPlanVersion =UIHelper.GetInt(ddlPlanVersion);
        }
        #region Events
        protected void ddlPlanTipo_SelectedIndexChanged(object sender, EventArgs e)
        { 
            UIHelper.CallTryMethod(BuscarPlan);
        }
        #endregion
        #region Private Functions
        private void BuscarPlan()
        {
            
            Int32 idPlanTipo = UIHelper.GetInt(ddlPlanTipo);
            if (idPlanTipo == 0)
            {
                UIHelper.ClearItems(ddlPlanPeriodo);
                ddlPlanPeriodo.Enabled = false;
                UIHelper.ClearItems(ddlPlanVersion);
                ddlPlanVersion.Enabled = false;
            }
            else
            {
                nc.PlanPeriodoFilter planPeriodoFilter = new nc.PlanPeriodoFilter();
                planPeriodoFilter.OrderBys.Add(new FilterOrderBy("AnioInicial", true));
                planPeriodoFilter.IdPlanTipo = idPlanTipo;
                planPeriodoFilter.Activo = true;

                UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(planPeriodoFilter), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período" }, false);
                UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo, Activo = true }), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión" }, true, "Orden");
                ddlPlanPeriodo.Enabled = true;
                ddlPlanVersion.Enabled = true;
            }
        }
        #endregion
    }
}
