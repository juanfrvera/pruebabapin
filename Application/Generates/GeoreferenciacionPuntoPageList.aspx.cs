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
	public partial class GeoreferenciacionPuntoPageList : PageList<nc.GeoreferenciacionPunto ,nc.GeoreferenciacionPuntoFilter, nc.GeoreferenciacionPuntoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstGeoreferenciacionPunto;
            webControlFilter = this.ftGeoreferenciacionPunto;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "GeoreferenciacionPuntoPageEdit.aspx";            
            base._Load();
        }
		protected GeoreferenciacionPuntoService Service
		{
			get { return GeoreferenciacionPuntoService.Current; }
		}
		protected override IEntityService<nc.GeoreferenciacionPunto, nc.GeoreferenciacionPuntoFilter, nc.GeoreferenciacionPuntoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.GeoreferenciacionPunto ,nc.GeoreferenciacionPuntoFilter,GeoreferenciacionPuntoResult, int> ViewService
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
