using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using nc = Contract;
using Contract;
using Service;
namespace UI.Web
{
    public partial class ProyectoDNIPEdit : WebControlEdit<nc.ProyectoIntervencionDNIPCompose>
    {
        protected override void _Initialize()
        {
            PopUpComentarioTecnico.Attributes.CssStyle.Add("display", "none");
            PopUpDictamen.Attributes.CssStyle.Add("display", "none");
            PopUpProyectoPrioridad.Attributes.CssStyle.Add("display", "none");
            base._Initialize();
        }
        public override void SetValue()
        {
            ProyectoDictamenRefresh();
            ProyectoPrioridadRefresh();
            ProyectoComentarioTecnicoRefresh();
        }

        public override void GetValue()
        {
        }

        public override void Clear()
        {
            UIHelper.Clear(gridDictamen);
            UIHelper.Clear(gridProyectoPrioridad);
            UIHelper.Clear(gridProyectoComentarioTecnico);
        }

        #region Dictamen
        private ProyectoDictamenResult actualProyectoDictamen;
        protected ProyectoDictamenResult ActualProyectoDictamen
        {
            get
            {
                if (actualProyectoDictamen == null)
                    if (ViewState["actualProyectoDictamen"] != null)
                        actualProyectoDictamen = ViewState["actualProyectoDictamen"] as ProyectoDictamenResult;
                    else
                    {
                        actualProyectoDictamen = GetNewProyectoDictamen();
                        ViewState["actualProyectoDictamen"] = actualProyectoDictamen;
                    }
                return actualProyectoDictamen;
            }
            set
            {
                actualProyectoDictamen = value;
                ViewState["actualProyectoDictamen"] = value;
            }
        }
        ProyectoDictamenResult GetNewProyectoDictamen()
        {
            return new ProyectoDictamenResult();
        }
        void HidePopUpDictamen()
        {
            ModalPopupExtenderDictamen.Hide();
        }
        void ShowPopUpDictamen()
        {
            ModalPopupExtenderDictamen.Show();
            upDictamenPopUp.Update();
        }
        #region EventosGrillas

        protected void GridDictamen_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoDictamen = (from o in Entity.proyectoDictamen where o.IdProyectoDictamen == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoDictamenEdit();
                    break;

            }

        }

        protected virtual void GridDictamen_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridDictamen.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridDictamen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridDictamen.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveDictamen_Click(object sender, EventArgs e)
        {
        }
        protected void btNewDictamen_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelDictamen1_Click(object sender, EventArgs e)
        {
            ProyectoDictamenClear();
            HidePopUpDictamen();
        }
        #endregion
        #region Commands
        void CommandProyectoDictamenEdit()
        {
            ProyectoDictamenSetValue();
            UIHelper.CallTryMethod(ShowPopUpDictamen);
        }
        void CommandProyectoDictamenSave()
        {

        }
        void CommandProyectoDictamenDelete()
        {
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoDictamenClear()
        {
            pDictamen.Clear();
            ActualProyectoDictamen = GetNewProyectoDictamen();
        }
        void ProyectoDictamenSetValue()
        {
            pDictamen.Entity = ActualProyectoDictamen.ToEntity();
            pDictamen.SetValue();


        }
        void ProyectoDictamenGetValue()
        {

        }
        void ProyectoDictamenRefresh()
        {
            UIHelper.Load(gridDictamen, Entity.proyectoDictamen);
            upDNIP.Update();
        }
        #endregion


        #endregion

        #region ProyectoComentarioTecnico
        private ProyectoComentarioTecnicoResult actualProyectoComentarioTecnico;
        protected ProyectoComentarioTecnicoResult ActualProyectoComentarioTecnico
        {
            get
            {
                if (actualProyectoComentarioTecnico == null)
                    if (ViewState["actualProyectoComentarioTecnico"] != null)
                        actualProyectoComentarioTecnico = ViewState["actualProyectoComentarioTecnico"] as ProyectoComentarioTecnicoResult;
                    else
                    {
                        actualProyectoComentarioTecnico = GetNewProyectoComentarioTecnico();
                        ViewState["actualProyectoComentarioTecnico"] = actualProyectoComentarioTecnico;
                    }
                return actualProyectoComentarioTecnico;
            }
            set
            {
                actualProyectoComentarioTecnico = value;
                ViewState["actualProyectoComentarioTecnico"] = value;
            }
        }
        ProyectoComentarioTecnicoResult GetNewProyectoComentarioTecnico()
        {
            return new ProyectoComentarioTecnicoResult();
        }
        void HidePopUpProyectoComentarioTecnico()
        {
            ModalPopupExtenderComentarioTecnico.Hide();
        }
        void ShowPopUpProyectoComentarioTecnico()
        {
            ModalPopupExtenderComentarioTecnico.Show();
            //upProyectoComentarioTecnicoPopUp.Update();
        }
        #region EventosGrillas

        protected void GridProyectoComentarioTecnico_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "True")
                    e.Row.Cells[4].Text = "Si";
                else
                    e.Row.Cells[4].Text = "No";

            }
        }

        protected void GridProyectoComentarioTecnico_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoComentarioTecnico = (from o in Entity.proyectoComentarioTecnico where o.IdProyectoComentarioTecnico == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoComentarioTecnicoEdit();
                    break;

            }

        }

        protected virtual void GridProyectoComentarioTecnico_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoComentarioTecnico.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        protected virtual void GridProyectoComentarioTecnico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoComentarioTecnico.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoComentarioTecnico_Click(object sender, EventArgs e)
        {
        }
        protected void btNewProyectoComentarioTecnico_Click(object sender, EventArgs e)
        {
        }
        protected void btCancelProyectoComentarioTecnico1_Click(object sender, EventArgs e)
        {
            ProyectoComentarioTecnicoClear();
            HidePopUpProyectoComentarioTecnico();
        }

        #endregion
        #region Commands
        void CommandProyectoComentarioTecnicoEdit()
        {
            ProyectoComentarioTecnicoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoComentarioTecnico);
        }
        void CommandProyectoComentarioTecnicoSave()
        {

        }
        void CommandProyectoComentarioTecnicoDelete()
        {
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoComentarioTecnicoClear()
        {
            ctlProyectoComentarioTecnico.Clear();
            ActualProyectoComentarioTecnico = GetNewProyectoComentarioTecnico();
        }
        void ProyectoComentarioTecnicoSetValue()
        {
            ctlProyectoComentarioTecnico.Entity = ActualProyectoComentarioTecnico.ToEntity();
            ctlProyectoComentarioTecnico.SetValue();
            ((CheckBox)ctlProyectoComentarioTecnico.Controls[35]).Checked = actualProyectoComentarioTecnico.GeneraComentarioTecnico;
            upComentarioTecnicoPopUp.Update();

        }
        void ProyectoComentarioTecnicoGetValue()
        {

        }
        void ProyectoComentarioTecnicoRefresh()
        {
            Entity.proyectoComentarioTecnico = Entity.proyectoComentarioTecnico.OrderByDescending(i => i.Fecha).ToList();

            foreach (ProyectoComentarioTecnicoResult proyectoComentarioTecnico in Entity.proyectoComentarioTecnico)
            {
                ProyectoSeguimientoProyectoFilter filter = new ProyectoSeguimientoProyectoFilter();
                filter.IdProyecto = proyectoComentarioTecnico.IdProyecto;

                ProyectoSeguimientoProyecto seguimiento = ProyectoSeguimientoProyectoService.Current.GetList(filter).FirstOrDefault();

                if (seguimiento != null)
                {


                    foreach (ProyectoSeguimientoEstado seguimientoEstado in seguimiento.ProyectoSeguimiento.ProyectoSeguimientoEstados)
                    {

                        if (seguimientoEstado.GeneraComentarioTecnico)
                        {
                            proyectoComentarioTecnico.GeneraComentarioTecnico = true;
                        }
                    }

                }
            }

            UIHelper.Load(gridProyectoComentarioTecnico, Entity.proyectoComentarioTecnico);
            upDNIP.Update();
            if (Entity.proyectoComentarioTecnico.Count > 0)
                this.cpeComentarioDNIP.Collapsed = false;
        }
        #endregion


        #endregion

        #region ProyectoPrioridad
        private ProyectoPrioridadResult actualProyectoPrioridad;
        protected ProyectoPrioridadResult ActualProyectoPrioridad
        {
            get
            {
                if (actualProyectoPrioridad == null)
                    if (ViewState["actualProyectoPrioridad"] != null)
                        actualProyectoPrioridad = ViewState["actualProyectoPrioridad"] as ProyectoPrioridadResult;
                    else
                    {
                        actualProyectoPrioridad = GetNewProyectoPrioridad();
                        ViewState["actualProyectoPrioridad"] = actualProyectoPrioridad;
                    }
                return actualProyectoPrioridad;
            }
            set
            {
                actualProyectoPrioridad = value;
                ViewState["actualProyectoPrioridad"] = value;
            }
        }
        ProyectoPrioridadResult GetNewProyectoPrioridad()
        {
            return new ProyectoPrioridadResult();
        }
        void HidePopUpProyectoPrioridad()
        {
            ModalPopupExtenderProyectoPrioridad.Hide();
        }
        void ShowPopUpProyectoPrioridad()
        {
            ModalPopupExtenderProyectoPrioridad.Show();
            upProyectoPrioridadPopUp.Update();
        }
        #region EventosGrillas

        protected void GridProyectoPrioridad_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoPrioridad = (from o in Entity.proyectoPrioridad where o.IdProyectoPrioridad == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoPrioridadEdit();
                    break;

            }

        }

        protected virtual void GridProyectoPrioridad_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoPrioridad.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoPrioridad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoPrioridad.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoPrioridad_Click(object sender, EventArgs e)
        {
        }
        protected void btNewProyectoPrioridad_Click(object sender, EventArgs e)
        {
        }

        protected void btCancelProyectoPrioridad1_Click(object sender, EventArgs e)
        {
            ProyectoPrioridadClear();
            HidePopUpProyectoPrioridad();
        }
        #endregion
        #region Commands
        void CommandProyectoPrioridadEdit()
        {
            ProyectoPrioridadSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoPrioridad);
        }
        void CommandProyectoPrioridadSave()
        {

        }
        void CommandProyectoPrioridadDelete()
        {
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoPrioridadClear()
        {
            ctlProyectoPrioridad.Clear();
            ActualProyectoPrioridad = GetNewProyectoPrioridad();
        }
        void ProyectoPrioridadSetValue()
        {
            ctlProyectoPrioridad.Entity = ActualProyectoPrioridad.ToEntity();
            ctlProyectoPrioridad.SetValue();


        }
        void ProyectoPrioridadGetValue()
        {

        }
        void ProyectoPrioridadRefresh()
        {
            //UIHelper.Sort(Entity.proyectoPrioridad, "PlanPeriodo_AnioInicial", SortDirection.Descending );
            Entity.proyectoPrioridad = Entity.proyectoPrioridad.OrderByDescending(i => i.PlanPeriodo_AnioInicial).ToList();
            UIHelper.Load(gridProyectoPrioridad, Entity.proyectoPrioridad);
            upDNIP.Update();
        }
        #endregion






        #endregion

    }
}