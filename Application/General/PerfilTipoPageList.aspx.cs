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
	public partial class PerfilTipoPageList : PageList<nc.PerfilTipo ,nc.PerfilTipoFilter, nc.PerfilTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "PerfilTipo";
        }	
		protected override void _Load()
        {
            webControlList = this.lstPerfilTipo;
            webControlFilter = this.ftPerfilTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PerfilTipoPageEdit.aspx";            
            base._Load();
        }
		protected PerfilTipoService Service
		{
			get { return PerfilTipoService.Current; }
		}
		protected override IEntityService<nc.PerfilTipo, nc.PerfilTipoFilter, nc.PerfilTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PerfilTipo ,nc.PerfilTipoFilter,PerfilTipoResult, int> ViewService
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
