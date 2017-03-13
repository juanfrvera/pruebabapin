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
	public partial class OficinaSafPageList : PageList<nc.OficinaSaf ,nc.OficinaSafFilter, nc.OficinaSafResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstOficinaSaf;
            webControlFilter = this.ftOficinaSaf;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OficinaSafPageEdit.aspx";            
            base._Load();
        }
		protected OficinaSafService Service
		{
			get { return OficinaSafService.Current; }
		}
		protected override IEntityService<nc.OficinaSaf, nc.OficinaSafFilter, nc.OficinaSafResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.OficinaSaf ,nc.OficinaSafFilter,OficinaSafResult, int> ViewService
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
