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
	public partial class MonedaCotizacionPageList : PageList<nc.MonedaCotizacion ,nc.MonedaCotizacionFilter, nc.MonedaCotizacionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Moneda_Nombre";

        }	
		protected override void _Load()
        {
            webControlList = this.lstMonedaCotizacion;
            webControlFilter = this.ftMonedaCotizacion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "MonedaCotizacionPageEdit.aspx";            
            base._Load();
        }
		protected MonedaCotizacionService Service
		{
			get { return MonedaCotizacionService.Current; }
		}
		protected override IEntityService<nc.MonedaCotizacion, nc.MonedaCotizacionFilter, nc.MonedaCotizacionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.MonedaCotizacion ,nc.MonedaCotizacionFilter,MonedaCotizacionResult, int> ViewService
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
	}
}
