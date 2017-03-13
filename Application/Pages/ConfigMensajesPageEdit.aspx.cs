using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public partial class ConfigMensajesPageEdit : PageEdit<nc.MessageConfigurationCompose, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int>
    {
        #region Override
        protected override void _Load()
        {
            webControlEdit = this.editConfigMensajes;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ConfigMensajesPageList.aspx";
            base._Load();
        }
        protected MessageConfigurationService Service
        {
            get { return MessageConfigurationService.Current; }
        }
        protected override IEntityService<nc.MessageConfigurationCompose, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int> EntityService
        {
            get { return MessageConfigurationComposeService.Current; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion
    }
}