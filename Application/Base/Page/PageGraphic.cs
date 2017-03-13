using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Service;
using System.Linq;
using System.Data.Linq;
using nc = Contract;
using Contract;
namespace UI.Web
{  
    public abstract class PageGraphic<TFilter> : PageBase
        where TFilter : nc.Filter,new()
    {
        protected WebControlFilter<TFilter> webControlFilter;

        #region Page Events
        protected override void _Initialize()
        {
            if (PageBehaviour.ReloadAlways)
                CommandReload();
            base._Initialize();
        }        
        protected override void _Load()
        {
            base._Load();
            if (webControlFilter!= null) webControlFilter.ControlCommand += new ControlCommandHandler(ControlCommand);
        }
        #endregion

        #region Commnads
        protected override void ControlCommand(object sender, string name, object value)
        {
            CommandName = name;
            CommandValue = value;
            CommandSender = sender;
            try
            {
                switch (CommandName)
                {                  
                    case Command.RELOAD:
                        if (!PageBehaviour.ReloadAlways)
                            CommandReload();
                        break;
                    case Command.REFRESH:
                    case Command.SHOW_STATISTICS:
                        CommandStatistics();
                        break;                    
                    default:
                        CommandOthers();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.Manage(exception);
            }
        }
        protected virtual void CommandReload()
        {
            this.ReloadFilter();
            this.RefreshStatistics();
            this.ShowStatistics();
        }
        protected virtual void CommandStatistics()
        {
            this.RefreshStatistics();
            this.ShowStatistics();
        }      
        protected virtual void CommandOthers() { }
        
        #region Methods
        protected virtual void ReloadFilter()
        {
            if (webControlFilter != null)webControlFilter.LoadFilter();
        }
        protected abstract void RefreshStatistics();
        protected virtual void ShowStatistics() { }
        protected virtual void HideStatistics() { }
        
        #endregion
        #endregion
    }
}