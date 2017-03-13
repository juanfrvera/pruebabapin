using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class AuditOperationDetailFilter : WebControlFilter<nc.AuditOperationDetailFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.AuditOperation>(ddlAuditOperation, AuditOperationService.Current.GetList(),"UserName","IdAuditOperation",new nc.AuditOperation(){IdAuditOperation=0, UserName= "Seleccione uno"});
			revParentId.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revDeatil.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revParentId.ErrorMessage = TranslateFormat("InvalidField", "Id Padre");
            revDeatil.ErrorMessage = TranslateFormat("InvalidField", "Detalle");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlAuditOperation);
			ddlAuditOperation.Focus();
				UIHelper.Clear(txtParentId);
			UIHelper.Clear(txtDeatil);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdEndDate);
				
        }		
		protected override void SetValue()
        {ddlAuditOperation.Focus();
				UIHelper.SetValue(txtParentId, Filter.ParentId);
                UIHelper.SetValue(ddlAuditOperation, Filter.IdAuditOperation);
						UIHelper.SetValueFilter(txtDeatil, Filter.Detail);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdEndDate, Filter.EndDate, Filter.EndDate_To);
							
        }	
        protected override void GetValue()
        {
			Filter.IdAuditOperation =UIHelper.GetIntNullable(ddlAuditOperation);
			Filter.ParentId=UIHelper.GetIntNullable(txtParentId);
            Filter.Detail = UIHelper.GetStringBetweenFilter(txtDeatil);
			Filter.StartDate =UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
			Filter.EndDate =UIHelper.GetValueFromDate(rdEndDate);
            Filter.EndDate_To = UIHelper.GetValueToDate(rdEndDate);

        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }        
    }
}
