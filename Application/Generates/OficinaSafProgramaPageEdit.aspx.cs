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
	public partial class OficinaSafProgramaPageEdit : PageEdit<nc.OficinaSafPrograma ,nc.OficinaSafProgramaFilter, nc.OficinaSafProgramaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOficinaSafPrograma;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OficinaSafProgramaPageList.aspx";            
            base._Load();
        }
		protected OficinaSafProgramaService Service
		{
			get { return OficinaSafProgramaService.Current; }
		}
		protected override IEntityService<nc.OficinaSafPrograma, nc.OficinaSafProgramaFilter, nc.OficinaSafProgramaResult, int> EntityService
		{
			get { return OficinaSafProgramaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
