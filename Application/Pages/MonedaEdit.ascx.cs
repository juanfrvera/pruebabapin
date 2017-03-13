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
    public partial class MonedaEdit : WebControlEdit<nc.Moneda>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(5);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(20);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(chkBase);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			txtSigla.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
			UIHelper.SetValue(chkBase, Entity.Base);
				
        }	
        public override void GetValue()
        {
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
			Entity.Base=UIHelper.GetBoolean(chkBase);
				
        }
    }
}
