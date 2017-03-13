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
	public partial class ProgramaPageEdit : PageEdit<nc.ProgramaCompose ,nc.ProgramaFilter, nc.ProgramaResult, int>
    {	
		#region Override      
		protected override void _Load()
        {
            webControlEdit = this.editPrograma;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProgramaPageList.aspx";            
            base._Load();
        }
		protected ProgramaService Service
		{
			get { return ProgramaService.Current; }
		}
        protected override IEntityService<nc.ProgramaCompose, nc.ProgramaFilter, nc.ProgramaResult, int> EntityService
		{
			get { return ProgramaComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        
		#endregion
	}
}
