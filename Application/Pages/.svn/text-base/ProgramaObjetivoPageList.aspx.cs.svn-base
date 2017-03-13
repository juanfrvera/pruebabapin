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
	public partial class ProgramaObjetivoPageList : PageList<nc.ProgramaObjetivo ,nc.ProgramaObjetivoFilter, nc.ProgramaObjetivoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression="Programa_Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstProgramaObjetivo;
            webControlFilter = this.ftProgramaObjetivo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProgramaObjetivoPageEdit.aspx";            
            base._Load();
        }
		protected ProgramaObjetivoService Service
		{
			get { return ProgramaObjetivoService.Current; }
		}
		protected override IEntityService<nc.ProgramaObjetivo, nc.ProgramaObjetivoFilter, nc.ProgramaObjetivoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProgramaObjetivo ,nc.ProgramaObjetivoFilter,ProgramaObjetivoResult, int> ViewService
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
