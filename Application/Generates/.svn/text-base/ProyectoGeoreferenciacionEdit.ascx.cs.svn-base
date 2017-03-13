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
    public partial class ProyectoGeoreferenciacionEdit : WebControlEdit<nc.ProyectoGeoreferenciacion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Proyecto>(ddlProyecto, ProyectoService.Current.GetList(),"ProyectoDenominacion","IdProyecto",new nc.Proyecto(){IdProyecto=0, ProyectoDenominacion= "Seleccione Proyecto"});
			//UIHelper.Load<nc.Georeferenciacion>(ddlGeoreferenciacion, GeoreferenciacionService.Current.GetList(),"IdGeoreferenciacion","IdGeoreferenciacion",new nc.Georeferenciacion(){IdGeoreferenciacion=0, IdGeoreferenciacion= "Seleccione Georeferenciacion"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlProyecto);
			ddlProyecto.Focus();
				UIHelper.Clear(ddlGeoreferenciacion);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlProyecto, Entity.IdProyecto);
			ddlProyecto.Focus();
				UIHelper.SetValue(ddlGeoreferenciacion, Entity.IdGeoreferenciacion);
				
        }	
        public override void GetValue()
        {
			Entity.IdProyecto =UIHelper.GetInt(ddlProyecto);
			Entity.IdGeoreferenciacion =UIHelper.GetInt(ddlGeoreferenciacion);
				
        }
    }
}
