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
	public partial class PersonaPageList : PageList<nc.Persona ,nc.PersonaFilter, nc.PersonaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            this.SortExpression = "NombreCompleto";
            
        }	
		protected override void _Load()
        {
            webControlList = this.lstPersona;
            webControlFilter = this.ftPersona;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PersonaPageEdit.aspx";            
            base._Load();
        }
		protected PersonaService Service
		{
			get { return PersonaService.Current; }
		}
		protected override IEntityService<nc.Persona, nc.PersonaFilter, nc.PersonaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Persona ,nc.PersonaFilter,PersonaResult, int> ViewService
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
