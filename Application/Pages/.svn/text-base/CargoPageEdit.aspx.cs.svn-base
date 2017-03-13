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
	public partial class CargoPageEdit : PageEdit<nc.Cargo ,nc.CargoFilter, nc.CargoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editCargo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "CargoPageList.aspx";            
            base._Load();
        }
		protected CargoService Service
		{
			get { return CargoService.Current; }
		}
		protected override IEntityService<nc.Cargo, nc.CargoFilter, nc.CargoResult, int> EntityService
		{
			get { return CargoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
