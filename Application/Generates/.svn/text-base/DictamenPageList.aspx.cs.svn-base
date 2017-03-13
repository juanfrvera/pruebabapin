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
	public partial class DictamenPageList : PageList<nc.Dictamen ,nc.DictamenFilter, nc.DictamenResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstDictamen;
            webControlFilter = this.ftDictamen;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "DictamenPageEdit.aspx";            
            base._Load();
        }
		protected DictamenService Service
		{
			get { return DictamenService.Current; }
		}
		protected override IEntityService<nc.Dictamen, nc.DictamenFilter, nc.DictamenResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Dictamen ,nc.DictamenFilter,DictamenResult, int> ViewService
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
