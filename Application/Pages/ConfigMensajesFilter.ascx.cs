using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nc = Contract;

namespace UI.Web
{
    public partial class ConfigMensajesFilter : WebControlFilter<nc.MessageConfigurationFilter>
    {
        protected override void _Initialize()
        {
            base._Initialize();
            revPagina.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(150);
            revTipoOperacion.ValidationExpression = Contract.DataHelper.GetExpRegNumberNullable();
            revMensaje.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revAsunto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2000);
            revTipoOperacion.ErrorMessage = TranslateFormat("InvalidField", "Tipo Operación");
            revPagina.ErrorMessage = TranslateFormat("InvalidField", "Pagina");
            revMensaje.ErrorMessage = TranslateFormat("InvalidField", "Mensaje");
            revAsunto.ErrorMessage = TranslateFormat("InvalidField", "Asunto");

        }

        protected override void Clear()
        {
            UIHelper.Clear(txtPagina);
            txtPagina.Focus();
            UIHelper.Clear(cboTipoOperacion);
            UIHelper.Clear(txtMensaje);
            UIHelper.Clear(txtAsunto);

        }
        protected override void SetValue()
        {
            UIHelper.SetValueFilter(txtPagina, Filter.Page);
            txtPagina.Focus();
            UIHelper.SetValue(cboTipoOperacion, Filter.OperationType);
            UIHelper.SetValue(txtMensaje, Filter.Body);
            UIHelper.SetValue(txtAsunto, Filter.Subject);

        }
        protected override void GetValue()
        {
            Filter.Page = UIHelper.GetStringBetweenFilter(txtPagina);
            Filter.OperationType = UIHelper.GetInt(cboTipoOperacion);
            filter.Body = UIHelper.GetStringBetweenFilter(txtMensaje);
            filter.Subject = UIHelper.GetStringBetweenFilter(txtAsunto);
        }
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}