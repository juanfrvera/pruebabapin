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
	public partial class SistemaCommandPageEdit : PageEdit<nc.SistemaCommand ,nc.SistemaCommandFilter, nc.SistemaCommandResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSistemaCommand;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SistemaCommandPageList.aspx";            
            base._Load();
        }
		protected SistemaCommandService Service
		{
			get { return SistemaCommandService.Current; }
		}
		protected override IEntityService<nc.SistemaCommand, nc.SistemaCommandFilter, nc.SistemaCommandResult, int> EntityService
		{
			get { return SistemaCommandService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
