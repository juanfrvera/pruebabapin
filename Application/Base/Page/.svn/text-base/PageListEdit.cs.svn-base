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
using System.Linq;
using System.Data.Linq;
using nc = Contract;
using Contract;
using Application.Controls;
namespace UI.Web
{
    /// <summary>
    /// Summary description for PageList
    /// </summary>
    public abstract class PageListEdit<TEntity, TFilter, TResult, TIdType> : CrudPage<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : nc.Filter,new()
        where TResult : class, nc.IResult<TIdType>, new()
        where TIdType : IComparable
    {
        #region Properties
        protected virtual bool IsActivePopup
        {
            get
            {
                if (ViewState["IsActivePopup"] == null)
                {
                    ViewState["IsActivePopup"] = false;
                }
                try
                {
                    return bool.Parse(ViewState["IsActivePopup"].ToString());
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
            set
            {
                ViewState["IsActivePopup"] = value;
            }
        }
        protected virtual string ActivePopupName
        {
            get
            {
                if (ViewState["ActivePopupName"] == null)
                {
                    ViewState["ActivePopupName"] = "";
                }
                try
                {
                    return ViewState["ActivePopupName"].ToString();
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
            set
            {
                ViewState["ActivePopupName"] = value;
            }
        }
        #endregion 

        public WebControlPaggingButtons webControlPaggingButtons;
        
        protected override void _Initialize()
        {
            if (PageBehaviour.ReloadAlways)
                CommandReload();

            if (!this.Can(ActionConfig.LIST))
                Response.Redirect("~/Default.aspx", false);

            base._Initialize();
        }
        protected virtual string SortExpression
        {
            get { return (ViewState["SortExpression"] == null ? string.Empty : ViewState["SortExpression"].ToString()); }
            set
            {
                if (SortExpression == value)
                {
                    SortDirection = SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                }
                else
                {
                    ViewState["SortExpression"] = value;
                    SortDirection = SortDirection.Ascending;
                }
            }
        }
        protected virtual SortDirection SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                try
                {
                    return (SortDirection)ViewState["SortDirection"]; ;
                }
                catch(Exception exception){
                        return SortDirection.Ascending;
                       }
            }
            set
            { 
                ViewState["SortDirection"] =  value; 
            }
        }
        public override IUserInterfaceMessage MessageDisplay
        {
            get
            {
                if (IsActivePopup)
                    return webControlEdit.FindControl("MessageBarForm") as IUserInterfaceMessage;
                else
                    return Master.FindControl("MessageBarForm") as IUserInterfaceMessage;
            }
        }
        
        protected override void _Load()
        {
            base._Load();
            if (webControlList!= null) webControlList.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlFilter!= null) webControlFilter.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlListButtons!=null) webControlListButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlPaggingButtons != null) webControlPaggingButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlEdit != null)
            {
                webControlEdit.ControlCommand += new ControlCommandHandler(ControlCommand);
                webControlEdit.Entity = Entity;
            }
        }

        #region Edition
        protected override void AddNew()
        {
            Entity = EntityService.GetNew();
            CrudAction = CrudActionEnum.Create;
        }
        protected override void Edit()
        {
            TIdType id = webControlList.GetSelectedId();
            Entity = EntityService.GetById(id);        
        }
        protected override void View()
        {
            TIdType id = webControlList.GetSelectedId();
            Entity = EntityService.GetById(id);
        }
        protected override void Copy()
        {
            TIdType id = webControlList.GetSelectedId();
            Entity = EntityService.Copy(id, this.ContextUser);
        }
        protected override void CopyAndSave()
        {
            TIdType id = webControlList.GetSelectedId();
            EntityService.CopyAndSave(id, this.ContextUser);
        }
        protected override void Delete()
        {
            TIdType[] ids = webControlList.GetSelectedIds();
            EntityService.Delete(ids, this.ContextUser);
        }
        protected override void Save()
        {            
            webControlEdit.Entity = Entity;
            webControlEdit.GetValue();
            EntityService.Save(Entity, this.ContextUser);
        }
        protected override void ShowEdit()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.Clear();
            webControlEdit.SetValue();
            //webControlEdit.SetEnable(true,CrudAction != CrudActionEnum.Create);
        }
        protected override void ShowView()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.Clear();
            webControlEdit.SetValue();
            //webControlEdit.SetEnable(false);
        }
        protected override void DisableEdit()
        {
            if (webControlEditionButtons != null)
            {
                webControlEditionButtons.EnableCancel = true;
                webControlEditionButtons.EnableDelete = false;
                webControlEditionButtons.EnableAplicate = false;
                webControlEditionButtons.EnableSave = false;
                webControlEditionButtons.EnableSaveAndNew = false;
            }
        }
        
        #endregion


        #region List
        protected override void RefreshOrder()
        {
            GridViewSortEventArgs e = CommandValue as GridViewSortEventArgs;
            if (e != null)
            {
                //this.SortDirection = e.SortDirection;
                SortExpression = e.SortExpression;
            }
        }
        protected override void ReloadFilter()
        {
            Filter = GetParameter<TFilter>(FilterKey);
            webControlFilter.Filter = Filter;
            webControlFilter.LoadFilter();
            webControlPaggingButtons.Pagging = Filter.Paged;
            webControlPaggingButtons.LoadPagging();
            SortExpression = Filter.OrderByProperty;
            SortDirection = filter.OrderByDesc ? SortDirection.Descending : SortDirection.Ascending;
        }
        protected override void RefreshFilter()
        {
            Filter = webControlFilter.GetFilter();
            Filter.Paged = this.webControlPaggingButtons.GetPagging();
            Filter.OrderByProperty = SortExpression;
            Filter.OrderByDesc = (SortDirection == SortDirection.Descending);
            Filter.GetTotaRowsCount = PageBehaviour.GetTotaRowsCount;
        }
        protected override void Search()
        {
            Filter = webControlFilter.GetFilter();
            this.webControlPaggingButtons.ResetPagging();
            Filter.Paged = this.webControlPaggingButtons.GetPagging();
            Filter.OrderByProperty = SortExpression;
            Filter.OrderByDesc = (SortDirection == SortDirection.Descending);
            Filter.GetTotaRowsCount = PageBehaviour.GetTotaRowsCount;
        }
        protected override void RefreshList()
        {
            SetParameter(FilterKey, Filter);
            ListPaged<TResult> result = EntityService.GetResult(filter);
            if (result.TotalRows.HasValue) this.webControlPaggingButtons.RefreshPagging(result.TotalRows.Value);
            webControlList.DataSource = result;
            webControlList.DataBind();
        }
        
        #endregion

    }
}