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
    public partial class ParameterFilter : WebControlFilter<nc.ParameterFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
			UIHelper.Load<nc.ParameterCategory>(ddlParameterCategory, ParameterCategoryService.Current.GetList(),"Name","IdParameterCategoty",new nc.ParameterCategory(){IdParameterCategoty=0, Name= "Seleccione ParameterCategory"});
			revStringValue.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(1000);
            //revTextValue.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revStringValue.ErrorMessage = TranslateFormat("InvalidField", "String");
            //revTextValue.ErrorMessage = TranslateFormat("InvalidField", "Texto");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtCode);
			UIHelper.Clear(txtDescription);
			UIHelper.Clear(ddlParameterCategory);
			UIHelper.Clear(txtStringValue);
			UIHelper.Clear(rnNumberValue);
			UIHelper.Clear(rdDateValue);
            //UIHelper.Clear(txtTextValue);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
				UIHelper.SetValueFilter(txtCode, Filter.Code);
                UIHelper.SetValue(ddlParameterCategory, Filter.IdParameterCategory);
						UIHelper.SetValueFilter(txtDescription, Filter.Description);
						UIHelper.SetValueFilter(txtStringValue, Filter.StringValue);
						UIHelper.SetValue<decimal?>(rnNumberValue, Filter.NumberValue, Filter.NumberValue_To);
						UIHelper.SetValue<DateTime?>(rdDateValue, Filter.DateValue, Filter.DateValue_To);
                        //UIHelper.SetValueFilter(txtTextValue, Filter.TextValue);
							
        }	
        protected override void GetValue()
        {
            Filter.Name = UIHelper.GetStringBetweenFilter(txtName);
            Filter.Code = UIHelper.GetStringBetweenFilter(txtCode);
            Filter.Description = UIHelper.GetStringBetweenFilter(txtDescription);
			Filter.IdParameterCategory =UIHelper.GetIntNullable(ddlParameterCategory);
            Filter.StringValue = UIHelper.GetStringBetweenFilter(txtStringValue);
			Filter.NumberValue =UIHelper.GetValueFrom<decimal?>(rnNumberValue);
            Filter.NumberValue_To = UIHelper.GetValueTo<decimal?>(rnNumberValue);
			Filter.DateValue =UIHelper.GetValueFromDate(rdDateValue);
            Filter.DateValue_To = UIHelper.GetValueToDate(rdDateValue);
            //Filter.TextValue = UIHelper.GetStringBetweenFilter(txtTextValue);

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
