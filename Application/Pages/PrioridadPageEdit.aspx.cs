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
	public partial class PrioridadPageEdit : PageEdit<nc.Prioridad ,nc.PrioridadFilter, nc.PrioridadResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPrioridad;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PrioridadPageList.aspx";            
            base._Load();
        }
		protected PrioridadService Service
		{
			get { return PrioridadService.Current; }
		}
		protected override IEntityService<nc.Prioridad, nc.PrioridadFilter, nc.PrioridadResult, int> EntityService
		{
			get { return PrioridadService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
