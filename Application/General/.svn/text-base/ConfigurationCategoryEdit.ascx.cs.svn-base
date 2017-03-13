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
    public partial class ConfigurationCategoryEdit : WebControlEdit<nc.ConfigurationCategory>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvName.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
					
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtName, Entity.Name);
			txtName.Focus();
					
        }	
        public override void GetValue()
        {
			Entity.Name =UIHelper.GetString(txtName);
				
        }
    }
}
