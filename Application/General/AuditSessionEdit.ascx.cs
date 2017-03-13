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

		}
		public override void Clear()
        {			
			UIHelper.Clear(lblUserName);
			lblUserName.Focus();
				UIHelper.Clear(lblSessionId);
			UIHelper.Clear(lblLogin);
			UIHelper.Clear(lblRols);
			UIHelper.Clear(lblArea);
			UIHelper.Clear(lblIP);
			UIHelper.Clear(lblBrowserVersion);
			UIHelper.Clear(lblOperatingSystem);
			UIHelper.Clear(lblStartDate);
			UIHelper.Clear(lblEndDate);
			UIHelper.Clear(lblMandate);
			UIHelper.Clear(lblMessage);
			UIHelper.Clear(lblComments);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(lblUserName, Entity.UserName);
			lblUserName.Focus();
				UIHelper.SetValue(lblSessionId, Entity.SessionId);
			UIHelper.SetValue(lblLogin, Entity.Login);
			UIHelper.SetValue(lblRols, Entity.Rols);
			UIHelper.SetValue(lblArea, Entity.Area);
			UIHelper.SetValue(lblIP, Entity.IP);
			UIHelper.SetValue(lblBrowserVersion, Entity.BrowserVersion);
			UIHelper.SetValue(lblOperatingSystem, Entity.OperatingSystem);
			UIHelper.SetValue(lblStartDate, Entity.StartDate);
			UIHelper.SetValue(lblEndDate, Entity.EndDate);
			UIHelper.SetValue(lblMandate, Entity.Mandate);
			UIHelper.SetValue(lblMessage, Entity.Message);
			UIHelper.SetValue(lblComments, Entity.Comments);
				
        }	
        public override void GetValue()
        {
           /*
			Entity.UserName =UIHelper.GetString(lblUserName);
			Entity.SessionId =UIHelper.GetString(lblSessionId);
			Entity.Login =UIHelper.GetString(lblLogin);
			Entity.Rols =UIHelper.GetString(lblRols);
			Entity.Area =UIHelper.GetString(lblArea);
			Entity.IP =UIHelper.GetString(lblIP);
			Entity.BrowserVersion =UIHelper.GetString(lblBrowserVersion);
			Entity.OperatingSystem =UIHelper.GetString(lblOperatingSystem);
			Entity.StartDate =UIHelper.GetDateTimeNullable(lblStartDate);
			Entity.EndDate =UIHelper.GetDateTimeNullable(lblEndDate);
			Entity.Mandate =UIHelper.GetString(lblMandate);
			Entity.Message =UIHelper.GetString(lblMessage);
			Entity.Comments =UIHelper.GetString(lblComments);
			*/
        }
    }
}
