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
    public partial class SistemaAccionEdit : WebControlEdit<nc.SistemaAccion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
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
            UIHelper.Clear(chkIncluirEstado);
            UIHelper.Clear(chkEsLectura);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(chkIncluirEstado, Entity.IncluirEstado);
            UIHelper.SetValue(chkEsLectura, Entity.EsLectura);
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.IncluirEstado = UIHelper.GetBoolean(chkIncluirEstado);
            Entity.EsLectura = UIHelper.GetBoolean(chkEsLectura);				
        }
    }
}
