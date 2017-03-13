using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Contract;
using Application.Controls;

namespace UI.Web
{
    public partial class PerfilesAdministracion : PageBase
    {
        #region Clases auxiliares
        private class Perfiles
        {
            private string roleName;
            public string RoleName
            {
                get { return roleName; }
                set { roleName = value; }
            }

            private string asignado;
            public string Asignado
            {
                get { return asignado; }
                set { asignado = value; }
            }
        }

        private class Acciones
        {

            private string ruleName;
            public string RuleName
            {
                get { return ruleName; }
                set { ruleName = value; }
            }

            private string asignado;
            public string Asignado
            {
                get { return asignado; }
                set { asignado = value; }
            }
        }
        #endregion

        #region Atributos
        private string RoleSeleccionado
        {
            get { return (string)ViewState["ROLESELECCIONADO"]; }
            set { ViewState["ROLESELECCIONADO"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CargarPerfiles();
            }
        }

        #region Funciones Privadas

        private void CargarPerfiles()
        {
            string[] allRoles = Roles.GetAllRoles();

            List<Perfiles> perfiles = new List<Perfiles>();
            Perfiles perfil;
            foreach (string rol in allRoles)
            {
                perfil = new Perfiles();
                perfil.RoleName = rol;
                perfil.Asignado = "N";

                perfiles.Add(perfil);
            }


            gvPerfiles.DataSource = perfiles;
            gvPerfiles.DataBind();
        }

        private void GrabarNodoAccion(TreeNode nodo)
        {
            string ruleName;
            string newRuleNameExpresion;

            //obtiene el perfil seleccionado
            string[] roleArray = new string[] { this.RoleSeleccionado };

            //genera una Principal, que solo contiene el perfil seleccionado, de modo de poder ver que acciones tiene habilitadas solo ese perfil
            CustomIdentity customIdentity = new CustomIdentity(WebSessionRepository.Current.Identity.UserId, WebSessionRepository.Current.Identity.Name, WebSessionRepository.Current.Identity.AuthenticationType);
            CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, roleArray);
            UIWebAutorizacionManager Autorization = UIWebAutorizacionManager.Current; 
            ruleName = nodo.Value;

            if (nodo.Checked)
            {
                if (!Autorization.AuthorizationProvider.Authorize(customPrincipal, ruleName))
                {
                    newRuleNameExpresion = Autorization.AuthorizationProvider.RuleExpressionModify(Autorization.AuthorizationProvider.AuthorizationRules[ruleName].Expression, TokenType.Role, this.RoleSeleccionado, true, false);
                    Autorization.AuthorizationProvider.ModifyExpression(ruleName, newRuleNameExpresion);
                }
            }
            else
            {
                if (Autorization.AuthorizationProvider.Authorize(customPrincipal, ruleName))
                {
                    newRuleNameExpresion = Autorization.AuthorizationProvider.RuleExpressionModify(Autorization.AuthorizationProvider.AuthorizationRules[ruleName].Expression, TokenType.Role, this.RoleSeleccionado, false, true);
                    Autorization.AuthorizationProvider.ModifyExpression(ruleName, newRuleNameExpresion);
                }
            }
        }

        #endregion

        #region Eventos

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode raiz = treeAcciones.Nodes[0];

                foreach (TreeNode nodo in raiz.ChildNodes)
                {
                    foreach (TreeNode subNodo in nodo.ChildNodes)
                        GrabarNodoAccion(subNodo);

                    GrabarNodoAccion(nodo);
                }

                hfGraba.Value = "";

                this.ShowInfo("Los cambios se guardaron con éxito.");
            }
            catch (Exception ex)
            {
                this.Manage(ex);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
        }

        protected void gvPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //En caso de que el usuario lo desee, graba las modificaciones introducidas
            if (hfGraba.Value == "true")
                btnAceptar_Click(btnAceptar, null);
            this.hfGraba.Value = "";

            //obtiene el perfil seleccionado
            this.RoleSeleccionado = gvPerfiles.SelectedValue.ToString();
            string[] roleArray = new string[] { this.RoleSeleccionado };

            ////genera una Principal, que solo contiene el perfil seleccionado, de modo de poder ver que acciones tiene habilitadas solo ese perfil
            CustomIdentity customIdentity = new CustomIdentity(WebSessionRepository.Current.Identity.UserId, WebSessionRepository.Current.Identity.Name, WebSessionRepository.Current.Identity.AuthenticationType);
            CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, roleArray);

            UIWebAutorizacionManager autorizacion = UIWebAutorizacionManager.Current;
            List<string[]> contenedores = autorizacion.AutorizarTodoContenedor(customPrincipal);

            treeAcciones.Nodes.Clear();
            TreeNode nodo;
            TreeNode subNodo;

            hfRootText.Value = "(Asignar Todas)";
            TreeNode raiz = new TreeNode(hfRootText.Value);
            raiz.Value = "-1";
            raiz.ShowCheckBox = true;
            raiz.Expand();
            raiz.SelectAction = TreeNodeSelectAction.Expand;

            foreach (string[] rule in contenedores)
            {
                //---------------------------------------------------------------------------------
                nodo = new TreeNode(rule[0]);
                nodo.Value = rule[0];
                nodo.Text = rule[2];
                nodo.ShowCheckBox = true;
                nodo.Checked = ((rule[1] == "S") ? true : false);
                nodo.SelectAction = TreeNodeSelectAction.None;

                List<string[]> items = autorizacion.AutorizarItemsContenedor(customPrincipal,rule[0]);
                foreach (string[] item in items)
                {
                    subNodo = new TreeNode(item[0]);
                    subNodo.Value = item[0];
                    subNodo.Text = item[2];
                    subNodo.ShowCheckBox = true;
                    subNodo.Checked = ((item[1] == "S") ? true : false);
                    subNodo.SelectAction = TreeNodeSelectAction.None;

                    nodo.ChildNodes.Add(subNodo);
                }
                raiz.ChildNodes.Add(nodo);
                //---------------------------------------------------------------------------------
            }
            treeAcciones.Nodes.Add(raiz);
        }

        protected void gvPerfiles_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Attributes.Add("onclick", "onGridViewRowSelected('" + Convert.ToString(e.Row.RowIndex + 1) + "')");
        }

        #endregion

        #region Funciones Publicas
        public bool EvalAsignado(string item)
        {
            if (item == "S")
                return true;
            else
                return false;
        }
        public override IUserInterfaceMessage MessageDisplay
        {
            get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
        }
        #endregion
    }
}
