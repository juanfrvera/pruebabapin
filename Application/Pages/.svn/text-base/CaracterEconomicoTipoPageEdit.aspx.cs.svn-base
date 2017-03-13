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
	public partial class CaracterEconomicoTipoPageEdit : PageEdit<nc.CaracterEconomicoTipo ,nc.CaracterEconomicoTipoFilter, nc.CaracterEconomicoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editCaracterEconomicoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "CaracterEconomicoTipoPageList.aspx";            
            base._Load();
        }
		protected CaracterEconomicoTipoService Service
		{
			get { return CaracterEconomicoTipoService.Current; }
		}
		protected override IEntityService<nc.CaracterEconomicoTipo, nc.CaracterEconomicoTipoFilter, nc.CaracterEconomicoTipoResult, int> EntityService
		{
			get { return CaracterEconomicoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
