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
    public partial class EstadoEdit : WebControlEdit<nc.Estado>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revCodigo.ValidationExpression = Contract.DataHelper.GetExpRegString(2);
            revDescripcion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
            revDescripcion.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
			
		}
		public override void Clear()
        {			
			txtNombre.Focus();
				UIHelper.Clear(txtNombre);
                UIHelper.Clear(txtCodigo);
			UIHelper.Clear(txtOrden);
			UIHelper.Clear(txtDescripcion);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			txtNombre.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
            UIHelper.SetValue(txtCodigo, Entity.Codigo);
			UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(txtDescripcion, Entity.Descripcion);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Orden=UIHelper.GetInt(txtOrden);
            Entity.Codigo = UIHelper.GetString(txtCodigo);
			Entity.Descripcion =UIHelper.GetString(txtDescripcion);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}
