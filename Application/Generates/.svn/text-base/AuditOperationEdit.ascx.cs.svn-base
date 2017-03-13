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
    public partial class AuditOperationEdit : WebControlEdit<nc.AuditOperation>
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
		public override void Clear()
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
			UIHelper.Clear(diStartDate);
			UIHelper.Clear(diEndDate);
			UIHelper.Clear(chkEnableViewLog);
			UIHelper.Clear(txtApplicationName);
			UIHelper.Clear(txtFormPath);
			UIHelper.Clear(txtFormName);
			UIHelper.Clear(txtUserControlName);
			UIHelper.Clear(txtUserControlPath);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlAuditSession, Entity.IdAuditSession);
			ddlAuditSession.Focus();
				UIHelper.SetValue(txtUserName, Entity.UserName);
			UIHelper.SetValue(txtEntityName, Entity.EntityName);
			UIHelper.SetValue(txtEntityBaseName, Entity.EntityBaseName);
			UIHelper.SetValue(txtTypeName, Entity.TypeName);
			UIHelper.SetValue(txtEntityId, Entity.EntityId);
			UIHelper.SetValue(txtEntityKey, Entity.EntityKey);
			UIHelper.SetValue(txtModule, Entity.Module);
			UIHelper.SetValue(txtServiceType, Entity.ServiceType);
			UIHelper.SetValue(txtService, Entity.Service);
			UIHelper.SetValue(txtOperation, Entity.Operation);
			UIHelper.SetValue(txtStatusName, Entity.StatusName);
			UIHelper.SetValue(txtInfo, Entity.Info);
			UIHelper.SetValue(txtComment, Entity.Comment);
			UIHelper.SetValue(txtDataOld, Entity.DataOld);
			UIHelper.SetValue(txtDataPreOperation, Entity.DataPreOperation);
			UIHelper.SetValue(txtDataPostOperation, Entity.DataPostOperation);
			UIHelper.SetValue(diStartDate, Entity.StartDate);
			UIHelper.SetValue(diEndDate, Entity.EndDate);
			UIHelper.SetValue(chkEnableViewLog, Entity.EnableViewLog);
			UIHelper.SetValue(txtApplicationName, Entity.ApplicationName);
			UIHelper.SetValue(txtFormPath, Entity.FormPath);
			UIHelper.SetValue(txtFormName, Entity.FormName);
			UIHelper.SetValue(txtUserControlName, Entity.UserControlName);
			UIHelper.SetValue(txtUserControlPath, Entity.UserControlPath);
				
        }	
        public override void GetValue()
        {
			Entity.IdAuditSession =UIHelper.GetInt(ddlAuditSession);
			Entity.UserName =UIHelper.GetString(txtUserName);
			Entity.EntityName =UIHelper.GetString(txtEntityName);
			Entity.EntityBaseName =UIHelper.GetString(txtEntityBaseName);
			Entity.TypeName =UIHelper.GetString(txtTypeName);
			Entity.EntityId =UIHelper.GetString(txtEntityId);
			Entity.EntityKey =UIHelper.GetString(txtEntityKey);
			Entity.Module =UIHelper.GetString(txtModule);
			Entity.ServiceType =UIHelper.GetString(txtServiceType);
			Entity.Service =UIHelper.GetString(txtService);
			Entity.Operation =UIHelper.GetString(txtOperation);
			Entity.StatusName =UIHelper.GetString(txtStatusName);
			Entity.Info =UIHelper.GetString(txtInfo);
			Entity.Comment =UIHelper.GetString(txtComment);
			Entity.DataOld =UIHelper.GetString(txtDataOld);
			Entity.DataPreOperation =UIHelper.GetString(txtDataPreOperation);
			Entity.DataPostOperation =UIHelper.GetString(txtDataPostOperation);
			Entity.StartDate =UIHelper.GetDateTime(diStartDate);
			Entity.EndDate =UIHelper.GetDateTimeNullable(diEndDate);
			Entity.EnableViewLog=UIHelper.GetBoolean(chkEnableViewLog);
			Entity.ApplicationName =UIHelper.GetString(txtApplicationName);
			Entity.FormPath =UIHelper.GetString(txtFormPath);
			Entity.FormName =UIHelper.GetString(txtFormName);
			Entity.UserControlName =UIHelper.GetString(txtUserControlName);
			Entity.UserControlPath =UIHelper.GetString(txtUserControlPath);
				
        }
    }
}
