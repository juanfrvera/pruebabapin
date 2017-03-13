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
	public partial class ClasificacionGeograficaPageList : PageList<nc.ClasificacionGeografica ,nc.ClasificacionGeograficaFilter, nc.ClasificacionGeograficaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("ClasificacionGeograficaPadre_BreadcrumbCodeOrden"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstClasificacionGeografica;
            webControlFilter = this.ftClasificacionGeografica;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ClasificacionGeograficaPageEdit.aspx";            
            base._Load();
        }
		protected ClasificacionGeograficaService Service
		{
			get { return ClasificacionGeograficaService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGeografica, nc.ClasificacionGeograficaFilter, nc.ClasificacionGeograficaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ClasificacionGeografica ,nc.ClasificacionGeograficaFilter,ClasificacionGeograficaResult, int> ViewService
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
