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
	public partial class EntidadTipoPageList : PageList<nc.EntidadTipo ,nc.EntidadTipoFilter, nc.EntidadTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstEntidadTipo;
            webControlFilter = this.ftEntidadTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "EntidadTipoPageEdit.aspx";            
            base._Load();
        }
		protected EntidadTipoService Service
		{
			get { return EntidadTipoService.Current; }
		}
		protected override IEntityService<nc.EntidadTipo, nc.EntidadTipoFilter, nc.EntidadTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.EntidadTipo ,nc.EntidadTipoFilter,EntidadTipoResult, int> ViewService
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
