using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Application.Base;
using Application.Controls;
using AjaxControlToolkit;
using Contract;
using Service;
using System.Web.Security;
using UI.Web;
using System.IO;

namespace Application.Shared
{
    public class PageNameComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            x = Path.GetFileNameWithoutExtension(x);
            y = Path.GetFileNameWithoutExtension(y);
            return x.Equals(y, StringComparison.InvariantCultureIgnoreCase);
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
    
    public partial class General : MasterBase
    {  
        #region Properties       

        private string[] pagesEnables;
        public string[] PagesEnables
        {
            get {
                if (pagesEnables == null)
                    pagesEnables =  AuthorizationManager.GetOptions(UIContext.Current.ContextUser,"Menu");
                  return pagesEnables;                        
                }
        }
        private List<MenuItem> menuItems;
        public List<MenuItem> MenuItems
        {
            get {
                if (menuItems == null)
                { 
                    menuItems = SolutionContext.Current.CacheBySessionManager["SLTN_MENU_ITEMS"] as List<MenuItem> ;
                    if (menuItems == null)
                    {
                        menuItems = GetMenuItems();
                        SolutionContext.Current.CacheBySessionManager["SLTN_MENU_ITEMS"] = menuItems;
                    }
                }
                return menuItems; }
            set { 
                    menuItems = value;
                    SolutionContext.Current.CacheBySessionManager["SLTN_MENU_ITEMS"] = value;
                }
        }
        #endregion

        #region Page
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //esto esta por si se pierde la session
            if (!UIContext.Current.IsLogin)
                Response.Redirect("~/Security/frmLogin.aspx");
        }
        protected override void _Initialize()
        {
            base._Initialize();
            if (UIContext.Current.ContextUser != null && UIContext.Current.ContextUser.User != null)
            {
                ctlMasterHeader.UserName = UIContext.Current.ContextUser.User.NombreUsuario ;
                ctlMasterHeader.User = UIContext.Current.ContextUser.User.NombreCompleto;
            }
            else
            {
                ctlMasterHeader.UserName = "";
                ctlMasterHeader.User = "";
            }
            LoadMenu();
           
        }
        #endregion
        
        #region Menu
        public void LoadMenu()
        {
            var isParent = false;
            foreach (MenuItem menu in MenuItems)
            {
                MenuPrincipal.Items.Add(menu);
                if (SiteMap.CurrentNode != null)
                {
                    if (menu.NavigateUrl == SiteMap.CurrentNode.Url && SiteMap.CurrentNode.ParentNode.Title == string.Empty)
                    {
                        menu.Selected = true;
                        isParent = true;
                        Session["CurrentNodeParent"] = menu.NavigateUrl;
                    }
                }
            }
            if(SiteMap.CurrentNode != null && (SiteMap.CurrentNode.Description == "Inversion" || SiteMap.CurrentNode.Description == "Prestamo")) 
            {
                SiteMapPath.Visible=false;
            }
            if(SiteMap.CurrentNode != null && !isParent) SetParentMenuItemSelected();
        }
        private SiteMapNode GetTopParentNode(SiteMapNode node)
        {
            if (node.ParentNode == SiteMap.RootNode)
                return node;
            else
                return GetTopParentNode(node.ParentNode);
        }
        private void SetParentMenuItemSelected()
        {
            if (SiteMap.CurrentNode.ParentNode.ParentNode != null && SiteMap.CurrentNode.ParentNode.ParentNode.Title != string.Empty) 
            {
                var a = MenuItems.Where(x => x.Value == SiteMap.CurrentNode.ParentNode.ParentNode.Title).FirstOrDefault();
                a.Selected = true;
                return;
            }
            else 
            if (SiteMap.CurrentNode.ParentNode.Title != string.Empty)
            {
                var a = MenuItems.Where(x => x.Value == SiteMap.CurrentNode.ParentNode.Title).FirstOrDefault();
                a.Selected = true;
                return;
            }

            if (Session["CurrentNodeParent"] != null)
            {
                var a = MenuItems.Where(x => x.NavigateUrl == (string)Session["CurrentNodeParent"]).FirstOrDefault();
                a.Selected = true;
            }
            
        }

        protected List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (SiteMapNode childNode in SiteMap.RootNode.ChildNodes)
            {
                if (childNode["DisplayInNav"] == "false")
                    continue;
                if (childNode.Url == "" || NodeEnable(childNode))
                {
                    MenuItem childMenu = new MenuItem(childNode.Title, childNode.Title, null, childNode.Url);
                    if (childNode.HasChildNodes) LoadChilds(childMenu, childNode);
                    if(childMenu.ChildItems.Count > 0 || (childMenu.NavigateUrl != null && childMenu.NavigateUrl != string.Empty))
                       menuItems.Add(childMenu);
                }
            }
            return menuItems;
        }
        protected void LoadChilds(MenuItem menu,SiteMapNode node)
        {
            foreach (SiteMapNode childNode in node.ChildNodes)
            {
                if (childNode["DisplayInNav"] == "false")
                    continue;
                if (childNode.Url == "" || NodeEnable(childNode))
                {
                    MenuItem childMenu = new MenuItem(childNode.Title, childNode.Title, null, childNode.Url);    
                    if(childNode.HasChildNodes)LoadChilds(childMenu, childNode);
                    if (childMenu.ChildItems.Count > 0 || (childMenu.NavigateUrl != null && childMenu.NavigateUrl != string.Empty))
                    menu.ChildItems.Add(childMenu);
                }                
            }
        }
        public bool NodeEnable(SiteMapNode node)
        {
            return PagesEnables.Contains(node.Url, new PageNameComparer());
        }
        #endregion
        
        protected override MessageBar MessageDisplay { get { return MessageBarForm; } }

        #region Events
        /*OnMenuItemDataBound="MenuPrincipal_MenuItemDataBound" OnMenuItemClick="MenuPrincipal_MenuItemClick"
         * protected void MenuPrincipal_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (SiteMap.CurrentNode != null)
            {
                if (e.Item.Text == SiteMap.CurrentNode.Title)
                {
                    e.Item.Selected = true;
                }
            }
        }
        protected void MenuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (SiteMap.CurrentNode != null)
            {
                if (e.Item.Text == SiteMap.CurrentNode.Title)
                {
                    e.Item.Selected = true;
                }
            }
        }*/
        
        protected virtual void Password_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmChangePassword.aspx",false);
        }
        protected override ContentPlaceHolder GetMainContent()
        {
            return this.ContenidoPrincipal;
        }
        #endregion
               
    }
}
