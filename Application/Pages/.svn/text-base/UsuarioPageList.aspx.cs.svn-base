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
	public partial class UsuarioPageList : PageList<nc.Usuario ,nc.UsuarioFilter, nc.UsuarioResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "NombreUsuario";
        }	
		protected override void _Load()
        {
            webControlList = this.lstUsuario;
            webControlFilter = this.ftUsuario;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "UsuarioPageEdit.aspx";            
            base._Load();
        }
		protected UsuarioService Service
		{
			get { return UsuarioService.Current; }
		}
		protected override IEntityService<nc.Usuario, nc.UsuarioFilter, nc.UsuarioResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Usuario ,nc.UsuarioFilter,UsuarioResult, int> ViewService
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
