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
	public partial class CaracterEconomicoPageList : PageList<nc.CaracterEconomico ,nc.CaracterEconomicoFilter, nc.CaracterEconomicoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("CaracterEconomicoPadre_BreadcrumbCodeOrden"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstCaracterEconomico;
            webControlFilter = this.ftCaracterEconomico;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "CaracterEconomicoPageEdit.aspx";            
            base._Load();
        }
		protected CaracterEconomicoService Service
		{
			get { return CaracterEconomicoService.Current; }
		}
		protected override IEntityService<nc.CaracterEconomico, nc.CaracterEconomicoFilter, nc.CaracterEconomicoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.CaracterEconomico ,nc.CaracterEconomicoFilter,CaracterEconomicoResult, int> ViewService
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
