using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using System.IO;

namespace UI.Web
{
    public partial class ProyectoProductoIntermedioEdit : WebControlEdit<nc.ProyectoProductoIntermedioCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();


            // Popus
            PopUpEjecucion.Attributes.CssStyle.Add("display", "none");
            PopUpGastos.Attributes.CssStyle.Add("display", "none");
            PopUpIndicadoresEtapa.Attributes.CssStyle.Add("display", "none");
            PopUpEvoluciones.Attributes.CssStyle.Add("display", "none");

            tbCodeVinculacionEjecucion.Width = 140;


            //PopUp Ejecución
            revNroEjecucion.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();

            revNroEjecucion.ErrorMessage = TranslateFormat("InvalidField", "Nro. Presupuestario");

            //PopUp Evolución
            tsEvolucion.Width = 490;
            //formatos de campos
            revCantRealizadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCantEstimadaEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revCotizacion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //revMontoEstimadoEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullableWithMiles();
            //revMontoRealizado.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullableWithMiles();
            revNroCertificadoEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revNroDesembolso.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(20);
            revPE_AcumuladoEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            revPR_AcumuladoEvolucion.ValidationExpression = Contract.DataHelper.GetExpRegDecimalNullable(2);
            //mensajes de error
            tsEvolucion.RequiredMessage = TranslateFormat("FieldIsNull", "Localización");
            diFechaEstimadaEvolucion.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
            rfvDescripcionEtapa.ErrorMessage = TranslateFormat("FieldIsNull", "Descripción");
            revCotizacion.ErrorMessage = TranslateFormat("InvalidField", "Cotización");
            revNroCertificadoEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Nro. Certificado");
            rfvNroCertificadoEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "Nro. Certificado");
            revNroDesembolso.ErrorMessage = TranslateFormat("InvalidField", "Nro. Desembolso");
            //cantidades    
            rfvCantEstimadaEvolucion.ErrorMessage = TranslateFormat("FieldIsNull", "%E. Certificado");
            revCantEstimadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "%E. Cerrtificado");
            RVCantEstimadaEvolucion.ErrorMessage = Translate("El campo %E. Certificado debe estar entre 1 y 100");

            rfvPE_AcumuladoEvolution.ErrorMessage = TranslateFormat("FieldIsNull", "%E. Acumulado");
            revPE_AcumuladoEvolucion.ErrorMessage = TranslateFormat("InvalidField", "%E.Acumulado");
            RVPE_AcumuladoEvolution.ErrorMessage = Translate("El campo %E.Acumulado debe estar entre 1 y 100");

            revCantRealizadaEvolucion.ErrorMessage = TranslateFormat("InvalidField", "%R.Certificado");
            RVCantRealizadaEvolucion.ErrorMessage = Translate("El campo %R.Certificado debe estar entre 1 y 100");

            revPR_AcumuladoEvolucion.ErrorMessage = TranslateFormat("InvalidField", "%R. Acumulado");
            RVPR_AcumuladoEvolucion.ErrorMessage = Translate("El campo %R. Acumulado debe estar entre 1 y 100");

            //revMontoEstimadoEvolucion.ErrorMessage = TranslateFormat("InvalidField", "Monto Estimado");
            //revMontoRealizado.ErrorMessage = TranslateFormat("InvalidField", "Monto Realizado");


            UIHelper.Load<nc.UnidadMedida>(IND_ddlUnidad, UnidadMedidaService.Current.GetList(new nc.UnidadMedidaFilter() { Activo = true }), "Nombre", "IdUnidadMedida");
            //UIHelper.Load<nc.MedioVerificacion>(IND_ddlMedioVerificacion, MedioVerificacionService.Current.GetList (new nc.MedioVerificacionFilter() { }), "Nombre", "IdMedioVerificacion");
            UIHelper.Load<nc.Moneda>(IND_ddlMoneda, MonedaService.Current.GetList(new nc.MonedaFilter() { Activo = true }), "Nombre", "IdMoneda");
            IND_ddlMoneda.Width = 114;

            List<FaseResult> fases = FaseService.Current.GetResultFromList(new nc.FaseFilter() { Activo = true });
            fases.Remove(fases.Where(l => l.IdFase == (Int32)FaseEnum.Ejecucion).SingleOrDefault());

            fases = fases.OrderBy(p => p.Orden).ToList();


            UIHelper.Load<nc.FaseResult>(ddlFase, fases, "Nombre", "IdFase", new FaseResult() { IdFase = 0, Nombre = Translate("Seleccione una fase") }, false);
            //UIHelper.Load<nc.Fase>(ddlFase, FaseService.Current.GetList(new nc.FaseFilter() { Activo = true }), "Nombre", "IdFase", "Orden", SortDirection.Ascending);

            //UIHelper.Load<IndicadorEvolucionInstancia>(ddlTipoEvolucion, IndicadorEvolucionInstanciaService.Current.GetList(), "Nombre", "IdIndicadorEvolucionInstancia", SortDirection.Ascending);
            UIHelper.Load<nc.Estado>(ddlEstadoEvolucion, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Certificado }), "Nombre", "IdEstado", new Estado() { IdEstado = 0, Nombre = "Seleccione Estado" });

            //Matias 20140318 - Tarea 119
            diFechaEstimadaEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Estimada");
            diFechaRealizadaEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Realizada");
            diFPagoCertificacoEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Pago");
            diFVtoCertificadoEvolucion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Vencimiento");
            //FinMatias 20131318 - Tarea 119

            //Matias 20150120 - Tarea 191
            IND_diFechaLicitacion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Licitación");
            IND_diFechaInicioObra.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Inicio de Obra");
            IND_diFechaContratacion.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha de Contratación");
            //FinMatias 20150120 - Tarea 191

            //Matias 20150206 - Tarea 198
            revNroProyecto.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            revNroProyecto.ErrorMessage = TranslateFormat("InvalidField", "Nro. Proyecto");
            //FinMatias 20150206 - Tarea 198

        }
        protected override void _Load()
        {
            base._Load();
        }
        public override void Clear()
        {
        }
        public override void GetValue()
        {
            Entity.EsProyecto = UIHelper.GetBoolean(cbEsProyecto);
            if (Entity.EsProyecto)
                Entity.NroProyecto = UIHelper.GetInt(tbNroProyecto);
            else
                Entity.NroProyecto = 0;
        }
        public override void SetValue()
        {
            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
            if (Entity.Etapas.Where(e => e.EsDeEjecucion).Count() > 0)
                actualProyectoEjecucion = (Entity.Etapas.Where(e => e.EsDeEjecucion).ToList()[0]);
            else
                actualProyectoEjecucion = GetNewEjecucion();

            UIHelper.SetValue(cbEsProyecto, Entity.EsProyecto);
            string nroProy = "0";
            if (Entity.NroProyecto.ToString().Length == 1)
                nroProy += Entity.NroProyecto.ToString();
            else
                nroProy = Entity.NroProyecto.ToString();

            UIHelper.SetValue(tbNroProyecto, Entity.NroProyecto == 0 ? "" : nroProy);

            RefreshBtAgregarEjecucion();
            RefreshCbEsProyecto();
            ProyectoEjecucionRefresh();
            ProyectoGastosRefresh();
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
        //        this.pnlEjecucion.Enabled = false;
        //        this.pnlGastos.Enabled = false;                
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

        #region Otros Metodos

        public int CantidadObra
        {
            get
            {
                Int32 cantObra = 0;

                foreach (ProyectoEtapaResult per in Entity.Etapas)
                {
                    if (per.IdEtapa == EtapaObra.IdEtapa)
                        cantObra++;
                }
                return cantObra;
            }
        }

        public int CantidadBienDeUso
        {
            get
            {
                Int32 cantBienDeUso = 0;

                foreach (ProyectoEtapaResult per in Entity.Etapas)
                {
                    if (per.IdEtapa == EtapaBien.IdEtapa)
                        cantBienDeUso++;
                }
                return cantBienDeUso;
            }
        }

        public void RefreshDdlEtapa(bool esModificacion)
        {

            List<EtapaResult> etapas = new List<EtapaResult>();

            // Matias 20170607 - Bug que permite editar una IF y agregar mas de una Obra.
            //if (Entity.EsProyecto && (esModificacion || Entity.EtapasCantidadMaxima > CantidadObra) && !Entity.EsEquipamientoBasico)
            if (Entity.EsProyecto && ((esModificacion && ActualProyectoEjecucion.EsObra) || Entity.EtapasCantidadMaxima > CantidadObra) && !Entity.EsEquipamientoBasico)
            // FinMatias 20170607 
            {
                etapas.Add(EtapaObra);
            }

            if (esModificacion || Entity.EtapasCantidadMaxima > CantidadBienDeUso)
            {
                etapas.Add(EtapaBien);
            }
            if (etapas.Count == 0)
            {
                etapas.Add(EtapaObra);
                etapas.Add(EtapaBien);
                ddlEtapa.Enabled = false;
            }
            else
            {
                ddlEtapa.Enabled = true;
            }
            UIHelper.Load<nc.EtapaResult>(ddlEtapa, etapas, "Nombre", "IdEtapa", SortDirection.Descending);
        }

        public void RefreshBtAgregarEjecucion()
        {
            if (Entity.EtapasCantidadMaxima <= CantidadBienDeUso && (!Entity.EsProyecto || Entity.EsEquipamientoBasico || (Entity.EsProyecto && Entity.EtapasCantidadMaxima <= CantidadObra)))
                btAgregarEjecucion.Enabled = false;
            else
                btAgregarEjecucion.Enabled = true;

            btAgregarEtapaIndicadorCompose.Enabled = Entity.Etapas.Count > 0;
            upGridEjecucion.Update();
        }

        public void RefreshCbEsProyecto()
        {
            //Matias 20170220 - Ticket #ER228124
            //cbEsProyecto.Enabled = CantidadObra == 0;
            //tbNroProyecto.Enabled = Entity.EsProyecto;
            cbEsProyecto.Enabled = ((CantidadObra == 0) & (!Entity.EsEquipamientoBasico));
            tbNroProyecto.Enabled = ((Entity.EsProyecto) & (!Entity.EsEquipamientoBasico));
            //FinMatias 20170220 - Ticket #ER228124

            UpdatePanelProy.Update();
        }


        public void cbEsProyecto_OnCheckedChanged(object sender, EventArgs e)
        {
            Entity.EsProyecto = ((CheckBox)sender).Checked;

            if (!((CheckBox)sender).Checked)
            {
                tbNroProyecto.Text = "";
                tbNroProyecto.Enabled = false;
            }
            else
            {
                string nroProy = "0";
                if (Entity.NroProyecto.ToString().Length == 1)
                    nroProy += Entity.NroProyecto.ToString();
                else
                    nroProy = Entity.NroProyecto.ToString();

                tbNroProyecto.Text = nroProy;
                tbNroProyecto.Enabled = true;
            }
            RefreshBtAgregarEjecucion();
            RefreshCbEsProyecto();
        }
        private List<EtapaResult> etapasPlaneamiento;
        protected List<EtapaResult> EtapasPlaneamiento
        {
            get
            {
                if (etapasPlaneamiento == null)
                {
                    if (ExistsPersist("ProductoInternoEtapasPlan"))
                        etapasPlaneamiento = ((List<EtapaResult>)GetPersist("ProductoInternoEtapasPlan"));
                    else
                    {
                        etapasPlaneamiento = EtapaService.Current.GetResult(new nc.EtapaFilter() { IdFase = (Int32)FaseEnum.Planeamiento });
                        SetPersist("ProductoInternoEtapasPlan", etapasPlaneamiento);
                    }
                }
                return etapasPlaneamiento;
            }
            set
            {
                etapasPlaneamiento = value;
                SetPersist("ProductoInternoEtapasPlan", value);
            }
        }

        private EtapaResult etapaObra;
        protected EtapaResult EtapaObra
        {
            get
            {
                if (etapaObra == null)
                {
                    if (ExistsPersist("etapaObra"))
                        etapaObra = ((EtapaResult)GetPersist("etapaObra"));
                    else
                    {
                        Etapa e = EtapaService.Current.GetEtapaObra();
                        etapaObra = new EtapaResult() { IdEtapa = e.IdEtapa, Nombre = e.Nombre };
                        SetPersist("etapaObra", etapaObra);
                    }
                }
                return etapaObra;
            }

        }

        private EtapaResult etapaBien;
        protected EtapaResult EtapaBien
        {
            get
            {
                if (etapaBien == null)
                {
                    if (ExistsPersist("etapaBien"))
                        etapaBien = ((EtapaResult)GetPersist("etapaBien"));
                    else
                    {
                        Etapa e = EtapaService.Current.GetEtapaBienDeUso();
                        etapaBien = new EtapaResult() { IdEtapa = e.IdEtapa, Nombre = e.Nombre };
                        SetPersist("etapaBien", etapaBien);
                    }
                }
                return etapaBien;
            }
        }
        #endregion Metodos

        #region Sobre Ejecucion

        private ProyectoEtapaResult actualProyectoEjecucion;
        protected ProyectoEtapaResult ActualProyectoEjecucion
        {
            get
            {
                if (actualProyectoEjecucion == null)
                {
                    if (ExistsPersist("actualProyectoEjecucion"))
                        actualProyectoEjecucion = ((ProyectoEtapaResult)GetPersist("actualProyectoEjecucion"));
                    else
                    {
                        if (Entity.Etapas.Where(e => e.EsDeEjecucion).Count() > 0)
                            actualProyectoEjecucion = (Entity.Etapas.Where(e => e.EsDeEjecucion).ToList()[0]);
                        else
                            actualProyectoEjecucion = GetNewEjecucion();
                        SetPersist("actualProyectoEjecucion", actualProyectoEjecucion);
                    }
                }
                return actualProyectoEjecucion;
            }
            set
            {
                actualProyectoEjecucion = value;
                SetPersist("actualProyectoEjecucion", value);
            }
        }
        ProyectoEtapaResult GetNewEjecucion()
        {
            int id = 0;
            if (Entity.Etapas.Count > 0) id = Entity.Etapas.Min(l => l.IdProyectoEtapa);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaResult plResult = new ProyectoEtapaResult();
            plResult.IdProyectoEtapa = id;
            plResult.Etapa_IdFase = (Int32)FaseEnum.Ejecucion;
            //plResult.IdEstado = (int)EstadoEnum.Pendiente;
            //plResult.FechaInicioEstimada = DateTime.Now;
            //plResult.FechaFinEstimada = DateTime.Now;
            return plResult;
        }

        #region Methods
        void HidePopUpEjecucion()
        {
            ModalPopupExtenderEjecucion.Hide();
        }
        void ProyectoEjecucionClear()
        {
            UIHelper.Clear(tbNroEjecucion);
            UIHelper.Clear(tbDescripcionEjecucion);
            UIHelper.Clear(tbCodeVinculacionEjecucion);

            if (Entity.Etapas.Where(e => e.EsDeEjecucion).Count() > 0)
                MarcarProyectoEtapa(Entity.Etapas.Where(e => e.EsDeEjecucion).ToList()[0].IdProyectoEtapa);
        }
        void ProyectoEjecucionSetValue()
        {
            UIHelper.SetValue(ddlEtapa, ActualProyectoEjecucion.IdEtapa);
            UIHelper.SetValue(tbNroEjecucion, ActualProyectoEjecucion.NroEtapa);
            UIHelper.SetValue(tbDescripcionEjecucion, ActualProyectoEjecucion.Nombre);
            UIHelper.SetValue(tbCodeVinculacionEjecucion, ActualProyectoEjecucion.CodigoVinculacion);
        }
        void ProyectoEjecucionGetValue()
        {
            ActualProyectoEjecucion.IdEtapa = UIHelper.GetInt(ddlEtapa);
            ActualProyectoEjecucion.Etapa_Nombre = ddlEtapa.SelectedItem.Text;
            ActualProyectoEjecucion.NroEtapa = UIHelper.GetIntNullable(tbNroEjecucion);
            ActualProyectoEjecucion.Nombre = UIHelper.GetString(tbDescripcionEjecucion);
            ActualProyectoEjecucion.CodigoVinculacion = UIHelper.GetString(tbCodeVinculacionEjecucion);
        }
        void ProyectoEjecucionRefresh()
        {
            List<ProyectoEtapaResult> auxs = Entity.Etapas.Where(e => e.EsDeEjecucion).ToList();
            UIHelper.Load(gridEjecucion, auxs, "Etapa_Orden");

            if (ActualProyectoEjecucion == null && Entity.Etapas.Count > 0)
                ActualProyectoEjecucion = Entity.Etapas[0];
            if (ActualProyectoEjecucion != null)
                MarcarProyectoEtapa(ActualProyectoEjecucion.ID);
            upGridEjecucion.Update();
        }
        void MarcarProyectoEtapa(Int32 idProyectoEtapa)
        {
            foreach (ProyectoEtapaResult pe in Entity.Etapas)
            {
                if (pe.IdProyectoEtapa == idProyectoEtapa)
                {
                    ActualProyectoEjecucion = pe;
                    ProyectoEtapaIndicadorComposeRefresh();
                }
            }
            foreach (GridViewRow row in gridEjecucion.Rows)
            {
                Int32 idRowAux = Int32.Parse(gridEjecucion.DataKeys[row.RowIndex].Value.ToString());
                RadioButton rb = ((RadioButton)row.Cells[0].FindControl("rbEtapa"));
                rb.Checked = idRowAux == idProyectoEtapa;
            }
        }
        public string GetMensajeEliminar(Int32 id)
        {
            string rv = "";
            if (this.Entity.Etapas.Where(e => e.IdProyectoEtapa == id && e.TotalEstimado > 0).Count() > 0)
                rv = "return confirm('Existen Montos Estimados, Está seguro de eliminar?');";
            else
                rv = "return confirm('Está seguro de eliminar?');";

            return rv;
        }
        #endregion Methods

        #region Commands
        void CommandProyectoEjecucionEdit()
        {
            RefreshDdlEtapa(true);
            ProyectoEjecucionSetValue();
            ModalPopupExtenderEjecucion.Show();
            upEjecucionPopUp.Update();
        }
        void CommandProyectoEjecucionSave()
        {
            lblError.Text = "";
            ProyectoEjecucionGetValue();
            //if (ActualProyectoEjecucion.NroEtapa > 0)
            //{
            ProyectoEtapaResult result = (from l in Entity.Etapas
                                          where l.IdProyectoEtapa == ActualProyectoEjecucion.ID
                                          select l).FirstOrDefault();
            if (result != null)
            {
                result.Nombre = ActualProyectoEjecucion.Nombre;
                result.IdEtapa = ActualProyectoEjecucion.IdEtapa;
                result.Etapa_Nombre = ActualProyectoEjecucion.Etapa_Nombre;
                result.CodigoVinculacion = ActualProyectoEjecucion.CodigoVinculacion;
                result.NroEtapa = ActualProyectoEjecucion.NroEtapa;
            }
            else
            {
                Entity.Etapas.Add(ActualProyectoEjecucion);
            }
            ProyectoEjecucionClear();

            RefreshDdlEtapa(false);
            RefreshBtAgregarEjecucion();
            RefreshCbEsProyecto();
            //}
            //else
            //{
            //    lblError.Text = TranslateFormat("InvalidField", "Número");
            //    UIHelper.ShowAlert(TranslateFormat("InvalidField", "Número"), upEjecucionPopUp);
            //}

            ProyectoEjecucionRefresh();
            pnlAgregarEtapaIndicadorCompose.Update();
        }
        void CommandProyectoEjecucionDelete()
        {
            // DETALLE
            foreach (ProyectoEtapaIndicadorCompose ie in Entity.IndicadoresEtapa.Where(l => l.Indicador.IdProyectoEtapa == ActualProyectoEjecucion.IdProyectoEtapa).ToList())
            {
                ProyectoEtapaIndicadorCompose peicds = (from l in Entity.IndicadoresEtapa where l.Indicador.IdIndicador == ie.ID select l).FirstOrDefault();
                Entity.IndicadoresEtapa.Remove(peicds);
            }
            ProyectoEtapaIndicadorComposeClear();
            ProyectoEtapaIndicadorComposeRefresh();


            ProyectoEtapaResult result = (from l in Entity.Etapas where l.IdProyectoEtapa == ActualProyectoEjecucion.ID select l).FirstOrDefault();
            //Matias 20141104 - Tarea 168
            //if (result.TotalRealizado == 0)
            if (result.TotalRealizado == null || result.TotalRealizado == 0)
            //Matias 20141104 - Tarea 168
            {
                Entity.Etapas.Remove(result);
                ProyectoEjecucionClear();
                RefreshBtAgregarEjecucion();
                RefreshCbEsProyecto();
                ProyectoEjecucionRefresh();
            }
        }
        #endregion

        #region Eventos
        protected void btSaveEjecucion_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoEjecucionSave);
            if (lblError.Text == "")
                HidePopUpEjecucion();
        }
        protected void btNewEjecucion_Click(object sender, EventArgs e)
        {
            ActualProyectoEjecucion = GetNewEjecucion();
            CallTryMethod(CommandProyectoEjecucionSave);
        }
        protected void btCancelEjecucion_Click(object sender, EventArgs e)
        {
            ProyectoEjecucionClear();
            HidePopUpEjecucion();
        }
        protected void btAgregarEjecucion_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            ProyectoEjecucionClear();
            ActualProyectoEjecucion = GetNewEjecucion();
            RefreshDdlEtapa(false);
            tbNroEjecucion.Focus();
            upEjecucionPopUp.Update();
            ModalPopupExtenderEjecucion.Show();
        }
        public void rbEtapa_OnCheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = ((GridViewRow)((WebControl)sender).NamingContainer);
            Int32 idRow = Int32.Parse(gridEjecucion.DataKeys[gvr.RowIndex].Value.ToString());
            MarcarProyectoEtapa(idRow);
        }
        #endregion

        #region EventosGrillas
        protected void GridEjecucion_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
                ((RadioButton)e.Row.Cells[0].FindControl("rbEtapa")).Checked = true;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 IdProyectoEtapa = Int32.Parse(gridEjecucion.DataKeys[e.Row.RowIndex].Value.ToString());
                    if (IdProyectoEtapa < 0 || ProyectoProductoIntermedioComposeService.Current.Can(Entity, IdProyectoEtapa, ActionConfig.DELETE, UIContext.Current.ContextUser))
                    {
                        ((ImageButton)e.Row.Cells[0].FindControl("imgDelete")).Enabled = true;
                    }
                    else
                    {
                        ((ImageButton)e.Row.Cells[0].FindControl("imgDelete")).ControlStyle.CssClass = "ibDisable";
                        ((ImageButton)e.Row.Cells[0].FindControl("imgDelete")).Enabled = false;
                    }
                }
            }
        }
        protected void GridEjecucion_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEjecucion = (from l in Entity.Etapas where l.IdProyectoEtapa == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoEjecucionEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoEjecucionDelete();
                    break;
            }
        }
        protected virtual void GridEjecucion_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridEjecucion.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridEjecucion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridEjecucion.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Ejecucion

        #region Sobre Indicadores

        private ProyectoEtapaIndicadorCompose actualProyectoEtapaIndicadorCompose;
        protected ProyectoEtapaIndicadorCompose ActualProyectoEtapaIndicadorCompose
        {
            get
            {
                if (actualProyectoEtapaIndicadorCompose == null)
                {
                    if (ExistsPersist("actualProyectoEtapaIndicadorCompose"))
                        actualProyectoEtapaIndicadorCompose = ((ProyectoEtapaIndicadorCompose)GetPersist("actualProyectoEtapaIndicadorCompose"));
                    else
                    {
                        actualProyectoEtapaIndicadorCompose = GetNewEtapaIndicadorCompose();
                        SetPersist("actualProyectoEtapaIndicadorCompose", actualProyectoEtapaIndicadorCompose);
                    }
                }
                return actualProyectoEtapaIndicadorCompose;
            }
            set
            {
                actualProyectoEtapaIndicadorCompose = value;
                SetPersist("actualProyectoEtapaIndicadorCompose", value);
            }
        }
        ProyectoEtapaIndicadorCompose GetNewEtapaIndicadorCompose()
        {
            int id = 0;
            if (Entity.IndicadoresEtapa.Count > 0) id = Entity.IndicadoresEtapa.Min(l => (Int32)l.Indicador.IdIndicador);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaIndicadorCompose plResult = new ProyectoEtapaIndicadorCompose();
            plResult.Indicador.IdProyectoEtapaIndicador = id;
            plResult.Indicador.IdIndicador = id;
            plResult.Indicador.IdProyectoEtapa = ActualProyectoEjecucion.IdProyectoEtapa;
            plResult.Evoluciones = new List<IndicadorEvolucionResult>();
            return plResult;
        }

        #region Methods
        void HidePopUpIndicadoresEtapa()
        {
            ModalPopupExtenderIndicadoresEtapa.Hide();
        }
        void ProyectoEtapaIndicadorComposeClear()
        {
            //UIHelper.Clear(IND_ddlMedioVerificacion);
            UIHelper.Clear(IND_ddlUnidad);
            UIHelper.Clear(IND_diFechaContratacion);
            UIHelper.Clear(IND_diFechaInicioObra);
            UIHelper.Clear(IND_diFechaLicitacion);
            UIHelper.Clear(IND_tbContratista);
            UIHelper.Clear(IND_tbDescripcion);
            UIHelper.Clear(IND_tbExpediente);
            UIHelper.Clear(IND_tbObservaciones);
            UIHelper.Clear(IND_tbPlazo);
            UIHelper.Clear(IND_ddlMoneda);
            UIHelper.Clear(IND_txtMagnitud);
            UIHelper.Clear(IND_txtMContrato);
            UIHelper.Clear(IND_txtMVigente);
        }
        void ProyectoEtapaIndicadorComposeSetValue()
        {
            //UIHelper.SetValue(IND_ddlMedioVerificacion,ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_IdMedioVerificacion);
            UIHelper.SetValue(IND_ddlUnidad, ActualProyectoEtapaIndicadorCompose.Indicador.IdUnidadMedia);
            UIHelper.SetValue(IND_diFechaContratacion, ActualProyectoEtapaIndicadorCompose.Indicador.FechaContratacion);
            UIHelper.SetValue(IND_diFechaInicioObra, ActualProyectoEtapaIndicadorCompose.Indicador.FechaInicioObra);
            UIHelper.SetValue(IND_diFechaLicitacion, ActualProyectoEtapaIndicadorCompose.Indicador.FechaLicitacion);
            UIHelper.SetValue(IND_tbContratista, ActualProyectoEtapaIndicadorCompose.Indicador.Contratista);
            UIHelper.SetValue(IND_tbDescripcion, ActualProyectoEtapaIndicadorCompose.Indicador.Descripcion);
            UIHelper.SetValue(IND_tbExpediente, ActualProyectoEtapaIndicadorCompose.Indicador.NroExpediente);
            UIHelper.SetValue(IND_tbObservaciones, ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_Observacion);
            UIHelper.SetValue(IND_tbPlazo, ActualProyectoEtapaIndicadorCompose.Indicador.PlazoEjecucion);
            UIHelper.SetValue(IND_ddlMoneda, ActualProyectoEtapaIndicadorCompose.Indicador.IdMoneda);
            UIHelper.SetValue(IND_txtMagnitud, ActualProyectoEtapaIndicadorCompose.Indicador.Magnitud);
            UIHelper.SetValue(IND_txtMContrato, ActualProyectoEtapaIndicadorCompose.Indicador.MontoContrato);
            UIHelper.SetValue(IND_txtMVigente, ActualProyectoEtapaIndicadorCompose.Indicador.MontoVigente);
        }
        void ProyectoEtapaIndicadorComposeGetValue()
        {
            //ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_IdMedioVerificacion = UIHelper.GetInt(IND_ddlMedioVerificacion);
            //ActualProyectoEtapaIndicadorCompose.Indicador.MedioDeVerificacion = IND_ddlMedioVerificacion.SelectedItem.Text;
            ActualProyectoEtapaIndicadorCompose.Indicador.IdUnidadMedia = UIHelper.GetInt(IND_ddlUnidad);
            ActualProyectoEtapaIndicadorCompose.Indicador.FechaContratacion = UIHelper.GetDateTimeNullable(IND_diFechaContratacion);
            ActualProyectoEtapaIndicadorCompose.Indicador.FechaInicioObra = UIHelper.GetDateTimeNullable(IND_diFechaInicioObra);
            ActualProyectoEtapaIndicadorCompose.Indicador.FechaLicitacion = UIHelper.GetDateTimeNullable(IND_diFechaLicitacion);
            ActualProyectoEtapaIndicadorCompose.Indicador.Contratista = UIHelper.GetString(IND_tbContratista);
            ActualProyectoEtapaIndicadorCompose.Indicador.Descripcion = UIHelper.GetString(IND_tbDescripcion);
            ActualProyectoEtapaIndicadorCompose.Indicador.NroExpediente = UIHelper.GetString(IND_tbExpediente);
            ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_Observacion = UIHelper.GetString(IND_tbObservaciones);
            ActualProyectoEtapaIndicadorCompose.Indicador.PlazoEjecucion = UIHelper.GetString(IND_tbPlazo);
            ActualProyectoEtapaIndicadorCompose.Indicador.IdMoneda = UIHelper.GetInt(IND_ddlMoneda);
            ActualProyectoEtapaIndicadorCompose.Indicador.Magnitud = UIHelper.GetInt(IND_txtMagnitud);
            ActualProyectoEtapaIndicadorCompose.Indicador.MontoVigente = UIHelper.GetInt(IND_txtMVigente);
            ActualProyectoEtapaIndicadorCompose.Indicador.MontoContrato = UIHelper.GetInt(IND_txtMContrato);
        }
        void ProyectoEtapaIndicadorComposeRefresh()
        {
            if (ActualProyectoEjecucion == null)
            {
                UIHelper.Load(gridIndicadoresEtapa, new List<ProyectoEtapaIndicadorCompose>(), "Fecha");
                upGridIndicadoresEtapa.Update();
                return;
            }
            UIHelper.Load(gridIndicadoresEtapa, Entity.IndicadoresEtapa.Where(i => i.Indicador.IdProyectoEtapa == ActualProyectoEjecucion.IdProyectoEtapa).ToList());
            upGridIndicadoresEtapa.Update();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoEtapaIndicadorComposeEdit()
        {
            ProyectoEtapaIndicadorComposeSetValue();
            ModalPopupExtenderIndicadoresEtapa.Show();
            upIndicadoresEtapaPopUp.Update();
        }
        void CommandProyectoEtapaIndicadorComposeSave()
        {
            ProyectoEtapaIndicadorComposeGetValue();
            ProyectoEtapaIndicadorCompose result = (from l in Entity.IndicadoresEtapa
                                                    where l.Indicador.IdProyectoEtapaIndicador == ActualProyectoEtapaIndicadorCompose.Indicador.IdProyectoEtapaIndicador
                                                    select l).FirstOrDefault();
            if (true)
            {
                if (result != null)
                {
                    result.Indicador.Indicador_IdMedioVerificacion = ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_IdMedioVerificacion;
                    result.Indicador.IdUnidadMedia = ActualProyectoEtapaIndicadorCompose.Indicador.IdUnidadMedia;
                    result.Indicador.FechaContratacion = ActualProyectoEtapaIndicadorCompose.Indicador.FechaContratacion;
                    result.Indicador.FechaInicioObra = ActualProyectoEtapaIndicadorCompose.Indicador.FechaInicioObra;
                    result.Indicador.FechaLicitacion = ActualProyectoEtapaIndicadorCompose.Indicador.FechaLicitacion;
                    result.Indicador.Contratista = ActualProyectoEtapaIndicadorCompose.Indicador.Contratista;
                    result.Indicador.Descripcion = ActualProyectoEtapaIndicadorCompose.Indicador.Descripcion;
                    result.Indicador.NroExpediente = ActualProyectoEtapaIndicadorCompose.Indicador.NroExpediente;
                    result.Indicador.Indicador_Observacion = ActualProyectoEtapaIndicadorCompose.Indicador.Indicador_Observacion;
                    result.Indicador.PlazoEjecucion = ActualProyectoEtapaIndicadorCompose.Indicador.PlazoEjecucion;
                    result.Indicador.MedioDeVerificacion = ActualProyectoEtapaIndicadorCompose.Indicador.MedioDeVerificacion;
                    result.Indicador.IdMoneda = ActualProyectoEtapaIndicadorCompose.Indicador.IdMoneda;
                    result.Indicador.MontoContrato = ActualProyectoEtapaIndicadorCompose.Indicador.MontoContrato;
                    result.Indicador.MontoVigente = ActualProyectoEtapaIndicadorCompose.Indicador.MontoVigente;
                    result.Indicador.Magnitud = ActualProyectoEtapaIndicadorCompose.Indicador.Magnitud;
                }
                else
                {
                    Entity.IndicadoresEtapa.Add(ActualProyectoEtapaIndicadorCompose);
                }
                ProyectoEtapaIndicadorComposeClear();
                ProyectoEtapaIndicadorComposeRefresh();
                ProyectoEjecucionRefresh();
            }
            else
            {
                lblErrorEtapaIndicadorCompose.Text = SolutionContext.Current.TextManager.Translate("Datos Faltantes, Inválidos o Repetidos");
                UIHelper.ShowAlert(UIHelper.Translate("Datos Faltantes, Inválidos o Repetidos"), upIndicadoresEtapaPopUp);
                upIndicadoresEtapaPopUp.Update();
            }
        }
        void CommandProyectoEtapaIndicadorComposeDelete()
        {
            //ProyectoEtapaIndicadorCompose result = (from l in Entity.IndicadoresEtapa where l.Indicador.IdIndicador == ActualProyectoEtapaIndicadorCompose.Indicador.ID select l).FirstOrDefault();
            // Corregido por marcos
            ProyectoEtapaIndicadorCompose result = (from l in Entity.IndicadoresEtapa where l.Indicador.ID == ActualProyectoEtapaIndicadorCompose.Indicador.ID select l).FirstOrDefault();
            Entity.IndicadoresEtapa.Remove(result);
            ProyectoEtapaIndicadorComposeClear();
            ProyectoEtapaIndicadorComposeRefresh();
            ProyectoEjecucionRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveEtapaIndicadorCompose_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEtapaIndicadorCompose, "");
            UIHelper.CallTryMethod(CommandProyectoEtapaIndicadorComposeSave);
            if (lblErrorEtapaIndicadorCompose.Text == "")
                HidePopUpIndicadoresEtapa();
        }
        protected void btNewEtapaIndicadorCompose_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEtapaIndicadorCompose, "");
            UIHelper.CallTryMethod(CommandProyectoEtapaIndicadorComposeSave);
            if (lblErrorEtapaIndicadorCompose.Text == "")
            {
            }
            //Matias 20131104 - Tarea 29
            if (Entity.Etapas.Count > 0 && ActualProyectoEjecucion != null)
            {
                ActualProyectoEtapaIndicadorCompose = GetNewEtapaIndicadorCompose();
                upIndicadoresEtapaPopUp.Update();
                ModalPopupExtenderIndicadoresEtapa.Show();
            }
            //FinMatias 20131104 - Tarea 29
        }
        protected void btCancelEtapaIndicadorCompose_Click(object sender, EventArgs e)
        {
            ProyectoEtapaIndicadorComposeClear();
            ProyectoEtapaIndicadorComposeRefresh();
            ProyectoEjecucionRefresh();
            HidePopUpIndicadoresEtapa();
        }
        protected void btAgregarEtapaIndicadorCompose_Click(object sender, EventArgs e)
        {
            if (Entity.Etapas.Count > 0 && ActualProyectoEjecucion != null)
            {
                ActualProyectoEtapaIndicadorCompose = GetNewEtapaIndicadorCompose();
                upIndicadoresEtapaPopUp.Update();
                ModalPopupExtenderIndicadoresEtapa.Show();
            }
        }

        protected void btExportarDetalle_Click(object sender, EventArgs e)
        {
            // Primero verifico si en la grilla de indicadores de etapas, hay registros para exportar, sino lo hay, muestro un mensaje informativo
            if (this.gridIndicadoresEtapa.Rows.Count == 0)
            {
                UIHelper.ShowAlert("No hay registros para exportar", this.Page);
                return;
            }

            // Realizo la funcion para exportar a excel
            this.GenerateExcel();


        }

        protected void GenerateExcel()
        {
            Filter Filter = new ProyectoProductoFilter();
            int auxPageSize = Filter.PageSize;
            int auxPageNumber = Filter.PageNumber;
            bool auxGetTotaRowsCount = Filter.GetTotaRowsCount;
            Filter.PageSize = 0;
            Filter.PageNumber = 1;

            List<ProyectoEtapaIndicadorResult> listaProyectoEtapaIndicador = new List<ProyectoEtapaIndicadorResult>();
            Entity.IndicadoresEtapa.ForEach(proyectoEtapa => listaProyectoEtapaIndicador.Add(proyectoEtapa.Indicador));

            DataTableMapping mapping = GetDataTableMapping();

            MemoryStream stream = new MemoryStream();
            DataHelper.Write<ProyectoEtapaIndicadorResult>(stream, listaProyectoEtapaIndicador, mapping, ReportEnum.Excel);
            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/vnd.ms-excel";
            HttpContext.Current.Session["OpenXmlFileName"] = mapping.Title + ".xls";
            Filter.PageSize = auxPageSize;
            Filter.PageNumber = auxPageNumber;
            Filter.GetTotaRowsCount = auxGetTotaRowsCount;
            int rows = listaProyectoEtapaIndicador.Count();
            Filter.Rows = rows;
            SetParameter("ProyectoProductoFilter", Filter);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "OpenFile", "window.open( '../Controls/OpenFileFromSession.aspx', null, 'height=1,width=1,status=yes,toolbar=no,menubar=no,location=no' );", true);
        }

        protected DataTableMapping GetDataTableMapping()
        {
            return (new ProyectoEtapaIndicadorResult().ToMapping());
        }

        #endregion

        #region EventosGrillas

        protected void GridIndicadoresEtapa_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEtapaIndicadorCompose = (from l in Entity.IndicadoresEtapa where l.Indicador.IdProyectoEtapaIndicador == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoEtapaIndicadorComposeEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoEtapaIndicadorComposeDelete();
                    break;
                case Command.SHOW_DETAILS:
                    ShowPopUpEvoluciones();
                    break;
            }
        }
        protected virtual void GridIndicadoresEtapa_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridIndicadoresEtapa.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridIndicadoresEtapa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridIndicadoresEtapa.PageIndex = e.NewPageIndex;
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

        private IndicadorEvolucionResult actualIndicadorEvolucion;
        protected IndicadorEvolucionResult ActualIndicadorEvolucion
        {
            get
            {
                if (actualIndicadorEvolucion == null)
                {
                    if (ExistsPersist("actualIndicadorEvolucion"))
                        actualIndicadorEvolucion = ((IndicadorEvolucionResult)GetPersist("actualIndicadorEvolucion"));
                    else
                    {
                        actualIndicadorEvolucion = GetNewEvolucion();
                        SetPersist("actualIndicadorEvolucion", actualIndicadorEvolucion);
                    }
                }
                return actualIndicadorEvolucion;
            }
            set
            {
                actualIndicadorEvolucion = value;
                SetPersist("actualIndicadorEvolucion", value);
            }
        }
        IndicadorEvolucionResult GetNewEvolucion()
        {
            int id = 0;
            if (ActualProyectoEtapaIndicadorCompose.Evoluciones.Count > 0) id = ActualProyectoEtapaIndicadorCompose.Evoluciones.Min(l => l.IdIndicadorEvolucion);
            if (id > 0) id = 0;
            id--;
            IndicadorEvolucionResult indicadorEvolucionResult = new IndicadorEvolucionResult();
            indicadorEvolucionResult.IdIndicadorEvolucion = id;
            indicadorEvolucionResult.IdIndicador = ActualProyectoEtapaIndicadorCompose.Indicador.IdProyectoEtapaIndicador;
            return indicadorEvolucionResult;
        }

        #region Methods
        void HidePopUpEvoluciones()
        {
            ModalPopupExtenderEvoluciones.Hide();
        }
        void ShowPopUpEvoluciones()
        {
            EvolucionesRefresh();
            btNewEvolucion.Enabled = true;
            btSaveEvolucion.Enabled = false;
            upEvolucionesPopUp.Update();
            ModalPopupExtenderEvoluciones.Show();
        }
        void EvolucionesClear()
        {
            UIHelper.Clear(tsEvolucion as IWebControlTreeSelect);
            UIHelper.Clear(diFechaEstimadaEvolucion);
            UIHelper.Clear(diFechaRealizadaEvolucion);
            UIHelper.Clear(tbCantRealizadaEvolucion);
            UIHelper.Clear(tbCantEstimadaEvolucion);
            UIHelper.Clear(ddlEstadoEvolucion);
            UIHelper.Clear(tbPE_AcumuladoEvolucion);
            UIHelper.Clear(tbPR_AcumuladoEvolucion);
            UIHelper.Clear(txtExpediente);
            UIHelper.Clear(tbMontoEstimadoEvolucion);
            UIHelper.Clear(tbMontoRealizadoEvolucion);
            UIHelper.Clear(tbNroCertificadoEvolucion);
            UIHelper.Clear(diFPagoCertificacoEvolucion);
            UIHelper.Clear(diFVtoCertificadoEvolucion);
            UIHelper.Clear(tbObservacionesEvolucion);
            UIHelper.Clear(tbCotizacion);
            UIHelper.Clear(tbNroDesembolso);

            ActualIndicadorEvolucion = GetNewEvolucion();
        }
        void EvolucionesSetValue()
        {
            lblErrorEvoluciones.Text = "";
            UIHelper.SetValue(tsEvolucion as IWebControlTreeSelect, ActualIndicadorEvolucion.IdClasificacionGeografica);
            UIHelper.SetValue(diFechaEstimadaEvolucion, ActualIndicadorEvolucion.FechaEstimada);
            UIHelper.SetValue(diFechaRealizadaEvolucion, ActualIndicadorEvolucion.FechaReal);
            if (actualIndicadorEvolucion.IdCertificadoEstado.HasValue)
                UIHelper.SetValue<Estado, int>(ddlEstadoEvolucion, ActualIndicadorEvolucion.IdCertificadoEstado.Value, EstadoService.Current.GetById);
            UIHelper.SetValue(tbPE_AcumuladoEvolucion, ActualIndicadorEvolucion.CantidadAcumuladaEstimada);
            UIHelper.SetValue(tbPR_AcumuladoEvolucion, ActualIndicadorEvolucion.CantidadAcumuladaRealizada);
            UIHelper.SetValue(tbCantRealizadaEvolucion, ActualIndicadorEvolucion.CantidadReal);
            UIHelper.SetValue(tbCantEstimadaEvolucion, ActualIndicadorEvolucion.CantidadEstimada);
            UIHelper.SetValue(txtExpediente, ActualIndicadorEvolucion.NroExpediente);
            UIHelper.SetValue(tbMontoEstimadoEvolucion, ActualIndicadorEvolucion.MontoEstimado);
            UIHelper.SetValue(tbMontoRealizadoEvolucion, ActualIndicadorEvolucion.MontoRealizado);
            UIHelper.SetValue(tbNroCertificadoEvolucion, ActualIndicadorEvolucion.CertificadoNumero);
            UIHelper.SetValue(diFPagoCertificacoEvolucion, ActualIndicadorEvolucion.CertificadoFechaPago);
            UIHelper.SetValue(diFVtoCertificadoEvolucion, ActualIndicadorEvolucion.CertificadoFechaVencimiento);
            UIHelper.SetValue(tbObservacionesEvolucion, ActualIndicadorEvolucion.Observacion);
            UIHelper.SetValue(tbCotizacion, ActualIndicadorEvolucion.Cotizacion);
            UIHelper.SetValue(tbNroDesembolso, ActualIndicadorEvolucion.NumeroDesembolso);
        }
        void EvolucionesGetValue()
        {
            ActualIndicadorEvolucion.IdClasificacionGeografica = UIHelper.GetInt(tsEvolucion as IWebControlTreeSelect);
            ActualIndicadorEvolucion.FechaEstimada = UIHelper.GetDateTimeNullable(diFechaEstimadaEvolucion);
            ActualIndicadorEvolucion.FechaReal = UIHelper.GetDateTimeNullable(diFechaRealizadaEvolucion);
            ActualIndicadorEvolucion.IdCertificadoEstado = UIHelper.GetIntNullable(ddlEstadoEvolucion);
            ActualIndicadorEvolucion.CantidadAcumuladaEstimada = UIHelper.GetDecimal(tbPE_AcumuladoEvolucion);
            ActualIndicadorEvolucion.CantidadAcumuladaRealizada = UIHelper.GetDecimal(tbPR_AcumuladoEvolucion);
            ActualIndicadorEvolucion.CantidadEstimada = UIHelper.GetDecimal(tbCantEstimadaEvolucion);
            ActualIndicadorEvolucion.CantidadReal = UIHelper.GetDecimal(tbCantRealizadaEvolucion);
            ActualIndicadorEvolucion.IdIndicadorEvolucionInstancia = 1;// NO CONTEMPLA NULL
            ActualIndicadorEvolucion.NroExpediente = UIHelper.GetString(txtExpediente);
            ActualIndicadorEvolucion.MontoEstimado = UIHelper.GetDecimal(tbMontoEstimadoEvolucion);
            ActualIndicadorEvolucion.MontoRealizado = UIHelper.GetDecimal(tbMontoRealizadoEvolucion);
            ActualIndicadorEvolucion.CertificadoNumero = UIHelper.GetString(tbNroCertificadoEvolucion);
            ActualIndicadorEvolucion.CertificadoFechaPago = UIHelper.GetDateTimeNullable(diFPagoCertificacoEvolucion);
            ActualIndicadorEvolucion.CertificadoFechaVencimiento = UIHelper.GetDateTimeNullable(diFVtoCertificadoEvolucion);
            ActualIndicadorEvolucion.Observacion = UIHelper.GetString(tbObservacionesEvolucion);
            ActualIndicadorEvolucion.Cotizacion = UIHelper.GetDecimal(tbCotizacion);
            ActualIndicadorEvolucion.NumeroDesembolso = UIHelper.GetString(tbNroDesembolso);
            ActualIndicadorEvolucion.ValidarCantidadEstados = false;

            if (ActualIndicadorEvolucion.IdClasificacionGeografica > 0)
                ActualIndicadorEvolucion.ClasificacionGeografica_Descripcion = UIHelper.GetNodeResult(tsEvolucion as IWebControlTreeSelect).Descripcion;
            if (ActualIndicadorEvolucion.IdCertificadoEstado != null && ActualIndicadorEvolucion.IdCertificadoEstado > 0)
                ActualIndicadorEvolucion.CertificadoEstado_Nombre = ddlEstadoEvolucion.SelectedItem.Text;

            //ActualIndicadorEvolucion.IndicadorEvolucionInstancia_Nombre = ddlTipoEvolucion.SelectedItem.Text;
        }
        void EvolucionesRefresh()
        {
            UIHelper.Load(gridEvoluciones, ActualProyectoEtapaIndicadorCompose.Evoluciones, "Orden");
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
        bool ValidateEvoluciones(List<IndicadorEvolucionResult> Evoluciones)
        {
            var tabla = from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            CantBase = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Base),
                            CantIntermedio = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio),
                            CantFinal = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Final)
                        };

            foreach (var linea in tabla)
            {
                if (linea.CantBase != 1)
                    return false;
                if (linea.CantIntermedio < 1)
                    return false;
                if (linea.CantFinal != 1)
                    return false;
            }

            var tabla2 = from evolucion in Evoluciones
                         group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                         select new
                         {
                             IdClasificacionGeografica = evolucionGroup.Key,
                             MonthGroups =
                                             from o in evolucionGroup
                                             group o by o.FechaReal into mg
                                             select new { Fecha = mg.Key, CantIntermedio = mg.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio) }
                         };
            foreach (var linea2 in tabla2)
            {
                if (linea2.MonthGroups.Count(p => p.CantIntermedio > 1) > 0)
                    return false;
            }
            return true;
        }
        void AdministrarEvolucionesEvoluciones()
        {
            // Copia las Evoluciones al objeto
            ProyectoEtapaIndicadorCompose refActual = (from e in Entity.IndicadoresEtapa
                                                       where e.ID == ActualProyectoEtapaIndicadorCompose.Indicador.IdProyectoEtapaIndicador
                                                       select e).FirstOrDefault();
            refActual.Evoluciones = ActualProyectoEtapaIndicadorCompose.Evoluciones;
        }
        #endregion

        #region Eventos
        protected void btSaveEvolucion_Click(object sender, EventArgs e)
        {
            // Guarda la Calificacion Anteriror seleccionada
            Int32 CGAnterior = UIHelper.GetInt(tsEvolucion as IWebControlTreeSelect);

            lblErrorEvoluciones.Text = "";
            CallTryMethod(CommandEvolucionSave);

            // Setea la calificacion anterior
            UIHelper.SetValue(tsEvolucion as IWebControlTreeSelect, CGAnterior);
        }
        protected void btNewEvolucion_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandEvolucionSave);
            upGridEvoluciones.Update();
        }
        protected void btCancelEvolucion_Click(object sender, EventArgs e)
        {
            //if (ValidateEvoluciones(ActualProyectoEtapaIndicadorCompose.Evoluciones))
            //{
            EvolucionesClear();
            HidePopUpEvoluciones();
            //}
            //else
            //{
            //    lblErrorEvoluciones.Text = SolutionContext.Current.TextManager.Translate("La evolución no contempla todos los tipos.");
            //}
        }
        protected void btClearEvolucion_Click(object sender, EventArgs e)
        {
            EvolucionesClear();
            btNewEvolucion.Enabled = true;
            btSaveEvolucion.Enabled = false;
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
            btNewEvolucion.Enabled = false;
            btSaveEvolucion.Enabled = true;
            upEvolucionesPopUp.Update();
        }
        void CommandEvolucionSave()
        {
            EvolucionesGetValue();

            if (ValidaEvolucionActual())
            {
                IndicadorEvolucionResult ier = (from l in ActualProyectoEtapaIndicadorCompose.Evoluciones
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
                    ier.IdCertificadoEstado = ActualIndicadorEvolucion.IdCertificadoEstado;
                    ier.CantidadAcumuladaEstimada = ActualIndicadorEvolucion.CantidadAcumuladaEstimada;
                    ier.CantidadAcumuladaRealizada = ActualIndicadorEvolucion.CantidadAcumuladaRealizada;
                    ier.NroExpediente = ActualIndicadorEvolucion.NroExpediente;
                    ier.MontoEstimado = ActualIndicadorEvolucion.MontoEstimado;
                    ier.MontoRealizado = ActualIndicadorEvolucion.MontoRealizado;
                    ier.CertificadoNumero = ActualIndicadorEvolucion.CertificadoNumero;
                    ier.CertificadoFechaPago = ActualIndicadorEvolucion.CertificadoFechaPago;
                    ier.CertificadoFechaVencimiento = ActualIndicadorEvolucion.CertificadoFechaVencimiento;
                    ier.Observacion = ActualIndicadorEvolucion.Observacion;
                    ier.Cotizacion = ActualIndicadorEvolucion.Cotizacion;
                    ier.NumeroDesembolso = ActualIndicadorEvolucion.NumeroDesembolso;
                    ier.CertificadoEstado_Nombre = ActualIndicadorEvolucion.CertificadoEstado_Nombre;
                }
                else
                {
                    ActualProyectoEtapaIndicadorCompose.Evoluciones.Add(ActualIndicadorEvolucion);
                }

                AdministrarEvolucionesEvoluciones();
                EvolucionesClear();
                EvolucionesRefresh();
                btNewEvolucion.Enabled = true;
                btSaveEvolucion.Enabled = false;
                upEvolucionesPopUp.Update();
            }
            else
            {
                lblErrorEvoluciones.Text = SolutionContext.Current.TextManager.Translate("Los datos Localización y Cantidad Certificada/Acumulada Estimada son Obligatorios ");
                UIHelper.ShowAlert(UIHelper.Translate("Los datos Localización y Cantidad Certificada/Acumulada Estimada son Obligatorios "), upEvolucionesPopUp);
                upEvolucionesPopUp.Update();
            }
        }
        void CommandEvolucionDelete()
        {
            IndicadorEvolucionResult result = (from l in ActualProyectoEtapaIndicadorCompose.Evoluciones
                                               where l.IdIndicadorEvolucion == ActualIndicadorEvolucion.ID
                                               select l).FirstOrDefault();
            ActualProyectoEtapaIndicadorCompose.Evoluciones.Remove(result);
            AdministrarEvolucionesEvoluciones();
            EvolucionesClear();
            EvolucionesRefresh();
        }
        #endregion

        #region EventosGrillas
        protected void GridEvoluciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualIndicadorEvolucion = (from l in ActualProyectoEtapaIndicadorCompose.Evoluciones
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

        #region Sobre Gastos

        private ProyectoEtapaResult actualProyectoGastos;
        protected ProyectoEtapaResult ActualProyectoGastos
        {
            get
            {
                if (actualProyectoGastos == null)
                {
                    if (ExistsPersist("actualProyectoGastos"))
                        actualProyectoGastos = ((ProyectoEtapaResult)GetPersist("actualProyectoGastos"));
                    else
                    {
                        actualProyectoGastos = GetNewGastos();
                        SetPersist("actualProyectoGastos", actualProyectoGastos);
                    }
                }
                return actualProyectoGastos;
            }
            set
            {
                actualProyectoGastos = value;
                SetPersist("actualProyectoGastos", value);
            }
        }
        ProyectoEtapaResult GetNewGastos()
        {
            int id = 0;
            if (Entity.Etapas.Count > 0) id = Entity.Etapas.Min(l => l.IdProyectoEtapa);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaResult plResult = new ProyectoEtapaResult();
            plResult.IdProyectoEtapa = id;
            return plResult;
        }

        #region Methods
        void HidePopUpGastos()
        {
            ModalPopupExtenderGastos.Hide();
        }
        void ProyectoGastosClear()
        {
            UIHelper.Clear(ddlFase);
            BuscarTipoEtapaYDescripcion();
            UIHelper.Clear(tbDescripcion);
            tbDescripcion.Enabled = true;
            ActualProyectoGastos = GetNewGastos();
        }
        void ProyectoGastosSetValue()
        {
            UIHelper.SetValue<Fase, int>(ddlFase, ActualProyectoGastos.Etapa_IdFase, FaseService.Current.GetById);

            nc.EtapaFilter etapaFilter = new nc.EtapaFilter() { IdFase = ActualProyectoGastos.Etapa_IdFase, Activo = true };
            etapaFilter.FilterOrderBy = new FilterOrderBy { OrderByDesc = false, OrderByProperty = "Orden" };
            List<EtapaResult> etapas = EtapaService.Current.GetResultFromList(etapaFilter);

            UIHelper.Load<nc.EtapaResult>(ddlTipoEtapa, etapas, "Nombre", "IdEtapa", false);
            ddlTipoEtapa.Enabled = true;

            UIHelper.SetValue(ddlTipoEtapa, ActualProyectoGastos.IdEtapa);
            UIHelper.SetValue(tbDescripcion, ActualProyectoGastos.Nombre);
            tbDescripcion.Enabled = EtapasPlaneamiento.Where(et => et.IdEtapa == ActualProyectoGastos.IdEtapa).Count() == 0;
        }
        void ProyectoGastosGetValue()
        {
            ActualProyectoGastos.IdEtapa = UIHelper.GetInt(ddlTipoEtapa);
            ActualProyectoGastos.Etapa_Nombre = UIHelper.GetString(ddlTipoEtapa);
            ActualProyectoGastos.Nombre = UIHelper.GetString(tbDescripcion);
            ActualProyectoGastos.Etapa_IdFase = UIHelper.GetInt(ddlFase);
            ActualProyectoGastos.Fase_Nombre = UIHelper.GetString(ddlFase);
        }
        void ProyectoGastosRefresh()
        {
            var result = from s in Entity.Etapas where s.EsDeEjecucion == false orderby s.Fase_Orden, s.Etapa_Orden, s.IdProyectoEtapa select s;
            UIHelper.Load(gridGastos, result.ToList());
            upGridGastos.Update();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoGastosEdit()
        {
            ProyectoGastosSetValue();
            ModalPopupExtenderGastos.Show();
            upGastosPopUp.Update();
        }
        void CommandProyectoGastosSave()
        {

            ProyectoGastosGetValue();
            if (ActualProyectoGastos.Nombre != "")
            {
                ProyectoEtapaResult result = (from l in Entity.Etapas
                                              where l.IdProyectoEtapa == ActualProyectoGastos.ID
                                              select l).FirstOrDefault();
                if (result != null)
                {
                    result.Nombre = ActualProyectoGastos.Nombre;
                    result.IdEtapa = ActualProyectoGastos.IdEtapa;
                    result.Etapa_Nombre = ActualProyectoGastos.Etapa_Nombre;
                }
                else
                {
                    Entity.Etapas.Add(ActualProyectoGastos);
                }
                ProyectoGastosClear();
                ProyectoGastosRefresh();
            }
        }
        void CommandProyectoGastosDelete()
        {
            ProyectoEtapaResult result = (from l in Entity.Etapas where l.IdProyectoEtapa == ActualProyectoGastos.ID select l).FirstOrDefault();
            Entity.Etapas.Remove(result);
            ProyectoGastosClear();
            ProyectoGastosRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveGastos_Click(object sender, EventArgs e)
        {
            if (this.ddlFase.SelectedIndex == 0)
            {
                UIHelper.ShowAlert("Debe seleccionar una fase", upGastosPopUp);
                return;
            }
            else if (string.IsNullOrEmpty(this.tbDescripcion.Text))
            {
                UIHelper.ShowAlert("El campo descripción no puede ser vacio", upGastosPopUp);
                return;
            }

            CallTryMethod(CommandProyectoGastosSave);
            HidePopUpGastos();
        }
        protected void btNewGastos_Click(object sender, EventArgs e)
        {
            if (this.ddlFase.SelectedIndex == 0)
            {
                UIHelper.ShowAlert("Debe seleccionar una fase", upGastosPopUp);
                return;
            }
            else if (string.IsNullOrEmpty(this.tbDescripcion.Text))
            {
                UIHelper.ShowAlert("El campo descripción no puede ser vacio", upGastosPopUp);
                return;
            }

            CallTryMethod(CommandProyectoGastosSave);
        }
        protected void btCancelGastos_Click(object sender, EventArgs e)
        {
            ProyectoGastosClear();
            HidePopUpGastos();
        }
        protected void btAgregarGasto_Click(object sender, EventArgs e)
        {
            if (EtapasPlaneamiento.Where(et => et.IdEtapa == UIHelper.GetInt(ddlTipoEtapa)).Count() > 0)
            {
                tbDescripcion.Text = EtapasPlaneamiento.Where(et => et.IdEtapa == UIHelper.GetInt(ddlTipoEtapa)).SingleOrDefault().Nombre;
                tbDescripcion.Enabled = false;
            }
            else
                tbDescripcion.Enabled = true;

            ModalPopupExtenderGastos.Show();
        }

        protected void ddlTipoEtapa_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDescripcion();

        }

        private void ActualizarDescripcion()
        {
            if (EtapasPlaneamiento.Where(et => et.IdEtapa == UIHelper.GetInt(ddlTipoEtapa)).Count() > 0)
            {
                tbDescripcion.Text = EtapasPlaneamiento.Where(et => et.IdEtapa == UIHelper.GetInt(ddlTipoEtapa)).SingleOrDefault().Nombre;
                tbDescripcion.Enabled = false;
            }
            else
                tbDescripcion.Enabled = true;
        }
        protected void ddlFase_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarTipoEtapaYDescripcion();
        }

        private void BuscarTipoEtapaYDescripcion()
        {
            Int32 idFase = UIHelper.GetInt(ddlFase);
            if (idFase > 0)
            {
                if (!tbDescripcion.Enabled)
                    tbDescripcion.Text = "";
                ddlTipoEtapa.Enabled = true;

                nc.EtapaFilter etapaFilter = new nc.EtapaFilter() { IdFase = idFase, Activo = true };
                etapaFilter.FilterOrderBy = new FilterOrderBy { OrderByDesc = false, OrderByProperty = "Orden" };
                List<EtapaResult> etapas = EtapaService.Current.GetResultFromList(etapaFilter);
                UIHelper.Load<nc.EtapaResult>(ddlTipoEtapa, etapas, "Nombre", "IdEtapa", false);

                ddlTipoEtapa.SelectedIndex = 0;
                ActualizarDescripcion();
                //ddlTipoEtapa_OnSelectedIndexChanged(sender, e);
            }
            else
            {

                UIHelper.Load<nc.EtapaResult>(ddlTipoEtapa, new List<EtapaResult>(), "Nombre", "IdEtapa");
                ddlTipoEtapa.Enabled = false;
            }
        }
        #endregion

        #region EventosGrillas
        protected void GridGastos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoGastos = (from l in Entity.Etapas where l.IdProyectoEtapa == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoGastosEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoGastosDelete();
                    break;
            }
        }
        protected virtual void GridGastos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridGastos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridGastos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Gastos
    }
}