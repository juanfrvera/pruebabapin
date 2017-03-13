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
    public partial class TextEdit : WebControlEdit<nc.Text>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvCode.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvTextCategory.ErrorMessage = TranslateFormat("FieldIsNull", "Categoría de Texto");
            diStartDate.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Inicio");
			UIHelper.Load<nc.TextCategory>(ddlTextCategory, TextCategoryService.Current.GetList(),"Name","IdTextCategory",new nc.TextCategory(){IdTextCategory=0, Name= "Seleccione TextCategory"});
            UIHelper.Load<nc.Usuario>(ddlUsuarioChecked, UsuarioService.Current.GetList(new nc.UsuarioFilter() { Activo = true }), "NombreUsuario", "IdUsuario", new nc.Usuario() { IdUsuario = 0, NombreUsuario = "Seleccione Usuario" });
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCode);
			txtCode.Focus();
				UIHelper.Clear(txtDescription);
			UIHelper.Clear(ddlTextCategory);
			UIHelper.Clear(chkIsAutomaticLoad);
			UIHelper.Clear(diStartDate);
			UIHelper.Clear(chkChecked);
			UIHelper.Clear(diCheckedDate);
			UIHelper.Clear(ddlUsuarioChecked);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCode, Entity.Code);
			txtCode.Focus();
				UIHelper.SetValue(txtDescription, Entity.Description);
			UIHelper.SetValue(ddlTextCategory, Entity.IdTextCategory);
			UIHelper.SetValue(chkIsAutomaticLoad, Entity.IsAutomaticLoad);
			UIHelper.SetValue(diStartDate, Entity.StartDate);
			UIHelper.SetValue(chkChecked, Entity.Checked);
			UIHelper.SetValue(diCheckedDate, Entity.CheckedDate);
            if(Entity.IdUsuarioChecked.HasValue)
    			UIHelper.SetValue<Usuario,int>(ddlUsuarioChecked, Entity.IdUsuarioChecked.Value,UsuarioService.Current.GetById);
        }	
        public override void GetValue()
        {
			Entity.Code =UIHelper.GetString(txtCode);
			Entity.Description =UIHelper.GetString(txtDescription);
			Entity.IdTextCategory =UIHelper.GetInt(ddlTextCategory);
			Entity.IsAutomaticLoad=UIHelper.GetBoolean(chkIsAutomaticLoad);
			Entity.StartDate =UIHelper.GetDateTime(diStartDate);
			Entity.Checked=UIHelper.GetBoolean(chkChecked);
			Entity.CheckedDate =UIHelper.GetDateTimeNullable(diCheckedDate);
			Entity.IdUsuarioChecked =UIHelper.GetIntNullable(ddlUsuarioChecked);
				
        }
    }
}
