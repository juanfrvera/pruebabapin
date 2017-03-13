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
    public partial class ProyectoEdit : WebControlEdit<nc.ProyectoGeneralCompose>
    {
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
        protected override void _Load()
        {

            this.toEjecutor.Width = 390;
            this.toIniciador.Width = 390;
            this.toResponsable.Width = 390;
            this.toFinalidadFuncion.Width = 600;
            base._Load();
        }
        protected override void _Initialize()
        {
            base._Initialize();
            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revBapin.ValidationExpression = Contract.DataHelper.GetExpRegNumberInteger();
            revJustificacionDemora.ValidationExpression = Contract.DataHelper.GetExpRegString(8000);
            revPrioridad.ValidationExpression = Contract.DataHelper.GetExpRegNumberIntegerNullable();
            UIHelper.Load<nc.ProyectoTipo>(ddlTipoProyecto, ProyectoTipoService.Current.GetList(new nc.ProyectoTipoFilter() { Activo = true }), "Nombre", "IdProyectoTipo", new ProyectoTipo() { IdProyectoTipo = 0, Nombre = "Seleccione Clasificación" });
            UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto }), "Nombre", "IdEstado", new Estado() { IdEstado = 0, Nombre = "Seleccione Estado" }, true, "Orden", typeof(Int32));
            UIHelper.Load<nc.ModalidadContratacion>(ddlModalidadContratacion, ModalidadContratacionService.Current.GetList(new nc.ModalidadContratacionFilter() { Activo = true }), "Nombre", "IdModalidadContratacion", new ModalidadContratacion() { IdModalidadContratacion = 0, Nombre = "Seleccione Modalidad de Contratacion" });

            UIHelper.Load<nc.OrganismoPrioridad>(ddlPrioridad, OrganismoPrioridadService.Current.GetList(new nc.OrganismoPrioridadFilter() { Activo = true }), "Nombre", "IdOrganismoPrioridad", new nc.OrganismoPrioridad() { IdOrganismoPrioridad = 0, Nombre = "Seleccione Prioridad" });
            UIHelper.Load<nc.ProyectoRelacionTipo>(ddlTipoRelacionProyectoRelacionado, ProyectoRelacionTipoService.Current.GetList(new nc.ProyectoRelacionTipoFilter() { Activo = true }), "Nombre", "IdProyectoRelacionTipo", new nc.ProyectoRelacionTipo() { IdProyectoRelacionTipo = 0, Nombre = "Seleccione tipo de Relacion" });

            //rfvTipoProyecto.ErrorMessage = TranslateFormat("FieldIsNull", "Clasificación Económica");
            //Matias 20141014 - Tarea 157
            rfvTipoProyecto.ErrorMessage = TranslateFormat("FieldIsNull", "TipoProyecto");
            rfvTipoProyecto2.ErrorMessage = TranslateFormat("FieldIsNull", "TipoProyecto");
            //FinMatias 20141014 - Tarea 157
            rfvSAF.ErrorMessage = TranslateFormat("FieldIsNull", "Saf");
            rfvPrograma.ErrorMessage = TranslateFormat("FieldIsNull", "Programa");
            rfvPrograma2.ErrorMessage = TranslateFormat("FieldIsNull", "Programa");
            rfvSubPrograma.ErrorMessage = TranslateFormat("FieldIsNull", "Sub Programa");
            rfvSubPrograma2.ErrorMessage = TranslateFormat("FieldIsNull", "Sub Programa");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominacion");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominacion");
            rfvEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            revPrioridad.ErrorMessage = TranslateFormat("InvalidField", "Prioridad");
            rfvTipoPopoUp.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            rfvPeriodoPopUp.ErrorMessage = TranslateFormat("FieldIsNull", "Periodo");
            rfvPeriodoPopUp2.ErrorMessage = TranslateFormat("FieldIsNull", "Periodo");
            rfvVersionPopUp.ErrorMessage = TranslateFormat("FieldIsNull", "Version");
            rfvVersionPopUp2.ErrorMessage = TranslateFormat("FieldIsNull", "Version");
            //rfvTipoOrigenFinanciamiento.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo Origen de Financiamiento");
            rfvCodigoOrigenFinanciamiento.ErrorMessage = TranslateFormat("FieldIsNull", "Código Origen de Financiamiento");
            rfvBapin.ErrorMessage = TranslateFormat("FieldIsNull", "Nro Bapin");
            revBapin.ErrorMessage = TranslateFormat("InvalidField", "Nro Bapin");
            rfvTipoRelacionProyectoRelacionado.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Proyecto Relacionado");
            rfvJustificacionDemora.ErrorMessage = TranslateFormat("FieldIsNull", "Justificación Demora");
            revJustificacionDemora.ErrorMessage = TranslateFormat("InvalidField", "Justificación Demora");

            //Matias 20131218 - Tarea 103
            diFechaDemora.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha"); //"Fecha inválida";
            diFechaDemora.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha"); //"Fecha obligatoria";
            //FinMatias 20131218 - Tarea 103

            rfvSAFTransferencia.ErrorMessage = TranslateFormat("FieldIsNull", "SAF");
            //rfvJurisdiccionTransferencia.ErrorMessage = TranslateFormat("FieldIsNull", "Jurisdición"); //Matias 20140403 - Tarea 122
            //rfvProvinciaTransferencia.ErrorMessage = TranslateFormat("FieldIsNull", "Provincia"); //Matias 20140403 - Tarea 122

        }
        public override void Clear()
        {
            ddlEstado.Enabled = true;
            UIHelper.Clear(ddlTipoProyecto);
            ddlTipoProyecto.Focus();
            UIHelper.Clear(chkBorrador);
            UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(ddlEstado);
            UIHelper.Clear(ddlModalidadContratacion);
            UIHelper.Clear(chkRequiereDictamen);
            //UIHelper.Clear(ddlIniciador);
            UIHelper.Clear(toIniciador);
            //UIHelper.Clear(ddlEjecutor);
            UIHelper.Clear(toEjecutor);
            //UIHelper.Clear(ddlResponsable);
            UIHelper.Clear(toResponsable);
            UIHelper.Clear(lbSectorialista);
            UIHelper.Clear(ddlPrioridad);
            UIHelper.Clear(txtPrioridad);
            UIHelper.Clear(txtSituacionActual);
            UIHelper.Clear(txtDescripcion);
            UIHelper.Clear(txtObservaciones);
            UIHelper.Clear(toFinalidadFuncion);


            if (CrudAction == CrudActionEnum.Create)
            {
                UIHelper.SetValue(toIniciador, ActualOficina.IdOficina);
                UIHelper.SetValue(toEjecutor, ActualOficina.IdOficina);
                UIHelper.SetValue(toResponsable, ActualOficina.IdOficina);
            }
            UIHelper.Clear(dlFuncionarioIniciador);
            UIHelper.Clear(dlFuncionarioEjecutor);
            UIHelper.Clear(dlFuncionarioResponsable);
            ClearCombosAnidados();
            ProyectoOficinaPerfilClear();
        }
        public override void SetValue()
        {
            #region Old
            //UIHelper.SetValue(ddlTipoProyecto, Entity.IdTipoProyecto);
            //ddlTipoProyecto.Focus();
            //    UIHelper.SetValue(ddlSubPrograma, Entity.IdSubPrograma);
            //UIHelper.SetValue(txtCodigo, Entity.Codigo);
            //UIHelper.SetValue(txtProyectoDenominacion, Entity.ProyectoDenominacion);
            //UIHelper.SetValue(txtProyectoSituacionActual, Entity.ProyectoSituacionActual);
            //UIHelper.SetValue(txtProyectoDescripcion, Entity.ProyectoDescripcion);
            //UIHelper.SetValue(txtProyectoObservacion, Entity.ProyectoObservacion);
            //UIHelper.SetValue(ddlEstado, Entity.IdEstado);
            //UIHelper.SetValue(ddlProceso, Entity.IdProceso);
            //UIHelper.SetValue(ddlModalidadContratacion, Entity.IdModalidadContratacion);
            //UIHelper.SetValue(ddlFinalidadFuncion, Entity.IdFinalidadFuncion);
            //UIHelper.SetValue(ddlOrganismoPrioridad, Entity.IdOrganismoPrioridad);
            //UIHelper.SetValue(txtSubPrioridad, Entity.SubPrioridad);
            //UIHelper.SetValue(chkBorrador, Entity.Borrador);
            //UIHelper.SetValue(txtNroProyecto, Entity.NroProyecto);
            //UIHelper.SetValue(txtAnioCorriente, Entity.AnioCorriente);
            //UIHelper.SetValue(diFechaInicio, Entity.FechaInicio);
            //UIHelper.SetValue(diFechaFin, Entity.FechaFin);
            //UIHelper.SetValue(diFechaAlta, Entity.FechaAlta);
            //UIHelper.SetValue(diFechaModificacion, Entity.FechaModificacion);
            //UIHelper.SetValue(txtIdUsuarioModificacion, Entity.IdUsuarioModificacion);
            #endregion
            SetPermissions();
            List<SafResult> safs;
            if (UIContext.Current.ContextUser.User.AccesoTotal || CrudAction != CrudActionEnum.Create)
                safs = SafService.Current.GetResultFromList(new nc.SafFilter() { Activo = true });
            else
                safs = SafService.Current.GetResultFromList(new nc.SafFilter() { Activo = true, IdUsusario = UIContext.Current.ContextUser.User.ID });
            UIHelper.Load<SafResult>(ddlSAF, safs, "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", typeof(Int32));

            //Matias 20170125 - Ticket #ER311422
            //Inserta, en caso que el TipoProyecto del Proyecto esta INACTIVO, el TipoProyecto en el ddlTipoProyecto
            ProyectoTipo pt = ProyectoTipoService.Current.GetById(Entity.proyecto.IdTipoProyecto);
            if (pt!=null && !pt.Activo)
                ddlTipoProyecto.Items.Add(new ListItem() { Value = pt.IdProyectoTipo.ToString(), Text = pt.Nombre.ToString() + " (INACTIVO)" });
            //FinMatias 20170125 - Ticket #ER311422
            
            UIHelper.SetValue<ProyectoTipo, int>(ddlTipoProyecto, Entity.proyecto.IdTipoProyecto, ProyectoTipoService.Current.GetById);
            //UIHelper.SetValue(ddlTipoProyecto, Entity.proyecto.IdTipoProyecto);
            CargarProcesos();

            //Matias 20131205 - Tarea 91
            if (CrudAction == CrudActionEnum.Create)
            {
                Contract.OficinaResult os = OficinaService.Current.GetResult(new nc.OficinaFilter() { IdOficina = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault();
                int? idOficinaIdSAF = os.IdSaf.Equals(null) ? 0 : os.IdSaf;
                UIHelper.SetValue(ddlSAF, idOficinaIdSAF);
            }
            else
            {
                UIHelper.SetValue(ddlSAF, Entity.proyecto.IdSAF); /*Sentencia original unica*/
            }
            //FinMatias 20131205 - Tarea 91

            //UIHelper.SetValue(acSaf , Entity.proyecto.IdSAF);
            //UIHelper.SetValue(acSaf, String.Format("{0}-{1}", Entity.proyecto.Saf_Codigo, Entity.proyecto.Saf_Nombre));
            CargarProgramas();
            UIHelper.SetValue(chkBorrador, Entity.proyecto.EsBorrador);
            UIHelper.SetValue(chkActivo, Entity.proyecto.Activo);
            if (Entity.proyecto.IdProyecto > 0)
                UIHelper.SetValue<ProgramaResult, int>(ddlPrograma, Entity.proyecto.IdPrograma, ProgramaService.Current.GetResultById);
            //Matias 20170127 - Ticket #REQ399293
            CargarSubProgramas(); //original estaba descomentado
            if (Entity.proyecto.IdProyecto > 0) 
                UIHelper.SetValue<SubPrograma, int>(ddlSubPrograma, Entity.proyecto.IdSubPrograma, SubProgramaService.Current.GetById);
            //FinMatias 20170127 - Ticket #REQ399293

            UIHelper.SetValue(txtDenominacion, Entity.proyecto.ProyectoDenominacion);
            if (Entity.proyecto.IdProceso.HasValue)
                UIHelper.SetValue<Proceso, int>(ddlProceso, Entity.proyecto.IdProceso.Value, ProcesoService.Current.GetById);
            if (Entity.proyecto.IdEstado == 0)
            {
                UIHelper.SetValue<Estado, int>(ddlEstado, (short)EstadoEnum.Idea, EstadoService.Current.GetById);
                ddlEstado.Enabled = false;
            }
            else
                UIHelper.SetValue<Estado, int>(ddlEstado, Entity.proyecto.IdEstado, EstadoService.Current.GetById);
            if (Entity.proyecto.IdModalidadContratacion.HasValue)
                UIHelper.SetValue<ModalidadContratacion, int>(ddlModalidadContratacion, Entity.proyecto.IdModalidadContratacion.Value, ModalidadContratacionService.Current.GetById);
            UIHelper.SetValue(chkRequiereDictamen, Entity.proyecto.RequiereDictamen);
            if (Entity.proyecto.IdOrganismoPrioridad.HasValue)
                UIHelper.SetValue<Prioridad, int>(ddlPrioridad, Entity.proyecto.IdOrganismoPrioridad.Value, PrioridadService.Current.GetById);
            UIHelper.SetValue(txtPrioridad, Entity.proyecto.SubPrioridad);
            UIHelper.SetValue(txtSituacionActual, Entity.proyecto.ProyectoSituacionActual);
            UIHelper.SetValue(txtDescripcion, Entity.proyecto.ProyectoDescripcion);
            UIHelper.SetValue(txtObservaciones, Entity.proyecto.ProyectoObservacion);
            UIHelper.SetValue(dlFuncionarioIniciador, Entity.proyectoOficinaPerfilFuncionarioIniciador.OrderBy(i => i.Usuario_ApellidoYNombre));
            UIHelper.SetValue(dlFuncionarioEjecutor, Entity.proyectoOficinaPerfilFuncionarioEjecutor.OrderBy(i => i.Usuario_ApellidoYNombre));
            UIHelper.SetValue(dlFuncionarioResponsable, Entity.proyectoOficinaPerfilFuncionarioResponsable.OrderBy(i => i.Usuario_ApellidoYNombre));
            UIHelper.SetValue(toFinalidadFuncion, Entity.proyecto.IdFinalidadFuncion);
            ProyectoPlanRefresh();
            ActualizarUltimoPlan();
            upDatosGenerales.Update();
            upOtrosDatos.Update();
            ProyectoOficinaPerfilSetValue();
            ProyectoOrigenFinanciamientoRefresh();
            ProyectoRelacionRefresh();
            ProyectoDemoraRefresh();
            DeshabilitarEdicionCombos();
            if (this.Entity.proyecto.EsBorrador)
                this.btAgregarOrigenFinanciamiento.Enabled = false;

        }
        public override void GetValue()
        {
            bool esBorrador = UIHelper.GetBoolean(chkBorrador);
            if (esBorrador && Entity.proyectoOrigenFinanciamiento.Count > 0) {

                throw new Exception("Error: Proyecto asociado a una fuente de fianaciamiento. No puede estar en Borrador");
            }

            //*******************************************************
            //Fecha Modificación: 09/01/2017
            //Modificado por Diego DB' según requerimiento Constanza Hilario
            //Se requiere que los proyectos no pueden tener la marca borrador y tengan asignado al menos un plan
            //********************************************************
            if (esBorrador && Entity.proyectoPlan.Count > 0)
            {
                esBorrador = false;
                //throw new Exception("Error: No es posible configurar el proyecto como Borrador cuando el mismo tiene o ha tenido un plan asignado");
                throw new Exception("Error: Proyecto ligado a un Plan. No puede estar en Borrador");
            }
            //FinDiegoDB

            Entity.proyecto.IdTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);
            Entity.proyecto.IdSAF = UIHelper.GetInt(ddlSAF);
            Entity.proyecto.EsBorrador = esBorrador;
            //Entity.proyecto.Activo  = UIHelper.GetBoolean(chkActivo);
            Entity.proyecto.IdPrograma = UIHelper.GetInt(ddlPrograma);
            Entity.proyecto.IdSubPrograma = UIHelper.GetInt(ddlSubPrograma);
            Entity.proyecto.ProyectoDenominacion = UIHelper.GetString(txtDenominacion);
            Entity.proyecto.IdProceso = UIHelper.GetIntNullable(ddlProceso);
            Entity.proyecto.IdEstado = UIHelper.GetInt(ddlEstado);
            Entity.proyecto.IdModalidadContratacion = UIHelper.GetIntNullable(ddlModalidadContratacion);
            Entity.proyecto.RequiereDictamen = UIHelper.GetBoolean(chkRequiereDictamen);
            Entity.proyecto.IdOrganismoPrioridad = UIHelper.GetIntNullable(ddlPrioridad);
            Entity.proyecto.SubPrioridad = UIHelper.GetIntNullable(txtPrioridad);
            Entity.proyecto.ProyectoSituacionActual = UIHelper.GetString(txtSituacionActual);
            Entity.proyecto.ProyectoDescripcion = UIHelper.GetString(txtDescripcion);
            Entity.proyecto.ProyectoObservacion = UIHelper.GetString(txtObservaciones);
            if (CrudAction == CrudActionEnum.Create)
            {
                Entity.proyecto.FechaAlta = DateTime.Now;
                Entity.proyecto.FechaModificacion = DateTime.Now;
            }
            Entity.proyecto.IdFinalidadFuncion = UIHelper.GetIntNullable(toFinalidadFuncion);
            ProyectoOficinaPerfilGetValue();
            Update(dlFuncionarioIniciador, Entity.proyectoOficinaPerfilFuncionarioIniciador);
            Update(dlFuncionarioEjecutor, Entity.proyectoOficinaPerfilFuncionarioEjecutor);
            Update(dlFuncionarioResponsable, Entity.proyectoOficinaPerfilFuncionarioResponsable);

        }

        #region Events
        protected void ddlSaf_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarProgramas);
            ddlSAF.Focus();
        }
        protected void ddlPrograma_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarSubProgramas);
            ddlPrograma.Focus();
        }
        protected void ddlTipoProyecto_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarProcesos);
            ddlTipoProyecto.Focus();
        }

        #endregion

        #region Private Methods

        private void ClearCombosAnidados()
        {
            UIHelper.ClearItems(ddlPrograma);
            ddlPrograma.Enabled = false;
            UIHelper.ClearItems(ddlSubPrograma);
            ddlSubPrograma.Enabled = false;
            UIHelper.ClearItems(ddlProceso);
            ddlProceso.Enabled = false;

        }
        private void Update(DataList dataList, List<ProyectoOficinaPerfilFuncionarioResult> list)
        {
            for (int i = 0; i < dataList.Items.Count; i++)
            {
                bool isChecked = ((CheckBox)dataList.Items[i].FindControl("chk")).Checked;
                string StringValue = ((HiddenField)dataList.Items[i].FindControl("hdValue")).Value;
                short value;
                if (!short.TryParse(StringValue, out value))
                    value = 0;
                if (value == 0) continue;
                ProyectoOficinaPerfilFuncionarioResult item = (from o in list where o.IdUsuario == value select o).FirstOrDefault();
                if (item == null) continue;
                item.Selected = isChecked;
            }
        }
        private void CargarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            List<ProgramaResult> programa;
            if (idSaf != 0)
            {
                if (UIContext.Current.ContextUser.User.AccesoTotal || CrudAction != CrudActionEnum.Create)
                    programa = ProgramaService.Current.GetResultFromList(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true });
                else
                    programa = ProgramaService.Current.GetResultFromList(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true, IdUsuarioSaf = UIContext.Current.ContextUser.User.ID });

                UIHelper.Load<ProgramaResult>(ddlPrograma, programa, "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" }, true, "CodigoInt", typeof(Int32));
                ddlPrograma.Enabled = true;
                if (programa.Count == 1)
                    ddlPrograma.SelectedValue = Convert.ToString(programa.FirstOrDefault().IdPrograma);
            }
            else
            {
                UIHelper.ClearItems(ddlPrograma);
                ddlPrograma.Enabled = false;

            }
            CargarSubProgramas();
        }
        private void CargarSubProgramas()
        {
            Int32 idPrograma = UIHelper.GetInt(ddlPrograma);
            if (idPrograma != 0)
            {
                List<SubProgramaResult> subProgramas = SubProgramaService.Current.GetResultFromList(new nc.SubProgramaFilter() { IdPrograma = idPrograma, Activo = true });
                UIHelper.Load<SubProgramaResult>(ddlSubPrograma, subProgramas, "CodigoNombre", "IdSubPrograma", new SubProgramaResult() { IdSubPrograma = 0, Codigo = "", Nombre = "Seleccione Sub Programa" }, true, "CodigoInt", typeof(Int32));
                ddlSubPrograma.Enabled = true;
                if (subProgramas.Count == 1)
                    ddlSubPrograma.SelectedValue = Convert.ToString(subProgramas.FirstOrDefault().IdSubPrograma);
            }
            else
            {
                UIHelper.ClearItems(ddlSubPrograma);
                ddlSubPrograma.Enabled = false;
            }
            CargarSectorialista();
        }
        private void CargarProcesos()
        {
            Int32 idTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);
            if (idTipoProyecto != 0)
            {
                UIHelper.Load<Proceso>(ddlProceso, ProcesoService.Current.GetList(new nc.ProcesoFilter() { IdProyectoTipo = idTipoProyecto, Activo = true }), "Nombre", "IdProceso", new Proceso() { IdProceso = 0, Nombre = "Seleccione Proceso" });
                //Matias 20170125 - Ticket #ER311422
                //Inserta, en caso que el TipoProyecto del Proyecto esta INACTIVO, el TipoProyecto en el ddlTipoProyecto
                if (Entity.proyecto.IdProceso != null && Entity.proyecto.IdProceso > 0)
                {
                    List<Contract.Proceso> procs = ProcesoService.Current.GetList(new nc.ProcesoFilter() { IdProyectoTipo = idTipoProyecto, Activo = false, IdProceso = Entity.proyecto.IdProceso.GetValueOrDefault() });
                    if (procs.Count > 0)
                        ddlProceso.Items.Add(new ListItem() { Value = procs[0].IdProceso.ToString(), Text = procs[0].Nombre.ToString() + " (INACTIVO)" });
                }
                //FinMatias 20170125 - Ticket #ER311422
                ddlProceso.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlProceso);
                ddlProceso.Enabled = false;
            }
        }
        private void CargarSectorialista()
        {
            Int32 IdPrograma = UIHelper.GetInt(ddlPrograma);
            if (IdPrograma == 0)
            {
                UIHelper.Clear(lbSectorialista);
                return;
            }
            Programa programa = ProgramaService.Current.GetById(IdPrograma);
            if (programa.IdSectorialista.HasValue && programa.IdSectorialista.Value != 0)
            {
                Persona persona = PersonaService.Current.GetList(new nc.PersonaFilter() { IdPersona = programa.IdSectorialista }).FirstOrDefault();
                UIHelper.SetValue(lbSectorialista, String.Format("{0} {1} | {2} | {3}", persona.Nombre, persona.Apellido, persona.TelefonoLaboral, persona.EMailLaboral));
            }
            else
                UIHelper.Clear(lbSectorialista);

        }
        private void DeshabilitarEdicionCombos()
        {
            bool Activar = CrudAction == CrudActionEnum.Create;
            ddlSAF.Enabled = Activar;
            ddlPrograma.Enabled = Activar;
            ddlSubPrograma.Enabled = Activar;

        }
        private OficinaResult GetOficinaUsuario()
        {
            return OficinaService.Current.GetResult(new nc.OficinaFilter() { IdOficina = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault();
        }

        #endregion

        #endregion

        #region Events
        protected void toIniciador_ValueChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeOficinaIniciador);
        }
        protected void toEjecutor_ValueChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeOficinaEjecutor);
        }
        protected void toResponsable_ValueChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeOficinaResponsable);
        }


        #endregion

        #region Private Methods
        private void ChangeOficinaIniciador()
        {
            Entity.proyectoOficinaPerfilFuncionarioIniciador = ProyectoService.Current.GetProyectoOficinaPerfilFuncionarioResult(UIHelper.GetInt(toIniciador));
            UIHelper.SetValue(dlFuncionarioIniciador, Entity.proyectoOficinaPerfilFuncionarioIniciador.OrderBy(i => i.Usuario_ApellidoYNombre));
            upFuncionariosIniciadorPopUp.Update();
        }
        private void ChangeOficinaEjecutor()
        {
            Entity.proyectoOficinaPerfilFuncionarioEjecutor = ProyectoService.Current.GetProyectoOficinaPerfilFuncionarioResult(UIHelper.GetInt(toEjecutor));
            UIHelper.SetValue(dlFuncionarioEjecutor, Entity.proyectoOficinaPerfilFuncionarioEjecutor.OrderBy(i => i.Usuario_ApellidoYNombre));
            upFuncionariosEjecutorPopUp.Update();
        }
        private void ChangeOficinaResponsable()
        {
            Entity.proyectoOficinaPerfilFuncionarioResponsable = ProyectoService.Current.GetProyectoOficinaPerfilFuncionarioResult(UIHelper.GetInt(toResponsable));
            UIHelper.SetValue(dlFuncionarioResponsable, Entity.proyectoOficinaPerfilFuncionarioResponsable.OrderBy(i => i.Usuario_ApellidoYNombre));
            upFuncionariosResponsablePopUp.Update();
        }
        #endregion

        #region Funcionarios
        protected void funcionario1_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosIniciador.Show();
        }
        protected void funcionario2_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosEjecutor.Show();
        }
        protected void funcionario3_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosResponsable.Show();
        }
        protected void btCancelFuncionariosEjecutor_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosEjecutor.Hide();
        }
        protected void btCancelFuncionariosResponsable_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosResponsable.Hide();
        }
        protected void btCancelFuncionariosIniciador_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderFuncionariosIniciador.Hide();
        }
        #endregion

        #region ProyectoOficinaPerfil

        #region Clear SetValue GetValue Refresh
        void ProyectoOficinaPerfilClear()
        {
            UIHelper.Clear(toIniciador);
            UIHelper.Clear(toEjecutor);
            UIHelper.Clear(toResponsable);
        }
        void ProyectoOficinaPerfilSetValue()
        {

            UIHelper.SetValue(toIniciador, Entity.proyectoOficinaPerfilIniciador.IdOficina);
            UIHelper.SetValue(toEjecutor, Entity.proyectoOficinaPerfilEjecutor.IdOficina);
            UIHelper.SetValue(toResponsable, Entity.proyectoOficinaPerfilResponsable.IdOficina);

        }
        void ProyectoOficinaPerfilGetValue()
        {
            Entity.proyectoOficinaPerfilIniciador.OficinaNode = UIHelper.GetNodeResult(toIniciador);
            Entity.proyectoOficinaPerfilEjecutor.OficinaNode = UIHelper.GetNodeResult(toEjecutor);
            Entity.proyectoOficinaPerfilResponsable.OficinaNode = UIHelper.GetNodeResult(toResponsable);
        }
        void ProyectoOficinaPerfilRefresh()
        {

        }
        #endregion

        #region Commands

        #endregion
        #region Events

        #endregion
        #endregion

        #region ProyectoPlan

        private ProyectoPlanResult actualProyectoPlan;
        protected ProyectoPlanResult ActualProyectoPlan
        {
            get
            {
                if (actualProyectoPlan == null)
                    if (ViewState["actualProyectoPlan"] != null)
                        actualProyectoPlan = ViewState["actualProyectoPlan"] as ProyectoPlanResult;
                    else
                    {
                        actualProyectoPlan = GetNewProyectoPlan();
                        ViewState["actualProyectoPlan"] = actualProyectoPlan;
                    }
                return actualProyectoPlan;
            }
            set
            {
                actualProyectoPlan = value;
                ViewState["actualProyectoPlan"] = value;
            }
        }
        ProyectoPlanResult GetNewProyectoPlan()
        {
            int id = 0;
            if (Entity.proyectoPlan.Count > 0) id = Entity.proyectoPlan.Min(o => o.IdProyectoPlan);
            if (id > 0) id = 0;
            id--;
            ProyectoPlanResult uopResult = new ProyectoPlanResult();
            ProyectoPlanService.Current.Set(ProyectoPlanService.Current.GetNew(), uopResult);
            uopResult.Activo = true;
            uopResult.IdProyectoPlan = id;
            return uopResult;
        }
        void HidePopUpProyectoPlan()
        {
            ModalPopupExtenderPlan.Hide();
            upDatosGenerales.Update();
        }
        void ShowPopUpProyectoPlan()
        {
            CargarPopUpPlanes();
            ModalPopupExtenderPlan.Show();
            upPlanPopUp.Update();
            //HabilitarControlesPlan();
        }

        #region Carga Dinamica PopUp Planes
        private void CargarPopUpPlanes()
        {
            if (!PopUpPlanesCargado)
            {
                //Matias 20170210 - Ticket #REQ653581
                //UIHelper.Load<nc.PlanTipo>(ddlTipoPopUp, PlanTipoService.Current.GetList(new nc.PlanTipoFilter() { Activo = true }).OrderBy(t => t.Orden).ToList(), "Sigla", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Sigla = "Seleccione Tipo de Plan" }, false);
                ListPaged<PlanTipo> lista = PlanTipoService.Current.GetPlanTipoPlanesActivosResult(new nc.PlanTipoFilter() { Activo = true} );
                UIHelper.Load<nc.PlanTipo>(ddlTipoPopUp, lista.OrderBy(t => t.Orden).ToList(), "Sigla", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Sigla = "Seleccione Tipo de Plan" }, false);
                if (lista.Count == 1)
                {
                    ddlTipoPopUp.SelectedValue = Convert.ToString(lista.FirstOrDefault().IdPlanTipo);
                }
                //FinMatias 20170210 - Ticket #REQ653581

                PopUpPlanesCargado = true;
            }
        }
        private bool? _PopUpPlanesCargado;
        protected bool PopUpPlanesCargado
        {
            get
            {
                if (_PopUpPlanesCargado == null)
                    if (ViewState["_PopUpPlanesCargado"] != null)
                    {
                        _PopUpPlanesCargado = ViewState["_PopUpPlanesCargado"] as bool?;
                    }
                    else
                    {
                        _PopUpPlanesCargado = false;
                        ViewState["_PopUpPlanesCargado"] = _PopUpPlanesCargado;
                    }
                return _PopUpPlanesCargado.Value;
            }
            set
            {
                _PopUpPlanesCargado = value;
                ViewState["_PopUpPlanesCargado"] = value;
            }
        }
        #endregion
        private void CargarControlesPlanes()
        {

            Int32 idPlanTipo = UIHelper.GetInt(ddlTipoPopUp);
            if (idPlanTipo == 0)
            {
                UIHelper.ClearItems(ddlPeriodoPopUp);
                ddlPeriodoPopUp.Enabled = false;
            }
            else
            {
                //Matias 20170210 - Ticket #REQ653581
                //UIHelper.Load<nc.PlanPeriodo>(ddlPeriodoPopUp, PlanPeriodoService.Current.GetList(new nc.PlanPeriodoFilter() { IdPlanTipo = idPlanTipo, Activo = true }).OrderByDescending(t => t.AnioInicial).ToList(), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Periodo" }, false); //ORIGINAL
                ListPaged<PlanPeriodo> lista = PlanPeriodoService.Current.GetPlanPeriodoPlanesActivosResult(new nc.PlanPeriodoFilter() { IdPlanTipo = idPlanTipo, Activo = true });
                UIHelper.Load<nc.PlanPeriodo>(ddlPeriodoPopUp, lista.OrderByDescending(t => t.AnioInicial).ToList(), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Periodo" }, false);
                if (lista.Count == 1)
                {
                    ddlPeriodoPopUp.SelectedValue = Convert.ToString(lista.FirstOrDefault().IdPlanPeriodo);
                    //Fuerzo el itemChange del ddlPeriodoPopUp
                    UIHelper.CallTryMethod(CargarControlesPeriodos);
                    ddlPeriodoPopUp.Focus();
                }
                //FinMatias 20170210 - Ticket #REQ653581
                ddlPeriodoPopUp.Enabled = true;
            }
        }
        private void CargarControlesPeriodos()
        {
            Int32 idPlanTipo = UIHelper.GetInt(ddlTipoPopUp);
            Int32 idPlanPeriodo = UIHelper.GetInt(ddlPeriodoPopUp);
            if (idPlanTipo == 0 || idPlanPeriodo == 0)
            {
                UIHelper.ClearItems(ddlVersionPopUp);
                ddlVersionPopUp.Enabled = false;
            }
            else
            {
                //Matias 20170210 - Ticket #REQ653581
                //UIHelper.Load<nc.PlanVersion>(ddlVersionPopUp, PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo, Activo = true, IdPlanPeriodoActivo = idPlanPeriodo }).OrderBy(t => t.Orden).ToList(), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Version" }, false);
                ListPaged<PlanVersion> lista = PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo, IdPlanPeriodoActivo = idPlanPeriodo, Activo = true });
                UIHelper.Load<nc.PlanVersion>(ddlVersionPopUp, lista.OrderBy(t => t.Orden).ToList(), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Version" }, false);
                if (lista.Count == 1)
                {
                    ddlVersionPopUp.SelectedValue = Convert.ToString(lista.FirstOrDefault().IdPlanVersion);
                }
                //FinMatias 20170210 - Ticket #REQ653581                
                ddlVersionPopUp.Enabled = true;
            }
        }
        private void ActualizarUltimoPlan()
        {
            //Matias 20170131 - Ticket #ER682004
            //ProyectoPlanResult ppr = Entity.proyectoPlan.FirstOrDefault();
            //if (ppr == null)
            //{
            //    UIHelper.Clear(lbPlan);
            //    return;
            //}
            //Entity.proyecto.IdProyectoPlan = ppr.IdProyectoPlan;
            //UIHelper.SetValue(lbPlan, String.Format("{0} {1} {2}", ppr.PlanTipo_Nombre, ppr.PlanPeriodo_Periodo, ppr.PlanVersion_Nombre));
            //upDatosGenerales.Update();

            ProyectoPlanResult ppr;
            
            if (Entity.proyectoPlan.Count == 0)
            {
                Entity.proyecto.IdProyectoPlan = null;
                UIHelper.Clear(lbPlan);
                return;
            }

            int IdProyectoPlanMAX = Entity.proyectoPlan.Max(ProyectoPlan => ProyectoPlan.IdProyectoPlan);
            int IdProyectoPlanMAX_New = Entity.proyectoPlan.Min(ProyectoPlan => ProyectoPlan.IdProyectoPlan);

            //if (IdProyectoPlanMAX == 0)
            //{
            //    UIHelper.Clear(lbPlan);
            //    return;
            //}
            
            //Tener en cuenta, por ej, si cargo 2 nuevos planes serán -1 y -2, con lo cual el último debería ser -2!!            
            if (IdProyectoPlanMAX_New < 0)
            {
                //Nuevo plan ingresado y aún no guardó lo cambios, entonces sería el Plan mas reciente.
                ppr = Entity.proyectoPlan.FirstOrDefault(ProyectoPlan => ProyectoPlan.IdProyectoPlan == IdProyectoPlanMAX_New);
            }
            else
            {
                ppr = Entity.proyectoPlan.FirstOrDefault(ProyectoPlan => ProyectoPlan.IdProyectoPlan == IdProyectoPlanMAX);
            }

            Entity.proyecto.IdProyectoPlan = ppr.IdProyectoPlan;
            UIHelper.SetValue(lbPlan, String.Format("{0} {1} {2}", ppr.PlanTipo_Nombre, ppr.PlanPeriodo_Periodo, ppr.PlanVersion_Nombre));
            upDatosGenerales.Update();
            //Matias 20170131 - Ticket #ER682004
            
        }
        //private void HabilitarControlesPlan()
        //{ 
        //    bool Habilitar = Entity.proyectoPlan.Count == 0 ;
        //    btAgregarPlan.Enabled = Habilitar;
        //    btGuardarPlan.Enabled = Habilitar;
        //}

        #region EventosGrillas

        protected void gridPlanPopUp_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoPlan = (from o in Entity.proyectoPlan where o.IdProyectoPlan == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoPlanEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoPlanDelete();
                    break;
            }

        }
        protected virtual void gridPlanPopUp_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridPlanPopUp.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void gridPlanPopUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridPlanPopUp.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #region Events

        protected void btSaveProyectoPlan_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoPlanSave);
            HidePopUpProyectoPlan();
        }
        protected void btNewProyectoPlan_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoPlanSave);
        }
        protected void btCancelProyectoPlan_Click(object sender, EventArgs e)
        {
            ProyectoPlanClear();
            HidePopUpProyectoPlan();
        }
        protected void btAgregarProyectoPlan_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpProyectoPlan);
        }
        protected void ddlTipoPupUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarControlesPlanes);
            ddlTipoPopUp.Focus();
        }
        protected void ddlPeriodoPopUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarControlesPeriodos);
            ddlPeriodoPopUp.Focus();
        }

        #endregion

        #region Commands
        void CommandProyectoPlanEdit()
        {
            ProyectoPlanSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoPlan);
        }
        void CommandProyectoPlanSave()
        {
            ProyectoPlanGetValue();
            ProyectoPlanResult result = (from o in Entity.proyectoPlan where o.IdProyectoPlan == ActualProyectoPlan.ID select o).FirstOrDefault();

            if (result != null)
            {
                result.IdPlanPeriodo = ActualProyectoPlan.IdPlanPeriodo;
                result.IdPlanVersion = ActualProyectoPlan.IdPlanVersion;
                result.Fecha = ActualProyectoPlan.Fecha;
                result.IdPlanTipo = ActualProyectoPlan.IdPlanTipo;
                result.PlanTipo_Nombre = ActualProyectoPlan.PlanTipo_Nombre;
                result.PlanVersion_Nombre = ActualProyectoPlan.PlanVersion_Nombre;
                result.PlanPeriodo_AnioInicial = actualProyectoPlan.PlanPeriodo_AnioInicial;
                result.PlanPeriodo_AnioFinal = actualProyectoPlan.PlanPeriodo_AnioFinal;
            }
            else
            {
                Entity.proyectoPlan.Add(ActualProyectoPlan);
            }
            ProyectoPlanClear();
            ProyectoPlanRefresh();
            ActualizarUltimoPlan();
        }
        void CommandProyectoPlanDelete()
        {
            ProyectoPlanResult result = (from o in Entity.proyectoPlan where o.IdProyectoPlan == ActualProyectoPlan.ID select o).FirstOrDefault();
            Entity.proyectoPlan.Remove(result);
            ProyectoPlanClear();
            ProyectoPlanRefresh();
            ActualizarUltimoPlan();
        }
        #endregion

        #region Clear SetValue GetValue Refresh
        void ProyectoPlanClear()
        {
            UIHelper.Clear(ddlTipoPopUp);
            UIHelper.ClearItems(ddlPeriodoPopUp);
            UIHelper.ClearItems(ddlVersionPopUp);
            ActualProyectoPlan = GetNewProyectoPlan();


        }
        void ProyectoPlanSetValue()
        {
            UIHelper.SetValue<PlanPeriodo, int>(ddlPeriodoPopUp, ActualProyectoPlan.IdPlanPeriodo, PlanPeriodoService.Current.GetById);
            UIHelper.SetValue<PlanVersion, int>(ddlVersionPopUp, ActualProyectoPlan.IdPlanVersion, PlanVersionService.Current.GetById);
            UIHelper.SetValue<PlanTipo, int>(ddlTipoPopUp, ActualProyectoPlan.IdPlanTipo, PlanTipoService.Current.GetById);
        }
        void ProyectoPlanGetValue()
        {
            ActualProyectoPlan.IdPlanPeriodo = UIHelper.GetInt(ddlPeriodoPopUp);
            ActualProyectoPlan.IdPlanVersion = UIHelper.GetInt(ddlVersionPopUp);
            ActualProyectoPlan.Fecha = DateTime.Now;
            ActualProyectoPlan.IdPlanTipo = UIHelper.GetInt(ddlTipoPopUp);
            ActualProyectoPlan.PlanTipo_Nombre = UIHelper.GetString(ddlTipoPopUp);
            ActualProyectoPlan.PlanVersion_Nombre = UIHelper.GetString(ddlVersionPopUp);
            PlanPeriodo ppr = PlanPeriodoService.Current.GetList(new nc.PlanPeriodoFilter() { IdPlanPeriodo = ActualProyectoPlan.IdPlanPeriodo }).SingleOrDefault();
            ActualProyectoPlan.PlanPeriodo_AnioInicial = ppr.AnioInicial;
            ActualProyectoPlan.PlanPeriodo_AnioFinal = ppr.AnioFinal;
            if (ActualProyectoPlan.Activo == null)
                ActualProyectoPlan.Activo = true;
        }
        void ProyectoPlanRefresh()
        {
            Entity.proyectoPlan = Entity.proyectoPlan.OrderBy(t => t.PlanTipo_Orden).ThenByDescending(t => t.PlanPeriodo_AnioInicial).ThenByDescending(t => t.PlanVersion_Orden).ToList();
            UIHelper.Load(gridPlanPopUp, Entity.proyectoPlan);
            //HabilitarControlesPlan();
            upPlanPopUp.Update();

        }
        #endregion


        #endregion

        #region ProyectoOrigenFinanciamiento

        private ProyectoOrigenFinanciamientoResult actualProyectoOrigenFinanciamiento;
        protected ProyectoOrigenFinanciamientoResult ActualProyectoOrigenFinanciamiento
        {

            get
            {
                if (actualProyectoOrigenFinanciamiento == null)
                    if (ViewState["actualProyectoOrigenFinanciamiento"] != null)
                        actualProyectoOrigenFinanciamiento = ViewState["actualProyectoOrigenFinanciamiento"] as ProyectoOrigenFinanciamientoResult;
                    else
                    {
                        actualProyectoOrigenFinanciamiento = GetNewProyectoOrigenFinanciamiento();
                        ViewState["actualProyectoOrigenFinanciamiento"] = actualProyectoOrigenFinanciamiento;
                    }
                return actualProyectoOrigenFinanciamiento;
            }
            set
            {

                actualProyectoOrigenFinanciamiento = value;
                ViewState["actualProyectoOrigenFinanciamiento"] = value;
            }
        }
        ProyectoOrigenFinanciamientoResult GetNewProyectoOrigenFinanciamiento()
        {
            int id = 0;
            if (Entity.proyectoOrigenFinanciamiento.Count > 0) id = Entity.proyectoOrigenFinanciamiento.Min(o => o.IdProyectoOrigenFinanciamiento);
            if (id > 0) id = 0;
            id--;
            ProyectoOrigenFinanciamientoResult uopResult = new ProyectoOrigenFinanciamientoResult();
            ProyectoOrigenFinanciamientoService.Current.Set(ProyectoOrigenFinanciamientoService.Current.GetNew(), uopResult);
            uopResult.IdProyectoOrigenFinanciamiento = id;
            return uopResult;
        }
        void HidePopUpProyectoOrigenFinanciamiento()
        {
            ModalPopupExtenderOrigenFinanciamiento.Hide();
        }
        void ShowPopUpProyectoOrigenFinanciamiento()
        {
            ModalPopupExtenderOrigenFinanciamiento.Show();
            upOrigenFinanciamientoPopUp.Update();
        }
        void BuscarOrigenFinanciamiento()
        {
            UIHelper.Clear(lblNombreOrigenFinanciamiento);
            Int32 codigo = UIHelper.GetInt(txtCodigoOrigenFinanciamiento);
            if (codigo == 0)
            //Matias 20140120 - Tarea 102
            {
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Préstamo válido"), upOrigenFinanciamientoPopUp);
                return;
            }
            //FinMatias 20140120 - Tarea 102
            if ((from o in this.Entity.proyectoOrigenFinanciamiento select o.OrigenCodigo).Contains(codigo))
            {
                UIHelper.ShowAlert(Translate("Nro Préstamo ya asociado"), upOrigenFinanciamientoPopUp);
                return;
            }

            //Matias 20170124 - Ticket #ER382869
            //List<nc.Prestamo> prestamol = PrestamoService.Current.GetList(new nc.PrestamoFilter() { Numero = codigo, UnicamentePorCodigo = true });
            //if (prestamol.Count == 0)
            nc.Prestamo prestamo = PrestamoService.Current.GetList(new nc.PrestamoFilter() { Numero = codigo, UnicamentePorCodigo = true }).FirstOrDefault();
            if (prestamo == null)
            //FinMatias 20170124 - Ticket #ER382869
            {
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Préstamo válido"), upOrigenFinanciamientoPopUp);
                return;
            }

            //Matias 20170124 - Ticket #ER382869
            if (!prestamo.Activo )
            {
                UIHelper.ShowAlert(Translate("El Nro Préstamo ingresado corresponde a un Préstamo inactivo"), upOrigenFinanciamientoPopUp);
                return;
            }
            //FinMatias 20170124 - Ticket #ER382869

            UIHelper.SetValue(lblNombreOrigenFinanciamiento, prestamo.Denominacion);
            ActualProyectoOrigenFinanciamiento.IdPrestamo = prestamo.IdPrestamo;
            ActualProyectoOrigenFinanciamiento.Prestamo_Numero = prestamo.Numero;
            ActualProyectoOrigenFinanciamiento.Prestamo_Denominacion = prestamo.Denominacion;
        }

        #region EventosGrillas

        protected void GridOrigenFinanciamiento_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoOrigenFinanciamiento = (from o in Entity.proyectoOrigenFinanciamiento where o.IdProyectoOrigenFinanciamiento == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoOrigenFinanciamientoEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoOrigenFinanciamientoDelete();
                    break;
            }

        }
        protected virtual void GridOrigenFinanciamiento_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridOrigenFinanciamiento.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridOrigenFinanciamiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridOrigenFinanciamiento.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #region Events

        protected void btSearchOrigenFinanciamiento_Click(object sender, EventArgs e)
        {
            CallTryMethod(BuscarOrigenFinanciamiento);
        }
        protected void btSaveProyectoOrigenFinanciamiento_Click(object sender, EventArgs e)
        {
            if (lblNombreOrigenFinanciamiento.Text != "")
            {
                CallTryMethod(CommandProyectoOrigenFinanciamientoSave);
                HidePopUpProyectoOrigenFinanciamiento();
            }
            else
                UIHelper.ShowAlert("Debe buscar el préstamo", upOrigenFinanciamientoPopUp);
        }
        protected void btNewProyectoOrigenFinanciamiento_Click(object sender, EventArgs e)
        {
            if (lblNombreOrigenFinanciamiento.Text != "")
            {
                UIHelper.CallTryMethod(CommandProyectoOrigenFinanciamientoSave);
            }
        }
        protected void btCancelProyectoOrigenFinanciamiento_Click(object sender, EventArgs e)
        {
            ProyectoOrigenFinanciamientoClear();
            HidePopUpProyectoOrigenFinanciamiento();
        }
        protected void btProyectoOrigenFinanciamienta_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpProyectoOrigenFinanciamiento);
        }


        #endregion

        #region Commands
        void CommandProyectoOrigenFinanciamientoEdit()
        {
            ProyectoOrigenFinanciamientoSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoOrigenFinanciamiento);
        }
        void CommandProyectoOrigenFinanciamientoSave()
        {
            ProyectoOrigenFinanciamientoGetValue();
            //ProyectoOrigenFinanciamientoResult result = (from o in Entity.proyectoOrigenFinanciamiento where o.IdProyectoOrigenFinanciamiento == ActualProyectoOrigenFinanciamiento.ID select o).FirstOrDefault();
            //if (result != null)
            //{
            //    result.IdProyectoOrigenFinancianmientoTipo = ActualProyectoOrigenFinanciamiento.IdProyectoOrigenFinancianmientoTipo;
            //    result.IdPrestamo = ActualProyectoOrigenFinanciamiento.IdPrestamo ;
            //    result.Prestamo_Numero  = ActualProyectoOrigenFinanciamiento.Prestamo_Numero ;
            //    result.Prestamo_Denominacion  = ActualProyectoOrigenFinanciamiento.Prestamo_Denominacion ;
            //}
            //else
            //{
            //    Entity.proyectoOrigenFinanciamiento.Add(ActualProyectoOrigenFinanciamiento);
            //}
            Entity.proyectoOrigenFinanciamiento.Add(ActualProyectoOrigenFinanciamiento);
            ProyectoOrigenFinanciamientoClear();
            ProyectoOrigenFinanciamientoRefresh();
        }
        void CommandProyectoOrigenFinanciamientoDelete()
        {
            ProyectoOrigenFinanciamientoResult result = (from o in Entity.proyectoOrigenFinanciamiento where o.IdProyectoOrigenFinanciamiento == ActualProyectoOrigenFinanciamiento.ID select o).FirstOrDefault();
            Entity.proyectoOrigenFinanciamiento.Remove(result);
            ProyectoOrigenFinanciamientoClear();
            ProyectoOrigenFinanciamientoRefresh();
        }
        #endregion

        #region Clear SetValue GetValue Refresh
        void ProyectoOrigenFinanciamientoClear()
        {
            UIHelper.Clear(txtCodigoOrigenFinanciamiento);
            UIHelper.Clear(lblNombreOrigenFinanciamiento);
            ActualProyectoOrigenFinanciamiento = GetNewProyectoOrigenFinanciamiento();
        }
        void ProyectoOrigenFinanciamientoSetValue()
        {
            UIHelper.SetValue(txtCodigoOrigenFinanciamiento, ActualProyectoOrigenFinanciamiento.IdPrestamo);
            UIHelper.SetValue(lblNombreOrigenFinanciamiento, ActualProyectoOrigenFinanciamiento.Prestamo_Denominacion);
        }
        void ProyectoOrigenFinanciamientoGetValue()
        {
            ActualProyectoOrigenFinanciamiento.IdProyectoOrigenFinancianmientoTipo = 1;
            ActualProyectoOrigenFinanciamiento.ProyectoOrigenFinancianmientoTipo_Nombre = "Préstamo"; //Matias 20170220 - Ticket #ER646848
            ActualProyectoOrigenFinanciamiento.Prestamo_Denominacion = UIHelper.GetString(lblNombreOrigenFinanciamiento);
            //BuscarOrigenFinanciamiento();
        }
        void ProyectoOrigenFinanciamientoRefresh()
        {
            // Agrupo los prestamos por numero de prestamo por si hay prestamos repetidos
            List<ProyectoOrigenFinanciamientoResult> proyectoGroupBys = Entity.proyectoOrigenFinanciamiento.GroupBy(proyecto => proyecto.Prestamo_Numero).ToList()
                .Select(origenFinanciamiento => new ProyectoOrigenFinanciamientoResult()
                {
                    IdProyectoOrigenFinanciamiento = origenFinanciamiento.Select(o => o.IdProyectoOrigenFinanciamiento).FirstOrDefault(),
                    ProyectoOrigenFinancianmientoTipo_Nombre = origenFinanciamiento.Select(o => o.ProyectoOrigenFinancianmientoTipo_Nombre).FirstOrDefault(),
                    Prestamo_Numero = origenFinanciamiento.Select(o => o.OrigenCodigo).FirstOrDefault(),
                    Prestamo_Denominacion = origenFinanciamiento.Select(o => o.Prestamo_Denominacion).FirstOrDefault(),
                    IdProyectoOrigenFinancianmientoTipo = origenFinanciamiento.Select(o => o.IdProyectoOrigenFinancianmientoTipo).FirstOrDefault()
                }).ToList();

            List<ProyectoOrigenFinanciamientoResult> transferencias = Entity.proyectoOrigenFinanciamiento.Where(o => o.IdProyectoOrigenFinancianmientoTipo == 2).ToList()
                .Select(origenFinanciamiento => new ProyectoOrigenFinanciamientoResult()
                {
                    IdProyectoOrigenFinanciamiento = origenFinanciamiento.IdProyectoOrigenFinanciamiento,
                    ProyectoOrigenFinancianmientoTipo_Nombre = origenFinanciamiento.ProyectoOrigenFinancianmientoTipo_Nombre,
                    Codigo = origenFinanciamiento.OrigenCodigo.ToString(),
                    IdTransferencia = origenFinanciamiento.OrigenCodigo,
                    CodigoTransferencia = origenFinanciamiento.OrigenCodigo.ToString(),
                    Transferencia_Denominacion = origenFinanciamiento.Transferencia_Denominacion,
                    IdProyectoOrigenFinancianmientoTipo = origenFinanciamiento.IdProyectoOrigenFinancianmientoTipo
                }).ToList();

            proyectoGroupBys = proyectoGroupBys.Where(o => o.IdProyectoOrigenFinancianmientoTipo == 1).Union(transferencias).ToList();

            UIHelper.Load(GridOrigenFinanciamiento, proyectoGroupBys);
            upGridOrigenFinanciamiento.Update();
        }
        #endregion

        #endregion

        #region Transferencia

        private List<TransferenciaResult> listTransferencias;
        protected List<TransferenciaResult> ListTransferencias
        {
            get
            {
                if (actualProyectoDemora == null)
                    if (ViewState["listTransferencias"] != null)
                        listTransferencias = ViewState["listTransferencias"] as List<TransferenciaResult>;
                    else
                    {
                        listTransferencias = new List<TransferenciaResult>();
                        ViewState["listTransferencias"] = listTransferencias;
                    }
                return listTransferencias;
            }
            set
            {
                listTransferencias = value;
                ViewState["listTransferencias"] = value;
            }
        }
        void HidePopUpProyectoOrigenFinanciamientoTransferencia()
        {
            ModalPopupExtenderTransferencia.Hide();
        }
        void ShowPopUpProyectoOrigenFinanciamientoTransferencia()
        {
            CargarPopUpTransferencia();
            ModalPopupExtenderTransferencia.Show();
            upTransferenciaPopUp.Update();
        }

        #region Events

        protected void btAgregarTransferencia_Click(object sender, EventArgs e)
        {
            CallTryMethod(ShowPopUpProyectoOrigenFinanciamientoTransferencia);
        }
        protected void btLimpiarProyectoOrigenFinanciamientoTransferencia_Click(object sender, EventArgs e)
        {
            ClearTransferencias();
        }
        protected void btCancelProyectoOrigenFinanciamientoTransferencia_Click(object sender, EventArgs e)
        {
            ClearTransferencias();
            HidePopUpProyectoOrigenFinanciamientoTransferencia();
        }
        protected void btBuscarProyectoOrigenFinanciamientoTransferencia_Click(object sender, EventArgs e)
        {
            TransferenciaFilter filter = new TransferenciaFilter();
            filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacionTransferencia);
            filter.IdClasificacionGeografica = UIHelper.GetIntNullable(ddlProvinciaTransferencia);
            filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccionTransferencia);
            filter.IdSaf = UIHelper.GetIntNullable(ddlSAFTransferencia);
            filter.IdPrograma = UIHelper.GetIntNullable(ddlProgramaTransferencia);
            filter.IdClasificacionGasto = UIHelper.GetIntNullable(ddlClasificacionGastoTransferencia); ;

            ListTransferencias = TransferenciaService.Current.GetResult(filter);
            UIHelper.Load(gridTransferencias, ListTransferencias);
            upGridTransferencias.Update();
        }
        protected void btAceptarProyectoOrigenFinanciamientoTransferencia_Click(object sender, EventArgs e)
        {
            CallTryMethod(CommandTransferenciasSave);
            //Matias 20141016 - Tarea 122
            //HidePopUpProyectoOrigenFinanciamientoTransferencia(); 
            //FinMatias 20141016 - Tarea 122
        }
        protected void ddlJurisdiccionTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallTryMethod(BuscarSafs);
            ddlJurisdiccionTransferencia.Focus();
        }
        protected void ddlSAFTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallTryMethod(BuscarProgramas);
            ddlSAFTransferencia.Focus();
        }

        #endregion

        #region Commands
        void CommandTransferenciasSave()
        {
            int[] keys = UIHelper.GetSelectedHtmlInputDataKeys<int>(gridTransferencias, "ItemCheckBox");
            if (keys.Count() < 1)
            {
                UIHelper.ShowAlert(Translate("Debe seleccionar al menos una transferencia de la lista."), upTransferenciaPopUp);
                return;
            }

            foreach (int item in keys)
            {
                if ((from o in this.Entity.proyectoOrigenFinanciamiento select o.OrigenCodigo).Contains(item))
                {
                    //ClearTransferencias(); //Matias 20141016 - Tarea 122
                    throw new ValidationException(Translate("- Código ya Asociado"));

                }
                TransferenciaResult transferenciaResult = (from o in ListTransferencias where o.IdTransferencia == item select o).FirstOrDefault();
                if (transferenciaResult != null)
                {
                    ProyectoOrigenFinanciamientoResult result = GetNewProyectoOrigenFinanciamiento();
                    result.CodigoTransferencia = transferenciaResult.Codigo;
                    result.IdProyectoOrigenFinancianmientoTipo = 2;
                    result.ProyectoOrigenFinancianmientoTipo_Nombre = "Transferencia";
                    result.Transferencia_Denominacion = transferenciaResult.Denominacion;
                    result.IdTransferencia = item;
                    Entity.proyectoOrigenFinanciamiento.Add(result);
                }
            }
            ClearTransferencias();
            ProyectoOrigenFinanciamientoRefresh();
            //Matias 20141016 - Tarea 122
            HidePopUpProyectoOrigenFinanciamientoTransferencia();
            //FinMatias 20141016 - Tarea 122
        }
        #endregion

        #region Metodos
        private void BuscarSafs()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccionTransferencia);
            if (idJurisdiccion == 0)
            {
                UIHelper.ClearItems(ddlSAFTransferencia);
                ddlSAFTransferencia.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.SafResult>(ddlSAFTransferencia, SafService.Current.GetResultFromList(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", Type.GetType("System.Int32"));

                ddlSAFTransferencia.Enabled = true;
            }
            BuscarProgramas();
        }
        private void BuscarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAFTransferencia);
            if (idSaf == 0)
            {
                UIHelper.ClearItems(ddlProgramaTransferencia);
                ddlProgramaTransferencia.Enabled = false;
            }
            else
            {
                UIHelper.Load<nc.ProgramaResult>(ddlProgramaTransferencia, ProgramaService.Current.GetResultFromList(new nc.ProgramaFilter() { IdSAF = idSaf }), "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" }, true, "CodigoInt", Type.GetType("System.Int32"));
                ddlProgramaTransferencia.Enabled = true;
            }
        }
        #endregion

        #region Clear SetValue GetValue Refresh
        private void ClearTransferencias()
        {
            ClearCombosAnidadosTransferencia();
            UIHelper.Clear(txtDenominacionTransferencia);
            UIHelper.Clear(ddlProvinciaTransferencia);
            UIHelper.Clear(gridTransferencias);
            ListTransferencias = new List<TransferenciaResult>();
            upTransferenciaPopUp.Update();
            upGridTransferencias.Update();
        }
        private void ClearCombosAnidadosTransferencia()
        {
            UIHelper.Clear(ddlJurisdiccionTransferencia);
            UIHelper.ClearItems(ddlSAFTransferencia);
            ddlSAFTransferencia.Enabled = false;
            UIHelper.ClearItems(ddlProgramaTransferencia);
            ddlProgramaTransferencia.Enabled = false;
        }
        void TransferenciaRefresh()
        {
            ProyectoOrigenFinanciamientoRefresh();
            HidePopUpProyectoOrigenFinanciamientoTransferencia();
        }
        #endregion

        #region Carga Dinamica PopUp Transferencia

        private void CargarPopUpTransferencia()
        {
            if (!PopUpTransferenciaCargado)
            {
                UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccionTransferencia, JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter()), "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" }, true, "CodigoInt", Type.GetType("System.Int32"));

                List<ClasificacionGeografica> cgr = ClasificacionGeograficaService.Current.GetList(new nc.ClasificacionGeograficaFilter { IdClasificacionGeograficaTipo = (int)ClasificacionGeograficaTipoEnum.Provincia }).ToList();
                UIHelper.Load<nc.ClasificacionGeografica>(ddlProvinciaTransferencia, cgr, "Nombre", "IdClasificacionGeografica", new ClasificacionGeografica() { IdClasificacionGeografica = 0, Codigo = "", Nombre = "- Seleccione Provincia" });

                List<ClasificacionGasto> cg = ClasificacionGastoService.Current.GetList(new nc.ClasificacionGastoFilter { IdClasificacionGastoTipo = 8 }).ToList();
                UIHelper.Load<nc.ClasificacionGasto>(ddlClasificacionGastoTransferencia, cg, "Nombre", "IdClasificacionGasto", new ClasificacionGasto() { IdClasificacionGasto = 0, Codigo = "", Nombre = "- Seleccione Objetivo del Gasto" });
                PopUpTransferenciaCargado = true;
            }
        }
        private bool? _PopUpTransferenciaCargado;
        protected bool PopUpTransferenciaCargado
        {
            get
            {
                if (_PopUpTransferenciaCargado == null)
                    if (ViewState["_PopUpTransferenciaCargado"] != null)
                    {
                        _PopUpTransferenciaCargado = ViewState["_PopUpTransferenciaCargado"] as bool?;
                    }
                    else
                    {
                        _PopUpTransferenciaCargado = false;
                        ViewState["_PopUpTransferenciaCargado"] = _PopUpTransferenciaCargado;
                    }
                return _PopUpTransferenciaCargado.Value;
            }
            set
            {
                _PopUpTransferenciaCargado = value;
                ViewState["_PopUpTransferenciaCargado"] = value;
            }
        }


        #endregion

        #endregion

        #region ProyectoRelacion
        private bool _relacionOK = true; //Matias 20141104 - Tarea 164
        private ProyectoRelacionResult actualProyectoRelacion;
        protected ProyectoRelacionResult ActualProyectoRelacion
        {
            get
            {
                if (actualProyectoRelacion == null)
                    if (ViewState["actualProyectoRelacion"] != null)
                        actualProyectoRelacion = ViewState["actualProyectoRelacion"] as ProyectoRelacionResult;
                    else
                    {
                        actualProyectoRelacion = GetNewProyectoRelacion();
                        ViewState["actualProyectoRelacion"] = actualProyectoRelacion;
                    }
                return actualProyectoRelacion;
            }
            set
            {
                actualProyectoRelacion = value;
                ViewState["actualProyectoRelacion"] = value;
            }
        }
        ProyectoRelacionResult GetNewProyectoRelacion()
        {
            int id = 0;
            if (Entity.proyectoRelacion.Count > 0) id = Entity.proyectoRelacion.Min(o => o.IdProyectoRelacion);
            if (id > 0) id = 0;
            id--;
            ProyectoRelacionResult uopResult = new ProyectoRelacionResult();
            ProyectoRelacionService.Current.Set(ProyectoRelacionService.Current.GetNew(), uopResult);
            uopResult.IdProyectoRelacion = id;
            return uopResult;
        }
        void HidePopUpProyectoRelacion()
        {
            ModalPopupExtenderProyectosRelacionados.Hide();
        }
        void ShowPopUpProyectoRelacion()
        {
            ModalPopupExtenderProyectosRelacionados.Show();
            upProyectosRelacionadosPopUp.Update();
        }
        void BuscarBapin()
        {
            _relacionOK = true;
            Int32 NroBapin = UIHelper.GetInt(txtBapinProyectosRelacionados);
            if (NroBapin == 0)
            {
                //Matias 20141103 - Tarea 164
                //throw new ValidationException("Debe Ingresar Un Nro Bapin Valido"); //Comentado - Va Original
                _relacionOK = false;
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Bapin válido"), upProyectosRelacionadosPopUp);
                return;
                //FinMatias 20141103 - Tarea 164                
            }
            if (NroBapin == Entity.proyecto.Codigo)
            {
                //Matias 20141103 - Tarea 164
                //throw new ValidationException("Debe Ingresar Un Nro Bapin Diferente al Proyecto actual"); //Original VA
                _relacionOK = false;
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Bapin diferente al Proyecto actual"), upProyectosRelacionadosPopUp);
                return;
                //FinMatias 20141103 - Tarea 164
            }
            nc.Proyecto proyecto = ProyectoService.Current.GetList(new nc.ProyectoFilter() { Codigo = NroBapin }).FirstOrDefault();
            if (proyecto == null)
            {
                //Matias 20141103 - Tarea 164
                //throw new ValidationException("Debe Ingresar Un Nro Bapin Valido");
                _relacionOK = false;
                UIHelper.ShowAlert(Translate("Debe ingresar un Nro Bapin válido"), upProyectosRelacionadosPopUp);
                return;
                //FinMatias 20141103 - Tarea 164
            }

            //Matias 20170124 - Ticket #ER382869
            if (!proyecto.Activo)
            {
                _relacionOK = false;
                UIHelper.ShowAlert(Translate("El Nro Bapin ingresado corresponde a un Proyecto inactivo"), upProyectosRelacionadosPopUp);
                return;
            }
            //FinMatias 20170124 - Ticket #ER382869

            UIHelper.SetValue(lbDenominacionProyectosRelacionados, proyecto.ProyectoDenominacion);
            ActualProyectoRelacion.IdProyectoRelacionado = proyecto.IdProyecto;
            ActualProyectoRelacion.ProyectoRelacionado_Codigo = proyecto.Codigo;
            ActualProyectoRelacion.ProyectoRelacionado_ProyectoDenominacion = proyecto.ProyectoDenominacion;

        }

        #region EventosGrillas

        protected void GridProyectosRelacionados_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoRelacion = (from o in Entity.proyectoRelacion where o.IdProyectoRelacion == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoRelacionEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoRelacionDelete();
                    break;
            }

        }
        protected virtual void GridProyectosRelacionados_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridProyectosRelacionados.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectosRelacionados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridProyectosRelacionados.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveProyectoRelacion_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoRelacionSave);
            if (_relacionOK)//Matias 20141103 - Tarea 164
                HidePopUpProyectoRelacion();
        }
        protected void btNewProyectoRelacion_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoRelacionSave);
        }
        protected void btCancelProyectoRelacion_Click(object sender, EventArgs e)
        {
            ProyectoRelacionClear();
            ActualProyectoRelacion = GetNewProyectoRelacion();
            HidePopUpProyectoRelacion();
        }
        protected void btAgregarProyectosRelacionados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpProyectoRelacion);
        }

        protected void txtBapinProyectosRelacionados_TextChanged(object sender, EventArgs e)
        {
            CallTryMethod(BuscarBapin);
            txtBapinProyectosRelacionados.Focus();
        }

        #endregion
        #region Commands
        void CommandProyectoRelacionEdit()
        {
            ProyectoRelacionSetValue();
            UIHelper.CallTryMethod(ShowPopUpProyectoRelacion);
        }
        void CommandProyectoRelacionSave()
        {
            ProyectoRelacionGetValue();
            if (_relacionOK)
            {
                ProyectoRelacionResult result = (from o in Entity.proyectoRelacion where o.IdProyectoRelacion == ActualProyectoRelacion.ID select o).FirstOrDefault();
                if (result != null)
                {
                    result.IdProyectoRelacionado = ActualProyectoRelacion.IdProyectoRelacionado;
                    result.IdProyectoRelacionTipo = ActualProyectoRelacion.IdProyectoRelacionTipo;
                    result.ProyectoRelacionado_Codigo = ActualProyectoRelacion.ProyectoRelacionado_Codigo;
                    result.ProyectoRelacionTipo_Nombre = ActualProyectoRelacion.ProyectoRelacionTipo_Nombre;
                    result.ProyectoRelacionado_ProyectoDenominacion = ActualProyectoRelacion.ProyectoRelacionado_ProyectoDenominacion;
                }
                else
                {
                    Entity.proyectoRelacion.Add(ActualProyectoRelacion);
                }
                ProyectoRelacionClear();
                ProyectoRelacionRefresh();
            }
        }
        void CommandProyectoRelacionDelete()
        {
            ProyectoRelacionResult result = (from o in Entity.proyectoRelacion where o.IdProyectoRelacion == ActualProyectoRelacion.ID select o).FirstOrDefault();
            Entity.proyectoRelacion.Remove(result);
            ProyectoRelacionClear();
            ProyectoRelacionRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoRelacionClear()
        {
            UIHelper.Clear(txtBapinProyectosRelacionados);
            UIHelper.Clear(ddlTipoRelacionProyectoRelacionado);
            UIHelper.Clear(lbDenominacionProyectosRelacionados);
            ActualProyectoRelacion = GetNewProyectoRelacion();
        }
        void ProyectoRelacionSetValue()
        {
            UIHelper.SetValue(txtBapinProyectosRelacionados, ActualProyectoRelacion.ProyectoRelacionado_Codigo);
            UIHelper.SetValue<ProyectoRelacionTipo, int>(ddlTipoRelacionProyectoRelacionado, ActualProyectoRelacion.IdProyectoRelacionTipo, ProyectoRelacionTipoService.Current.GetById);
            UIHelper.SetValue(lbDenominacionProyectosRelacionados, ActualProyectoRelacion.ProyectoRelacionado_ProyectoDenominacion);
        }
        void ProyectoRelacionGetValue()
        {

            ActualProyectoRelacion.IdProyectoRelacionTipo = UIHelper.GetInt(ddlTipoRelacionProyectoRelacionado);
            ActualProyectoRelacion.ProyectoRelacionTipo_Nombre = UIHelper.GetString(ddlTipoRelacionProyectoRelacionado);
            actualProyectoRelacion.ProyectoRelacionado_Codigo = UIHelper.GetInt(txtBapinProyectosRelacionados);
            BuscarBapin();
        }
        void ProyectoRelacionRefresh()
        {
            UIHelper.Load(GridProyectosRelacionados, Entity.proyectoRelacion);
            upGridProyectosRelacionados.Update();
        }
        #endregion


        #endregion

        #region ProyectoDemora
        private ProyectoDemoraResult actualProyectoDemora;
        protected ProyectoDemoraResult ActualProyectoDemora
        {
            get
            {
                if (actualProyectoDemora == null)
                    if (ViewState["actualProyectoDemora"] != null)
                        actualProyectoDemora = ViewState["actualProyectoDemora"] as ProyectoDemoraResult;
                    else
                    {
                        actualProyectoDemora = GetNewProyectoDemora();
                        ViewState["actualProyectoDemora"] = actualProyectoDemora;
                    }
                return actualProyectoDemora;
            }
            set
            {
                actualProyectoDemora = value;
                ViewState["actualProyectoDemora"] = value;
            }
        }
        ProyectoDemoraResult GetNewProyectoDemora()
        {
            int id = 0;
            if (Entity.proyectoDemora.Count > 0) id = Entity.proyectoDemora.Min(o => o.IdProyectoDemora);
            if (id > 0) id = 0;
            id--;
            ProyectoDemoraResult uopResult = new ProyectoDemoraResult();
            ProyectoDemoraService.Current.Set(ProyectoDemoraService.Current.GetNew(), uopResult);
            uopResult.IdProyectoDemora = id;
            return uopResult;
        }
        void HidePopUpProyectoDemora()
        {
            ModalPopupExtenderDemoras.Hide();
        }
        #region EventosGrillas

        protected void GridProyectoDemora_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualProyectoDemora = (from o in Entity.proyectoDemora where o.IdProyectoDemora == id select o).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoDemoraEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoDemoraDelete();
                    break;
            }

        }
        protected virtual void GridProyectoDemora_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridProyectoDemora.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoDemora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridProyectoDemora.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btDemoras_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderDemoras.Show();
        }
        protected void btSaveProyectoDemora_Click(object sender, EventArgs e)
        {
            if (this.diFechaDemora.Fecha == null)
            {
                UIHelper.ShowAlert("La fecha de demora no puede ser vacia", upDemorasPopUp);
                return;
            }

            UIHelper.CallTryMethod(CommandProyectoDemoraSave);
            HidePopUpProyectoDemora();
        }
        protected void btNewProyectoDemora_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoDemoraSave);
        }
        protected void btCancelProyectoDemora_Click(object sender, EventArgs e)
        {
            ProyectoDemoraClear();
            HidePopUpProyectoDemora();
        }
        //protected void btAgregarRolOficina_Click(object sender, EventArgs e)
        //{
        //    ModalPopupExtenderDemoras.Show();
        //    ddlOficinaPopUp.Focus();
        //}
        #endregion
        #region Commands
        void CommandProyectoDemoraEdit()
        {
            ProyectoDemoraSetValue();
            ModalPopupExtenderDemoras.Show();
        }
        void CommandProyectoDemoraSave()
        {
            ProyectoDemoraGetValue();
            ProyectoDemoraResult result = (from o in Entity.proyectoDemora where o.IdProyectoDemora == ActualProyectoDemora.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.Justificacion = ActualProyectoDemora.Justificacion;
                result.Fecha = ActualProyectoDemora.Fecha;
            }
            else
            {
                Entity.proyectoDemora.Add(ActualProyectoDemora);
            }
            ProyectoDemoraClear();
            ProyectoDemoraRefresh();
        }
        void CommandProyectoDemoraDelete()
        {
            ProyectoDemoraResult result = (from o in Entity.proyectoDemora where o.IdProyectoDemora == ActualProyectoDemora.ID select o).FirstOrDefault();
            Entity.proyectoDemora.Remove(result);
            ProyectoDemoraClear();
            ProyectoDemoraRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void ProyectoDemoraClear()
        {
            UIHelper.Clear(diFechaDemora);
            UIHelper.Clear(txtJustificacionDemora);
            ActualProyectoDemora = GetNewProyectoDemora();
        }
        void ProyectoDemoraSetValue()
        {
            UIHelper.SetValue(diFechaDemora, ActualProyectoDemora.Fecha);
            UIHelper.SetValue(txtJustificacionDemora, ActualProyectoDemora.Justificacion);
            upDemorasPopUp.Update();
        }
        void ProyectoDemoraGetValue()
        {
            ActualProyectoDemora.Fecha = UIHelper.GetDateTime(diFechaDemora);
            ActualProyectoDemora.Justificacion = UIHelper.GetString(txtJustificacionDemora);
        }
        void ProyectoDemoraRefresh()
        {
            UIHelper.Load(GridProyectoDemora, Entity.proyectoDemora);
            upGridProyectoDemora.Update();
        }
        #endregion
        #endregion

        #region Events

        #endregion

        #region Permissions

        protected bool EnablePlanUpdate
        {
            get
            {
                return Convert.ToBoolean(ViewState["EnablePlanUpdate"]);
            }
            set
            {
                ViewState["EnablePlanUpdate"] = value;
            }
        }

        protected bool EnablePlanCreate
        {
            get
            {
                return Convert.ToBoolean(ViewState["EnablePlanCreate"]);
            }
            set
            {
                ViewState["EnablePlanCreate"] = value;
            }
        }

        protected bool EnableDatosGenerales
        {
            get
            {
                return Convert.ToBoolean(ViewState["EnableDatosGenerales"]);
            }
            set
            {
                ViewState["EnableDatosGenerales"] = value;
            }
        }

        protected void SetPermissions()
        {
            if (CrudAction == CrudActionEnum.Create)
            {
                EnablePlanUpdate = false;
                EnablePlanCreate = false;
                EnableDatosGenerales = true;
            }
            else if (CrudAction == CrudActionEnum.Read)
            {
                EnablePlanUpdate = false;
                EnablePlanCreate = false;
                EnableDatosGenerales = false;
            }
            else
            {
                EnablePlanUpdate = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);
                EnablePlanCreate = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.CREATE, Entity.proyecto.IdEstado);
                EnableDatosGenerales = CanByOffice("ProyectoGeneralCompose", Entity.proyecto.PerfilOficinas, "ProyectoGeneralCompose_DatosGenerales", Entity.proyecto.IdEstado);

            }
            //Planes
            //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;
            this.btAgregarPlan.Enabled = EnablePlanUpdate;
            //this.btGuardarPlan.Enabled = EnablePlanCreate;
            //Datos Generales 
            this.pnlDatosGenerales.Enabled = EnableDatosGenerales;
            this.toEjecutor.Enabled = EnableDatosGenerales;
            this.toFinalidadFuncion.Enabled = EnableDatosGenerales;
            this.toIniciador.Enabled = EnableDatosGenerales;
            this.toResponsable.Enabled = EnableDatosGenerales;
            this.txtSituacionActual.Enabled = EnableDatosGenerales;
            this.txtDescripcion.Enabled = EnableDatosGenerales;
            this.txtObservaciones.Enabled = EnableDatosGenerales;
            this.btAgregarOrigenFinanciamiento.Enabled = EnableDatosGenerales;
            this.btAgregarTransferencia.Enabled = EnableDatosGenerales;
            this.btAgregarProyectosRelacionados.Enabled = EnableDatosGenerales;
            this.btDemoras.Enabled = EnableDatosGenerales;
        }



        #endregion

    }
}
