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
	public partial class MedioVerificacionPageEdit : PageEdit<nc.MedioVerificacion ,nc.MedioVerificacionFilter, nc.MedioVerificacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editMedioVerificacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "MedioVerificacionPageList.aspx";            
            base._Load();
        }
		protected MedioVerificacionService Service
		{
			get { return MedioVerificacionService.Current; }
		}
		protected override IEntityService<nc.MedioVerificacion, nc.MedioVerificacionFilter, nc.MedioVerificacionResult, int> EntityService
		{
			get { return MedioVerificacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
