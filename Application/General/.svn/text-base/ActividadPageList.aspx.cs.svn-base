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
	public partial class ActividadPageList : PageList<nc.Actividad ,nc.ActividadFilter, nc.ActividadResult, int>
    {
        #region override
        protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstActividad;
            webControlFilter = this.ftActividad;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ActividadPageEdit.aspx"; 
           
            base._Load();
        }
		protected ActividadService Service
		{
			get { return ActividadService.Current; }
		}
		protected override IEntityService<nc.Actividad, nc.ActividadFilter, nc.ActividadResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Actividad ,nc.ActividadFilter,ActividadResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
        }       
        #endregion
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
