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
	public partial class MessagePageList : PageList<nc.Message ,nc.MessageFilter, nc.MessageResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "StartDate";
            SortDirection = SortDirection.Descending;
        }	
		protected override void _Load()
        {
            webControlList = this.lstMessage;
            webControlFilter = this.ftMessage;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "MessagePageEdit.aspx";            
            base._Load();
        }
		protected MessageService Service
		{
			get { return MessageService.Current; }
		}
		protected override IEntityService<nc.Message, nc.MessageFilter, nc.MessageResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Message ,nc.MessageFilter,MessageResult, int> ViewService
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
