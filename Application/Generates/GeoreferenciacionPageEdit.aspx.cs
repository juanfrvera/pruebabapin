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
	public partial class GeoreferenciacionPageEdit : PageEdit<nc.Georeferenciacion ,nc.GeoreferenciacionFilter, nc.GeoreferenciacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editGeoreferenciacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "GeoreferenciacionPageList.aspx";            
            base._Load();
        }
		protected GeoreferenciacionService Service
		{
			get { return GeoreferenciacionService.Current; }
		}
		protected override IEntityService<nc.Georeferenciacion, nc.GeoreferenciacionFilter, nc.GeoreferenciacionResult, int> EntityService
		{
			get { return GeoreferenciacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
