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
	public partial class PrestamoDictamenPageEdit : PageEdit<nc.PrestamoDictamen ,nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPrestamoDictamen;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PrestamoDictamenPageList.aspx";            
            base._Load();
        }
		protected PrestamoDictamenService Service
		{
			get { return PrestamoDictamenService.Current; }
		}
		protected override IEntityService<nc.PrestamoDictamen, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int> EntityService
		{
			get { return PrestamoDictamenService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
