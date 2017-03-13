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
	public partial class AuditSessionPageEdit : PageEdit<nc.AuditSession ,nc.AuditSessionFilter, nc.AuditSessionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editAuditSession;
            webControlEditionButtons = this.editButtons;
            PathListPage = "AuditSessionPageList.aspx";            
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
		#endregion
	}
}
