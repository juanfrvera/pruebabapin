using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;
using UI.Web.Pages;

namespace UI.Web 
{
    public partial class PrestamoComponentesEdit : WebControlEdit<nc.PrestamoComponenteCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();


            autoCmpIndicadorClase.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            //German 20140302 - tarea 110
            autoCmpIndicadorClase.Visible = false;
            toIndicadoClase.RequiredMessage = TranslateFormat("FieldIsNull", "Tipo de Indicador");
            //Fin German 20140302 - tarea 110
            tsEvolucion.Width = 470;
            tsEvolucion.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            diFechaEstimadaEvolucion.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
            rfvTipoEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Evolución");
            rfvCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Cantidad Estimada");
            rfvMontoAcumulado.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Acumulado");

            revCantidadEstimadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Estimada");

            revCantidadRealizadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadRealizadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Realizada");             
            
            
            diD_Fecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");

            rfvComponente.ErrorMessage = TranslateFormat("FieldIsNull", "Componente");
            tsFuenteFinanciamiento.RequiredMessage = TranslateFormat("FieldIsNull", "Fuente Financiamiento");
            rfvMontoFinanciamiento.ErrorMessage = TranslateFormat("FieldIsNull", "Monto");
            rfvComp.ErrorMessage = TranslateFormat("FieldIsNull", "Componente");
            rfvSubComp.ErrorMessage = TranslateFormat("FieldIsNull", "SubComponente");
            // Componentes
            PopUpComponentes.Attributes.CssStyle.Add("display", "none");
            // Financiamientos
            PopUpFinanciamientos.Attributes.CssStyle.Add("display", "none");
            // Desembolsos
            PopUpDesembolsos.Attributes.CssStyle.Add("display", "none");
            // Indicadores
            PopUpIndicadores.Attributes.CssStyle.Add("display", "none");
            // Evoluciones
            PopUpEvoluciones.Attributes.CssStyle.Add("display", "none");
            // Supuestos
            PopUpSupuestos.Attributes.CssStyle.Add("display", "none");
            // Mensaje
            PopUpMensajes.Attributes.CssStyle.Add("display", "none");

            CargarCombos();

            autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //German 20140302 - tarea 110
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //Fin German 20140302 - tarea 110

		}
        protected override void _Load()
        {
            base._Load();

            PrestamoDesembolsoRefresh();
            EvolucionesRefresh();
            SupuestosRefresh();
            IndicadoresRefresh();
            RecalcularMontosComponentes();
        }
		public override void Clear()
        {            
        }	
        public override void GetValue()
        {
            //Matias 20140428 - Tarea 140.
            /*
            if (!Entity.ValidoMontoTotal())
            {
                ltMensajeErrorMonto.Text = Translate("- Los montos superan el total del Préstamo");
                UIHelper.ShowAlert(ltMensajeErrorMonto.Text, upGridComponentes);
                
                //upMensajesPopUp.Update(); Esta sentencia ya estaba comentada - No comentado por Matias.
                //ModalPopupExtenderMensajes.Show(); Esta sentencia ya estaba comentada - No comentado por Matias.
            }
            */
            //FinMatias 20140428 - Tarea 140.
        }
        public override void SetValue()
        {
            PrestamoComponenteRefresh();
            PrestamoFinanciamientoRefresh();
            PrestamoDesembolsoRefresh();
            EvolucionesRefresh();
            SupuestosRefresh();
            IndicadoresRefresh();
        }
        #endregion Override 
                
        #region Sobre Componentes

        private PrestamoObjetivoComponenteCompose actualPrestamoComponente;
        protected PrestamoObjetivoComponenteCompose ActualPrestamoComponente
        {
            get
            {
                if (actualPrestamoComponente == null)
                {
                    if (ExistsPersist("actualPrestamoComponente"))
                        actualPrestamoComponente = ((PrestamoObjetivoComponenteCompose)GetPersist("actualPrestamoComponente"));
                    else
                    {
                        if (Entity.Componentes.Count != 0)
                        {
                            actualPrestamoComponente = Entity.Componentes.First();
                            SetPersist("actualPrestamoComponente", actualPrestamoComponente);
                        }
                        else
                        {
                            actualPrestamoComponente = GetNewComponente();
                            SetPersist("actualPrestamoComponente", actualPrestamoComponente);
                        }
                    }
                }
                return actualPrestamoComponente;
            }
            set
            {
                actualPrestamoComponente = value;
                SetPersist("actualPrestamoComponente", value);
            }
        }
        PrestamoObjetivoComponenteCompose GetNewComponente()
        {
            int id = 0;
            if (Entity.Componentes.Count > 0) id = Entity.Componentes.Min(l => l.Componente.IdPrestamoComponente);
            if (id > 0) id = 0;
            id--;
            PrestamoObjetivoComponenteCompose plResult = new PrestamoObjetivoComponenteCompose();
            plResult.Componente.IdPrestamoComponente = id;
            plResult.Componente.IdPrestamo = Entity.IdPrestamo;
            return plResult;
        }

        #region Methods
        void HidePopUpComponentes()
        {
            ModalPopupExtenderComponentes.Hide();
        }
        void PrestamoComponenteClear()
        {
            UIHelper.Clear(txtComponente);
            upComponentesPopUp.Update();
        }
        void PrestamoComponenteSetValue()
        {
            UIHelper.SetValue(txtComponente, ActualPrestamoComponente.Componente.Objetivo_Nombre);
        }
        void PrestamoComponenteGetValue()
        {
            ActualPrestamoComponente.Componente.Objetivo_Nombre = UIHelper.GetString(txtComponente);
        }
        void PrestamoComponenteRefresh()
        {
            ddlF_Componente.Items.Clear();

            RecalcularMontosComponentes();
            UIHelper.Load(gridComponentes, Entity.Componentes);
            List<PrestamoComponenteResult> aux = (from c in Entity.Componentes select c.Componente).ToList();
            if (aux.Count >0)
                UIHelper.Load<nc.PrestamoComponenteResult>(ddlF_Componente, aux, "Objetivo_Nombre", "IdPrestamoComponente");
            if (ActualPrestamoComponente != null)
                MarcarPrestamoComponente(ActualPrestamoComponente.ID);
            upGridComponentes.Update();

            btAgregarSubComponente.Enabled = aux.Count > 0;
            btAgregarIndicadorComponente.Enabled = aux.Count > 0;
            pnlAgregarSubComponente.Update();
            upAgregarIndicadorComponente.Update();
            PrestamoFinanciamientoRefresh();
            PrestamoSubComponenteRefresh();
        }

        void MarcarPrestamoComponente(Int32 idPrestamoComponente)
        {
            foreach (PrestamoObjetivoComponenteCompose pe in Entity.Componentes) 
            {
                if (pe.Componente.IdPrestamoComponente == idPrestamoComponente)
                {
                    ActualPrestamoComponente = pe;
                    PrestamoSubComponenteRefresh();
                    IndicadoresRefresh();
                }
            }
            bool somecheck = false;
            foreach (GridViewRow row in gridComponentes.Rows)
            {
                Int32 idRowAux = Int32.Parse(gridComponentes.DataKeys[row.RowIndex].Value.ToString());
                RadioButton rb = ((RadioButton)row.Cells[0].FindControl("rbComponente"));
                rb.Checked = idRowAux == idPrestamoComponente;
                somecheck = somecheck || rb.Checked;
            }
            if (!somecheck && gridComponentes.Rows.Count > 0)
            {
                GridViewRow row = gridComponentes.Rows[0];
                Int32 idRow = Int32.Parse(gridComponentes.DataKeys[row.RowIndex].Value.ToString());
                MarcarPrestamoComponente(idRow);
            }
            
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoComponenteEdit()
        {
            PrestamoComponenteSetValue();
            ModalPopupExtenderComponentes.Show();
            upComponentesPopUp.Update();
        }
        void CommandPrestamoComponenteSave()
        {
            PrestamoComponenteGetValue();

            if (ActualPrestamoComponente.Componente.Objetivo_Nombre != "")
            {
                PrestamoObjetivoComponenteCompose result = (from l in Entity.Componentes
                                                            where l.Componente.IdPrestamoComponente == ActualPrestamoComponente.Componente.ID
                                                            select l).FirstOrDefault();
                if (result != null)
                {
                    result.Componente.Objetivo_Nombre = ActualPrestamoComponente.Componente.Objetivo_Nombre;
                }
                else
                {
                    Entity.Componentes.Add(ActualPrestamoComponente);
                }
                ddlF_Componente.Enabled = Entity.Componentes.Count > 0;
                PrestamoComponenteRefresh();
                ManejarCombos();
            }
        }
        void CommandPrestamoComponenteDelete()
        {
            // SUBCOMPONENTES
            foreach (PrestamoSubComponenteResult scr in Entity.Subcomponentes.Where(l => l.IdPrestamoComponente == ActualPrestamoComponente.Componente.ID).ToList())
            {
                PrestamoSubComponenteResult results = (from l in Entity.Subcomponentes where l.IdPrestamoSubComponente == scr.ID select l).FirstOrDefault();
                Entity.Subcomponentes.Remove(results);
            }
            PrestamoSubComponenteClear();
            PrestamoSubComponenteRefresh();

            // FINANCIAMIENTOS
            foreach (PrestamoFinanciamientoResult pfr in Entity.Financiamientos.Where(l => l.IdPrestamoComponente == ActualPrestamoComponente.Componente.ID).ToList())
            {
                PrestamoFinanciamientoResult resultf = (from l in Entity.Financiamientos where l.IdPrestamoFinanciamiento == pfr.ID select l).FirstOrDefault();
                Entity.Financiamientos.Remove(resultf);
            }
            PrestamoFinanciamientoClear();
            PrestamoFinanciamientoRefresh();
            RecalcularMontosComponentes();

            PrestamoObjetivoComponenteCompose result = (from l in Entity.Componentes where l.Componente.IdPrestamoComponente == ActualPrestamoComponente.Componente.ID select l).FirstOrDefault();
            Entity.Componentes.Remove(result);
            PrestamoComponenteClear();
            PrestamoComponenteRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveComponente_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoComponenteSave);
            if (ActualPrestamoComponente.Componente.Objetivo_Nombre != "")
                HidePopUpComponentes();
        }
        protected void btNewComponente_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoComponenteSave);
            PrestamoComponenteClear();
            ActualPrestamoComponente = GetNewComponente();
            txtComponente.Focus();
        }
        protected void btCancelComponente_Click(object sender, EventArgs e)
        {
            PrestamoComponenteClear();
            HidePopUpComponentes();
            if (Entity.Componentes.Count > 0)
            {
                MarcarPrestamoComponente(Entity.Componentes[0].Componente.IdPrestamoComponente);
            }
        }
        protected void btAgregarComponente_Click(object sender, EventArgs e)
        {
            PrestamoComponenteClear();
            ActualPrestamoComponente = GetNewComponente();
            ModalPopupExtenderComponentes.Show();
            txtComponente.Focus();
        }
        public void rbComponente_OnCheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = ((GridViewRow)((WebControl)sender).NamingContainer);
            Int32 idRow = Int32.Parse(gridComponentes.DataKeys[gvr.RowIndex].Value.ToString());
            MarcarPrestamoComponente(idRow);
        }
        protected void GridComponente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
                ((RadioButton)e.Row.Cells[0].FindControl("rbComponente")).Checked = true;
        }
        protected void btCancelMensaje_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderMensajes.Hide();
        }
        #endregion

        #region EventosGrillas
        protected void GridComponentes_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoComponente = (from l in Entity.Componentes where l.Componente.IdPrestamoComponente == id select l).FirstOrDefault();

            

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoComponenteEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoComponenteDelete();
                    break;
                case Command.SHOW_DETAILS:
                    lblTituloSupuestos.Text = ActualPrestamoComponente.Descripcion; 
                    ShowPopUpSupuestos();
                    break;
            }
        }
        protected virtual void GridComponentes_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridComponentes.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridComponentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridComponentes.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Componente

        #region Sobre Supuestos

        private ObjetivoSupuestoResult actualObjetivoSupuesto;
        protected ObjetivoSupuestoResult ActualObjetivoSupuesto
        {
            get
            {
                if (actualObjetivoSupuesto == null)
                    if (ViewState["actualObjetivoSupuesto"] != null)
                        actualObjetivoSupuesto = ViewState["actualObjetivoSupuesto"] as ObjetivoSupuestoResult;
                    else
                    {
                        actualObjetivoSupuesto = GetNewSupuesto();
                        ViewState["actualObjetivoSupuesto"] = actualObjetivoSupuesto;
                    }
                return actualObjetivoSupuesto;
            }
            set
            {
                actualObjetivoSupuesto = value;
                ViewState["actualObjetivoSupuesto"] = value;
            }
        }
        ObjetivoSupuestoResult GetNewSupuesto()
        {
            int id = 0;
            if (ActualPrestamoComponente.Supuestos.Count > 0) id = ActualPrestamoComponente.Supuestos.Min(l => l.IdObjetivoSupuesto);
            if (id > 0) id = 0;
            id--;
            ObjetivoSupuestoResult objetivoSupuestoResult = new ObjetivoSupuestoResult();
            objetivoSupuestoResult.IdObjetivoSupuesto = id;
            //objetivoSupuestoResult.IdObjetivo = ActualPrestamoComponente.Componente.IdObjetivo;                   
            return objetivoSupuestoResult;
        }

        #region Methods
        void HidePopUpSupuestos()
        {
            ModalPopupExtenderSupuestos.Hide();
        }
        void ShowPopUpSupuestos()
        {
            SupuestosRefresh();
            btNewSupuesto.Enabled = true;
            btSaveSupuesto.Enabled = false;
            upSupuestosPopUp.Update();
            ModalPopupExtenderSupuestos.Show();
        }
        void SupuestosClear()
        {
            UIHelper.Clear(txtSupuesto);
            ActualObjetivoSupuesto = GetNewSupuesto();
        }
        void SupuestosSetValue()
        {
            UIHelper.SetValue(txtSupuesto, ActualObjetivoSupuesto.Descripcion);
        }
        void SupuestosGetValue()
        {
            ActualObjetivoSupuesto.Descripcion = UIHelper.GetString(txtSupuesto);
        }
        void SupuestosRefresh()
        {
            UIHelper.Load(gridSupuestos, ActualPrestamoComponente.Supuestos, "Descripcion");
            upGridSupuestos.Update();
        }
        #endregion Methods

        #region Eventos
        protected void btSaveSupuesto_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandSupuestoSave);
        }
        protected void btNewSupuesto_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandSupuestoSave);
        }
        protected void btCancelSupuesto_Click(object sender, EventArgs e)
        {
            SupuestosClear();

            if (ActualPrestamoComponente is PrestamoObjetivoComponenteCompose)
            {

                PrestamoObjetivoComponenteCompose PrestamoObjetivoComponenteCompose = (from l in Entity.Componentes
                                                                       where l.Componente.ID == ActualPrestamoComponente.Componente.ID
                                                                       select l).FirstOrDefault();

                PrestamoObjetivoComponenteCompose.Supuestos = ActualPrestamoComponente.Supuestos;
            }
            HidePopUpSupuestos();
        }
        protected void btAgregarSupuesto_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderSupuestos.Show();
            txtSupuesto.Focus();
        }
        #endregion

        #region Commands
        void CommandSupuestoEdit()
        {
            SupuestosSetValue();
            btNewSupuesto.Enabled = false;
            btSaveSupuesto.Enabled = true;
            upSupuestosPopUp.Update();
            upSupuestosPopUp.Update();
        }
        void CommandSupuestoSave()
        {
            SupuestosGetValue();
            if (ActualObjetivoSupuesto.Descripcion != "")
            {
                ObjetivoSupuestoResult osr = (from l in ActualPrestamoComponente.Supuestos
                                              where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                              select l).FirstOrDefault();
                if (osr != null)
                {
                    osr.Descripcion = ActualObjetivoSupuesto.Descripcion;
                }
                else
                {
                    ActualPrestamoComponente.Supuestos.Add(ActualObjetivoSupuesto);
                }

                SupuestosClear();
                SupuestosRefresh();
                btNewSupuesto.Enabled = true;
                btSaveSupuesto.Enabled = false;
                upSupuestosPopUp.Update();
            }
        }
        void CommandSupuestoDelete()
        {
            ObjetivoSupuestoResult result = (from l in ActualPrestamoComponente.Supuestos
                                             where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                             select l).FirstOrDefault();

            ActualPrestamoComponente.Supuestos.Remove(result);
            SupuestosClear();
            SupuestosRefresh();
        }
        #endregion

        #region EventosGrillas
        protected void GridImageButtonSupuestos_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualObjetivoSupuesto = (from l in ActualPrestamoComponente.Supuestos
                                      where l.IdObjetivoSupuesto == id
                                      select l).FirstOrDefault();
            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandSupuestoEdit();
                    break;
                case Command.DELETE:
                    CommandSupuestoDelete();
                    break;
            }
        }
        protected void GridSupuestos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualObjetivoSupuesto = (from l in ActualPrestamoComponente.Supuestos
                                      where l.IdObjetivoSupuesto == id
                                      select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandSupuestoEdit();
                    break;
                case Command.DELETE:
                    CommandSupuestoDelete();
                    break;
            }

        }
        protected virtual void GridSupuestos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridSupuestos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridSupuestos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridSupuestos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Supuestos

        #region Sobre SubComponentes

        private PrestamoSubComponenteResult actualPrestamoSubComponente;
        protected PrestamoSubComponenteResult ActualPrestamoSubComponente
        {
            get
            {
                if (actualPrestamoSubComponente == null)
                {
                    if (ExistsPersist("actualPrestamoSubComponente"))
                        actualPrestamoSubComponente = ((PrestamoSubComponenteResult)GetPersist("actualPrestamoSubComponente"));
                    else
                    {
                        actualPrestamoSubComponente = GetNewSubComponente();
                        SetPersist("actualPrestamoSubComponente", actualPrestamoSubComponente);
                    }
                }
                return actualPrestamoSubComponente;
            }
            set
            {
                actualPrestamoSubComponente = value;
                SetPersist("actualPrestamoSubComponente", value);
            }
        }
        PrestamoSubComponenteResult GetNewSubComponente()
        {
            int id = 0;
            if (Entity.Subcomponentes.Count > 0) id = Entity.Subcomponentes.Min(l => l.IdPrestamoSubComponente);
            if (id > 0) id = 0;
            id--;
            PrestamoSubComponenteResult plResult = new PrestamoSubComponenteResult();
            plResult.IdPrestamoSubComponente = id;
            plResult.IdPrestamoComponente = ActualPrestamoComponente.Componente.IdPrestamoComponente;
            return plResult;
        }

        #region Methods
        void HidePopUpSubComponentes()
        {
            ModalPopupExtenderSubComponentes.Hide();
        }
        void PrestamoSubComponenteClear()
        {
            UIHelper.Clear(txtSubComponente);
            ActualPrestamoSubComponente = GetNewSubComponente();
        }
        void PrestamoSubComponenteSetValue()
        {
            UIHelper.SetValue(txtSubComponente, ActualPrestamoSubComponente.Descripcion);
        }
        void PrestamoSubComponenteGetValue()
        {
            ActualPrestamoSubComponente.Descripcion = UIHelper.GetString(txtSubComponente);
        }
        void PrestamoSubComponenteRefresh()
        {
            UIHelper.Load(gridSubComponentes, Entity.Subcomponentes.Where(s => s.IdPrestamoComponente == ActualPrestamoComponente.Componente.IdPrestamoComponente).ToList(), "Orden");
            upGridSubComponentes.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoSubComponenteEdit()
        {
            PrestamoSubComponenteSetValue();
            ModalPopupExtenderSubComponentes.Show();
            upSubComponentesPopUp.Update();
        }
        void CommandPrestamoSubComponenteSave()
        {
            PrestamoSubComponenteGetValue();
            if (ActualPrestamoSubComponente.Descripcion != "")
            {
                PrestamoSubComponenteResult result = (from l in Entity.Subcomponentes
                                                      where l.IdPrestamoSubComponente == ActualPrestamoSubComponente.ID
                                                      select l).FirstOrDefault();
                if (result != null)
                {
                    result.Descripcion = ActualPrestamoSubComponente.Descripcion;
                }
                else
                {
                    Entity.Subcomponentes.Add(ActualPrestamoSubComponente);
                }
                PrestamoSubComponenteClear();
                PrestamoSubComponenteRefresh();
            }
        }
        void CommandPrestamoSubComponenteDelete()
        {
            PrestamoSubComponenteResult result = (from l in Entity.Subcomponentes where l.IdPrestamoSubComponente == ActualPrestamoSubComponente.ID select l).FirstOrDefault();
            Entity.Subcomponentes.Remove(result);
            PrestamoSubComponenteClear();
            PrestamoSubComponenteRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveSubComponente_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoSubComponenteSave);
            if (ActualPrestamoSubComponente.Descripcion!="")
                HidePopUpSubComponentes();
        }
        protected void btNewSubComponente_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoSubComponenteSave);
            txtSubComponente.Focus();
        }
        protected void btCancelSubComponente_Click(object sender, EventArgs e)
        {
            PrestamoSubComponenteClear();
            HidePopUpSubComponentes();
        }
        protected void btAgregarSubComponente_Click(object sender, EventArgs e)
        {
            PrestamoSubComponenteClear();
            ModalPopupExtenderSubComponentes.Show();
            txtSubComponente.Focus();
        }
        #endregion

        #region EventosGrillas
        protected void GridSubComponentes_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoSubComponente = (from l in Entity.Subcomponentes where l.IdPrestamoSubComponente == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoSubComponenteEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoSubComponenteDelete();
                    break;
            }
        }
        protected virtual void GridSubComponentes_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridSubComponentes.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridSubComponentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridSubComponentes.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected void GridImageButtonSC_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoSubComponente = (from l in Entity.Subcomponentes where l.IdPrestamoSubComponente == id select l).FirstOrDefault();

            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoSubComponenteEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoSubComponenteDelete();
                    break;
            }
        }
        #endregion

        #endregion SubComponente

        #region Sobre Indicadores

        // ActualIndicadorComponente
        private ObjetivoIndicadorCompose actualIndicadorComponente;
        protected ObjetivoIndicadorCompose ActualIndicadorComponente
        {
            get
            {
                if (actualIndicadorComponente == null)
                    if (ViewState["actualIndicadorComponente"] != null)
                        actualIndicadorComponente = ViewState["actualIndicadorComponente"] as ObjetivoIndicadorCompose;
                    else
                    {
                        actualIndicadorComponente = GetNewIndicador(ActualPrestamoComponente);
                        ViewState["actualIndicadorComponente"] = actualIndicadorComponente;
                    }
                return actualIndicadorComponente;
            }
            set
            {
                actualIndicadorComponente = value;
                ViewState["actualIndicadorComponente"] = value;
            }
        }
        ObjetivoIndicadorCompose GetNewIndicador(ObjetivoCompose objetivoCompose)
        {
            ObjetivoIndicadorCompose objetivoIndicadorCompose = new ObjetivoIndicadorCompose();
            if (objetivoCompose != null)
            {
                int id = 0;
                if (objetivoCompose.Indicadores.Count > 0) id = objetivoCompose.Indicadores.Min(l => l.Indicador.IdObjetivoIndicador);
                if (id > 0) id = 0;
                id--;
                objetivoIndicadorCompose.Indicador = new ObjetivoIndicadorResult();
                objetivoIndicadorCompose.Indicador.IdIndicador = id;
                objetivoIndicadorCompose.Indicador.IdObjetivoIndicador = id;
                objetivoIndicadorCompose.Evoluciones = new List<IndicadorEvolucionResult>();
            }
            return objetivoIndicadorCompose;
        }

        #region Methods
        void HidePopUpIndicadores()
        {
            ModalPopupExtenderIndicadores.Hide();
        }
        void IndicadoresClear()
        {
           
            UIHelper.Clear(lblErrorIndicadores);
            UIHelper.Clear(txtObservacionesIndicadores);
            UIHelper.Clear(autoCmpIndicadorClase);
            //German 20140302 - tarea 110
            UIHelper.Clear(toIndicadoClase);
            //Fin German 20140302 - tarea 110
            UIHelper.Clear(ddlMedioVerificacion);

            autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };

            //German 20140302 - tarea 110
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //Fin German 20140302 - tarea 110
            
            ActualIndicadorComponente = GetNewIndicador(ActualPrestamoComponente);

            upIndicadoresPopUp.Update();

        }
        void IndicadoresSetValue()
        {
            UIHelper.SetValue(autoCmpIndicadorClase, ActualIndicadorComponente.Indicador.IdIndicadorClase);
            //German 20140302 - tarea 110
            UIHelper.SetValue(toIndicadoClase, ActualIndicadorComponente.Indicador.IdIndicadorClase);
            //FinGerman 20140302 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadoClase.Sectores, ActualIndicadorComponente.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124
            UIHelper.SetValue(ddlMedioVerificacion, ActualIndicadorComponente.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadores, ActualIndicadorComponente.Indicador.Indicador_Observacion);
        }
        void IndicadoresGetValue()
        {
            ActualIndicadorComponente.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadores);
            ActualIndicadorComponente.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacion);

            ActualIndicadorComponente.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClase);

            //German 20140302 - tarea 110
            ActualIndicadorComponente.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadoClase);
            //FinGerman 20140302 - tarea 110
            //German 20140511 - Tarea 124
            ActualIndicadorComponente.Indicador.IdIndicadorRubro = UIHelper.GetIntNullable(toIndicadoClase.Sectores);
            //FinGerman 20140511 - Tarea 124
            
            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualIndicadorComponente.Indicador.IdIndicadorClase }).FirstOrDefault();


            ActualIndicadorComponente.Indicador.IndicadorClase_Sigla = result.Sigla;
            ActualIndicadorComponente.Indicador.IndicadorClase_Nombre = result.Nombre;
            ActualIndicadorComponente.Indicador.IndicadorClase_Unidad = result.Unidad_Nombre;

            if (ActualIndicadorComponente.Indicador.Indicador_IdMedioVerificacion != null)
            {
                ActualIndicadorComponente.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacion);
            }
            else
            {
                ActualIndicadorComponente.Indicador.Indicador_MedioVerificacion = string.Empty;
            }             

         
        }
        void IndicadoresRefresh()
        {
            UIHelper.Load(gridIndicadoresComponente, (from i in ActualPrestamoComponente.Indicadores select i.Indicador).ToList(), "IndicadorClase_Nombre");
            upGridIndicadoresComponente.Update();
        }
        bool ValidateIndicadores(ObjetivoCompose objetivoCompose, out string msgError)
        {
            msgError = string.Empty;
            int id = UIHelper.GetInt(autoCmpIndicadorClase);

            //German 20140302 - tarea 110
            if (autoCmpIndicadorClase.Visible == false)
                id = UIHelper.GetInt(toIndicadoClase);
            //Fin German 20140302 - tarea 110
            
            int idIndicador = ActualIndicadorComponente.Indicador.IdObjetivoIndicador;

            if (objetivoCompose.Indicadores.Where(p => (p.Indicador.IdObjetivoIndicador != idIndicador) && (p.Indicador.IdIndicadorClase == id)).Count() > 0)
            {
                msgError = Translate("- No puede haber más de un indicador de la misma clase.");
                return false;
            }
            return true;
        }
        
        void CargarCombos()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacion, MedioVerificacionService.Current.GetList(), "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Seleccione Medio" });

            nc.IndicadorEvolucionInstanciaFilter indicadorEvolucionInstanciaFilter = new nc.IndicadorEvolucionInstanciaFilter();
            indicadorEvolucionInstanciaFilter.OrderBys.Add(new FilterOrderBy("IdIndicadorEvolucionInstancia"));
            UIHelper.Load<IndicadorEvolucionInstancia>(ddlTipoEvolucion, IndicadorEvolucionInstanciaService.Current.GetList(indicadorEvolucionInstanciaFilter),
                "Nombre", "IdIndicadorEvolucionInstancia", new IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = 0, Nombre = "Selecione Tipo" }, false);          
            
        }

        #endregion Methods

        #region Commands
        void CommandIndicadoresEdit()
        {
            IndicadoresSetValue();
            ModalPopupExtenderIndicadores.Show();
            upIndicadoresPopUp.Update();
        }
        void CommandIndicadoresSave()
        {
            IndicadoresGetValue();

            PrestamoObjetivoComponenteCompose refCompActual = (from c in Entity.Componentes
                                                               where c.ID == ActualPrestamoComponente.ID
                                                               select c).FirstOrDefault();

            ObjetivoIndicadorCompose refIndActual = (from i in refCompActual.Indicadores
                                                     where i.ID == ActualIndicadorComponente.ID
                                                     select i).FirstOrDefault();


            if (refIndActual != null)
            {
                refIndActual.Indicador.Indicador_Observacion = ActualIndicadorComponente.Indicador.Indicador_Observacion;
                refIndActual.Indicador.IdIndicadorClase = ActualIndicadorComponente.Indicador.IdIndicadorClase;
                refIndActual.Indicador.Indicador_IdMedioVerificacion = ActualIndicadorComponente.Indicador.Indicador_IdMedioVerificacion;
                refIndActual.Indicador.IndicadorClase_Nombre = ActualIndicadorComponente.Indicador.IndicadorClase_Nombre;
                refIndActual.Indicador.IndicadorClase_Sigla = ActualIndicadorComponente.Indicador.IndicadorClase_Sigla;
                refIndActual.Indicador.IndicadorClase_Unidad = ActualIndicadorComponente.Indicador.IndicadorClase_Unidad;
                refIndActual.Indicador.Indicador_MedioVerificacion = ActualIndicadorComponente.Indicador.Indicador_MedioVerificacion;
                refIndActual.Indicador.IdIndicadorRubro = ActualIndicadorComponente.Indicador.IdIndicadorRubro;                
            }
            else
            {
                refCompActual.Indicadores.Add(ActualIndicadorComponente);
            }

            ActualPrestamoComponente = refCompActual;
            
            IndicadoresClear();
            IndicadoresRefresh();

        }
        void CommandIndicadoresDelete()
        {
            PrestamoDesembolsoResult result = (from l in Entity.Desembolsos where l.IdPrestamoDesembolso == ActualPrestamoDesembolso.ID select l).FirstOrDefault();
            Entity.Desembolsos.Remove(result);
            PrestamoDesembolsoClear();
            PrestamoDesembolsoRefresh();

            PrestamoObjetivoComponenteCompose refCompActual = (from c in Entity.Componentes
                                                               where c.ID == ActualPrestamoComponente.ID
                                                               select c).FirstOrDefault();

            ObjetivoIndicadorCompose refIndActual = (from i in refCompActual.Indicadores
                                                     where i.ID == ActualIndicadorComponente.ID
                                                     select i).FirstOrDefault();


            ActualPrestamoComponente = refCompActual;
            refCompActual.Indicadores.Remove(refIndActual);
            IndicadoresClear();
            IndicadoresRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveIndicador_Click(object sender, EventArgs e)
        {
            // Validate
            string msgError;
            if (ValidateIndicadores(ActualPrestamoComponente, out msgError))
            {
                CallTryMethod(CommandIndicadoresSave);
                HidePopUpIndicadores();
            }
            else
            {
                lblErrorIndicadores.Text = msgError;
                UIHelper.ShowAlert(lblErrorIndicadores.Text, upIndicadoresPopUp);
            }

        }
        protected void btNewIndicador_Click(object sender, EventArgs e)
        {
            // Validate
            string msgError;
            if (ValidateIndicadores(ActualPrestamoComponente, out msgError))
            {

                CallTryMethod(CommandIndicadoresSave);
            }
            else
            {
                lblErrorIndicadores.Text = msgError;
                UIHelper.ShowAlert(lblErrorIndicadores.Text, upIndicadoresPopUp);
            }
        }
        protected void btCancelIndicador_Click(object sender, EventArgs e)
        {
            IndicadoresClear();
            HidePopUpIndicadores();
        }
        protected void btAgregarIndicadorComponente_Click(object sender, EventArgs e)
        {
            lblTituloIndicadores.Text = (ActualPrestamoComponente as PrestamoObjetivoComponenteCompose).Componente.Objetivo_Nombre;
            upIndicadoresPopUp.Update();
            ModalPopupExtenderIndicadores.Show();
            //focus
            //ddlSector.Focus();
        }
        protected void ddlMedioVerificacion_IndexChanged(object sender, EventArgs e) {}
        #endregion

        #region EventosGrillas
        protected void GridImageButtonIndicadores_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            for (int i = 0; i < Entity.Componentes.Count; i++)
            {
                if (Entity.Componentes[i].ID == ActualPrestamoComponente.ID)
                {
                    ActualIndicadorComponente = (from l in Entity.Componentes[i].Indicadores
                                                 where l.Indicador.ID == id
                                                 select l).FirstOrDefault();
                    break;
                }
            }

            lblTituloEvoluciones.Text = (ActualPrestamoComponente as PrestamoObjetivoComponenteCompose).Componente.Objetivo_Nombre;

            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ShowPopUpEvoluciones();
                    break;
            }
        }
        protected void GridIndicadores_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualIndicadorComponente = (from l in ActualPrestamoComponente.Indicadores
                                         where l.Indicador.ID == id
                                         select l).FirstOrDefault();
            lblTituloEvoluciones.Text = (ActualPrestamoComponente as PrestamoObjetivoComponenteCompose).Componente.Objetivo_Nombre;

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ShowPopUpEvoluciones();
                    break;
            }
        }
        protected virtual void GridIndicadores_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                ((GridView)sender).PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridIndicadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                ((GridView)sender).PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion        

        #endregion Indicadores

        #region Sobre Evoluciones

        private enum PopPupState { Adding, Modifying }
        private PopPupState EvolucionesPopPupState
        {
            get { return (PopPupState)ViewState["EvolucionesPopPupState"]; }
            set { ViewState["EvolucionesPopPupState"] = value; }

        }
        private IndicadorEvolucionResult actualIndicadorEvolucion;
        protected IndicadorEvolucionResult ActualIndicadorEvolucion
        {
            get
            {
                if (actualIndicadorEvolucion == null)
                {
                    if (ExistsPersist("actualIndicadorEvolucionComp"))
                        actualIndicadorEvolucion = ((IndicadorEvolucionResult)GetPersist("actualIndicadorEvolucionComp"));
                    else
                    {
                        actualIndicadorEvolucion = GetNewEvolucion();
                        SetPersist("actualIndicadorEvolucionComp", actualIndicadorEvolucion);
                    }
                }
                return actualIndicadorEvolucion;
            }
            set
            {
                actualIndicadorEvolucion = value;
                SetPersist("actualIndicadorEvolucionComp", value);
            }
        }
        IndicadorEvolucionResult GetNewEvolucion()
        {
            int id = 0;
            if (ActualIndicadorComponente.Evoluciones.Count > 0) id = ActualIndicadorComponente.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            indicadorEvolucionResult.IdIndicador = ActualIndicadorComponente.Indicador.IdObjetivoIndicador;
            return indicadorEvolucionResult;
        }

        #region Methods
        void HidePopUpEvoluciones()
        {
            ModalPopupExtenderEvoluciones.Hide();
        }
        void ShowPopUpEvoluciones()
        {

            tsEvolucion.Focus();
            EvolucionesRefresh();
            btNewEvolucion.Enabled = true;
            btSaveEvolucion.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            //lblTituloEvoluciones.Text = objetivoIndicadorCompose.Indicador.IndicadorClase_Nombre;
            upEvolucionesPopUp.Update();
            ModalPopupExtenderEvoluciones.Show();
        }
        void EvolucionesClear(bool entradaContinua)
        {
            if (!entradaContinua)
            UIHelper.Clear(tsEvolucion as IWebControlTreeSelect);
            UIHelper.Clear(diFechaEstimadaEvolucion);
            UIHelper.Clear(diFechaRealizadaEvolucion);
            UIHelper.Clear(txtCantidadRealizadaEvolucion);
            UIHelper.Clear(txtCantidadEstimadaEvolucion);
            UIHelper.Clear(ddlTipoEvolucion);

            ActualIndicadorEvolucion = GetNewEvolucion();
        }
        void EvolucionesSetValue()
        {
            lblErrorEvoluciones.Text = "";
            UIHelper.SetValue(tsEvolucion as IWebControlTreeSelect, ActualIndicadorEvolucion.IdClasificacionGeografica);
            UIHelper.SetValue(diFechaEstimadaEvolucion, ActualIndicadorEvolucion.FechaEstimada);
            UIHelper.SetValue(diFechaRealizadaEvolucion, ActualIndicadorEvolucion.FechaReal);
            UIHelper.SetValue(txtCantidadRealizadaEvolucion, ActualIndicadorEvolucion.CantidadReal);
            UIHelper.SetValue(txtCantidadEstimadaEvolucion, ActualIndicadorEvolucion.CantidadEstimada);
            UIHelper.SetValue(ddlTipoEvolucion, ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia);
        }
        void EvolucionesGetValue()
        {
            ActualIndicadorEvolucion.IdClasificacionGeografica = UIHelper.GetInt(tsEvolucion as IWebControlTreeSelect);
            ActualIndicadorEvolucion.FechaEstimada = UIHelper.GetDateTimeNullable(diFechaEstimadaEvolucion);
            ActualIndicadorEvolucion.FechaReal = UIHelper.GetDateTimeNullable(diFechaRealizadaEvolucion);
            ActualIndicadorEvolucion.CantidadEstimada = UIHelper.GetDecimal(txtCantidadEstimadaEvolucion);
            ActualIndicadorEvolucion.CantidadReal = UIHelper.GetDecimal(txtCantidadRealizadaEvolucion);
            ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia = UIHelper.GetInt(ddlTipoEvolucion);

            if (ActualIndicadorEvolucion.IdClasificacionGeografica > 0)
                ActualIndicadorEvolucion.ClasificacionGeografica_Descripcion = UIHelper.GetNodeResult(tsEvolucion as IWebControlTreeSelect).Descripcion;
            ActualIndicadorEvolucion.IndicadorEvolucionInstancia_Nombre = ddlTipoEvolucion.SelectedItem.Text;
        }
        void EvolucionesRefresh()
        {
            UIHelper.Load(gridEvoluciones, ActualIndicadorComponente.Evoluciones, "Orden");
            upGridEvoluciones.Update();
        }
        bool ValidaEvolucionActual()
        {   // Controla Obligatorios
            return ActualIndicadorEvolucion.IdClasificacionGeografica != 0 &&
                   ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia != 0 &&
                   ActualIndicadorEvolucion.FechaEstimada != null &&
                   ActualIndicadorEvolucion.CantidadEstimada != null &&
                   ActualIndicadorEvolucion.CantidadEstimada > 0;
        }

        void AdministrarEvolucionesEvoluciones()
        {
            PrestamoObjetivoComponenteCompose refCompActual = (from c in Entity.Componentes
                                                               where c.ID == ActualPrestamoComponente.ID
                                                               select c).FirstOrDefault();

            ObjetivoIndicadorCompose refIndActual = (from i in refCompActual.Indicadores
                                                     where i.ID == ActualIndicadorComponente.ID
                                                     select i).FirstOrDefault();

            refIndActual.Evoluciones = ActualIndicadorComponente.Evoluciones;
        }
        #endregion

        #region Eventos
        protected void btSaveEvolucion_Click(object sender, EventArgs e)
        {

            CallTryMethod(CommandEvolucionSave);
            upGridEvoluciones.Update();
    

            /*
            // Guarda la Calificacion Anteriror seleccionada
            Int32 CGAnterior = UIHelper.GetInt(tsEvolucion as IWebControlTreeSelect);

            lblErrorEvoluciones.Text = "";
            CallTryMethod(CommandEvolucionSave);

            // Setea la calificacion anterior
            UIHelper.SetValue(tsEvolucion as IWebControlTreeSelect, CGAnterior);
             */
        }
        protected void btNewEvolucion_Click(object sender, EventArgs e)
        {
            if (EvolucionesPopPupState == PopPupState.Adding)
            {
                CallTryMethod(CommandEvolucionSave);
                upGridEvoluciones.Update();
            }
            else
            {
                EvolucionesClear(false);
                EvolucionesRefresh();
                btNewEvolucion.Text = Translate("Agregar");
                btCancelEvolucion.Enabled = true;
                btSaveEvolucion.Enabled = false;
                EvolucionesPopPupState = PopPupState.Adding;
                upEvolucionesPopUp.Update();

            }
        }
        protected void btCancelEvolucion_Click(object sender, EventArgs e)
        {

            string msgError = string.Empty;
            if (ValidatorEvolucion.ValidateEvoluciones(ActualIndicadorComponente.Evoluciones, out msgError))
            {

                EvolucionesClear(false);
                HidePopUpEvoluciones();


                /*
                EvolucionesClear(false);

                ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
                ObjetivoCompose entityObjetivoCompose;

                GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);
                entityObjetivoIndicadorCompose.Evoluciones = ActualIndicadorCompose.Evoluciones;
                HidePopUpEvoluciones();
                 */
            }
            else
            {
                UIHelper.ShowAlert(msgError, upEvolucionesPopUp);
            }

        }
        protected void btAgregarEvolucion_Click(object sender, EventArgs e)
        {
            lblErrorEvoluciones.Text = "";
            tsEvolucion.Focus();
            ModalPopupExtenderEvoluciones.Show();
        }
        #endregion

        #region Commands
        void CommandEvolucionEdit()
        {
            EvolucionesSetValue();
            btNewEvolucion.Text = Translate("Cancelar");
            btSaveEvolucion.Enabled = true;
            btCancelEvolucion.Enabled = false;
            EvolucionesPopPupState = PopPupState.Modifying;
            upEvolucionesPopUp.Update();

        }
        void CommandEvolucionSave()
        {
            EvolucionesGetValue();

            if (ValidaEvolucionActual())
            {
                IndicadorEvolucionResult ier = (from l in ActualIndicadorComponente.Evoluciones
                                                where l.IdIndicadorEvolucion == ActualIndicadorEvolucion.ID
                                                select l).FirstOrDefault();
                if (ier != null)
                {
                    ier.IdClasificacionGeografica = ActualIndicadorEvolucion.IdClasificacionGeografica;
                    ier.ClasificacionGeografica_Descripcion = ActualIndicadorEvolucion.ClasificacionGeografica_Descripcion;
                    ier.IdIndicadorEvolucionInstancia = ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia;
                    ier.IndicadorEvolucionInstancia_Nombre = ActualIndicadorEvolucion.IndicadorEvolucionInstancia_Nombre;
                    ier.FechaEstimada = ActualIndicadorEvolucion.FechaEstimada;
                    ier.CantidadEstimada = ActualIndicadorEvolucion.CantidadEstimada;
                    ier.FechaReal = ActualIndicadorEvolucion.FechaReal;
                    ier.CantidadReal = ActualIndicadorEvolucion.CantidadReal;
                    AdministrarEvolucionesEvoluciones();
                    EvolucionesClear(false);
                }
                else
                {
                    ActualIndicadorComponente.Evoluciones.Add(ActualIndicadorEvolucion);
                    AdministrarEvolucionesEvoluciones();
                    EvolucionesClear(true);
                }

                EvolucionesRefresh();
                btNewEvolucion.Text = Translate("Agregar");
                btCancelEvolucion.Enabled = true;
                btSaveEvolucion.Enabled = false;
                EvolucionesPopPupState = PopPupState.Adding;
                upEvolucionesPopUp.Update();

            }
            else
            {
                lblErrorEvoluciones.Text = SolutionContext.Current.TextManager.Translate("- Lo datos no son válidos");
                UIHelper.ShowAlert(lblErrorEvoluciones.Text, upEvolucionesPopUp);
                upEvolucionesPopUp.Update();
            }
        }
        void CommandEvolucionDelete()
        {
            IndicadorEvolucionResult result = (from l in ActualIndicadorComponente.Evoluciones
                                               where l.IdIndicadorEvolucion == ActualIndicadorEvolucion.ID
                                               select l).FirstOrDefault();
            ActualIndicadorComponente.Evoluciones.Remove(result);
            AdministrarEvolucionesEvoluciones();
            EvolucionesClear(false);
            EvolucionesRefresh();
        }
        #endregion

        #region EventosGrillas 
        protected void GridImageButtonEvolucion_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualIndicadorEvolucion = (from l in ActualIndicadorComponente.Evoluciones
                                        where l.IdIndicadorEvolucion == id
                                        select l).FirstOrDefault();
            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandEvolucionEdit();
                    break;
                case Command.DELETE:
                    CommandEvolucionDelete();
                    break;
            }
        }
        protected void GridEvoluciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualIndicadorEvolucion = (from l in ActualIndicadorComponente.Evoluciones
                                        where l.IdIndicadorEvolucion == id
                                        select l).FirstOrDefault();
            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandEvolucionEdit();
                    break;
                case Command.DELETE:
                    CommandEvolucionDelete();
                    break;
            }

        }
        protected virtual void GridEvoluciones_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridEvoluciones.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridEvoluciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridEvoluciones.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Sobre Evoluciones

        #region Sobre Financiamientos

        private PrestamoFinanciamientoResult actualPrestamoFinanciamiento;
        protected PrestamoFinanciamientoResult ActualPrestamoFinanciamiento
        {
            get
            {
                if (actualPrestamoFinanciamiento == null)
                {
                    if (ExistsPersist("actualPrestamoFinanciamiento"))
                        actualPrestamoFinanciamiento = ((PrestamoFinanciamientoResult)GetPersist("actualPrestamoFinanciamiento"));
                    else
                    {
                        actualPrestamoFinanciamiento = GetNewFinanciamiento();
                        SetPersist("actualPrestamoFinanciamiento", actualPrestamoFinanciamiento);
                    }
                }
                return actualPrestamoFinanciamiento;
            }
            set
            {
                actualPrestamoFinanciamiento = value;
                SetPersist("actualPrestamoFinanciamiento", value);
            }
        }
        PrestamoFinanciamientoResult GetNewFinanciamiento()
        {
            int id = 0;
            if (Entity.Financiamientos.Count > 0) id = Entity.Financiamientos.Min(l => l.IdPrestamoFinanciamiento);
            if (id > 0) id = 0;
            id--;
            PrestamoFinanciamientoResult plResult = new PrestamoFinanciamientoResult();
            plResult.IdPrestamoFinanciamiento = id;
            return plResult;
        }

        #region Methods
        void HidePopUpFinanciamientos()
        {
            ModalPopupExtenderFinanciamientos.Hide();
        }
        void PrestamoFinanciamientoClear()
        {
            lblErrorFinanciamiento.Text = "";
            UIHelper.Clear(ddlF_Componente);
            UIHelper.Clear(ddlF_SubComponente);
            UIHelper.Clear(tsFuenteFinanciamiento);
            UIHelper.Clear(txtF_Monto);
            ActualPrestamoFinanciamiento = GetNewFinanciamiento();

        }
        void PrestamoFinanciamientoSetValue()
        {
            UIHelper.SetValue(tsFuenteFinanciamiento, ActualPrestamoFinanciamiento.IdFuenteFinanciamiento);
            UIHelper.SetValue(txtF_Monto, ActualPrestamoFinanciamiento.Monto);
            UIHelper.SetValue(ddlF_Componente, ActualPrestamoFinanciamiento.IdPrestamoComponente);
            if (ActualPrestamoFinanciamiento.IdPrestamoSubComponente != null && ActualPrestamoFinanciamiento.IdPrestamoComponente != 0)
                UIHelper.SetValue(ddlF_SubComponente, ActualPrestamoFinanciamiento.IdPrestamoSubComponente);
        }
        void PrestamoFinanciamientoGetValue()
        {
            if (ddlF_Componente.SelectedValue != "")
            {
                ActualPrestamoFinanciamiento.IdPrestamoComponente = UIHelper.GetInt(ddlF_Componente);
                ActualPrestamoFinanciamiento.PrestamoComponente_Nombre = ddlF_Componente.SelectedItem.Text;

                ActualPrestamoFinanciamiento.IdPrestamoSubComponente = ddlF_SubComponente.SelectedValue != "" ? ((Int32?)Int32.Parse(ddlF_SubComponente.SelectedValue)) : null;
                if (ActualPrestamoFinanciamiento.IdPrestamoSubComponente != null)
                    ActualPrestamoFinanciamiento.PrestamoSubComponente_Descripcion = ddlF_SubComponente.SelectedItem.Text;
                else
                {
                    ActualPrestamoFinanciamiento.IdPrestamoSubComponente = 0;
                    ActualPrestamoFinanciamiento.PrestamoSubComponente_Descripcion = "";
                }

                ActualPrestamoFinanciamiento.IdFuenteFinanciamiento = UIHelper.GetInt(tsFuenteFinanciamiento);
                if (ActualPrestamoFinanciamiento.IdFuenteFinanciamiento > 0)
                {
                    FuenteFinanciamiento ff = FuenteFinanciamientoService.Current.GetById(ActualPrestamoFinanciamiento.IdFuenteFinanciamiento);
                    ActualPrestamoFinanciamiento.FuenteFinanciamiento_Descripcion = ff.Descripcion;
                }
                else
                {
                    ActualPrestamoFinanciamiento.FuenteFinanciamiento_Descripcion = "";
                }

                ActualPrestamoFinanciamiento.Monto = UIHelper.GetDecimal(txtF_Monto);
            }
        }
        void PrestamoFinanciamientoRefresh()
        {

            List<PrestamoFinanciamientoResult> result = (from l in Entity.Financiamientos 
                                                         orderby l.IdPrestamoComponente, l.IdPrestamoSubComponente, l.IdFuenteFinanciamiento
                                                         select l).ToList();

            UIHelper.Load(gridFinanciamientos, result);
            upGridFinanciamientos.Update();
        }
        void ManejarCombos()
        {
            if (Entity.Componentes.Count > 0)
            {
                List<PrestamoComponenteResult> aux = (from c in Entity.Componentes select c.Componente).ToList();
                UIHelper.Load<nc.PrestamoComponenteResult>(ddlF_Componente, aux, "Objetivo_Nombre", "IdPrestamoComponente");
                //Matias 20140429 - Tarea 143
                //UIHelper.SetValue(ddlF_Componente, aux[0].ID);
                if ((ActualPrestamoComponente != null) && (ActualPrestamoComponente.ID > 0))
                    UIHelper.SetValue(ddlF_Componente, ActualPrestamoComponente.ID);
                else
                    UIHelper.SetValue(ddlF_Componente, aux[0].ID);
                //FinMatias 20140429 - Tarea 143

                ddlF_SubComponente.SelectedValue = null;
                Int32 idSelected = Int32.Parse(ddlF_Componente.SelectedValue);                                                         
                UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlF_SubComponente, Entity.Subcomponentes.Where(s => s.IdPrestamoComponente == idSelected).ToList(), "Descripcion", "IdPrestamoSubComponente");

                if (ddlF_SubComponente.Enabled)
                    UIHelper.SetValue(ddlF_SubComponente, 0);

                ddlF_Componente.Enabled = ddlF_Componente.Items.Count > 0;
                ddlF_SubComponente.Enabled = ddlF_SubComponente.Items.Count > 0;
                btAgregarSubComponente.Enabled = true;
                btAgregarIndicadorComponente.Enabled = true;
            }
            else
            {
                ddlF_Componente.Enabled = false;
                btAgregarSubComponente.Enabled = false;
                btAgregarIndicadorComponente.Enabled = false;
            }
            upFinanciamientosPopUp.Update();
        }
        void RecalcularMontosComponentes()
        {
            foreach (PrestamoObjetivoComponenteCompose c in Entity.Componentes)
                c.Monto = 0;
            foreach (PrestamoSubComponenteResult sc in Entity.Subcomponentes)
                sc.Monto = 0;
            foreach (PrestamoFinanciamientoResult pfr in Entity.Financiamientos)
            {
                foreach (PrestamoObjetivoComponenteCompose c in Entity.Componentes)
                {
                    if (c.Componente.IdPrestamoComponente == pfr.IdPrestamoComponente)
                        c.Monto += pfr.Monto;
                }
                foreach (PrestamoSubComponenteResult sc in Entity.Subcomponentes)
                {
                    if (pfr.IdPrestamoSubComponente != null && sc.IdPrestamoSubComponente == pfr.IdPrestamoSubComponente)
                        sc.Monto += pfr.Monto;
                }
            }            
            upGridComponentes.Update();
            PrestamoSubComponenteRefresh();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoFinanciamientoEdit()
        {
            PrestamoFinanciamientoSetValue();
            ddlF_Componente.Focus();
            ModalPopupExtenderFinanciamientos.Show();
            upFinanciamientosPopUp.Update();
        }
        void CommandPrestamoFinanciamientoSave()
        {
            lblErrorFinanciamiento.Text = "";
            PrestamoFinanciamientoGetValue();
            PrestamoFinanciamientoResult result = (from l in Entity.Financiamientos
                                                   where l.IdPrestamoFinanciamiento == ActualPrestamoFinanciamiento.ID
                                                   select l).FirstOrDefault();

            PrestamoFinanciamientoResult resultRepetido = (from l in Entity.Financiamientos
                                                           where l.IdPrestamoFinanciamiento != ActualPrestamoFinanciamiento.ID
                                                           && l.IdPrestamoComponente == ActualPrestamoFinanciamiento.IdPrestamoComponente
                                                           && l.IdPrestamoSubComponente == ActualPrestamoFinanciamiento.IdPrestamoSubComponente
                                                           && l.IdFuenteFinanciamiento == ActualPrestamoFinanciamiento.IdFuenteFinanciamiento
                                                           select l).FirstOrDefault();

            if (ActualPrestamoFinanciamiento.IdPrestamoComponente == 0)
            {
                lblErrorFinanciamiento.Text = TranslateFormat("InvalidFiled", "Componente");
                UIHelper.ShowAlert(lblErrorFinanciamiento.Text, upFinanciamientosPopUp);
            }
            else if (ActualPrestamoFinanciamiento.IdFuenteFinanciamiento == 0)
            {
                lblErrorFinanciamiento.Text = TranslateFormat("InvalidFiled", "FuenteFinanciamiento");
                UIHelper.ShowAlert(lblErrorFinanciamiento.Text, upFinanciamientosPopUp);
            }
            else if (resultRepetido != null)
            {
                lblErrorFinanciamiento.Text = Translate("Registro ya ingresado");
                UIHelper.ShowAlert(lblErrorFinanciamiento.Text, upFinanciamientosPopUp);
            }
            else
            {
                if (result != null)
                {
                    result.IdFuenteFinanciamiento = ActualPrestamoFinanciamiento.IdFuenteFinanciamiento;
                    result.IdPrestamoComponente = ActualPrestamoFinanciamiento.IdPrestamoComponente;
                    result.IdPrestamoSubComponente = ActualPrestamoFinanciamiento.IdPrestamoSubComponente;
                    result.Monto = ActualPrestamoFinanciamiento.Monto;
                    result.PrestamoComponente_Nombre = ActualPrestamoFinanciamiento.PrestamoComponente_Nombre;
                    result.FuenteFinanciamiento_Descripcion = ActualPrestamoFinanciamiento.FuenteFinanciamiento_Descripcion;
                    result.PrestamoSubComponente_Descripcion = ActualPrestamoFinanciamiento.PrestamoSubComponente_Descripcion;
                }
                else
                {
                    Entity.Financiamientos.Add(ActualPrestamoFinanciamiento);
                }
                PrestamoFinanciamientoClear();
                PrestamoFinanciamientoRefresh();
                PrestamoComponenteRefresh();
                ManejarCombos();
            }

        }
        void CommandPrestamoFinanciamientoDelete()
        {
            PrestamoFinanciamientoResult result = (from l in Entity.Financiamientos where l.IdPrestamoFinanciamiento == ActualPrestamoFinanciamiento.ID select l).FirstOrDefault();
            Entity.Financiamientos.Remove(result);
            PrestamoFinanciamientoClear();
            PrestamoFinanciamientoRefresh();
            RecalcularMontosComponentes();
            UIHelper.Load(gridComponentes, Entity.Componentes, "Orden");
            upGridComponentes.Update();
        }
        #endregion

        #region Eventos
        protected void btSaveFinanciamiento_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoFinanciamientoSave);
            if(lblErrorFinanciamiento.Text == "")
                HidePopUpFinanciamientos();
        }
        protected void btNewFinanciamiento_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoFinanciamientoSave);
        }
        protected void btCancelFinanciamiento_Click(object sender, EventArgs e)
        {
            PrestamoFinanciamientoClear();
            HidePopUpFinanciamientos();
        }
        protected void btAgregarFinanciamiento_Click(object sender, EventArgs e)
        {
            PrestamoFinanciamientoClear();
            ManejarCombos();
            ModalPopupExtenderFinanciamientos.Show();
            ddlF_Componente.Focus();
        }
        protected void ddlComponenetes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Recargar combo de Subcomponentes
            ddlF_SubComponente.Items.Clear();
            ActualPrestamoFinanciamiento.IdPrestamoComponente = UIHelper.GetInt(ddlF_Componente);
            Int32 idSelected = Int32.Parse(ddlF_Componente.SelectedValue);
            UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlF_SubComponente, Entity.Subcomponentes.Where(s => s.IdPrestamoComponente == idSelected).ToList(), "Descripcion", "IdPrestamoSubComponente");

            ddlF_SubComponente.Enabled = ddlF_SubComponente.Items.Count > 0;
            upFinanciamientosPopUp.Update();            
        }
        #endregion

        #region EventosGrillas

        protected void GridFinanciamientos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoFinanciamiento = (from l in Entity.Financiamientos where l.IdPrestamoFinanciamiento == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoFinanciamientoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoFinanciamientoDelete();
                    break;
            }
        }
        protected virtual void GridFinanciamientos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridFinanciamientos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridFinanciamientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridFinanciamientos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected void GridImageButtonFinancia_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoFinanciamiento = (from l in Entity.Financiamientos where l.IdPrestamoFinanciamiento == id select l).FirstOrDefault();
            UIHelper.Load<nc.PrestamoSubComponenteResult>(ddlF_SubComponente, Entity.Subcomponentes.Where(s => s.IdPrestamoComponente == ActualPrestamoFinanciamiento.IdPrestamoComponente).ToList(), "Descripcion", "IdPrestamoSubComponente");
            ddlF_SubComponente.Enabled = ddlF_SubComponente.Items.Count > 0;
            if (ActualPrestamoFinanciamiento.IdPrestamoSubComponente != null)
                UIHelper.SetValue(ddlF_SubComponente, ActualPrestamoFinanciamiento.IdPrestamoSubComponente);

            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoFinanciamientoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoFinanciamientoDelete();
                    break;
            }
        }
        #endregion

        #endregion Financiamiento

        #region Sobre Desembolsos

        private PrestamoDesembolsoResult actualPrestamoDesembolso;
        protected PrestamoDesembolsoResult ActualPrestamoDesembolso
        {
            get
            {
                if (actualPrestamoDesembolso == null)
                {
                    if (ExistsPersist("actualPrestamoDesembolso"))
                        actualPrestamoDesembolso = ((PrestamoDesembolsoResult)GetPersist("actualPrestamoDesembolso"));
                    else
                    {
                        actualPrestamoDesembolso = GetNewDesembolso();
                        SetPersist("actualPrestamoDesembolso", actualPrestamoDesembolso);
                    }
                }
                return actualPrestamoDesembolso;
            }
            set
            {
                actualPrestamoDesembolso = value;
                SetPersist("actualPrestamoDesembolso", value);
            }
        }
        PrestamoDesembolsoResult GetNewDesembolso()
        {
            int id = 0;
            if (Entity.Desembolsos.Count > 0) id = Entity.Desembolsos.Min(l => l.IdPrestamoDesembolso);
            if (id > 0) id = 0;
            id--;
            PrestamoDesembolsoResult plResult = new PrestamoDesembolsoResult();
            plResult.IdPrestamoDesembolso = id;
            plResult.IdPrestamo = Entity.IdPrestamo;
            return plResult;
        }

        #region Methods
        void HidePopUpDesembolsos()
        {
            ModalPopupExtenderDesembolsos.Hide();
        }
        void PrestamoDesembolsoClear()
        {
            UIHelper.Clear(diD_Fecha);
            UIHelper.Clear(txtD_Monto);
            UIHelper.Clear(txtD_Observaciones);
            UIHelper.Clear(txtD_Total);
            lblErrorDesembolso.Text = "";

            ActualPrestamoDesembolso = GetNewDesembolso();
        }
        void PrestamoDesembolsoSetValue()
        {
            UIHelper.SetValue(diD_Fecha, ActualPrestamoDesembolso.Fecha);
            UIHelper.SetValue(txtD_Observaciones, ActualPrestamoDesembolso.Observacion);            
            UIHelper.SetValue(txtD_Monto, ActualPrestamoDesembolso.MontoAcumulado);
            UIHelper.SetValue(txtD_Total, ActualPrestamoDesembolso.PTotal);
        }
        void PrestamoDesembolsoGetValue()
        {
            ActualPrestamoDesembolso.Fecha = UIHelper.GetDateTimeNullable(diD_Fecha);
            ActualPrestamoDesembolso.MontoAcumulado = UIHelper.GetDecimal(txtD_Monto);
            ActualPrestamoDesembolso.Observacion = UIHelper.GetString(txtD_Observaciones);
        }
        void PrestamoDesembolsoRefresh()
        {
            RecalcularPorcentajeConvenio();
            UIHelper.Load(gridDesembolsos, Entity.Desembolsos, "Orden", SortDirection.Ascending, Type.GetType("System.DateTime"));
            upGridDesembolsos.Update();
        }

        bool ValidosDesembolsos()
        {
            bool retval = ActualPrestamoDesembolso.Fecha <= DateTime.Now.Date;

            foreach (PrestamoDesembolsoResult d in Entity.Desembolsos)
            {
                retval = retval &&
                         d.Fecha <= DateTime.Now.Date &&
                         ((d.Fecha <= ActualPrestamoDesembolso.Fecha) &&
                         (d.MontoAcumulado <= ActualPrestamoDesembolso.MontoAcumulado))
                         ||
                         ((d.Fecha >= ActualPrestamoDesembolso.Fecha) &&
                         (d.MontoAcumulado >= ActualPrestamoDesembolso.MontoAcumulado));
                if (!retval) break;
            }

            return retval;
        }
        void RecalcularPorcentajeConvenio()
        {
            foreach (PrestamoDesembolsoResult d in Entity.Desembolsos)
                d.PTotal = string.Format("{0:F2}", Entity.GetPorcentajeConvenio(d.MontoAcumulado == null ? 0 : (decimal)d.MontoAcumulado));
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoDesembolsoEdit()
        {
            PrestamoDesembolsoSetValue();
            ModalPopupExtenderDesembolsos.Show();
            upDesembolsosPopUp.Update();
        }
        void CommandPrestamoDesembolsoSave()
        {
            PrestamoDesembolsoGetValue();
            if (ActualPrestamoDesembolso.Fecha <= DateTime.Now.Date)
            {
                if (ValidosDesembolsos())
                {

                    PrestamoDesembolsoResult result = (from l in Entity.Desembolsos
                                                       where l.IdPrestamoDesembolso == ActualPrestamoDesembolso.ID
                                                       select l).FirstOrDefault();
                    if (result != null)
                    {
                        result.MontoAcumulado = ActualPrestamoDesembolso.MontoAcumulado;
                        result.Fecha = ActualPrestamoDesembolso.Fecha;
                        result.Observacion = ActualPrestamoDesembolso.Observacion;
                    }
                    else
                    {
                        Entity.Desembolsos.Add(ActualPrestamoDesembolso);
                    }
                    PrestamoDesembolsoClear();
                    PrestamoDesembolsoRefresh();
                }
                else
                {
                    lblErrorDesembolso.Text = TranslateFormat("InvalidField", "Monto");
                    UIHelper.ShowAlert(lblErrorDesembolso.Text, upDesembolsosPopUp);
                }
            }
            else
            {
                lblErrorDesembolso.Text = TranslateFormat("La Fecha debe ser igual o inferior a la Actual");
                UIHelper.ShowAlert(lblErrorDesembolso.Text, upDesembolsosPopUp);
            }
        }
        void CommandPrestamoDesembolsoDelete()
        {
            PrestamoDesembolsoResult result = (from l in Entity.Desembolsos where l.IdPrestamoDesembolso == ActualPrestamoDesembolso.ID select l).FirstOrDefault();
            Entity.Desembolsos.Remove(result);
            PrestamoDesembolsoClear();
            PrestamoDesembolsoRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveDesembolso_Click(object sender, EventArgs e)
        {
            lblErrorDesembolso.Text = "";
            CallTryMethod(CommandPrestamoDesembolsoSave);
            if (lblErrorDesembolso.Text == "")
                HidePopUpDesembolsos();
        }
        protected void btNewDesembolso_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoDesembolsoSave);
        }
        protected void btCancelDesembolso_Click(object sender, EventArgs e)
        {
            PrestamoDesembolsoClear();
            HidePopUpDesembolsos();
        }
        protected void btAgregarDesembolso_Click(object sender, EventArgs e)
        {
            lblErrorDesembolso.Text = "";
            ModalPopupExtenderDesembolsos.Show();
        }
        #endregion

        #region EventosGrillas

        protected void GridDesembolsos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoDesembolso = (from l in Entity.Desembolsos where l.IdPrestamoDesembolso == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoDesembolsoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoDesembolsoDelete();
                    break;
            }
        }
        protected virtual void GridDesembolsos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridDesembolsos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridDesembolsos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridDesembolsos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected void GridImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            if (ib == null) return;
            int id;
            if (!int.TryParse(ib.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoDesembolso = (from l in Entity.Desembolsos where l.IdPrestamoDesembolso == id select l).FirstOrDefault();

            switch (ib.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoDesembolsoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoDesembolsoDelete();
                    break;
            }
        }
        #endregion

        #endregion Desembolso
    }
}
