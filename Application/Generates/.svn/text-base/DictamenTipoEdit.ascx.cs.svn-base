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
    public partial class DictamenTipoEdit : WebControlEdit<nc.DictamenTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
			revNivel.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(txtNivel);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			txtNombre.Focus();
				UIHelper.SetValue(txtNivel, Entity.Nivel);
				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Nivel=UIHelper.GetInt(txtNivel);
				
        }
    }
}
