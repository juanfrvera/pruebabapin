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
	public partial class GeoreferenciacionPageList : PageList<nc.Georeferenciacion ,nc.GeoreferenciacionFilter, nc.GeoreferenciacionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstGeoreferenciacion;
            webControlFilter = this.ftGeoreferenciacion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "GeoreferenciacionPageEdit.aspx";            
            base._Load();
        }
		protected GeoreferenciacionService Service
		{
			get { return GeoreferenciacionService.Current; }
		}
		protected override IEntityService<nc.Georeferenciacion, nc.GeoreferenciacionFilter, nc.GeoreferenciacionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Georeferenciacion ,nc.GeoreferenciacionFilter,GeoreferenciacionResult, int> ViewService
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
