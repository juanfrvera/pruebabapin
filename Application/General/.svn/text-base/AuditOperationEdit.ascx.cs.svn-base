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
			UIHelper.Load<nc.AuditSession>(ddlAuditSession, AuditSessionService.Current.GetList(),"UserName","IdAuditSession",new nc.AuditSession(){IdAuditSession=0, UserName= "Seleccione uno"});
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
            rfvAuditSession.ErrorMessage = TranslateFormat("FieldIsNull", "Sesión de Auditoria");
            revUserName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Usuario");
            revEntityName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Entidad ");
            revEntityBaseName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Base Entidad");
            revTypeName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Tipo");
            revEntityId.ErrorMessage = TranslateFormat("InvalidField", "Id Entidad");
            revEntityKey.ErrorMessage = TranslateFormat("InvalidField", "Clave Entidad");
            revModule.ErrorMessage = TranslateFormat("InvalidField", "Modulo");
            revServiceType.ErrorMessage = TranslateFormat("InvalidField", "Servicio Tipo");
            revService.ErrorMessage = TranslateFormat("InvalidField", "Servicio");
            revOperation.ErrorMessage = TranslateFormat("InvalidField", "Operación");
            revStatusName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Estado");
            revInfo.ErrorMessage = TranslateFormat("InvalidField", "Información");
            revComment.ErrorMessage = TranslateFormat("InvalidField", "Comentario");
            revDataOld.ErrorMessage = TranslateFormat("InvalidField", "Dato Anterior");
            revDataPreOperation.ErrorMessage = TranslateFormat("InvalidField", "Dato Operación Anterior");
            revDataPostOperation.ErrorMessage = TranslateFormat("InvalidField", "Dato Operación Próxima");
            diStartDate.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Inicio");

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
				
        }
    }
}
