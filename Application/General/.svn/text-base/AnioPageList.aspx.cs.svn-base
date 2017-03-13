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
	public partial class AnioPageList : PageList<nc.Anio ,nc.AnioFilter, nc.AnioResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstAnio;
            webControlFilter = this.ftAnio;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AnioPageEdit.aspx";            
            base._Load();
        }
		protected AnioService Service
		{
			get { return AnioService.Current; }
		}
		protected override IEntityService<nc.Anio, nc.AnioFilter, nc.AnioResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Anio ,nc.AnioFilter,AnioResult, int> ViewService
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
