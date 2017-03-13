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
	public partial class ModalidadContratacionPageEdit : PageEdit<nc.ModalidadContratacion ,nc.ModalidadContratacionFilter, nc.ModalidadContratacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editModalidadContratacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ModalidadContratacionPageList.aspx";            
            base._Load();
        }
		protected ModalidadContratacionService Service
		{
			get { return ModalidadContratacionService.Current; }
		}
		protected override IEntityService<nc.ModalidadContratacion, nc.ModalidadContratacionFilter, nc.ModalidadContratacionResult, int> EntityService
		{
			get { return ModalidadContratacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
