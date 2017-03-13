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
    public partial class SubConvenioTipoEdit : WebControlEdit<nc.SubConvenioTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
