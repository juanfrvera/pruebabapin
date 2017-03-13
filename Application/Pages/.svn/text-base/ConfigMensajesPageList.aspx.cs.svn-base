using Contract;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nc = Contract;

namespace UI.Web
{
    public partial class ConfigMensajesPageList : PageList<nc.MessageConfiguration, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int>
    {
        protected override void _Initialize()
        {
            base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Page";
        }
        protected override void _Load()
        {
            webControlList = this.lstConfigMensajes;
            webControlFilter = this.ftConfigMensajes;
            //webControlListButtons = this.listButtons;
            webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ConfigMensajesPageEdit.aspx";
            base._Load();
        }
        protected MessageConfigurationService Service
        {
            get { return MessageConfigurationService.Current; }
        }
        protected override IEntityService<nc.MessageConfiguration, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int> EntityService
        {
            get { return Service; }
        }
        protected override IViewService<nc.MessageConfiguration, nc.MessageConfigurationFilter, MessageConfigurationResult, int> ViewService
        {
            get { return Service; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
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