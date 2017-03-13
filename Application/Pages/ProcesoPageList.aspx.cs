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
	public partial class ProcesoPageList : PageList<nc.Proceso ,nc.ProcesoFilter, nc.ProcesoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("ProyectoTipo_Nombre"));
            OrderBys.Add(new FilterOrderBy("Nombre"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstProceso;
            webControlFilter = this.ftProceso;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProcesoPageEdit.aspx";            
            base._Load();
        }
		protected ProcesoService Service
		{
			get { return ProcesoService.Current; }
		}
		protected override IEntityService<nc.Proceso, nc.ProcesoFilter, nc.ProcesoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Proceso ,nc.ProcesoFilter,ProcesoResult, int> ViewService
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
