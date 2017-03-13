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
	public partial class IndicadorSectorPageList : PageList<nc.IndicadorSector ,nc.IndicadorSectorFilter, nc.IndicadorSectorResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstIndicadorSector;
            webControlFilter = this.ftIndicadorSector;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "IndicadorSectorPageEdit.aspx";            
            base._Load();
        }
		protected IndicadorSectorService Service
		{
			get { return IndicadorSectorService.Current; }
		}
		protected override IEntityService<nc.IndicadorSector, nc.IndicadorSectorFilter, nc.IndicadorSectorResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.IndicadorSector ,nc.IndicadorSectorFilter,IndicadorSectorResult, int> ViewService
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
