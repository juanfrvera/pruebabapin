using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web.Pages
{
    public partial class ProyectoObjetivosEdit : WebControlEdit<nc.ProyectoObjetivosCompose>
    {
         
        #region Override WebControlEdit
              

        protected override void _Initialize()
        {
            base._Initialize();
            tsEvolucion.Width = 470;
            tsEvolucion.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            autoCmpIndicadorClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //German 01032014 - tarea 110
            autoCmpIndicadorClase.Visible = false;
            toIndicadoClase.RequiredMessage = TranslateFormat("FieldIsNull", "Indicador");
            //Fin German 01032014 - tarea 110
            rfvProposito.ErrorMessage = TranslateFormat("FieldIsNull", "Propósito");           
            revProposito.ErrorMessage = TranslateFormat("InvalidField", "Propósito");
            revProposito.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            revSupuestos.ErrorMessage = TranslateFormat("FieldIsNull", "Supuesto");
            rfvSupuestos.ErrorMessage = TranslateFormat("InvalidField", "Supuesto");
            revSupuestos.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

            revObservacionesIndicadores.ErrorMessage = TranslateFormat("InvalidField", "Medio de Verifición");
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

            PopUpPropositos.Attributes.CssStyle.Add("display", "none");
            PopUpSupuestos.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadores.Attributes.CssStyle.Add("display", "none");
            PopUpEvoluciones.Attributes.CssStyle.Add("display", "none");

            //Matias 20150120 - Tarea 190
            diFechaEstimadaEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Estimada");
            diFechaRealizadaEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Realizada");
            //FinMatias 20150120 - Tarea 190

            //Matias 20170209 - Ticket #REQ819714
            rfvMedioVerificacion.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            rfvMedioVerificacion2.ErrorMessage = TranslateFormat("FieldIsNull", "Medio de Verificación");
            //FinMatias 20170209 - Ticket #REQ819714
                                
        }
        public override void Clear()
        {
          UIHelper.Clear(txtProducto);
        }
        public override void GetValue()
        {

            //Grabar siempre ???
            Entity.Producto.Producto.Objetivo_Nombre = UIHelper.GetString(txtProducto);
            SaveProgramas();
        }
        public override void SetValue()
        {
            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
            ProgramaObjetivosRefresh();
            ProyectoPropositosRefresh();
            IndicadoresClear(ModifyObjetivo.Proposito);
            upIndicadoresPopUp.Update();
            if (Entity.Producto != null)
            {
                UIHelper.SetValue(txtProducto, Entity.Producto.Producto.Objetivo_Nombre);
            }
            else
            {
                Entity.Producto = new ProyectoProductoCompose();
                Entity.Producto.Producto = new ProyectoProductoResult();
                Entity.Producto.Producto.IdProyectoProducto = -1;
                Entity.Producto.Producto.IdProyecto = Entity.IdProyecto;                
            }
                upProducto.Update();
                IndicadoresRefresh(Entity.Producto, gridIndicadoresProducto, upGridIndicadoresProducto);
                IndicadoresClear(ModifyObjetivo.Producto);
            //IndicadoresClear(); //Es el mejor lugar           
        }
        #endregion Override

        //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
        //#region Permissions
        //protected bool EnableSolapa
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(ViewState["EnableSolapa"]);
        //    }
        //    set
        //    {
        //        ViewState["EnableSolapa"] = value;
        //    }
        //}

        //protected void SetPermissions()
        //{
        //    if (CrudAction == CrudActionEnum.Create)
        //    {
        //        //EnableSolapa = false;
        //    }
        //    else if (CrudAction == CrudActionEnum.Read)
        //    {
        //        EnableSolapa = false;
        //        this.pnlFines.Enabled = false;
        //        this.pnlPropositos.Enabled = false;
        //        this.pnlProducto.Enabled = false;                
        //    }
        //    else
        //    {
        //        //EnableSolapa = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);                
        //    }

        //    //Inhabilito todos los componenetes de la Solapa
        //    //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;            
        //}
        //#endregion
        //FinMatias 20170210 - Ticket #REQ768159

        #region Programas

        void ProgramaObjetivosRefresh()
        {
            UIHelper.Load(gridObjetivosPrograma, Entity.Programas);
            upGridObjetivosPrograma.Update();
        }
        void SaveProgramas()
        {
            foreach (GridViewRow gvr in gridObjetivosPrograma.Rows)
            {

                if (gvr.RowType == DataControlRowType.DataRow)
                {

                    DataKey dk = gridObjetivosPrograma.DataKeys[gvr.RowIndex];
                    int ID = Convert.ToInt32(dk.Value);

                    //DataRowView rowView = ( DataRowView ) gvr.DataItem;
                    CheckBox cb = (CheckBox)gvr.FindControl("cbTieneProyectoFin");
                    bool bTieneProyectoFin = cb.Checked;

                    //int ID = Convert.ToInt32(gvr rowView["ID"]);

                    ProgramaObjetivoResult por = (from o in Entity.Programas where o.IdProgramaObjetivo == ID select o).FirstOrDefault();
                    por.TieneProyectoFin = bTieneProyectoFin;
                }

            }


        }

        #endregion Programas

        #region Propositos

        private ProyectoPropositoCompose actualProyectoProposito;
        protected ProyectoPropositoCompose ActualProyectoProposito
        {
            get
            {
                if (actualProyectoProposito == null)
                    if (ViewState["actualProyectoProposito"] != null)
                        actualProyectoProposito = ViewState["actualProyectoProposito"] as ProyectoPropositoCompose;
                    else
                    {
                        actualProyectoProposito = GetNewProposito();
                        ViewState["actualProyectoProposito"] = actualProyectoProposito;
                    }
                return actualProyectoProposito;
            }
            set
            {
                actualProyectoProposito = value;
                ViewState["actualProyectoProposito"] = value;
            }
        }
        ProyectoPropositoCompose GetNewProposito()
        {            
            int id = 0;
            if (Entity.Propositos.Count > 0) id = Entity.Propositos.Min(l => l.Proposito.IdProyectoProposito);
            if (id > 0) id = 0;
            id--;
            ProyectoPropositoCompose proyectoPropositoCompose = new ProyectoPropositoCompose();
            proyectoPropositoCompose.Proposito = new ProyectoPropositoResult();
            proyectoPropositoCompose.Proposito.IdProyectoProposito = id;
            proyectoPropositoCompose.Proposito.IdProyecto = Entity.IdProyecto;
            return proyectoPropositoCompose;
        }
        private int IdProyectoPropositoSeleccionado
        {
            
            get {  
                
                if (ViewState["IdProyectoPropositoSeleccionado"] == null)
                    return 0;
                return Convert.ToInt32(ViewState["IdProyectoPropositoSeleccionado"]);
            
                }
            set {
                    ViewState["IdProyectoPropositoSeleccionado"] = value;
                }
        }


        #region Methods
        void HidePopUpPropositos()
        {
            ModalPopupExtenderPropositos.Hide();
        }
        void ProyectoPropositosClear()
        {
            UIHelper.Clear(txtProposito);
            ActualProyectoProposito = GetNewProposito();
        }
        void ProyectoPropositosSetValue()
        {
            UIHelper.SetValue(txtProposito, ActualProyectoProposito.Proposito.Objetivo_Nombre);
        }
        void ProyectoPropositosGetValue()        
        {
            ActualProyectoProposito.Proposito.Objetivo_Nombre = UIHelper.GetString(txtProposito);
        }
        void ProyectoPropositosRefresh()
        {

            List<ProyectoPropositoResult>propositos = new List<ProyectoPropositoResult>();
            Entity.Propositos.ForEach( i => propositos.Add(i.Proposito));
            UIHelper.Load(gridPropositos, propositos);
            upGridPropositos.Update();

            if (Entity.Propositos.Count > 0)
            {
                if (Entity.Propositos.Exists(i => i.Proposito.IdProyectoProposito == IdProyectoPropositoSeleccionado))
                {
                    SelecionarPropositoFromId(IdProyectoPropositoSeleccionado);
                }
                else
                {
                    SeleccionarPrimerProposito();
                }

                if (!btAgregarIndicadorProposito.Enabled)
                {
                    btAgregarIndicadorProposito.Enabled = true;
                    upAgregarIndicadorProposito.Update();                
                }
            }
            else
            {
                IdProyectoPropositoSeleccionado = 0;
                UIHelper.Clear(gridIndicadoresProposito);
                upGridIndicadoresProposito.Update();
                btAgregarIndicadorProposito.Enabled = false;
                upAgregarIndicadorProposito.Update();


            }

        }
        #endregion Methods

        #region Commands
        void CommandProyectoPropositoEdit()
        {
            
            ProyectoPropositosSetValue();
            ModalPopupExtenderPropositos.Show();
            upPropositosPopUp.Update();
            
        }
        void CommandProyectoPropositoSave()
        {
            
            ProyectoPropositosGetValue();


            ProyectoPropositoCompose ppc = (from l in Entity.Propositos
                                            where l.Proposito.IdProyectoProposito == ActualProyectoProposito.Proposito.ID
                                            select l).FirstOrDefault();

            if (ppc != null)
            {
                ppc.Proposito.Objetivo_Nombre = ActualProyectoProposito.Proposito.Objetivo_Nombre;
                ProyectoPropositosRefresh();
            }
            else
            {
                
                Entity.Propositos.Add(ActualProyectoProposito);
                // Si no habia propositos seleeciono el que se agrego
                ProyectoPropositosRefresh();
                if (Entity.Propositos.Count == 1)
                    SeleccionarPrimerProposito();
            }
            
            ProyectoPropositosClear();
            

        }
        void CommandProyectoPropositoDelete()
        {
            
            ProyectoPropositoCompose compose = (from l in Entity.Propositos 
                                                where l.Proposito.IdProyectoProposito == ActualProyectoProposito.Proposito.ID 
                                                select l).FirstOrDefault();
            Entity.Propositos.Remove(compose);            
            ProyectoPropositosClear();
            ProyectoPropositosRefresh();
            
        }
        #endregion

        #region Eventos
        protected void btSaveProposito_Click(object sender, EventArgs e)
        {
            
            CallTryMethod(CommandProyectoPropositoSave);
            HidePopUpPropositos();
            
        }
        protected void btNewProposito_Click(object sender, EventArgs e)
        {
            
            CallTryMethod(CommandProyectoPropositoSave);
            txtProposito.Focus();
        }
        protected void btCancelProposito_Click(object sender, EventArgs e)
        {
            ProyectoPropositosClear();
            HidePopUpPropositos();             
        }
        protected void btAgregarProposito_Click(object sender, EventArgs e)
        {
            ProyectoPropositosClear();
            ModalPopupExtenderPropositos.Show();
            txtProposito.Focus();
        }

        protected void rbSeleccionProposito_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow gvr in gridPropositos.Rows)
            {
                ((RadioButton)gvr.FindControl("rbSeleccionProposito")).Checked = false;
            }

            RadioButton rb = sender as RadioButton;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("rbSeleccionProposito")).Checked = true;

            DataKey dk = gridPropositos.DataKeys[row.RowIndex];
            IdProyectoPropositoSeleccionado = Convert.ToInt32(dk.Value);

            ObjetivoCompose propositoSeleccionado = GetPropositoSeleccionado();

            IndicadoresRefresh(propositoSeleccionado, gridIndicadoresProposito, upGridIndicadoresProposito);

            IndicadoresClear(ModifyObjetivo.Proposito);

        }

        #endregion

        #region EventosGrillas
        protected void GridPropositos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {            
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoProposito = (from l in Entity.Propositos 
                                       where l.Proposito.IdProyectoProposito == id 
                                       select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoPropositoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoPropositoDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ActionSupuestos = ModifyObjetivo.Proposito;
                    lblTituloSupuestos.Text = ActualProyectoProposito.Proposito.Objetivo_Nombre;
                    ShowPopUpSupuestos();
                    break;
            }
             
        }
        protected virtual void GridPropositos_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            try
            {
                gridPropositos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
            
        }
        protected virtual void GridPropositos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            try
            {
                gridPropositos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
             
        }
        protected void GridPropositos_RowDataBound(Object sender, GridViewRowEventArgs e)
        {


        }

        void SeleccionarPrimerProposito()
        {
            if (Entity.Propositos.Count > 0)
            { 
                GridViewRow row = gridPropositos.Rows[0];
                ((RadioButton)row.FindControl("rbSeleccionProposito")).Checked = true;

                DataKey dk = gridPropositos.DataKeys[row.RowIndex];
                IdProyectoPropositoSeleccionado = Convert.ToInt32(dk.Value);

                ObjetivoCompose propositoSeleccionado = GetPropositoSeleccionado();

                IndicadoresRefresh(propositoSeleccionado, gridIndicadoresProposito, upGridIndicadoresProposito);
            
            }
        }
        void SelecionarPropositoFromId(int id)
        {
            //se peude recorrer directamente datakey
            DataKey dk;
            foreach (GridViewRow gvr in gridPropositos.Rows)
            {
                dk = gridPropositos.DataKeys[gvr.RowIndex];
                if (Convert.ToInt32(dk.Value) == id)
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionProposito")).Checked = true;
//                    SelectedRowIndexGridIndicadorClase = gvr.RowIndex;
                }
                else
                {
                    ((RadioButton)gvr.FindControl("rbSeleccionProposito")).Checked = false;
                }
            }
        }


        #endregion

        #endregion Propositos

        #region Supuestos

        private enum ModifyObjetivo { Proposito, Producto}
        private ModifyObjetivo ActionSupuestos
        {
            get { return (ModifyObjetivo)ViewState["ActionSupuestos"]; }
            set { ViewState["ActionSupuestos"] = value; }
        
        }

        private enum PopPupState { Adding, Modifying }
        private PopPupState SupuestosPopPupState
        {
            get { return (PopPupState)ViewState["SupuestosPopPupState"]; }
            set { ViewState["SupuestosPopPupState"] = value; }

        }

        private ObjetivoCompose actualObjetivoCompose
        {
            get 
            {
                switch (ActionSupuestos)
                {
                    case ModifyObjetivo.Proposito:
                        return ActualProyectoProposito;
                    case ModifyObjetivo.Producto:
                        return Entity.Producto;
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
            
            //List<ProyectoPropositoResult> propositos = new List<ProyectoPropositoResult>();
            //Entity.Propositos.ForEach(i => propositos.Add(i.Proposito));
            UIHelper.Load(gridSupuestos, actualObjetivoCompose.Supuestos);
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
            //HidePopUpPropositos();

        }
        protected void btCancelSupuesto_Click(object sender, EventArgs e)
        {
            SupuestosClear();

            if (actualObjetivoCompose is ProyectoPropositoCompose)
            {

                ProyectoPropositoCompose proyectoPropositoCompose = (from l in Entity.Propositos
                                                                     where l.Proposito.ID == ActualProyectoProposito.Proposito.ID
                                                                     select l).FirstOrDefault();

                //proyectoPropositoCompose.Supuestos = ActualProyectoProposito.Supuestos;
                proyectoPropositoCompose.Supuestos = actualObjetivoCompose.Supuestos;
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

        #region Producto

        protected void btShowProductoSupuestos_Click(object sender, EventArgs e)
        {
            ActionSupuestos = ModifyObjetivo.Producto;
            lblTituloSupuestos.Text = txtProducto.Text;
            ShowPopUpSupuestos();
        }

        #endregion Producto

        #region Indicadores


        private ModifyObjetivo ModificandoIndicadores
        {
            get { return (ModifyObjetivo)ViewState["ModificandoIndicadores"]; }
            set { ViewState["ModificandoIndicadores"] = value; }

        }

        private ObjetivoCompose GetPropositoSeleccionado()
        {
            ProyectoPropositoCompose proyectoPropositoCompose = (from l in Entity.Propositos
                                                                 where l.Proposito.IdProyectoProposito == IdProyectoPropositoSeleccionado
                                                                 select l).FirstOrDefault();

            return proyectoPropositoCompose;
        }

        // ActualIndicadorProposito

        private ObjetivoIndicadorCompose actualIndicadorProposito;
        protected ObjetivoIndicadorCompose ActualIndicadorProposito
        {
            get
            {
                if (actualIndicadorProposito == null)
                    if (ViewState["actualIndicadorProposito"] != null)
                        actualIndicadorProposito = ViewState["actualIndicadorProposito"] as ObjetivoIndicadorCompose;
                    else
                    {
                        actualIndicadorProposito = GetNewIndicador(GetPropositoSeleccionado());
                        ViewState["actualIndicadorProposito"] = actualIndicadorProposito;
                    }
                return actualIndicadorProposito;
            }
            set
            {
                actualIndicadorProposito = value;
                ViewState["actualIndicadorProposito"] = value;
            }
        }

        // ActualIndicadorProducto

        private ObjetivoIndicadorCompose actualIndicadorProducto;
        protected ObjetivoIndicadorCompose ActualIndicadorProducto
        {
            get
            {
                if (actualIndicadorProducto == null)
                    if (ViewState["actualIndicadorProducto"] != null)
                        actualIndicadorProducto = ViewState["actualIndicadorProducto"] as ObjetivoIndicadorCompose;
                    else
                    {
                        actualIndicadorProducto = GetNewIndicador(Entity.Producto);
                        ViewState["actualIndicadorProducto"] = actualIndicadorProducto;
                    }
                return actualIndicadorProducto;
            }
            set
            {
                actualIndicadorProducto = value;
                ViewState["actualIndicadorProducto"] = value;
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
        void IndicadoresClear(ModifyObjetivo entidad)
        {            
            switch (entidad)
            {
                case ModifyObjetivo.Proposito:
                    if (GetPropositoSeleccionado() != null)
                    ActualIndicadorProposito = GetNewIndicador(GetPropositoSeleccionado());
                    break;
                case ModifyObjetivo.Producto:
                    if (Entity.Producto != null)
                    ActualIndicadorProducto = GetNewIndicador(Entity.Producto);
                    break;
                default:
                    break;
            }
            UIHelper.Clear(txtObservacionesIndicadores);
            UIHelper.Clear(autoCmpIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.Clear(toIndicadoClase);
            //Fin German 01032014 - tarea 110
            UIHelper.Clear(ddlMedioVerificacion);


            autoCmpIndicadorClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };

            //German 01032014 - tarea 110
            toIndicadoClase.Filter = new nc.IndicadorClaseFilter { IdIndicadorTipo = (int)IndicadorTipoEnum.Objetivo, Activo = true };
            //Fin German 01032014 - tarea 110
            
            upIndicadoresPopUp.Update();
           
        }
        void IndicadoresSetValue(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {
            UIHelper.SetValue(autoCmpIndicadorClase, objetivoIndicadorCompose.Indicador.IdIndicadorClase);
            //German 01032014 - tarea 110
            UIHelper.SetValue(toIndicadoClase, objetivoIndicadorCompose.Indicador.IdIndicadorClase);
            //FinGerman 01032014 - tarea 110
            //German 20140511 - Tarea 124
            UIHelper.SetValue(toIndicadoClase.Sectores, objetivoIndicadorCompose.Indicador.IdIndicadorRubro);
            //FinGerman 20140511 - Tarea 124
            UIHelper.SetValue(ddlMedioVerificacion, objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(txtObservacionesIndicadores, objetivoIndicadorCompose.Indicador.Indicador_Observacion);
            UIHelper.SetValue(txtDetalleMedioVerificacion, objetivoIndicadorCompose.Indicador.DetalleMedioVerificacion);
        }
        void IndicadoresGetValue(ObjetivoIndicadorCompose objetivoIndicadorCompose)
        {
            objetivoIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(txtObservacionesIndicadores);
            objetivoIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetIntNullable(ddlMedioVerificacion);
            objetivoIndicadorCompose.Indicador.Indicador_DetalleMedioVerificacion = UIHelper.GetString(txtDetalleMedioVerificacion);
            objetivoIndicadorCompose.Indicador.DetalleMedioVerificacion = UIHelper.GetString(txtDetalleMedioVerificacion);

           objetivoIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(autoCmpIndicadorClase);
           //German 01032014 - tarea 110
           objetivoIndicadorCompose.Indicador.IdIndicadorClase = UIHelper.GetInt(toIndicadoClase);
           //FinGerman 01032014 - tarea 110
           //German 20140511 - Tarea 124
           objetivoIndicadorCompose.Indicador.IdIndicadorRubro = UIHelper.GetIntNullable(toIndicadoClase.Sectores);
           //FinGerman 20140511 - Tarea 124

           IndicadorClaseResult result = IndicadorClaseService.Current.GetResult(new Contract.IndicadorClaseFilter() { IdIndicadorClase = objetivoIndicadorCompose.Indicador.IdIndicadorClase}).FirstOrDefault();
 

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
            UIHelper.Load(gridview, indicadores);
            updatePanel.Update();
                                
        }
        #endregion Methods

        #region Commands

        void GetIndicadorSeleccionadoWithObjetivo(out ObjetivoIndicadorCompose objetivoIndicadorCompose, out ObjetivoCompose objetivoCompose)
        {

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.Proposito:

                    objetivoCompose = GetPropositoSeleccionado();
                    objetivoIndicadorCompose = (from l in objetivoCompose.Indicadores
                                                where l.Indicador.ID == ActualIndicadorProposito.Indicador.IdObjetivoIndicador
                                                select l).FirstOrDefault();
                    break;
                case ModifyObjetivo.Producto:

                    objetivoCompose = Entity.Producto;

                    objetivoIndicadorCompose = (from l in objetivoCompose.Indicadores
                                                where l.Indicador.ID == ActualIndicadorProducto.Indicador.IdObjetivoIndicador
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
                case ModifyObjetivo.Proposito:
                    objetivoIndicadorCompose = ActualIndicadorProposito;
                    gridview = gridIndicadoresProposito;
                    updatePanel = upGridIndicadoresProposito;
                    break;

                case ModifyObjetivo.Producto:
                    objetivoIndicadorCompose = ActualIndicadorProducto;
                    gridview = gridIndicadoresProducto;
                    updatePanel = upGridIndicadoresProducto;
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
                //Matias 20140523 - Tarea 124
                //entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro = entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro;
                entityObjetivoIndicadorCompose.Indicador.IdIndicadorRubro = objetivoIndicadorCompose.Indicador.IdIndicadorRubro;
                //FinMatias 20140523 - Tarea 124
                entityObjetivoIndicadorCompose.Indicador.DetalleMedioVerificacion = objetivoIndicadorCompose.Indicador.Indicador_DetalleMedioVerificacion;
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
                case ModifyObjetivo.Proposito:
                    objetivoIndicadorCompose = ActualIndicadorProposito;
                    gridview = gridIndicadoresProposito;
                    updatePanel = upGridIndicadoresProposito;
                    break;

                case ModifyObjetivo.Producto:
                    objetivoIndicadorCompose = ActualIndicadorProducto;
                    gridview = gridIndicadoresProducto;
                    updatePanel = upGridIndicadoresProducto;
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
        protected void btAgregarIndicadorProposito_Click(object sender, EventArgs e)
        {
            ModificandoIndicadores = ModifyObjetivo.Proposito;
            //IndicadoresClear(ModificandoIndicadores);
            lblTituloIndicadores.Text = (GetPropositoSeleccionado() as ProyectoPropositoCompose).Proposito.Objetivo_Nombre;
            upIndicadoresPopUp.Update();
            ModalPopupExtenderIndicadores.Show();
            autoCmpIndicadorClase.Focus();
            //German 01032014 - tarea 110
            toIndicadoClase.Focus();
            //Fin German 01032014 - tarea 110
        }
        protected void btAgregarIndicadorProducto_Click(object sender, EventArgs e)
        {
            ModificandoIndicadores = ModifyObjetivo.Producto;
            //IndicadoresClear(ModificandoIndicadores);
            lblTituloIndicadores.Text = Entity.Producto.Producto.Objetivo_Nombre;
            upIndicadoresPopUp.Update();
            ModalPopupExtenderIndicadores.Show();
            //SetFocus
            //autoCmpIndicadorClase
        }        
        #endregion

        #region EventosGrillas
        protected void GridIndicadores_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;


            ObjetivoIndicadorCompose objetivoIndicadorCompose = null;

            if (((Control)sender).ID == "gridIndicadoresProposito")
                ModificandoIndicadores = ModifyObjetivo.Proposito;
            else
                ModificandoIndicadores = ModifyObjetivo.Producto;


            

            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.Proposito:

                    ObjetivoCompose propositoSeleccionado = GetPropositoSeleccionado();
                    ActualIndicadorProposito = (from l in propositoSeleccionado.Indicadores
                                                where l.Indicador.ID == id
                                                select l).FirstOrDefault();

                    objetivoIndicadorCompose = ActualIndicadorProposito;

                    lblTituloIndicadores.Text = (propositoSeleccionado as ProyectoPropositoCompose).Proposito.Objetivo_Nombre;

                    break;

                case ModifyObjetivo.Producto:
                    
                    ActualIndicadorProducto = (from l in Entity.Producto.Indicadores
                                               where l.Indicador.ID == id
                                               select l).FirstOrDefault();

                    objetivoIndicadorCompose = ActualIndicadorProducto;

                    lblTituloIndicadores.Text = Entity.Producto.Producto.Objetivo_Nombre;
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
                    
                    //ActionSupuestos = ModifySupuestos.Proposito;
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
              "Nombre", "IdMedioVerificacion", new MedioVerificacion() { IdMedioVerificacion = 0, Nombre = "Selecione Medio" });
        }

        private bool ValidateIndicadores(ObjetivoCompose objetivoCompose, out string msgError)
        {
            msgError = string.Empty;

  

            int id = UIHelper.GetInt(autoCmpIndicadorClase);
            //German 01032014 - tarea 110
            if (autoCmpIndicadorClase.Visible == false)
                id = UIHelper.GetInt(toIndicadoClase);
            //Fin German 01032014 - tarea 110
            if (id == 0)
            { 
                msgError = TranslateFormat("FieldIsNull", "Indicador");
                return false;                 
            }
            int idIndicador = 0;
            switch (ModificandoIndicadores)
            {
                case ModifyObjetivo.Proposito:
                    idIndicador = ActualIndicadorProposito.Indicador.IdObjetivoIndicador;
                    break;

                case ModifyObjetivo.Producto:
                    idIndicador = ActualIndicadorProducto.Indicador.IdObjetivoIndicador;
                    break;
                default:
                    break;
            }
           
            if (objetivoCompose.Indicadores.Where(p => (p.Indicador.IdObjetivoIndicador != idIndicador) &&
                (p.Indicador.IdIndicadorClase == id)).Count() > 0)
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
                    case ModifyObjetivo.Proposito:
                        return ActualIndicadorProposito;
                    case ModifyObjetivo.Producto:
                        return ActualIndicadorProducto;
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
            if(!entradaContinua)
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
            var f = from d in ActualIndicadorCompose.Evoluciones
                    orderby d.ClasificacionGeografica_Descripcion, d.IdIndicadorEvolucionInstancia, d.FechaEstimada
                    select d;

            UIHelper.Load(gridEvoluciones, f.ToList());
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
            if ( ValidatorEvolucion.ValidateEvoluciones(ActualIndicadorCompose.Evoluciones, out msgError))
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
                "Nombre", "IdIndicadorEvolucionInstancia", new IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = 0, Nombre = "Selecione Tipo" },false);          
        }

        #endregion Evoluciones

    }
}