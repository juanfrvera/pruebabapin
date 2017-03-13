using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;
//Matias 20170306
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.IO;
//FinMatias 20170306

namespace UI.Web
{
    public partial class AuditOperationFilter : WebControlFilter<nc.AuditOperationFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revUserName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revSessionId.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(100);
            revEntityName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntityBaseName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revTypeName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revEntityId.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(30);
			revEntityKey.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revService.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revOperation.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			revStatusName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revUserName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Usuario");
            revEntityName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Entidad ");
            revEntityBaseName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Base Entidad");
            revTypeName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Tipo");
            revEntityId.ErrorMessage = TranslateFormat("InvalidField", "Id Entidad");
            revEntityKey.ErrorMessage = TranslateFormat("InvalidField", "Clave Entidad");
            revService.ErrorMessage = TranslateFormat("InvalidField", "Servicio");
            revOperation.ErrorMessage = TranslateFormat("InvalidField", "Operación");
            revStatusName.ErrorMessage = TranslateFormat("InvalidField", "Nombre Estado");

		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtSessionId);
            txtSessionId.Focus();
				UIHelper.Clear(txtUserName);
			UIHelper.Clear(txtEntityName);
			UIHelper.Clear(txtEntityBaseName);
			UIHelper.Clear(txtTypeName);
			UIHelper.Clear(txtEntityId);
			UIHelper.Clear(txtEntityKey);			
			UIHelper.Clear(txtService);
			UIHelper.Clear(txtOperation);
			UIHelper.Clear(txtStatusName);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(rdEndDate);				
        }		
		protected override void SetValue()
        {txtSessionId.Focus();
        UIHelper.SetValueFilter(txtSessionId, Filter.SessionId);
				UIHelper.SetValueFilter(txtUserName, Filter.UserName);
						UIHelper.SetValueFilter(txtEntityName, Filter.EntityName);
						UIHelper.SetValueFilter(txtEntityBaseName, Filter.EntityBaseName);
						UIHelper.SetValueFilter(txtTypeName, Filter.TypeName);
						UIHelper.SetValueFilter(txtEntityId, Filter.EntityId);
						UIHelper.SetValueFilter(txtEntityKey, Filter.EntityKey);
						UIHelper.SetValueFilter(txtService, Filter.Service);
						UIHelper.SetValueFilter(txtOperation, Filter.Operation);
						UIHelper.SetValueFilter(txtStatusName, Filter.StatusName);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue<DateTime?>(rdEndDate, Filter.EndDate, Filter.EndDate_To);
						
							
        }	
        protected override void GetValue()
        {
            Filter.SessionId = UIHelper.GetStringBetweenFilter(txtSessionId);
            Filter.UserName = UIHelper.GetStringBetweenFilter(txtUserName);
            Filter.EntityName = UIHelper.GetStringBetweenFilter(txtEntityName);
            Filter.EntityBaseName = UIHelper.GetStringBetweenFilter(txtEntityBaseName);
            Filter.TypeName = UIHelper.GetStringBetweenFilter(txtTypeName);
            Filter.EntityId = UIHelper.GetStringBetweenFilter(txtEntityId);
            Filter.EntityKey = UIHelper.GetStringBetweenFilter(txtEntityKey);
            Filter.Service = UIHelper.GetStringBetweenFilter(txtService);
            Filter.Operation = UIHelper.GetStringBetweenFilter(txtOperation);
            Filter.StatusName = UIHelper.GetStringBetweenFilter(txtStatusName);
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
