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
	public partial class PerfilActividadPageList : PageList<nc.PerfilActividad ,nc.PerfilActividadFilter, nc.PerfilActividadResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Perfil_Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstPerfilActividad;
            webControlFilter = this.ftPerfilActividad;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PerfilActividadPageEdit.aspx";            
            base._Load();
        }
		protected PerfilActividadService Service
		{
			get { return PerfilActividadService.Current; }
		}
		protected override IEntityService<nc.PerfilActividad, nc.PerfilActividadFilter, nc.PerfilActividadResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PerfilActividad ,nc.PerfilActividadFilter,PerfilActividadResult, int> ViewService
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
