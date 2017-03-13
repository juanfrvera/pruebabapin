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
    public partial class AuditSessionFilter : WebControlFilter<nc.AuditSessionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revUserName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revSessionId.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revIP.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(15);
			revBrowserVersion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revOperatingSystem.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revMandate.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(1);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtUserName);
			txtUserName.Focus();
				UIHelper.Clear(txtSessionId);
			UIHelper.Clear(txtIP);
			UIHelper.Clear(txtBrowserVersion);
			UIHelper.Clear(txtOperatingSystem);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdEndDate);
			UIHelper.Clear(txtMandate);				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtUserName, Filter.UserName);
						txtUserName.Focus();
				UIHelper.SetValueFilter(txtSessionId, Filter.SessionId);
						UIHelper.SetValueFilter(txtIP, Filter.IP);
						UIHelper.SetValueFilter(txtBrowserVersion, Filter.BrowserVersion);
						UIHelper.SetValueFilter(txtOperatingSystem, Filter.OperatingSystem);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdEndDate, Filter.EndDate, Filter.EndDate_To);
						UIHelper.SetValueFilter(txtMandate, Filter.Mandate);							
        }	
        protected override void GetValue()
        {
            Filter.UserName = UIHelper.GetStringBetweenFilter(txtUserName);
            Filter.SessionId = UIHelper.GetStringBetweenFilter(txtSessionId);
            Filter.IP = UIHelper.GetStringBetweenFilter(txtIP);
            Filter.BrowserVersion = UIHelper.GetStringBetweenFilter(txtBrowserVersion);
            Filter.OperatingSystem = UIHelper.GetStringBetweenFilter(txtOperatingSystem);
			Filter.StartDate =UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
			Filter.EndDate =UIHelper.GetValueFromDate(rdEndDate);
            Filter.EndDate_To = UIHelper.GetValueToDate(rdEndDate);
            Filter.Mandate = UIHelper.GetStringBetweenFilter(txtMandate);
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
