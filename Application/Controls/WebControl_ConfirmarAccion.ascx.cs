using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class WebControl_ConfirmarAccion : WebControlConfirm
    {
        #region Properties

        #endregion
        protected override void _Load()
        {
            PanelPopupAcciones.Attributes.CssStyle.Add("display", "none");
        }
        #region Events
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(CommandName, CommandValue);
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CANCEL_POPUP);
        }
        #endregion Botonera Principal

        #region public
        public override void Show()
        {
            if (mpeWindow != null)
            {
                upDatos.Update();
                mpeWindow.Show();
            }
        }

        public override void Hide()
        {
            if (mpeWindow != null)
                mpeWindow.Hide();
        }

        public override void SetMensaje(string Mensaje)
        {
            lblMensaje.Text = Mensaje;
        }

        public override void SetTitulo(string Titulo)
        {
            lblTitulo.Text = Titulo;
        }

        public override string GetMensaje()
        {
            return lblMensaje.Text;
        }

        public override string GetTitulo()
        {
            return lblTitulo.Text;
        }

        public override void SetDisplayNone()
        {
            this.PanelPopupAcciones.Attributes.CssStyle.Add("display", "none"); 
        }

        #endregion

        #region Private
        #endregion
    }
}