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
	public partial class PersonaPageEdit : PageEdit<nc.PersonaCompose ,nc.PersonaFilter, nc.PersonaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
           
            webControlEdit = this.editPersona;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PersonaPageList.aspx";            
            base._Load();
        }
		protected PersonaService Service
		{
			get { return PersonaService.Current; }
		}
		protected override IEntityService<nc.PersonaCompose, nc.PersonaFilter, nc.PersonaResult, int> EntityService
		{
			get { return PersonaComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        
        #endregion
	}
}
