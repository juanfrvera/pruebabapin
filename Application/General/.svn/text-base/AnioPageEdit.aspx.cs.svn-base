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
	public partial class AnioPageEdit : PageEdit<nc.Anio ,nc.AnioFilter, nc.AnioResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editAnio;
            webControlEditionButtons = this.editButtons;
            PathListPage = "AnioPageList.aspx";            
            base._Load();
        }
		protected AnioService Service
		{
			get { return AnioService.Current; }
		}
		protected override IEntityService<nc.Anio, nc.AnioFilter, nc.AnioResult, int> EntityService
		{
			get { return AnioService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
