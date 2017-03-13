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
	public partial class CaracterEconomicoTipoPageList : PageList<nc.CaracterEconomicoTipo ,nc.CaracterEconomicoTipoFilter, nc.CaracterEconomicoTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstCaracterEconomicoTipo;
            webControlFilter = this.ftCaracterEconomicoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "CaracterEconomicoTipoPageEdit.aspx";            
            base._Load();
        }
		protected CaracterEconomicoTipoService Service
		{
			get { return CaracterEconomicoTipoService.Current; }
		}
		protected override IEntityService<nc.CaracterEconomicoTipo, nc.CaracterEconomicoTipoFilter, nc.CaracterEconomicoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.CaracterEconomicoTipo ,nc.CaracterEconomicoTipoFilter,CaracterEconomicoTipoResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
	}
}
