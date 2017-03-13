using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc=Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{    
	public partial class ComentarioTecnicoPageEdit : PageEdit<nc.ComentarioTecnico ,nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editComentarioTecnico;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ComentarioTecnicoPageList.aspx";            
            base._Load();
        }
		protected ComentarioTecnicoService Service
		{
			get { return ComentarioTecnicoService.Current; }
		}
		protected override IEntityService<nc.ComentarioTecnico, nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int> EntityService
		{
			get { return ComentarioTecnicoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
