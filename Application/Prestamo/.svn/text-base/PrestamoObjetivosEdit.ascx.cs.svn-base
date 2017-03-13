using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web
{
    public partial class PrestamoObjetivosEdit : WebControlEdit<nc.PrestamoObjetivosCompose>
    {

        #region Override WebControlEdit

        protected override void _Load()
        {

            

        }

        protected override void _Initialize()
        {
            base._Initialize();

            tsEvolucion.Width = 470;
            rfvObjetivo.ErrorMessage = TranslateFormat("FieldIsNull", "Objetivo");
            revObjetivo.ErrorMessage = TranslateFormat("InvalidField", "Objetivo");
            revObjetivo.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            
            tsEvolucion.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            rfvObjetivoEspecifico.ErrorMessage = TranslateFormat("FieldIsNull", "Objetivo Específico");
            revObjetivoEspecifico.ErrorMessage = TranslateFormat("InvalidField", "Objetivo Específico");
            revObjetivoEspecifico.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            revSupuestos.ErrorMessage = TranslateFormat("FieldIsNull", "Supuesto");
            rfvSupuestos.ErrorMessage = TranslateFormat("InvalidField", "Supuesto");
            revSupuestos.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            autoCmpIndicadorClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //German 20140302 - tarea 110
            autoCmpIndicadorClase.Visible = false;
            toIndicadoClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //Fin German 20140302 - tarea 110
            revObservacionesIndicadores.ErrorMessage = TranslateFormat("InvalidField", "Medio de Verificación");
            revObservacionesIndicadores.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            diFechaEstimadaEvolucion.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
            rfvTipoEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Evolución");
            rfvCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Cantidad Estimada");

            revCantidadEstimadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadEstimadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Estimada");

            revCantidadRealizadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantidadRealizadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Cantidad Realizada");
                       
            CargarMediosVerificacion();
            CargarIndicadorEvolucionInstancia();

            PopUpObjetivosEspecificos.Attributes.CssStyle.Add("display", "none");
            PopUpSupuestos.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadores.Attributes.CssStyle.Add("display", "none");
            PopUpEvoluciones.Attributes.CssStyle.Add("display", "none");

        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {

            //Grabar siempre ???
            Entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre = UIHelper.GetString(txtObjetivo);
        }
        public override void SetValue()
        {
            PrestamoObjetivosEspecificosRefresh();
            IndicadoresClear(ModifyObjetivo.ObjetivoEspecifico);
            upIndicadoresPopUp.Update();
            if (Entity.Objetivo != null && Entity.Objetivo.PrestamoObjetivo!=null)
            {
                UIHelper.SetValue(txtObjetivo, Entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre);
            }
            else
            {
                Entity.Objetivo = new PrestamoObjetivoCompose();
                Entity.Objetivo.PrestamoObjetivo = new PrestamoObjetivoResult();
                Entity.Objetivo.PrestamoObjetivo.IdPrestamoObjetivo = -1;
                Entity.Objetivo.PrestamoObjetivo.IdPrestamo = Entity.IdPrestamo;
            }
            upObjetivo.Update();
            IndicadoresRefresh(Entity.Objetivo, gridIndicadoresObjetivo, upGridIndicadoresObjetivo);
            IndicadoresClear(ModifyObjetivo.Objetivo);
            //IndicadoresClear(); //Es el mejor lugar           
        }
        #endregion Override

        #region ObjetivosEspecificos

        private PrestamoObjetivoEspecificoCompose actualPrestamoObjetivoEspecifico;
        protected PrestamoObjetivoEspecificoCompose ActualPrestamoObjetivoEspecifico
        {
            get
            {
                if (actualPrestamoObjetivoEspecifico == null)
                    if (ViewState["actualPrestamoObjetivoEspecifico"] != null)
                        actualPrestamoObjetivoEspecifico = ViewState["actualPrestamoObjetivoEspecifico"] as PrestamoObjetivoEspecificoCompose;
                    else
                    {
                        actualPrestamoObjetivoEspecifico = GetNewObjetivoEspecifico();
                        ViewState["actualPrestamoObjetivoEspecifico"] = actualPrestamoObjetivoEspecifico;
                    }
                return actualPrestamoObjetivoEspecifico;
            }
            set
            {
                actualPrestamoObjetivoEspecifico = value;
                ViewState["actualPrestamoObjetivoEspecifico"] = value;
            }
        }
        PrestamoObjetivoEspecificoCompose GetNewObjetivoEspecifico()
        {            
            int id = 0;
            if (Entity.ObjetivosEspecificos.Count > 0) id = Entity.ObjetivosEspecificos.Min(l => l.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico);
            if (id > 0) id = 0;
            id--;
            PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose = new PrestamoObjetivoEspecificoCompose();
            PrestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico = new PrestamoObjetivoEspecificoResult();
            PrestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico = id;
            PrestamoObjetivoEspecificoCompose.PrestamoObjetivoEspecifico.IdPrestamo = Entity.IdPrestamo;
            return PrestamoObjetivoEspecificoCompose;
        }
        private int IdPrestamoObjetivoEspecificoSeleccionado
        {
            
            get {  
                
                if (ViewState["IdPrestamoObjetivoEspecificoSeleccionado"] == null)
                    return 0;
                return Convert.ToInt32(ViewState["IdPrestamoObjetivoEspecificoSeleccionado"]);
            
                }
            set {
                    ViewState["IdPrestamoObjetivoEspecificoSeleccionado"] = value;
                }
        }


        #region Methods
        void HidePopUpObjetivosEspecificos()
        {
            ModalPopupExtenderObjetivosEspecificos.Hide();
        }
        void PrestamoObjetivosEspecificosClear()
        {
            UIHelper.Clear(txtObjetivoEspecifico);
            ActualPrestamoObjetivoEspecifico = GetNewObjetivoEspecifico();
        }
        void PrestamoObjetivosEspecificosSetValue()
        {
            UIHelper.SetValue(txtObjetivoEspecifico, ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.Objetivo_Nombre);
        }
        void PrestamoObjetivosEspecificosGetValue()        
        {
            ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.Objetivo_Nombre = UIHelper.GetString(txtObjetivoEspecifico);
        }
        void PrestamoObjetivosEspecificosRefresh()
        {

            List<PrestamoObjetivoEspecificoResult>ObjetivosEspecificos = new List<PrestamoObjetivoEspecificoResult>();
            Entity.ObjetivosEspecificos.ForEach( i => ObjetivosEspecificos.Add(i.PrestamoObjetivoEspecifico));            
            UIHelper.Load(gridObjetivosEspecificos, ObjetivosEspecificos, "Objetivo_Nombre");
            upGridObjetivosEspecificos.Update();

            if (Entity.ObjetivosEspecificos.Count > 0)
            {
                if (Entity.ObjetivosEspecificos.Exists(i => i.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico == IdPrestamoObjetivoEspecificoSeleccionado))
                {
                    SelecionarObjetivoEspecificoFromId(IdPrestamoObjetivoEspecificoSeleccionado);
                }
                else
                {
                    SeleccionarPrimerObjetivoEspecifico();
                }

                if (!btAgregarIndicadorObjetivoEspecifico.Enabled)
                {
                    btAgregarIndicadorObjetivoEspecifico.Enabled = true;
                    upAgregarIndicadorObjetivoEspecifico.Update();                
                }
            }
            else
            {
                IdPrestamoObjetivoEspecificoSeleccionado = 0;
                UIHelper.Clear(gridIndicadoresObjetivoEspecifico);
                upGridIndicadoresObjetivoEspecifico.Update();
                btAgregarIndicadorObjetivoEspecifico.Enabled = false;
                upAgregarIndicadorObjetivoEspecifico.Update();


            }

        }
        #endregion Methods

        #region Commands
        void CommandPrestamoObjetivoEspecificoEdit()
        {
            
            PrestamoObjetivosEspecificosSetValue();
            ModalPopupExtenderObjetivosEspecificos.Show();
            upObjetivosEspecificosPopUp.Update();
            
        }
        void CommandPrestamoObjetivoEspecificoSave()
        {
            
            PrestamoObjetivosEspecificosGetValue();


            PrestamoObjetivoEspecificoCompose ppc = (from l in Entity.ObjetivosEspecificos
                                                     where l.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico == ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.ID
                                            select l).FirstOrDefault();

            if (ppc != null)
            {
                ppc.PrestamoObjetivoEspecifico.Objetivo_Nombre = ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.Objetivo_Nombre;
                PrestamoObjetivosEspecificosRefresh();
            }
            else
            {
                
                Entity.ObjetivosEspecificos.Add(ActualPrestamoObjetivoEspecifico);
                // Si no habia ObjetivosEspecificos seleeciono el que se agrego
                PrestamoObjetivosEspecificosRefresh();
                if (Entity.ObjetivosEspecificos.Count == 1)
                    SeleccionarPrimerObjetivoEspecifico();
            }
            
            PrestamoObjetivosEspecificosClear();
            

        }
        void CommandPrestamoObjetivoEspecificoDelete()
        {
            
            PrestamoObjetivoEspecificoCompose compose = (from l in Entity.ObjetivosEspecificos 
                                                where l.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico == ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.ID 
                                                select l).FirstOrDefault();
            Entity.ObjetivosEspecificos.Remove(compose);            
            PrestamoObjetivosEspecificosClear();
            PrestamoObjetivosEspecificosRefresh();
            
        }
        #endregion

        #region Eventos
        protected void btSaveObjetivoEspecifico_Click(object sender, EventArgs e)
        {
            
            CallTryMethod(CommandPrestamoObjetivoEspecificoSave);
            HidePopUpObjetivosEspecificos();
            
        }
        protected void btNewObjetivoEspecifico_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandPrestamoObjetivoEspecificoSave);
        }
        protected void btCancelObjetivoEspecifico_Click(object sender, EventArgs e)
        {
            PrestamoObjetivosEspecificosClear();
            HidePopUpObjetivosEspecificos();             
        }
        protected void btAgregarObjetivoEspecifico_Click(object sender, EventArgs e)
        {
            PrestamoObjetivosEspecificosClear();
            ModalPopupExtenderObjetivosEspecificos.Show();
            txtObjetivoEspecifico.Focus();
        }

        protected void rbSeleccionObjetivoEspecifico_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow gvr in gridObjetivosEspecificos.Rows)
            {
                ((RadioButton)gvr.FindControl("rbSeleccionObjetivoEspecifico")).Checked = false;
            }

            RadioButton rb = sender as RadioButton;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("rbSeleccionObjetivoEspecifico")).Checked = true;

            DataKey dk = gridObjetivosEspecificos.DataKeys[row.RowIndex];
            IdPrestamoObjetivoEspecificoSeleccionado = Convert.ToInt32(dk.Value);

            ObjetivoCompose ObjetivoEspecificoSeleccionado = GetObjetivoEspecificoSeleccionado();

            IndicadoresRefresh(ObjetivoEspecificoSeleccionado, gridIndicadoresObjetivoEspecifico, upGridIndicadoresObjetivoEspecifico);

            IndicadoresClear(ModifyObjetivo.ObjetivoEspecifico);

        }

        #endregion

        #region EventosGrillas
        protected void GridObjetivosEspecificos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoObjetivoEspecifico = (from l in Entity.ObjetivosEspecificos 
                                       where l.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico == id 
                                       select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoObjetivoEspecificoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoObjetivoEspecificoDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ActionSupuestos = ModifyObjetivo.ObjetivoEspecifico;
                    lblTituloSupuestos.Text = ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.Objetivo_Nombre;
                    ShowPopUpSupuestos();
                    break;
            }
             
        }
        protected virtual void GridObjetivosEspecificos_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            try
            {
                gridObjetivosEspecificos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
            
        }
        protected virtual void GridObjetivosEspecificos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            try
            {
                gridObjetivosEspecificos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
             
        }
        protected void GridObjetivosEspecificos_RowDataBound(Object sender, GridViewRowEventArgs e)
        {


        }

        void SeleccionarPrimerObjetivoEspecifico()
        {
            if (Entity.ObjetivosEspecificos.Count > 0)
            { 
                GridViewRow row = gridObjetivosEspecificos.Rows[0];
                ((RadioButton)row.FindControl("rbSeleccionObjetivoEspecifico")).Checked = true;

                DataKey dk = gridObjetivosEspecificos.DataKeys[row.RowIndex];
                IdPrestamoObjetivoEspecificoSeleccionado = Convert.ToInt32(dk.Value);

                ObjetivoCompose ObjetivoEspecificoSeleccionado = GetObjetivoEspecificoSeleccionado();

                IndicadoresRefresh(ObjetivoEspecificoSeleccionado, gridIndicadoresObjetivoEspecifico, upGridIndicadoresObjetivoEspecifico);
            
            }
        }
        void SelecionarObjetivoEspecificoFromId(int id)
        {
            //se peude recorrer directamente datakey
            DataKey dk;
            foreach (GridViewRow gvr in gridObjetivosEspecificos.Rows)
            {
                dk = gridObjetivosEspecificos.DataKeys[gvr.RowIndex];
                if (Convert.ToInt32(dk.Value) == id)
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionObjetivoEspecifico")).Checked = true;
//                    SelectedRowIndexGridIndicadorClase = gvr.RowIndex;
                }
                else
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionObjetivoEspecifico")).Checked = false;
                }
            }
        }


        #endregion

        #endregion ObjetivosEspecificos

        #region Supuestos
        private enum PopPupState { Adding, Modifying }
        private PopPupState SupuestosPopPupState
        {
            get { return (PopPupState)ViewState["SupuestosPopPupState"]; }
            set { ViewState["SupuestosPopPupState"] = value; }

        }
        private enum ModifyObjetivo { ObjetivoEspecifico, Objetivo}
        private ModifyObjetivo ActionSupuestos
        {
            get { return (ModifyObjetivo)ViewState["ActionSupuestos"]; }
            set { ViewState["ActionSupuestos"] = value; }
        
        }

        private ObjetivoCompose actualObjetivoCompose
        {
            get 
            {
                switch (ActionSupuestos)
                {
                    case ModifyObjetivo.ObjetivoEspecifico:
                        return ActualPrestamoObjetivoEspecifico;
                    case ModifyObjetivo.Objetivo:
                        return Entity.Objetivo;
                    default:
                        return null;
                }
            }
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
            if (actualObjetivoCompose.Supuestos.Count > 0) id = actualObjetivoCompose.Supuestos.Min(l => l.IdObjetivoSupuesto);
            if (id > 0) id = 0;
            id--;
            ObjetivoSupuestoResult objetivoSupuestoResult = new ObjetivoSupuestoResult();
            objetivoSupuestoResult.IdObjetivoSupuesto = id;
            //objetivoSupuestoResult.IdObjetivo = ActualPrestamoObjetivoEspecifico.ObjetivoEspecifico.IdObjetivo;                   
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
            
            //List<PrestamoObjetivoEspecificoResult> ObjetivosEspecificos = new List<PrestamoObjetivoEspecificoResult>();
            //Entity.ObjetivosEspecificos.ForEach(i => ObjetivosEspecificos.Add(i.ObjetivoEspecifico));
            UIHelper.Load(gridSupuestos, actualObjetivoCompose.Supuestos, "Descripcion");
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

            if (actualObjetivoCompose is PrestamoObjetivoEspecificoCompose)
            {

                PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose = (from l in Entity.ObjetivosEspecificos
                                                                     where l.PrestamoObjetivoEspecifico.ID == ActualPrestamoObjetivoEspecifico.PrestamoObjetivoEspecifico.ID
                                                                     select l).FirstOrDefault();

                //PrestamoObjetivoEspecificoCompose.Supuestos = ActualPrestamoObjetivoEspecifico.Supuestos;
                PrestamoObjetivoEspecificoCompose.Supuestos = actualObjetivoCompose.Supuestos;
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

            btNewSupuesto.Text = Translate("Cancelar");

            btSaveSupuesto.Enabled = true;
            btCanelSupuesto.Enabled = false;

            upSupuestosPopUp.Update();

            SupuestosPopPupState = PopPupState.Modifying;
          

        }
        void CommandSupuestoSave()
        {
            
            SupuestosGetValue();


            ObjetivoSupuestoResult osr = (from l in actualObjetivoCompose.Supuestos
                                            where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                            select l).FirstOrDefault();

            if (osr != null)
            {
                osr.Descripcion = ActualObjetivoSupuesto.Descripcion;
            }
            else
            {
                actualObjetivoCompose.Supuestos.Add(ActualObjetivoSupuesto);
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

            ObjetivoSupuestoResult result = (from l in actualObjetivoCompose.Supuestos
                                             where l.IdObjetivoSupuesto == ActualObjetivoSupuesto.ID
                                             select l).FirstOrDefault();

            actualObjetivoCompose.Supuestos.Remove(result);
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

            ActualObjetivoSupuesto = (from l in actualObjetivoCompose.Supuestos
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

        #region Objetivo

        protected void btShowObjetivoSupuestos_Click(object sender, EventArgs e)
        {
            ActionSupuestos = ModifyObjetivo.Objetivo;
            lblTituloSupuestos.Text = txtObjetivo.Text;
            ShowPopUpSupuestos();
        }

        #endregion Objetivo

        #region Indicadores


        private ModifyObjetivo ModificandoIndicadores
        {
            get { return (ModifyObjetivo)ViewState["ModificandoIndicadores"]; }
            set { ViewState["ModificandoIndicadores"] = value; }

        }

        private ObjetivoCompose GetObjetivoEspecificoSeleccionado()
        {
            PrestamoObjetivoEspecificoCompose PrestamoObjetivoEspecificoCompose = (from l in Entity.ObjetivosEspecificos
                                                                 where l.PrestamoObjetivoEspecifico.IdPrestamoObjetivoEspecifico == IdPrestamoObjetivoEspecificoSeleccionado
                                                                 select l).FirstOrDefault();

            return PrestamoObjetivoEspecificoCompose;
        }

        // ActualIndicadorObjetivosEspecificos

        private ObjetivoIndicadorCompose actualIndicadorObjetivoEspecifico;
        protected ObjetivoIndicadorCompose ActualIndicadorObjetivoEspecifico
        {
            get
            {
                if (actualIndicadorObjetivoEspecifico == null)
                    if (ViewState["actualIndicadorObjetivoEspecifico"] != null)
                        actualIndicadorObjetivoEspecifico = ViewState["actualIndicadorObjetivoEspecifico"] as ObjetivoIndicadorCompose;
                    else
                    {
                        actualIndicadorObjetivoEspecifico = GetNewIndicador(GetObjetivoEspecificoSeleccionado());
                        ViewState["actualIndicadorObjetivoEspecifico"] = actualIndicadorObjetivoEspecifico;
                    }
                return actualIndicadorObjetivoEspecifico;
            }
            set
            {
                actualIndicadorObjetivoEspecifico = value;
                ViewState["actualIndicadorObjetivoEspecifico"] = value;
            }
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
                        actualIndicadorObjetivo = GetNewIndicador(Entity.Objetivo);
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
            //objetivoIndicadorCompose.Indicador.IdObjetivo = ActualPrestamoObjetivoEspecifico.ObjetivoEspecifico.IdObjetivo;

            return objetivoIndicadorCompose;                        
        }
       
        #region Methods
        void HidePopUpIndicadores()
        {
            ModalPopupExtenderIndicadores.Hide();
        }
        void IndicadoresClear(ModifyObjetivo entidad)
        {            
            switch (entidad)
            {
                case ModifyObjetivo.ObjetivoEspecifico:
                    if (GetObjetivoEspecificoSeleccionado() != null)
                    ActualIndicadorObjetivoEspecifico = GetNewIndicador(GetObjetivoEspecificoSeleccionado());
                    break;
                case ModifyObjetivo.Objetivo:
                    if (Entity.Objetivo != null)
                    ActualIndicadorObjetivo = GetNewIndicador(Entity.Objetivo);
                    break;
                default:
                    break;
            }
            UIHelper.Clear(txtObservacionesIndicadores);
            UIHelper.Clear(ddlMedioVerificacion);
            UIHelper.Clear(autoCmpIndicadorClase);
            //German 20140302 - tarea 110
            UIHelper.Clear(toIndicadoClase);
            //Fin German 20140302 - tarea 110

            autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };

            //German 20140302 - tarea 110
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //Fin German 20140302 - tarea 110
            
            upIndicadoresPopUp.Update();
           
        }
        void IndicadoresSetValue(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {
            
            // Cargo las clases de ese rubro
            UIHelper.SetValue(autoCmpIndicadorClase, objetivoIndicadorCompose.Indicador.IdIndicadorClase);
            
            //German 20140302 - tarea 110
            UIHelper.SetValue(toIndicadoClase, objetivoIndicadorCompose.Indicador.IdIndicadorClase);
            //FinGerman 20140302 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadoClase.Sectores, objetivoIndicadorCompose.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124
            
            UIHelper.SetValue(ddlMedioVerificacion, objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadores, objetivoIndicadorCompose.Indicador.Indicador_Observacion);            
            

        }
        void IndicadoresGetValue(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {
            objetivoIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadores);
            objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacion);

            objetivoIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClase);

            //German 20140302 - tarea 110
            objetivoIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadoClase);
            //FinGerman 20140302 - tarea 110
            //German 20140511 - Tarea 124
            objetivoIndicadorCompose.Indicador.IdIndicadorRubro = UIHelper.GetIntNullable(toIndicadoClase.Sectores);
            //FinGerman 20140511 - Tarea 124
            
            IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = objetivoIndicadorCompose.Indicador.IdIndicadorClase }).FirstOrDefault();


            objetivoIndicadorCompose.Indicador.IndicadorClase_Sigla = result.Sigla;
            objetivoIndicadorCompose.Indicador.IndicadorClase_Nombre = result.Nombre;
            objetivoIndicadorCompose.Indicador.IndicadorClase_Unidad = result.Unidad_Nombre;

            if (objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion != null)
            {
                objetivoIndicadorCompose.Indicador.Indicador_MedioVerificacion = UIHelper.GetString(ddlMedioVerificacion);
            }
            else
            {
                objetivoIndicadorCompose.Indicador.Indicador_MedioVerificacion = string.Empty;
            }

        }
        void IndicadoresRefresh(ObjetivoCompose objetivoCompose, GridView gridview, UpdatePanel updatePanel)
        {            
            List<ObjetivoIndicadorResult> indicadores = new List<ObjetivoIndicadorResult>();
            objetivoCompose.Indicadores.ForEach(i => indicadores.Add(i.Indicador));
            UIHelper.Load(gridview, indicadores, "IndicadorClase_Nombre");
            updatePanel.Update();
                                
        }
        #endregion Methods

        #region Commands

        void GetIndicadorSeleccionadoWithObjetivo(out ObjetivoIndicadorCompose objetivoIndicadorCompose, out ObjetivoCompose objetivoCompose)
        {

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.ObjetivoEspecifico:

                    objetivoCompose = GetObjetivoEspecificoSeleccionado();
                    objetivoIndicadorCompose = (from l in objetivoCompose.Indicadores
                                                where l.Indicador.ID == ActualIndicadorObjetivoEspecifico.Indicador.IdObjetivoIndicador
                                                select l).FirstOrDefault();
                    break;
                case ModifyObjetivo.Objetivo:

                    objetivoCompose = Entity.Objetivo;

                    objetivoIndicadorCompose = (from l in objetivoCompose.Indicadores
                                                where l.Indicador.ID == ActualIndicadorObjetivo.Indicador.IdObjetivoIndicador
                                                select l).FirstOrDefault();
                    break;
                default:
                    objetivoCompose = null;
                    objetivoIndicadorCompose = null;
                    break;
            }

        }
        void CommandIndicadoresEdit(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {

            IndicadoresSetValue(objetivoIndicadorCompose);
            ModalPopupExtenderIndicadores.Show();
            upIndicadoresPopUp.Update();

        }
        void CommandIndicadoresSave()
        {

            ObjetivoIndicadorCompose objetivoIndicadorCompose = null;
            GridView gridview = null;
            UpdatePanel updatePanel = null;

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.ObjetivoEspecifico:
                    objetivoIndicadorCompose = ActualIndicadorObjetivoEspecifico;
                    gridview = gridIndicadoresObjetivoEspecifico;
                    updatePanel = upGridIndicadoresObjetivoEspecifico;
                    break;

                case ModifyObjetivo.Objetivo:
                    objetivoIndicadorCompose = ActualIndicadorObjetivo;
                    gridview = gridIndicadoresObjetivo;
                    updatePanel = upGridIndicadoresObjetivo;
                    break;
                default:
                    break;
            }

            IndicadoresGetValue(objetivoIndicadorCompose);


            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);

            if (entityObjetivoIndicadorCompose != null)
            {
                entityObjetivoIndicadorCompose.Indicador.Indicador_Observacion = objetivoIndicadorCompose.Indicador.Indicador_Observacion;
                entityObjetivoIndicadorCompose.Indicador.IdIndicadorClase = objetivoIndicadorCompose.Indicador.IdIndicadorClase;
                entityObjetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Nombre = objetivoIndicadorCompose.Indicador.IndicadorClase_Nombre;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Sigla = objetivoIndicadorCompose.Indicador.IndicadorClase_Sigla;
                entityObjetivoIndicadorCompose.Indicador.IndicadorClase_Unidad = objetivoIndicadorCompose.Indicador.IndicadorClase_Unidad;
                entityObjetivoIndicadorCompose.Indicador.Indicador_MedioVerificacion = objetivoIndicadorCompose.Indicador.Indicador_MedioVerificacion;
                entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro = entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro; 
            }
            else
            {
                entityObjetivoCompose.Indicadores.Add(objetivoIndicadorCompose);                
            }

            IndicadoresRefresh(entityObjetivoCompose, gridview, updatePanel);
            IndicadoresClear(ModificandoIndicadores); 
           
        }
        void CommandIndicadoresDelete()
        {

            ObjetivoIndicadorCompose objetivoIndicadorCompose = null;
            GridView gridview = null;
            UpdatePanel updatePanel = null;

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.ObjetivoEspecifico:
                    objetivoIndicadorCompose = ActualIndicadorObjetivoEspecifico;
                    gridview = gridIndicadoresObjetivoEspecifico;
                    updatePanel = upGridIndicadoresObjetivoEspecifico;
                    break;

                case ModifyObjetivo.Objetivo:
                    objetivoIndicadorCompose = ActualIndicadorObjetivo;
                    gridview = gridIndicadoresObjetivo;
                    updatePanel = upGridIndicadoresObjetivo;
                    break;
                default:
                    break;
            }

            ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
            ObjetivoCompose entityObjetivoCompose;

            GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);

            entityObjetivoCompose.Indicadores.Remove(entityObjetivoIndicadorCompose);
            IndicadoresClear(ModificandoIndicadores);
            IndicadoresRefresh(entityObjetivoCompose, gridview, updatePanel);

            
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
                autoCmpIndicadorClase.Clear();
                autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
                //German 20140302 - tarea 110
                toIndicadoClase.Clear();
                toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
                //Fin German 20140302 - tarea 110
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
            IndicadoresClear(ModificandoIndicadores);
            HidePopUpIndicadores();
        }
        protected void btAgregarIndicadorObjetivoEspecifico_Click(object sender, EventArgs e)
        {
            ModificandoIndicadores = ModifyObjetivo.ObjetivoEspecifico;
            //IndicadoresClear(ModificandoIndicadores);
            lblTituloIndicadores.Text = (GetObjetivoEspecificoSeleccionado() as PrestamoObjetivoEspecificoCompose).PrestamoObjetivoEspecifico.Objetivo_Nombre;
            upIndicadoresPopUp.Update();
            ModalPopupExtenderIndicadores.Show();                            
            //ddlSector.Focus();
        }
        protected void btAgregarIndicadorObjetivo_Click(object sender, EventArgs e)
        {
            ModificandoIndicadores = ModifyObjetivo.Objetivo;
            //IndicadoresClear(ModificandoIndicadores);
            lblTituloIndicadores.Text = Entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre;
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


            ObjetivoIndicadorCompose objetivoIndicadorCompose = null;

            if (((Control)sender).ID == "gridIndicadoresObjetivoEspecifico")
                ModificandoIndicadores = ModifyObjetivo.ObjetivoEspecifico;
            else
                ModificandoIndicadores = ModifyObjetivo.Objetivo;


            

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.ObjetivoEspecifico:

                    ObjetivoCompose ObjetivoEspecificoSeleccionado = GetObjetivoEspecificoSeleccionado();
                    ActualIndicadorObjetivoEspecifico = (from l in ObjetivoEspecificoSeleccionado.Indicadores
                                                where l.Indicador.ID == id
                                                select l).FirstOrDefault();

                    objetivoIndicadorCompose = ActualIndicadorObjetivoEspecifico;

                    lblTituloIndicadores.Text = (ObjetivoEspecificoSeleccionado as PrestamoObjetivoEspecificoCompose).PrestamoObjetivoEspecifico.Objetivo_Nombre;

                    break;

                case ModifyObjetivo.Objetivo:
                    
                    ActualIndicadorObjetivo = (from l in Entity.Objetivo.Indicadores
                                               where l.Indicador.ID == id
                                               select l).FirstOrDefault();

                    objetivoIndicadorCompose = ActualIndicadorObjetivo;

                    lblTituloIndicadores.Text = Entity.Objetivo.PrestamoObjetivo.Objetivo_Nombre;
                    break;

                default:
                    break;
            }

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandIndicadoresEdit(objetivoIndicadorCompose);
                    break;
                case Command.DELETE:
                    CommandIndicadoresDelete();
                    break;               
                case Command.SHOW_DETAILS:
                    
                    //ActionSupuestos = ModifySupuestos.ObjetivoEspecifico;
                    ShowPopUpEvoluciones(objetivoIndicadorCompose);
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

        protected void ddlMedioVerificacion_IndexChanged(object sender, EventArgs e)
        {

        }
        void CargarMediosVerificacion()
        {
            UIHelper.Load<MedioVerificacion>(ddlMedioVerificacion, MedioVerificacionService.Current.GetList(),
              "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Seleccione Medio" });
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
            int idIndicador = 0;
            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.Objetivo:
                    idIndicador = ActualIndicadorObjetivo.Indicador.IdObjetivoIndicador;
                    break;

                case ModifyObjetivo.ObjetivoEspecifico:
                    idIndicador = ActualIndicadorObjetivoEspecifico.Indicador.IdObjetivoIndicador;
                    break;
                default:
                    break;
            }


            if (objetivoCompose.Indicadores.Where(p => (p.Indicador.IdObjetivoIndicador != idIndicador) && (p.Indicador.IdIndicadorClase == id)).Count() > 0)
            {
                msgError = Translate("* No puede haber mas de un indicador de la misma clase.");
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
            if (ActualIndicadorCompose.Evoluciones.Count > 0) id = ActualIndicadorCompose.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            return indicadorEvolucionResult;

        }

        private ObjetivoIndicadorCompose ActualIndicadorCompose
        {
            get
            {
                switch (ModificandoIndicadores)
                {
                    case ModifyObjetivo.ObjetivoEspecifico:
                        return ActualIndicadorObjetivoEspecifico;
                    case ModifyObjetivo.Objetivo:
                        return ActualIndicadorObjetivo;
                    default:
                        return null;
                }
            }
        }

        #region Methods
        void HidePopUpEvoluciones()
        {
            ModalPopupExtenderEvoluciones.Hide();
        }
        void ShowPopUpEvoluciones(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {
            EvolucionesRefresh();
            btNewEvolucion.Enabled = true;
            btSaveEvolucion.Enabled = false;
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
            
            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.ObjetivoEspecifico:
                    var f = from d in ActualIndicadorObjetivoEspecifico.Evoluciones
                            orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
                            select d;
                    UIHelper.Load(gridEvoluciones, f.ToList());
                    break;
                case ModifyObjetivo.Objetivo:
                    var g = from d in ActualIndicadorObjetivo.Evoluciones
                            orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
                            select d;
                    UIHelper.Load(gridEvoluciones, g.ToList());
                    break;
            }
            
            upGridEvoluciones.Update();
            
        }
        #endregion Methods

        #region Eventos

        protected void btSaveEvolucion_Click(object sender, EventArgs e)
        {

            CallTryMethod(CommandEvolucionSave);


        }
        protected void btNewEvolucion_Click(object sender, EventArgs e)
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
        protected void btCancelEvolucion_Click(object sender, EventArgs e)
        {
            string msgError = string.Empty;
            if (Pages.ValidatorEvolucion.ValidateEvoluciones(ActualIndicadorCompose.Evoluciones, out msgError))
            {
                EvolucionesClear(false);

                ObjetivoIndicadorCompose entityObjetivoIndicadorCompose;
                ObjetivoCompose entityObjetivoCompose;
                GetIndicadorSeleccionadoWithObjetivo(out entityObjetivoIndicadorCompose, out entityObjetivoCompose);
                entityObjetivoIndicadorCompose.Evoluciones = ActualIndicadorCompose.Evoluciones;
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

            IndicadorEvolucionResult ier = (from l in ActualIndicadorCompose.Evoluciones
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
                ier.FechaReal =  ActualIndicadorEvolucion.FechaReal;
                ier.CantidadReal = ActualIndicadorEvolucion.CantidadReal;
                ier.IndicadorEvolucionInstancia_Orden = ActualIndicadorEvolucion.IndicadorEvolucionInstancia_Orden;
                EvolucionesClear(false);
            }
            else
            {
                ActualIndicadorCompose.Evoluciones.Add(ActualIndicadorEvolucion);
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


            IndicadorEvolucionResult result = (from l in ActualIndicadorCompose.Evoluciones
                                             where l.IdIndicadorEvolucion == ActualIndicadorEvolucion.ID
                                             select l).FirstOrDefault();

            ActualIndicadorCompose.Evoluciones.Remove(result);
            
            
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

            
            ActualIndicadorEvolucion = (from l in ActualIndicadorCompose.Evoluciones
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