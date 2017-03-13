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
	public partial class MedioVerificacionPageList : PageList<nc.MedioVerificacion ,nc.MedioVerificacionFilter, nc.MedioVerificacionResult, int>
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
            webControlList = this.lstMedioVerificacion;
            webControlFilter = this.ftMedioVerificacion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "MedioVerificacionPageEdit.aspx";            
            base._Load();
        }
		protected MedioVerificacionService Service
		{
			get { return MedioVerificacionService.Current; }
		}
		protected override IEntityService<nc.MedioVerificacion, nc.MedioVerificacionFilter, nc.MedioVerificacionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.MedioVerificacion ,nc.MedioVerificacionFilter,MedioVerificacionResult, int> ViewService
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
