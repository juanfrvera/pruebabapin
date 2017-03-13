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
	public partial class NumerationPageEdit : PageEdit<nc.Numeration ,nc.NumerationFilter, nc.NumerationResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editNumeration;
            webControlEditionButtons = this.editButtons;
            PathListPage = "NumerationPageList.aspx";            
            base._Load();
        }
		protected NumerationService Service
		{
			get { return NumerationService.Current; }
		}
		protected override IEntityService<nc.Numeration, nc.NumerationFilter, nc.NumerationResult, int> EntityService
		{
			get { return NumerationService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
