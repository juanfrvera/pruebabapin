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
    public partial class LanguageEdit : WebControlEdit<nc.Language>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(10);
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtCode);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtName, Entity.Name);
			txtName.Focus();
				UIHelper.SetValue(txtCode, Entity.Code);
				
        }	
        public override void GetValue()
        {
			Entity.Name =UIHelper.GetString(txtName);
			Entity.Code =UIHelper.GetString(txtCode);
				
        }
    }
}
