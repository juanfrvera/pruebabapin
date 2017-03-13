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
	public partial class ProcesoTipoPageList : PageList<nc.ProcesoTipo ,nc.ProcesoTipoFilter, nc.ProcesoTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstProcesoTipo;
            webControlFilter = this.ftProcesoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProcesoTipoPageEdit.aspx";            
            base._Load();
        }
		protected ProcesoTipoService Service
		{
			get { return ProcesoTipoService.Current; }
		}
		protected override IEntityService<nc.ProcesoTipo, nc.ProcesoTipoFilter, nc.ProcesoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProcesoTipo ,nc.ProcesoTipoFilter,ProcesoTipoResult, int> ViewService
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
