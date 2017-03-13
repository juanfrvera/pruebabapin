using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using Service;

namespace UI.Web
{

    public abstract class WebControlPopup : WebControlBase
    {
        public abstract void ShowPopup();
        public abstract void HidePopup();
    }


    public partial class WebControl_Copy : WebControlPopup
    {
        #region Methods
        public override void HidePopup()
        {
            mpePopupCopy.Hide();
        }
        public override void ShowPopup()
        {
            mpePopupCopy.Show();
            upControls.Update();
        }
        public void Aceptar()
        {
            int id;
            if (!int.TryParse(CommandValue, out id)) return;
            SimpleIntResult result = new SimpleIntResult() { ID = id, Text = UIHelper.GetString(txtNombre) };

            if (result == null) return;
            int idNew = ParameterService.Current.CopyAndSave(result.ID, result.Text, UIContext.Current.ContextUser);
            if (idNew > 0)
                UIHelper.ShowAlert("Parametro creado con el ID: " + idNew, upControls);
            else
                UIHelper.ShowAlert("Hubo un error al copiar el parametro", upControls);

            mpePopupCopy.Hide();
        }

        public string Nombre
        {
            get { return txtNombre.Text; }
            set { this.txtNombre.Text = value; }
        }

        public void Clear()
        {
            UIHelper.Clear(txtNombre);
            upControls.Update();
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