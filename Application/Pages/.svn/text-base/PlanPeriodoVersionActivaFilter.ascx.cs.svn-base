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
    public partial class PlanPeriodoVersionActivaFilter : WebControlFilter<nc.PlanPeriodoVersionActivaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            nc.PlanPeriodoFilter planPeriodoFilter = new nc.PlanPeriodoFilter();
            planPeriodoFilter.OrderBys.Add(new FilterOrderBy("AnioInicial", true));

			UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione Tipo" },true, "Orden");
            //UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(planPeriodoFilter), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período" },false);
            //UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión" },true, "Orden");

        }
		protected override void Clear()
        {
            ddlPlanPeriodo.Focus();
            UIHelper.Clear(ddlPlanTipo);		
            UIHelper.ClearItems(ddlPlanPeriodo);
            ddlPlanPeriodo.Enabled = false;
            UIHelper.ClearItems(ddlPlanVersion);
            ddlPlanVersion.Enabled = false;
				
        }		
		protected override void SetValue()
        {ddlPlanPeriodo.Focus();
            UIHelper.SetValue(ddlPlanTipo, Filter.IdPlanTipo);
            BuscarPlan();
            UIHelper.SetValue(ddlPlanPeriodo, Filter.IdPlanPeriodo);
            UIHelper.SetValue(ddlPlanVersion, Filter.IdPlanVersion);
        }	
        protected override void GetValue()
        {
			Filter.IdPlanPeriodo =UIHelper.GetIntNullable(ddlPlanPeriodo);
			Filter.IdPlanVersion =UIHelper.GetIntNullable(ddlPlanVersion);
            Filter.IdPlanTipo = UIHelper.GetIntNullable(ddlPlanTipo);

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
            //    UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período de Plan" });
            //    UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión de Plan" });
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

                UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(planPeriodoFilter), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período" }, false);
                UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo }), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión" }, true, "Orden");

                ddlPlanPeriodo.Enabled = true;
                ddlPlanVersion.Enabled = true;
            }
        }
        #endregion
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
