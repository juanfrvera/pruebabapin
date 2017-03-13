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
using UI.Web.Proyecto;
using System.Web.Services;
using System.IO;

namespace UI.Web
{
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public partial class ProyectoAlcanceGeograficoPageEdit : ProyectoPageEditTabPanel<nc.ProyectoAlcanceGeograficoCompose>
    {

        #region Override
        protected override void _Load()
        {
            webControlEdit = this.editProyectoAlcanceGeografico;
            webControlEditionButtons = this.editButtons;
            webControlConfirm = this.confirmarAccion;
            webControlPageTabPanel = this.proyectoTabPanel;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoHead; ;
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
        protected override IEntityService<nc.ProyectoAlcanceGeograficoCompose, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return ProyectoAlcanceGeograficoComposeService.Current; }
        }
        protected override void _SetPermissions()
        {
            base._SetPermissions();
            bool enableUpdate = false;
            if (CrudAction == CrudActionEnum.Create)
                enableUpdate = true;
            else if (CrudAction != CrudActionEnum.Read)
            {
                enableUpdate = CanByOffice("ProyectoAlcanceGeograficoCompose", Entity.Proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.Proyecto.IdEstado);

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

            if (Entity.Localizaciones.Count > 0) this.webControlPaggingInPage.RefreshPagging(Entity.Localizaciones.Count);
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[1].Controls[3].Controls[0].Controls[1]).DataSource = Entity.Localizaciones;
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[1].Controls[3].Controls[0].Controls[1]).DataBind();

            if (Entity.Alcances.Count > 0) this.webControlPaggingInPage.RefreshPagging(Entity.Alcances.Count);
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[7].Controls[3].Controls[0].Controls[1]).DataSource = Entity.Alcances;
            ((System.Web.UI.WebControls.GridView)webControlEdit.Controls[7].Controls[3].Controls[0].Controls[1]).DataBind();
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

        public static ProyectoResult ObtenerProyecto(int idProyecto)
        {

            ProyectoFilter proyectoFilter = new ProyectoFilter();
            proyectoFilter.Filter.Codigo = idProyecto;
            return ProyectoService.Current.GetProyecto(proyectoFilter.Filter);
        }
        
        [System.Web.Services.WebMethod]
        public static string SaveGeoLocations(ProyectoGeoLocalizacion[] geolocalizacion, int codigoBapin)
        {
            try
            {
                // Primero Creo el contexto para realizar operaciones en la base de datos
                IContextUser contextUser = UIContext.Current.ContextUser;

                // Almaceno el archivo o los archivos shapes si los hubiera
                ProyectoAlcanceGeograficoPageEdit.SaveShapeFile(codigoBapin, contextUser);

                //EL ID DE PROYECTO RECIBIDO ES EN REALIDAD EL CODIGO DE BAPIN
                //con este codigo buscar el proyecto para obtener el id del mismo y ese
                //es el valor que se insertara en la tabla de geolocalizacion

                string respuesta = "Datos almacenados correctamente";

                //primero elimino los registros existentes para este proyecto en caso de que haya alguno
                // Seteo un filtro para la eliminacion de los registros
                ProyectoGeoLocalizacionFilter setFilter = new ProyectoGeoLocalizacionFilter();
                ProyectoResult proyectoABorrar = ProyectoAlcanceGeograficoPageEdit.ObtenerProyecto(codigoBapin);
                setFilter.IdProyecto = proyectoABorrar.IdProyecto;

                ProyectoGeoLocalizacionService.Current.Delete(setFilter, contextUser);

                // recorro las localizaciones creadas en el mapa para ir guardandolas en la base
                foreach (ProyectoGeoLocalizacion localizacion in geolocalizacion)
                {
                    //primero busco el proyecto para obtener su ID
                    ProyectoResult proyecto = ProyectoAlcanceGeograficoPageEdit.ObtenerProyecto(codigoBapin);

                    //una vez obtenido el id, lo seteo en el campo idProyecto del objeto localizacion
                    localizacion.IdProyecto = proyecto.IdProyecto;

                    // Grabo la geolocalizacion en la base de datos
                    ProyectoGeoLocalizacionService.Current.Add(localizacion, contextUser);
                }

                return respuesta;
            }
            catch (Exception excepcion)
            {
                return excepcion.Message;
            }


        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        public static List<ProyectoGeoLocalizacionResult> GetGeoLocations(int codigoBapin)
        {

            //primero busco el proyecto para obtener su ID
            ProyectoResult proyecto = ProyectoAlcanceGeograficoPageEdit.ObtenerProyecto(codigoBapin);

            //busco las geolocalizaciones que tenga ese proyecto
            ProyectoGeoLocalizacionFilter localizacionFilter = new ProyectoGeoLocalizacionFilter();
            localizacionFilter.IdProyecto = proyecto.IdProyecto;
            List<ProyectoGeoLocalizacionResult> geoLocalizaciones = ProyectoGeoLocalizacionService.Current.GetProyectoGeoLocalizaciones(localizacionFilter);

            return geoLocalizaciones;
        }

        [System.Web.Services.WebMethod]
        public static void SaveShapeFile(int codigoBapin, IContextUser contextUser)
        {
            //primero elimino los registros existentes para este proyecto en caso de que haya alguno
            // Seteo un filtro para la eliminacion de los registros
            ProyectoShapeFileFilter setFilter = new ProyectoShapeFileFilter();
            ProyectoResult proyecto = ProyectoAlcanceGeograficoPageEdit.ObtenerProyecto(codigoBapin);
            setFilter.IdProyecto = proyecto.IdProyecto;

            ProyectoShapeFileService.Current.Delete(setFilter, contextUser);

            // Busco en la carpeta shape file la lista de archivos que tengan el codigo del proyecto actual
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists(currentPath + @"ShapesFiles\"))
            {
                // Obtengo todos los archivos que tenga el proyecto actual
                string[] filePaths = Directory.GetFiles(currentPath + @"ShapesFiles\", "*" + codigoBapin.ToString() + "*");

                //verifico si obtuvo algun archivo, si trae alguno, lo grabo en la base
                if (filePaths.Count() > 0)
                {
                    foreach (string file in filePaths)
                    {

                        ProyectoShapeFile shapeFile = new ProyectoShapeFile();

                        shapeFile.IdProyecto = proyecto.IdProyecto;
                        shapeFile.RutaArchivo = file;

                        // Grabo el shapefile en la base de datos
                        ProyectoShapeFileService.Current.Add(shapeFile, contextUser);
                    }
                }

            }
            
        }

        [System.Web.Services.WebMethod]
        public static string VisualizarShape(int codigoBapin)
        {
            // Primero Creo el contexto para realizar operaciones en la base de datos
            IContextUser contextUser = UIContext.Current.ContextUser;

            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string filenameReturn = string.Empty;
            if (Directory.Exists(currentPath + @"ShapesFiles\"))
            {
                // Seteo un filtro para obtener el shape asociado al proyecto
                ProyectoShapeFileFilter setFilter = new ProyectoShapeFileFilter();
                ProyectoResult proyecto = ProyectoAlcanceGeograficoPageEdit.ObtenerProyecto(codigoBapin);
                setFilter.IdProyecto = proyecto.IdProyecto;

                // Obtengo los archivos shapes que tenga el proyecto actual
               List<ProyectoShapeFileResult> listaShapes = ProyectoShapeFileService.Current.GetShapes(setFilter);

               foreach (ProyectoShapeFileResult proyectoShale in listaShapes)
               {
                   string[] pathsArray = proyectoShale.RutaArchivo.Split('\\');
                   filenameReturn = pathsArray[pathsArray.Length - 1];
               }
            }

            return filenameReturn;
        }
    }
}
