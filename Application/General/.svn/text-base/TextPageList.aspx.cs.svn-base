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
	public partial class TextPageList : PageList<nc.Text ,nc.TextFilter, nc.TextResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Description";
        }	
		protected override void _Load()
        {
            webControlList = this.lstText;
            webControlFilter = this.ftText;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "TextPageEdit.aspx";            
            base._Load();
        }
		protected TextService Service
		{
			get { return TextService.Current; }
		}
		protected override IEntityService<nc.Text, nc.TextFilter, nc.TextResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Text ,nc.TextFilter,TextResult, int> ViewService
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
