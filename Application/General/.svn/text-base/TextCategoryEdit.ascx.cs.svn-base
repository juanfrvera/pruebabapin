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
    public partial class TextCategoryEdit : WebControlEdit<nc.TextCategory>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Decripción");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvName.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtDescription);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtName, Entity.Name);
			txtName.Focus();
				UIHelper.SetValue(txtDescription, Entity.Description);
				
        }	
        public override void GetValue()
        {
			Entity.Name =UIHelper.GetString(txtName);
			Entity.Description =UIHelper.GetString(txtDescription);
				
        }
    }
}
