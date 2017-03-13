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
	public partial class IndicadorClasePageList : PageList<nc.IndicadorClase ,nc.IndicadorClaseFilter, nc.IndicadorClaseResult, int>
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
            webControlList = this.lstIndicadorClase;
            webControlFilter = this.ftIndicadorClase;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "IndicadorClasePageEdit.aspx";            
            base._Load();
        }
		protected IndicadorClaseService Service
		{
			get { return IndicadorClaseService.Current; }
		}
		protected override IEntityService<nc.IndicadorClase, nc.IndicadorClaseFilter, nc.IndicadorClaseResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.IndicadorClase ,nc.IndicadorClaseFilter,IndicadorClaseResult, int> ViewService
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
