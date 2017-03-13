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
            //btNew.Visible = canCreate;
            //idImgCreate.Visible = canCreate;
            this.SortExpression = "StartDate";
            this.SortDirection = SortDirection.Descending;
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
        protected override void ViewLog()
        {
            int idLog;
            if (int.TryParse(CommandValue.ToString(), out idLog))
            {
                AuditOperation audit = AuditOperationService.Current.GetById(idLog);
                
                UIHelper.Validate(audit != null, "No se puede mostrar el Log");
                UIHelper.Validate(audit.FormPath != null, "No se puede mostrar el Log");
                UIHelper.Validate(audit.FormPath.Trim() != string.Empty, "No se puede mostrar el Log");
                
                string pageLog =  "~"+@audit.FormPath;
                SetParameter(pageLog, PARAMETER_ACTION, Command.VIEW_LOG);
                SetParameter(pageLog, PARAMETER_VALUE, idLog.ToString());
                Response.Redirect(pageLog, false);
            }
        }  
	}
}
