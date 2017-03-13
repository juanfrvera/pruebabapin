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
	public partial class DictamenTipoPageList : PageList<nc.DictamenTipo ,nc.DictamenTipoFilter, nc.DictamenTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstDictamenTipo;
            webControlFilter = this.ftDictamenTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "DictamenTipoPageEdit.aspx";            
            base._Load();
        }
		protected DictamenTipoService Service
		{
			get { return DictamenTipoService.Current; }
		}
		protected override IEntityService<nc.DictamenTipo, nc.DictamenTipoFilter, nc.DictamenTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.DictamenTipo ,nc.DictamenTipoFilter,DictamenTipoResult, int> ViewService
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
