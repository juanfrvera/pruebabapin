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
	public partial class OficinaPageList : PageList<nc.Oficina ,nc.OficinaFilter, nc.OficinaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("BreadcrumbCode"));
            OrderBys.Add(new FilterOrderBy("OficinaPadre_Nombre"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstOficina;
            webControlFilter = this.ftOficina;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OficinaPageEdit.aspx";            
            base._Load();
        }
		protected OficinaService Service
		{
			get { return OficinaService.Current; }
		}
		protected override IEntityService<nc.Oficina, nc.OficinaFilter, nc.OficinaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Oficina ,nc.OficinaFilter,OficinaResult, int> ViewService
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
