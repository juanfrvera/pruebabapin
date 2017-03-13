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
	public partial class ClasificacionGastoTipoPageList : PageList<nc.ClasificacionGastoTipo ,nc.ClasificacionGastoTipoFilter, nc.ClasificacionGastoTipoResult, int>
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
            webControlList = this.lstClasificacionGastoTipo;
            webControlFilter = this.ftClasificacionGastoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ClasificacionGastoTipoPageEdit.aspx";            
            base._Load();
        }
		protected ClasificacionGastoTipoService Service
		{
			get { return ClasificacionGastoTipoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGastoTipo, nc.ClasificacionGastoTipoFilter, nc.ClasificacionGastoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ClasificacionGastoTipo ,nc.ClasificacionGastoTipoFilter,ClasificacionGastoTipoResult, int> ViewService
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
