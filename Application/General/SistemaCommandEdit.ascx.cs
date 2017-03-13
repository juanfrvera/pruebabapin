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
    public partial class SistemaCommandEdit : WebControlEdit<nc.SistemaCommand>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
			  revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			  rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			revDescripcion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(250);
			  revDescripcion.ErrorMessage = TranslateFormat("InvalidField", "Descripcion");
			UIHelper.Load<nc.SistemaEntidad>(ddlsistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione SistemaEntidad"});
			revCommandText.ValidationExpression=Contract.DataHelper.GetExpRegString(2000);
			  revCommandText.ErrorMessage = TranslateFormat("InvalidField", "CommandText");
			  rfvCommandText.ErrorMessage = TranslateFormat("FieldIsNull", "CommandText");		
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(txtDescripcion);
			UIHelper.Clear(ddlsistemaEntidad);
			UIHelper.Clear(txtCommandText);
			UIHelper.Clear(chkActivo);				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			txtNombre.Focus();
				UIHelper.SetValue(txtDescripcion, Entity.Descripcion);
			UIHelper.SetValue(ddlsistemaEntidad, Entity.IdsistemaEntidad);
			UIHelper.SetValue(txtCommandText, Entity.CommandText);
			UIHelper.SetValue(chkActivo, Entity.Activo);				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Descripcion =UIHelper.GetString(txtDescripcion);
			Entity.IdsistemaEntidad =UIHelper.GetInt(ddlsistemaEntidad);
			Entity.CommandText =UIHelper.GetString(txtCommandText);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
            Entity.CommandType = 1;	
        }
    }
}
