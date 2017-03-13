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
    public partial class ParameterEdit : WebControlEdit<nc.Parameter>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvCode.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvName.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			UIHelper.Load<nc.ParameterCategory>(ddlParameterCategory, ParameterCategoryService.Current.GetList(),"Name","IdParameterCategoty",new nc.ParameterCategory(){IdParameterCategoty=0, Name= "Seleccione ParameterCategory"});
			revStringValue.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(1000);
			revNumberValue.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revTextValue.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revStringValue.ErrorMessage = TranslateFormat("InvalidField", "String");
            revNumberValue.ErrorMessage = TranslateFormat("InvalidField", "Número");
            revTextValue.ErrorMessage = TranslateFormat("InvalidField", "Texto");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtCode);
			UIHelper.Clear(txtDescription);
			UIHelper.Clear(ddlParameterCategory);
			UIHelper.Clear(txtStringValue);
			UIHelper.Clear(txtNumberValue);
			UIHelper.Clear(diDateValue);
			UIHelper.Clear(txtTextValue);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtName, Entity.Name);
			txtName.Focus();
				UIHelper.SetValue(txtCode, Entity.Code);
			UIHelper.SetValue(txtDescription, Entity.Description);
			UIHelper.SetValue(ddlParameterCategory, Entity.IdParameterCategory);
			UIHelper.SetValue(txtStringValue, Entity.StringValue);
			UIHelper.SetValue(txtNumberValue, Entity.NumberValue);
			UIHelper.SetValue(diDateValue, Entity.DateValue);
			UIHelper.SetValue(txtTextValue, Entity.TextValue);
				
        }	
        public override void GetValue()
        {
			Entity.Name =UIHelper.GetString(txtName);
			Entity.Code =UIHelper.GetString(txtCode);
			Entity.Description =UIHelper.GetString(txtDescription);
			Entity.IdParameterCategory =UIHelper.GetInt(ddlParameterCategory);
			Entity.StringValue =UIHelper.GetString(txtStringValue);
			Entity.NumberValue=UIHelper.GetDecimalNullable(txtNumberValue);
			Entity.DateValue =UIHelper.GetDateTimeNullable(diDateValue);
			Entity.TextValue =UIHelper.GetString(txtTextValue);
				
        }
    }
}
