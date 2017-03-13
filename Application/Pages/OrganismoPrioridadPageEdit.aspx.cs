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
	public partial class OrganismoPrioridadPageEdit : PageEdit<nc.OrganismoPrioridad ,nc.OrganismoPrioridadFilter, nc.OrganismoPrioridadResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOrganismoPrioridad;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OrganismoPrioridadPageList.aspx";            
            base._Load();
        }
		protected OrganismoPrioridadService Service
		{
			get { return OrganismoPrioridadService.Current; }
		}
		protected override IEntityService<nc.OrganismoPrioridad, nc.OrganismoPrioridadFilter, nc.OrganismoPrioridadResult, int> EntityService
		{
			get { return OrganismoPrioridadService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
