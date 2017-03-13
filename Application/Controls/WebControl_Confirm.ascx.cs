using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class WebControl_Confirm : WebControlPopup
    {
       
        #region Properties
        public String Observaciones
        {
            get { return txObservaciones.Text; }
            set { txObservaciones.Text = value; }
        }
        public String Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        #endregion
        #region Methods
        public override void HidePopup()
        {
            mpeWindow.Hide();
            upControls.Update();
        }
        public override void ShowPopup()
        {
            mpeWindow.Show();
            UIHelper.Clear(txObservaciones);
            upControls.Update();
        }
        public void Aceptar()
        {
            RaiseControlCommand(CommandName, CommandValue);
        }
        #endregion

        #region Events
        protected void btAceptar_Click(object sender, EventArgs e)
        {
            CallTryMethod(Aceptar);
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            CallTryMethod(HidePopup);
        }
        #endregion
    }
}