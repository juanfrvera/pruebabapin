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
    public partial class TextLanguageFilter : WebControlFilter<nc.TextLanguageFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Language>(ddlLanguage, LanguageService.Current.GetList(),"Name","IdLanguage",new nc.Language(){IdLanguage=0, Name= "Seleccione Language"});
			revTranslateText.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revTranslateText.ErrorMessage = TranslateFormat("InvalidField", "Traducir");
		}
		protected override void Clear()
        {		
            UIHelper.Clear(acText);
            acText.Focus();
			UIHelper.Clear(ddlLanguage);
			UIHelper.Clear(txtTranslateText);
			UIHelper.Clear(chkIsAutomaticLoad);
			UIHelper.Clear(rdStartDate);
			UIHelper.Clear(chkChecked);
			UIHelper.Clear(rdCheckedDate);
            UIHelper.Clear(acUsuarioChecked);
        }		
		protected override void SetValue()
        {acText.Focus();
            UIHelper.SetValue(acText, Filter.IdText, Filter.Text_Code);	
	        UIHelper.SetValueFilter(txtTranslateText, Filter.TranslateText);
            UIHelper.SetValue(ddlLanguage, Filter.IdLanguage);
			UIHelper.SetValue(chkIsAutomaticLoad, Filter.IsAutomaticLoad);
			UIHelper.SetValue<DateTime?>(rdStartDate, Filter.StartDate, Filter.StartDate_To);
			UIHelper.SetValue(chkChecked, Filter.Checked);
			UIHelper.SetValue<DateTime?>(rdCheckedDate, Filter.CheckedDate, Filter.CheckedDate_To);
			UIHelper.SetValue(acUsuarioChecked, Filter.IdUsuarioChecked, Filter.UsuarioChecked_NombreCompleto);			
        }	
        protected override void GetValue()
        {
            Filter.IdText = UIHelper.GetIntNullable(acText);
            Filter.Text_Code = UIHelper.GetStringBetweenFilter(acText);
			Filter.IdLanguage =UIHelper.GetIntNullable(ddlLanguage);
            Filter.TranslateText = UIHelper.GetStringBetweenFilter(txtTranslateText);
			Filter.IsAutomaticLoad=UIHelper.GetBooleanNullable(chkIsAutomaticLoad);			  
			Filter.StartDate =UIHelper.GetValueFromDate(rdStartDate);
            Filter.StartDate_To = UIHelper.GetValueToDate(rdStartDate);
			Filter.Checked=UIHelper.GetBooleanNullable(chkChecked);			  
			Filter.CheckedDate =UIHelper.GetValueFromDate(rdCheckedDate);
            Filter.CheckedDate_To = UIHelper.GetValueToDate(rdCheckedDate);
            Filter.IdUsuarioChecked = UIHelper.GetIntNullable(acUsuarioChecked);
            Filter.UsuarioChecked_NombreCompleto = UIHelper.GetStringBetweenFilter(acUsuarioChecked);
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
