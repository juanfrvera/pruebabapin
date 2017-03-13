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
	public partial class SubJurisdiccionPageEdit : PageEdit<nc.SubJurisdiccion ,nc.SubJurisdiccionFilter, nc.SubJurisdiccionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSubJurisdiccion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SubJurisdiccionPageList.aspx";            
            base._Load();
        }
		protected SubJurisdiccionService Service
		{
			get { return SubJurisdiccionService.Current; }
		}
		protected override IEntityService<nc.SubJurisdiccion, nc.SubJurisdiccionFilter, nc.SubJurisdiccionResult, int> EntityService
		{
			get { return SubJurisdiccionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
