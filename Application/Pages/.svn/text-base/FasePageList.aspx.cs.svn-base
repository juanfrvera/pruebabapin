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
	public partial class FasePageList : PageList<nc.Fase ,nc.FaseFilter, nc.FaseResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Orden";
            
        }	
		protected override void _Load()
        {
            webControlList = this.lstFase;
            webControlFilter = this.ftFase;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "FasePageEdit.aspx";            
            base._Load();
        }
		protected FaseService Service
		{
			get { return FaseService.Current; }
		}
		protected override IEntityService<nc.Fase, nc.FaseFilter, nc.FaseResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Fase ,nc.FaseFilter,FaseResult, int> ViewService
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
