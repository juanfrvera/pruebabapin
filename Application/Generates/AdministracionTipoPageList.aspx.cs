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
	public partial class AdministracionTipoPageList : PageList<nc.AdministracionTipo ,nc.AdministracionTipoFilter, nc.AdministracionTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstAdministracionTipo;
            webControlFilter = this.ftAdministracionTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "AdministracionTipoPageEdit.aspx";            
            base._Load();
        }
		protected AdministracionTipoService Service
		{
			get { return AdministracionTipoService.Current; }
		}
		protected override IEntityService<nc.AdministracionTipo, nc.AdministracionTipoFilter, nc.AdministracionTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.AdministracionTipo ,nc.AdministracionTipoFilter,AdministracionTipoResult, int> ViewService
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
