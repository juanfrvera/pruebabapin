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
	public partial class ProyectoComentarioTecnicoPageEdit : PageEdit<nc.ProyectoComentarioTecnico,nc.ProyectoComentarioTecnicoFilter, nc.ProyectoComentarioTecnicoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProyectoComentarioTecnico;
            webControlEditionButtons = this.editButtons;
            this.editButtons.SetApplyButtonAsDefault();
            PathListPage = "ProyectoPageList.aspx";     
            base._Load();
            
        }
		protected ProyectoComentarioTecnicoService Service
		{
			get { return ProyectoComentarioTecnicoService.Current; }
		}
		protected override IEntityService<nc.ProyectoComentarioTecnico, nc.ProyectoComentarioTecnicoFilter, nc.ProyectoComentarioTecnicoResult, int> EntityService
		{
			get { return ProyectoComentarioTecnicoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
