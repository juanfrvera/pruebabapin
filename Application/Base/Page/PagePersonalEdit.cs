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
namespace UI.Web
{
    /// <summary>
    /// Summary description for PageList
    /// </summary>
    public abstract class PagePersonalEdit<TEntity, TFilter, TResult, TIdType> : CrudPage<TEntity, TFilter, TResult, TIdType>
        where TEntity : class,new()
        where TFilter : nc.Filter, new()
        where TResult : class,nc.IResult<TIdType>,new()
        where TIdType : IComparable
    { 
        protected override void _Load()
        {
            base._Load();
            if(webControlEdit!=null)webControlEdit.ControlCommand += new ControlCommandHandler(ControlCommand);
            if(webControlEditionButtons!=null)webControlEditionButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (webControlEditionButtons != null) webControlEditionButtons.EnableDelete = EntityService.Can(Entity, ActionConfig.DELETE, this.ContextUser);
            base.OnPreRender(e);
        }
        protected override void AddNew()
        {
            Entity = EntityService.GetNew();                    
        }        
        protected override void Edit()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.GetById(id);                       
        }
        protected override void View()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.GetById(id);
        }
        protected override void Copy()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.Copy(id, this.ContextUser);                      
        }
        protected override void Save()
        {            
            GetValue();
            EntityService.Save(Entity, this.ContextUser);
        }
        protected override void Delete()
        {
            EntityService.Delete(Entity, this.ContextUser);
        }
        protected override void ShowEdit()
        {            
            Clear();
            SetValue(); 
        }
        protected override void ShowView()
        {
            Clear();
            SetValue();
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
        protected override void HideEdit()
        {
            SetParameter(PagePrevious, PARAMETER_ACTION, Command.RELOAD);
            Response.Redirect(PagePrevious,false);
        }
        //protected override void Cancel()
        //{
        //    //SetValue(PathListPage, PARAMETER_ACTION, Command.CANCEL);
        //    //Response.Redirect(PathListPage);
        //    SetValue(PagePrevious, PARAMETER_ACTION, Command.CANCEL);
        //    Response.Redirect(PagePrevious);
        //}
        //protected override void ShowList()
        //{
        //    //SetValue(PathListPage,PARAMETER_ACTION,Command.RELOAD);
        //    //Response.Redirect(PathListPage);
        //    SetValue(PagePrevious, PARAMETER_ACTION, Command.RELOAD);
        //    Response.Redirect(PagePrevious); 
        //}
        //protected override void ReloadFilter()
        //{            
        //}        
        //protected override void RefreshList()
        //{            
        //}
        protected abstract void Clear();
        protected abstract void SetValue();
        protected abstract void GetValue();
    }
}