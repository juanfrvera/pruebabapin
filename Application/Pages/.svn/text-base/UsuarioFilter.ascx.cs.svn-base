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
    public partial class UsuarioFilter : WebControlFilter<nc.UsuarioFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombreUsuario.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revClave.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNombreUsuario.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revClave.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.Language>(ddlLanguage, LanguageService.Current.GetList(),"Name","IdLanguage",new nc.Language(){IdLanguage=0, Name= "Seleccione Language"});

            chkActivo.CheckedValue = true;
        }
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombreUsuario);
			txtNombreUsuario.Focus();
				UIHelper.Clear(txtClave);
			chkActivo.CheckedValue = true;
			UIHelper.Clear(chkEsSectioralista);
			UIHelper.Clear(ddlLanguage);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombreUsuario, Filter.NombreUsuario);
						txtNombreUsuario.Focus();
				UIHelper.SetValueFilter(txtClave, Filter.Clave);
                UIHelper.SetValue(ddlLanguage, Filter.IdLanguage);
						UIHelper.SetValue(chkActivo, Filter.Activo);
						UIHelper.SetValue(chkEsSectioralista, Filter.EsSectioralista);
							
        }	
        protected override void GetValue()
        {
            Filter.NombreUsuario = UIHelper.GetStringBetweenFilter(txtNombreUsuario);
            Filter.Clave = UIHelper.GetStringBetweenFilter(txtClave);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.EsSectioralista=UIHelper.GetBooleanNullable(chkEsSectioralista);			  
			Filter.IdLanguage =UIHelper.GetIntNullable(ddlLanguage);

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
