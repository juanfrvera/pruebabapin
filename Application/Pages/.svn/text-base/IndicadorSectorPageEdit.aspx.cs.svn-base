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
	public partial class IndicadorSectorPageEdit : PageEdit<nc.IndicadorSector ,nc.IndicadorSectorFilter, nc.IndicadorSectorResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editIndicadorSector;
            webControlEditionButtons = this.editButtons;
            PathListPage = "IndicadorSectorPageList.aspx";            
            base._Load();
        }
		protected IndicadorSectorService Service
		{
			get { return IndicadorSectorService.Current; }
		}
		protected override IEntityService<nc.IndicadorSector, nc.IndicadorSectorFilter, nc.IndicadorSectorResult, int> EntityService
		{
			get { return IndicadorSectorService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
