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
	public partial class ProgramaPageList : PageList<nc.Programa ,nc.ProgramaFilter, nc.ProgramaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("SAF_Código"));  
            OrderBys.Add(new FilterOrderBy("Codigo"));          
        }	
		protected override void _Load()
        {
            webControlList = this.lstPrograma;
            webControlFilter = this.ftPrograma;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProgramaPageEdit.aspx";            
            base._Load();
        }
		protected ProgramaService Service
		{
			get { return ProgramaService.Current; }
		}
		protected override IEntityService<nc.Programa, nc.ProgramaFilter, nc.ProgramaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Programa ,nc.ProgramaFilter,ProgramaResult, int> ViewService
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


        protected override void View()
        {
            string pageView = "ProgramaObjetivoPageEdit.aspx";

            int id = ConvertId(ConvertId(CommandValue));
            SetParameter(pageView, PARAMETER_ACTION, Command.VIEW);
            SetParameter(pageView, PARAMETER_VALUE, id.ToString());
            Filter.RowIndex = GetSelectedRowIndex(id);
            SetGeneralParameter(EditFilter, Filter);
            Response.Redirect(pageView, false);
        }      
        protected override void CommandOthers()
        {
            base.CommandOthers();
            string pageChange = "";
            switch (CommandName)
            {
                case Command.SHOW_DETAILS:                    
                    pageChange = "ProgramaObjetivoPageEdit.aspx";
                    SetParameter(pageChange, PARAMETER_ACTION, Command.EDIT);
                    SetParameter(pageChange, PARAMETER_VALUE, CommandValue.ToString());
                    Response.Redirect(pageChange, false);
                    break;
            }
        }


	}
}
