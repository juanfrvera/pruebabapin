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
	public partial class EtapaPageList : PageList<nc.Etapa ,nc.EtapaFilter, nc.EtapaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("Fase_Nombre"));
            OrderBys.Add(new FilterOrderBy("Orden"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstEtapa;
            webControlFilter = this.ftEtapa;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "EtapaPageEdit.aspx";            
            base._Load();
        }
		protected EtapaService Service
		{
			get { return EtapaService.Current; }
		}
		protected override IEntityService<nc.Etapa, nc.EtapaFilter, nc.EtapaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Etapa ,nc.EtapaFilter,EtapaResult, int> ViewService
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
