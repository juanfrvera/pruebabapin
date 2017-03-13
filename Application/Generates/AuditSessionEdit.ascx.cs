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
    public partial class AuditSessionEdit : WebControlEdit<nc.AuditSession>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revUserName.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
			revSessionId.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
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
		public override void Clear()
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
			UIHelper.Clear(diStartDate);
			UIHelper.Clear(diEndDate);
			UIHelper.Clear(txtMandate);
			UIHelper.Clear(txtMessage);
			UIHelper.Clear(txtComments);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtUserName, Entity.UserName);
			txtUserName.Focus();
				UIHelper.SetValue(txtSessionId, Entity.SessionId);
			UIHelper.SetValue(txtLogin, Entity.Login);
			UIHelper.SetValue(txtRols, Entity.Rols);
			UIHelper.SetValue(txtArea, Entity.Area);
			UIHelper.SetValue(txtIP, Entity.IP);
			UIHelper.SetValue(txtBrowserVersion, Entity.BrowserVersion);
			UIHelper.SetValue(txtOperatingSystem, Entity.OperatingSystem);
			UIHelper.SetValue(diStartDate, Entity.StartDate);
			UIHelper.SetValue(diEndDate, Entity.EndDate);
			UIHelper.SetValue(txtMandate, Entity.Mandate);
			UIHelper.SetValue(txtMessage, Entity.Message);
			UIHelper.SetValue(txtComments, Entity.Comments);
				
        }	
        public override void GetValue()
        {
			Entity.UserName =UIHelper.GetString(txtUserName);
			Entity.SessionId =UIHelper.GetString(txtSessionId);
			Entity.Login =UIHelper.GetString(txtLogin);
			Entity.Rols =UIHelper.GetString(txtRols);
			Entity.Area =UIHelper.GetString(txtArea);
			Entity.IP =UIHelper.GetString(txtIP);
			Entity.BrowserVersion =UIHelper.GetString(txtBrowserVersion);
			Entity.OperatingSystem =UIHelper.GetString(txtOperatingSystem);
			Entity.StartDate =UIHelper.GetDateTimeNullable(diStartDate);
			Entity.EndDate =UIHelper.GetDateTimeNullable(diEndDate);
			Entity.Mandate =UIHelper.GetString(txtMandate);
			Entity.Message =UIHelper.GetString(txtMessage);
			Entity.Comments =UIHelper.GetString(txtComments);
				
        }
    }
}
