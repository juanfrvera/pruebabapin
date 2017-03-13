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
	public partial class CaracterEconomicoPageEdit : PageEdit<nc.CaracterEconomico ,nc.CaracterEconomicoFilter, nc.CaracterEconomicoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editCaracterEconomico;
            webControlEditionButtons = this.editButtons;
            PathListPage = "CaracterEconomicoPageList.aspx";            
            base._Load();
        }
		protected CaracterEconomicoService Service
		{
			get { return CaracterEconomicoService.Current; }
		}
		protected override IEntityService<nc.CaracterEconomico, nc.CaracterEconomicoFilter, nc.CaracterEconomicoResult, int> EntityService
		{
			get { return CaracterEconomicoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
