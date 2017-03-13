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
	public partial class SectorPageEdit : PageEdit<nc.Sector ,nc.SectorFilter, nc.SectorResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSector;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SectorPageList.aspx";            
            base._Load();
        }
		protected SectorService Service
		{
			get { return SectorService.Current; }
		}
		protected override IEntityService<nc.Sector, nc.SectorFilter, nc.SectorResult, int> EntityService
		{
			get { return SectorService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
