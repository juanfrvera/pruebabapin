using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Application.Controls;
using System.Reflection;
using System.ComponentModel;
using AjaxControlToolkit;
using Ingematica.Librerias.Helpers;
using System.Web.UI.WebControls;
using System.Web.Security;
using Service;
using UI.Web;
using Contract;

namespace Application.Base
{
    public abstract class MasterBase : MasterPage
    {
        #region Properties
        public global::Application.Controls.MessageBar MessageBarForm; 
        protected abstract MessageBar MessageDisplay { get; }
        protected abstract ContentPlaceHolder GetMainContent();
        protected SiteMapNode BuscarParent(SiteMapNode siteMapNode)
        {
            if (siteMapNode.ParentNode != null)
            {
                if (String.IsNullOrEmpty(siteMapNode.ParentNode.Url))
                    return siteMapNode;
                else
                    return BuscarParent(siteMapNode.ParentNode);
            }
            else
                return siteMapNode;
        }
        protected IAuthorizationManager AuthorizationManager
        {
            get { return SolutionContext.Current.AuthorizationManager; }
        }
        #endregion
        
        #region Page Methods         
        protected void Page_Load(object sender, EventArgs e)
        {
            this._SetParameters();
            this._Load();
            if (!this.IsPostBack)
            {                
                this._Initialize();
                if (UIContext.Current.HadTranslate)
                   this.TransalteAll();
            }
        }
        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            Response.Redirect("~/frmError.aspx", false);
        }        
        protected virtual void _SetParameters(){}
        protected virtual void _Load() { }
        protected virtual void _Initialize() { }
        #endregion

        #region Translate
        public string Translate(string textCode)
        {
            return UIHelper.Translate(textCode);
        }
        public void TransalteAll()
        {
            UIHelper.TranslateControl(this.Controls, UIContext.Current.LanguageCode);
        }
        #endregion
    }
}
