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
	public partial class FasePageEdit : PageEdit<nc.Fase ,nc.FaseFilter, nc.FaseResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editFase;
            webControlEditionButtons = this.editButtons;
            PathListPage = "FasePageList.aspx";            
            base._Load();
        }
		protected FaseService Service
		{
			get { return FaseService.Current; }
		}
		protected override IEntityService<nc.Fase, nc.FaseFilter, nc.FaseResult, int> EntityService
		{
			get { return FaseService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
