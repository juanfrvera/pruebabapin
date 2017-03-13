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
	public partial class AuditOperationDetailPageEdit : PageEdit<nc.AuditOperationDetail ,nc.AuditOperationDetailFilter, nc.AuditOperationDetailResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editAuditOperationDetail;
            webControlEditionButtons = this.editButtons;
            PathListPage = "AuditOperationDetailPageList.aspx";            
            base._Load();
        }
		protected AuditOperationDetailService Service
		{
			get { return AuditOperationDetailService.Current; }
		}
		protected override IEntityService<nc.AuditOperationDetail, nc.AuditOperationDetailFilter, nc.AuditOperationDetailResult, int> EntityService
		{
			get { return AuditOperationDetailService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
