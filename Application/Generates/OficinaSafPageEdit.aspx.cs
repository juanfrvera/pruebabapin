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
	public partial class OficinaSafPageEdit : PageEdit<nc.OficinaSaf ,nc.OficinaSafFilter, nc.OficinaSafResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOficinaSaf;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OficinaSafPageList.aspx";            
            base._Load();
        }
		protected OficinaSafService Service
		{
			get { return OficinaSafService.Current; }
		}
		protected override IEntityService<nc.OficinaSaf, nc.OficinaSafFilter, nc.OficinaSafResult, int> EntityService
		{
			get { return OficinaSafService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
