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
    public partial class ConfigMensajesPageListEdit : PageListEdit<nc.MessageConfigurationCompose, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int>
    {
        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            pnPopUpEditConfigMensajes.Attributes.CssStyle.Add("display", "none");
        }
        protected override void _Load()
        {
            webControlList = this.lstEstado;
            webControlFilter = this.ftConfigMensajes;
            webControlEdit = this.editConfigMensajes;
            webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ConfigMensajesPageEdit.aspx";
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
        #region Methods
        protected override void ShowEdit()
        {
            base.ShowEdit();
            IsActivePopup = true;
            upEditConfigMensajes.Update();
            ModalPopupExtenderEditConfigMensajes.Show();
        }
        protected override void ShowView()
        {
            base.ShowView();
            IsActivePopup = true;
            upEditConfigMensajes.Update();
            ModalPopupExtenderEditConfigMensajes.Show();
        }
        protected override void HideEdit()
        {
            base.HideEdit();
            IsActivePopup = false;
            ActivePopupName = "";
            ModalPopupExtenderEditConfigMensajes.Hide();
        }
        #endregion
        #region Events
        protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected virtual void btEdit_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
                ControlCommand(Command.EDIT);
        }
        protected virtual void btView_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
                ControlCommand(Command.VIEW);
        }
        protected virtual void btDelete_Click(object sender, EventArgs e)
        {
            if (webControlList.GetSelectedId() > 0)
                ControlCommand(Command.DELETE);
        }
        #endregion
    }
}