using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Contract;
using nc=Contract;
using System.IO;
using System.Collections.Generic;

namespace UI.Web
{
    [Serializable]
    public class PageLinkData
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public bool IsNewVisible { get; set; }
        public bool Visible { get; set; }
    }

    public abstract partial class WebControlPageTabPanel: WebControlBase
    {
        #region Properties
        private string actualUrl; 
        public string ActualUrl
        {
            get { 
                if(actualUrl==null)
                    actualUrl = Path.GetFileNameWithoutExtension(Request.Url.LocalPath);
                return actualUrl; }
            set { actualUrl = value; }
        }
        private List<PageLinkData> urls;
        public List<PageLinkData> Urls
        {
            get
            {
                if (urls == null)
                {
                    if (ViewState["urls"] != null)
                        urls = ViewState["urls"] as List<PageLinkData>;
                    else
                        urls = GetUrls();
                }
                return urls;
            }
            set
            {
                urls = value;
                ViewState["urls"] = value;
            }
        }
        public virtual List<PageLinkData> GetUrls() { return null; }
        private bool isNew;
        public virtual bool IsNew
        {
            get { return isNew; }
            set
            {
                isNew = value;
                Urls.ForEach(p => p.Visible = isNew == true ? p.IsNewVisible : true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Urls = Urls;
            base.OnPreRender(e);
        }


        #endregion
        public void RefreshData()
        {
            RefreshData(false);
        }
        public void RefreshData(bool isNew)
        {
            this.IsNew = isNew;
            SetValue();
        }
        protected abstract void SetValue();
        
        public string GetTabClass(string url)
        {
            if (Path.GetFileNameWithoutExtension(url) == ActualUrl) return "TabbedPanelsTabSelected";
            return "TabbedPanelsTab";
        } 
        protected void rpTab_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           RaiseControlCommand(e.CommandName, e.CommandArgument);
        }
        
    }
}
