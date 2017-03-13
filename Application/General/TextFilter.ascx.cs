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
    public partial class TextFilter : WebControlFilter<nc.TextFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
			UIHelper.Load<nc.TextCategory>(ddlTextCategory, TextCategoryService.Current.GetList(),"Name","IdTextCategory",new nc.TextCategory(){IdTextCategory=0, Name= "Seleccione TextCategory"});
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCode);
			txtCode.Focus();
				UIHelper.Clear(txtDescription);
			UIHelper.Clear(ddlTextCategory);
			UIHelper.Clear(chkIsAutomaticLoad);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(chkChecked);
            UIHelper.Clear(rdCheckedDate);
            UIHelper.Clear(acUsuarioChecked);
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCode, Filter.Code);
						txtCode.Focus();
				UIHelper.SetValueFilter(txtDescription, Filter.Description);
                UIHelper.SetValue(ddlTextCategory, Filter.IdTextCategory);
						UIHelper.SetValue(chkIsAutomaticLoad, Filter.IsAutomaticLoad);
						UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
						UIHelper.SetValue(chkChecked, Filter.Checked);
						UIHelper.SetValue<DateTime?>(rdCheckedDate, Filter.CheckedDate, Filter.CheckedDate_To);
                        UIHelper.SetValue(acUsuarioChecked, Filter.IdUsuarioChecked, Filter.UsuarioChecked_NombreUsuario);	
						
							
        }	
        protected override void GetValue()
        {
            Filter.Code = UIHelper.GetStringBetweenFilter(txtCode);
            Filter.Description = UIHelper.GetStringBetweenFilter(txtDescription);
			Filter.IdTextCategory =UIHelper.GetIntNullable(ddlTextCategory);
			Filter.IsAutomaticLoad=UIHelper.GetBooleanNullable(chkIsAutomaticLoad);			  
			Filter.StartDate =UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
			Filter.Checked=UIHelper.GetBooleanNullable(chkChecked);			  
			Filter.CheckedDate =UIHelper.GetValueFromDate(rdCheckedDate);
            Filter.CheckedDate_To = UIHelper.GetValueToDate(rdCheckedDate);
            Filter.UsuarioChecked_NombreUsuario = UIHelper.GetStringBetweenFilter(acUsuarioChecked);


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
