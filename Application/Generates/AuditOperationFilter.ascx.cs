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
    public partial class AuditOperationFilter : WebControlFilter<nc.AuditOperationFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.AuditSession>(ddlAuditSession, AuditSessionService.Current.GetList(),"UserName","IdAuditSession",new nc.AuditSession(){IdAuditSession=0, UserName= "Seleccione AuditSession"});
			revUserName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntityName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntityBaseName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revTypeName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntityId.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(30);
			revEntityKey.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revModule.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revServiceType.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revService.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revOperation.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revStatusName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revInfo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(1000);
			revComment.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
			revDataOld.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
			revDataPreOperation.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
			revDataPostOperation.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
			revApplicationName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revFormPath.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(200);
			revFormName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revUserControlName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revUserControlPath.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(200);
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlAuditSession);
			ddlAuditSession.Focus();
				UIHelper.Clear(txtUserName);
			UIHelper.Clear(txtEntityName);
			UIHelper.Clear(txtEntityBaseName);
			UIHelper.Clear(txtTypeName);
			UIHelper.Clear(txtEntityId);
			UIHelper.Clear(txtEntityKey);
			UIHelper.Clear(txtModule);
			UIHelper.Clear(txtServiceType);
			UIHelper.Clear(txtService);
			UIHelper.Clear(txtOperation);
			UIHelper.Clear(txtStatusName);
			UIHelper.Clear(txtInfo);
			UIHelper.Clear(txtComment);
			UIHelper.Clear(txtDataOld);
			UIHelper.Clear(txtDataPreOperation);
			UIHelper.Clear(txtDataPostOperation);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdEndDate);
			UIHelper.Clear(chkEnableViewLog);
			UIHelper.Clear(txtApplicationName);
			UIHelper.Clear(txtFormPath);
			UIHelper.Clear(txtFormName);
			UIHelper.Clear(txtUserControlName);
			UIHelper.Clear(txtUserControlPath);
				
        }		
		protected override void SetValue()
        {ddlAuditSession.Focus();
				UIHelper.SetValueFilter(txtUserName, Filter.UserName);
						UIHelper.SetValueFilter(txtEntityName, Filter.EntityName);
						UIHelper.SetValueFilter(txtEntityBaseName, Filter.EntityBaseName);
						UIHelper.SetValueFilter(txtTypeName, Filter.TypeName);
						UIHelper.SetValueFilter(txtEntityId, Filter.EntityId);
						UIHelper.SetValueFilter(txtEntityKey, Filter.EntityKey);
						UIHelper.SetValueFilter(txtModule, Filter.Module);
						UIHelper.SetValueFilter(txtServiceType, Filter.ServiceType);
						UIHelper.SetValueFilter(txtService, Filter.Service);
						UIHelper.SetValueFilter(txtOperation, Filter.Operation);
						UIHelper.SetValueFilter(txtStatusName, Filter.StatusName);
						UIHelper.SetValueFilter(txtInfo, Filter.Info);
						UIHelper.SetValueFilter(txtComment, Filter.Comment);
						UIHelper.SetValueFilter(txtDataOld, Filter.DataOld);
						UIHelper.SetValueFilter(txtDataPreOperation, Filter.DataPreOperation);
						UIHelper.SetValueFilter(txtDataPostOperation, Filter.DataPostOperation);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdEndDate, Filter.EndDate, Filter.EndDate_To);
						UIHelper.SetValue(chkEnableViewLog, Filter.EnableViewLog);
						UIHelper.SetValueFilter(txtApplicationName, Filter.ApplicationName);
						UIHelper.SetValueFilter(txtFormPath, Filter.FormPath);
						UIHelper.SetValueFilter(txtFormName, Filter.FormName);
						UIHelper.SetValueFilter(txtUserControlName, Filter.UserControlName);
						UIHelper.SetValueFilter(txtUserControlPath, Filter.UserControlPath);
							
        }	
        protected override void GetValue()
        {
			Filter.IdAuditSession =UIHelper.GetIntNullable(ddlAuditSession);
			Filter.UserName =UIHelper.GetStringFilter(txtUserName);
			Filter.EntityName =UIHelper.GetStringFilter(txtEntityName);
			Filter.EntityBaseName =UIHelper.GetStringFilter(txtEntityBaseName);
			Filter.TypeName =UIHelper.GetStringFilter(txtTypeName);
			Filter.EntityId =UIHelper.GetStringFilter(txtEntityId);
			Filter.EntityKey =UIHelper.GetStringFilter(txtEntityKey);
			Filter.Module =UIHelper.GetStringFilter(txtModule);
			Filter.ServiceType =UIHelper.GetStringFilter(txtServiceType);
			Filter.Service =UIHelper.GetStringFilter(txtService);
			Filter.Operation =UIHelper.GetStringFilter(txtOperation);
			Filter.StatusName =UIHelper.GetStringFilter(txtStatusName);
			Filter.Info =UIHelper.GetStringFilter(txtInfo);
			Filter.Comment =UIHelper.GetStringFilter(txtComment);
			Filter.DataOld =UIHelper.GetStringFilter(txtDataOld);
			Filter.DataPreOperation =UIHelper.GetStringFilter(txtDataPreOperation);
			Filter.DataPostOperation =UIHelper.GetStringFilter(txtDataPostOperation);
			Filter.StartDate =UIHelper.GetValueFrom<DateTime?>(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueTo<DateTime?>(rdStartDate);
			Filter.EndDate =UIHelper.GetValueFrom<DateTime?>(rdEndDate);
            Filter.EndDate_To = UIHelper.GetValueTo<DateTime?>(rdEndDate);
			Filter.EnableViewLog=UIHelper.GetBooleanNullable(chkEnableViewLog);			  
			Filter.ApplicationName =UIHelper.GetStringFilter(txtApplicationName);
			Filter.FormPath =UIHelper.GetStringFilter(txtFormPath);
			Filter.FormName =UIHelper.GetStringFilter(txtFormName);
			Filter.UserControlName =UIHelper.GetStringFilter(txtUserControlName);
			Filter.UserControlPath =UIHelper.GetStringFilter(txtUserControlPath);
				
        }
		//protected void btSearch_Click(object sender, EventArgs e)
        //{
        //    RaiseControlCommand(Command.SEARCH);
        //}
    }
}
