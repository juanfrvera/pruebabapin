using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc=Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{    
	public partial class ClasificacionGastoPageList : PageList<nc.ClasificacionGasto ,nc.ClasificacionGastoFilter, nc.ClasificacionGastoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("ClasificacionGastoPadre_BreadcrumbCodeOrden"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstClasificacionGasto;
            webControlFilter = this.ftClasificacionGasto;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ClasificacionGastoPageEdit.aspx";            
            base._Load();
        }
		protected ClasificacionGastoService Service
		{
			get { return ClasificacionGastoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGasto, nc.ClasificacionGastoFilter, nc.ClasificacionGastoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ClasificacionGasto ,nc.ClasificacionGastoFilter,ClasificacionGastoResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
	}
}
