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
	public partial class SistemaEntidadPageList : PageList<nc.SistemaEntidad ,nc.SistemaEntidadFilter, nc.SistemaEntidadResult, int>
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
            webControlList = this.lstSistemaEntidad;
            webControlFilter = this.ftSistemaEntidad;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SistemaEntidadPageEdit.aspx";            
            base._Load();
        }
		protected SistemaEntidadService Service
		{
			get { return SistemaEntidadService.Current; }
		}
		protected override IEntityService<nc.SistemaEntidad, nc.SistemaEntidadFilter, nc.SistemaEntidadResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.SistemaEntidad ,nc.SistemaEntidadFilter,SistemaEntidadResult, int> ViewService
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
