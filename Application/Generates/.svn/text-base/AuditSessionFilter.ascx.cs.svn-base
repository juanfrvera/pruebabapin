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
			revLogin.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revRols.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revArea.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revIP.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(15);
			revBrowserVersion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revOperatingSystem.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revMandate.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(1);
			revMessage.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(4000);
			revComments.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(4000);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtUserName);
			txtUserName.Focus();
				UIHelper.Clear(txtSessionId);
			UIHelper.Clear(txtLogin);
			UIHelper.Clear(txtRols);
			UIHelper.Clear(txtArea);
			UIHelper.Clear(txtIP);
			UIHelper.Clear(txtBrowserVersion);
			UIHelper.Clear(txtOperatingSystem);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdEndDate);
			UIHelper.Clear(txtMandate);
			UIHelper.Clear(txtMessage);
			UIHelper.Clear(txtComments);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtUserName, Filter.UserName);
						txtUserName.Focus();
				UIHelper.SetValueFilter(txtSessionId, Filter.SessionId);
						UIHelper.SetValueFilter(txtLogin, Filter.Login);
						UIHelper.SetValueFilter(txtRols, Filter.Rols);
						UIHelper.SetValueFilter(txtArea, Filter.Area);
						UIHelper.SetValueFilter(txtIP, Filter.IP);
						UIHelper.SetValueFilter(txtBrowserVersion, Filter.BrowserVersion);
						UIHelper.SetValueFilter(txtOperatingSystem, Filter.OperatingSystem);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdEndDate, Filter.EndDate, Filter.EndDate_To);
						UIHelper.SetValueFilter(txtMandate, Filter.Mandate);
						UIHelper.SetValueFilter(txtMessage, Filter.Message);
						UIHelper.SetValueFilter(txtComments, Filter.Comments);
							
        }	
        protected override void GetValue()
        {
			Filter.UserName =UIHelper.GetStringFilter(txtUserName);
			Filter.SessionId =UIHelper.GetStringFilter(txtSessionId);
			Filter.Login =UIHelper.GetStringFilter(txtLogin);
			Filter.Rols =UIHelper.GetStringFilter(txtRols);
			Filter.Area =UIHelper.GetStringFilter(txtArea);
			Filter.IP =UIHelper.GetStringFilter(txtIP);
			Filter.BrowserVersion =UIHelper.GetStringFilter(txtBrowserVersion);
			Filter.OperatingSystem =UIHelper.GetStringFilter(txtOperatingSystem);
			Filter.StartDate =UIHelper.GetValueFrom<DateTime?>(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueTo<DateTime?>(rdStartDate);
			Filter.EndDate =UIHelper.GetValueFrom<DateTime?>(rdEndDate);
            Filter.EndDate_To = UIHelper.GetValueTo<DateTime?>(rdEndDate);
			Filter.Mandate =UIHelper.GetStringFilter(txtMandate);
			Filter.Message =UIHelper.GetStringFilter(txtMessage);
			Filter.Comments =UIHelper.GetStringFilter(txtComments);
				
        }
		//protected void btSearch_Click(object sender, EventArgs e)
        //{
        //    RaiseControlCommand(Command.SEARCH);
        //}
    }
}
