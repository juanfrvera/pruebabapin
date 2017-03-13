using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Service;
using nc = Contract;
using Contract;
using Application.Controls;
using System.IO;
namespace UI.Web
{
    /// <summary>
    /// Summary description for PageList
    /// </summary>
    public abstract class PageEditTabPanel<TEntity, TFilter, TResult, TIdType> : PageEdit<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : nc.Filter, new()
        where TResult : class, nc.IResult<TIdType>, new()
        where TIdType : IComparable
    {       
        #region Controls        
        protected WebControlPageTabPanel webControlPageTabPanel;
        protected WebControlHead<TResult> webControlHead;
        #endregion

        public override PageBehaviour PageBehaviour
        {
            get
            {
                PageBehaviour pageBehaviour = base.PageBehaviour;
                pageBehaviour.HadSerializeEntity = false;
                pageBehaviour.ConfirmOnPageChange = true;
                return pageBehaviour;
            }
        }

        #region Properties
        private string tabCommandName;
        public string TabCommandName
        {
            get
            {
                if (tabCommandName == null)
                    tabCommandName = (ViewState["TabCommandName"] != null) ? ViewState["TabCommandName"].ToString() : Command.ADD_NEW;
                return tabCommandName;
            }
            set
            {
                tabCommandName = value;
                ViewState["TabCommandName"] = value;
            }
        }
        #endregion

        #region Page Methods        
        protected override void _Load()
        {
            base._Load();           
            if (webControlPageTabPanel != null)
            {
                webControlPageTabPanel.ControlCommand += new ControlCommandHandler(ControlCommand);
                //webControlPageTabPanel.Filter                
            }
        }
        #endregion
                          
        #region Commands

        #region Override Commnads
        protected override void CommandApply()
        {
            base.CommandApply();
            TabCommandName = Command.EDIT;
        }
        protected override void CommandAddNew()
        {
            base.CommandAddNew();
            TabCommandName = this.CommandName;            
        }
        protected override void CommandEdit()
        {
            base.CommandEdit();
            TabCommandName = Command.EDIT;
        }
        protected override void CommandView()
        {
            base.CommandView();
            TabCommandName = Command.VIEW;
        }
        protected override void CommandCopy()
        {
            base.CommandCopy();
            TabCommandName = Command.EDIT;
        }
        protected override void CommandSave()
        {
            base.CommandSave();
            TabCommandName = Command.EDIT;
        }
        protected override void CommandSaveAndNew()
        {
            base.CommandSaveAndNew();
            TabCommandName = Command.ADD_NEW;            
        }
        protected override void CommandViewLog()
        {
            base.CommandViewLog();
            TabCommandName = Command.VIEW_LOG;
        }
        #endregion

        protected override void ShowEdit()
        {
            base.ShowEdit();
            ShowHead();         
        }
        protected override void ShowView()
        {
            base.ShowView();
            ShowHead();
        }
        protected virtual void ShowHead()
        {
            if (webControlPageTabPanel != null)
            {
                List<PageLinkData> urls = GetTabUrls();
                if (urls != null && urls.Count > 0) webControlPageTabPanel.Urls = urls;
                webControlPageTabPanel.RefreshData(CrudAction == CrudActionEnum.Create);
            }
            if (webControlHead != null)
            {
                if (CrudAction == CrudActionEnum.Create)
                {
                    webControlHead.HeadVisible = false;
                }
                else
                {
                    webControlHead.HeadVisible = true;
                    webControlHead.Set(GetHeadResult());
                }
            }
            if (webControlPaggingInPage != null)
            {
                if (CrudAction == CrudActionEnum.Create)
                {
                    webControlPaggingInPage.Visible = false;
                }
                else
                {
                    webControlPaggingInPage.Visible = true;
                }
            }
        }
        protected virtual TResult GetHeadResult() { return new TResult();}
        protected virtual List<PageLinkData> GetTabUrls() { return new List<PageLinkData>(); }
        protected override void HideEdit()
        {
            string nextPage = "";            
            if (webControlPageTabPanel != null)
            {
                if (webControlPageTabPanel.Urls.Exists(p => Path.GetFileNameWithoutExtension(p.Url) == Path.GetFileNameWithoutExtension(PagePrevious)))
                {
                    if (PathListPage != null && PathListPage.Trim() != string.Empty)
                        nextPage = PathListPage;
                    else
                        nextPage = "~/Default.aspx";
                }
                else
                    nextPage = PagePrevious;
            }
            else
            {
                nextPage = PagePrevious; 
            }
            SetParameter(nextPage, PARAMETER_ACTION, Command.RELOAD);
            Response.Redirect(nextPage,false);
        }


        protected override void CommandOthers()
        {
            string pageChange = "";
            switch (CommandName)
            {
                case Command.CONFIRM_CHANGE_PAGE:
                    if (PageBehaviour.ConfirmOnPageChange)
                    {
                        webControlEdit.Entity = Entity;
                        webControlEdit.GetValue();
                        if (TabCommandName == Command.EDIT && !EntityService.Equals(Entity, EntityOld) && webControlConfirm != null)
                        {
                            webControlConfirm.SetTitulo(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE_TITLE"));
                            webControlConfirm.SetMensaje(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE"));
                            webControlConfirm.CommandName = Command.CHANGE_PAGE;
                            webControlConfirm.CommandValue = (string)CommandValue;
                            webControlConfirm.Show();
                            return;
                        }
                        else
                        {
                            TIdType id = EntityService.GetId(Entity);
                            pageChange = (string)CommandValue;
                            SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                            SetParameter(pageChange, PARAMETER_VALUE, id.ToString());
                            Response.Redirect(pageChange, false);
                        }
                    }
                    else
                    {
                        TIdType id = EntityService.GetId(Entity);
                        pageChange = (string)CommandValue;
                        SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                        SetParameter(pageChange, PARAMETER_VALUE, id.ToString());
                        Response.Redirect(pageChange, false);
                    }
                    break;
                case Command.CHANGE_PAGE:
                    
                    TIdType Eid = EntityService.GetId(Entity);
                    pageChange = (string)CommandValue;
                    SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                    SetParameter(pageChange, PARAMETER_VALUE, Eid.ToString());
                    Response.Redirect(pageChange, false);
                    break;
                case Command.CANCEL_POPUP:
                    if (webControlConfirm != null)
                    {
                        webControlConfirm.Hide();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}