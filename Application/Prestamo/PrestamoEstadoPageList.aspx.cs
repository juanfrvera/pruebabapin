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
	public partial class PrestamoEstadoPageList : PageList<nc.PrestamoEstado ,nc.PrestamoEstadoFilter, nc.PrestamoEstadoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Prestamo_Descripcion";
        }	
		protected override void _Load()
        {
            webControlList = this.lstPrestamoEstado;
            webControlFilter = this.ftPrestamoEstado;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PrestamoEstadoPageEdit.aspx";            
            base._Load();
        }
		protected PrestamoEstadoService Service
		{
			get { return PrestamoEstadoService.Current; }
		}
		protected override IEntityService<nc.PrestamoEstado, nc.PrestamoEstadoFilter, nc.PrestamoEstadoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PrestamoEstado ,nc.PrestamoEstadoFilter,PrestamoEstadoResult, int> ViewService
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
