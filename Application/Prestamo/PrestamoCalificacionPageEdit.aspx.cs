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
	public partial class PrestamoCalificacionPageEdit : PageEdit<nc.PrestamoCalificacion ,nc.PrestamoCalificacionFilter, nc.PrestamoCalificacionResult, int>
    {	
		#region Override
        protected override void _SetParameters()
        {
            PathListPage = "PrestamoPageList.aspx";
            EditFilter = "PrestamoFilter";
            base._SetParameters();
        }
		protected override void _Load()
        {
            webControlEdit = this.editPrestamoCalificacion;
            webControlEditionButtons = this.editButtons;           
            base._Load();
        }
		protected PrestamoCalificacionService Service
		{
			get { return PrestamoCalificacionService.Current; }
		}
		protected override IEntityService<nc.PrestamoCalificacion, nc.PrestamoCalificacionFilter, nc.PrestamoCalificacionResult, int> EntityService
		{
			get { return PrestamoCalificacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
