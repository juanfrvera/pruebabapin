using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Application.Base;
using Application.Controls;
using AjaxControlToolkit;
using Contract;
using Service;
using System.Web.Security;
using UI.Web;

namespace Application.Shared
{
    public partial class WithoutLogin : MasterBase
    {
        #region Properties        
        protected override MessageBar MessageDisplay { get { return MessageBarForm; } }
        protected override ContentPlaceHolder GetMainContent()
        {
            return this.ContenidoPrincipal;
        }        
        #endregion
    }
}
