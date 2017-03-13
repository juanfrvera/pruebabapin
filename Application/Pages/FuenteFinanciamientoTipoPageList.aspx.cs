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
	public partial class FuenteFinanciamientoTipoPageList : PageList<nc.FuenteFinanciamientoTipo ,nc.FuenteFinanciamientoTipoFilter, nc.FuenteFinanciamientoTipoResult, int>
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
            webControlList = this.lstFuenteFinanciamientoTipo;
            webControlFilter = this.ftFuenteFinanciamientoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "FuenteFinanciamientoTipoPageEdit.aspx";            
            base._Load();
        }
		protected FuenteFinanciamientoTipoService Service
		{
			get { return FuenteFinanciamientoTipoService.Current; }
		}
		protected override IEntityService<nc.FuenteFinanciamientoTipo, nc.FuenteFinanciamientoTipoFilter, nc.FuenteFinanciamientoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.FuenteFinanciamientoTipo ,nc.FuenteFinanciamientoTipoFilter,FuenteFinanciamientoTipoResult, int> ViewService
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
