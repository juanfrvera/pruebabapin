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
    public partial class OficinaSafEdit : WebControlEdit<nc.OficinaSaf>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Oficina>(ddlOficina, OficinaService.Current.GetList(),"Nombre","IdOficina",new nc.Oficina(){IdOficina=0, Nombre= "Seleccione Oficina"});
			UIHelper.Load<nc.Saf>(ddlSaf, SafService.Current.GetList(),"Codigo","IdSaf",new nc.Saf(){IdSaf=0, Codigo= "Seleccione Saf"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlOficina);
			ddlOficina.Focus();
				UIHelper.Clear(ddlSaf);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlOficina, Entity.IdOficina);
			ddlOficina.Focus();
				UIHelper.SetValue(ddlSaf, Entity.IdSaf);
				
        }	
        public override void GetValue()
        {
			Entity.IdOficina =UIHelper.GetInt(ddlOficina);
			Entity.IdSaf =UIHelper.GetInt(ddlSaf);
				
        }
    }
}
