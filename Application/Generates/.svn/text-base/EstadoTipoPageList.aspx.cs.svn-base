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
	public partial class EstadoTipoPageList : PageList<nc.EstadoTipo ,nc.EstadoTipoFilter, nc.EstadoTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstEstadoTipo;
            webControlFilter = this.ftEstadoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "EstadoTipoPageEdit.aspx";            
            base._Load();
        }
		protected EstadoTipoService Service
		{
			get { return EstadoTipoService.Current; }
		}
		protected override IEntityService<nc.EstadoTipo, nc.EstadoTipoFilter, nc.EstadoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.EstadoTipo ,nc.EstadoTipoFilter,EstadoTipoResult, int> ViewService
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
