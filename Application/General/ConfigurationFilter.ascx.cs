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
    public partial class ConfigurationFilter : WebControlFilter<nc.ConfigurationFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
			revCode.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revDescription.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
            revCode.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revDescription.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
			UIHelper.Load<nc.ConfigurationCategory>(ddlConfigurationCategory, ConfigurationCategoryService.Current.GetList(),"Name","IdConfigurationCategory",new nc.ConfigurationCategory(){IdConfigurationCategory=0, Name= "Seleccione uno"});
			UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione uno"});
			UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(),"Nombre","IdEstado",new nc.Estado(){IdEstado=0, Nombre= "Seleccione Estado"});
			
		}
		protected override void Clear()
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
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtName, Filter.Name);
						txtName.Focus();
				UIHelper.SetValueFilter(txtCode, Filter.Code);
                UIHelper.SetValue(ddlConfigurationCategory, Filter.IdConfigurationCategory);
                UIHelper.SetValue(ddlSistemaEntidad, Filter.IdSistemaEntidad);
                UIHelper.SetValue(ddlEstado, Filter.IdEstado);
				UIHelper.SetValueFilter(txtDescription, Filter.Description);
				UIHelper.SetValue(chkActive, Filter.Active);
							
        }	
        protected override void GetValue()
        {
            Filter.Name = UIHelper.GetStringBetweenFilter(txtName);
            Filter.Code = UIHelper.GetStringBetweenFilter(txtCode);
            Filter.Description = UIHelper.GetStringBetweenFilter(txtDescription);
			Filter.IdConfigurationCategory =UIHelper.GetIntNullable(ddlConfigurationCategory);
			Filter.Active=UIHelper.GetBooleanNullable(chkActive);			  
			Filter.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
			Filter.IdEstado =UIHelper.GetIntNullable(ddlEstado);

        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
