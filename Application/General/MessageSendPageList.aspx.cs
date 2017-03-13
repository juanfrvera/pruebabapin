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
	public partial class MessageSendPageList : PageList<nc.MessageSend ,nc.MessageSendFilter, nc.MessageSendResult, int>
    {
        public override PageBehaviour PageBehaviour
        {
            get
            {
                PageBehaviour pageBehaviour = base.PageBehaviour;
                pageBehaviour.ReloadAlways = true;
                return pageBehaviour;
            }
        }
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            this.SortExpression = "Message_StartDate";
            this.SortDirection = SortDirection.Descending;
        }	
		protected override void _Load()
        {
            webControlList = this.lstMessageSend;
            webControlFilter = this.ftMessageSend;
       	    //webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "MessageSendPageEdit.aspx";            
            base._Load();
        }
		protected MessageSendService Service
		{
			get { return MessageSendService.Current; }
		}
		protected override IEntityService<nc.MessageSend, nc.MessageSendFilter, nc.MessageSendResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.MessageSend ,nc.MessageSendFilter,MessageSendResult, int> ViewService
        {
            get { return Service; }
        }
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected override void AddNew()
        {
            string pathAddNewMessage = "MessagePageEdit.aspx";
            SetParameter(pathAddNewMessage, PARAMETER_ACTION, Command.ADD_NEW);
            if (CommandValue != null) SetParameter(pathAddNewMessage, PARAMETER_VALUE, CommandValue);
            Response.Redirect(pathAddNewMessage, false);
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
	}
}
