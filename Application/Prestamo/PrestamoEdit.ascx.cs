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
    public partial class PrestamoEdit : WebControlEdit<nc.PrestamoGeneralCompose>
    {
        #region General
        #region Override
        private OficinaResult actualOficina;
        protected OficinaResult ActualOficina
        {
            get
            {
                if (actualOficina == null)
                    if (ViewState["actualOficina"] != null)
                        actualOficina = ViewState["actualOficina"] as OficinaResult;
                    else
                    {
                        actualOficina = GetOficinaUsuario();
                        ViewState["actualOficina"] = actualOficina;
                    }
                return actualOficina;
            }
            set
            {
                actualOficina = value;
                ViewState["actualOficina"] = value;
            }
        }
		protected override void _Initialize()
        {
            base._Initialize();

            PopUpClasificaciones.Attributes.CssStyle.Add("display", "none");
            PopUpEstados.Attributes.CssStyle.Add("display", "none");
            PopUpOficinas.Attributes.CssStyle.Add("display", "none");


            revCodigoVinculacion.ValidationExpression = Contract.DataHelper.GetExpRegString(50);
            revCodigoVinculacion2.ValidationExpression = Contract.DataHelper.GetExpRegString(50);
            revResponsablePolitico.ValidationExpression = Contract.DataHelper.GetExpRegString(100);
            revResponsableTecnico.ValidationExpression = Contract.DataHelper.GetExpRegString(100);
            toOficinas.RequiredMessage = TranslateFormat("FieldIsNull", "Oficina");

            rfvSAF.ErrorMessage = TranslateFormat("FieldIsNull", "SAF");
            rfvPrograma.ErrorMessage = TranslateFormat("FieldIsNull", "Programa");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");
            revCodigoVinculacion.ErrorMessage = TranslateFormat("InvalidField", "Código Vinculación 1");
            revCodigoVinculacion2.ErrorMessage = TranslateFormat("InvalidField", "Código Vinculación 2");
            revResponsablePolitico.ErrorMessage = TranslateFormat("InvalidField", "Responsable Político");
            revResponsableTecnico.ErrorMessage = TranslateFormat("InvalidField", "Responsable Técnico");

            
            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            List<SafResult> lsr ;
            if (UIContext.Current.ContextUser.User.AccesoTotal || CrudAction != CrudActionEnum.Create)
                lsr = SafService.Current.GetResult(new nc.SafFilter() { Activo = true });
            else
                lsr = SafService.Current.GetResult(new nc.SafFilter() { Activo = true, IdSaf = ActualOficina.IdSaf });
            UIHelper.Load<nc.SafResult>(ddlSAF, lsr, "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt",typeof(Int32));

            UIHelper.SetValue(diFechaEstimada, DateTime.Now);
            diFechaEstimada.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha");
            diFechaEstimada.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");


          //  lblFechaHoy.Text = DateTime.Now.Date.ToShortDateString();
            UIHelper.Load<nc.EstadoResult>(ddlEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PRESTAMO, Activo = true, OrderByProperty = "Orden" }), "Nombre", "IdEstado", false);
		}
		public override void Clear()
        {
            UIHelper.Clear(ddlSAF);
			UIHelper.Clear(ddlPrograma);
            UIHelper.Clear(txtCodigoVinculacion1);
            UIHelper.Clear(txtCodigoVinculacion2);
            UIHelper.Clear(txtResponsablePolitico);
            UIHelper.Clear(txtResponsableTecnico);
			UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(txtDescripcion);
            UIHelper.Clear(txtObservaciones);
            UIHelper.Clear(toResponsable);
            if (CrudAction == CrudActionEnum.Create)
                UIHelper.SetValue(toResponsable, ActualOficina.IdOficina);
            UIHelper.Clear(dlFuncionarioResponsable);
        }		
		public override void SetValue()
        {
            if (Entity.Prestamo.Programa_IdSAF>0)
                UIHelper.SetValue<SafResult ,int>(ddlSAF, Entity.Prestamo.Programa_IdSAF,SafService.Current.GetResultById);
            CargarProgramas();

            UIHelper.SetValue(toResponsable, Entity.Responsable.IdOficina);



            UIHelper.SetValue(toResponsable, Entity.Responsable.IdOficina);
            UIHelper.SetValue(txtCodigoVinculacion1, Entity.Prestamo.CodigoVinculacion1);
            UIHelper.SetValue(txtCodigoVinculacion1, Entity.Prestamo.CodigoVinculacion1);
            UIHelper.SetValue(txtCodigoVinculacion2, Entity.Prestamo.CodigoVinculacion2);
            UIHelper.SetValue(txtResponsablePolitico, Entity.Prestamo.ResponsablePolitico);
            UIHelper.SetValue(txtResponsableTecnico, Entity.Prestamo.ResponsableTecnico);            
            UIHelper.SetValue(txtDenominacion, Entity.Prestamo.Denominacion);
            UIHelper.SetValue(txtDescripcion, Entity.Prestamo.Descripcion);
            UIHelper.SetValue(txtObservaciones, Entity.Prestamo.Observacion);

            UIHelper.Sort(Entity.Funcionarios, "Usuario_ApellidoYNombre", SortDirection.Ascending);
            UIHelper.SetValue(dlFuncionarioResponsable, Entity.Funcionarios);

            PrestamoEstadoRefresh();
            PrestamoOficinaRefresh();
            PrestamoClasificacionRefresh();
            upDescripcion.Update();
            upObservaciones.Update();

            ddlSAF.Enabled = CrudAction == CrudActionEnum.Create;
            ddlPrograma.Enabled = CrudAction == CrudActionEnum.Create && ddlPrograma.Items.Count > 0;

        }	
        public override void GetValue()
        {
			Entity.Prestamo.IdPrograma = UIHelper.GetInt(ddlPrograma);
            Entity.Prestamo.Programa_IdSAF = UIHelper.GetInt(ddlSAF);

            Entity.Prestamo.CodigoVinculacion1 = UIHelper.GetString(txtCodigoVinculacion1);
            Entity.Prestamo.CodigoVinculacion2 = UIHelper.GetString(txtCodigoVinculacion2);
            Entity.Prestamo.ResponsablePolitico = UIHelper.GetString(txtResponsablePolitico);
            Entity.Prestamo.ResponsableTecnico = UIHelper.GetString(txtResponsableTecnico);

            Entity.Prestamo.Denominacion = UIHelper.GetString(txtDenominacion);
            Entity.Prestamo.Descripcion = UIHelper.GetString(txtDescripcion);
            Entity.Prestamo.Observacion = UIHelper.GetString(txtObservaciones);
            if (CrudAction == CrudActionEnum.Create)
                Entity.Prestamo.FechaAlta = DateTime.Now;
            Entity.Prestamo.FechaModificacion = DateTime.Now;

            
            Entity.Responsable.OficinaNode = UIHelper.GetNodeResult(toResponsable);

            Update(dlFuncionarioResponsable, Entity.Funcionarios);
        }
        #endregion
        #region Events
        protected void ddlSaf_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarProgramas);
        }
        #endregion
        #region Private Methods
        private void CargarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            if (idSaf != 0)
            {
                UIHelper.Load<ProgramaResult>(ddlPrograma, ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo=true }), "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" },true,"CodigoInt" ,typeof(Int32));
                if (Entity.Prestamo.IdPrograma > 0)
                    UIHelper.SetValue<Programa,int>(ddlPrograma, Entity.Prestamo.IdPrograma, ProgramaService.Current.GetById);
                ddlPrograma.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlPrograma);
                ddlPrograma.Enabled = false;
            }
            ddlPrograma.Enabled = ddlPrograma.Items.Count > 0;
        }
        private OficinaResult GetOficinaUsuario()
        {
            return OficinaService.Current.GetResult(new nc.OficinaFilter() { IdOficina = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault();
        }
        protected void toResponsable_OnValueChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeOficinaResponsable);
        }

        private void ChangeOficinaResponsable()
        {

            //Entity.Responsable.IdPerfil = PerfilConfig.IdResponsablePrestamo;
            //Entity.Responsable.IdOficina = UIHelper.GetInt(toResponsable);
            //Entity.Funcionarios.Clear();
            //PrestamoComposeService.Current.ActualizarFuncionarios(Entity);
            //UIHelper.Clear(dlFuncionarioResponsable);
            //UIHelper.Sort(Entity.Funcionarios, "Usuario_NombreYApellido", SortDirection.Ascending);
            //UIHelper.SetValue(dlFuncionarioResponsable, Entity.Funcionarios);
            //upFuncionariosResponsablePopUp.Update();

            Entity.Funcionarios = PrestamoComposeService.Current.GetPrestamoOficinaPerfilFuncionarioResult(UIHelper.GetInt(toResponsable));
            UIHelper.SetValue(dlFuncionarioResponsable, Entity.Funcionarios.OrderBy(i => i.Usuario_ApellidoYNombre));
            upFuncionariosResponsablePopUp.Update();
        }

        private void Update(DataList dataList, List<PrestamoOficinaFuncionarioResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value;
                if (short.TryParse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value, out value))
                {
                    PrestamoOficinaFuncionarioResult item = (from o in list where o.IdUsuario == value select o).FirstOrDefault();
                    if (item == null) continue;
                    item.Selected = isChecked;
                }
            }
        }
        #endregion
        #endregion General 

        #region Estados
        private PrestamoEstadoResult actualPrestamoEstado;
        protected PrestamoEstadoResult ActualPrestamoEstado
        {
            get
            {
                if (actualPrestamoEstado == null)
                {
                    if (ExistsPersist("actualPrestamoEstado"))
                        actualPrestamoEstado = ((PrestamoEstadoResult)GetPersist("actualPrestamoEstado"));
                    else
                    {
                        actualPrestamoEstado = GetNewEstado();
                        SetPersist("actualPrestamoEstado", actualPrestamoEstado);
                    }
                }
                return actualPrestamoEstado;
            }
            set
            {
                actualPrestamoEstado = value;
                SetPersist("actualPrestamoEstado", value);
            }
        }
        PrestamoEstadoResult GetNewEstado()
        {
            int id = 0;
            if (Entity.Estados.Count > 0) id = Entity.Estados.Min(l => l.IdPrestamoEstado);
            if (id > 0) id = 0;
            id--;
            PrestamoEstadoResult plResult = new PrestamoEstadoResult();
            plResult.IdPrestamoEstado = id;
            plResult.IdPrestamo = Entity.Prestamo.IdPrestamo;
            return plResult;
        }

        #region Methods
        void HidePopUpEstados()
        {
            ModalPopupExtenderEstados.Hide();
        }
        void PrestamoEstadoClear()
        {
            UIHelper.Clear(ddlEstado);
            ActualPrestamoEstado = GetNewEstado();
        }
        void PrestamoEstadoSetValue()
        {
            UIHelper.SetValue(lblErrorEstado, "");
            PrestamoEstadoRefresh();
        }
        void PrestamoEstadoGetValue()
        {
            ActualPrestamoEstado.IdEstado = UIHelper.GetInt(ddlEstado);
            ActualPrestamoEstado.Estado_Nombre = ddlEstado.SelectedItem.Text;
            ActualPrestamoEstado.FechaEstimada = UIHelper.GetDateTime(diFechaEstimada);
            ActualPrestamoEstado.FechaRealizada = DateTime.Now;
        }
        void PrestamoEstadoRefresh()
        {
            UIHelper.Load(gridEstados, Entity.Estados, "Orden", SortDirection.Ascending, Type.GetType("System.DateTime"));
            upDatosGenerales.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoEstadoEdit()
        {
            //PrestamoEstadoSetValue();
            //ModalPopupExtenderEstados.Show();
            //upEstadosPopUp.Update();
        }
        void CommandPrestamoEstadoSave()
        {
            lblErrorEstado.Text = "";
            PrestamoEstadoGetValue();
            PrestamoEstadoResult result = (from l in Entity.Estados
                                           where l.IdEstado == ActualPrestamoEstado.IdEstado
                                           select l).FirstOrDefault();
            if (result != null)
            {
                lblErrorEstado.Text = SolutionContext.Current.TextManager.Translate("El estado ya ha sido utilizado");
                UIHelper.ShowAlert(lblErrorEstado.Text, upEstadosPopUp);
                upEstadosPopUp.Update();
            }
            else
            {
                Entity.Estados.Add(ActualPrestamoEstado);
                PrestamoEstadoClear();
                PrestamoEstadoRefresh();
            }
        }
        void CommandPrestamoEstadoDelete()
        {
            PrestamoEstadoResult result = (from l in Entity.Estados where l.IdPrestamoEstado == ActualPrestamoEstado.ID select l).FirstOrDefault();
            Entity.Estados.Remove(result);
            PrestamoEstadoClear();
            PrestamoEstadoRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveEstado_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEstado, "");
            CallTryMethod(CommandPrestamoEstadoSave);
            if (lblErrorEstado.Text == "")
                HidePopUpEstados();
        }
        protected void btNewEstado_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEstado, "");
            CallTryMethod(CommandPrestamoEstadoSave);
        }
        protected void btCancelEstado_Click(object sender, EventArgs e)
        {
            PrestamoEstadoClear();
            HidePopUpEstados();
        }
        protected void btAgregarEstado_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEstado, "");
            upEstadosPopUp.Update();
            ModalPopupExtenderEstados.Show();
        }
        #endregion

        #region EventosGrillas
        protected void GridEstados_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoEstado = (from l in Entity.Estados where l.IdPrestamoEstado == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoEstadoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoEstadoDelete();
                    break;
            }
        }
        protected virtual void GridEstados_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridEstados.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridEstados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridEstados.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion
        #endregion Estados

        #region Oficina

        private PrestamoOficinaPerfilResult actualPrestamoOficinaPerfil;
        protected PrestamoOficinaPerfilResult ActualPrestamoOficinaPerfil
        {
            get
            {
                if (actualPrestamoOficinaPerfil == null)
                {
                    if (ExistsPersist("actualPrestamoOficinaPerfil"))
                        actualPrestamoOficinaPerfil = ((PrestamoOficinaPerfilResult)GetPersist("actualPrestamoOficinaPerfil"));
                    else
                    {
                        actualPrestamoOficinaPerfil = GetNewOficina();
                        SetPersist("actualPrestamoOficinaPerfil", actualPrestamoOficinaPerfil);
                    }
                }
                return actualPrestamoOficinaPerfil;
            }
            set
            {
                actualPrestamoOficinaPerfil = value;
                SetPersist("actualPrestamoOficinaPerfil", value);
            }
        }
        PrestamoOficinaPerfilResult GetNewOficina()
        {
            int id = 0;
            if (Entity.OficinasSinResponsable.Count > 0) id = Entity.OficinasSinResponsable.Min(l => l.IdPrestamoOficinaPerfil);
            if (id > 0) id = 0;
            id--;
            PrestamoOficinaPerfilResult plResult = new PrestamoOficinaPerfilResult();
            plResult.IdPrestamoOficinaPerfil = id;
            plResult.IdPrestamo = Entity.Prestamo.IdPrestamo;
            plResult.IdPerfil = PerfilConfig.IdAsociado;
            return plResult;
        }

        #region Methods
        void HidePopUpOficinas()
        {
            ModalPopupExtenderOficinas.Hide();
        }
        void PrestamoOficinaClear()
        {
            UIHelper.Clear(toOficinas);
            ActualPrestamoOficinaPerfil = GetNewOficina();
        }
        void PrestamoOficinaSetValue()
        {
            UIHelper.SetValue(toOficinas, ActualPrestamoOficinaPerfil.IdOficina);
            PrestamoOficinaRefresh();
        }
        void PrestamoOficinaGetValue()
        {
            ActualPrestamoOficinaPerfil.IdOficina = UIHelper.GetInt(toOficinas);
            Oficina o = OficinaService.Current.GetById(ActualPrestamoOficinaPerfil.IdOficina);
            if (o != null)
            {
                ActualPrestamoOficinaPerfil.Oficina_BreadcrumbCode = o.BreadcrumbCode;
                ActualPrestamoOficinaPerfil.Oficina_Descripcion = o.Descripcion;
                actualPrestamoOficinaPerfil.Oficina_DescripcionInvertida = o.DescripcionInvertida;
            }
        }
        void PrestamoOficinaRefresh()
        {
            UIHelper.Load(gridOficinas, Entity.OficinasSinResponsable, "Orden", SortDirection.Ascending);
            upGridOficinas.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoOficinaEdit()
        {
            PrestamoOficinaSetValue();
            ModalPopupExtenderOficinas.Show();
            upOficinasPopUp.Update();
        }
        void CommandPrestamoOficinaSave()
        {
            PrestamoOficinaGetValue();
            PrestamoOficinaPerfilResult result = (from l in Entity.OficinasSinResponsable
                                                  where l.IdPrestamoOficinaPerfil == ActualPrestamoOficinaPerfil.IdPrestamoOficinaPerfil
                                                  select l).FirstOrDefault();

            if (ActualPrestamoOficinaPerfil.Oficina_Descripcion != null)
            {
                if (result != null)
                {
                    result.IdOficina = ActualPrestamoOficinaPerfil.IdOficina;
                }
                else
                {
                    Entity.Oficinas.Add(ActualPrestamoOficinaPerfil);
                }
                PrestamoOficinaClear();
                PrestamoOficinaRefresh();
            }
        }
        void CommandPrestamoOficinaDelete()
        {
            PrestamoOficinaPerfilResult result = (from l in Entity.Oficinas 
                                                  where l.IdPrestamoOficinaPerfil == ActualPrestamoOficinaPerfil.IdPrestamoOficinaPerfil 
                                                  select l).FirstOrDefault();
            Entity.Oficinas.Remove(result);
            PrestamoOficinaClear();
            PrestamoOficinaRefresh();
        }
        #endregion

        #region Eventos

        protected bool ValidateOficina()
        {

            int oficina = UIHelper.GetInt(toOficinas);
            if (oficina > 0)
            {
                    List<PrestamoOficinaPerfilResult> popf = Entity.OficinasSinResponsable.Where( p => p.IdOficina == oficina).ToList();
                if (ActualPrestamoOficinaPerfil.ID < 0)
                {
                    if (popf != null && popf.Count == 1)
                    {
                        UIHelper.ShowAlert("La oficina ya existe en la lista.", upOficinasPopUp);
                        return false;
                    }
                }
                else
                {
                    if (popf != null && popf.Count == 1 && ActualPrestamoOficinaPerfil.ID != popf.FirstOrDefault().ID)
                    {
                        UIHelper.ShowAlert("La oficina ya existe en la lista.", upOficinasPopUp);
                        return false;
                    }

                   

                }
            }
            return true;
        }

        protected void btSaveOficina_Click(object sender, EventArgs e)
        {

            if (ValidateOficina())
            {
                CallTryMethod(CommandPrestamoOficinaSave);
                HidePopUpOficinas();
            }
        }
        protected void btNewOficina_Click(object sender, EventArgs e)
        {
            if (ValidateOficina())
            {
                CallTryMethod(CommandPrestamoOficinaSave);
            }
        }
        protected void btCancelOficina_Click(object sender, EventArgs e)
        {
            PrestamoOficinaClear();
            HidePopUpOficinas();
        }
        protected void btAgregarOficina_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderOficinas.Show();
        }
        #endregion

        #region EventosGrillas

        protected void GridOficinas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoOficinaPerfil = (from l in Entity.OficinasSinResponsable where l.IdPrestamoOficinaPerfil == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoOficinaEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoOficinaDelete();
                    break;
            }
        }
        protected virtual void GridOficinas_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridOficinas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridOficinas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion Oficina

        #region Clasificacion

        private PrestamoFinalidadFuncionResult actualPrestamoFinalidadFuncionResult;
        protected PrestamoFinalidadFuncionResult ActualPrestamoFinalidadFuncionResult
        {
            get
            {
                if (actualPrestamoFinalidadFuncionResult == null)
                {
                    if (ExistsPersist("actualPrestamoFinalidadFuncionResult"))
                        actualPrestamoFinalidadFuncionResult = ((PrestamoFinalidadFuncionResult)GetPersist("actualPrestamoFinalidadFuncionResult"));
                    else
                    {
                        actualPrestamoFinalidadFuncionResult = GetNewClasificacion();
                        SetPersist("actualPrestamoFinalidadFuncionResult", actualPrestamoFinalidadFuncionResult);
                    }
                }
                return actualPrestamoFinalidadFuncionResult;
            }
            set
            {
                actualPrestamoFinalidadFuncionResult = value;
                SetPersist("actualPrestamoFinalidadFuncionResult", value);
            }
        }
        PrestamoFinalidadFuncionResult GetNewClasificacion()
        {
            int id = 0;
            if (Entity.Clasificaciones.Count > 0) id = Entity.Clasificaciones.Min(l => l.IdPrestamoFinalidadFuncion);
            if (id > 0) id = 0;
            id--;
            PrestamoFinalidadFuncionResult plResult = new PrestamoFinalidadFuncionResult();
            plResult.IdPrestamoFinalidadFuncion = id;
            plResult.IdPrestamo = Entity.Prestamo.IdPrestamo;
            return plResult;
        }

        #region Methods
        void HidePopUpClasificaciones()
        {
            ModalPopupExtenderClasificaciones.Hide();
        }
        void PrestamoClasificacionClear()
        {
            UIHelper.Clear(toFinalidad);
            ActualPrestamoFinalidadFuncionResult = GetNewClasificacion();
        }
        void PrestamoClasificacioneSetValue()
        {
            UIHelper.SetValue(toFinalidad, ActualPrestamoFinalidadFuncionResult.IdFinalidadFuncion);
            PrestamoClasificacionRefresh();
        }
        void PrestamoClasificacionGetValue()
        {
            ActualPrestamoFinalidadFuncionResult.IdFinalidadFuncion = UIHelper.GetInt(toFinalidad);
            FinalidadFuncion ff = FinalidadFuncionService.Current.GetById(ActualPrestamoFinalidadFuncionResult.IdFinalidadFuncion);
            if (ff != null)
            {
                ActualPrestamoFinalidadFuncionResult.FinalidadFuncion_BreadcrumbCode = ff.BreadcrumbCode;
                ActualPrestamoFinalidadFuncionResult.FinalidadFuncion_Descripcion = ff.Descripcion;
            }
        }
        void PrestamoClasificacionRefresh()
        {
            UIHelper.Load(gridClasificaciones, Entity.Clasificaciones, "Orden");
            upGridClasificaciones.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoClasificacionEdit()
        {
            PrestamoClasificacioneSetValue();
            ModalPopupExtenderClasificaciones.Show();
            upClasificacionesPopUp.Update();
        }
        void CommandPrestamoClasificacionesave()
        {
            PrestamoClasificacionGetValue();
            PrestamoFinalidadFuncionResult result = (from l in Entity.Clasificaciones
                                                           where l.IdPrestamoFinalidadFuncion == ActualPrestamoFinalidadFuncionResult.IdPrestamoFinalidadFuncion
                                                           select l).FirstOrDefault();

            if (ActualPrestamoFinalidadFuncionResult.FinalidadFuncion_Descripcion != null)
            {
                if (result != null)
                {
                    result.IdFinalidadFuncion = ActualPrestamoFinalidadFuncionResult.IdFinalidadFuncion;
                }
                else
                {
                    Entity.Clasificaciones.Add(ActualPrestamoFinalidadFuncionResult);
                }
                PrestamoClasificacionClear();
                PrestamoClasificacionRefresh();
            }
        }
        void CommandPrestamoClasificacionDelete()
        {
            PrestamoFinalidadFuncionResult result = (from l in Entity.Clasificaciones
                                                           where l.IdPrestamoFinalidadFuncion == ActualPrestamoFinalidadFuncionResult.IdPrestamoFinalidadFuncion
                                                           select l).FirstOrDefault();
            Entity.Clasificaciones.Remove(result);
            PrestamoClasificacionClear();
            PrestamoClasificacionRefresh();
        }
        protected bool ValidateClasificacion()
        {
            int IdFinalidadFuncion = UIHelper.GetInt(toFinalidad);
            if (IdFinalidadFuncion > 0)
            {
                List<PrestamoFinalidadFuncionResult> ffr = Entity.Clasificaciones.Where(p => p.IdFinalidadFuncion == IdFinalidadFuncion).ToList();
                if (ActualPrestamoFinalidadFuncionResult.ID < 0)
                {
                    if (ffr != null && ffr.Count == 1)
                    {
                        UIHelper.ShowAlert("La clasificación ya existe en la lista.", upClasificacionesPopUp);
                        return false;
                    }
                }
                else
                {
                    if (ffr != null && ffr.Count == 1 && ActualPrestamoFinalidadFuncionResult.ID != ffr.FirstOrDefault().ID)
                    {
                        UIHelper.ShowAlert("La clasificación ya existe en la lista.", upClasificacionesPopUp);
                        return false;
                    }

                }
            }
            return true;
        }
        #endregion

        #region Eventos
        protected void btSaveClasificacion_Click(object sender, EventArgs e)
        {

            if (ValidateClasificacion())
            {
                CallTryMethod(CommandPrestamoClasificacionesave);
                HidePopUpClasificaciones();
            }

        }
        protected void btNewClasificacion_Click(object sender, EventArgs e)
        {
            if (ValidateClasificacion())
            {
                CallTryMethod(CommandPrestamoClasificacionesave);
            }
        }
        protected void btCancelClasificacion_Click(object sender, EventArgs e)
        {
            PrestamoClasificacionClear();
            HidePopUpClasificaciones();
        }
        protected void btAgregarClasificacion_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderClasificaciones.Show();
        }
        #endregion

        #region EventosGrillas

        protected void GridClasificaciones_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoFinalidadFuncionResult = (from l in Entity.Clasificaciones where l.IdPrestamoFinalidadFuncion == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoClasificacionEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoClasificacionDelete();
                    break;
            }
        }
        protected virtual void GridClasificaciones_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridClasificaciones.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridClasificaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridClasificaciones.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion Clasificacion

        #region Funcionarios
        protected void funcionarios_Click(object sender, EventArgs e)
        {
            if(UIHelper.GetNodeResult(toResponsable) != null)
                ModalPopupExtenderFuncionariosResponsable.Show();
        }
        protected void btCancelFuncionarios_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosResponsable.Hide();
        }
        #endregion 
    }
}
