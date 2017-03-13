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
using System.Collections;

namespace UI.Web
{    
	public partial class ParameterPageList : PageList<nc.Parameter ,nc.ParameterFilter, nc.ParameterResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add (new FilterOrderBy(){ OrderByProperty= "Name", OrderByDesc = false }) ;
        }	
		protected override void _Load()
        {
            webControlList = this.lstParameter;
            webControlFilter = this.ftParameter;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ParameterPageEdit.aspx";            
            base._Load();
        }
		protected ParameterService Service
		{
			get { return ParameterService.Current; }
		}
		protected override IEntityService<nc.Parameter, nc.ParameterFilter, nc.ParameterResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Parameter ,nc.ParameterFilter,ParameterResult, int> ViewService
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

        protected override void CommandOthers()
        {
            Hashtable args = new Hashtable();
            switch (CommandName)
            {
                case Command.SHOW_POPUP_COPY_AND_SAVE:
                    ShowCopyAndSave(CommandValue);
                    break;
            }
        }

        void ShowCopyAndSave(object CommandValue)
        {
            ParameterResult parameterResult = (from o in List where o.ID == ConvertId(CommandValue) select o).FirstOrDefault();
            if (parameterResult == null) return;
            ActualPopupId = "ucCopy";
            ucCopy.Visible = true;
            ucCopy.Clear();
            ucCopy.Nombre = parameterResult.Description;
            ucCopy.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
            ucCopy.CommandName = Command.COPY_AND_SAVE;
            ucCopy.ShowPopup();
        }
	}
}
