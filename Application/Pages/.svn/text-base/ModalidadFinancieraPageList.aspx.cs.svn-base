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
	public partial class ModalidadFinancieraPageList : PageList<nc.ModalidadFinanciera ,nc.ModalidadFinancieraFilter, nc.ModalidadFinancieraResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("OrganismoFinanciero_Nombre"));
            OrderBys.Add(new FilterOrderBy("Nombre"));

        }	
		protected override void _Load()
        {
            webControlList = this.lstModalidadFinanciera;
            webControlFilter = this.ftModalidadFinanciera;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ModalidadFinancieraPageEdit.aspx";            
            base._Load();
        }
		protected ModalidadFinancieraService Service
		{
			get { return ModalidadFinancieraService.Current; }
		}
		protected override IEntityService<nc.ModalidadFinanciera, nc.ModalidadFinancieraFilter, nc.ModalidadFinancieraResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ModalidadFinanciera ,nc.ModalidadFinancieraFilter,ModalidadFinancieraResult, int> ViewService
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
