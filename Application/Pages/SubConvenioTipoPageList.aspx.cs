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
	public partial class SubConvenioTipoPageList : PageList<nc.SubConvenioTipo ,nc.SubConvenioTipoFilter, nc.SubConvenioTipoResult, int>
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
            webControlList = this.lstSubConvenioTipo;
            webControlFilter = this.ftSubConvenioTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SubConvenioTipoPageEdit.aspx";            
            base._Load();
        }
		protected SubConvenioTipoService Service
		{
			get { return SubConvenioTipoService.Current; }
		}
		protected override IEntityService<nc.SubConvenioTipo, nc.SubConvenioTipoFilter, nc.SubConvenioTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.SubConvenioTipo ,nc.SubConvenioTipoFilter,SubConvenioTipoResult, int> ViewService
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
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
	}
}
