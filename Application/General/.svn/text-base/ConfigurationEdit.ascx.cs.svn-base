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
    public partial class ConfigurationEdit : WebControlEdit<nc.Configuration>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegString(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvCode.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvName.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			UIHelper.Load<nc.ConfigurationCategory>(ddlConfigurationCategory, ConfigurationCategoryService.Current.GetList(),"Name","IdConfigurationCategory",new nc.ConfigurationCategory(){IdConfigurationCategory=0, Name= "Seleccione uno"});
            UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(new nc.SistemaEntidadFilter() { Activo = true }), "Nombre", "IdSistemaEntidad", new nc.SistemaEntidad() { IdSistemaEntidad = 0, Nombre = "Seleccione uno" });
            UIHelper.Load<nc.EstadoResult>(ddlEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true}), "Nombre", "IdEstado", new nc.EstadoResult() { IdEstado = 0, Nombre = "Seleccione Estado" });
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtName);
			txtName.Focus();
				UIHelper.Clear(txtCode);
			UIHelper.Clear(txtDescription);
			UIHelper.Clear(ddlConfigurationCategory);
			UIHelper.Clear(chkActive);
			UIHelper.Clear(ddlSistemaEntidad);
			UIHelper.Clear(ddlEstado);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtName, Entity.Name);
			txtName.Focus();
				UIHelper.SetValue(txtCode, Entity.Code);
			UIHelper.SetValue(txtDescription, Entity.Description);
			UIHelper.SetValue(ddlConfigurationCategory, Entity.IdConfigurationCategory);
			UIHelper.SetValue(chkActive, Entity.Active);
            if(Entity.IdSistemaEntidad.HasValue)
    			UIHelper.SetValue<SistemaEntidad,int>(ddlSistemaEntidad, Entity.IdSistemaEntidad.Value, SistemaEntidadService.Current.GetById);
			if(Entity.IdEstado.HasValue)
                UIHelper.SetValue<Estado,int>(ddlEstado, Entity.IdEstado.Value, EstadoService.Current.GetById);
            if(Entity.IdSistemaEntidad.HasValue)
                UIHelper.SetValue<SistemaEntidad, int>(ddlSistemaEntidad, Entity.IdSistemaEntidad.Value, SistemaEntidadService.Current.GetById);
            if(Entity.IdEstado.HasValue)
                UIHelper.SetValue<Estado, int>(ddlEstado, Entity.IdEstado.Value, EstadoService.Current.GetById);
				
        }	
        public override void GetValue()
        {
			Entity.Name =UIHelper.GetString(txtName);
			Entity.Code =UIHelper.GetString(txtCode);
			Entity.Description =UIHelper.GetString(txtDescription);
			Entity.IdConfigurationCategory =UIHelper.GetInt(ddlConfigurationCategory);
			Entity.Active=UIHelper.GetBoolean(chkActive);
			Entity.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
			Entity.IdEstado =UIHelper.GetIntNullable(ddlEstado);
				
        }
    }
}
