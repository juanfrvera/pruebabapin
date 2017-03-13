using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public partial class frmChangePassword : PageBase
    {

        protected void ValidarPassword(object source, EventArgs args)
        {
            //if (((TextBox)ChangePassword.Controls[0].FindControl("NewPassword")).Text != ((TextBox)ChangePassword.Controls[0].FindControl("ConfirmPassword")).Text)
            //{
            //    ((MessageBar)ChangePassword.Controls[0].FindControl("FailureText")).Text = ChangePassword.ConfirmPasswordCompareErrorMessage;
            //    args.IsValid = false;
            //}
        }
        protected void Cancel_Click(object source, EventArgs args)
        {
            if (PagePrevious == null)
                Response.Redirect("~/Default.aspx", false);
            else
                Response.Redirect(PagePrevious, false);
        }


        protected void Aceptar_Click(object source, EventArgs args)
        {


            try
            {
                nc.Usuario usuario = UsuarioService.Current.GetById(UIContext.Current.ContextUser.User.IdUsuario);
                if (CurrentPassword.Text == usuario.Clave && NewPassword.Text == ConfirmPassword.Text)
                {
                    usuario.Clave = ConfirmPassword.Text;
                    UsuarioService.Current.Update(usuario, UIContext.Current.ContextUser);
                    UIContext.Current.Logout();
                    HttpContext.Current.Response.Redirect("~/Security/frmLogin.aspx", false);
                }
                else
                {
                    UIHelper.SetValue(lblMessage, UIHelper.Translate("Las contraseñas no son correctas."));
                    UIHelper.Clear(CurrentPassword);
                    UIHelper.Clear(NewPassword);
                    UIHelper.Clear(ConfirmPassword);
                }
            }
            catch (Exception exception)
            {
                UIHelper.SetValue(lblMessage, exception.Message);
            }                
        }
    }
}
