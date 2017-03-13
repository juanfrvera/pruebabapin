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
	public partial class JurisdiccionPageEdit : PageEdit<nc.Jurisdiccion ,nc.JurisdiccionFilter, nc.JurisdiccionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editJurisdiccion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "JurisdiccionPageList.aspx";            
            base._Load();
        }
		protected JurisdiccionService Service
		{
			get { return JurisdiccionService.Current; }
		}
		protected override IEntityService<nc.Jurisdiccion, nc.JurisdiccionFilter, nc.JurisdiccionResult, int> EntityService
		{
			get { return JurisdiccionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
