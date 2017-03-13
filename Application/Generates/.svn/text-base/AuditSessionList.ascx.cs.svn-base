using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{    
	public partial class AuditSessionList : WebControlList<nc.AuditSessionResult,int>    
    { 
		public override object DataSource
        {
            get{return this.Grid.DataSource;}
            set{this.Grid.DataSource = value;}
        }
        public override void DataBind()
        {
            this.Grid.DataBind();
        }
		#region Events
        protected void Grid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            RaiseControlCommand(e.CommandName, e.CommandArgument);
        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {   
            try
            {                
                Grid.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);                
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grid.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
		#endregion 		
		
		#region Can
        public bool CanEdit(object IdAuditSession)
        {
           int _IdAuditSession;
            if (int.TryParse(IdAuditSession.ToString(), out _IdAuditSession))
                return CanEdit(_IdAuditSession);
            return false;
        }
        public bool CanEdit(int IdAuditSession)
        {
            return AuditSessionService.Current.Can(new Contract.AuditSession() { IdAuditSession = IdAuditSession }, ActionConfig.EDIT, UIContext.Current.ContextUser);
        }
        public bool CanDelete(object IdAuditSession)
        {
           int _IdAuditSession;
            if (int.TryParse(IdAuditSession.ToString(), out _IdAuditSession))
                return CanDelete(_IdAuditSession);
            return false;
        }
        public bool CanDelete(int IdAuditSession)
        {
            return AuditSessionService.Current.Can(new Contract.AuditSession() { IdAuditSession = IdAuditSession }, ActionConfig.DELETE, UIContext.Current.ContextUser);
        }
        #endregion
		
    }
}
