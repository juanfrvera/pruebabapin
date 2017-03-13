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
    public partial class FaseEdit : WebControlEdit<nc.Fase>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(2);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtOrden);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Orden=UIHelper.GetInt(txtOrden);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
