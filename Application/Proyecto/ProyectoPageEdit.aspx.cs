using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public abstract partial class ProyectoPageEditTabPanel<TEntity> : PageEditTabPanel<TEntity, nc.ProyectoFilter, ProyectoResult, int>
        where TEntity : class, new()
    {
        #region Properties
        private ProyectoResult proyecto;
        public ProyectoResult Proyecto
        {
            get
            {
                if (proyecto == null) proyecto = GetProyecto();
                return proyecto;
            }
            set { proyecto = value; }
        }
        protected abstract ProyectoResult GetProyecto();
        #endregion

        #region Override
        public override PageBehaviour PageBehaviour
        {
            get
            {
                pageBehaviour = base.PageBehaviour;
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour() { ConfirmOnPageChange = true };
                return pageBehaviour;
            }
        }

        protected override void _SetParameters()
        {
            PathListPage = "ProyectoPageList.aspx";
            EditFilter = "ProyectoFilter";
            base._SetParameters();
        }

        protected override List<PageLinkData> GetTabUrls()
        {
            bool ProyectoCronogramaRead = CanByOffice("ProyectoCronogramaCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoAlcanceGeograficoRead = CanByOffice("ProyectoAlcanceGeograficoCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoCalidadRead = CanByOffice("ProyectoCalidadCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoFilesRead = CanByOffice("ProyectoFilesCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoIntervencionDNIPComposeRead = CanByOffice("ProyectoIntervencionDNIPCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoEvaluacionRead = CanByOffice("ProyectoEvaluacionCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoProductoIntermedioRead = CanByOffice("ProyectoProductoIntermedioCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            bool ProyectoObjetivosRead = CanByOffice("ProyectoObjetivosCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);
            //TODO: modificar por ProyectoPrincipiosCompose
            bool ProyectoPrincipiosRead = CanByOffice("ProyectoObjetivosCompose", Proyecto.PerfilOficinas, ActionConfig.READ, Proyecto.IdEstado);

            List<PageLinkData> urls = new List<PageLinkData>();
            urls.Add(new PageLinkData() { Text = "Generales", Url = "~/Proyecto/ProyectoPageEdit.aspx", IsNewVisible = true });

            //if (ProyectoAlcanceGeograficoRead) urls.Add(new PageLinkData() { Text = "Alcance Geográfico", Url = "~/Proyecto/ProyectoAlcanceGeograficoPageEdit.aspx" });
            if (ProyectoPrincipiosRead) urls.Add(new PageLinkData() { Text = "Principios Conceptuales de Formulación", Url = "~/Proyecto/ProyectoPrincipiosPageEdit.aspx" });
            //if (ProyectoObjetivosRead) urls.Add(new PageLinkData() { Text = "Objetivos", Url = "~/Proyecto/ProyectoObjetivosPageEdit.aspx" });            
            //if (ProyectoProductoIntermedioRead) urls.Add(new PageLinkData() { Text = "Producto Intermedio", Url = "~/Proyecto/ProyectoProductoIntermedioPageEdit.aspx" });
            if (ProyectoCronogramaRead) urls.Add(new PageLinkData() { Text = "Cronograma", Url = "~/Proyecto/ProyectoCronogramaPageEdit.aspx" });
            if (ProyectoEvaluacionRead) urls.Add(new PageLinkData() { Text = "Evaluación", Url = "~/Proyecto/ProyectoEvaluacionPageEdit.aspx" });
            if (ProyectoFilesRead) urls.Add(new PageLinkData() { Text = "Información complementaria", Url = "~/Proyecto/ProyectoAdjuntarPageList.aspx" });
            //if (ProyectoCalidadRead) urls.Add(new PageLinkData() { Text = "Calidad", Url = "~/Proyecto/ProyectoCalidadPageEdit.aspx" });
            if (ProyectoIntervencionDNIPComposeRead) urls.Add(new PageLinkData() { Text = "Interv. DNIP", Url = "~/Proyecto/ProyectoDNIPPageEdit.aspx" });

            return urls;
        }

        protected override ProyectoResult GetHeadResult()
        {
            return Proyecto;
        }

        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        #endregion

    }
    public partial class ProyectoPageEdit : ProyectoPageEditTabPanel<nc.ProyectoGeneralCompose>
    {
        #region Override
        protected override void _Load()
        {
            webControlEdit = this.editProyecto;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.proyectoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoHead;
            ucImprimirProyecto.ControlCommand += new ControlCommandHandler(ControlCommand);

            base._Load();

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoResult GetProyecto()
        {
            return Entity.proyecto;
        }
        protected ProyectoComposeService Service
        {
            get { return ProyectoComposeService.Current; }
        }
        protected override IEntityService<nc.ProyectoGeneralCompose, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return ProyectoComposeService.Current; }
        }
        protected override void AddNew()
        {
            ProyectoResult example = CommandValue as ProyectoResult;
            if (example == null && Entity != null && Entity.proyecto != null && Entity.proyecto.IdProyecto > 0)
                example = new ProyectoResult() { IdOficina_Usuario = ContextUser.User.Persona_IdOficina };
            Entity = (example != null) ? Service.GetNew(example) : Service.GetNew();
        }
        protected override void _SetPermissions()
        {
            base._SetPermissions();
            bool enableUpdate = false;
            if (CrudAction == CrudActionEnum.Create)
                enableUpdate = true;
            else if (CrudAction != CrudActionEnum.Read)
            {
                enableUpdate = CanByOffice("ProyectoGeneralCompose", Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);

                if (this.Entity.proyecto != null)
                {
                    //Verifico lo mismo que en el filtro de inversion para chequear si el bapin se puede editar o no
                    enableUpdate = this.HabilitarEdicion() & this.HabilitarOpciones();
                }
            }
            webControlEditionButtons.EnableSave = enableUpdate;
            webControlEditionButtons.EnableAplicate = enableUpdate;
            webControlEditionButtons.EnableDelete = enableUpdate;
            webControlEditionButtons.EnableSaveAndNew = enableUpdate;

        }

        protected override void CommandOthers()
        {
            base.CommandOthers();
            switch (CommandName)
            {
                case Command.SHOW_POPUP_PRINT:
                    ShowPrint(CommandValue);
                    break;
                case Command.PRINT:
                    Print();
                    break;
                //Matias 20170201 - Ticket #REQ571729
                //case Command.GENERATE_HISTORYCOPY:
                //    GenerateHistoryCopy();
                //    break;
                //FinMatias 20170201 - Ticket #REQ571729
            }
        }

        #endregion

        #region Private Methods
        
        //Matias 20170201 - Ticket #REQ571729
        //void GenerateHistoryCopy()
        //{
        //    entity.proyecto.GenerateHistoryCopy = true;
        //}        
        //FinMatias 20170201 - Ticket #REQ571729

        void ShowPrint(object CommandValue)
        {
            ActualPopupId = "ucImprimirProyecto";
            ucImprimirProyecto.Visible = true;
            ucImprimirProyecto.CommandValue = Entity.proyecto.IdProyecto.ToString();
            ucImprimirProyecto.CommandName = Command.PRINT;
            ucImprimirProyecto.ShowPopup();
        }
        protected void Print()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Proyecto", Activo = true });
            if (Report != null)
            {
                Filter.printFilter = ucImprimirProyecto.Filtro;

                ReportInfo reportInfo = ProyectoService.Current.GetReport(Report.IdSistemaReporte, Filter);
                //ReportViewerManager.SaveReportExcel(reportInfo);

                //ShowDownLoadExport();         
                SetParameter(PathReportPage, PARAMETER_ACTION, CommandName);
                SetParameter(PathReportPage, PARAMETER_VALUE, reportInfo);
                //Response.Redirect(PathReportPage, false);
                ShowPrintExport();
            }
        }

        protected bool HabilitarEdicion()
        {
            bool retorno = true;
            // busco el proyecto del usuario
            ProyectoResult item = this.Entity.proyecto;

            // busco los datos del usuario logueado
            ContextUser contexto = (ContextUser)Session["contextUser"];
            List<UsuarioOficinaPerfilSimpleResult> perfilesOficina = contexto.PerfilesPorOficina.ToList();

            // verifico si el usuario logueado es administrador

            bool esAdministrador = (contexto.Perfiles.Where(perf => perf.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;

            if (esAdministrador)
                return retorno = true;

            //Matias 20170126 - Ticket #ER645535
            if (perfilesOficina.Count == 0)
                return retorno = false;
            //FinMatias 20170126 - Ticket #ER645535

            foreach (UsuarioOficinaPerfilSimpleResult perfil in perfilesOficina)
            {
                // Primero verifico si el usuario logueado tiene tildado solo hereda consulta
                if (perfil.HeredaConsulta && !perfil.HeredaEdicion)
                {
                    // Verifico si el proyecto actual tiene alguna oficina (en oficinas y funcionarios) que coincida con la oficina del usuario logueado
                    if (item.PerfilOficinas.Count > 0)
                    {
                        PerfilOficina perf = item.PerfilOficinas.Where(p => p.IdOficina == perfil.IdOficina).FirstOrDefault();

                        // Si no tiene ninguna, deshabilito las opciones de edicion, eliminacion y copiar
                        if (perf == null) // chequear las oficinas hijas q tiene habilitadas
                            retorno = false;
                    }
                    else
                    {
                        //Matias 20170202 - Ticket #270112
                        // Este ELSE es para tratar de resolver el BUG al momento de guardar un proyecto por primera vez.
                        // Hay un bug que hace que, luego de guardar por PRIMERA VEZ, no levante las oficinas vinculadas al proyecto.
                        // Busco las oficinas en la BD.
                        Contract.ProyectoFilter pf = new Contract.ProyectoFilter();
                        pf.IdProyecto = item.IdProyecto;
                        PerfilOficina perfilOficina = ((ProyectoService.Current.GetResultWithOfficePerfil(pf).FirstOrDefault()).PerfilOficinas).Where(p => p.IdOficina == perfil.IdOficina && (p.IdPerfil == 4/*Iniciador*/ || p.IdPerfil == 6/*Responsable*/)).FirstOrDefault();

                        if (perfilOficina == null)
                            retorno = false;
                        //FinMatias 20170202 - Ticket #270112
                    }
                }
                else
                    retorno = true;
            }

            return retorno;

        }

        public bool HabilitarOpciones()
        {
            ProyectoResult item = this.Entity.proyecto;
            ContextUser contexto = (ContextUser)Session["contextUser"];
            UsuarioOficinaPerfilSimpleResult perfilOficina = contexto.PerfilesPorOficina.Where(perfil => perfil.AccesoTotal == true).FirstOrDefault();

            bool esAdministrador = (contexto.Perfiles.Where(perfil => perfil.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;

            bool retorno = true;
            bool AccesoTotal = (perfilOficina == null) ? false : perfilOficina.AccesoTotal;

            //busco el estado de decision
            int idEstadoDesicion = (item.IdEstadoDeDesicion == null) ? 0 : item.IdEstadoDeDesicion.Value;

            EstadoDeDesicion estadoDesicion = EstadoDeDesicionService.Current.GetById(idEstadoDesicion);

            string EstadoDesecion = (estadoDesicion == null) ? string.Empty : estadoDesicion.Nombre;

            if ((string.Compare(EstadoDesecion, "POSTULADO", true) == 0 ||
               string.Compare(EstadoDesecion, "CONFORMADO", true) == 0 ||
                string.Compare(EstadoDesecion, "OBSERVADO", true) == 0) && !AccesoTotal && !esAdministrador)
            {
                retorno = false;
            }

            return retorno;
        }

        #endregion


    }
}
