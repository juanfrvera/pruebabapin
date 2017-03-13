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
    public partial class ProgramaObjetivoEdit : WebControlEdit<nc.ProgramaObjetivosCompose >
    {
        private bool? enable;
        protected bool Enable
        {
            get
            {
                if (enable == null)
                    if (ViewState["enable"] != null)
                        enable = (bool)ViewState["enable"];
                    else
                    {
                        enable = Can(ActionConfig.SAVE) && CrudAction != CrudActionEnum.Read;
                        ViewState["enable"] = enable;
                    }
                if ( enable.HasValue )
                    return enable.Value ;
                return false; 
            }
            set
            {
                enable = value;
                ViewState["enable"] = value;
            }
        }

        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            tsEvolucion.Width = 470;
            tsEvolucion.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            autoCmpIndicadorClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //German 20140302 - tarea 110
            autoCmpIndicadorClase.Visible = false;
            toIndicadoClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //Fin German 20140302 - tarea 110
            rfvObjetivo.ErrorMessage = TranslateFormat("FieldIsNull", "Propósito");
            revObjetivo.ErrorMessage = TranslateFormat("InvalidField", "Propósito");
            revObjetivo.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            revSupuestos.ErrorMessage = TranslateFormat("FieldIsNull", "Supuesto");
            revSupuestos.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            rfvSupuestos.ErrorMessage = TranslateFormat("InvalidField", "Supuesto");
            

            revObservacionesIndicadores.ErrorMessage = TranslateFormat("InvalidField", "Medio de Verifición");
            revObservacionesIndicadores.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            diFechaEstimadaEvolucion.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
            rfvTipoEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Evolución");
            rfvCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Cantidad Estimado");

            revCantidadEstimadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Estimada");

            revCantidadRealizadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadRealizadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Realizada");  

            CargarMediosVerificacion();
            CargarIndicadorEvolucionInstancia();

            
		}
		public override void Clear()
        {
            UIHelper.Clear(txtDatosGeneralesSaf);
            UIHelper.Clear(txtDatosGeneralesCodigo);
            UIHelper.Clear(txtDatosGeneralesFechaAlta);
            UIHelper.Clear(txtDatosGeneralesFechaBaja);
            UIHelper.Clear(txtDatosGeneralesDenominacion);
            UIHelper.Clear(gridSubprogramas); 
        }
		public override void SetValue()
        {
            Habilitar();
            
            txtDatosGeneralesSaf.Text = Entity.Programa.SAF_Codigo + " - " + Entity.Programa.SAF_Denominacion;
            UIHelper.SetValue(txtDatosGeneralesCodigo, Entity.Programa.Codigo);
            UIHelper.SetValue(txtDatosGeneralesFechaAlta, Entity.Programa.FechaAlta.ToString("d"));
            UIHelper.SetValue(txtDatosGeneralesFechaBaja, Entity.Programa.FechaBaja.ToString());
            UIHelper.SetValue(txtDatosGeneralesDenominacion, Entity.Programa.Nombre);
            UIHelper.SetValue(txtSectorialista, Entity.Programa.Sectorialista_Nombre);
            UIHelper.SetValue(chkActivo, Entity.Programa.Activo);
            SubprogramasRefresh();
            ProgramaObjetivosRefresh();
            IndicadoresClear();
            upIndicadoresPopUp.Update();
            // DDD IndicadoresRefresh();
            IndicadoresClear();
			//UIHelper.SetValue(ddlPrograma, Entity.IdPrograma);
			//ddlPrograma.Focus();
				//UIHelper.SetValue(ddlObjetivo, Entity.IDObjetivo);
				
        }	
        public override void GetValue()
        {
			//Entity.IdPrograma =UIHelper.GetInt(ddlPrograma);
			//Entity.IDObjetivo =UIHelper.GetInt(ddlObjetivo);

        }

        #endregion
        #region Methods
        private void Habilitar()
        {
            bool Enabled = Enable;
            btAgregarIndicadorObjetivo.Enabled = Enabled;
            btAgregarObjetivo.Enabled = Enabled;
            btAgregarIndicadorObjetivo.Enabled = Enabled;
            btSaveObjetivos.Enabled = Enabled;
            btNewObjetivos.Enabled = Enabled;
            btNewSupuesto.Enabled = Enabled;
            btSaveSupuesto.Enabled = Enabled;
            btSaveIndicadores.Enabled = Enabled;
            btNewIndicadores.Enabled = Enabled;
            btNewEvolucion.Enabled = Enabled;
            btSaveEvolucion.Enabled = Enabled;
        }
        void SubprogramasRefresh()
        {
            UIHelper.Load(gridSubprogramas, Entity.SubProgramas, "Nombre");
        }

        #endregion

        #region Events
        protected virtual void GridSubprogramas_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridSubprogramas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridSubprogramas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridSubprogramas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion
        #region Objetivos

        private ProgramaObjetivoCompose actualProgramaObjetivo;
        protected ProgramaObjetivoCompose ActualProgramaObjetivo
        {
            get
            {
                if (actualProgramaObjetivo == null)
                    if (ViewState["actualProgramaObjetivo"] != null)
                        actualProgramaObjetivo = ViewState["actualProgramaObjetivo"] as ProgramaObjetivoCompose;
                    else
                    {
                        actualProgramaObjetivo = GetNewObjetivo();
                        ViewState["actualProgramaObjetivo"] = actualProgramaObjetivo;
                    }
                return actualProgramaObjetivo;
            }
            set
            {
                actualProgramaObjetivo = value;
                ViewState["actualProgramaObjetivo"] = value;
            }
        }
        ProgramaObjetivoCompose GetNewObjetivo()
        {
            int id = 0;
            if (Entity.Objetivos.Count > 0) id = Entity.Objetivos.Min(l => l.ProgramaObjetivo.IdProgramaObjetivo);
            if (id > 0) id = 0;
            id--;
            ProgramaObjetivoCompose programaObjetivoCompose = new ProgramaObjetivoCompose();
            programaObjetivoCompose.ProgramaObjetivo = new ProgramaObjetivoResult();
            programaObjetivoCompose.ProgramaObjetivo.IdProgramaObjetivo = id;
            programaObjetivoCompose.ProgramaObjetivo.IdPrograma = Entity.IdPrograma;
            return programaObjetivoCompose;
        }
        private int IdProgramaObjetivoSeleccionado
        {

            get
            {

                if (ViewState["IdProgramaObjetivoSeleccionado"] == null)
                    return 0;
                return Convert.ToInt32(ViewState["IdProgramaObjetivoSeleccionado"]);

            }
            set
            {
                ViewState["IdProgramaObjetivoSeleccionado"] = value;
            }
        }


        #region Methods
        void HidePopUpObjetivos()
        {
            ModalPopupExtenderObjetivos.Hide();
        }
        void ProgramaObjetivosClear()
        {
            UIHelper.Clear(txtObjetivo);
            ActualProgramaObjetivo = GetNewObjetivo();
        }
        void ProgramaObjetivosSetValue()
        {
            UIHelper.SetValue(txtObjetivo, ActualProgramaObjetivo.ProgramaObjetivo.Objetivo_Nombre);
        }
        void ProgramaObjetivosGetValue()
        {
            ActualProgramaObjetivo.ProgramaObjetivo.Objetivo_Nombre = UIHelper.GetString(txtObjetivo);
        }
        void ProgramaObjetivosRefresh()
        {

            List<ProgramaObjetivoResult> objetivos = new List<ProgramaObjetivoResult>();
            Entity.Objetivos.ForEach(i => objetivos.Add(i.ProgramaObjetivo));
            UIHelper.Load(gridObjetivos, objetivos, "Objetivo_Nombre");
            upGridObjetivos.Update();

            if (Entity.Objetivos.Count > 0)
            {
                if (Entity.Objetivos.Exists(i => i.ProgramaObjetivo.IdProgramaObjetivo == IdProgramaObjetivoSeleccionado))
                {
                    SelecionarObjetivoFromId(IdProgramaObjetivoSeleccionado);
                }
                else
                {
                    SeleccionarPrimerObjetivo();
                }

                if (!btAgregarIndicadorObjetivo.Enabled)
                {
                    btAgregarIndicadorObjetivo.Enabled = true;
                    upAgregarIndicadorObjetivo.Update();
                }
            }
            else
            {
                IdProgramaObjetivoSeleccionado = 0;
                UIHelper.Clear(gridIndicadoresObjetivo);
                upGridIndicadoresObjetivo.Update();
                btAgregarIndicadorObjetivo.Enabled = false;
                upAgregarIndicadorObjetivo.Update();


            }

        }
        #endregion Methods

        #region Commands
        void CommandProgramaObjetivoEdit()
        {

            ProgramaObjetivosSetValue();
            ModalPopupExtenderObjetivos.Show();
            upObjetivosPopUp.Update();

        }
        void CommandProgramaObjetivoSave()
        {

            ProgramaObjetivosGetValue();


            ProgramaObjetivoCompose ppc = (from l in Entity.Objetivos
                                           where l.ProgramaObjetivo.IdProgramaObjetivo == ActualProgramaObjetivo.ProgramaObjetivo.ID
                                           select l).FirstOrDefault();

            if (ppc != null)
            {
                ppc.ProgramaObjetivo.Objetivo_Nombre = ActualProgramaObjetivo.ProgramaObjetivo.Objetivo_Nombre;
                ProgramaObjetivosRefresh();
            }
            else
            {

                Entity.Objetivos.Add(ActualProgramaObjetivo);
                // Si no habia objetivos seleeciono el que se agrego
                ProgramaObjetivosRefresh();
                if (Entity.Objetivos.Count == 1)
                    SeleccionarPrimerObjetivo();
            }

            ProgramaObjetivosClear();


        }
        void CommandProgramaObjetivoDelete()
        {

            ProgramaObjetivoCompose compose = (from l in Entity.Objetivos
                                               where l.ProgramaObjetivo.IdProgramaObjetivo == ActualProgramaObjetivo.ProgramaObjetivo.ID
                                               select l).FirstOrDefault();
            Entity.Objetivos.Remove(compose);
            ProgramaObjetivosClear();
            ProgramaObjetivosRefresh();

        }
        #endregion

        #region Eventos
        protected void btSaveObjetivo_Click(object sender, EventArgs e)
        {

            CallTryMethod(CommandProgramaObjetivoSave);
            HidePopUpObjetivos();

        }
        protected void btNewObjetivo_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProgramaObjetivoSave);
        }
        protected void btCancelObjetivo_Click(object sender, EventArgs e)
        {
            ProgramaObjetivosClear();
            HidePopUpObjetivos();
        }
        protected void btAgregarObjetivo_Click(object sender, EventArgs e)
        {
            ProgramaObjetivosClear();
            ModalPopupExtenderObjetivos.Show();
            txtObjetivo.Focus();
        }

        protected void rbSeleccionObjetivo_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow gvr in gridObjetivos.Rows)
            {
                ((RadioButton)gvr.FindControl("rbSeleccionObjetivo")).Checked = false;
            }

            RadioButton rb = sender as RadioButton;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("rbSeleccionObjetivo")).Checked = true;

            DataKey dk = gridObjetivos.DataKeys[row.RowIndex];
            IdProgramaObjetivoSeleccionado = Convert.ToInt32(dk.Value);

            ObjetivoCompose objetivoSeleccionado = GetObjetivoSeleccionado();

            IndicadoresRefresh(objetivoSeleccionado);

            IndicadoresClear();


        }

        #endregion

        #region EventosGrillas
        protected void GridObjetivos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProgramaObjetivo = (from l in Entity.Objetivos
                                      where l.ProgramaObjetivo.IdProgramaObjetivo == id
                                      select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProgramaObjetivoEdit();
                    break;
                case Command.DELETE:
                    CommandProgramaObjetivoDelete();
                    break;
                case Command.SHOW_DETAILS:    
                    lblTituloSupuestos.Text = ActualProgramaObjetivo.ProgramaObjetivo.Objetivo_Nombre;
                    ShowPopUpSupuestos();
                    break;
            }

        }
        protected virtual void GridObjetivos_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridObjetivos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected virtual void GridObjetivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gridObjetivos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        protected void GridObjetivos_RowDataBound(Object sender, GridViewRowEventArgs e)
        {


        }

        void SeleccionarPrimerObjetivo()
        {
            if (Entity.Objetivos.Count > 0)
            {
                GridViewRow row = gridObjetivos.Rows[0];
                ((RadioButton)row.FindControl("rbSeleccionObjetivo")).Checked = true;

                DataKey dk = gridObjetivos.DataKeys[row.RowIndex];
                IdProgramaObjetivoSeleccionado = Convert.ToInt32(dk.Value);

                ObjetivoCompose objetivoSeleccionado = GetObjetivoSeleccionado();

                IndicadoresRefresh(objetivoSeleccionado);
                
            }
        }
        void SelecionarObjetivoFromId(int id)
        {
            // se peude recorrer directamente datakey
            DataKey dk;
            foreach (GridViewRow gvr in gridObjetivos.Rows)
            {
                dk = gridObjetivos.DataKeys[gvr.RowIndex];
                if (Convert.ToInt32(dk.Value) == id)
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionObjetivo")).Checked = true;
                    //                    SelectedRowIndexGridIndicadorClase = gvr.RowIndex;
                }
                else
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionObjetivo")).Checked = false;
                }
            }
        }


        #endregion

        #endregion Objetivos

        #region Supuestos

        private enum PopPupState { Adding, Modifying }
        private PopPupState SupuestosPopPupState
        {
            get { return (PopPupState)ViewState["SupuestosPopPupState"]; }
            set { ViewState["SupuestosPopPupState"] = value; }

        }
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
            if (ActualProgramaObjetivo.Supuestos.Count > 0) id = ActualProgramaObjetivo.Supuestos.Min(l => l.IdObjetivoSupuesto);
            if (id > 0) id = 0;
            id--;
            ObjetivoSupuestoResult objetivoSupuestoResult = new ObjetivoSupuestoResult();
            objetivoSupuestoResult.IdObjetivoSupuesto = id;
            //objetivoSupuestoResult.IdObjetivo = ActualProyectoProposito.Proposito.IdObjetivo;                   
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
            bool Enabled = Enable;
            btNewSupuesto.Enabled = true && Enabled  ;
            btSaveSupuesto.Enabled = false && Enabled;
            SupuestosPopPupState = PopPupState.Adding;
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

            //List<ProyectoPropositoResult> propositos = new List<ProyectoPropositoResult>();
            //Entity.Propositos.ForEach(i => propositos.Add(i.Proposito));
            UIHelper.Load(gridSupuestos, ActualProgramaObjetivo.Supuestos, "Descripcion");
            upGridSupuestos.Update();

        }
        #endregion Methods

        #region Eventos

        protected void btSaveSupuesto_Click(object sender, EventArgs e)
        {

            if (SupuestosPopPupState == PopPupState.Adding)
            {
                CallTryMethod(CommandSupuestoSave);
            }
            else
            {
                SupuestosClear();
                SupuestosRefresh();
                btNewSupuesto.Text = Translate("Agregar");
                btCanelSupuesto.Enabled = true;
                btSaveSupuesto.Enabled = false;
                SupuestosPopPupState = PopPupState.Adding;
                upSupuestosPopUp.Update();
            }

        }
        protected void btNewSupuesto_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandSupuestoSave);
        }
        protected void btCancelSupuesto_Click(object sender, EventArgs e)
        {
            SupuestosClear();

            ProgramaObjetivoCompose programaObjetivoCompose = (from l in Entity.Objetivos
                                                               where l.ProgramaObjetivo.ID == ActualProgramaObjetivo.ProgramaObjetivo.ID
                                                               select l).FirstOrDefault();

            programaObjetivoCompose.Supuestos = ActualProgramaObjetivo.Supuestos;

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

            btNewSupuesto.Text = Translate("Cancelar");

            btSaveSupuesto.Enabled = true;
            btCanelSupuesto.Enabled = false;

            upSupuestosPopUp.Update();

            SupuestosPopPupState = PopPupState.Modifying;


        }
        void CommandSupuestoSave()
        {

            SupuestosGetValue();


            ObjetivoSupuestoResult osr = (from l in ActualProgramaObjetivo.Supuestos
                                          where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                          select l).FirstOrDefault();

            if (osr != null)
            {
                osr.Descripcion = ActualObjetivoSupuesto.Descripcion;
            }
            else
            {
                ActualProgramaObjetivo.Supuestos.Add(ActualObjetivoSupuesto);
            }

            SupuestosClear();
            SupuestosRefresh();
            btNewSupuesto.Text = Translate("Agregar");
            btCanelSupuesto.Enabled = true;
            btSaveSupuesto.Enabled = false;
            SupuestosPopPupState = PopPupState.Adding;
            upSupuestosPopUp.Update();

        }
        void CommandSupuestoDelete()
        {

            ObjetivoSupuestoResult result = (from l in ActualProgramaObjetivo.Supuestos
                                             where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                             select l).FirstOrDefault();

            ActualProgramaObjetivo.Supuestos.Remove(result);
            SupuestosClear();
            SupuestosRefresh();

        }
        #endregion

        #region EventosGrillas
        protected void GridSupuestos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualObjetivoSupuesto = (from l in ActualProgramaObjetivo.Supuestos
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

        #region Indicadores

        private ObjetivoCompose GetObjetivoSeleccionado()
        {
            ProgramaObjetivoCompose programaObjetivoCompose = (from l in Entity.Objetivos
                                                                where l.ProgramaObjetivo.IdProgramaObjetivo == IdProgramaObjetivoSeleccionado
                                                                select l).FirstOrDefault();

            return programaObjetivoCompose;
        }

        // ActualIndicadorObjetivo

        private ObjetivoIndicadorCompose actualIndicadorObjetivo;
        protected ObjetivoIndicadorCompose ActualIndicadorObjetivo
        {
            get
            {
                if (actualIndicadorObjetivo == null)
                    if (ViewState["actualIndicadorObjetivo"] != null)
                        actualIndicadorObjetivo = ViewState["actualIndicadorObjetivo"] as ObjetivoIndicadorCompose;
                    else
                    {
                        actualIndicadorObjetivo = GetNewIndicador(GetObjetivoSeleccionado());
                        ViewState["actualIndicadorObjetivo"] = actualIndicadorObjetivo;
                    }
                return actualIndicadorObjetivo;
            }
            set
            {
                actualIndicadorObjetivo = value;
                ViewState["actualIndicadorObjetivo"] = value;
            }
        }

        ObjetivoIndicadorCompose GetNewIndicador(ObjetivoCompose objetivoCompose)
        {

            int id = 0;
            if (objetivoCompose.Indicadores.Count > 0) id = objetivoCompose.Indicadores.Min(l => l.Indicador.IdObjetivoIndicador);
            if (id > 0) id = 0;
            id--;
            ObjetivoIndicadorCompose objetivoIndicadorCompose = new ObjetivoIndicadorCompose();
            objetivoIndicadorCompose.Indicador = new ObjetivoIndicadorResult();
            objetivoIndicadorCompose.Indicador.IdObjetivoIndicador = id;

            //Es necesario
            //objetivoIndicadorCompose.Indicador.IdObjetivo = ActualProyectoProposito.Proposito.IdObjetivo;

            return objetivoIndicadorCompose;
        }

        #region Methods
        void HidePopUpIndicadores()
        {
            ModalPopupExtenderIndicadores.Hide();
        }
        void IndicadoresClear()
        {

            if (GetObjetivoSeleccionado() != null)
               ActualIndicadorObjetivo = GetNewIndicador(GetObjetivoSeleccionado());
           
            UIHelper.Clear(txtObservacionesIndicadores);
            UIHelper.Clear(ddlMedioVerificacion);
            UIHelper.Clear(autoCmpIndicadorClase);
            autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //German 20140302 - tarea 110
            UIHelper.Clear(toIndicadoClase);
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //Fin German 20140302 - tarea 110
            upIndicadoresPopUp.Update();

        }
        void IndicadoresSetValue()
        {

            UIHelper.SetValue(autoCmpIndicadorClase, ActualIndicadorObjetivo.Indicador.IdIndicadorClase);
            //German 20140302 - tarea 110
            UIHelper.SetValue(toIndicadoClase, ActualIndicadorObjetivo.Indicador.IdIndicadorClase);
            //FinGerman 20140302 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadoClase.Sectores, ActualIndicadorObjetivo.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124
            UIHelper.SetValue(ddlMedioVerificacion, ActualIndicadorObjetivo.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadores, ActualIndicadorObjetivo.Indicador.Indicador_Observacion);

        }
        void IndicadoresGetValue()
        {
            ActualIndicadorObjetivo.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadores);
            ActualIndicadorObjetivo.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacion);

            ActualIndicadorObjetivo.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClase);
            //German 20140302 - tarea 110
            ActualIndicadorObjetivo.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadoClase);
            //Fin German 20140302 - tarea 110
            //German 20140511 - Tarea 124
            ActualIndicadorObjetivo.Indicador.IdIndicadorRubro = UIHelper.GetIntNullable(toIndicadoClase.Sectores);
            //FinGerman 20140511 - Tarea 124

            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = ActualIndicadorObjetivo.Indicador.IdIndicadorClase }).FirstOrDefault();


            ActualIndicadorObjetivo.Indicador.IndicadorClase_Sigla = result.Sigla;
            ActualIndicadorObjetivo.Indicador.IndicadorClase_Nombre = result.Nombre;
            ActualIndicadorObjetivo.Indicador.IndicadorClase_Unidad = result.Unidad_Nombre;

            if (ActualIndicadorObjetivo.Indicador.Indicador_IdMedioVerificacion != null)
            {
                ActualIndicadorObjetivo.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacion);
            }
            else
            {
                ActualIndicadorObjetivo.Indicador.Indicador_MedioVerificacion = string.Empty;
            }
           

        }
        void IndicadoresRefresh(ObjetivoCompose objetivoCompose)
        {
            List<ObjetivoIndicadorResult> indicadores = new List<ObjetivoIndicadorResult>();
            objetivoCompose.Indicadores.ForEach(i => indicadores.Add(i.Indicador));
            UIHelper.Load(gridIndicadoresObjetivo, indicadores, "IndicadorClase_Nombre");
            upGridIndicadoresObjetivo.Update();

        }
        #endregion Methods

        #region Commands

        void GetIndicadorSeleccionadoWithObjetivo(out ObjetivoIndicadorCompose objetivoIndicadorCompose,
                                                  out ObjetivoCompose objetivoCompose)
        {

                    objetivoCompose = GetObjetivoSeleccionado();
                    objetivoIndicadorCompose = (from l in objetivoCompose.Indicadores
                                                where l.Indicador.ID == ActualIndicadorObjetivo.Indicador.IdObjetivoIndicador
                                                select l).FirstOrDefault();

        }
        void CommandIndicadoresEdit()
        {

            IndicadoresSetValue();
            ModalPopupExtenderIndicadores.Show();
            upIndicadoresPopUp.Update();

        }
        void CommandIndicadoresSave()
        {

            IndicadoresGetValue();


            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);

            if (entityObjetivoIndicadorCompose != null)
            {
                entityObjetivoIndicadorCompose.Indicador.Indicador_Observacion = ActualIndicadorObjetivo.Indicador.Indicador_Observacion;
                entityObjetivoIndicadorCompose.Indicador.IdIndicadorClase = ActualIndicadorObjetivo.Indicador.IdIndicadorClase;
                entityObjetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = ActualIndicadorObjetivo.Indicador.Indicador_IdMedioVerificacion;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Nombre = ActualIndicadorObjetivo.Indicador.IndicadorClase_Nombre;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Sigla = ActualIndicadorObjetivo.Indicador.IndicadorClase_Sigla;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Unidad = ActualIndicadorObjetivo.Indicador.IndicadorClase_Unidad;
                entityObjetivoIndicadorCompose.Indicador.Indicador_MedioVerificacion = ActualIndicadorObjetivo.Indicador.Indicador_MedioVerificacion;
                entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro = ActualIndicadorObjetivo.Indicador.IdIndicadorRubro; 
            }
            else
            {
                entityObjetivoCompose.Indicadores.Add(ActualIndicadorObjetivo);
            }

            IndicadoresRefresh(entityObjetivoCompose);
            IndicadoresClear();

        }
        void CommandIndicadoresDelete()
        {

            ObjetivoIndicadorCompose objetivoIndicadorCompose = null;

            objetivoIndicadorCompose = ActualIndicadorObjetivo;

                    

            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);

            entityObjetivoCompose.Indicadores.Remove(entityObjetivoIndicadorCompose);
            IndicadoresClear();
            IndicadoresRefresh(entityObjetivoCompose);


        }
        #endregion

        #region Eventos
        protected void btSaveIndicador_Click(object sender, EventArgs e)
        {

            // Validate
            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);
            string msgError;
            if (ValidateIndicadores(entityObjetivoCompose, out msgError))
            {

                CallTryMethod(CommandIndicadoresSave);
                HidePopUpIndicadores();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresPopUp);
            }

        }
        protected void btNewIndicador_Click(object sender, EventArgs e)
        {

            // Validate
            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);

            string msgError;
            if (ValidateIndicadores(entityObjetivoCompose, out msgError))
            {

                CallTryMethod(CommandIndicadoresSave);
            }
            else
            {
                UIHelper.ShowAlert(msgError, upIndicadoresPopUp);
            }


        }
        protected void btCancelIndicador_Click(object sender, EventArgs e)
        {
            IndicadoresClear();
            HidePopUpIndicadores();
        }
        protected void btAgregarIndicadorObjetivo_Click(object sender, EventArgs e)
        {        
            //IndicadoresClear(ModificandoIndicadores);
            lblTituloIndicadores.Text = (GetObjetivoSeleccionado() as ProgramaObjetivoCompose).ProgramaObjetivo.Objetivo_Nombre;
            upIndicadoresPopUp.Update();
            ModalPopupExtenderIndicadores.Show();
            //ddlSector.Focus();
        }

        #endregion

        #region EventosGrillas
        protected void GridIndicadores_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

                ObjetivoCompose objetivoSeleccionado = GetObjetivoSeleccionado();
                ActualIndicadorObjetivo = (from l in objetivoSeleccionado.Indicadores
                                            where l.Indicador.ID == id
                                            select l).FirstOrDefault();

                lblTituloIndicadores.Text = (objetivoSeleccionado as ProgramaObjetivoCompose).ProgramaObjetivo.Objetivo_Nombre;


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresEdit();
                    break;
                case Command.DELETE:
                    CommandIndicadoresDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ShowPopUpEvoluciones(ActualIndicadorObjetivo);
                    break;

            }


        }
        protected virtual void GridIndicadores_Sorting(object sender, GridViewSortEventArgs e)
        {

            try
            {
                gridIndicadoresObjetivo.PageIndex = 0;
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
                gridIndicadoresObjetivo.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }

        }
        #endregion

        protected void ddlMedioVerificacion_IndexChanged(object sender, EventArgs e)
        {

        }

        void CargarMediosVerificacion()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacion, MedioVerificacionService.Current.GetList(),
              "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Selecione Medio" });
        }

        private bool ValidateIndicadores(ObjetivoCompose objetivoCompose, out string msgError)
        {
            msgError = string.Empty;
            int id = UIHelper.GetInt(autoCmpIndicadorClase);
            //German 20140302 - tarea 110
            if (autoCmpIndicadorClase.Visible == false)
                id = UIHelper.GetInt(toIndicadoClase);
            //Fin German 20140302 - tarea 110
            if (id == 0)
            {
                msgError = TranslateFormat("FieldIsNull", "Indicador");
                return false;
            }
            int idIndicador = ActualIndicadorObjetivo.Indicador.IdObjetivoIndicador;

            if (objetivoCompose.Indicadores.Where(p => (p.Indicador.IdObjetivoIndicador != idIndicador) && (p.Indicador.IdIndicadorClase == id)).Count() > 0)
            {
                msgError = Translate("- No puede haber mas de un indicador de la misma clase.");
                return false;
            }
            return true;
        }

        #endregion Indicadores

        #region Evoluciones

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
                    if (ViewState["actualIndicadorEvolucion"] != null)
                        actualIndicadorEvolucion = ViewState["actualIndicadorEvolucion"] as IndicadorEvolucionResult;
                    else
                    {
                        actualIndicadorEvolucion = GetNewEvolucion();
                        ViewState["actualIndicadorEvolucion"] = actualIndicadorEvolucion;
                    }
                return actualIndicadorEvolucion;
            }
            set
            {
                actualIndicadorEvolucion = value;
                ViewState["actualIndicadorEvolucion"] = value;
            }
        }
        IndicadorEvolucionResult GetNewEvolucion()
        {
            int id = 0;
            if (ActualIndicadorObjetivo.Evoluciones.Count > 0) id = ActualIndicadorObjetivo.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            return indicadorEvolucionResult;

        }


        #region Methods
        void HidePopUpEvoluciones()
        {
            ModalPopupExtenderEvoluciones.Hide();
        }
        void ShowPopUpEvoluciones(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {

            EvolucionesRefresh();
            bool Enabled = Can(ActionConfig.SAVE) && CrudAction != CrudActionEnum.Read;
            btNewEvolucion.Enabled = true && Enabled;
            btSaveEvolucion.Enabled = false && Enabled;
            EvolucionesPopPupState = PopPupState.Adding;
            lblTituloEvoluciones.Text = objetivoIndicadorCompose.Indicador.IndicadorClase_Nombre;
            upEvolucionesPopUp.Update();
            ModalPopupExtenderEvoluciones.Show();

        }
        void EvolucionesClear(bool entradaContinua)
        {
            if (!entradaContinua)
            UIHelper.Clear(tsEvolucion as IWebControlTreeSelect);
            UIHelper.Clear(ddlTipoEvolucion);
            UIHelper.Clear(diFechaEstimadaEvolucion);
            UIHelper.Clear(txtCantidadEstimadaEvolucion);
            UIHelper.Clear(diFechaRealizadaEvolucion);
            UIHelper.Clear(txtCantidadRealizadaEvolucion);

            ActualIndicadorEvolucion = GetNewEvolucion();
        }
        void EvolucionesSetValue()
        {

            UIHelper.SetValue(tsEvolucion as IWebControlTreeSelect, ActualIndicadorEvolucion.IdClasificacionGeografica);
            UIHelper.SetValue(ddlTipoEvolucion, ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia);
            UIHelper.SetValue(diFechaEstimadaEvolucion, ActualIndicadorEvolucion.FechaEstimada);
            UIHelper.SetValue(txtCantidadEstimadaEvolucion, ActualIndicadorEvolucion.CantidadEstimada);
            UIHelper.SetValue(diFechaRealizadaEvolucion, ActualIndicadorEvolucion.FechaReal);
            UIHelper.SetValue(txtCantidadRealizadaEvolucion, ActualIndicadorEvolucion.CantidadReal);
        }
        void EvolucionesGetValue()
        {
            ActualIndicadorEvolucion.IdClasificacionGeografica = UIHelper.GetInt(tsEvolucion as IWebControlTreeSelect);
            ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia = UIHelper.GetInt(ddlTipoEvolucion);
            ActualIndicadorEvolucion.FechaEstimada = UIHelper.GetDateTime(diFechaEstimadaEvolucion);
            ActualIndicadorEvolucion.CantidadEstimada = UIHelper.GetDecimal(txtCantidadEstimadaEvolucion);
            ActualIndicadorEvolucion.FechaReal = UIHelper.GetDateTimeNullable(diFechaRealizadaEvolucion);
            ActualIndicadorEvolucion.CantidadReal = UIHelper.GetDecimalNullable(txtCantidadRealizadaEvolucion);
            ActualIndicadorEvolucion.ClasificacionGeografica_Descripcion = UIHelper.GetNodeResult(tsEvolucion as IWebControlTreeSelect).Descripcion;
            ActualIndicadorEvolucion.IndicadorEvolucionInstancia_Nombre = UIHelper.GetString(ddlTipoEvolucion);
        }
        void EvolucionesRefresh()
        {
            var f = from d in ActualIndicadorObjetivo.Evoluciones
                    orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
                    select d;

            UIHelper.Load(gridEvoluciones, f.ToList());
            upGridEvoluciones.Update();

        }
        #endregion Methods

        #region Eventos

        protected void btSaveEvolucion_Click(object sender, EventArgs e)
        {
            if (EvolucionesPopPupState == PopPupState.Adding)
            {
                CallTryMethod(CommandEvolucionSave);
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
        protected void btNewEvolucion_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandEvolucionSave);
        }
        protected void btCancelEvolucion_Click(object sender, EventArgs e)
        {
            string msgError = string.Empty;
            if (Pages.ValidatorEvolucion.ValidateEvoluciones(ActualIndicadorObjetivo.Evoluciones, out msgError))
            {
                EvolucionesClear(false);

                ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
                ObjetivoCompose entityObjetivoCompose;

                GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);
                entityObjetivoIndicadorCompose.Evoluciones = ActualIndicadorObjetivo.Evoluciones;
                HidePopUpEvoluciones();
            }
            else
            {
                UIHelper.ShowAlert(msgError, upEvolucionesPopUp);
            }

        }
        protected void btAgregarEvolucion_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderEvoluciones.Show();
            tsEvolucion.Focus();
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

            IndicadorEvolucionResult ier = (from l in ActualIndicadorObjetivo.Evoluciones
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
                EvolucionesClear(false);
            }
            else
            {
                ActualIndicadorObjetivo.Evoluciones.Add(ActualIndicadorEvolucion);
                EvolucionesClear(true);
            }

            EvolucionesRefresh();
            btNewEvolucion.Text = Translate("Agregar");
            btCancelEvolucion.Enabled = true;
            btSaveEvolucion.Enabled = false;
            EvolucionesPopPupState = PopPupState.Adding;
            upEvolucionesPopUp.Update();

        }
        void CommandEvolucionDelete()
        {


            IndicadorEvolucionResult result = (from l in ActualIndicadorObjetivo.Evoluciones
                                               where l.IdIndicadorEvolucion == ActualIndicadorEvolucion.ID
                                               select l).FirstOrDefault();

            ActualIndicadorObjetivo.Evoluciones.Remove(result);


            EvolucionesClear(false);
            EvolucionesRefresh();

        }
        #endregion

        #region EventosGrillas
        protected void GridEvoluciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;


            ActualIndicadorEvolucion = (from l in ActualIndicadorObjetivo.Evoluciones
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

        void CargarIndicadorEvolucionInstancia()
        {

            nc.IndicadorEvolucionInstanciaFilter indicadorEvolucionInstanciaFilter = new nc.IndicadorEvolucionInstanciaFilter();
            indicadorEvolucionInstanciaFilter.OrderBys.Add(new FilterOrderBy("IdIndicadorEvolucionInstancia"));
            UIHelper.Load<IndicadorEvolucionInstancia>(ddlTipoEvolucion, IndicadorEvolucionInstanciaService.Current.GetList(indicadorEvolucionInstanciaFilter),
                "Nombre", "IdIndicadorEvolucionInstancia", new IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = 0, Nombre = "Selecione Tipo" }, false);     
        }
  

        #endregion Evoluciones



    }
}
