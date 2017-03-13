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
using Business;

namespace UI.Web
{
    public partial class ConfigMensajesEdit : WebControlEdit<nc.MessageConfigurationCompose>
    {

        protected override void _Initialize()
        {
            base._Initialize();

            List<ListItem> pagesOrderBy = this.cboPagina.Items.Cast<ListItem>().Select(page => page).OrderBy(cbo => cbo.Text).ToList();
            this.cboPagina.Items.Clear();

            foreach (ListItem item in pagesOrderBy)
                this.cboPagina.Items.Add(item);
        }
        public override void Clear()
        {
            UIHelper.Clear(cboPagina);
            cboPagina.Focus();
            UIHelper.Clear(cboTipoOperacion);
            UIHelper.Clear(txtMensaje);

        }
        public override void SetValue()
        {
            if (CrudAction == CrudActionEnum.Update)
            {
                MessageResult messageResult = MessageBusiness.Current.GetResult(new nc.MessageFilter() { IdMessage = Entity.MessageConfiguration.IdMessage }).FirstOrDefault();
                string mensaje = (messageResult == null) ? string.Empty : messageResult.Body;
                string asunto = (messageResult == null) ? string.Empty : messageResult.Subject;
                int prioridad = (messageResult == null) ? 1 : messageResult.IdPriority;

                string page = (Entity.MessageConfiguration.Page.Contains("List.aspx")) ? Entity.MessageConfiguration.Page.Replace("List.aspx", "") : Entity.MessageConfiguration.Page.Replace("Edit.aspx", "");

                UIHelper.SetValue(cboPagina, page);
                cboPagina.Focus();
                UIHelper.SetValue(cboTipoOperacion, Entity.MessageConfiguration.OperationType);
                UIHelper.SetValue(txtMensaje, mensaje);
                UIHelper.SetValue(txtAsunto, asunto);
                UIHelper.SetValue(cboPrioridad, prioridad);
            }

        }
        public override void GetValue()
        {
            int tipoOperacion = UIHelper.GetInt(cboTipoOperacion);

            string nombrePaginaFaltante = string.Empty;
            nombrePaginaFaltante = (tipoOperacion == 0 || tipoOperacion == 1) ? nombrePaginaFaltante + "Edit.aspx" : nombrePaginaFaltante + "List.aspx";

            Entity.MessageConfiguration.Page = cboPagina.SelectedValue + nombrePaginaFaltante;
            Entity.MessageConfiguration.OperationType = tipoOperacion;
            Entity.MessageConfiguration.Message = UIHelper.GetString(txtMensaje);
            Entity.MessageConfiguration.Subject = UIHelper.GetString(txtAsunto);
            Entity.MessageConfiguration.idPrioridad = UIHelper.GetInt(cboPrioridad);
            Entity.MessageConfiguration.idUserForm = ((ContextUser)Session["contextuser"]).User.ID;

        }

        #region Events

        #endregion

    }
}