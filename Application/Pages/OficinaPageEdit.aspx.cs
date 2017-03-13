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
	public partial class OficinaPageEdit : PageEdit<nc.OficinaCompose ,nc.OficinaFilter, nc.OficinaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOficina;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OficinaPageList.aspx";            
            base._Load();
        }
		protected OficinaService Service
		{
			get { return OficinaService.Current; }
		}
		protected override IEntityService<nc.OficinaCompose, nc.OficinaFilter, nc.OficinaResult, int> EntityService
		{
			get { return OficinaComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
