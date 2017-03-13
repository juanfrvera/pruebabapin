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
	public partial class LanguagePageEdit : PageEdit<nc.Language ,nc.LanguageFilter, nc.LanguageResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editLanguage;
            webControlEditionButtons = this.editButtons;
            PathListPage = "LanguagePageList.aspx";            
            base._Load();
        }
		protected LanguageService Service
		{
			get { return LanguageService.Current; }
		}
		protected override IEntityService<nc.Language, nc.LanguageFilter, nc.LanguageResult, int> EntityService
		{
			get { return LanguageService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        protected override void CommandOthers()
        {
            switch (CommandName)
            {
                case Command.COMPLETE:
                    CommandComplete();
                    break;
            }
        }
		#endregion

        #region Methods
        void CommandComplete()
        {
            Service.Execute(Entity, ActionConfig.COMPLETE, ContextUser);
        }
        #endregion

        #region events
        protected void btComplete_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.COMPLETE);
        }
        #endregion

    }
}
