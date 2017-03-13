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
    public partial class TextLanguageEdit : WebControlEdit<nc.TextLanguage>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Text>(ddlText, TextService.Current.GetList(),"Code","IdText",new nc.Text(){IdText=0, Code= "Seleccione Text"});
			UIHelper.Load<nc.Language>(ddlLanguage, LanguageService.Current.GetList(),"Name","IdLanguage",new nc.Language(){IdLanguage=0, Name= "Seleccione Language"});
			revTranslateText.ValidationExpression=Contract.DataHelper.GetExpRegString(2147483647);
            revTranslateText.ErrorMessage = TranslateFormat("InvalidField", "Traducir");
            rfvLanguage.ErrorMessage = TranslateFormat("FieldIsNull", "Lenguaje");
            rfvText.ErrorMessage = TranslateFormat("FieldIsNull", "Texto");
            rfvTranslateText.ErrorMessage = TranslateFormat("FieldIsNull", "Traducir");
            diStartDate.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Inicio");
			UIHelper.Load<nc.UsuarioResult>(ddlUsuarioChecked, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true }), "NombreUsuario", "IdUsuario", new nc.UsuarioResult() { IdUsuario = 0, NombreUsuario = "Seleccione Usuario" });
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlText);
			ddlText.Focus();
				UIHelper.Clear(ddlLanguage);
			UIHelper.Clear(txtTranslateText);
			UIHelper.Clear(chkIsAutomaticLoad);
			UIHelper.Clear(diStartDate);
			UIHelper.Clear(chkChecked);
			UIHelper.Clear(diCheckedDate);
			UIHelper.Clear(ddlUsuarioChecked);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlText, Entity.IdText);
			ddlText.Focus();
				UIHelper.SetValue(ddlLanguage, Entity.IdLanguage);
			UIHelper.SetValue(txtTranslateText, Entity.TranslateText);
			UIHelper.SetValue(chkIsAutomaticLoad, Entity.IsAutomaticLoad);
			UIHelper.SetValue(diStartDate, Entity.StartDate);
			UIHelper.SetValue(chkChecked, Entity.Checked);
			UIHelper.SetValue(diCheckedDate, Entity.CheckedDate);
            if (Entity.IdUsuarioChecked.HasValue)
                UIHelper.SetValue<Usuario, int>(ddlUsuarioChecked, Entity.IdUsuarioChecked.Value, UsuarioService.Current.GetById);
				
        }	
        public override void GetValue()
        {
			Entity.IdText =UIHelper.GetInt(ddlText);
			Entity.IdLanguage =UIHelper.GetInt(ddlLanguage);
			Entity.TranslateText =UIHelper.GetString(txtTranslateText);
			Entity.IsAutomaticLoad=UIHelper.GetBoolean(chkIsAutomaticLoad);
			Entity.StartDate =UIHelper.GetDateTime(diStartDate);
			Entity.Checked=UIHelper.GetBoolean(chkChecked);
			Entity.CheckedDate =UIHelper.GetDateTimeNullable(diCheckedDate);
			Entity.IdUsuarioChecked =UIHelper.GetIntNullable(ddlUsuarioChecked);
				
        }
    }
}
