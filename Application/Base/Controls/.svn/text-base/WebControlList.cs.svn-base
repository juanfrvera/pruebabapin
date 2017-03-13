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
using Ingematica.Librerias.Helpers;
using System.Linq;
using Contract;

namespace UI.Web
{
    public abstract class WebControlList<TResult, TIdType> : WebControlBase, IControlOrder, IControlGrid<TIdType>
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {
        #region Properties
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
                return ((Boolean)ViewState["SortDirection"] == false) ?
                        SortDirection.Ascending : SortDirection.Descending;
            }

            set
            { ViewState["SortDirection"] = value == SortDirection.Descending; }
        }

        private List<int> idsLista;
        /// <summary>
        /// sirver para guardar en viewstate todos los identificadores de una grilla 
        /// la grilla pagina y se necesita recuperar todos los ids para invocar a un servicio
        /// en este conviene poner el atributo view state de la grilla como false.
        /// </summary>
        protected List<int> IdsLista
        {
            get
            {
                if (idsLista == null)
                {
                    if (ViewState["IdsLista"] == null)
                        ViewState["IdsLista"] = new List<TIdType>();
                    idsLista = ViewState["IdsLista"] as List<int>;
                }
                return idsLista;
            }
            set
            {
                ViewState["IdsLista"] = value;
            }
        }
        #endregion

        #region Methods
        //public override void RaiseControlCommand(string commandName, object value)
        //{
        //    switch (commandName)
        //    {
        //        case Command.SORT:
        //            this.clauseOrder = value.ToString();
        //            break;
        //    }
        //    base.RaiseControlCommand(commandName, value);
        //}
        public virtual void ResetOrder() { }
        public abstract object DataSource { get; set; }
        public abstract void DataBind();
        #endregion

        public virtual TIdType GetSelectedId()
        {
            TIdType[] ids = GetSelectedIds();
            if (ids.Length > 0) return ids[0];
            return default(TIdType);
        }
        public virtual TIdType[] GetSelectedIds()
        {
            throw new NotImplementedException();
        }

    }

    public abstract partial class WebControlGrid<TResult, TIdType> : WebControlList<TResult, TIdType>
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {
        protected override void _Initialize()
        {
            base._Initialize();
            GridView.EmptyDataText = Translate("No se encontraron registros...");
        }
        public DisplayExceptionDelegate DisplayException;

        protected abstract TIdType ConvertId(object value);
        //protected abstract bool Can(TIdType id, string actionName);

        public abstract GridView GridView { get; }
        public override object DataSource
        {
            get
            {
                return this.GridView.DataSource;
            }
            set
            {
                this.GridView.DataSource = value;
            }
        }
        public override void DataBind()
        {
            this.GridView.DataBind();
        }
        public override TIdType[] GetSelectedIds()
        {
            return ControlHelper.GetSelectedHtmlInputDataKeys<TIdType>(GridView, "ItemCheckBox");
        }
        public List<TResult> List
        {
            get { return DataSource as List<TResult>; }
        }
        public TResult GetItem(TIdType id)
        {
            if (List == null) return default(TResult);
            return (from o in List where o.ID.Equals(id) select o).FirstOrDefault();
        }

        #region Events
        protected virtual void Grid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            RaiseControlCommand(e.CommandName, e.CommandArgument);
        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridView.PageIndex = 0;
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
                GridView.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        protected virtual void Grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
        }
        #endregion

        #region Can
        public virtual bool CanById(object id, string actionName)
        {
            return PageBase.CanById(id, actionName);
        }

        public virtual string VerificarEstadoDecision(object id, string actionName, string actionNameCurrent)
        {
            return PageBase.VerificarEstadoDecision(id, actionName, actionNameCurrent);
        }

        public virtual bool HideButtonStates(object id, string actionName)
        {
            return PageBase.HideButtonStates(id, actionName);
        }

        public bool CanRead(object id)
        {
            return CanById(id, ActionConfig.READ);
        }
        public bool CanEdit(object id)
        {
            return CanById(ConvertId(id), ActionConfig.UPDATE);
        }
        public bool CanDelete(object id)
        {
            return CanById(ConvertId(id), ActionConfig.DELETE);
        }
        #endregion
    }

    public abstract partial class WebControlGridWithSelection<TResult, TIdType> : WebControlGrid<TResult, TIdType>
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {

        #region Properties
        private List<KeySelected<TIdType>> allSelected;
        protected List<KeySelected<TIdType>> AllSelected
        {
            get
            {
                if (allSelected == null)
                {
                    allSelected = GetParameter<List<KeySelected<TIdType>>>("AllSelected");
                    if (allSelected == null)
                    {
                        allSelected = new List<KeySelected<TIdType>>();
                    }
                }
                return allSelected;
            }
            set
            {
                allSelected = value;
                //ViewState["AllSelected"] = value;
                SetParameter("AllSelected", value);
            }
        }
        #endregion

        protected override void _Load()
        {
            base._Load();
            UpdateAllSelected();
        }
        public override void DataBind()
        {
            this.GridView.DataBind();
            UpdateGridSelected();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            AllSelected = AllSelected;
        }
        protected void UpdateAllSelected()
        {
            if (GridView != null && GridView.Rows.Count > 0)
            {
                List<KeySelected<TIdType>> keysInPage = UIHelper.GetDataKeySelected<TIdType>(GridView, "ItemCheckBox");

                List<KeySelected<TIdType>> deleteds = (from o in AllSelected
                                                       where (from p in keysInPage
                                                              where p.Selected == false
                                                              select p.ID).Contains(o.ID)
                                                       select o
                                                      ).ToList();
                deleteds.ForEach(p => AllSelected.Remove(p));

                List<KeySelected<TIdType>> adds = (from o in keysInPage
                                                   where o.Selected == true && !(from p in AllSelected select p.ID).Contains(o.ID)
                                                   select o).ToList();
                AllSelected.AddRange(adds);
            }
        }
        protected void UpdateGridSelected()
        {
            UIHelper.SetDataKeySelected(GridView, "ItemCheckBox", AllSelected);
        }
        public void ClearAllSelecteds()
        {
            AllSelected = null;
            UpdateGridSelected();
        }
        public override TIdType[] GetSelectedIds()
        {
            return (from o in AllSelected select o.ID).ToArray();
        }
    }
}
