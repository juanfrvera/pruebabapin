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
    public partial class OrganismoFinancieroEdit : WebControlEdit<nc.OrganismoFinanciero>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(8);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
		}
		public override void Clear()
        {			
            txtSigla.Focus();
				UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
            txtSigla.Focus();
				UIHelper.SetValue(txtSigla, Entity.Sigla);
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
