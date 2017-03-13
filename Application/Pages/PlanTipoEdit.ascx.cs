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
    public partial class PlanTipoEdit : WebControlEdit<nc.PlanTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(5);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtOrden);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			txtSigla.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Orden=UIHelper.GetInt(txtOrden);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
