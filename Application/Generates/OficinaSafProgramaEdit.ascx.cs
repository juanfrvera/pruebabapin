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
    public partial class OficinaSafProgramaEdit : WebControlEdit<nc.OficinaSafPrograma>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			//UIHelper.Load<nc.OficinaSaf>(ddlOficinaSaf, OficinaSafService.Current.GetList(),"IdOficinaSaf","IdOficinaSaf",new nc.OficinaSaf(){IdOficinaSaf=0, IdOficinaSaf= "Seleccione OficinaSaf"});
			UIHelper.Load<nc.Programa>(ddlPrograma, ProgramaService.Current.GetList(),"Nombre","IdPrograma",new nc.Programa(){IdPrograma=0, Nombre= "Seleccione Programa"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlOficinaSaf);
			ddlOficinaSaf.Focus();
				UIHelper.Clear(ddlPrograma);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlOficinaSaf, Entity.IdOficinaSaf);
			ddlOficinaSaf.Focus();
				UIHelper.SetValue(ddlPrograma, Entity.IdPrograma);
				
        }	
        public override void GetValue()
        {
			Entity.IdOficinaSaf =UIHelper.GetInt(ddlOficinaSaf);
			Entity.IdPrograma =UIHelper.GetInt(ddlPrograma);
				
        }
    }
}
