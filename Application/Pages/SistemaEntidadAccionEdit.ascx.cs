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
    public partial class SistemaEntidadAccionEdit : WebControlEdit<nc.SistemaEntidadAccion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(new nc.SistemaEntidadFilter() { Activo = true }), "Nombre", "IdSistemaEntidad", new nc.SistemaEntidad() { IdSistemaEntidad = 0, Nombre = "Seleccione Sistema Entidad" });
            UIHelper.Load<nc.SistemaAccion>(ddlSistemaAccion, SistemaAccionService.Current.GetList(new nc.SistemaAccionFilter() { Activo = true }), "Nombre", "IdSistemaAccion", new nc.SistemaAccion() { IdSistemaAccion = 0, Nombre = "Seleccione Sistema Acción" });
            revNombre.ValidationExpression = Contract.DataHelper.GetExpRegString(100);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvSistemaAccion.ErrorMessage = TranslateFormat("FieldIsNull", "Sistema Acción");
            rfvSistemaEntidad.ErrorMessage = TranslateFormat("FieldIsNull", "Sistema Entidad");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlSistemaEntidad);
			ddlSistemaEntidad.Focus();
				UIHelper.Clear(ddlSistemaAccion);
			UIHelper.Clear(txtNombre);
				
        }		
		public override void SetValue()
        {			
			ddlSistemaEntidad.Focus();
                UIHelper.SetValue<SistemaEntidad, int>(ddlSistemaEntidad, Entity.IdSistemaEntidad, SistemaEntidadService.Current.GetById);
                UIHelper.SetValue<SistemaAccion, int>(ddlSistemaAccion, Entity.IdSistemaAccion, SistemaAccionService.Current.GetById);
				
			UIHelper.SetValue(txtNombre, Entity.Nombre);
				
        }	
        public override void GetValue()
        {
			Entity.IdSistemaEntidad =UIHelper.GetInt(ddlSistemaEntidad);
			Entity.IdSistemaAccion =UIHelper.GetInt(ddlSistemaAccion);
			Entity.Nombre =UIHelper.GetString(txtNombre);
				
        }
    }
}
