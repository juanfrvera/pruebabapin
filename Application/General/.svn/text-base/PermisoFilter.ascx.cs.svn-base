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
    public partial class PermisoFilter : WebControlFilter<nc.PermisoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(70);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione SistemaEntidad"});
			UIHelper.Load<nc.SistemaAccion>(ddlSistemaAccion, SistemaAccionService.Current.GetList(),"Nombre","IdSistemaAccion",new nc.SistemaAccion(){IdSistemaAccion=0, Nombre= "Seleccione SistemaAccion"});
	//		UIHelper.Load<nc.Estado>(ddlSistemaEstado, EstadoService.Current.GetList(),"Nombre","IdEstado",new nc.Estado(){IdEstado=0, Nombre= "Seleccione Estado"});

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(ddlSistemaEntidad);
			UIHelper.Clear(ddlSistemaAccion);
	//		UIHelper.Clear(ddlSistemaEstado);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
				UIHelper.SetValue(chkActivo, Filter.Activo);
                UIHelper.SetValue(ddlSistemaEntidad, Filter.IdSistemaEntidad);
    //            UIHelper.SetValue(ddlSistemaEstado, Filter.IdSistemaEstado);
							
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
			Filter.IdSistemaAccion =UIHelper.GetIntNullable(ddlSistemaAccion);
	//		Filter.IdSistemaEstado =UIHelper.GetIntNullable(ddlSistemaEstado);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);

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
