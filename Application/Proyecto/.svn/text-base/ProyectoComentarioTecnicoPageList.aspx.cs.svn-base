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
	public partial class ProyectoComentarioTecnicoPageList : PageList<nc.ProyectoComentarioTecnico ,nc.ProyectoComentarioTecnicoFilter, nc.ProyectoComentarioTecnicoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "ComentarioTecnico_Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstProyectoComentarioTecnico;
            webControlFilter = this.ftProyectoComentarioTecnico;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProyectoComentarioTecnicoPageEdit.aspx";            
            base._Load();
        }
		protected ProyectoComentarioTecnicoService Service
		{
			get { return ProyectoComentarioTecnicoService.Current; }
		}
		protected override IEntityService<nc.ProyectoComentarioTecnico, nc.ProyectoComentarioTecnicoFilter, nc.ProyectoComentarioTecnicoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProyectoComentarioTecnico ,nc.ProyectoComentarioTecnicoFilter,ProyectoComentarioTecnicoResult, int> ViewService
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
