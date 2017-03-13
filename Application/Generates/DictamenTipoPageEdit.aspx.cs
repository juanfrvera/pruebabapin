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
	public partial class DictamenTipoPageEdit : PageEdit<nc.DictamenTipo ,nc.DictamenTipoFilter, nc.DictamenTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editDictamenTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "DictamenTipoPageList.aspx";            
            base._Load();
        }
		protected DictamenTipoService Service
		{
			get { return DictamenTipoService.Current; }
		}
		protected override IEntityService<nc.DictamenTipo, nc.DictamenTipoFilter, nc.DictamenTipoResult, int> EntityService
		{
			get { return DictamenTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
