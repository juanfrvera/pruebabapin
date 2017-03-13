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
    public partial class SistemaEntidadEstadoEdit : WebControlEdit<nc.SistemaEntidadEstado>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(new nc.SistemaEntidadFilter() { Activo = true }), "Nombre", "IdSistemaEntidad", new nc.SistemaEntidad() { IdSistemaEntidad = 0, Nombre = "Seleccione SistemaEntidad" });
            UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true }), "Nombre", "IdEstado", new nc.Estado() { IdEstado = 0, Nombre = "Seleccione Estado" });
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(100);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            rfvSistemaEntidad.ErrorMessage = TranslateFormat("FieldIsNull", "Sistema Entidad");

			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlSistemaEntidad);
			ddlSistemaEntidad.Focus();
				UIHelper.Clear(ddlEstado);
			UIHelper.Clear(txtNombre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue<SistemaEntidad,int>(ddlSistemaEntidad, Entity.IdSistemaEntidad, SistemaEntidadService.Current.GetById);
			ddlSistemaEntidad.Focus();
				UIHelper.SetValue<Estado,int>(ddlEstado, Entity.IdEstado,EstadoService.Current.GetById );
			UIHelper.SetValue(txtNombre, Entity.Nombre);
				
        }	
        public override void GetValue()
        {
			Entity.IdSistemaEntidad =UIHelper.GetInt(ddlSistemaEntidad);
			Entity.IdEstado =UIHelper.GetInt(ddlEstado);
			Entity.Nombre =UIHelper.GetString(txtNombre);
				
        }
    }
}
