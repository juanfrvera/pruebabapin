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
	public partial class PrestamoEstadoPageEdit : PageEdit<nc.PrestamoEstado ,nc.PrestamoEstadoFilter, nc.PrestamoEstadoResult, int>
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
            webControlEdit = this.editPrestamoEstado;
            webControlEditionButtons = this.editButtons;            
            base._Load();
        }
		protected PrestamoEstadoService Service
		{
			get { return PrestamoEstadoService.Current; }
		}
		protected override IEntityService<nc.PrestamoEstado, nc.PrestamoEstadoFilter, nc.PrestamoEstadoResult, int> EntityService
		{
			get { return PrestamoEstadoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
