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
	public partial class AuditSessionPageList : PageList<nc.AuditSession ,nc.AuditSessionFilter, nc.AuditSessionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            this.SortExpression = "StartDate";
            //btNew.Visible = canCreate;
            //idImgCreate.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstAuditSession;
            webControlFilter = this.ftAuditSession;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AuditSessionPageEdit.aspx";
            this.SortExpression = "StartDate";
            this.SortDirection = SortDirection.Descending;
            base._Load();
        }
		protected AuditSessionService Service
		{
			get { return AuditSessionService.Current; }
		}
		protected override IEntityService<nc.AuditSession, nc.AuditSessionFilter, nc.AuditSessionResult, int> EntityService
		{
			get { return AuditSessionService.Current; }
		}
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        //protected void btNew_OnClick(object sender, EventArgs e)
        //{
        //    ControlCommand(Command.ADD_NEW);
        //}
	}
}
