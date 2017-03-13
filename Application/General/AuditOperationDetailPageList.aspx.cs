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
	public partial class AuditOperationDetailPageList : PageList<nc.AuditOperationDetail ,nc.AuditOperationDetailFilter, nc.AuditOperationDetailResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "AuditOperation_UserName";
        }	
		protected override void _Load()
        {
            webControlList = this.lstAuditOperationDetail;
            webControlFilter = this.ftAuditOperationDetail;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AuditOperationDetailPageEdit.aspx";            
            base._Load();
        }
		protected AuditOperationDetailService Service
		{
			get { return AuditOperationDetailService.Current; }
		}
		protected override IEntityService<nc.AuditOperationDetail, nc.AuditOperationDetailFilter, nc.AuditOperationDetailResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.AuditOperationDetail ,nc.AuditOperationDetailFilter,AuditOperationDetailResult, int> ViewService
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
