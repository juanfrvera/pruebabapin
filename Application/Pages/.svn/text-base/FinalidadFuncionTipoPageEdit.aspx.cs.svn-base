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
	public partial class FinalidadFuncionTipoPageEdit : PageEdit<nc.FinalidadFuncionTipo ,nc.FinalidadFuncionTipoFilter, nc.FinalidadFuncionTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editFinalidadFuncionTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "FinalidadFuncionTipoPageList.aspx";            
            base._Load();
        }
		protected FinalidadFuncionTipoService Service
		{
			get { return FinalidadFuncionTipoService.Current; }
		}
		protected override IEntityService<nc.FinalidadFuncionTipo, nc.FinalidadFuncionTipoFilter, nc.FinalidadFuncionTipoResult, int> EntityService
		{
			get { return FinalidadFuncionTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
