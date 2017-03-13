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
    public partial class PerfilTipoEdit : WebControlEdit<nc.PerfilTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdPerfilTipo.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
            revIdPerfilTipo.ErrorMessage = TranslateFormat("InvalidField", "Id Perfil Tipo");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdPerfilTipo);
			txtIdPerfilTipo.Focus();
				UIHelper.Clear(txtNombre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdPerfilTipo, Entity.IdPerfilTipo);
			txtIdPerfilTipo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
				
        }	
        public override void GetValue()
        {
			Entity.IdPerfilTipo=UIHelper.GetInt(txtIdPerfilTipo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
				
        }
    }
}
