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
using Service;
using Contract;
using System.Collections.Generic;

namespace UI.Web
{
    public partial class ProyectoDictamenFactibilidadEdit : WebControlEdit<nc.DictamenCompose>
    {
        #region Override        
        protected override void _Initialize()
        {
            revNroProyectoSeguimiento.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            rfvNroProyectoSeguimiento.ErrorMessage = TranslateFormat("FieldIsNull", "Proyecto Seguimiento");
            revNroProyectoSeguimiento.ErrorMessage = TranslateFormat("InvalidField", "Proyecto Seguimiento");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");
            //rfvEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            
            //UIHelper.Load ( ddlEstado , EstadoService.Current.GetList (new nc.EstadoFilter (){Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Dictamen }), "Nombre","IdEstado", new Estado(){IdEstado = 0 , Nombre ="Seleccione Estado" });
            UIHelper.Load<Estado>(ddlEstadoPopUpEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PROYECTO_DICTAMEN, Activo = true }), "Nombre", "IdEstado", new Estado() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });

            //Matias 20141105 - Tarea 171
            rfvEstadoPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            rfvUsuarioPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Usuario");
            //FinMatias 20141105 - Tarea 171

            PopUpEstados.Attributes.CssStyle.Add("display", "none");
            PopUpProyectoSeguimiento.Attributes.CssStyle.Add("display", "none");
            base._Initialize();
        }
        public override void SetValue()
        {
            UIHelper.SetValue(txtDenominacion, Entity.ProyectoDictamen.Denominacion);
            //UIHelper.SetValue(ddlEstado, Entity.ProyectoDictamen.IdEstado);
            upDenominacion.Update();
            //upEstado.Update();
            ProyectoSeguimientoRefresh();
            ProyectoDictamenEstadoRefresh();
        }

        public override void GetValue()
        {
            Entity.ProyectoDictamen.Denominacion = UIHelper.GetString(txtDenominacion);
           // Entity.ProyectoDictamen.IdEstado = UIHelper.GetInt(ddlEstado);
        }

        public override void Clear()
        {
            //UIHelper.Clear(ddlEstado );
            UIHelper.Clear(txtDenominacion );
            UIHelper.Clear(gvEvaluacionFactibilidad);
            UIHelper.Clear(gvProyectos);
            UIHelper.Clear(dlProvincias);
        }
        #endregion
        #region ProyectoSeguimiento
        private ProyectoSeguimientoResult actualProyectoSeguimiento;
        protected ProyectoSeguimientoResult ActualProyectoSeguimiento
        {
            get
            {
                if (actualProyectoSeguimiento == null)
                    if (ViewState["actualProyectoSeguimiento"] != null)
                        actualProyectoSeguimiento = ViewState["actualProyectoSeguimiento"] as ProyectoSeguimientoResult;
                    else
                    {
                        actualProyectoSeguimiento = GetNewProyectoSeguimiento();
                        ViewState["actualProyectoSeguimiento"] = actualProyectoSeguimiento;
                    }
                return actualProyectoSeguimiento;
            }
            set
            {
                actualProyectoSeguimiento = value;
                ViewState["actualProyectoSeguimiento"] = value;
            }
        }
        ProyectoSeguimientoResult GetNewProyectoSeguimiento()
        {
            int id = 0;
            if (Entity.proyectoSeguimiento.Count > 0) id = Entity.proyectoSeguimiento.Min(o => o.IdProyectoSeguimiento);
            if (id > 0) id = 0;
            id--;
            ProyectoSeguimientoResult uopResult = new ProyectoSeguimientoResult();
            ProyectoSeguimientoService.Current.Set(ProyectoSeguimientoService.Current.GetNew(), uopResult);
            uopResult.IdProyectoSeguimiento = id;
            return uopResult;
        }
        void HidePopUpProyectoSeguimiento()
        {
            ModalPopupExtenderProyectoSeguimiento.Hide();
        }
        void ShowPopUpProyectoSeguimiento()
        {
            ModalPopupExtenderProyectoSeguimiento.Show();
            upProyectoSeguimientoPopUp.Update();
        }
        void BuscarEvaluacionFactibilidad()
        {
            String MsjError;
            Int32 Nro= UIHelper.GetInt(txtNroProyectoSeguimiento);
            if (Nro == 0)
            {
                MsjError =  Translate("Debe Ingresar Un Nro Valido");
                throw new ValidationException(MsjError);
            }
            ProyectoSeguimientoResult ProyectoSeguimiento = ProyectoSeguimientoService.Current.GetResult(new nc.ProyectoSeguimientoFilter() { IdProyectoSeguimiento  = Nro}).FirstOrDefault();
            if (ProyectoSeguimiento == null)
            {
                MsjError = Translate("Evaluación Inexistente"); //Matias 20141125 - Tarea 177 | Orig: MsjError = Translate("Evolución Inexistente");
                throw new ValidationException(MsjError);
            }
            List<ProyectoDictamenSeguimientoResult> pdsrl = ProyectoDictamenSeguimientoService.Current.GetResult(new ProyectoDictamenSeguimientoFilter() { IdProyectoSeguimiento = Nro });
            
            //DataHelper.Validate (pdsrl.Where ( i=> i.IdProyectoDictamen != Entity.IdProyectoDictamen).Count () ==0 , "Evolución Asociada a Otro dictamen");
            if (pdsrl.Where(i => i.IdProyectoDictamen != Entity.IdProyectoDictamen).Count() != 0)
            {
                MsjError = Translate("La evaluación seleccionada se encuentra relacionada a otro dictamen."); //Matias 20141125 - Tarea 177 | Orig: MsjError = Translate("La evolución seleccionada se encuentra relacionada a otro dictamen.");
                throw new ValidationException(MsjError);
            }
            UIHelper.SetValue(lbDenominacionProyectoSeguimiento , ProyectoSeguimiento.Denominacion );
            ActualProyectoSeguimiento.IdProyectoSeguimiento = ProyectoSeguimiento.IdProyectoSeguimiento;
            ActualProyectoSeguimiento.Saf_Denominacion = ProyectoSeguimiento.Saf_Denominacion;
            ActualProyectoSeguimiento.Denominacion = ProyectoSeguimiento.Denominacion;
            upProyectoSeguimientoPopUp.Update();
        }

        #region EventosGrillas

        protected void gvEvaluacionFactibilidad_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoSeguimiento = (from o in Entity.proyectoSeguimiento where o.IdProyectoSeguimiento == id select o).FirstOrDefault();
            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoSeguimientoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoSeguimientoDelete();
                    break;
            }
        }
        protected virtual void gvEvaluacionFactibilidad_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gvEvaluacionFactibilidad.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void gvEvaluacionFactibilidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvEvaluacionFactibilidad.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoSeguimiento_Click(object sender, EventArgs e)
        {  
            CallTryMethod(CommandProyectoSeguimientoSave);
            HidePopUpProyectoSeguimiento();
        }
        protected void btNewProyectoSeguimiento_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandProyectoSeguimientoSave);
        }
        protected void btCancelProyectoSeguimiento_Click(object sender, EventArgs e)
        {
            ProyectoSeguimientoClear();
            HidePopUpProyectoSeguimiento();
        }
        protected void btAgregarEvaluacionFactibilidad_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpProyectoSeguimiento);
        }
        //protected void txtNroProyectoSeguimiento_TextChanged(object sender, EventArgs e)
        //{
        //    CallTryMethod(BuscarEvaluacionFactibilidad);
        //}

        protected void btSearchProyectoSeguimiento_Click(object sender, EventArgs e)
        {
            CallTryMethod(BuscarEvaluacionFactibilidad);
        }
       


        #endregion
        #region Commands
        void CommandProyectoSeguimientoEdit()
        {
            ProyectoSeguimientoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoSeguimiento);
        }
        void CommandProyectoSeguimientoSave()
        {
            ProyectoSeguimientoGetValue();
            ProyectoSeguimientoResult result = (from o in Entity.proyectoSeguimiento where o.IdProyectoSeguimiento == ActualProyectoSeguimiento.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.IdProyectoSeguimiento  = ActualProyectoSeguimiento.IdProyectoSeguimiento ;
                result.Denominacion  = ActualProyectoSeguimiento.Denominacion ;
                result.Saf_Denominacion = ActualProyectoSeguimiento.Saf_Denominacion;
            }
            else
            {
                Entity.proyectoSeguimiento.Add(ActualProyectoSeguimiento);
            }
            if (Entity.proyectoSeguimiento.Count > 0 && UIHelper.GetString (txtDenominacion) == String.Empty  )
            {
                UIHelper.SetValue(txtDenominacion, Entity.proyectoSeguimiento.First().Denominacion);
                upDenominacion.Update();
            }
            ProyectoSeguimientoClear();
            ProyectoSeguimientoRefresh();
        }
        void CommandProyectoSeguimientoDelete()
        {
            ProyectoSeguimientoResult result = (from o in Entity.proyectoSeguimiento  where o.IdProyectoSeguimiento == ActualProyectoSeguimiento.ID select o).FirstOrDefault();
            Entity.proyectoSeguimiento.Remove(result);
            ProyectoSeguimientoClear();
            ProyectoSeguimientoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoSeguimientoClear()
        {
            UIHelper.Clear(txtNroProyectoSeguimiento );
            UIHelper.Clear(lbDenominacionProyectoSeguimiento);
            ActualProyectoSeguimiento = GetNewProyectoSeguimiento();
        }
        void ProyectoSeguimientoSetValue()
        {
            UIHelper.SetValue(txtNroProyectoSeguimiento, ActualProyectoSeguimiento.IdProyectoSeguimiento );
            UIHelper.SetValue(lbDenominacionProyectoSeguimiento, ActualProyectoSeguimiento.Denominacion );
        }
        void ProyectoSeguimientoGetValue()
        {
            BuscarEvaluacionFactibilidad();
        }
        void ProyectoSeguimientoRefresh()
        {
            UIHelper.Load(gvEvaluacionFactibilidad, Entity.proyectoSeguimiento );
            CargarProyectos();
            upGridProyectoSeguimiento.Update();
            
        }
        #endregion
        #endregion

        private void CargarProyectos()
        {
            if (Entity.proyectoSeguimiento.Count > 0)
            {
                RefreshProyectos(ProyectoSeguimientoProyectoService.Current.GetResult(new nc.ProyectoSeguimientoProyectoFilter() { IdsProyectoSeguimiento = Entity.proyectoSeguimiento.Select(i => i.IdProyectoSeguimiento).ToList() }));
                RefreshLocalizacion(ProyectoSeguimientoComposeService.Current.AlcanceGeograficoToProyectoSeguimientoLocalizacion(Entity.proyectoSeguimiento.Select(i => i.IdProyectoSeguimiento).ToList()));
            }
            else
            {
                RefreshProyectos();
                RefreshLocalizacion(ProyectoSeguimientoComposeService.Current.AlcanceGeograficoToProyectoSeguimientoLocalizacion());
            }

        }
        private void RefreshProyectos()
        {
            RefreshProyectos(null);
        }
        private void RefreshProyectos(List<ProyectoSeguimientoProyectoResult> proyectoSeguimientoProyecto )
        {
            UIHelper.Load(gvProyectos, proyectoSeguimientoProyecto);
            upProyectos.Update();
        
        }
        private void RefreshLocalizacion(List<ProyectoSeguimientoLocalizacionResult> proyectoSeguimientoLocalizacion)
        {
            UIHelper.SetValue(dlProvincias,proyectoSeguimientoLocalizacion.OrderBy (i=> i.CalificacionGeografica_Codigo));           
        }

        #region Estados
        private ProyectoDictamenEstadoResult actualProyectoDictamenEstado;
        protected ProyectoDictamenEstadoResult ActualProyectoDictamenEstado
        {
            get
            {
                if (actualProyectoDictamenEstado == null)
                    if (ViewState["actualProyectoDictamenEstado"] != null)
                        actualProyectoDictamenEstado = ViewState["actualProyectoDictamenEstado"] as ProyectoDictamenEstadoResult;
                    else
                    {
                        actualProyectoDictamenEstado = GetNewProyectoDictamenEstado();
                        ViewState["actualProyectoDictamenEstado"] = actualProyectoDictamenEstado;
                    }
                return actualProyectoDictamenEstado;
            }
            set
            {
                actualProyectoDictamenEstado = value;
                ViewState["actualProyectoDictamenEstado"] = value;
            }
        }
        ProyectoDictamenEstadoResult GetNewProyectoDictamenEstado()
        {
            int id = 0;
            if (Entity.ProyectoDictamenEstado.Count > 0) id = Entity.ProyectoDictamenEstado.Min(o => o.IdProyectoDictamenEstado);
            if (id > 0) id = 0;
            id--;
            ProyectoDictamenEstadoResult uopResult = new ProyectoDictamenEstadoResult();
            ProyectoDictamenEstadoService.Current.Set(ProyectoDictamenEstadoService.Current.GetNew(), uopResult);
            uopResult.IdProyectoDictamenEstado = id;
            return uopResult;
        }
        void HidePopUpEstados()
        {
            ModalPopupExtenderEstados.Hide();
        }
        void ShowPopUpEstados()
        {
            ModalPopupExtenderEstados.Show();
            ProyectoDictamenEstadoClear();
            upEstadosPopUp.Update();
        }
        #region EventosGrillas

        protected void GridRoles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoDictamenEstado = (from o in Entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoDictamenEstadoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoDictamenEstadoDelete();
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
            UIHelper.CallTryMethod(CommandProyectoDictamenEstadoSave);
            HidePopUpEstados();
        }
        protected void btNewEstados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoDictamenEstadoSave);
        }
        protected void btCancelEstados_Click(object sender, EventArgs e)
        {
            ProyectoDictamenEstadoClear();
            HidePopUpEstados();
        }
        protected void btAgregarEstado_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        #endregion
        #region Commands
        void CommandProyectoDictamenEstadoEdit()
        {
            ProyectoDictamenEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        void CommandProyectoDictamenEstadoSave()
        {
            ProyectoDictamenEstadoGetValue();
            ProyectoDictamenEstadoResult result = (from o in Entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado == ActualProyectoDictamenEstado.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.IdEstado = ActualProyectoDictamenEstado.IdEstado;
                result.Estado_Nombre = ActualProyectoDictamenEstado.Estado_Nombre;
                result.Fecha = ActualProyectoDictamenEstado.Fecha;
                result.Observacion = ActualProyectoDictamenEstado.Observacion;
                result.IdUsuario = ActualProyectoDictamenEstado.IdUsuario;
                result.Usuario_NombreUsuario = ActualProyectoDictamenEstado.Usuario_NombreUsuario;
                result.Persona_Apellido = ActualProyectoDictamenEstado.Persona_Apellido;
                result.Persona_Nombre = ActualProyectoDictamenEstado.Persona_Nombre;

            }
            else
            {
                Entity.ProyectoDictamenEstado.Add(ActualProyectoDictamenEstado);
            }
            Entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo = null;
            ProyectoDictamenEstadoClear();
            ProyectoDictamenEstadoRefresh();
        }
        void CommandProyectoDictamenEstadoDelete()
        {
            ProyectoDictamenEstadoResult result = (from o in Entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado == ActualProyectoDictamenEstado.ID select o).FirstOrDefault();
            Entity.ProyectoDictamenEstado.Remove(result);
            ProyectoDictamenEstadoClear();
            ProyectoDictamenEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoDictamenEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentario);
            UIHelper.SetValue(diFechaPopUpEstado, DateTime.Now);
            //UIHelper.SetValue<Usuario,Int32>(ddlUsuarioPopUpEstado, UIContext.Current.ContextUser.User.IdUsuario,UsuarioService.Current.GetById );
            UIHelper.SetValue(ddlUsuarioPopUpEstado, UIContext.Current.ContextUser.User.IdUsuario);
            ActualProyectoDictamenEstado = GetNewProyectoDictamenEstado();

        }
        void ProyectoDictamenEstadoSetValue()
        {
            UIHelper.SetValue<Estado, int>(ddlEstadoPopUpEstado, ActualProyectoDictamenEstado.IdEstado, EstadoService.Current.GetById);
            //UIHelper.SetValue<Usuario, int>(ddlUsuarioPopUpEstado, ActualProyectoDictamenEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(ddlUsuarioPopUpEstado, ActualProyectoDictamenEstado.IdUsuario);
            UIHelper.SetValue(diFechaPopUpEstado, ActualProyectoDictamenEstado.Fecha);
            UIHelper.SetValue(txtComentario, ActualProyectoDictamenEstado.Observacion);
            //UIHelper.SetValue(chkGeneraComentarioTecnico, ActualProyectoDictamenEstado.GeneraComentarioTecnico);
            //UIHelper.SetValue(chkEnviaMensaje, ActualProyectoDictamenEstado.EnviarMensaje);
        }
        void ProyectoDictamenEstadoGetValue()
        {
            ActualProyectoDictamenEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualProyectoDictamenEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualProyectoDictamenEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
            UsuarioResult usu = UsuarioService.Current.GetResult(new nc.UsuarioFilter() { IdUsuario = ActualProyectoDictamenEstado.IdUsuario }).FirstOrDefault();
            if (usu != null)
            {
                ActualProyectoDictamenEstado.Persona_Nombre = usu.Persona_Nombre;
                ActualProyectoDictamenEstado.Persona_Apellido = usu.Persona_Apellido;
            }
            ActualProyectoDictamenEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualProyectoDictamenEstado.Observacion = UIHelper.GetString(txtComentario);
            //ActualProyectoDictamenEstado.GeneraComentarioTecnico = UIHelper.GetBoolean(chkGeneraComentarioTecnico);
            //ActualProyectoDictamenEstado.EnviarMensaje = UIHelper.GetBoolean(chkEnviaMensaje);
        }
        void ProyectoDictamenEstadoRefresh()
        {

            if (Entity.ProyectoDictamenEstado.Count == 0) return;
            ProyectoDictamenEstadoResult pser;
            if (Entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo.HasValue)
                pser = (from o in this.Entity.ProyectoDictamenEstado where o.IdProyectoDictamenEstado == Entity.ProyectoDictamen.IdProyectoDictamenEstadoUltimo select o).FirstOrDefault();
            else
                pser = Entity.ProyectoDictamenEstado.Last();
            if (pser == null) return;
            UIHelper.SetValue(lbUsuario, pser.Persona_ApellidoYNombre);
            UIHelper.SetValue(lbEstadoSituacion, pser.Estado_Nombre);
            UIHelper.SetValue(diFechaEstado, pser.Fecha);
            UIHelper.SetValue(txtObservacionEstado, pser.Observacion);

        }
        #endregion


        #endregion
    }
}