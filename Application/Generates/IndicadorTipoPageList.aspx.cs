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
	public partial class IndicadorTipoPageList : PageList<nc.IndicadorTipo ,nc.IndicadorTipoFilter, nc.IndicadorTipoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            idImgCreate.Visible = canCreate;
        }	
		protected override void _Load()
        {
            webControlList = this.lstIndicadorTipo;
            webControlFilter = this.ftIndicadorTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "IndicadorTipoPageEdit.aspx";            
            base._Load();
        }
		protected IndicadorTipoService Service
		{
			get { return IndicadorTipoService.Current; }
		}
		protected override IEntityService<nc.IndicadorTipo, nc.IndicadorTipoFilter, nc.IndicadorTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.IndicadorTipo ,nc.IndicadorTipoFilter,IndicadorTipoResult, nc.IndicadorTipoId> ViewService
        {
            get { return Service; }
        }
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
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
