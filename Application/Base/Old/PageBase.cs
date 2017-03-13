using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using AjaxControlToolkit;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Data.Linq.Mapping;
using Application.Controls;
using Ingematica.Librerias.Helpers;

namespace UI.Web
{
    public abstract class PageBaseOLD : Page
    {        
        protected virtual Contract.IContextUser ContextUser
        {
            get { return null; }
        }

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
                        ViewState["IdsLista"] = new List<int>();
                    idsLista = (List<int>)ViewState["IdsLista"];
                }
                return idsLista;
            }
            set
            {
                ViewState["IdsLista"] = value;
            }
        }
        #endregion Properties

        #region Persist
        protected void PersistObject(Object o)
        {
            PersistObject(o, null);
        }
        protected void RestoreObject(Object o)
        {
            RestoreObject(o, null);
        }
        protected void PersistObject(Object o, string[] columns)
        {
            foreach (PropertyInfo po in o.GetType().GetProperties())
            {
                if (PersistProperty(po, columns))
                    ViewState[po.Name] = po.GetValue(o, null);
            }
        }
        protected void RestoreObject(Object o, string[] columns)
        {
            foreach (PropertyInfo po in o.GetType().GetProperties())
            {
                if (PersistProperty(po, columns))
                    po.SetValue(o, ViewState[po.Name], null);
            }
        }
        private static bool PersistProperty(PropertyInfo po, IEnumerable<string> columns)
        {
            bool ok = columns != null && columns.Contains(po.Name);
            if (!ok)
            {
                var ca = po.GetCustomAttributes(false).Where(at => at is ColumnAttribute).SingleOrDefault() as ColumnAttribute;
                if (ca != null)
                {
                    if (ca.IsPrimaryKey || ca.IsVersion)
                        ok = true;
                }
            }
            return ok;
        }
        #endregion PageState

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/HtmlDecode.js", Page.ResolveClientUrl("~/App_Scripts/HtmlDecode.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Pagina.js", Page.ResolveClientUrl("~/App_Scripts/Pagina.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Validar.js", Page.ResolveClientUrl("~/App_Scripts/Validar.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-1.3.2.min.js", Page.ResolveClientUrl("~/App_Scripts/jquery-1.3.2.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-ui-1.7.2.custom.min.js", Page.ResolveClientUrl("~/App_Scripts/jquery-ui-1.7.2.custom.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-json.js", Page.ResolveClientUrl("~/App_Scripts/jquery-json.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/UIHelper.js", Page.ResolveClientUrl("~/App_Scripts/UIHelper.js"));
        }
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreRender(e);
            if (Context.Session.IsNewSession)
            {
                Response.Redirect("~/SessionEnd.aspx",false);
            }
        }
        #endregion Events
          
        #region Abstract Methods
        protected abstract void DisplayError(string message);
        protected abstract void DisplayInfo(string message);
        #endregion Abstract Methods

    }

    /*
    public abstract class PaginaBaseReporte : PaginaBase
    {
        protected virtual void btLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
            }
            catch (Exception ex)
            {
                MostrarErrorForm(ExceptionHelper.Process(ex));
            }
        }

        protected virtual void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.Validators.Count > 1)
                {
                    if (Page.IsValid)
                        Imprimir();
                }
                else
                    Imprimir();
            }
            catch (Exception ex)
            {
                MostrarErrorForm(ExceptionHelper.Process(ex));
            }
        }

        protected virtual void SetearParametros(ListControl lc, string parametros)
        {
            bool existeCero = (from s in parametros.Split(',')
                               where s == 0.ToString()
                               select s).Any();

            foreach (ListItem li in lc.Items)
                if ((existeCero && li.Value == 0.ToString()) || !existeCero)
                    li.Selected = parametros.Split(',').Contains(li.Value) || (li.Value == 0.ToString() && parametros == String.Empty);
        }

        #region filtros

        protected virtual void lbInsumoTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarInsumos();
            }
            catch (Exception ex)
            {
                MostrarErrorForm(ExceptionHelper.Process(ex));
            }
        }

        protected void ActualizarInsumos()
        {
            var lbInsumoTipoFiltro = (ListBox)BuscarControl(Controls, "lbInsumoTipoFiltro");
            var lbInsumoFiltro = (ListBox)BuscarControl(Controls, "lbInsumoFiltro");
            var lbLaborFiltro = (ListBox)BuscarControl(Controls, "lbLaborFiltro");

            lbInsumoFiltro.DataSource = new StockServicio().InsumoBuscar(ListaInts(lbLaborFiltro, false), ListaInts(lbInsumoTipoFiltro, false)).FindAll(it => it.Activo).OrderBy(it => it.Nombre);
            lbInsumoFiltro.DataBind();
            lbInsumoFiltro.Items.Insert(0, new ListItem(MensajesListas.TodosLosInsumos, "0"));
            ControlHelper.SetSelectedItem(lbInsumoFiltro, "0");
        }

        private static ListControl BuscarControl(ControlCollection controles, string id)
        {
            foreach (Control c in controles)
            {
                if (c.Controls.Count > 0)
                {
                    ListControl lcHijo = BuscarControl(c.Controls, id);
                    if (lcHijo != null) return lcHijo;
                }
                if (c is ListControl && c.ID == id)
                    return (ListControl)c;
            }

            return null;
        }

        #endregion

        protected abstract void Imprimir();

        protected abstract void Limpiar();
    }*/
}


