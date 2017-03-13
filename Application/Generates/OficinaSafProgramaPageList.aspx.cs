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
	public partial class OficinaSafProgramaPageList : PageList<nc.OficinaSafPrograma ,nc.OficinaSafProgramaFilter, nc.OficinaSafProgramaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstOficinaSafPrograma;
            webControlFilter = this.ftOficinaSafPrograma;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OficinaSafProgramaPageEdit.aspx";            
            base._Load();
        }
		protected OficinaSafProgramaService Service
		{
			get { return OficinaSafProgramaService.Current; }
		}
		protected override IEntityService<nc.OficinaSafPrograma, nc.OficinaSafProgramaFilter, nc.OficinaSafProgramaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.OficinaSafPrograma ,nc.OficinaSafProgramaFilter,OficinaSafProgramaResult, int> ViewService
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
