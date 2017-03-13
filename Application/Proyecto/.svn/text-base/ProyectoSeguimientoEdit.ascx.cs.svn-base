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
    public partial class ProyectoSeguimientoEdit : WebControlEdit<nc.ProyectoSeguimientoCompose>
    {

        #region Override
        protected override void _Initialize()
        {
            base._Initialize();

            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revRuta.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revMalla.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);

            rfvEstadoPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            rfvUsuarioPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Usuario");
            rfvAnalista.ErrorMessage = TranslateFormat("FieldIsNull", "Analista");
            rfvBapin.ErrorMessage = TranslateFormat("FieldIsNull", "Bapin");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");
            rfvSaf.ErrorMessage = TranslateFormat("FieldIsNull", "Saf");
            revBapin.ErrorMessage = TranslateFormat("InvalidField", "Bapin");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominacion");
            revMalla.ErrorMessage = TranslateFormat("InvalidField", "Malla");
            revRuta.ErrorMessage = TranslateFormat("InvalidField", "Ruta");



            UIHelper.Load<SafResult>(ddlSaf, SafService.Current.GetResult(new nc.SafFilter() { Activo = true }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Denominacion = "Seleccione Saf" });
            UIHelper.Load<UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            UIHelper.Load<Estado>(ddlEstadoPopUpEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_SEGUIMIENTO_ESTADO, Activo = true }), "Nombre", "IdEstado", new Estado() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });

            PopUpProyectoSeguimientoProyecto.Attributes.CssStyle.Add("display", "none");
            PopUpEstados.Attributes.CssStyle.Add("display", "none");
        }
        public override void Clear()
        {
            UIHelper.Clear(ddlSaf);
            UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(txtRuta);
            UIHelper.Clear(txtMalla);
            UIHelper.Clear(ddlAnalista);
            UIHelper.Clear(dlProvincias);
            UIHelper.Clear(lbUsuario);
            UIHelper.Clear(lbEstadoSituacion);
            UIHelper.Clear(diFechaEstado);
            UIHelper.Clear(txtObservacionEstado);
        }
        public override void SetValue()
        {
            UIHelper.SetValue<Saf, int>(ddlSaf, Entity.ProyectoSeguimiento.IdSaf, SafService.Current.GetById);
            UIHelper.SetValue(txtDenominacion, Entity.ProyectoSeguimiento.Denominacion);
            UIHelper.SetValue(txtRuta, Entity.ProyectoSeguimiento.Ruta);
            UIHelper.SetValue(txtMalla, Entity.ProyectoSeguimiento.Malla);
            UIHelper.SetValue<UsuarioResult, int>(ddlAnalista, Entity.ProyectoSeguimiento.IdAnalista, UsuarioService.Current.GetResultById);
            upDatosGenerales.Update();
            RefreshProvincias();
            ProyectoSeguimientoEstadoRefresh();
            ProyectoSeguimientoProyectoRefresh();
        }
        public override void GetValue()
        {
            Entity.ProyectoSeguimiento.IdSaf = UIHelper.GetInt(ddlSaf);
            Entity.ProyectoSeguimiento.Denominacion = UIHelper.GetString(txtDenominacion);
            Entity.ProyectoSeguimiento.Ruta = UIHelper.GetString(txtRuta);
            Entity.ProyectoSeguimiento.Malla = UIHelper.GetString(txtMalla);
            Entity.ProyectoSeguimiento.IdAnalista = UIHelper.GetInt(ddlAnalista);
            Update(dlProvincias, Entity.ProyectoSeguimientoLocalizacion);
        }
        #endregion
        #region Events
        protected void btBuscarProyectoSeguimientoAnterior_Click(object sender, EventArgs e)
        {
            CallTryMethod(BuscarProyectoSeguimientoAnterior);
        }
        #endregion
        #region Private Functions
        private void BuscarProyectoSeguimientoAnterior()
        {
            Int32 idProyectoSeguimientoAnterior = UIHelper.GetInt(txtProyectoSeguimientoAnterior);
            if (idProyectoSeguimientoAnterior == 0) return;
            ProyectoSeguimientoResult psr = ProyectoSeguimientoService.Current.GetResult(new nc.ProyectoSeguimientoFilter() { IdProyectoSeguimiento = idProyectoSeguimientoAnterior }).SingleOrDefault();
            if (psr == null) return;
            Entity.ProyectoSeguimiento.IdProyectoSeguimientoAnterior = psr.IdProyectoSeguimiento;
            Entity.ProyectoSeguimiento.ProyectoSeguimientoAnterior_Denominacion = psr.Denominacion;
            UIHelper.SetValue(lbDenominacionEvaluacion, Entity.ProyectoSeguimiento.ProyectoSeguimientoAnterior_Denominacion);
        }
        private void RefreshProvincias()
        {
            UIHelper.Sort<ProyectoSeguimientoLocalizacionResult>(Entity.ProyectoSeguimientoLocalizacion, "CalificacionGeografica_Nombre");
            UIHelper.SetValue(dlProvincias, Entity.ProyectoSeguimientoLocalizacion);
        }
        private void CheckearProvincias()
        {
            if (Entity.ProyectoSeguimientoProyecto.Count == 0) return;
            List<ProyectoLocalizacion> pl = ProyectoLocalizacionService.Current.GetList(new nc.ProyectoLocalizacionFilter() { IdsProyecto = Entity.ProyectoSeguimientoProyecto.Select(i => i.IdProyecto).ToList() });
            (
               from o in Entity.ProyectoSeguimientoLocalizacion
               where pl.Select(i => i.IdClasificacionGeografica).Contains(o.IdCalificacionGeografica)
               select o
            ).Each(i => i.Selected = true);
            RefreshProvincias();
        }
        private void Update(DataList dataList, List<ProyectoSeguimientoLocalizacionResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                short value = short.Parse(((HiddenField)dataList.Items[i].FindControl("hdValue")).Value);
                ProyectoSeguimientoLocalizacionResult item = (from o in list where o.IdCalificacionGeografica == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }

        #endregion
        #region ProyectoSeguimientoProyecto
        private ProyectoSeguimientoProyectoResult actualProyectoSeguimientoProyecto;
        protected ProyectoSeguimientoProyectoResult ActualProyectoSeguimientoProyecto
        {
            get
            {
                if (actualProyectoSeguimientoProyecto == null)
                    if (ViewState["actualProyectoSeguimientoProyecto"] != null)
                        actualProyectoSeguimientoProyecto = ViewState["actualProyectoSeguimientoProyecto"] as ProyectoSeguimientoProyectoResult;
                    else
                    {
                        actualProyectoSeguimientoProyecto = GetNewProyectoSeguimientoProyecto();
                        ViewState["actualProyectoSeguimientoProyecto"] = actualProyectoSeguimientoProyecto;
                    }
                return actualProyectoSeguimientoProyecto;
            }
            set
            {
                actualProyectoSeguimientoProyecto = value;
                ViewState["actualProyectoSeguimientoProyecto"] = value;
            }
        }
        ProyectoSeguimientoProyectoResult GetNewProyectoSeguimientoProyecto()
        {
            int id = 0;
            if (Entity.ProyectoSeguimientoProyecto.Count > 0) id = Entity.ProyectoSeguimientoProyecto.Min(o => o.IdProyectoSeguimientoProyecto);
            if (id > 0) id = 0;
            id--;
            ProyectoSeguimientoProyectoResult uopResult = new ProyectoSeguimientoProyectoResult();
            ProyectoSeguimientoProyectoService.Current.Set(ProyectoSeguimientoProyectoService.Current.GetNew(), uopResult);
            uopResult.IdProyectoSeguimientoProyecto = id;
            return uopResult;
        }
        void HidePopUpProyectoSeguimientoProyecto()
        {
            ModalPopupExtenderProyectoSeguimientoProyecto.Hide();
        }
        void ShowPopUpProyectoSeguimientoProyecto()
        {
            ModalPopupExtenderProyectoSeguimientoProyecto.Show();
            upProyectoSeguimientoProyectoPopUp.Update();
        }
        private bool _buscarBapin; //Matias        
        void BuscarBapin()
        {
            _buscarBapin = false;
            Int32 NroBapin = UIHelper.GetInt(txtBapinProyecto);
            
            if (NroBapin == 0)
            {
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Bapin válido"), upProyectoSeguimientoProyectoPopUp );
                return;
                //throw new ValidationException("Debe ingresar un Nro Bapin válido");
            }

            ProyectoResult Proyecto = ProyectoService.Current.GetResult(new nc.ProyectoFilter() { Codigo = NroBapin }).FirstOrDefault();
            if (Proyecto == null)
            {
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Bapin válido"), upProyectoSeguimientoProyectoPopUp);
                return;
                //throw new ValidationException("Debe ingresar un Nro Bapin válido");
            }

            //Matias 20170124 - Ticket #ER382869
            if (!Proyecto.Activo)
            {
                UIHelper.ShowAlert(Translate("El Nro Bapin ingresado corresponde a un Proyecto inactivo"), upProyectoSeguimientoProyectoPopUp);
                return;
                //throw new ValidationException("El Nro Bapin ingresado corresponde a un Proyecto inactivo");
            }
            //FinMatias 20170124 - Ticket #ER382869
            
            UIHelper.SetValue(lbDenominacionProyecto, Proyecto.ProyectoDenominacion);
            ActualProyectoSeguimientoProyecto.IdProyecto = Proyecto.IdProyecto;
            ActualProyectoSeguimientoProyecto.Proyecto_ProyectoDenominacion = Proyecto.ProyectoDenominacion;
            ActualProyectoSeguimientoProyecto.Proyecto_Codigo = Proyecto.Codigo;

            _buscarBapin = true;

        }

        #region EventosGrillas

        protected void GridProyectos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoSeguimientoProyecto = (from o in Entity.ProyectoSeguimientoProyecto where o.IdProyectoSeguimientoProyecto == id select o).FirstOrDefault();
            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoSeguimientoProyectoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoSeguimientoProyectoDelete();
                    break;
            }
        }
        protected virtual void GridProyectos_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridProyectos.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridProyectos.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyecto_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoSeguimientoProyectoSave);
        }
        protected void btNewProyecto_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoSeguimientoProyectoSave);
        }
        protected void btCancelProyecto_Click(object sender, EventArgs e)
        {
            ProyectoSeguimientoProyectoClear();
            HidePopUpProyectoSeguimientoProyecto();
        }
        protected void btAgregarProyecto_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpProyectoSeguimientoProyecto);
        }
        protected void txtBapinProyecto_TextChanged(object sender, EventArgs e)
        {
            CallTryMethod(BuscarBapin);
        }

        #endregion
        #region Commands
        void CommandProyectoSeguimientoProyectoEdit()
        {
            ProyectoSeguimientoProyectoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoSeguimientoProyecto);
        }
        void CommandProyectoSeguimientoProyectoSave()
        {
            const string mensajeValidacion = "El proyecto ingresado ya fue agregado con anterioridad";
            
            ProyectoSeguimientoProyectoGetValue();
            if (_buscarBapin)
            {
                ProyectoSeguimientoProyectoResult result = (from o in Entity.ProyectoSeguimientoProyecto where o.IdProyectoSeguimientoProyecto == ActualProyectoSeguimientoProyecto.ID select o).FirstOrDefault();
                if (result != null)
                {
                    if (existeProyectoEnGrilla(result.Proyecto_Codigo))
                    {
                        UIHelper.ShowAlert(mensajeValidacion, upProyectoSeguimientoProyectoPopUp.Page);
                        upDatosGenerales.Update();
                        return;
                    }
                    // actualizo el saf, la denominacion y las provincias
                    actualizarSafDenominacionProvincia(result.IdProyecto, actualProyectoSeguimientoProyecto.Proyecto_ProyectoDenominacion);

                    result.IdProyecto = ActualProyectoSeguimientoProyecto.IdProyecto;
                    result.Proyecto_Codigo = ActualProyectoSeguimientoProyecto.Proyecto_Codigo;
                    result.Proyecto_ProyectoDenominacion = ActualProyectoSeguimientoProyecto.Proyecto_ProyectoDenominacion;
                }
                else
                {
                    if (existeProyectoEnGrilla(actualProyectoSeguimientoProyecto.Proyecto_Codigo))
                    {
                        UIHelper.ShowAlert(mensajeValidacion, upProyectoSeguimientoProyectoPopUp.Page);
                        upDatosGenerales.Update();
                        return;
                    }
                    // Actualizo el saf , la denominacion y las provincias
                    actualizarSafDenominacionProvincia(actualProyectoSeguimientoProyecto.IdProyecto, actualProyectoSeguimientoProyecto.Proyecto_ProyectoDenominacion);
                    Entity.ProyectoSeguimientoProyecto.Add(ActualProyectoSeguimientoProyecto);
                }

                ProyectoSeguimientoProyectoClear();
                //CheckearProvincias(); Esto se comenta porque se van a tildar las provincias con el primer bapin cargado
                ProyectoSeguimientoProyectoRefresh();
                HidePopUpProyectoSeguimientoProyecto();
            }

        }

        void actualizarSafDenominacionProvincia(int idProyecto, string denominacion, bool resetDenominacion = false)
        {

            // Obtener SAF
            // con el id del proyecto, buscar el proyecto
            Contract.ProyectoFilter filtro = new Contract.ProyectoFilter();
            filtro.IdProyecto = idProyecto;
            ProyectoResult proyecto = ProyectoService.Current.GetProyecto(filtro);

            // luego con el proyecto obtengo el saf y lo seteo en el combo saf
            if (proyecto != null)
            {

                if (this.GridProyectos.Rows.Count == 0)
                {
                    // Seteo el id del sf en el combo saf
                    ddlSaf.SelectedValue = proyecto.IdSAF.ToString();
                }

                if (resetDenominacion)
                {
                    txtDenominacion.Text = denominacion;
                }
                else
                {
                    // Obtener Denominacion
                    if (txtDenominacion.Text == string.Empty)
                        txtDenominacion.Text += denominacion;
                    else
                        if (GridProyectos.Rows.Count > 0)
                            txtDenominacion.Text += " | " + denominacion;
                        else
                            txtDenominacion.Text = denominacion;


                    // Obtener provincias
                    ProyectoLocalizacionFilter filtroLocalizacion = new ProyectoLocalizacionFilter();
                    filtroLocalizacion.IdProyecto = idProyecto;

                    // con el id del proyecto, buscar el proyectoLocalizacion
                    // con el idClasificacionGeografica de este objeto, obtener el objeto clasificacionGeografica (este objeto tiene el campo idClasificacionGeograficaTipo que es lo que nos sirve para saber si es provincia o no)
                    // el tipo 1 es de provincias
                    List<ProyectoLocalizacion> localizaciones = ProyectoLocalizacionService.Current.GetList(filtroLocalizacion).ToList();

                    foreach (ProyectoLocalizacion loc in localizaciones)
                    {
                        foreach (Control controlProvincia in this.dlProvincias.Controls)
                        {
                            foreach (Control controlCheckBox in controlProvincia.Controls)
                            {
                                if (controlCheckBox is CheckBox)
                                {
                                    CheckBox chkProvincia = (CheckBox)controlCheckBox;
                                    string[] clasificacionGeog = loc.ClasificacionGeografica.Descripcion.Split('/');

                                    if (string.Compare(clasificacionGeog[0].Trim(), chkProvincia.Text.Trim(), true) == 0)
                                        chkProvincia.Checked = true;
                                }
                            }
                        }
                    }
                }

                // Actualizo el panel de datos generales para que tome los cambios que estoy haciendo
                upDatosGenerales.Update();


            }

        }

        void blanquearProvincias()
        {
            foreach (Control controlProvincia in this.dlProvincias.Controls)
            {
                foreach (Control controlCheckBox in controlProvincia.Controls)
                {
                    if (controlCheckBox is CheckBox)
                        ((CheckBox)controlCheckBox).Checked = false;
                }
            }
        }

        bool existeProyectoEnGrilla(int codigoProyecto)
        {
            foreach (GridViewRow row in GridProyectos.Rows)
            {
                if (string.Compare(row.Cells[0].Text, codigoProyecto.ToString(), true) == 0)
                {

                    return true;
                }
            }
            return false;
        }

        void CommandProyectoSeguimientoProyectoDelete()
        {
            ProyectoSeguimientoProyectoResult result = (from o in Entity.ProyectoSeguimientoProyecto where o.IdProyectoSeguimientoProyecto == ActualProyectoSeguimientoProyecto.ID select o).FirstOrDefault();
            Entity.ProyectoSeguimientoProyecto.Remove(result);
            ProyectoSeguimientoProyectoClear();
            ProyectoSeguimientoProyectoRefresh();
            if (GridProyectos.Rows.Count == 0)
            {
                this.blanquearProvincias();
                this.actualizarSafDenominacionProvincia(result.IdProyecto, result.Proyecto_ProyectoDenominacion, true);
            }
        }
        #endregion

        #region Clear SetValue GetValue Refresh
        void ProyectoSeguimientoProyectoClear()
        {
            UIHelper.Clear(txtBapinProyecto);
            UIHelper.Clear(lbDenominacionProyecto);
            ActualProyectoSeguimientoProyecto = GetNewProyectoSeguimientoProyecto();
        }
        void ProyectoSeguimientoProyectoSetValue()
        {
            UIHelper.SetValue(txtBapinProyecto, ActualProyectoSeguimientoProyecto.Proyecto_Codigo);
            UIHelper.SetValue(lbDenominacionProyecto, ActualProyectoSeguimientoProyecto.Proyecto_ProyectoDenominacion);
        }
        void ProyectoSeguimientoProyectoGetValue()
        {
            BuscarBapin();
        }
        void ProyectoSeguimientoProyectoRefresh()
        {
            UIHelper.Load(GridProyectos, Entity.ProyectoSeguimientoProyecto);
            upGridProyectos.Update();
        }
        #endregion
        #endregion
        #region Estados
        private ProyectoSeguimientoEstadoResult actualProyectoSeguimientoEstado;
        protected ProyectoSeguimientoEstadoResult ActualProyectoSeguimientoEstado
        {
            get
            {
                if (actualProyectoSeguimientoEstado == null)
                    if (ViewState["actualProyectoSeguimientoEstado"] != null)
                        actualProyectoSeguimientoEstado = ViewState["actualProyectoSeguimientoEstado"] as ProyectoSeguimientoEstadoResult;
                    else
                    {
                        actualProyectoSeguimientoEstado = GetNewProyectoSeguimientoEstado();
                        ViewState["actualProyectoSeguimientoEstado"] = actualProyectoSeguimientoEstado;
                    }
                return actualProyectoSeguimientoEstado;
            }
            set
            {
                actualProyectoSeguimientoEstado = value;
                ViewState["actualProyectoSeguimientoEstado"] = value;
            }
        }
        ProyectoSeguimientoEstadoResult GetNewProyectoSeguimientoEstado()
        {
            int id = 0;
            if (Entity.ProyectoSeguimientoEstado.Count > 0) id = Entity.ProyectoSeguimientoEstado.Min(o => o.IdProyectoSeguimientoEstado);
            if (id > 0) id = 0;
            id--;
            ProyectoSeguimientoEstadoResult uopResult = new ProyectoSeguimientoEstadoResult();
            ProyectoSeguimientoEstadoService.Current.Set(ProyectoSeguimientoEstadoService.Current.GetNew(), uopResult);
            uopResult.IdProyectoSeguimientoEstado = id;
            return uopResult;
        }
        void HidePopUpEstados()
        {
            ModalPopupExtenderEstados.Hide();
        }
        void ShowPopUpEstados()
        {
            ModalPopupExtenderEstados.Show();
            ProyectoSeguimientoEstadoClear();
            upEstadosPopUp.Update();
        }
        #region EventosGrillas

        protected void GridRoles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoSeguimientoEstado = (from o in Entity.ProyectoSeguimientoEstado where o.IdProyectoSeguimientoEstado == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoSeguimientoEstadoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoSeguimientoEstadoDelete();
                    break;
            }

        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //gridRoles.PageIndex = 0;
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
                //gridRoles.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveEstados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoSeguimientoEstadoSave);
            HidePopUpEstados();
        }
        protected void btNewEstados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoSeguimientoEstadoSave);
        }
        protected void btCancelEstados_Click(object sender, EventArgs e)
        {
            ProyectoSeguimientoEstadoClear();
            HidePopUpEstados();
        }
        protected void btAgregarEstado_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        #endregion
        #region Commands
        void CommandProyectoSeguimientoEstadoEdit()
        {
            ProyectoSeguimientoEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        void CommandProyectoSeguimientoEstadoSave()
        {
            ProyectoSeguimientoEstadoGetValue();
            ProyectoSeguimientoEstadoResult result = (from o in Entity.ProyectoSeguimientoEstado where o.IdProyectoSeguimientoEstado == ActualProyectoSeguimientoEstado.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.IdEstado = ActualProyectoSeguimientoEstado.IdEstado;
                result.Estado_Nombre = ActualProyectoSeguimientoEstado.Estado_Nombre;
                result.Fecha = ActualProyectoSeguimientoEstado.Fecha;
                result.Observacion = ActualProyectoSeguimientoEstado.Observacion;
                result.IdUsuario = ActualProyectoSeguimientoEstado.IdUsuario;
                result.Usuario_NombreUsuario = ActualProyectoSeguimientoEstado.Usuario_NombreUsuario;
                result.Persona_Apellido = ActualProyectoSeguimientoEstado.Persona_Apellido;
                result.Persona_Nombre = ActualProyectoSeguimientoEstado.Persona_Nombre;

            }
            else
            {
                Entity.ProyectoSeguimientoEstado.Add(ActualProyectoSeguimientoEstado);
            }
            Entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = null;
            ProyectoSeguimientoEstadoClear();
            ProyectoSeguimientoEstadoRefresh();
        }
        void CommandProyectoSeguimientoEstadoDelete()
        {
            ProyectoSeguimientoEstadoResult result = (from o in Entity.ProyectoSeguimientoEstado where o.IdProyectoSeguimientoEstado == ActualProyectoSeguimientoEstado.ID select o).FirstOrDefault();
            Entity.ProyectoSeguimientoEstado.Remove(result);
            ProyectoSeguimientoEstadoClear();
            ProyectoSeguimientoEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoSeguimientoEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentario);
            UIHelper.Clear(chkGeneraComentarioTecnico);
            UIHelper.Clear(chkEnviaMensaje);
            UIHelper.SetValue(diFechaPopUpEstado, DateTime.Now);
            UIHelper.SetValue(ddlUsuarioPopUpEstado, UIContext.Current.ContextUser.User.IdUsuario);
            ActualProyectoSeguimientoEstado = GetNewProyectoSeguimientoEstado();
        }
        void ProyectoSeguimientoEstadoSetValue()
        {
            UIHelper.SetValue<Estado, int>(ddlEstadoPopUpEstado, ActualProyectoSeguimientoEstado.IdEstado, EstadoService.Current.GetById);
            UIHelper.SetValue<Usuario, int>(ddlUsuarioPopUpEstado, ActualProyectoSeguimientoEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(diFechaPopUpEstado, ActualProyectoSeguimientoEstado.Fecha);
            UIHelper.SetValue(txtComentario, ActualProyectoSeguimientoEstado.Observacion);
            UIHelper.SetValue(chkGeneraComentarioTecnico, ActualProyectoSeguimientoEstado.GeneraComentarioTecnico);
            UIHelper.SetValue(chkEnviaMensaje, ActualProyectoSeguimientoEstado.EnviarMensaje);
        }
        void ProyectoSeguimientoEstadoGetValue()
        {
            ActualProyectoSeguimientoEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualProyectoSeguimientoEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualProyectoSeguimientoEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
            UsuarioResult usu = UsuarioService.Current.GetResult(new nc.UsuarioFilter() { IdUsuario = ActualProyectoSeguimientoEstado.IdUsuario }).FirstOrDefault();
            if (usu != null)
            {
                ActualProyectoSeguimientoEstado.Persona_Nombre = usu.Persona_Nombre;
                ActualProyectoSeguimientoEstado.Persona_Apellido = usu.Persona_Apellido;
            }
            //Matias 20170223 - Ticket #ER678458
            //ActualProyectoSeguimientoEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            DateTime fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualProyectoSeguimientoEstado.Fecha = fecha.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
            //FinMatias 20170223 - Ticket #ER678458            
            ActualProyectoSeguimientoEstado.Observacion = UIHelper.GetString(txtComentario);
            ActualProyectoSeguimientoEstado.GeneraComentarioTecnico = UIHelper.GetBoolean(chkGeneraComentarioTecnico);
            ActualProyectoSeguimientoEstado.EnviarMensaje = UIHelper.GetBoolean(chkEnviaMensaje);
        }
        void ProyectoSeguimientoEstadoRefresh()
        {

            if (Entity.ProyectoSeguimientoEstado.Count == 0) return;
            ProyectoSeguimientoEstadoResult pser;
            if (Entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo.HasValue)
                pser = (from o in this.Entity.ProyectoSeguimientoEstado where o.IdProyectoSeguimientoEstado == Entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo select o).FirstOrDefault();
            else
                pser = Entity.ProyectoSeguimientoEstado.Last();
            if (pser == null) return;
            UIHelper.SetValue(lbUsuario, pser.Persona_ApellidoYNombre);
            UIHelper.SetValue(lbEstadoSituacion, pser.Estado_Nombre);
            UIHelper.SetValue(diFechaEstado, pser.Fecha);
            UIHelper.SetValue(txtObservacionEstado, pser.Observacion);

        }
        #endregion

        protected void chkGeneraComentarioTecnico_CheckedChanged(object sender, EventArgs e)
        {
            CallTryMethod(ActivarFechaComentarioTecnico);
        }
        private void ActivarFechaComentarioTecnico()
        {
            bool Activo = UIHelper.GetBoolean(chkGeneraComentarioTecnico) || UIHelper.GetBoolean(chkEnviaMensaje);
            pnFechaComentarioPopUpEstado.Enabled = Activo;
            if (!Activo)
                UIHelper.Clear(diFechaComentarioPopUpEstado);
            else
                if (UIHelper.GetDateTimeNullable(diFechaComentarioPopUpEstado) == null)
                    UIHelper.SetValue(diFechaComentarioPopUpEstado, DateTime.Now);
        }

        #endregion


    }
}
