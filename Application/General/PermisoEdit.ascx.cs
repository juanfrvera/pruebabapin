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
    public partial class PermisoEdit : WebControlEdit<nc.Permiso>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
            revCodigo.ValidationExpression = Contract.DataHelper.GetExpRegString(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(new nc.SistemaEntidadFilter() { Activo = true }), "Nombre", "IdSistemaEntidad", new nc.SistemaEntidad() { IdSistemaEntidad = 0, Nombre = "Seleccione Sistema Entidad" });
            //UIHelper.Load<nc.SistemaAccion>(ddlSistemaAccion, SistemaAccionService.Current.GetList(new nc.SistemaAccionFilter() {Activo = true}),"Nombre","IdSistemaAccion",new nc.SistemaAccion(){IdSistemaAccion=0, Nombre= "Seleccione Sistema Acción"});
            //UIHelper.Load<nc.SistemaEntidadEstado>(ddlSistemaEstado, SistemaEntidadEstadoService.Current.GetList(new nc.SistemaEntidadEstadoFilter() { Activo = true }), "Nombre", "IdSistemaEntidadEstado", new nc.SistemaEntidadEstado() { IdSistemaEntidadEstado = 0, Nombre = "Seleccione Sistema Estado" });
        }
		public override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(ddlSistemaEntidad);
            //UIHelper.Clear(ddlSistemaAccion);
            //UIHelper.Clear(ddlSistemaEstado);
            UIHelper.Clear(chkActivo);
            UIHelper.Clear(txtCodigo);	
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			txtNombre.Focus();
            if(Entity.IdSistemaEntidad.HasValue)
               UIHelper.SetValue<SistemaEntidad, int>(ddlSistemaEntidad, Entity.IdSistemaEntidad.Value, SistemaEntidadService.Current.GetById);
            //if (Entity.IdSistemaAccion.HasValue)
            //    UIHelper.SetValue<SistemaAccion, int>(ddlSistemaAccion, Entity.IdSistemaAccion.Value, SistemaAccionService.Current.GetById);
            //if (Entity.IdSistemaEstado.HasValue)
            //    UIHelper.SetValue<SistemaEntidadEstado, int>(ddlSistemaEstado, Entity.IdSistemaEstado.Value, SistemaEntidadEstadoService.Current.GetById);
            UIHelper.SetValue(chkActivo, Entity.Activo);
            UIHelper.SetValue(txtCodigo, Entity.Codigo);	
				
        }	
        public override void GetValue()
        {
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
            //Entity.IdSistemaAccion =UIHelper.GetIntNullable(ddlSistemaAccion);
            //Entity.IdSistemaEstado =UIHelper.GetIntNullable(ddlSistemaEstado);
            Entity.Activo = UIHelper.GetBoolean(chkActivo);
            Entity.Codigo = UIHelper.GetString(txtCodigo);
        }
    }
}
