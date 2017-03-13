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
    public partial class ProgramaObjetivoFilter : WebControlFilter<nc.ProgramaObjetivoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.Saf>(ddlSaf, SafService.Current.GetList(), "Denominacion", "IdSaf", new nc.Saf() { IdSaf = 0, Denominacion = "Seleccione SAF" });
		}
		protected override void Clear()
        {
            UIHelper.Clear(ddlSaf);
            ddlSaf.Focus();
            UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(diFechaAlta);
            UIHelper.Clear(diFechaBaja);
            UIHelper.ClearItems(ddlCodigo);
        }		
		protected override void SetValue()
        {
            ddlSaf.Focus();
            UIHelper.SetValue(ddlSaf, Filter.IdSaf);
            UIHelper.SetValue(ddlCodigo,Filter.IdPrograma);
            UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
            UIHelper.SetValue(diFechaAlta, Filter.FechaAlta);
            UIHelper.SetValue(diFechaBaja, Filter.FechaBaja);
					
        }	
        protected override void GetValue()
        {
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSaf);
            Filter.IdPrograma = UIHelper.GetIntNullable(ddlCodigo);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
            Filter.FechaAlta = UIHelper.GetDateTimeNullable(diFechaAlta);
            Filter.FechaBaja = UIHelper.GetDateTimeNullable(diFechaBaja);
        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProgramas);
        }
        private void BuscarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSaf);
            if (idSaf == 0)
            {
                UIHelper.ClearItems(ddlCodigo);
            }
            else
            {
                UIHelper.Load<nc.Programa>(ddlCodigo, ProgramaService.Current.GetList(new nc.ProgramaFilter() {  IdSAF = idSaf }), "Codigo", "IdPrograma", new nc.Programa() {  IdPrograma = 0, Codigo = "Seleccione Código" });
            }
        }
    }
}
