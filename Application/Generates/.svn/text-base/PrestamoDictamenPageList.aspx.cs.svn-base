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
	public partial class PrestamoDictamenPageList : PageList<nc.PrestamoDictamen ,nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstPrestamoDictamen;
            webControlFilter = this.ftPrestamoDictamen;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PrestamoDictamenPageEdit.aspx";            
            base._Load();
        }
		protected PrestamoDictamenService Service
		{
			get { return PrestamoDictamenService.Current; }
		}
		protected override IEntityService<nc.PrestamoDictamen, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PrestamoDictamen ,nc.PrestamoDictamenFilter,PrestamoDictamenResult, int> ViewService
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
