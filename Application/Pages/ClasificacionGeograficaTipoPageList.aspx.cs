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
	public partial class ClasificacionGeograficaTipoPageList : PageList<nc.ClasificacionGeograficaTipo ,nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int>
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
            webControlList = this.lstClasificacionGeograficaTipo;
            webControlFilter = this.ftClasificacionGeograficaTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ClasificacionGeograficaTipoPageEdit.aspx";            
            base._Load();
        }
		protected ClasificacionGeograficaTipoService Service
		{
			get { return ClasificacionGeograficaTipoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGeograficaTipo, nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ClasificacionGeograficaTipo ,nc.ClasificacionGeograficaTipoFilter,ClasificacionGeograficaTipoResult, int> ViewService
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
