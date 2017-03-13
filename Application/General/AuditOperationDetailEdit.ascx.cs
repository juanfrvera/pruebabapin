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
    public partial class AuditOperationDetailEdit : WebControlEdit<nc.AuditOperationDetail>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.AuditOperation>(ddlAuditOperation, AuditOperationService.Current.GetList(),"UserName","IdAuditOperation",new nc.AuditOperation(){IdAuditOperation=0, UserName= "Seleccione uno"});
			revParentId.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revDeatil.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revParentId.ErrorMessage = TranslateFormat("InvalidField", "Id Padre");
            revDeatil.ErrorMessage = TranslateFormat("InvalidField", "Detalle");
            revParentId.ErrorMessage = TranslateFormat("FieldIsNull", "Id Padre");
            revDeatil.ErrorMessage = TranslateFormat("FieldIsNull", "Detalle");
            diStartDate.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Inicio");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlAuditOperation);
			ddlAuditOperation.Focus();
				UIHelper.Clear(txtParentId);
			UIHelper.Clear(txtDeatil);
			UIHelper.Clear(diStartDate);
			UIHelper.Clear(diEndDate);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlAuditOperation, Entity.IdAuditOperation);
			ddlAuditOperation.Focus();
				UIHelper.SetValue(txtParentId, Entity.ParentId);
			UIHelper.SetValue(txtDeatil, Entity.Detail);
			UIHelper.SetValue(diStartDate, Entity.StartDate);
			UIHelper.SetValue(diEndDate, Entity.EndDate);
				
        }	
        public override void GetValue()
        {
			Entity.IdAuditOperation =UIHelper.GetInt(ddlAuditOperation);
			Entity.ParentId=UIHelper.GetIntNullable(txtParentId);
			Entity.Detail =UIHelper.GetString(txtDeatil);
			Entity.StartDate =UIHelper.GetDateTime(diStartDate);
			Entity.EndDate =UIHelper.GetDateTimeNullable(diEndDate);
				
        }
    }
}
