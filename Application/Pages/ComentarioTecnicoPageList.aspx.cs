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
	public partial class ComentarioTecnicoPageList : PageList<nc.ComentarioTecnico ,nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int>
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
            webControlList = this.lstComentarioTecnico;
            webControlFilter = this.ftComentarioTecnico;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ComentarioTecnicoPageEdit.aspx";            
            base._Load();
        }
		protected ComentarioTecnicoService Service
		{
			get { return ComentarioTecnicoService.Current; }
		}
		protected override IEntityService<nc.ComentarioTecnico, nc.ComentarioTecnicoFilter, nc.ComentarioTecnicoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ComentarioTecnico ,nc.ComentarioTecnicoFilter,ComentarioTecnicoResult, int> ViewService
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
