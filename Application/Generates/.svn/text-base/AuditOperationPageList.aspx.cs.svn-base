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
	public partial class AuditOperationPageList : PageList<nc.AuditOperation ,nc.AuditOperationFilter, nc.AuditOperationResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            idImgCreate.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstAuditOperation;
            webControlFilter = this.ftAuditOperation;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AuditOperationPageEdit.aspx";            
            base._Load();
        }
		protected AuditOperationService Service
		{
			get { return AuditOperationService.Current; }
		}
		protected override IEntityService<nc.AuditOperation, nc.AuditOperationFilter, nc.AuditOperationResult, int> EntityService
		{
			get { return AuditOperationService.Current; }
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
	}
}
