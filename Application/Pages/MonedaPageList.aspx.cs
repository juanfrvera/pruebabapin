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
	public partial class MonedaPageList : PageList<nc.Moneda ,nc.MonedaFilter, nc.MonedaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";       
        }	
		protected override void _Load()
        {
            webControlList = this.lstMoneda;
            webControlFilter = this.ftMoneda;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "MonedaPageEdit.aspx";            
            base._Load();
        }
		protected MonedaService Service
		{
			get { return MonedaService.Current; }
		}
		protected override IEntityService<nc.Moneda, nc.MonedaFilter, nc.MonedaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Moneda ,nc.MonedaFilter,MonedaResult, int> ViewService
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
