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
	public partial class IndicadorClasePageEdit : PageEdit<nc.IndicadorClaseCompose ,nc.IndicadorClaseFilter, nc.IndicadorClaseResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editIndicadorClase;
            webControlEditionButtons = this.editButtons;
            PathListPage = "IndicadorClasePageList.aspx";            
            base._Load();
        }
		protected IndicadorClaseService Service
		{
			get { return IndicadorClaseService.Current; }
		}
		protected override IEntityService<nc.IndicadorClaseCompose, nc.IndicadorClaseFilter, nc.IndicadorClaseResult, int> EntityService
		{
			get { return IndicadorClaseComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
