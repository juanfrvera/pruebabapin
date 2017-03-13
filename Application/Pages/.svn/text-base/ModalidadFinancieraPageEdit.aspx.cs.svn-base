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
	public partial class ModalidadFinancieraPageEdit : PageEdit<nc.ModalidadFinanciera ,nc.ModalidadFinancieraFilter, nc.ModalidadFinancieraResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editModalidadFinanciera;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ModalidadFinancieraPageList.aspx";            
            base._Load();
        }
		protected ModalidadFinancieraService Service
		{
			get { return ModalidadFinancieraService.Current; }
		}
		protected override IEntityService<nc.ModalidadFinanciera, nc.ModalidadFinancieraFilter, nc.ModalidadFinancieraResult, int> EntityService
		{
			get { return ModalidadFinancieraService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
