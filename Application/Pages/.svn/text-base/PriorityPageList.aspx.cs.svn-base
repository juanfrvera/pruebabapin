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
	public partial class PriorityPageList : PageList<nc.Priority ,nc.PriorityFilter, nc.PriorityResult, int>
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
            webControlList = this.lstPriority;
            webControlFilter = this.ftPriority;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PriorityPageEdit.aspx";            
            base._Load();
        }
		protected PriorityService Service
		{
			get { return PriorityService.Current; }
		}
		protected override IEntityService<nc.Priority, nc.PriorityFilter, nc.PriorityResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Priority ,nc.PriorityFilter,PriorityResult, int> ViewService
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
