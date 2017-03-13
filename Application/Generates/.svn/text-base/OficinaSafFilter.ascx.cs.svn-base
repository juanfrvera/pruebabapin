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
    public partial class OficinaSafFilter : WebControlFilter<nc.OficinaSafFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Oficina>(ddlOficina, OficinaService.Current.GetList(),"Nombre","IdOficina",new nc.Oficina(){IdOficina=0, Nombre= "Seleccione Oficina"});
			UIHelper.Load<nc.Saf>(ddlSaf, SafService.Current.GetList(),"Codigo","IdSaf",new nc.Saf(){IdSaf=0, Codigo= "Seleccione Saf"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlOficina);
			ddlOficina.Focus();
				UIHelper.Clear(ddlSaf);
				
        }		
		protected override void SetValue()
        {ddlOficina.Focus();
					
        }	
        protected override void GetValue()
        {
			Filter.IdOficina =UIHelper.GetIntNullable(ddlOficina);
			Filter.IdSaf =UIHelper.GetIntNullable(ddlSaf);
				
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
