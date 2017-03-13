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
    public partial class EstadoTipoEdit : WebControlEdit<nc.EstadoTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdTipoEstado.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdTipoEstado);
			txtIdTipoEstado.Focus();
				UIHelper.Clear(txtNombre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdTipoEstado, Entity.IdTipoEstado);
			txtIdTipoEstado.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
				
        }	
        public override void GetValue()
        {
			Entity.IdTipoEstado=UIHelper.GetInt(txtIdTipoEstado);
			Entity.Nombre =UIHelper.GetString(txtNombre);
				
        }
    }
}
