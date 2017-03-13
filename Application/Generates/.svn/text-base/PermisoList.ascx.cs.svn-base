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
	public partial class PermisoList : WebControlList<nc.PermisoResult,int>    
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
        public bool CanEdit(object IdPermiso)
        {
           int _IdPermiso;
            if (int.TryParse(IdPermiso.ToString(), out _IdPermiso))
                return CanEdit(_IdPermiso);
            return false;
        }
        public bool CanEdit(int IdPermiso)
        {
            return PermisoService.Current.Can(new Contract.Permiso() { IdPermiso = IdPermiso }, ActionConfig.EDIT, UIContext.Current.ContextUser);
        }
        public bool CanDelete(object IdPermiso)
        {
           int _IdPermiso;
            if (int.TryParse(IdPermiso.ToString(), out _IdPermiso))
                return CanDelete(_IdPermiso);
            return false;
        }
        public bool CanDelete(int IdPermiso)
        {
            return PermisoService.Current.Can(new Contract.Permiso() { IdPermiso = IdPermiso }, ActionConfig.DELETE, UIContext.Current.ContextUser);
        }
        #endregion
		
    }
}
