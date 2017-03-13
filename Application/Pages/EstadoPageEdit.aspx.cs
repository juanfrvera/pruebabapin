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
	public partial class EstadoPageEdit : PageEdit<nc.Estado ,nc.EstadoFilter, nc.EstadoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editEstado;
            webControlEditionButtons = this.editButtons;
            PathListPage = "EstadoPageList.aspx";            
            base._Load();
        }
		protected EstadoService Service
		{
			get { return EstadoService.Current; }
		}
		protected override IEntityService<nc.Estado, nc.EstadoFilter, nc.EstadoResult, int> EntityService
		{
			get { return EstadoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
