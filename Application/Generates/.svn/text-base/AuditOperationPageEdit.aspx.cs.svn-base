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
	public partial class AuditOperationPageEdit : PageEdit<nc.AuditOperation ,nc.AuditOperationFilter, nc.AuditOperationResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editAuditOperation;
            webControlEditionButtons = this.editButtons;
            PathListPage = "AuditOperationPageList.aspx";            
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
		#endregion
	}
}
