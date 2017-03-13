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
	public partial class FinalidadFuncionTipoPageList : PageList<nc.FinalidadFuncionTipo ,nc.FinalidadFuncionTipoFilter, nc.FinalidadFuncionTipoResult, int>
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
            webControlList = this.lstFinalidadFuncionTipo;
            webControlFilter = this.ftFinalidadFuncionTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "FinalidadFuncionTipoPageEdit.aspx";            
            base._Load();
        }
		protected FinalidadFuncionTipoService Service
		{
			get { return FinalidadFuncionTipoService.Current; }
		}
		protected override IEntityService<nc.FinalidadFuncionTipo, nc.FinalidadFuncionTipoFilter, nc.FinalidadFuncionTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.FinalidadFuncionTipo ,nc.FinalidadFuncionTipoFilter,FinalidadFuncionTipoResult, int> ViewService
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
