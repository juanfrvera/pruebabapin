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
    public partial class CacheManagerPageEdit : PageBase
    {
        private const string TextManager ="Caché Textos";
        private const string ParameterManager = "Caché Parámetros";
        private const string AuthorizationManager = "Caché Autorización";
        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            CargarManagers();
        }
        #endregion
        #region Events
        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case Command.DELETE:
                    CommandDelete(id);
                    break;
            }
        }
        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ClearTodos);
        }
        #endregion
        #region Private Methods
        private void CargarManagers()
        {
            List<CacheManagerResult> list = new List<CacheManagerResult>();
            list.Clear();
            list.Add(new CacheManagerResult(SolutionContext.Current.TextManager, TextManager));
            list.Add(new CacheManagerResult(SolutionContext.Current.ParameterManager, ParameterManager));
            list.Add(new CacheManagerResult(SolutionContext.Current.AuthorizationManager, AuthorizationManager));
            UIHelper.Load<CacheManagerResult>((GridView)Grid, list);
        }
        private void CommandDelete(string id)
        {
            switch (id)
            {
                case TextManager:
                    ClearTextManager();
                    break;
                case ParameterManager:
                    ClearParameterManager();
                    break;
                case AuthorizationManager:
                    ClearAuthorizationManager();
                    break;
            }
            Alert();
        }
        private void ClearTextManager()
        {
            SolutionContext.Current.TextManager.Refresh();
        }
        private void ClearParameterManager()
        {
            SolutionContext.Current.ParameterManager.Refresh();
        }
        private void ClearAuthorizationManager()
        {
            SolutionContext.Current.AuthorizationManager.Refresh();
        }
        private void ClearTodos()
        {
            ClearTextManager();
            ClearParameterManager();
            ClearAuthorizationManager();
            Alert();
        }
        private void Alert()
        {
            UIHelper.ShowAlert(Translate("Se Limpió la Caché"), upManagers);
        }
        #endregion
    }
}
