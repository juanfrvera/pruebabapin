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
    public partial class OficinaSafProgramaFilter : WebControlFilter<nc.OficinaSafProgramaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			//UIHelper.Load<nc.OficinaSaf>(ddlOficinaSaf, OficinaSafService.Current.GetList(),"IdOficinaSaf","IdOficinaSaf",new nc.OficinaSaf(){IdOficinaSaf=0, IdOficinaSaf= "Seleccione OficinaSaf"});
			UIHelper.Load<nc.Programa>(ddlPrograma, ProgramaService.Current.GetList(),"Nombre","IdPrograma",new nc.Programa(){IdPrograma=0, Nombre= "Seleccione Programa"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlOficinaSaf);
			ddlOficinaSaf.Focus();
				UIHelper.Clear(ddlPrograma);
				
        }		
		protected override void SetValue()
        {ddlOficinaSaf.Focus();
					
        }	
        protected override void GetValue()
        {
			Filter.IdOficinaSaf =UIHelper.GetIntNullable(ddlOficinaSaf);
			Filter.IdPrograma =UIHelper.GetIntNullable(ddlPrograma);
				
        }
		protected void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}
