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
	public partial class FinalidadFuncionPageEdit : PageEdit<nc.FinalidadFuncion ,nc.FinalidadFuncionFilter, nc.FinalidadFuncionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editFinalidadFuncion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "FinalidadFuncionPageList.aspx";            
            base._Load();
        }
		protected FinalidadFuncionService Service
		{
			get { return FinalidadFuncionService.Current; }
		}
		protected override IEntityService<nc.FinalidadFuncion, nc.FinalidadFuncionFilter, nc.FinalidadFuncionResult, int> EntityService
		{
			get { return FinalidadFuncionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
