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
	public partial class NumerationPageList : PageList<nc.Numeration ,nc.NumerationFilter, nc.NumerationResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "IdNumeration";
        }	
		protected override void _Load()
        {
            webControlList = this.lstNumeration;
            webControlFilter = this.ftNumeration;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "NumerationPageEdit.aspx";            
            base._Load();
        }
		protected NumerationService Service
		{
			get { return NumerationService.Current; }
		}
		protected override IEntityService<nc.Numeration, nc.NumerationFilter, nc.NumerationResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Numeration ,nc.NumerationFilter,NumerationResult, int> ViewService
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
