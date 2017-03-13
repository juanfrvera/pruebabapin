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
    public partial class PerfilActividadFilter : WebControlFilter<nc.PerfilActividadFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Perfil>(ddlPerfil, PerfilService.Current.GetList(),"Nombre","IdPerfil",new nc.Perfil(){IdPerfil=0, Nombre= "Seleccione Perfil"});
			UIHelper.Load<nc.Actividad>(ddlActividad, ActividadService.Current.GetList(),"Nombre","IdActividad",new nc.Actividad(){IdActividad=0, Nombre= "Seleccione Actividad"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlPerfil);
			ddlPerfil.Focus();
				UIHelper.Clear(ddlActividad);
				
        }		
		protected override void SetValue()
        {ddlPerfil.Focus();
            UIHelper.SetValue(ddlPerfil, Filter.IdPerfil);
            UIHelper.SetValue(ddlActividad, Filter.IdActividad);
					
        }	
        protected override void GetValue()
        {
			Filter.IdPerfil =UIHelper.GetIntNullable(ddlPerfil);
			Filter.IdActividad =UIHelper.GetIntNullable(ddlActividad);

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
