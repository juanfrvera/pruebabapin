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
    public partial class ProyectoTipoEdit : WebControlEdit<nc.ProyectoTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            ddlTipo.Items.Add("Seleccione Tipo");
            ddlTipo.Items.Add("I");
            ddlTipo.Items.Add("T");
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(ddlTipo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			txtSigla.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
            if (Entity.Tipo != "")
            {
                UIHelper.SetValue(ddlTipo, Entity.Tipo);
            }
				
        }	
        public override void GetValue()
        {
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            if (ddlTipo.SelectedIndex != 0)
            {
                Entity.Tipo = UIHelper.GetString(ddlTipo);
            }
        }
    }
}
