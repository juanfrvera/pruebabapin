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
	public partial class IndicadorRubroPageEdit : PageEdit<nc.IndicadorRubro ,nc.IndicadorRubroFilter, nc.IndicadorRubroResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editIndicadorRubro;
            webControlEditionButtons = this.editButtons;
            PathListPage = "IndicadorRubroPageList.aspx";            
            base._Load();
        }
		protected IndicadorRubroService Service
		{
			get { return IndicadorRubroService.Current; }
		}
		protected override IEntityService<nc.IndicadorRubro, nc.IndicadorRubroFilter, nc.IndicadorRubroResult, int> EntityService
		{
			get { return IndicadorRubroService.Current; }
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
