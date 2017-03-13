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
    public partial class UsuarioEdit : WebControlEdit<nc.Usuario>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdUsuario.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombreUsuario.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revClave.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revIdUsuario.ErrorMessage = TranslateFormat("InvalidField", "Id Usuario");
            revNombreUsuario.ErrorMessage = TranslateFormat("InvalidField", "Nombre Usuario");
            revClave.ErrorMessage = TranslateFormat("InvalidField", "Clave");
            rfvNombreUsuario.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre Usuario");
            rfvClave.ErrorMessage = TranslateFormat("FieldIsNull", "Clave");
			UIHelper.Load<nc.Language>(ddlLanguage, LanguageService.Current.GetList(),"Name","IdLanguage",new nc.Language(){IdLanguage=0, Name= "Seleccione Language"});
			


		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdUsuario);
			txtIdUsuario.Focus();
				UIHelper.Clear(txtNombreUsuario);
			UIHelper.Clear(txtClave);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(chkEsSectioralista);
			UIHelper.Clear(ddlLanguage);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdUsuario, Entity.IdUsuario);
			txtIdUsuario.Focus();
				UIHelper.SetValue(txtNombreUsuario, Entity.NombreUsuario);
			UIHelper.SetValue(txtClave, Entity.Clave);
			UIHelper.SetValue(chkActivo, Entity.Activo);
			UIHelper.SetValue(chkEsSectioralista, Entity.EsSectioralista);
			UIHelper.SetValue(ddlLanguage, Entity.IdLanguage);
				
        }	
        public override void GetValue()
        {
			Entity.IdUsuario=UIHelper.GetInt(txtIdUsuario);
			Entity.NombreUsuario =UIHelper.GetString(txtNombreUsuario);
			Entity.Clave =UIHelper.GetString(txtClave);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
			Entity.EsSectioralista=UIHelper.GetBoolean(chkEsSectioralista);
			Entity.IdLanguage =UIHelper.GetInt(ddlLanguage);
				
        }
    }
}
