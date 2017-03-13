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
    public partial class ProyectoAdjuntarPageList : ProyectoPageEditTabPanel<nc.ProyectoFilesCompose>
    {
        #region Override
        protected override void _Load()
        {
            webControlEdit = this.editProyectoAdjuntar;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPaggingInPage = this.paggingInPage;
            webControlPageTabPanel = this.proyectoTabPanel;
            webControlHead = this.proyectoHead;
            base._Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
        }
        protected override ProyectoResult GetProyecto()
        {
            return Entity.Proyecto;
        }
        protected ProyectoService Service
        {
            get { return ProyectoService.Current; }
        }
        protected override IEntityService<nc.ProyectoFilesCompose, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return ProyectoFilesComposeService.Current; }
        }
        protected override void _SetPermissions()
        {
            base._SetPermissions();
            bool enableUpdate = false;
            if (CrudAction == CrudActionEnum.Create)
                enableUpdate = true;
            else if (CrudAction != CrudActionEnum.Read)
            {
                enableUpdate = CanByOffice("ProyectoFilesCompose", Entity.Proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.Proyecto.IdEstado);

                //en relación al bug de páginado del 2016-11-28 | Agregado por Diego DB 2016-05-12
                if (this.Entity.Proyecto != null)
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

        protected override void RefreshList()
        {
            base.RefreshList();
            //SetParameter(FilterKey, Filter);

            if (Entity.ProyectoFiles.Count > 0) this.webControlPaggingInPage.RefreshPagging(Entity.ProyectoFiles.Count);
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[1].Controls[3].Controls[0].Controls[1]).DataSource = Entity.ProyectoFiles;
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[1].Controls[3].Controls[0].Controls[1]).DataBind();
        }

        #endregion



        //Agregado para corrección de páginado De acerudo a bug del 2016-11-28
        //Modificado por Diego DB 2016-05-12
        //Funciones: HabilitarEdicion(), HabilitarOpciones()
        protected bool HabilitarEdicion()
        {
            bool retorno = true;
            // busco el proyecto del usuario
            ProyectoResult item = this.Entity.Proyecto;

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
                    PerfilOficina perf = item.PerfilOficinas.Where(p => p.IdOficina == perfil.IdOficina).FirstOrDefault();

                    // Si no tiene ninguna, deshabilito las opciones de edicion, eliminacion y copiar
                    if (perf == null) // chequear las oficinas hijas q tiene habilitadas
                        retorno = false;

                }
                else
                    retorno = true;
            }

            return retorno;

        }

        public bool HabilitarOpciones()
        {
            ProyectoResult item = this.Entity.Proyecto;
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
    }
}