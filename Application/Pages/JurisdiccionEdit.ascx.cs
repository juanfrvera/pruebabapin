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
    public partial class JurisdiccionEdit : WebControlEdit<nc.Jurisdiccion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(15);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(120);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
