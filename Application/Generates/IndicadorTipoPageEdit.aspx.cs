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
	public partial class IndicadorTipoPageEdit : PageEdit<nc.IndicadorTipo ,nc.IndicadorTipoFilter, nc.IndicadorTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editIndicadorTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "IndicadorTipoPageList.aspx";            
            base._Load();
        }
		protected IndicadorTipoService Service
		{
			get { return IndicadorTipoService.Current; }
		}
		protected override IEntityService<nc.IndicadorTipo, nc.IndicadorTipoFilter, nc.IndicadorTipoResult, int> EntityService
		{
			get { return IndicadorTipoService.Current; }
		}
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}
