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
    public partial class PerfilActividadEdit : WebControlEdit<nc.PerfilActividad>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Perfil>(ddlPerfil, PerfilService.Current.GetList(new nc.PerfilFilter() { Activo = true}),"Nombre","IdPerfil",new nc.Perfil(){IdPerfil=0, Nombre= "Seleccione Perfil"});
			UIHelper.Load<nc.Actividad>(ddlActividad, ActividadService.Current.GetList(new nc.ActividadFilter() { Activo = true}),"Nombre","IdActividad",new nc.Actividad(){IdActividad=0, Nombre= "Seleccione Actividad"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlPerfil);
			ddlPerfil.Focus();
				UIHelper.Clear(ddlActividad);
				
        }		
		public override void SetValue()
        {
            UIHelper.SetValue<Perfil, int>(ddlPerfil,Entity.IdPerfil, PerfilService.Current.GetById);
            UIHelper.SetValue<Actividad, int>(ddlActividad, Entity.IdActividad, ActividadService.Current.GetById);
			ddlPerfil.Focus();
				
        }	
        public override void GetValue()
        {
			Entity.IdPerfil =UIHelper.GetInt(ddlPerfil);
			Entity.IdActividad =UIHelper.GetInt(ddlActividad);
				
        }
    }
}
