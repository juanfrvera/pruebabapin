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
    public partial class ProyectoGeoreferenciacionFilter : WebControlFilter<nc.ProyectoGeoreferenciacionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Proyecto>(ddlProyecto, ProyectoService.Current.GetList(),"ProyectoDenominacion","IdProyecto",new nc.Proyecto(){IdProyecto=0, ProyectoDenominacion= "Seleccione Proyecto"});
			//UIHelper.Load<nc.Georeferenciacion>(ddlGeoreferenciacion, GeoreferenciacionService.Current.GetList(),"IdGeoreferenciacion","IdGeoreferenciacion",new nc.Georeferenciacion(){IdGeoreferenciacion=0, IdGeoreferenciacion= "Seleccione Georeferenciacion"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlProyecto);
			ddlProyecto.Focus();
				UIHelper.Clear(ddlGeoreferenciacion);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValue(ddlProyecto, Filter.IdProyecto);
				ddlProyecto.Focus();
				UIHelper.SetValue(ddlGeoreferenciacion, Filter.IdGeoreferenciacion);
					
        }	
        protected override void GetValue()
        {
			Filter.IdProyecto =UIHelper.GetIntNullable(ddlProyecto);
			Filter.IdGeoreferenciacion =UIHelper.GetIntNullable(ddlGeoreferenciacion);
				
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
