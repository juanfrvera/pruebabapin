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
	public partial class PerfilPageList : PageList<nc.Perfil ,nc.PerfilFilter, nc.PerfilResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("PerfilTipo_Nombre"));
            OrderBys.Add(new FilterOrderBy("Nombre"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstPerfil;
            webControlFilter = this.ftPerfil;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PerfilPageEdit.aspx";            
            base._Load();
        }
		protected PerfilService Service
		{
			get { return PerfilService.Current; }
		}
		protected override IEntityService<nc.Perfil, nc.PerfilFilter, nc.PerfilResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Perfil ,nc.PerfilFilter,PerfilResult, int> ViewService
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
