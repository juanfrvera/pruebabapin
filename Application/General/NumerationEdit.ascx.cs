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
    public partial class NumerationEdit : WebControlEdit<nc.Numeration>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revLastvalue.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revLastvalue.ErrorMessage = TranslateFormat("InvalidField", "Último Valor");
            rfvLastvalue.ErrorMessage = TranslateFormat("FieldIsNull", "Último Valor");
            rfvCode.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
			
		}
		public override void Clear()
        {			
			txtCode.Focus();
				UIHelper.Clear(txtCode);
			UIHelper.Clear(txtLastvalue);
				
        }		
		public override void SetValue()
        {
            txtCode.Focus();
				UIHelper.SetValue(txtCode, Entity.Code);
			UIHelper.SetValue(txtLastvalue, Entity.Lastvalue);
				
        }	
        public override void GetValue()
        {
			Entity.Code =UIHelper.GetString(txtCode);
			Entity.Lastvalue=UIHelper.GetInt(txtLastvalue);
				
        }
    }
}
