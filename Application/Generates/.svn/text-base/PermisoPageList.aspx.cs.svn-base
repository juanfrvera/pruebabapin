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
	public partial class PermisoPageList : PageList<nc.Permiso ,nc.PermisoFilter, nc.PermisoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstPermiso;
            webControlFilter = this.ftPermiso;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PermisoPageEdit.aspx";            
            base._Load();
        }
		protected PermisoService Service
		{
			get { return PermisoService.Current; }
		}
		protected override IEntityService<nc.Permiso, nc.PermisoFilter, nc.PermisoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Permiso ,nc.PermisoFilter,PermisoResult, int> ViewService
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
