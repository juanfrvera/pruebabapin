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

    public partial class ProyectoList : WebControlGrid<nc.ProyectoResult, int>
    {

        public override GridView GridView { get { return this.Grid; } }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }

        #region Can
        public override bool CanById(object id, string actionName)
        {
            ProyectoResult item = GetItem(ConvertId(id));
            if (item == null) return false;

            if (!PageBase.CanByOffice(item.PerfilOficinas, actionName, item.IdEstado)) return false;

            /* Matias 20161206 - Comente todo lo nuevo agregado por Rodrigo para analizar de cero este tema
            // busco el estado de decision
            int idEstadoDesicion = (item.IdEstadoDeDesicion == null) ? 0 : item.IdEstadoDeDesicion.Value;

            EstadoDeDesicion estadoDesicion = EstadoDeDesicionService.Current.GetById(idEstadoDesicion);

            // busco los datos del usuario logueado
            ContextUser contexto = (ContextUser)Session["contextUser"];

            if (string.Compare(actionName, "Reiniciar", true) == 0 && contexto.User.AccesoTotal)
                return true;
            //Matias 20161202
            else
            {
                if (string.Compare(actionName, "Reiniciar", true) == 0)
                {
                    bool esAdmin = (contexto.Perfiles.Where(perfil => perfil.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;
                    UsuarioOficinaPerfilSimpleResult perfilOficina = contexto.PerfilesPorOficina.Where(perfil => perfil.AccesoTotal == true).FirstOrDefault();
                    bool accesoTotal    = (perfilOficina == null) ? false : perfilOficina.AccesoTotal;
                    bool esAprobador    = (contexto.PerfilesPorOficina.Where(perfil => perfil.Perfil_Codigo == "AP").FirstOrDefault() != null) ? true : false; 
                    bool esPostulador   = (contexto.PerfilesPorOficina.Where(perfil => perfil.Perfil_Codigo == "PP").FirstOrDefault() != null) ? true : false;
                    bool esConformador  = (contexto.PerfilesPorOficina.Where(perfil => perfil.Perfil_Codigo == "PC").FirstOrDefault() != null) ? true : false;

                    if (esPostulador || esConformador)
                        return false;
                }                
            }
            //FinMatias
            
            if (estadoDesicion != null)
            {
                //Matias 20161207 - Modificar para que se pueda REINICIAR desde cualquier estado (menos desde el REINICIADO)
                //if (string.Compare(estadoDesicion.Nombre, "Reiniciado") != 0 && string.Compare(actionName, "Reiniciar", true) == 0 && contexto.User.AccesoTotal)
                //    return true;
                if (string.Compare(estadoDesicion.Nombre, "Reiniciado") != 0 && string.Compare(actionName, "Reiniciar", true) == 0)
                    return true;
                //FinMatias

                if (string.Compare(estadoDesicion.Nombre, "Aceptado", true) == 0 && string.Compare(actionName, "REINICIAR", true) == 0) 
                    return true;

                if (string.Compare(estadoDesicion.Nombre, "Reiniciado", true) == 0 && (string.Compare(actionName, "Postular", true) == 0 ||
                    string.Compare(actionName, "Conformar", true) == 0 || string.Compare(actionName, "Aceptar", true) == 0))
                    return true;

            }
             * FinMatias
            */

            return ProyectoService.Current.Can(item, actionName, UIContext.Current.ContextUser);
            //No habilitaba nada
            //return CanByResult(item, actionName);            
        }

        public override string VerificarEstadoDecision(object id, string actionName, string actionNameCurret)
        {
            ProyectoResult item = GetItem(ConvertId(id));
            if (item == null) return string.Empty;

            EstadoDeDesicion estadoDeDesicion = SolutionContext.Current.EstadoDeDesicionCache.GetByCode(actionNameCurret);

            //busco el estado de decision
            int idEstadoDesicion = (item.IdEstadoDeDesicion == null) ? 0 : item.IdEstadoDeDesicion.Value;

            EstadoDeDesicion estadoDesicion = EstadoDeDesicionService.Current.GetById(idEstadoDesicion);


            if (idEstadoDesicion == estadoDeDesicion.IdEstadoDeDesicion)
                return "Estado Actual: " + actionNameCurret;

            // busco los datos del usuario logueado
            ContextUser contexto = (ContextUser)Session["contextUser"];

            if (string.Compare(actionName, "Reiniciar", true) == 0 && contexto.User.AccesoTotal)
                return actionName;
            //Matias 20161202
            else
            {
                if (string.Compare(actionName, "Reiniciar", true) == 0)
                {
                    bool esPostulador = (contexto.PerfilesPorOficina.Where(perfil => perfil.Perfil_Codigo == "PP").FirstOrDefault() != null) ? true : false;
                    bool esConformador = (contexto.PerfilesPorOficina.Where(perfil => perfil.Perfil_Codigo == "PC").FirstOrDefault() != null) ? true : false;

                    if (esPostulador || esConformador)
                        return "Estado No disponible";
                }
            }
            //FinMatias

            if (estadoDesicion != null)
            {
                if (string.Compare(estadoDesicion.Nombre, "Reiniciado") != 0 && string.Compare(actionName, "Reiniciar", true) == 0 && contexto.User.AccesoTotal)
                    return actionName;

                if (string.Compare(estadoDesicion.Nombre, "Aceptado", true) == 0 && string.Compare(actionName, "REINICIAR", true) == 0)
                    return actionName;

                if (string.Compare(estadoDesicion.Nombre, "Reiniciado", true) == 0 && (string.Compare(actionName, "Postular", true) == 0 ||
                    string.Compare(actionName, "Conformar", true) == 0 || string.Compare(actionName, "Aceptar", true) == 0))
                    return actionName;
            }

            if (!ProyectoService.Current.Can(item, actionName, UIContext.Current.ContextUser))
                return "Estado No disponible";

            return actionName;
        }

        /*Matias - Original de Rodrigo (lo usa en Estados de Decision.
        public override bool HideButtonStates(object id, string actionName)
        {
            ProyectoResult item = GetItem(ConvertId(id));
            if (!PageBase.CanByOffice(item.PerfilOficinas, actionName, item.IdEstado)) return false;

            return true;

        }
        */

        public bool HabilitarOpciones(object id)
        {
            ProyectoResult item = GetItem(ConvertId(id));
            ContextUser contexto = (ContextUser)Session["contextUser"];
            UsuarioOficinaPerfilSimpleResult perfilOficina = contexto.PerfilesPorOficina.Where(perfil => perfil.AccesoTotal == true).FirstOrDefault();

            bool esAdministrador = (contexto.Perfiles.Where(perfil => perfil.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;

            bool retorno = true;
            bool AccesoTotal = (perfilOficina == null) ? false : perfilOficina.AccesoTotal;

            //busco el estado de decision
            int idEstadoDesicion = (item.IdEstadoDeDesicion == null) ? 0 : item.IdEstadoDeDesicion.Value;

            EstadoDeDesicion estadoDesicion = EstadoDeDesicionService.Current.GetById(idEstadoDesicion);

            string EstadoDesecion = (estadoDesicion == null) ? string.Empty : estadoDesicion.Nombre;

            if ((   string.Compare(EstadoDesecion, "POSTULADO", true) == 0 ||
                    string.Compare(EstadoDesecion, "CONFORMADO", true) == 0 ||
                    string.Compare(EstadoDesecion, "OBSERVADO", true) == 0      ) 
                    && !AccesoTotal && !esAdministrador)
            {
                retorno = false;
            }

            return retorno;
        }

        public bool HabilitarEdicion(object id)
        {
            bool retorno = true;
            // busco el proyecto del usuario
            ProyectoResult item = GetItem(ConvertId(id));

            // busco los datos del usuario logueado
            ContextUser contexto = (ContextUser)Session["contextUser"];
            List<UsuarioOficinaPerfilSimpleResult> perfilesOficina = contexto.PerfilesPorOficina.ToList();

            // verifico si el usuario logueado es administrador

            bool esAdministrador = (contexto.Perfiles.Where(perf => perf.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;

            if (esAdministrador)
                return retorno = true;

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

                // Corroborar con CONSTANZA la verificacion del programa del proyecto con los programas que figuren en 
                // OficinaSafPrograma y si no coincide, deshabilitar las opciones de edicion, eliminacion y copia

            }

            return retorno;

        }

        #endregion

        #region Overrides

        protected override void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string[] ActividadObra = e.Row.Cells[9].Text.Split('.');

                if (ActividadObra.Length == 3)
                {
                    if (ActividadObra[1] != "00" & ActividadObra[2] != "00")
                    {
                        string actividad = ActividadObra[0] + "." + ActividadObra[1] + ".00";
                        string obra = ActividadObra[0] + ".00." + ActividadObra[2];

                        e.Row.Cells[9].Text = obra + "\n\t" + actividad;
                    }
                }

            }
        }

        #endregion
    }
}
