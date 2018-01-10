using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Web.UI.WebControls;
using System.Collections;

namespace Business
{
    public class ProyectoBusiness : _ProyectoBusiness
    {
        #region Singleton
        private static volatile ProyectoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoBusiness() {}
        public static ProyectoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        #region Gets
        public override Proyecto GetNew(ProyectoResult example)
        {
            return base.GetNew(example);
        }
        public virtual ListPaged<ProyectoResult> GetResultWithOfficePerfil(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = GetResult(filter);
            LoadPerfilOficinas(result);
            return result;
        }
        public virtual ListPaged<ProyectoResult> GetResultFromListWithOfficePerfil(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = GetResultFromList(filter);
            LoadPerfilOficinas(result);
            return result;
        }

        public virtual void LoadPerfilOficinas(ListPaged<ProyectoResult> result)
        {
            List<int> ids = (from o in result select o.IdProyecto).ToList();
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfiles = ProyectoOficinaPerfilData.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdsProyecto = ids });
            result.ForEach(p => p.PerfilOficinas = (from o in proyectoOficinaPerfiles where o.IdProyecto == p.IdProyecto select new PerfilOficina() { IdOficina = o.IdOficina, IdPerfil = o.IdPerfil, Oficina_BreadcrumbId = o.Oficina_BreadcrumbId }).ToList());
        }

        //Matias 20140512 - Tarea 133
        public virtual ListPaged<ProyectoResult> GetResultGraficos(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficos(filter));
            //LoadPerfilOficinas(result); German 20130731 - Tarea 79 - Corrige bug por parametros > 2100
            return result;
            //return new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficos(filter));
        }
        public virtual ListPaged<ProyectoResult> GetResultGraficosLocalizaciones(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficosLocalizacion(filter));
            //LoadPerfilOficinas(result); German 20130731 - Tarea 79 - Corrige bug por parametros > 2100
            return result;
            //return new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficos(filter));
        }
        public virtual ListPaged<ProyectoResult> GetResultGraficosPrestamos(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficosPrestamos(filter));
            //LoadPerfilOficinas(result); German 20130731 - Tarea 79 - Corrige bug por parametros > 2100
            return result;
            //return new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficos(filter));
        }
        public virtual ListPaged<ProyectoResult> GetResultGraficosLocalizacionesPartido(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficosLocalizacionPartido(filter));
            //LoadPerfilOficinas(result); German 20130731 - Tarea 79 - Corrige bug por parametros > 2100
            return result;
        }
        //FinMatias 20140512 - Tarea 133
        //Matias 20141014 - Tarea 158
        public virtual ListPaged<ProyectoResult> GetResultGraficosProvincia(ProyectoFilter filter)
        {
            ListPaged<ProyectoResult> result = new ListPaged<ProyectoResult>(ProyectoData.Current.QueryResultGraficosProvincia(filter));
            return result;
        }
        public virtual ProyectoResult GetProyecto(ProyectoFilter filter)
        {
            ProyectoResult result = ProyectoData.Current.QueryResultIdProyecto(filter);
            return result;
        }
        //FinMatias 20141014 - Tarea 158

        public virtual ListPaged<ProyectoResult> GetResultSP(ProyectoFilter filter)
        {
            return ProyectoData.Current.QuerySP(filter);
        }
        #endregion

        #region Actions

        //private static readonly Object obj = new Object();//Matias 20161025 - Variable para implementar LOCK en CodigoBAPIN

        public override void Add(Proyecto entity, IContextUser contextUser)
        {            
            entity.FechaAlta = DateTime.Now;
            entity.FechaModificacion = DateTime.Now;
            int nroNotification;
            //lock (obj) //Matias 20161025 - Variable para implementar LOCK en Codigo BAPIN
            //{
            nroNotification = NumerationBusiness.Current.GetNext(NumerationConfig.PROYECTO_NRO_BAPIN);
            //}
            entity.Codigo = nroNotification;
            entity.IdUsuarioModificacion = contextUser.User.IdUsuario;
            base.Add(entity, contextUser);
        }
        //Matias 20131106 - Tarea 80
        public void UpdateFechaModificacion(ProyectoResult proyecto, IContextUser contextUser)
        {
            Proyecto proy = ProyectoBusiness.Current.GetById(proyecto.ID);
            ProyectoBusiness.Current.Set(proyecto, proyecto);
            ProyectoBusiness.Current.Update(proy, contextUser);
        }


        public void updateFechaUltimaModificacion(int id, IContextUser contextUser)
        {
            ProyectoData.Current.updateFechaUltimaModificacion(id, contextUser);
        }
        //FinMatias 20131106 - Tarea 80
        public override void Update(Proyecto entity, IContextUser contextUser)
        {
            entity.FechaModificacion = DateTime.Now;
            entity.IdUsuarioModificacion = contextUser.User.IdUsuario;
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Validate(ProyectoResult result, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(result, actionName, contextUser, args);
        }
        public override void Delete(int id, IContextUser contextUser)
        {
            //Matias 20170123 - Ticket #ER382869
            
            Proyecto proyecto = ProyectoBusiness.Current.GetById(id);

            bool esAdministrador = (contextUser.Perfiles.Where(perf => perf.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;

            if (!esAdministrador)
            {
                //Tiene marca Plan o Demanda?
                if (proyecto.ProyectoPlans.Count > 0) //(proyecto.IdProyectoPlan != null ) || 
                    throw new Exception("No es posible eliminar este Proyecto (tiene asociado Planes o Demandas).");

                //Monto real cargado?
                decimal? totalRealizado = 0;
                foreach (ProyectoEtapa pe in proyecto.ProyectoEtapas)
                {
                    foreach (ProyectoEtapaRealizado per in pe.ProyectoEtapaRealizados)
                    {
                        foreach (ProyectoEtapaRealizadoPeriodo perp in per.ProyectoEtapaRealizadoPeriodos)
                        {
                            totalRealizado += perp.MontoCalculado;
                        }
                    }
                }
                if (totalRealizado > 0)
                    throw new Exception("No es posible eliminar este Proyecto (tiene cargado gastos dentro del Cronograma de Gastos Realizados).");

                //Asociado a un préstamo?
                if (proyecto.PrestamoProductos.Count > 0)
                    throw new Exception("No es posible eliminar este Proyecto (se encuentra asociado al Producto de un Préstamo).");

                //Vinculado a otro proyecto?
                if (proyecto.ProyectoRelacions.Count > 0)
                    throw new Exception("No es posible eliminar este Proyecto (se encuentra asociado como Proyecto Relacionado de otro Proyecto).");

                //Tiene evaluacion de factibilidad realizada?
                if (proyecto.ProyectoSeguimientoProyectos.Count > 0)
                    throw new Exception("No es posible eliminar este Proyecto (tiene ingresada una Evaluación de Factibilidad).");
            }

            proyecto.Activo = false;
            ProyectoBusiness.Current.Update(proyecto, contextUser);
            SendMessageEliminacionProyecto(proyecto, contextUser);            

            //FinMatias 20170123 - Ticket #ER382869


            /*
            ProyectoDemoraBusiness.Current.Delete(new ProyectoDemoraFilter() { IdProyecto = id }, contextUser);
            ProyectoOrigenFinanciamientoBusiness.Current.Delete(new ProyectoOrigenFinanciamientoFilter() { IdProyecto = id }, contextUser);
            ProyectoPlanBusiness.Current.Delete(new ProyectoPlanFilter() { IdProyecto = id }, contextUser);
            ProyectoRelacionBusiness.Current.Delete(new ProyectoRelacionFilter() { IdProyecto = id }, contextUser);
            base.Delete(id, contextUser);
             **/
        }


        public void CambiarEstadoDeDesicion(Proyecto entity, string estadoCodigo, IContextUser contextUser, Hashtable args)
        {
            EstadoDeDesicion estadoDeDesicion = SolutionContext.Current.EstadoDeDesicionCache.GetByCode(estadoCodigo);
            DataHelper.Validate(estadoDeDesicion != null, "No existe el código de estado:{0}", estadoCodigo);
            Proyecto proyecto = GetById(entity.IdProyecto);

            // Si el estado de decision actual es reiniciado, seteo el mismo en NULL para que vuelva a comenzar el ciclo completo desde POSTULAR
            //proyecto.IdEstadoDeDesicion = (string.Compare(estadoDeDesicion.Nombre, "Reiniciado") == 0) ? EstadoIdentificacionNulo : estadoDeDesicion.IdEstadoDeDesicion;
            proyecto.IdEstadoDeDesicion = estadoDeDesicion.IdEstadoDeDesicion;
            Data.Update(proyecto);

            EstadoDeDesicionHistorico historico = EstadoDeDesicionHistoricoBusiness.Current.GetNew();
            historico.IdProyecto = proyecto.IdProyecto;
            historico.IdEstadoDeDesicion = estadoDeDesicion.IdEstadoDeDesicion;
            historico.IdUsuario = contextUser.User.IdUsuario;
            historico.Fecha = DateTime.Now;
            historico.Observacion = (args != null && args.ContainsKey("Observacion")) ? args["Observacion"].ToString() : "";
            EstadoDeDesicionHistoricoBusiness.Current.Add(historico, contextUser);
        }

        #endregion

        #region ChangeStructure
        public void ChangeStructure(int[] ids, CambioEstructuraDestino cambio, IContextUser contextUser)
        {
            ChangeStructure(new ProyectoFilter() { Ids = new List<int>(ids) }, cambio, contextUser);
        }
        public void ChangeStructure(ProyectoFilter filter, CambioEstructuraDestino cambio, IContextUser contextUser)
        {
            ChangeStructure(GetList(filter), cambio, contextUser);
        }
        public void ChangeStructure(List<Proyecto> entities, CambioEstructuraDestino cambio, IContextUser contextUser)
        {
            List<SubPrograma> subProgramas = new List<SubPrograma>();
            SubPrograma subPrograma;
            Perfil perfilIniciador = null;
            Perfil perfilEjecutor = null;
            Perfil perfilResponsable = null;

            if (cambio.IdOficinaIniciador > 0)
                perfilIniciador = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "INIC" });
            if (cambio.IdOficinaEjecutor > 0)
                perfilEjecutor = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "EJEC" });
            if (cambio.IdOficinaResponsable > 0)
                perfilResponsable = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "RESP" });

            foreach (Proyecto entity in entities)
            {
                if (cambio.IdSubPrograma > 0)
                {
                    //Se hace para no hacer tantas llamadas para buscar los SubProgramas
                    subPrograma = (from o in subProgramas where o.IdSubPrograma == entity.IdSubPrograma select o).FirstOrDefault();
                    if (subPrograma == null)
                    {
                        subPrograma = SubProgramaBusiness.Current.GetById(entity.IdSubPrograma);
                        subProgramas.Add(subPrograma);
                    }
                    //si cambia de programa elimina los proyecto-programa anteriores
                    if (cambio.IdPrograma > 0 && subPrograma.IdPrograma != cambio.IdPrograma)
                        ProyectoFinBusiness.Current.Delete(new ProyectoFinFilter() { IdProyecto = entity.IdProyecto }, contextUser);
                    //asigna el nuevo subprograma
                    entity.IdSubPrograma = cambio.IdSubPrograma;
                    //guada los cambios          
                    Update(entity, contextUser);
                }
                if (perfilIniciador != null)
                {
                    foreach (ProyectoOficinaPerfil pop in ProyectoOficinaPerfilBusiness.Current.GetList(new ProyectoOficinaPerfilFilter() { IdProyecto = entity.IdProyecto, IdPerfil = perfilIniciador.IdPerfil }))
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(pop, contextUser);
                    }
                    ProyectoOficinaPerfil proyectoOficinaPerfil = ProyectoOficinaPerfilBusiness.Current.GetNew();
                    proyectoOficinaPerfil.IdProyecto = entity.IdProyecto;
                    proyectoOficinaPerfil.IdPerfil = perfilIniciador.IdPerfil;
                    proyectoOficinaPerfil.IdOficina = cambio.IdOficinaIniciador;
                    ProyectoOficinaPerfilBusiness.Current.Add(proyectoOficinaPerfil, contextUser);
                }
                if (perfilEjecutor != null)
                {
                    foreach (ProyectoOficinaPerfil pop in ProyectoOficinaPerfilBusiness.Current.GetList(new ProyectoOficinaPerfilFilter() { IdProyecto = entity.IdProyecto, IdPerfil = perfilEjecutor.IdPerfil }))
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(pop, contextUser);
                    }
                    ProyectoOficinaPerfil proyectoOficinaPerfil = ProyectoOficinaPerfilBusiness.Current.GetNew();
                    proyectoOficinaPerfil.IdProyecto = entity.IdProyecto;
                    proyectoOficinaPerfil.IdPerfil = perfilEjecutor.IdPerfil;
                    proyectoOficinaPerfil.IdOficina = cambio.IdOficinaEjecutor;
                    ProyectoOficinaPerfilBusiness.Current.Add(proyectoOficinaPerfil, contextUser);

                }
                if (perfilResponsable != null)
                {
                    foreach (ProyectoOficinaPerfil pop in ProyectoOficinaPerfilBusiness.Current.GetList(new ProyectoOficinaPerfilFilter() { IdProyecto = entity.IdProyecto, IdPerfil = perfilResponsable.IdPerfil }))
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(pop, contextUser);
                    }
                    ProyectoOficinaPerfil proyectoOficinaPerfil = ProyectoOficinaPerfilBusiness.Current.GetNew();
                    proyectoOficinaPerfil.IdProyecto = entity.IdProyecto;
                    proyectoOficinaPerfil.IdPerfil = perfilResponsable.IdPerfil;
                    proyectoOficinaPerfil.IdOficina = cambio.IdOficinaResponsable;
                    ProyectoOficinaPerfilBusiness.Current.Add(proyectoOficinaPerfil, contextUser);
                }

            }

        }
        #endregion

        #region CopyAndSave
        public override int CopyAndSave(int id, IContextUser contextUser)
        {
            string renameFormat = Translate("Copia de", contextUser) + " {0}";
            return CopyAndSave(id, renameFormat, contextUser);
        }
        public override int CopyAndSave(Proyecto entity, string rename, IContextUser contextUser)
        {
            return CopyAndSave(GetId(entity), rename, contextUser);
        }
        public override int CopyAndSave(Proyecto entity, IContextUser contextUser)
        {
            string renameFormat = Translate("Copia de", contextUser) + " {0}";
            return CopyAndSave(GetId(entity), renameFormat, contextUser);
        }
        public override int CopyAndSave(int id, string rename, IContextUser contextUser)
        {
            return ProyectoGeneralComposeBusiness.Current.CopyAndSave(id, rename, contextUser);
        }
        public int CopyAndSave(int id, ProyectCopy proyectoCopy, IContextUser contextUser)
        {
            int idProject = ProyectoGeneralComposeBusiness.Current.CopyAndSaveProyecto(id, proyectoCopy, contextUser);
            if (proyectoCopy.Solapas.AlcanceGeografico) ProyectoAlcanceGeograficoComposeBusiness.Current.CopyAndSave(id, idProject, contextUser);
            if (proyectoCopy.Solapas.Objetivos) ProyectoObjetivosComposeBusiness.Current.CopyAndSave(id, idProject, contextUser);
            if (proyectoCopy.Solapas.Cronograma)
            {
                ProyectoProductoIntermedioCompose proyectoProductoIntermedioCompose = ProyectoProductoIntermedioComposeBusiness.Current.CopyProyectoProductoIntermedio(id, idProject, proyectoCopy.Offset, contextUser);
                ProyectoCronogramaComposeBusiness.Current.CopyProyectoCronogramaCompose(id, idProject, proyectoCopy.Offset, proyectoProductoIntermedioCompose, contextUser);
            }
            if (proyectoCopy.Solapas.Evaluacion) ProyectoEvaluacionComposeBusiness.Current.CopyAndSave(id, idProject, contextUser);
            return idProject;
        }
        public ProyectoResult CopyProyecto(ProyectoResult source, ProyectCopy proyectoCopy, IContextUser contextUser)
        {
            Estado estadoIdea = EstadoBusiness.Current.FirstOrDefault(new EstadoFilter() { Codigo = EstadoConfig.IDEA });

            ProyectoResult target = new ProyectoResult();
            target.IdProyecto = 0;
            target.Activo = source.Activo;
            target.IdTipoProyecto = source.IdTipoProyecto;
            target.IdSubPrograma = source.IdSubPrograma;
            target.Codigo = source.Codigo;
            target.ProyectoDenominacion = string.Format(proyectoCopy.Rename, source.ProyectoDenominacion);
            target.ProyectoSituacionActual = "";//source.ProyectoSituacionActual;
            target.ProyectoDescripcion = source.ProyectoDescripcion;
            target.ProyectoObservacion = "";//source.ProyectoObservacion;
            if (estadoIdea != null)
                target.IdEstado = estadoIdea.IdEstado;// source.IdEstado;
            target.IdProceso = source.IdProceso;
            target.IdModalidadContratacion = source.IdModalidadContratacion;
            target.IdFinalidadFuncion = source.IdFinalidadFuncion;
            target.IdOrganismoPrioridad = null;// source.IdOrganismoPrioridad;
            target.SubPrioridad = null;//source.SubPrioridad;
            target.EsBorrador = false;//source.EsBorrador;
            target.EsProyecto = false;// source.EsProyecto;
            target.NroProyecto = null;// source.NroProyecto;
            target.AnioCorriente = null;// source.AnioCorriente;
            if (source.FechaInicioEjecucionCalculada.HasValue)
                target.FechaInicioEjecucionCalculada = source.FechaInicioEjecucionCalculada.Value.AddYears(proyectoCopy.Offset);
            if (target.FechaFinEjecucionCalculada.HasValue)
                target.FechaFinEjecucionCalculada = source.FechaFinEjecucionCalculada.Value.AddYears(proyectoCopy.Offset); ;
            target.FechaAlta = DateTime.Now;
            target.FechaModificacion = DateTime.Now;
            target.IdUsuarioModificacion = contextUser.User.IdUsuario;
            //target.IdProyectoPlan = source.IdProyectoPlan;
            //target.IdSAF 
            //target.IdPrograma 
            //target.RequiereDictamen
            //target.IdPrioridad 
            //target.IdOficina_Usuario
            //target.Programa_Nombre 
            //target.Programa_Codigo 
            //target.Saf_Nombre 
            //target.Saf_Codigo 
            //target.Saf_Jurisdiccion 
            //target.Programa_IdSectorialista 
            //target.Estado_IdEstadoTipo 
            //target.Plan_Nombre 

            return target;
        }
        #endregion

        #region Reports
        public List<ProyectoReportResult> GetProyectoReport(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReport(filter);
        }
        public List<ProyectoReportJurisdiccionResult> GetReportProyectoJurisdiccion(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportJurisdiccion(filter);
        }
        public List<ProyectoReportProvinciaResult> GetReportProyectoProvincia(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportProvincia(filter);
        }
        //Matias 20131107 - Tarea 72
        public List<ProyectoReportFuenteFinanciamientoResult> GetReportProyectoFuenteFinanciamientoPorTipo(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportFuenteFinanciamientoPorTipo(filter);
        }
        //FinMatias 20131107 - Tarea 72
        public List<ProyectoReportFuenteFinanciamientoResult> GetReportProyectoFuenteFinanciamiento(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportFuenteFinanciamiento(filter);
        }
        public List<ProyectoReportTipoProyectoResult> GetReportProyectoTipoProyecto(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportTipoProyecto(filter);
        }
        public List<ProyectoReportFinalidadFuncionResult> GetReportProyectoFinalidadFuncion(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetReportFinalidadFuncion(filter);
        }

        public override ReportInfo GetReport(SistemaReporte reporte, ProyectoFilter filter)
        {
            ReportInfo reportInfo = new ReportInfo();
            //Matias 20131107 - Tarea 72 - Agrega "if"
            //reportInfo.ReportFileName = reporte.FileName; Unica sentencia original.
            if (filter.reportFilter != null && filter.reportFilter.SoloEstimados == null && !reporte.Codigo.Equals("Proyecto"))
                reportInfo.ReportFileName = reporte.FileName.Replace(".rdlc", "") + "PorTotal.rdlc";
            else
                reportInfo.ReportFileName = reporte.FileName;
            //FinMatias 20131107 - Tarea 72
            reportInfo.Title = reporte.Nombre;

            switch (reporte.Codigo)
            {
                case "FinanlidadFunción":
                    CargarReporteFinalidadFuncion(reportInfo, filter);
                    break;
                case "FuenteFinanciamiento":
                    CargarReporteFuenteFinanciamiento(reportInfo, filter);
                    break;
                case "Provincia":
                    CargarReporteProvincia(reportInfo, filter);
                    break;
                case "TipoProyecto":
                    CargarReporteTipoProyecto(reportInfo, filter);
                    break;
                case "Jurisdiccion":
                    CargarReporteJurisdiccion(reportInfo, filter);
                    break;
                case "Proyecto":
                    Imprimir(reportInfo, filter);
                    break;
            }
            return reportInfo;
        }
        public override void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, ProyectoFilter filter, IContextUser contextUser)
        {
            if (reporte.Codigo == "Proyecto")
            {//Esto es por que el Reporte de Proyecto que deberia ser por Entidad esta hecho por Filtro
                ReportInfo reportInfo = GetReport(reporte, filter);
                if (reportInfo == null) return;
                SistemaReporteHistorico sistemaReporteHistorico = SistemaReporteHistoricoBusiness.Current.GetNew();
                sistemaReporteHistorico.IdSistemaReporte = reporte.IdSistemaReporte;
                sistemaReporteHistorico.Fecha = DateTime.Now;
                sistemaReporteHistorico.IdUsuario = contextUser.User.IdUsuario;
                sistemaReporteHistorico.EntityId = filter.printFilter.IdProyecto.ToString();
                sistemaReporteHistorico.FilterData = DataHelper.SerializeObject<ProyectoFilter>(filter);
                sistemaReporteHistorico.Comentarios = info.Comments;
                sistemaReporteHistorico.Data = DataHelper.SerializeObject<ReportInfo>(reportInfo);
                SistemaReporteHistoricoBusiness.Current.Add(sistemaReporteHistorico, contextUser);
            }
            else
            {
                base.SaveHistoryReport(reporte, info, filter, contextUser);
            }
        }

        private void CargarReporteFinalidadFuncion(ReportInfo reportInfo, ProyectoFilter filter)
        {
            List<ProyectoReportFinalidadFuncionResult> prffr = GetReportProyectoFinalidadFuncion(filter);
            List<ProyectoReportFinalidadFuncionResult> result;
            List<ProyectoReportEstimadoRealizado> prer;
            if (filter.reportFilter.SoloEstimados == true)
                prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
            else if (filter.reportFilter.SoloEstimados == false)
                prer = ProyectoData.Current.GetRealizado(filter.reportFilter);
            else
            {
                //Matias 20131107 - Tarea 72
                /* Sentencias originales...
                 * prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                 * prer.AddRange(ProyectoData.Current.GetRealizado(filter.reportFilter));
                 */
                prer = ProyectoData.Current.GetTotalizado(filter.reportFilter);
                //FinMatias 20131107 - Tarea 72
            }
            result = (from o in prffr
                      join _er in prer on o.IdProyecto equals _er.IdProyecto into ter
                      from er in ter.DefaultIfEmpty()
                      select new ProyectoReportFinalidadFuncionResult
                      {
                          #region ProyectoReportResult
                          IdProyecto = o.IdProyecto
                          ,
                          IdSubPrograma = o.IdSubPrograma
                          ,
                          IdFinalidadFuncion = o.IdFinalidadFuncion
                          ,
                          Codigo = o.Codigo
                          ,
                          ProyectoDenominacion = o.ProyectoDenominacion
                          ,
                          IdEstado = o.IdEstado
                          ,
                          NroProyecto = o.NroProyecto
                          ,
                          FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                          ,
                          FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                          ,
                          Estado_Nombre = o.Estado_Nombre
                          ,
                          Plan_Nombre = o.Plan_Nombre
                          ,
                          NroProyectoPresupuestario = o.NroProyectoPresupuestario
                          ,
                          NroBienUso = o.NroBienUso
                          ,
                          NroObra = o.NroObra
                          #endregion
                          #region Finalidad Funcion
,
                          SubPrograma_Codigo = o.SubPrograma_Codigo
                           ,
                          SubPrograma_Nombre = o.SubPrograma_Nombre
                           ,
                          IdPrograma = o.IdPrograma
                           ,
                          Programa_Codigo = o.Programa_Codigo
                           ,
                          Programa_Nombre = o.Programa_Nombre
                           ,
                          IdSaf = o.IdSaf
                           ,
                          Saf_Codigo = o.Saf_Codigo
                           ,
                          Saf_Denominacion = o.Saf_Denominacion
                           ,
                          IdJurisdiccion = o.IdJurisdiccion
                           ,
                          Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                           ,
                          Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                           ,
                          FinalidadFuncion_Codigo = o.FinalidadFuncion_Codigo
                           ,
                          FinalidadFuncion_Denominacion = o.FinalidadFuncion_Denominacion
                          #endregion
                          #region EstimadoRealizado
                              //Matias - 20131107 - Tarea 72
                          ,
                          Periodo = er == null ? 0 : er.Periodo
                          ,
                          SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value : 0)
                          ,
                          SaldoPrevioEstimado = er == null ? 0 : (er.SaldoPrevioEstimado.HasValue ? er.SaldoPrevioEstimado.Value : 0)
                          ,
                          SaldoPrevioRealizado = er == null ? 0 : (er.SaldoPrevioRealizado.HasValue ? er.SaldoPrevioRealizado.Value : 0)
                          ,
                          SaldoDelAnio = er == null ? 0 : (er.SaldoDelAnio.HasValue ? er.SaldoDelAnio.Value : 0)
                          ,
                          SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value : 0)
                          ,
                          SaldoDelAnioSiguienteEstimado = er == null ? 0 : (er.SaldoDelAnioSiguienteEstimado.HasValue ? er.SaldoDelAnioSiguienteEstimado.Value : 0)
                          ,
                          SaldoDelAnioSiguienteRealizado = er == null ? 0 : (er.SaldoDelAnioSiguienteRealizado.HasValue ? er.SaldoDelAnioSiguienteRealizado.Value : 0)
                          ,
                          SaldoDelAnioEstimado = er == null ? 0 : (er.SaldoDelAnioEstimado.HasValue ? er.SaldoDelAnioEstimado.Value : 0)
                          ,
                          SaldoDelAnioRealizado = er == null ? 0 : (er.SaldoDelAnioRealizado.HasValue ? er.SaldoDelAnioRealizado.Value : 0)
                          ,
                          SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value : 0)
                          ,
                          SaldoDosAniosFuturosEstimado = er == null ? 0 : (er.SaldoDosAniosFuturosEstimado.HasValue ? er.SaldoDosAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoDosAniosFuturosRealizado = er == null ? 0 : (er.SaldoDosAniosFuturosRealizado.HasValue ? er.SaldoDosAniosFuturosRealizado.Value : 0)
                          ,
                          SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value : 0)
                          ,
                          SaldoAniosFuturosEstimado = er == null ? 0 : (er.SaldoAniosFuturosEstimado.HasValue ? er.SaldoAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoAniosFuturosRealizado = er == null ? 0 : (er.SaldoAniosFuturosRealizado.HasValue ? er.SaldoAniosFuturosRealizado.Value : 0)
                          ,
                          Tipo = er == null ? String.Empty : er.Tipo
                          //FinMatias - 20131107 - Tarea 72
                          #endregion
                      }
            ).ToList();
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportFinalidadFuncionResult", result));
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });


        }
        private void CargarReporteJurisdiccion(ReportInfo reportInfo, ProyectoFilter filter)
        {
            List<ProyectoReportJurisdiccionResult> prjr = GetReportProyectoJurisdiccion(filter);
            List<ProyectoReportJurisdiccionResult> result;
            List<ProyectoReportEstimadoRealizado> prer;
            if (filter.reportFilter.SoloEstimados == true)
                prer = ProyectoData.Current.GetEstimado(filter.reportFilter);                
            else if (filter.reportFilter.SoloEstimados == false)
                prer = ProyectoData.Current.GetRealizado(filter.reportFilter);
            else
            {
                //Matias 20131107 - Tarea 72
                /*prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                prer.AddRange(ProyectoData.Current.GetRealizado(filter.reportFilter));
                 */
                prer = ProyectoData.Current.GetTotalizado(filter.reportFilter);
                //FinMatias 20131107 - Tarea 72
            }


            result = (from o in prjr
                      join er in prer on o.IdProyecto equals er.IdProyecto into ter
                      from er in ter.DefaultIfEmpty()
                      select new ProyectoReportJurisdiccionResult
                      {
                          #region ProyectoReportResult
                          IdProyecto = o.IdProyecto
                          ,
                          IdSubPrograma = o.IdSubPrograma
                          ,
                          IdFinalidadFuncion = o.IdFinalidadFuncion
                          ,
                          Codigo = o.Codigo
                          ,
                          ProyectoDenominacion = o.ProyectoDenominacion
                          ,
                          IdEstado = o.IdEstado
                          ,
                          NroProyecto = o.NroProyecto
                          ,
                          FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                          ,
                          FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                          ,
                          Estado_Nombre = o.Estado_Nombre
                          ,
                          Plan_Nombre = o.Plan_Nombre
                          ,
                          NroProyectoPresupuestario = o.NroProyectoPresupuestario
                          ,
                          NroBienUso = o.NroBienUso
                          ,
                          NroObra = o.NroObra
                          #endregion
                          #region Jurisdiccion
                            ,
                          SubPrograma_Codigo = o.SubPrograma_Codigo
                           ,
                          SubPrograma_Nombre = o.SubPrograma_Nombre
                           ,
                          IdPrograma = o.IdPrograma
                           ,
                          Programa_Codigo = o.Programa_Codigo
                           ,
                          Programa_Nombre = o.Programa_Nombre
                           ,
                          IdSaf = o.IdSaf
                           ,
                          Saf_Codigo = o.Saf_Codigo
                           ,
                          Saf_Denominacion = o.Saf_Denominacion
                           ,
                          IdJurisdiccion = o.IdJurisdiccion
                           ,
                          Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                           ,
                          Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                          #endregion
                          #region EstimadoRealizado
                              //Matias - 20131107 - Tarea 72
                              /* Comentado por Matias...
                              * ,Periodo = er == null ? 0 : er.Periodo
                              ,SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value :0)
                              ,SaldoDelAnio = er == null ? 0 :( er.SaldoDelAnio.HasValue ?er.SaldoDelAnio.Value:0)
                              ,SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value:0)
                              ,SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value:0)
                              ,SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value: 0)
                              ,Tipo = er == null ? String.Empty : er.Tipo*/
                          ,
                          Periodo = er == null ? 0 : er.Periodo
                          ,
                          SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value : 0)
                          ,
                          SaldoPrevioEstimado = er == null ? 0 : (er.SaldoPrevioEstimado.HasValue ? er.SaldoPrevioEstimado.Value : 0)
                          ,
                          SaldoPrevioRealizado = er == null ? 0 : (er.SaldoPrevioRealizado.HasValue ? er.SaldoPrevioRealizado.Value : 0)
                          ,
                          SaldoDelAnio = er == null ? 0 : (er.SaldoDelAnio.HasValue ? er.SaldoDelAnio.Value : 0)
                          ,
                          SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value : 0)
                          ,
                          SaldoDelAnioSiguienteEstimado = er == null ? 0 : (er.SaldoDelAnioSiguienteEstimado.HasValue ? er.SaldoDelAnioSiguienteEstimado.Value : 0)
                          ,
                          SaldoDelAnioSiguienteRealizado = er == null ? 0 : (er.SaldoDelAnioSiguienteRealizado.HasValue ? er.SaldoDelAnioSiguienteRealizado.Value : 0)
                          ,
                          SaldoDelAnioEstimado = er == null ? 0 : (er.SaldoDelAnioEstimado.HasValue ? er.SaldoDelAnioEstimado.Value : 0)
                          ,
                          SaldoDelAnioRealizado = er == null ? 0 : (er.SaldoDelAnioRealizado.HasValue ? er.SaldoDelAnioRealizado.Value : 0)
                          ,
                          SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value : 0)
                          ,
                          SaldoDosAniosFuturosEstimado = er == null ? 0 : (er.SaldoDosAniosFuturosEstimado.HasValue ? er.SaldoDosAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoDosAniosFuturosRealizado = er == null ? 0 : (er.SaldoDosAniosFuturosRealizado.HasValue ? er.SaldoDosAniosFuturosRealizado.Value : 0)
                          ,
                          SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value : 0)
                          ,
                          SaldoAniosFuturosEstimado = er == null ? 0 : (er.SaldoAniosFuturosEstimado.HasValue ? er.SaldoAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoAniosFuturosRealizado = er == null ? 0 : (er.SaldoAniosFuturosRealizado.HasValue ? er.SaldoAniosFuturosRealizado.Value : 0)
                          ,
                          Tipo = er == null ? String.Empty : er.Tipo
                          //FinMatias - 20131107 - Tarea 72
                          #endregion
                      }
            ).ToList();
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportJurisdiccionResult", result));
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });

        }
        private void CargarReporteFuenteFinanciamiento(ReportInfo reportInfo, ProyectoFilter filter)
        {
            //Matias 20131107 - Tarea 72
            if (filter.reportFilter.SoloEstimados == null)
            {
                List<ProyectoReportFuenteFinanciamientoResult> prjr = GetReportProyectoFuenteFinanciamientoPorTipo(filter);
                List<ProyectoReportFuenteFinanciamientoResult> result;
                result = (from o in prjr
                          select new ProyectoReportFuenteFinanciamientoResult
                          {
                              #region ProyectoReportResult
                              IdProyecto = o.IdProyecto
                              ,
                              IdSubPrograma = o.IdSubPrograma
                              ,
                              IdFinalidadFuncion = o.IdFinalidadFuncion
                              ,
                              Codigo = o.Codigo
                              ,
                              ProyectoDenominacion = o.ProyectoDenominacion
                              ,
                              IdEstado = o.IdEstado
                              ,
                              NroProyecto = o.NroProyecto
                              ,
                              FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                              ,
                              FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                              ,
                              Estado_Nombre = o.Estado_Nombre
                              ,
                              Plan_Nombre = o.Plan_Nombre
                              ,
                              NroProyectoPresupuestario = o.NroProyectoPresupuestario
                              ,
                              NroBienUso = o.NroBienUso
                              ,
                              NroObra = o.NroObra
                              #endregion
                              #region FuenteFinanciamiento
,
                              SubPrograma_Codigo = o.SubPrograma_Codigo
                               ,
                              SubPrograma_Nombre = o.SubPrograma_Nombre
                               ,
                              IdPrograma = o.IdPrograma
                               ,
                              Programa_Codigo = o.Programa_Codigo
                               ,
                              Programa_Nombre = o.Programa_Nombre
                               ,
                              IdSaf = o.IdSaf
                               ,
                              Saf_Codigo = o.Saf_Codigo
                               ,
                              Saf_Denominacion = o.Saf_Denominacion
                               ,
                              IdJurisdiccion = o.IdJurisdiccion
                               ,
                              Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                               ,
                              Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                              #endregion
                              #region EstimadoRealizado
,
                              Periodo = o.Periodo
                              ,
                              SaldoPrevioEstimado = o.SaldoPrevioEstimado
                              ,
                              SaldoDelAnioEstimado = o.SaldoDelAnioEstimado
                              ,
                              SaldoDelAnioSiguienteEstimado = o.SaldoDelAnioSiguienteEstimado
                              ,
                              SaldoDosAniosFuturosEstimado = o.SaldoDosAniosFuturosEstimado
                              ,
                              SaldoAniosFuturosEstimado = o.SaldoAniosFuturosEstimado
                              ,
                              SaldoPrevioRealizado = o.SaldoPrevioRealizado
                              ,
                              SaldoDelAnioRealizado = o.SaldoDelAnioRealizado
                              ,
                              SaldoDelAnioSiguienteRealizado = o.SaldoDelAnioSiguienteRealizado
                              ,
                              SaldoDosAniosFuturosRealizado = o.SaldoDosAniosFuturosRealizado
                              ,
                              SaldoAniosFuturosRealizado = o.SaldoAniosFuturosRealizado
                              ,
                              Tipo = o.Tipo
                              ,
                              Fuente_Id = o.Fuente_Id
                              ,
                              Fuente_Codigo = o.Fuente_Codigo
                              ,
                              Fuente_Nombre = o.Fuente_Nombre
                              #endregion
                          }).ToList();
                reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportFuenteFinanciamientoResult", result));
                reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });


            }
            else
            {
                List<ProyectoReportFuenteFinanciamientoResult> prjr = GetReportProyectoFuenteFinanciamiento(filter);
                List<ProyectoReportFuenteFinanciamientoResult> result;
                //List<ProyectoReportEstimadoRealizado> prer;
                //if (filter.reportFilter.SoloEstimados == true)
                //    prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                //else if (filter.reportFilter.SoloEstimados == false)
                //    prer = ProyectoData.Current.GetRealizado(filter.reportFilter);
                //else
                //{
                //    prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                //    prer.AddRange(ProyectoData.Current.GetRealizado(filter.reportFilter));
                //}


                result = (from o in prjr
                          select new ProyectoReportFuenteFinanciamientoResult
                          {
                              #region ProyectoReportResult
                              IdProyecto = o.IdProyecto
                              ,
                              IdSubPrograma = o.IdSubPrograma
                              ,
                              IdFinalidadFuncion = o.IdFinalidadFuncion
                              ,
                              Codigo = o.Codigo
                              ,
                              ProyectoDenominacion = o.ProyectoDenominacion
                              ,
                              IdEstado = o.IdEstado
                              ,
                              NroProyecto = o.NroProyecto
                              ,
                              FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                              ,
                              FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                              ,
                              Estado_Nombre = o.Estado_Nombre
                              ,
                              Plan_Nombre = o.Plan_Nombre
                              ,
                              NroProyectoPresupuestario = o.NroProyectoPresupuestario
                              ,
                              NroBienUso = o.NroBienUso
                              ,
                              NroObra = o.NroObra
                              #endregion
                              #region FuenteFinanciamiento
,
                              SubPrograma_Codigo = o.SubPrograma_Codigo
                               ,
                              SubPrograma_Nombre = o.SubPrograma_Nombre
                               ,
                              IdPrograma = o.IdPrograma
                               ,
                              Programa_Codigo = o.Programa_Codigo
                               ,
                              Programa_Nombre = o.Programa_Nombre
                               ,
                              IdSaf = o.IdSaf
                               ,
                              Saf_Codigo = o.Saf_Codigo
                               ,
                              Saf_Denominacion = o.Saf_Denominacion
                               ,
                              IdJurisdiccion = o.IdJurisdiccion
                               ,
                              Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                               ,
                              Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                              #endregion
                              #region EstimadoRealizado
,
                              Periodo = o.Periodo
                              ,
                              SaldoPrevio = o.SaldoPrevio
                              ,
                              SaldoDelAnio = o.SaldoDelAnio
                              ,
                              SaldoDelAnioSiguiente = o.SaldoDelAnioSiguiente
                              ,
                              SaldoDosAniosFuturos = o.SaldoDosAniosFuturos
                              ,
                              SaldoAniosFuturos = o.SaldoAniosFuturos
                              ,
                              Tipo = o.Tipo
                              ,
                              Fuente_Id = o.Fuente_Id
                              ,
                              Fuente_Codigo = o.Fuente_Codigo
                              ,
                              Fuente_Nombre = o.Fuente_Nombre
                              #endregion
                          }
                ).ToList();
                reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportFuenteFinanciamientoResult", result));
                reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });
            }
            //FinMatias 20131107 - Tarea 72
        }
        private void CargarReporteTipoProyecto(ReportInfo reportInfo, ProyectoFilter filter)
        {
            List<ProyectoReportTipoProyectoResult> prjr = GetReportProyectoTipoProyecto(filter);
            List<ProyectoReportTipoProyectoResult> result;
            List<ProyectoReportEstimadoRealizado> prer;
            if (filter.reportFilter.SoloEstimados == true)
                prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
            else if (filter.reportFilter.SoloEstimados == false)
                prer = ProyectoData.Current.GetRealizado(filter.reportFilter);
            else
            {
                //Matias 20131107 - Tarea 72
                /*prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                prer.AddRange(ProyectoData.Current.GetRealizado(filter.reportFilter));
                 */
                prer = ProyectoData.Current.GetTotalizado(filter.reportFilter);
                //FinMatias 20131107 - Tarea 72
            }
            result = (from o in prjr
                      join _er in prer on o.IdProyecto equals _er.IdProyecto into ter
                      from er in ter.DefaultIfEmpty()
                      select new ProyectoReportTipoProyectoResult
                      {
                          #region ProyectoReportResult
                          IdProyecto = o.IdProyecto
                          ,
                          IdSubPrograma = o.IdSubPrograma
                          ,
                          IdFinalidadFuncion = o.IdFinalidadFuncion
                          ,
                          Codigo = o.Codigo
                          ,
                          ProyectoDenominacion = o.ProyectoDenominacion
                          ,
                          IdEstado = o.IdEstado
                          ,
                          NroProyecto = o.NroProyecto
                          ,
                          FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                          ,
                          FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                          ,
                          Estado_Nombre = o.Estado_Nombre
                          ,
                          Plan_Nombre = o.Plan_Nombre
                          ,
                          NroProyectoPresupuestario = o.NroProyectoPresupuestario
                          ,
                          NroBienUso = o.NroBienUso
                          ,
                          NroObra = o.NroObra
                          #endregion
                          #region ProyectoTipo
,
                          SubPrograma_Codigo = o.SubPrograma_Codigo
                           ,
                          SubPrograma_Nombre = o.SubPrograma_Nombre
                           ,
                          IdPrograma = o.IdPrograma
                           ,
                          Programa_Codigo = o.Programa_Codigo
                           ,
                          Programa_Nombre = o.Programa_Nombre
                           ,
                          IdSaf = o.IdSaf
                           ,
                          Saf_Codigo = o.Saf_Codigo
                           ,
                          Saf_Denominacion = o.Saf_Denominacion
                           ,
                          IdJurisdiccion = o.IdJurisdiccion
                           ,
                          Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                           ,
                          Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                           ,
                          IdTipoProyecto = o.IdTipoProyecto
                           ,
                          Proceso_Nombre = o.Proceso_Nombre
                           ,
                          TipoProyecto_Nombre = o.TipoProyecto_Nombre
                          #endregion
                          #region EstimadoRealizado
                              //Matias - 20131107 - Tarea 72
                              /* Comentado por Matias...
                              * ,Periodo = er == null ? 0 : er.Periodo
                              ,SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value :0)
                              ,SaldoDelAnio = er == null ? 0 :( er.SaldoDelAnio.HasValue ?er.SaldoDelAnio.Value:0)
                              ,SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value:0)
                              ,SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value:0)
                              ,SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value: 0)
                              ,Tipo = er == null ? String.Empty : er.Tipo*/
                          ,
                          Periodo = er == null ? 0 : er.Periodo
                          ,
                          SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value : 0)
                          ,
                          SaldoPrevioEstimado = er == null ? 0 : (er.SaldoPrevioEstimado.HasValue ? er.SaldoPrevioEstimado.Value : 0)
                          ,
                          SaldoPrevioRealizado = er == null ? 0 : (er.SaldoPrevioRealizado.HasValue ? er.SaldoPrevioRealizado.Value : 0)
                          ,
                          SaldoDelAnio = er == null ? 0 : (er.SaldoDelAnio.HasValue ? er.SaldoDelAnio.Value : 0)
                          ,
                          SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value : 0)
                          ,
                          SaldoDelAnioSiguienteEstimado = er == null ? 0 : (er.SaldoDelAnioSiguienteEstimado.HasValue ? er.SaldoDelAnioSiguienteEstimado.Value : 0)
                          ,
                          SaldoDelAnioSiguienteRealizado = er == null ? 0 : (er.SaldoDelAnioSiguienteRealizado.HasValue ? er.SaldoDelAnioSiguienteRealizado.Value : 0)
                          ,
                          SaldoDelAnioEstimado = er == null ? 0 : (er.SaldoDelAnioEstimado.HasValue ? er.SaldoDelAnioEstimado.Value : 0)
                          ,
                          SaldoDelAnioRealizado = er == null ? 0 : (er.SaldoDelAnioRealizado.HasValue ? er.SaldoDelAnioRealizado.Value : 0)
                          ,
                          SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value : 0)
                          ,
                          SaldoDosAniosFuturosEstimado = er == null ? 0 : (er.SaldoDosAniosFuturosEstimado.HasValue ? er.SaldoDosAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoDosAniosFuturosRealizado = er == null ? 0 : (er.SaldoDosAniosFuturosRealizado.HasValue ? er.SaldoDosAniosFuturosRealizado.Value : 0)
                          ,
                          SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value : 0)
                          ,
                          SaldoAniosFuturosEstimado = er == null ? 0 : (er.SaldoAniosFuturosEstimado.HasValue ? er.SaldoAniosFuturosEstimado.Value : 0)
                          ,
                          SaldoAniosFuturosRealizado = er == null ? 0 : (er.SaldoAniosFuturosRealizado.HasValue ? er.SaldoAniosFuturosRealizado.Value : 0)
                          ,
                          Tipo = er == null ? String.Empty : er.Tipo
                          //FinMatias - 20131107 - Tarea 72
                          #endregion
                      }
            ).ToList();
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportTipoProyectoResult", result));
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });

        }
        private void CargarReporteProvincia(ReportInfo reportInfo, ProyectoFilter filter)
        {
            List<ProyectoReportProvinciaResult> prjr = GetReportProyectoProvincia(filter);
            List<ProyectoReportProvinciaResult> result;
            List<ProyectoReportEstimadoRealizado> prer;
            if (filter.reportFilter.SoloEstimados == true)
                prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
            else if (filter.reportFilter.SoloEstimados == false)
                prer = ProyectoData.Current.GetRealizado(filter.reportFilter);
            else
            {
                //Matias 20131107 - Tarea 72 - Algo
                /*prer = ProyectoData.Current.GetEstimado(filter.reportFilter);
                prer.AddRange(ProyectoData.Current.GetRealizado(filter.reportFilter));
                 */
                prer = ProyectoData.Current.GetTotalizado(filter.reportFilter);
                //FinMatias 20131107 - Tarea 72
            }
            var query = (from o in prjr
                         join _er in prer on o.IdProyecto equals _er.IdProyecto into ter
                         from er in ter.DefaultIfEmpty()
                         select new ProyectoReportProvinciaResult
                         {
                             #region ProyectoReportResult
                             IdProyecto = o.IdProyecto
                             ,
                             IdSubPrograma = o.IdSubPrograma
                             ,
                             IdFinalidadFuncion = o.IdFinalidadFuncion
                             ,
                             Codigo = o.Codigo
                             ,
                             ProyectoDenominacion = o.ProyectoDenominacion
                             ,
                             IdEstado = o.IdEstado
                             ,
                             NroProyecto = o.NroProyecto
                             ,
                             FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                             ,
                             FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                             ,
                             Estado_Nombre = o.Estado_Nombre
                             ,
                             Plan_Nombre = o.Plan_Nombre
                             ,
                             NroProyectoPresupuestario = o.NroProyectoPresupuestario
                             ,
                             NroBienUso = o.NroBienUso
                             ,
                             NroObra = o.NroObra
                             #endregion
                             #region Provincia
,
                             SubPrograma_Codigo = o.SubPrograma_Codigo
                             ,
                             SubPrograma_Nombre = o.SubPrograma_Nombre
                             ,
                             IdPrograma = o.IdPrograma
                             ,
                             Programa_Codigo = o.Programa_Codigo
                             ,
                             Programa_Nombre = o.Programa_Nombre
                             ,
                             IdSaf = o.IdSaf
                             ,
                             Saf_Codigo = o.Saf_Codigo
                             ,
                             Saf_Denominacion = o.Saf_Denominacion
                             ,
                             IdJurisdiccion = o.IdJurisdiccion
                             ,
                             Jurisdiccion_Codigo = o.Jurisdiccion_Codigo
                             ,
                             Jurisdiccion_Nombre = o.Jurisdiccion_Nombre
                             ,
                             Provincia_Codigo = o.Provincia_Codigo
                             ,
                             IdProvincia = o.IdProvincia
                             ,
                             Provincia_Denominacion = o.Provincia_Denominacion
                             #endregion
                             #region EstimadoRealizado
                                 //Matias - 20131107 - Tarea 72
                                 /* Comentado por Matias...
                                 * ,Periodo = er == null ? 0 : er.Periodo
                                 ,SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value :0)
                                 ,SaldoDelAnio = er == null ? 0 :( er.SaldoDelAnio.HasValue ?er.SaldoDelAnio.Value:0)
                                 ,SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value:0)
                                 ,SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value:0)
                                 ,SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value: 0)
                                 ,Tipo = er == null ? String.Empty : er.Tipo*/
                              ,
                             Periodo = er == null ? 0 : er.Periodo
                              ,
                             SaldoPrevio = er == null ? 0 : (er.SaldoPrevio.HasValue ? er.SaldoPrevio.Value : 0)
                              ,
                             SaldoPrevioEstimado = er == null ? 0 : (er.SaldoPrevioEstimado.HasValue ? er.SaldoPrevioEstimado.Value : 0)
                              ,
                             SaldoPrevioRealizado = er == null ? 0 : (er.SaldoPrevioRealizado.HasValue ? er.SaldoPrevioRealizado.Value : 0)
                              ,
                             SaldoDelAnio = er == null ? 0 : (er.SaldoDelAnio.HasValue ? er.SaldoDelAnio.Value : 0)
                              ,
                             SaldoDelAnioSiguiente = er == null ? 0 : (er.SaldoDelAnioSiguiente.HasValue ? er.SaldoDelAnioSiguiente.Value : 0)
                              ,
                             SaldoDelAnioSiguienteEstimado = er == null ? 0 : (er.SaldoDelAnioSiguienteEstimado.HasValue ? er.SaldoDelAnioSiguienteEstimado.Value : 0)
                              ,
                             SaldoDelAnioSiguienteRealizado = er == null ? 0 : (er.SaldoDelAnioSiguienteRealizado.HasValue ? er.SaldoDelAnioSiguienteRealizado.Value : 0)
                              ,
                             SaldoDelAnioEstimado = er == null ? 0 : (er.SaldoDelAnioEstimado.HasValue ? er.SaldoDelAnioEstimado.Value : 0)
                              ,
                             SaldoDelAnioRealizado = er == null ? 0 : (er.SaldoDelAnioRealizado.HasValue ? er.SaldoDelAnioRealizado.Value : 0)
                              ,
                             SaldoDosAniosFuturos = er == null ? 0 : (er.SaldoDosAniosFuturos.HasValue ? er.SaldoDosAniosFuturos.Value : 0)
                              ,
                             SaldoDosAniosFuturosEstimado = er == null ? 0 : (er.SaldoDosAniosFuturosEstimado.HasValue ? er.SaldoDosAniosFuturosEstimado.Value : 0)
                              ,
                             SaldoDosAniosFuturosRealizado = er == null ? 0 : (er.SaldoDosAniosFuturosRealizado.HasValue ? er.SaldoDosAniosFuturosRealizado.Value : 0)
                              ,
                             SaldoAniosFuturos = er == null ? 0 : (er.SaldoAniosFuturos.HasValue ? er.SaldoAniosFuturos.Value : 0)
                              ,
                             SaldoAniosFuturosEstimado = er == null ? 0 : (er.SaldoAniosFuturosEstimado.HasValue ? er.SaldoAniosFuturosEstimado.Value : 0)
                              ,
                             SaldoAniosFuturosRealizado = er == null ? 0 : (er.SaldoAniosFuturosRealizado.HasValue ? er.SaldoAniosFuturosRealizado.Value : 0)
                              ,
                             Tipo = er == null ? String.Empty : er.Tipo
                             //FinMatias - 20131107 - Tarea 72
                             #endregion
                         }
            ).AsQueryable();
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoReportProvinciaResult", query.ToList()));
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Anio", Value = filter.reportFilter.AnioInicialCronograma.ToString() });

        }

        private void Imprimir(ReportInfo reportInfo, ProyectoFilter filter)
        {
            Int32 IdProyecto = filter.printFilter.IdProyecto;

            //Datos generales
            List<ProyectoResult> proyecto = GetResult(new ProyectoFilter() { IdProyecto = IdProyecto });
            List<ProyectoPlanResult> proyectoPlanResult = ProyectoPlanBusiness.Current.GetResult(new ProyectoPlanFilter() { IdProyecto = IdProyecto });
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfiles = ProyectoOficinaPerfilBusiness.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdProyecto = IdProyecto });
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfilIniciador = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "INIC" select o).ToList();
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfilEjecutor = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "EJEC" select o).ToList();
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfilResponsable = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "RESP" select o).ToList();
            List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionario = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetResult(new ProyectoOficinaPerfilFuncionarioFilter() { IdsProyectoOficinaPerfil = (from o in proyectoOficinaPerfiles select o.IdProyectoOficinaPerfil).ToArray() });
            List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioIniciador = (from o in proyectoOficinaPerfilFuncionario where proyectoOficinaPerfilIniciador.Select(i => i.IdPerfil).Contains(o.ProyectoOficinaPerfil_IdPerfil) select o).ToList();
            List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioEjecutor = (from o in proyectoOficinaPerfilFuncionario where proyectoOficinaPerfilEjecutor.Select(i => i.IdPerfil).Contains(o.ProyectoOficinaPerfil_IdPerfil) select o).ToList();
            List<ProyectoOficinaPerfilFuncionarioResult> proyectoOficinaPerfilFuncionarioResponsable = (from o in proyectoOficinaPerfilFuncionario where proyectoOficinaPerfilResponsable.Select(i => i.IdPerfil).Contains(o.ProyectoOficinaPerfil_IdPerfil) select o).ToList();

            Programa programa = ProgramaBusiness.Current.GetById(proyecto.First().IdPrograma);
            Persona persona = PersonaBusiness.Current.GetList(new PersonaFilter() { IdPersona = programa.IdSectorialista }).FirstOrDefault();
            String sectorialista = String.Format("{0} {1} | {2} | {3}", persona.Nombre, persona.Apellido, persona.TelefonoLaboral, persona.EMailLaboral);

            List<ProyectoOrigenFinanciamientoResult> proyectoOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.GetResult(new ProyectoOrigenFinanciamientoFilter() { IdProyecto = IdProyecto });
            List<ProyectoRelacionResult> proyectoRelacion = ProyectoRelacionBusiness.Current.GetResult(new ProyectoRelacionFilter() { IdProyecto = IdProyecto });
            List<ProyectoDemoraResult> proyectoDemoraResult = ProyectoDemoraBusiness.Current.GetResult(new ProyectoDemoraFilter() { IdProyecto = IdProyecto });


            //Localización Geográfica
            List<ProyectoLocalizacionResult> proyectoLocalizacionResult = ProyectoLocalizacionBusiness.Current.GetResult(new ProyectoLocalizacionFilter() { IdProyecto = IdProyecto });
            List<ProyectoAlcanceGeograficoResult> proyectoAlcanceGeografico = ProyectoAlcanceGeograficoBusiness.Current.GetResult(new ProyectoAlcanceGeograficoFilter() { IdProyecto = IdProyecto });
            List<GeoreferenciacionPuntoResult> proyectoGeoreferenciacionResult = GeoreferenciacionPuntoBusiness.Current.GetResult(new GeoreferenciacionPuntoFilter() { IdProyecto = IdProyecto });

            //Objetivos: Fines, Propositos y Producto
            List<ProyectoObjetivoReportResult> proyectoObjetivoReportResult2 = GetProyectoObjetivoFines(new ProyectoFilter() { IdProyecto = IdProyecto });
            List<ProyectoObjetivoReportResult> proyectoObjetivoReportResult = GetProyectoObjetivo(new ProyectoFilter() { IdProyecto = IdProyecto });
            List<ProyectoObjetivoReportResult> proyectoProductoReportResult = GetProyectoProducto(new ProyectoFilter() { IdProyecto = IdProyecto });
            
            //Inversion física - Etapas
            List<ProyectoEtapaReportResult> proyectoEtapaReportResult = GetProyectoEtapa(new ProyectoFilter() { IdProyecto = IdProyecto });
            List<ProyectoEtapaResult> proyectoEtapaResult = ProyectoEtapaBusiness.Current.GetResult(new ProyectoEtapaFilter() { IdProyecto = IdProyecto });
            
            //Cronograma
            List<ProyectoEtapaResult> proyectoEtapaResultCronograma = ProyectoEtapaBusiness.Current.ProyectoEtapaConTotales(new ProyectoEtapaFilter() { IdProyecto = IdProyecto });
            
            //string descripcion = proyectoEtapaResultCronograma[0].Descripcion;
            
            List<ProyectoCronogramaReportResult> proyectoCronogramaReportResult = GetCronograma(new ProyectoFilter() { IdProyecto = IdProyecto });
            
            //Evaluacion
            List<ProyectoEvaluacionResult> proyectoEvaluacionResult = ProyectoEvaluacionBusiness.Current.GetResult(new ProyectoEvaluacionFilter() { Id_Proyecto = IdProyecto });
            List<ProyectoIndicadorPriorizacionResult> proyectoIndicadorPriorizacionResult = ProyectoIndicadorPriorizacionBusiness.Current.GetResult(new ProyectoIndicadorPriorizacionFilter() { IdProyecto = IdProyecto });
            List<ProyectoBeneficioIndicadorResult> proyectoBeneficioIndicador = ProyectoBeneficioIndicadorBusiness.Current.GetResult(new ProyectoBeneficioIndicadorFilter() { IdProyecto = IdProyecto });
            List<ProyectoIndicadorEconomicoResult> proyectoIndicadorEconomico = ProyectoIndicadorEconomicoBusiness.Current.GetResult(new ProyectoIndicadorEconomicoFilter() { IdProyecto = IdProyecto });
            List<ProyectoBeneficiarioReportResult> proyectoBeneficiarioReport = ProyectoBusiness.Current.GetProyectoBeneficiario(new ProyectoFilter() { IdProyecto = IdProyecto });
            List<ProyectoBeneficiosReportResult> proyectoBeneficiosReport = ProyectoBusiness.Current.GetProyectoBeneficio(new ProyectoFilter() { IdProyecto = IdProyecto });
            
            //DNIP
            List<ProyectoDictamenResult> proyectoDictamen = ProyectoDictamenBusiness.Current.GetResult(new ProyectoDictamenFilter() { IdProyecto = IdProyecto });
            List<ProyectoPrioridadResult> proyectoPrioridad = ProyectoPrioridadBusiness.Current.GetResult(new ProyectoPrioridadFilter() { IdProyecto = IdProyecto });
            List<ProyectoComentarioTecnicoResult> proyectoComentarioTecnino = ProyectoComentarioTecnicoBusiness.Current.GetResult(new ProyectoComentarioTecnicoFilter() { IdProyecto = IdProyecto }); //Matias 20170302 - Ticket #REQ792885
            
            //Adjuntos
            List<ProyectoFileResult> proyectoFile = ProyectoFileBusiness.Current.GetResult(new ProyectoFileFilter() { IdProyecto = IdProyecto });

            //Matias 20170216 - Ticket #REQ792885
            //Calidad
            List<ProyectoCalidadResult> proyectoCalidad = ProyectoCalidadBusiness.Current.GetResult(new ProyectoCalidadFilter() { IdProyecto = IdProyecto, ProyectoActivo = true, ProyectoBorrador = false });            
            //FinMatias 20170216 - Ticket #REQ792885

            
            //reportInfo.DataSources.Clear(); //Matias 20170220 - Error de REPORTE. Agregado y comentado por Matias.
            //reportInfo.Parameters.Clear();  //Matias 20170220 - Error de REPORTE. Agregado y comentado por Matias.           
            
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoResult", proyecto));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOrigenFinanciamientoResult", proyectoOrigenFinanciamiento));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoRelacionResult", proyectoRelacion));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoDemoraResult", proyectoDemoraResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoLocalizacionResult", proyectoLocalizacionResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("GeoreferenciacionPuntoResult", proyectoGeoreferenciacionResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoObjetivoReportResult", proyectoObjetivoReportResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoObjetivoReportResult1", proyectoProductoReportResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoObjetivoReportResult2", proyectoObjetivoReportResult2));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoEtapaReportResult", proyectoEtapaReportResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoEtapaResult", proyectoEtapaResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("proyectoEtapaResultCronograma", proyectoEtapaResultCronograma));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoCronogramaReportResult", proyectoCronogramaReportResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoEvaluacionResult", proyectoEvaluacionResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoIndicadorPriorizacionResult", proyectoIndicadorPriorizacionResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoDictamenResult", proyectoDictamen));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoPrioridadResult", proyectoPrioridad));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoFileResult", proyectoFile));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoIndicadorEconomicoResult", proyectoIndicadorEconomico));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoBeneficiarioReportResult", proyectoBeneficiarioReport));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoBeneficiosReportResult", proyectoBeneficiosReport));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoPlanResult", proyectoPlanResult));

            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilIniciador", proyectoOficinaPerfilIniciador));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilEjecutor", proyectoOficinaPerfilEjecutor));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilResponsable", proyectoOficinaPerfilResponsable));

            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilFuncionarioIniciador", proyectoOficinaPerfilFuncionarioIniciador));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilFuncionarioEjecutor", proyectoOficinaPerfilFuncionarioEjecutor));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilFuncionarioResponsable", proyectoOficinaPerfilFuncionarioResponsable));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoAlcanceGeograficoResult", proyectoAlcanceGeografico));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoCalidadResult", proyectoCalidad)); //Matias 20170216 - Ticket #REQ792885
            reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoComentarioTecnicoResult", proyectoComentarioTecnino)); //Matias 20170302 - Ticket #REQ792885            

            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "SolapaGeneral", Value = filter.printFilter.SolapaGeneral.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeDatosSecundarios", Value = filter.printFilter.IncluyeDatosSecundarios.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "AlcanceGeografico", Value = filter.printFilter.AlcanceGeografico.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Objetivos", Value = filter.printFilter.Objetivos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeEvolucionDeIndicadoresObjetivos", Value = filter.printFilter.IncluyeEvolucionDeIndicadoresObjetivos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "ProductoIntermedio", Value = filter.printFilter.ProductoIntermedio.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeDetalleDeEtapas", Value = filter.printFilter.IncluyeDetalleDeEtapas.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Cronograma", Value = filter.printFilter.Cronograma.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeDetallePorObjetoDelGastoYAnios", Value = filter.printFilter.IncluyeDetallePorObjetoDelGastoYAnios.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Evaluacion", Value = filter.printFilter.Evaluacion.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeEvolucionDeIndicadoresEvaluacion", Value = filter.printFilter.IncluyeEvolucionDeIndicadoresEvaluacion.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IntervencionDNIP", Value = filter.printFilter.IntervencionDNIP.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Adjuntos", Value = filter.printFilter.Adjuntos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Calidad", Value = filter.printFilter.Calidad.ToString() }); //Matias 20170216 - Ticket #REQ792885
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Sectorialista", Value = sectorialista });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IdPlaneamiento", Value = ((int)FaseEnum.Planeamiento).ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IdDesmantelamiento", Value = ((int)FaseEnum.Desmantelamiento).ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IdEjecucion", Value = ((int)FaseEnum.Ejecucion).ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IdOperacion", Value = ((int)FaseEnum.Operacion).ToString() });
        }

        public List<ProyectoObjetivoReportResult> GetProyectoObjetivo(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoObjetivo(filter);
        }
        public List<ProyectoObjetivoReportResult> GetProyectoObjetivoFines(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoObjetivoFines(filter);
        }
        public List<ProyectoObjetivoReportResult> GetProyectoProducto(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoProducto(filter);
        }
        public List<ProyectoEtapaReportResult> GetProyectoEtapa(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoEtapa(filter);
        }
        public List<ProyectoCronogramaReportResult> GetCronograma(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetCronograma(filter);
        }
        public List<ProyectoBeneficiosReportResult> GetProyectoBeneficio(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoBeneficio(filter);
        }
        public List<ProyectoBeneficiarioReportResult> GetProyectoBeneficiario(ProyectoFilter filter)
        {
            return ProyectoData.Current.GetProyectoBeneficiario(filter);
        }
        public override ReportInfo GetReport(SistemaReporte reporte, int id)
        {
            ReportInfo reportInfo = new ReportInfo();
            reportInfo.ReportFileName = reporte.FileName;
            reportInfo.Title = reporte.Nombre;

            switch (reporte.Codigo)
            {
                case "Test":
                    ProyectoGeneralCompose proyectoGeneralCompose = ProyectoGeneralComposeBusiness.Current.GetById(id);
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoGeneral", new List<ProyectoResult>(new ProyectoResult[] { proyectoGeneralCompose.proyecto })));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoDemora", proyectoGeneralCompose.proyectoDemora));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilFuncionarioEjecutor", proyectoGeneralCompose.proyectoOficinaPerfilFuncionarioEjecutor));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOficinaPerfilFuncionarioResponsable", proyectoGeneralCompose.proyectoOficinaPerfilFuncionarioResponsable));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoOrigenFinanciamiento", proyectoGeneralCompose.proyectoOrigenFinanciamiento));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoPlan", proyectoGeneralCompose.proyectoPlan));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoPrioridad", proyectoGeneralCompose.proyectoPrioridad));
                    reportInfo.DataSources.Add(new ReportInfoDataSource("ProyectoRelacion", proyectoGeneralCompose.proyectoRelacion));
                    break;
            }
            return reportInfo;


        }
        #endregion


        public void SendMessageEliminacionProyecto(Proyecto proyecto, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgProyectoEliminacionActive") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgProyectoEliminacion", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, proyecto.ProyectoDenominacion, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Proyecto Eliminado", body, proyecto.IdProyecto, contextUser);
        }


        public override bool Can(Proyecto entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            if (entity == null) return true;
            EstadoDeDesicion estadoDeDesicion = entity.IdEstadoDeDesicion.HasValue ? SolutionContext.Current.EstadoDeDesicionCache.GetById(entity.IdEstadoDeDesicion.Value) : null;
            switch (actionName)
            {
                case ActionConfig.CONFORMAR:
                    if (estadoDeDesicion == null) return true;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.REINICIADO) return true; //Matias 20161207
                    return false;
                case ActionConfig.POSTULAR:
                    if (estadoDeDesicion == null) return true;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.REINICIADO) return true; //Matias 20161207
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.CONFORMADO) return true;
                    return false;
                case ActionConfig.ACEPTAR:
                    if (estadoDeDesicion == null) return true;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.REINICIADO) return true; //Matias 20161207
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.POSTULADO) return true;
                    return false;
                case ActionConfig.OBSERVAR:
                    if (estadoDeDesicion == null) return false;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.POSTULADO) return true;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.CONFORMADO) return true;
                    return false;
                case ActionConfig.REINICIAR:
                    if (estadoDeDesicion == null) return false;
                    if (estadoDeDesicion.Codigo == EstadoDeDesicionConfig.OBSERVADO) return true;
                    return false;
            }
            return base.Can(entity, actionName, contextUser, args);
        }

        public override bool Can(ProyectoResult result, string actionName, IContextUser contextUser, Hashtable args)
        {
            switch (actionName)
            {
                case ActionConfig.DELETE:
                    //Matias 20170123 - Ticket #ER382869
                    
                    //Tiene marca Plan o Demanda?
                    
                    //Monto real cargado?
                    
                    //Asociado a un préstamo?

                    //Vinculado a otro proyecto?

                    //Tiene evaluacion de factibilidad realizada?

                    //FinMatias 20170123 - Ticket #ER382869
                case ActionConfig.UPDATE:
                    if (!result.Activo) return false;
                    break;

                //Matias 20170123 - Ticket #ER382869
                case ActionConfig.COPY:
                    if (!result.Activo) return false;
                    break;
                //FinMatias 20170123 - Ticket #ER382869                    
                default:
                    break;
            }
            return base.Can(result, actionName, contextUser, args);
        }

    }

    public class ProyectoGeneralComposeBusiness : EntityComposeBusiness<ProyectoGeneralCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoGeneralComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoGeneralComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeneralComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }
        #region Gets
        public override ProyectoGeneralCompose GetNew(ProyectoResult example)
        {
            ProyectoGeneralCompose compose = base.GetNew();
            example.EvaluarValidaciones = true;
            example.Activo = true;
            compose.proyecto = example;
            compose.proyectoDemora = new List<ProyectoDemoraResult>();
            compose.proyectoOrigenFinanciamiento = new List<ProyectoOrigenFinanciamientoResult>();
            compose.proyectoPlan = new List<ProyectoPlanResult>();
            compose.proyectoRelacion = new List<ProyectoRelacionResult>();
            Perfil perfilIniciador = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "INIC" });
            if (perfilIniciador != null)
            {
                compose.proyectoOficinaPerfilIniciador = new ProyectoOficinaPerfilResult() { IdPerfil = perfilIniciador.IdPerfil, IdOficina = example.IdOficina_Usuario };
            }
            Perfil perfilEjecutor = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "EJEC" });
            if (perfilEjecutor != null)
            {
                compose.proyectoOficinaPerfilEjecutor = new ProyectoOficinaPerfilResult() { IdPerfil = perfilEjecutor.IdPerfil, IdOficina = example.IdOficina_Usuario };
            }
            Perfil perfilResponsable = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "RESP" });
            if (perfilResponsable != null)
            {
                compose.proyectoOficinaPerfilResponsable = new ProyectoOficinaPerfilResult() { IdPerfil = perfilResponsable.IdPerfil, IdOficina = example.IdOficina_Usuario };
            }
            compose.proyectoOficinaPerfilFuncionarioIniciador = ToproyectoOficinaPerfilFuncionarios(PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = example.IdOficina_Usuario }));
            compose.proyectoOficinaPerfilFuncionarioEjecutor = ToproyectoOficinaPerfilFuncionarios(PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = example.IdOficina_Usuario }));
            compose.proyectoOficinaPerfilFuncionarioResponsable = ToproyectoOficinaPerfilFuncionarios(PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = example.IdOficina_Usuario }));

            ProyectoOficinaPerfilFuncionarioResult proyectoOficinaPerfilFuncionarioIniciador = compose.proyectoOficinaPerfilFuncionarioIniciador.Find(i => i.IdUsuario == example.IdUsuario);
            if (proyectoOficinaPerfilFuncionarioIniciador != null) proyectoOficinaPerfilFuncionarioIniciador.Selected = true;
            ProyectoOficinaPerfilFuncionarioResult proyectoOficinaPerfilFuncionarioEjecutor = compose.proyectoOficinaPerfilFuncionarioEjecutor.Find(i => i.IdUsuario == example.IdUsuario);
            if (proyectoOficinaPerfilFuncionarioEjecutor != null) proyectoOficinaPerfilFuncionarioEjecutor.Selected = true;
            ProyectoOficinaPerfilFuncionarioResult proyectoOficinaPerfilFuncionarioResponsable = compose.proyectoOficinaPerfilFuncionarioResponsable.Find(i => i.IdUsuario == example.IdUsuario);
            if (proyectoOficinaPerfilFuncionarioResponsable != null) proyectoOficinaPerfilFuncionarioResponsable.Selected = true;
            return compose;
        }
        public override ProyectoGeneralCompose GetNew()
        {
            ProyectoResult example = new ProyectoResult();
            example.Activo = true;
            example.EvaluarValidaciones = true;
            ProyectoBusiness.Current.Set(ProyectoBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(ProyectoGeneralCompose entity)
        {
            return entity.proyecto.IdProyecto;
        }
        public override ProyectoGeneralCompose GetById(int id)
        {
            ProyectoGeneralCompose compose = new ProyectoGeneralCompose();

            //Proyecto proyecto = ProyectoBusiness.Current.GetById(id);
            //ProyectoResult proyectoResult = ProyectoBusiness.Current.GetResult(new ProyectoFilter() { IdProyecto = id }).SingleOrDefault ();
            //ProyectoBusiness.Current.Set(proyecto, proyectoResult);
            compose.proyecto = ProyectoBusiness.Current.GetResultWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();

            compose.proyectoDemora = ProyectoDemoraBusiness.Current.GetResultFromList(new ProyectoDemoraFilter() { IdProyecto = id });
            //compose.proyectoDemora= ProyectoDemoraBusiness.Current.GetResult(new ProyectoDemoraFilter() { IdProyecto = id });
            compose.proyectoOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.GetResult(new ProyectoOrigenFinanciamientoFilter() { IdProyecto = id });
            //compose.proyectoOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.GetResult(new ProyectoOrigenFinanciamientoFilter() { IdProyecto = id });
            compose.proyectoPlan = ProyectoPlanBusiness.Current.GetResult(new ProyectoPlanFilter() { IdProyecto = id });
            compose.proyectoRelacion = ProyectoRelacionBusiness.Current.GetResult(new ProyectoRelacionFilter() { IdProyecto = id });

            //UsuarioResult usuario = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { IdUsuario = compose.proyecto.IdUsuarioModificacion }).SingleOrDefault();

            //Trae todos los ProyectoOficinaPerfil para el Proyecto
            List<ProyectoOficinaPerfilResult> proyectoOficinaPerfiles = ProyectoOficinaPerfilBusiness.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdProyecto = id });
            // Asigna el  ProyectoOficinaPerfil segun corresponda          
            compose.proyectoOficinaPerfilIniciador = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "INIC" select o).FirstOrDefault();
            if (compose.proyectoOficinaPerfilIniciador == null)
                compose.proyectoOficinaPerfilIniciador = new ProyectoOficinaPerfilResult();
            compose.proyectoOficinaPerfilEjecutor = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "EJEC" select o).FirstOrDefault();
            if (compose.proyectoOficinaPerfilEjecutor == null)
                compose.proyectoOficinaPerfilEjecutor = new ProyectoOficinaPerfilResult();
            compose.proyectoOficinaPerfilResponsable = (from o in proyectoOficinaPerfiles where o.Perfil_Codigo == "RESP" select o).FirstOrDefault();
            if (compose.proyectoOficinaPerfilResponsable == null)
                compose.proyectoOficinaPerfilResponsable = new ProyectoOficinaPerfilResult();

            #region Querys
            //obtiene los permisos asociados y los que no estan asociados            
            List<ProyectoOficinaPerfilFuncionarioResult> perfilFuncionarios = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetResult(new ProyectoOficinaPerfilFuncionarioFilter()
            {
                IdsProyectoOficinaPerfil = new int[]{compose.proyectoOficinaPerfilEjecutor.IdProyectoOficinaPerfil 
                                                   ,compose.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil
                                                   ,compose.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil }
            });

            List<Persona> personas = PersonaBusiness.Current.GetList(new PersonaFilter()
            {
                IdsOficina = new int[] { compose.proyectoOficinaPerfilEjecutor.IdOficina
                                       , compose.proyectoOficinaPerfilResponsable.IdOficina
                                       , compose.proyectoOficinaPerfilIniciador.IdOficina }
            });
            #endregion

            #region Ejecutor
            List<ProyectoOficinaPerfilFuncionarioResult> unselected = (from a in personas
                                                                       where !(from pa in perfilFuncionarios
                                                                               where pa.IdProyectoOficinaPerfil == compose.proyectoOficinaPerfilEjecutor.IdProyectoOficinaPerfil
                                                                               select pa.IdUsuario).Contains(a.IdPersona)
                                                                       && a.IdOficina == compose.proyectoOficinaPerfilEjecutor.IdOficina
                                                                       // && !(from o in perfilFuncionarios where o.ProyectoOficinaPerfil_IdOficina == compose.proyectoOficinaPerfilEjecutor.IdOficina select o.IdUsuario).Contains(a.IdPersona)
                                                                       select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            compose.proyectoOficinaPerfilFuncionarioEjecutor = new List<ProyectoOficinaPerfilFuncionarioResult>();
            compose.proyectoOficinaPerfilFuncionarioEjecutor.AddRange((from o in perfilFuncionarios where o.ProyectoOficinaPerfil_IdOficina == compose.proyectoOficinaPerfilEjecutor.IdOficina && o.ProyectoOficinaPerfil_IdPerfil == compose.proyectoOficinaPerfilEjecutor.IdPerfil select o).ToArray());
            compose.proyectoOficinaPerfilFuncionarioEjecutor.AddRange(unselected);

            //obtiene los permisos asociados y los que no estan asociados
            //List<ProyectoOficinaPerfilFuncionarioResult> popfResponsable = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetResult(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = compose.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil });
            //personas = PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = compose.proyectoOficinaPerfilResponsable.IdOficina });
            #endregion

            #region Responsable
            unselected = new List<ProyectoOficinaPerfilFuncionarioResult>();
            unselected = (from a in personas
                          where !(from pa in perfilFuncionarios
                                  where pa.IdProyectoOficinaPerfil == compose.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil
                                  select pa.IdUsuario).Contains(a.IdPersona)
                          && a.IdOficina == compose.proyectoOficinaPerfilResponsable.IdOficina
                          select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            compose.proyectoOficinaPerfilFuncionarioResponsable = new List<ProyectoOficinaPerfilFuncionarioResult>();
            compose.proyectoOficinaPerfilFuncionarioResponsable.AddRange((from o in perfilFuncionarios where o.ProyectoOficinaPerfil_IdOficina == compose.proyectoOficinaPerfilResponsable.IdOficina && o.ProyectoOficinaPerfil_IdPerfil == compose.proyectoOficinaPerfilResponsable.IdPerfil select o).ToArray());
            compose.proyectoOficinaPerfilFuncionarioResponsable.AddRange(unselected);


            //unselected = (from a in personas
            //               where !(from pa in popfResponsable select pa.IdUsuario).Contains(a.IdPersona)
            //               && a.IdOficina == compose.proyectoOficinaPerfilEjecutor.IdOficina 
            //               select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            //compose.proyectoOficinaPerfilFuncionarioResponsable = new List<ProyectoOficinaPerfilFuncionarioResult>();
            //compose.proyectoOficinaPerfilFuncionarioResponsable.AddRange(popfResponsable);
            //compose.proyectoOficinaPerfilFuncionarioResponsable.AddRange(unselected);
            #endregion

            #region Iniciador
            unselected = new List<ProyectoOficinaPerfilFuncionarioResult>();
            unselected = (from a in personas
                          where !(from pa in perfilFuncionarios
                                  where pa.IdProyectoOficinaPerfil == compose.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil
                                  select pa.IdUsuario).Contains(a.IdPersona)
                          && a.IdOficina == compose.proyectoOficinaPerfilIniciador.IdOficina
                          //&& (from o in perfilFuncionarios where o.ProyectoOficinaPerfil_IdOficina == compose.proyectoOficinaPerfilIniciador.IdOficina select o.IdUsuario).Contains(a.IdPersona)
                          select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            compose.proyectoOficinaPerfilFuncionarioIniciador = new List<ProyectoOficinaPerfilFuncionarioResult>();
            compose.proyectoOficinaPerfilFuncionarioIniciador.AddRange((from o in perfilFuncionarios where o.ProyectoOficinaPerfil_IdOficina == compose.proyectoOficinaPerfilIniciador.IdOficina && o.ProyectoOficinaPerfil_IdPerfil == compose.proyectoOficinaPerfilIniciador.IdPerfil select o).ToArray());
            compose.proyectoOficinaPerfilFuncionarioIniciador.AddRange(unselected);

            //obtiene los permisos asociados y los que no estan asociados
            //List<ProyectoOficinaPerfilFuncionarioResult> popfIniciador = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetResult(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = compose.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil });
            //personas = PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = compose.proyectoOficinaPerfilIniciador.IdOficina });
            //unselected = (from a in personas
            //              where !(from pa in popfIniciador select pa.IdUsuario).Contains(a.IdPersona)
            //              select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            //compose.proyectoOficinaPerfilFuncionarioIniciador = new List<ProyectoOficinaPerfilFuncionarioResult>();
            //compose.proyectoOficinaPerfilFuncionarioIniciador.AddRange(popfIniciador);
            //compose.proyectoOficinaPerfilFuncionarioIniciador.AddRange(unselected);
            #endregion

            return compose;
        }

        public List<ProyectoOficinaPerfilFuncionarioResult> GetProyectoOficinaPerfilFuncionarioResult(Int32 IdOficina)
        {
            List<Persona> personas = PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = IdOficina });
            List<ProyectoOficinaPerfilFuncionarioResult> unselected = (from a in personas select ToProyectoOficinaPerfilFuncionario(a)).ToList();
            List<ProyectoOficinaPerfilFuncionarioResult> popfr = new List<ProyectoOficinaPerfilFuncionarioResult>();
            popfr.AddRange(unselected);
            return popfr;
        }

        #endregion

        #region Actions
        public override void Add(ProyectoGeneralCompose entity, IContextUser contextUser)
        {
            try
            {
                //Crea el Proyecto
                Proyecto proyecto = entity.proyecto.ToEntity();
                ProyectoBusiness.Current.Add(proyecto, contextUser);
                entity.proyecto.IdProyecto = proyecto.IdProyecto;
                entity.proyecto.FechaAlta = proyecto.FechaAlta;
                entity.proyecto.FechaModificacion = proyecto.FechaModificacion;
                entity.proyecto.Codigo = proyecto.Codigo;
                entity.proyecto.IdUsuarioModificacion = proyecto.IdUsuarioModificacion;

                //Crea el proyectoDemora
                foreach (ProyectoDemoraResult pdr in entity.proyectoDemora)
                {
                    ProyectoDemora pd = pdr.ToEntity();
                    pd.IdProyecto = entity.proyecto.IdProyecto;
                    ProyectoDemoraBusiness.Current.Add(pd, contextUser);
                }

                //Crea el proyectoOrigenFinanciamiento
                foreach (ProyectoOrigenFinanciamientoResult pofr in entity.proyectoOrigenFinanciamiento)
                {
                    pofr.IdProyecto = entity.proyecto.IdProyecto;
                    ProyectoOrigenFinanciamiento pof = pofr.ToEntity();
                    ProyectoOrigenFinanciamientoBusiness.Current.Add(pof, contextUser);
                }

                //Crea el proyectoPlan
                foreach (ProyectoPlanResult ppr in entity.proyectoPlan)
                {
                    ppr.IdProyecto = entity.proyecto.IdProyecto;
                    ProyectoPlan pp = new ProyectoPlan();// = ppr.ToEntity;
                    ProyectoPlanBusiness.Current.Set(ppr, pp, false);
                    ProyectoPlanBusiness.Current.Add(pp, contextUser);
                    proyecto.IdProyectoPlan = pp.IdProyectoPlan;
                    ProyectoBusiness.Current.Update(proyecto, contextUser);

                }

                //Crea el proyectoRelacion
                foreach (ProyectoRelacionResult prr in entity.proyectoRelacion)
                {
                    prr.IdProyecto = entity.proyecto.IdProyecto;
                    ProyectoRelacion pr = prr.ToEntity();
                    ProyectoRelacionBusiness.Current.Add(pr, contextUser);
                }

                entity.proyectoOficinaPerfilIniciador.IdProyecto = proyecto.IdProyecto;
                ProyectoOficinaPerfil iniciador = entity.proyectoOficinaPerfilIniciador.ToEntity();
                ProyectoOficinaPerfilBusiness.Current.Add(iniciador, contextUser);


                entity.proyectoOficinaPerfilEjecutor.IdProyecto = proyecto.IdProyecto;
                ProyectoOficinaPerfil ejecutor = entity.proyectoOficinaPerfilEjecutor.ToEntity();
                ProyectoOficinaPerfilBusiness.Current.Add(ejecutor, contextUser);

                entity.proyectoOficinaPerfilResponsable.IdProyecto = proyecto.IdProyecto;
                ProyectoOficinaPerfil responsable = entity.proyectoOficinaPerfilResponsable.ToEntity();
                ProyectoOficinaPerfilBusiness.Current.Add(responsable, contextUser);


                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioEjecutor)
                {
                    if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                    {
                        popfr.IdProyectoOficinaPerfil = ejecutor.IdProyectoOficinaPerfil;
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popfr.ToEntity(), contextUser);
                    }
                }
                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioResponsable)
                {
                    if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                    {
                        popfr.IdProyectoOficinaPerfil = responsable.IdProyectoOficinaPerfil;
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popfr.ToEntity(), contextUser);
                    }
                }
                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioIniciador)
                {
                    if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                    {
                        popfr.IdProyectoOficinaPerfil = iniciador.IdProyectoOficinaPerfil;
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popfr.ToEntity(), contextUser);
                    }
                }

                SendMessageNuevoProyecto(proyecto, contextUser);


            }
            catch (Exception exception)
            {
                entity.proyecto.IdProyecto = 0;
                entity.proyectoDemora.ForEach(i => i.IdProyecto = 0);
                entity.proyectoOrigenFinanciamiento.ForEach(i => i.IdProyecto = 0);
                entity.proyectoPlan.ForEach(i => i.IdProyecto = 0);
                entity.proyectoRelacion.ForEach(i => i.IdProyecto = 0);

                entity.proyectoOficinaPerfilIniciador.IdProyecto = 0;
                entity.proyectoOficinaPerfilEjecutor.IdProyecto = 0;
                entity.proyectoOficinaPerfilResponsable.IdProyecto = 0;

                entity.proyectoOficinaPerfilFuncionarioEjecutor.ForEach(i => i.IdProyectoOficinaPerfil = 0);
                entity.proyectoOficinaPerfilFuncionarioResponsable.ForEach(i => i.IdProyectoOficinaPerfil = 0);
                entity.proyectoOficinaPerfilFuncionarioIniciador.ForEach(i => i.IdProyectoOficinaPerfil = 0);
                throw exception;
            }
        }
        public override void Update(ProyectoGeneralCompose entity, IContextUser contextUser)
        {
            List<ProyectoDemoraResult> copyDemora = ProyectoDemoraBusiness.Current.CopiesResult(entity.proyectoDemora);
            List<ProyectoOrigenFinanciamientoResult> copyOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.CopiesResult(entity.proyectoOrigenFinanciamiento);
            List<ProyectoPlanResult> copyPlan = ProyectoPlanBusiness.Current.CopiesResult(entity.proyectoPlan);
            List<ProyectoRelacionResult> copyRelacion = ProyectoRelacionBusiness.Current.CopiesResult(entity.proyectoRelacion);
            List<ProyectoOficinaPerfilFuncionarioResult> copyProyectoOficinaPerfilFuncionarioEjecutor = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioEjecutor);
            List<ProyectoOficinaPerfilFuncionarioResult> copyProyectoOficinaPerfilFuncionarioFuncionario = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioResponsable);
            List<ProyectoOficinaPerfilFuncionarioResult> copyProyectoOficinaPerfilFuncionarioIniciador = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioIniciador);

            try
            {
                Proyecto proyecto = ProyectoBusiness.Current.GetById(entity.proyecto.IdProyecto);

                entity.proyecto.OldIdEstado = ProyectoBusiness.Current.GetById(entity.proyecto.IdProyecto).IdEstado; //Matias 20170201 - Ticket #REQ571729

                if (proyecto.IdEstado != entity.proyecto.IdEstado)
                {//se envia un mensaje cuando hay cambio de estado                                       
                    SendMessageCambioEstado(entity.proyecto.ToEntity(), proyecto.IdEstado, entity.proyecto.IdEstado, contextUser);
                }

                if (proyecto.ProyectoDenominacion != entity.proyecto.ProyectoDenominacion)
                {//se envia un mensaje cuando hay cambio de estado                                       
                    SendMessageCambioDeDenominacion(entity.proyecto.ToEntity(), proyecto.ProyectoDenominacion, entity.proyecto.ProyectoDenominacion, contextUser);
                }

                if (proyecto.IdProceso != entity.proyecto.IdProceso)
                {//se envia un mensaje cuando hay cambio de estado 

                    string procesoAnterior = string.Empty;
                    string procesoActual = string.Empty;

                    if (proyecto.IdProceso != null)
                        procesoAnterior = ProcesoBusiness.Current.GetById((int)proyecto.IdProceso).Nombre;

                    if (entity.proyecto.IdProceso != null)
                        procesoActual = ProcesoBusiness.Current.GetById((int)entity.proyecto.IdProceso).Nombre;


                    SendMessageCambioDeProceso(entity.proyecto.ToEntity(), procesoAnterior, procesoActual, contextUser);
                }



                ProyectoBusiness.Current.Set(entity.proyecto, proyecto);
                ProyectoBusiness.Current.Update(proyecto, contextUser);


                //actualiza ProyectoDemora

                //Elimino los que ya no forman parte
                List<int> actualIdsDemora = (from o in entity.proyectoDemora where o.IdProyectoDemora > 0 select o.IdProyectoDemora).ToList();
                List<ProyectoDemora> oldDetailDemora = ProyectoDemoraBusiness.Current.GetList(new ProyectoDemoraFilter() { IdProyecto = entity.proyecto.IdProyecto });
                List<ProyectoDemora> deletetsDemora = (from o in oldDetailDemora where !actualIdsDemora.Contains(o.IdProyectoDemora) select o).ToList();
                ProyectoDemoraBusiness.Current.Delete(deletetsDemora, contextUser);

                foreach (ProyectoDemoraResult pdr in entity.proyectoDemora)
                {
                    ProyectoDemora pd = pdr.ToEntity();
                    if (pdr.IdProyectoDemora < 1)
                    {
                        //Agrego los nuevos
                        pd.IdProyecto = entity.proyecto.IdProyecto;
                        ProyectoDemoraBusiness.Current.Add(pd, contextUser);
                        pdr.IdProyectoDemora = pd.IdProyectoDemora;
                    }
                    else
                    {
                        ProyectoDemora pdOld = ProyectoDemoraBusiness.Current.GetById(pdr.IdProyectoDemora);
                        if (!ProyectoDemoraBusiness.Current.Equals(pd, pdOld))
                        {
                            pdOld.Fecha = pdr.Fecha;
                            pdOld.Justificacion = pdr.Justificacion;
                            ProyectoDemoraBusiness.Current.Update(pdOld, contextUser);
                        }
                    }
                }

                //actualiza ProyectoOrigenFinanciamiento

                //Elimino los que ya no forman parte
                List<int> actualIdsOrigenFinanciamiento = (from o in entity.proyectoOrigenFinanciamiento where o.IdProyectoOrigenFinanciamiento > 0 select o.IdProyectoOrigenFinanciamiento).ToList();
                List<ProyectoOrigenFinanciamiento> oldDetailOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.GetList(new ProyectoOrigenFinanciamientoFilter() { IdProyecto = entity.proyecto.IdProyecto });
                List<ProyectoOrigenFinanciamiento> deletetsOrigenFinanciamiento = (from o in oldDetailOrigenFinanciamiento where !actualIdsOrigenFinanciamiento.Contains(o.IdProyectoOrigenFinanciamiento) select o).ToList();
                ProyectoOrigenFinanciamientoBusiness.Current.Delete(deletetsOrigenFinanciamiento, contextUser);
                // TODO ACA ELIMINAR LOS PRESTAMOS PRODUCTOS QUE TENGA ESTE ORIGEN DE FINANCIMIENTO
                foreach (ProyectoOrigenFinanciamientoResult pofr in entity.proyectoOrigenFinanciamiento)
                {
                    ProyectoOrigenFinanciamiento pof = pofr.ToEntity();
                    if (pofr.IdProyectoOrigenFinanciamiento < 1)
                    {
                        //Agrego los nuevos
                        pof.IdProyecto = entity.proyecto.IdProyecto;
                        ProyectoOrigenFinanciamientoBusiness.Current.Add(pof, contextUser);
                        pofr.IdProyectoOrigenFinanciamiento = pof.IdProyectoOrigenFinanciamiento;

                        // TODO agregar este registro tambien en la tabla PrestamoProducto
                        // primero buscar el componente del prestamo (si tiene al menos uno), para asignarselo por defecto a este objeto
                        // Si no tiene ninguno, no se podra agregar el registro y se debera informar mediante un ALERT
                    }
                    else
                    {
                        ProyectoOrigenFinanciamiento pofOld = ProyectoOrigenFinanciamientoBusiness.Current.GetById(pofr.IdProyectoOrigenFinanciamiento);
                        if (!ProyectoOrigenFinanciamientoBusiness.Current.Equals(pof, pofOld))
                        {
                            pofOld.IdProyectoOrigenFinancianmientoTipo = pofr.IdProyectoOrigenFinancianmientoTipo;
                            pofOld.IdPrestamo = pofr.IdPrestamo;
                            ProyectoOrigenFinanciamientoBusiness.Current.Update(pofOld, contextUser);
                        }

                        //TODO actualizar este registro tambien en la tabla PrestamoProducto
                    }
                }

                //Matias 20170213 - Ticket #REQ317348
                //Blanquea, en caso de existir, el proyecto asociado al Prestamo en la Solapa Producto.
                //No elimina el registro, sino que blanquea el Proyecto asociado.
                foreach (ProyectoOrigenFinanciamiento pofDeleted in deletetsOrigenFinanciamiento)
                {
                    List<PrestamoProducto> deletesPP = new List<PrestamoProducto>();
                    //creo un filtro para origen de financiamiento asi elimino los registros
                    PrestamoProductoFilter filtroPP = new PrestamoProductoFilter();
                    filtroPP.IdProyectoOrigenFinanciamiento = pofDeleted.IdProyectoOrigenFinanciamiento;

                    PrestamoProducto pp = PrestamoProductoBusiness.Current.GetList(filtroPP).FirstOrDefault();

                    if (pp != null)
                    {
                        pp.IdProyecto = null;
                        pp.IdProyectoOrigenFinanciamiento = 0;
                        deletesPP.Add(pp);
                        PrestamoProductoBusiness.Current.Update(deletesPP, contextUser);
                    }
                    
                    //Matias 20170214 - Ticket #REQ512226
                    //Genero mensajes con información relacionada a la baja de Prestamo vinculado al Proyecto en Origen de Financiamiento.
                    if (pofDeleted != null)
                        this.SendMessageBajaPrestamo(entity.proyecto, pofDeleted, contextUser);                    
                    //FinMatias 20170214 - Ticket #REQ512226
                }                
                //FinMatias 20170213 - Ticket #REQ317348
                

                //actualiza ProyectoPlan

                //Elimino los que ya no forman parte
                List<int> actualIdsPlan = (from o in entity.proyectoPlan where o.IdProyectoPlan > 0 select o.IdProyectoPlan).ToList();
                List<ProyectoPlan> oldDetailPlan = ProyectoPlanBusiness.Current.GetList(new ProyectoPlanFilter() { IdProyecto = entity.proyecto.IdProyecto });
                List<ProyectoPlan> deletetsPlan = (from o in oldDetailPlan where !actualIdsPlan.Contains(o.IdProyectoPlan) select o).ToList();

                foreach (ProyectoPlan pp in deletetsPlan)
                {
                    ProyectoPlanResult ppResult = ProyectoPlanBusiness.Current.GetResult(new ProyectoPlanFilter() { IdProyectoPlan = pp.IdProyectoPlan }).SingleOrDefault();
                    SendMessagePlanEliminado(entity.proyecto.ToEntity(), String.Format("{0} {1} {2}", ppResult.PlanTipo_Nombre, ppResult.PlanPeriodo_Periodo, ppResult.PlanVersion_Nombre), contextUser);
                    ProyectoPlanBusiness.Current.Delete(ppResult.IdProyectoPlan, contextUser);

                }

                //ProyectoPlanBusiness.Current.Delete(deletetsPlan, contextUser);

                foreach (ProyectoPlanResult ppr in entity.proyectoPlan)
                {
                    ProyectoPlan pp = ppr.ToEntity();
                    if (ppr.IdProyectoPlan < 1)
                    {
                        //Agrego los nuevos
                        pp.IdProyecto = entity.proyecto.IdProyecto;
                        ProyectoPlanBusiness.Current.Add(pp, contextUser);
                        ppr.IdProyectoPlan = pp.IdProyectoPlan;
                        SendMessagePlanNuevo(entity.proyecto.ToEntity(), String.Format("{0} {1} {2}", ppr.PlanTipo_Nombre, ppr.PlanPeriodo_Periodo, ppr.PlanVersion_Nombre), contextUser);
                    }
                    else
                    {
                        ProyectoPlan ppOld = ProyectoPlanBusiness.Current.GetById(pp.IdProyectoPlan);
                        if (!ProyectoPlanBusiness.Current.Equals(pp, ppOld))
                        {
                            ppOld.IdPlanPeriodo = ppr.IdPlanPeriodo;
                            ppOld.IdPlanVersion = ppr.IdPlanVersion;
                            ppOld.Fecha = ppr.Fecha;
                            ProyectoPlanBusiness.Current.Update(ppOld, contextUser);
                        }
                    }

                    //proyecto.IdProyectoPlan = ppr.IdProyectoPlan;
                    //ProyectoBusiness.Current.Update(proyecto, contextUser);
                }

                //Matias 20141114 - Tarea 175                    
                //Matias 20170131 - Ticket #ER682004
                //ProyectoPlanResult pprf = entity.proyectoPlan.FirstOrDefault();
                if (entity.proyectoPlan.Count > 0)
                {
                    int IdProyectoPlanMAX = entity.proyectoPlan.Max(ProyectoPlan => ProyectoPlan.IdProyectoPlan);
                    ProyectoPlanResult pprf = entity.proyectoPlan.FirstOrDefault(ProyectoPlan => ProyectoPlan.IdProyectoPlan == IdProyectoPlanMAX);
                    //FinMatias 20170131 - Ticket #ER682004
                    if (pprf != null)
                    {
                        entity.proyecto.IdProyectoPlan = pprf.IdProyectoPlan;
                        ProyectoBusiness.Current.Set(entity.proyecto, proyecto);
                        ProyectoBusiness.Current.Update(proyecto, contextUser);
                    }
                }
                else
                {
                    entity.proyecto.IdProyectoPlan = null;
                    ProyectoBusiness.Current.Set(entity.proyecto, proyecto);
                    ProyectoBusiness.Current.Update(proyecto, contextUser);
                }
                //FinMatias 20141114 - Tarea 175


                //actualiza ProyectoRelacion

                //Elimino los que ya no forman parte
                List<int> actualIdsRelacion = (from o in entity.proyectoRelacion where o.IdProyectoRelacion > 0 select o.IdProyectoRelacion).ToList();
                List<ProyectoRelacion> oldDetailRelacion = ProyectoRelacionBusiness.Current.GetList(new ProyectoRelacionFilter() { IdProyecto = entity.proyecto.IdProyecto });
                List<ProyectoRelacion> deletetsRelacion = (from o in oldDetailRelacion where !actualIdsRelacion.Contains(o.IdProyectoRelacion) select o).ToList();
                ProyectoRelacionBusiness.Current.Delete(deletetsRelacion, contextUser);

                foreach (ProyectoRelacionResult prr in entity.proyectoRelacion)
                {
                    ProyectoRelacion pr = prr.ToEntity();
                    if (prr.IdProyectoRelacion < 1)
                    {
                        //Agrego los nuevos
                        pr.IdProyecto = entity.proyecto.IdProyecto;
                        ProyectoRelacionBusiness.Current.Add(pr, contextUser);
                        prr.IdProyectoRelacion = pr.IdProyectoRelacion;

                    }
                    else
                    {
                        ProyectoRelacion prOld = ProyectoRelacionBusiness.Current.GetById(pr.IdProyectoRelacion);
                        if (!ProyectoRelacionBusiness.Current.Equals(pr, prOld))
                        {
                            prOld.IdProyectoRelacionado = prr.IdProyectoRelacionado;
                            prOld.IdProyectoRelacionTipo = prr.IdProyectoRelacionTipo;
                            ProyectoRelacionBusiness.Current.Update(prOld, contextUser);
                        }
                    }
                }
                #region Iniciador
                ProyectoOficinaPerfilResult proyectoPerfilIniciadorResult = ProyectoOficinaPerfilBusiness.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdProyecto = proyecto.IdProyecto, CodigoPerfil = "INIC" }).SingleOrDefault();
                if (entity.proyectoOficinaPerfilIniciador != null && entity.proyectoOficinaPerfilIniciador.IdOficina > 0)
                {
                    if (proyectoPerfilIniciadorResult != null)
                    {
                        ProyectoOficinaPerfil proyectoPerfilIniciador = proyectoPerfilIniciadorResult.ToEntity(); ;
                        if (!entity.proyectoOficinaPerfilIniciador.Equals(proyectoPerfilIniciador))
                        {
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilIniciador.IdProyectoOficinaPerfil }, contextUser);
                            ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilIniciador.IdProyectoOficinaPerfil, contextUser);
                            if (entity.proyectoOficinaPerfilIniciador.IdOficina != 0)
                            {
                                ProyectoOficinaPerfil pop = entity.proyectoOficinaPerfilIniciador.ToEntity();
                                entity.proyectoOficinaPerfilIniciador.IdProyecto = proyecto.IdProyecto;
                                ProyectoOficinaPerfilBusiness.Current.Add(pop, contextUser);
                                entity.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil;
                            }
                        }
                    }
                    else
                    {
                        Perfil perfilIniciador = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "INIC" });

                        entity.proyectoOficinaPerfilIniciador.IdProyecto = proyecto.IdProyecto;
                        entity.proyectoOficinaPerfilIniciador.IdPerfil = perfilIniciador.IdPerfil;
                        ProyectoOficinaPerfil iniciador = entity.proyectoOficinaPerfilIniciador.ToEntity();
                        ProyectoOficinaPerfilBusiness.Current.Add(iniciador, contextUser);
                        entity.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil = iniciador.IdProyectoOficinaPerfil;
                    }

                    foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioIniciador)
                    {
                        if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                        {
                            popfr.IdProyectoOficinaPerfil = entity.proyectoOficinaPerfilIniciador.IdProyectoOficinaPerfil;
                            ProyectoOficinaPerfilFuncionario popf = popfr.ToEntity();
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popf, contextUser);
                            popfr.IdProyectoOficinaPerfilFuncionario = popf.IdProyectoOficinaPerfilFuncionario;
                        }
                        if (!popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario > 1)
                        {
                            ProyectoOficinaPerfilFuncionario popf = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetById(popfr.IdProyectoOficinaPerfilFuncionario);
                            if (popf != null)
                                ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(popf, contextUser);
                        }
                    }
                }
                else
                {
                    if (proyectoPerfilIniciadorResult != null && proyectoPerfilIniciadorResult.IdProyectoOficinaPerfil > 0)
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilIniciadorResult.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilIniciadorResult.IdProyectoOficinaPerfil, contextUser);
                    }
                }
                #endregion
                #region Ejecutor
                ProyectoOficinaPerfilResult proyectoPerfilEjecutorResult = ProyectoOficinaPerfilBusiness.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdProyecto = proyecto.IdProyecto, CodigoPerfil = "EJEC" }).DefaultIfEmpty().SingleOrDefault();
                if (entity.proyectoOficinaPerfilEjecutor != null && entity.proyectoOficinaPerfilEjecutor.IdOficina > 0)
                {
                    if (proyectoPerfilEjecutorResult != null)
                    {
                        ProyectoOficinaPerfil proyectoPerfilEjecutor = proyectoPerfilEjecutorResult.ToEntity();
                        if (!entity.proyectoOficinaPerfilEjecutor.Equals(proyectoPerfilEjecutor))
                        {
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilEjecutor.IdProyectoOficinaPerfil }, contextUser);
                            ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilEjecutor.IdProyectoOficinaPerfil, contextUser);
                            if (entity.proyectoOficinaPerfilEjecutor.IdOficina != 0)
                            {
                                ProyectoOficinaPerfil pop = entity.proyectoOficinaPerfilEjecutor.ToEntity();
                                entity.proyectoOficinaPerfilEjecutor.IdProyecto = proyecto.IdProyecto;
                                ProyectoOficinaPerfilBusiness.Current.Add(pop, contextUser);
                                entity.proyectoOficinaPerfilEjecutor.IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil;
                            }
                        }
                    }
                    else
                    {
                        Perfil perfilEjecutor = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "EJEC" });

                        entity.proyectoOficinaPerfilEjecutor.IdProyecto = proyecto.IdProyecto;
                        entity.proyectoOficinaPerfilEjecutor.IdPerfil = perfilEjecutor.IdPerfil;
                        ProyectoOficinaPerfil ejecutor = entity.proyectoOficinaPerfilEjecutor.ToEntity();
                        ProyectoOficinaPerfilBusiness.Current.Add(ejecutor, contextUser);
                        entity.proyectoOficinaPerfilEjecutor.IdProyectoOficinaPerfil = ejecutor.IdProyectoOficinaPerfil;
                    }
                    foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioEjecutor)
                    {
                        if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                        {
                            popfr.IdProyectoOficinaPerfil = entity.proyectoOficinaPerfilEjecutor.IdProyectoOficinaPerfil;
                            ProyectoOficinaPerfilFuncionario popf = popfr.ToEntity();
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popf, contextUser);
                            popfr.IdProyectoOficinaPerfilFuncionario = popf.IdProyectoOficinaPerfilFuncionario;
                        }
                        if (!popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario > 1)
                        {
                            ProyectoOficinaPerfilFuncionario popf = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetById(popfr.IdProyectoOficinaPerfilFuncionario);
                            if (popf != null)
                                ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(popf, contextUser);
                        }
                    }
                }
                else
                {
                    if (proyectoPerfilEjecutorResult != null && proyectoPerfilEjecutorResult.IdProyectoOficinaPerfil > 0)
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilEjecutorResult.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilEjecutorResult.IdProyectoOficinaPerfil, contextUser);
                    }
                }
                #endregion
                #region Responsable
                ProyectoOficinaPerfilResult proyectoPerfilResponsableResult = ProyectoOficinaPerfilBusiness.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdProyecto = proyecto.IdProyecto, CodigoPerfil = "RESP" }).DefaultIfEmpty().SingleOrDefault();
                if (entity.proyectoOficinaPerfilResponsable != null && entity.proyectoOficinaPerfilResponsable.IdOficina > 0)
                {
                    if (proyectoPerfilResponsableResult != null)
                    {
                        ProyectoOficinaPerfil proyectoPerfilResponsable = proyectoPerfilResponsableResult.ToEntity();
                        if (!entity.proyectoOficinaPerfilResponsable.Equals(proyectoPerfilResponsable))
                        {
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilResponsable.IdProyectoOficinaPerfil }, contextUser);
                            ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilResponsable.IdProyectoOficinaPerfil, contextUser);
                            if (entity.proyectoOficinaPerfilResponsable.IdOficina != 0)
                            {
                                ProyectoOficinaPerfil pop = entity.proyectoOficinaPerfilResponsable.ToEntity();
                                entity.proyectoOficinaPerfilResponsable.IdProyecto = proyecto.IdProyecto;
                                ProyectoOficinaPerfilBusiness.Current.Add(pop, contextUser);
                                entity.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil = pop.IdProyectoOficinaPerfil;
                            }
                        }
                    }
                    else
                    {
                        Perfil perfilResponsable = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "RESP" });

                        entity.proyectoOficinaPerfilResponsable.IdProyecto = proyecto.IdProyecto;
                        entity.proyectoOficinaPerfilResponsable.IdPerfil = perfilResponsable.IdPerfil;
                        ProyectoOficinaPerfil responsable = entity.proyectoOficinaPerfilResponsable.ToEntity();
                        ProyectoOficinaPerfilBusiness.Current.Add(responsable, contextUser);
                        entity.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil = responsable.IdProyectoOficinaPerfil;
                    }

                    foreach (ProyectoOficinaPerfilFuncionarioResult popfr in entity.proyectoOficinaPerfilFuncionarioResponsable)
                    {
                        if (popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario < 1)
                        {
                            popfr.IdProyectoOficinaPerfil = entity.proyectoOficinaPerfilResponsable.IdProyectoOficinaPerfil;
                            ProyectoOficinaPerfilFuncionario popf = popfr.ToEntity();
                            ProyectoOficinaPerfilFuncionarioBusiness.Current.Add(popf, contextUser);
                            popfr.IdProyectoOficinaPerfilFuncionario = popf.IdProyectoOficinaPerfilFuncionario;
                        }
                        if (!popfr.Selected && popfr.IdProyectoOficinaPerfilFuncionario > 1)
                        {
                            ProyectoOficinaPerfilFuncionario popf = ProyectoOficinaPerfilFuncionarioBusiness.Current.GetById(popfr.IdProyectoOficinaPerfilFuncionario);
                            if (popf != null)
                                ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(popf, contextUser);
                        }
                    }
                }
                else
                {
                    if (proyectoPerfilResponsableResult != null && proyectoPerfilResponsableResult.IdProyectoOficinaPerfil > 0)
                    {
                        ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdProyectoOficinaPerfil = proyectoPerfilResponsableResult.IdProyectoOficinaPerfil }, contextUser);
                        ProyectoOficinaPerfilBusiness.Current.Delete(proyectoPerfilResponsableResult.IdProyectoOficinaPerfil, contextUser);
                    }
                }
                #endregion

                //Matias 20170131 - Ticket #REQ571729
                #region
                //...Esto que esta comnetado funciona para CREAR COPIA del Proyecto; pero yo necesito CREAR HISTORICO (NO Copia!)...
                //Tengo que validar que NO ENTRE EN LOOP; al guardar un nuevo proyecto vuelve a este método para guardar los gastos.
                //ProyectCopy result = new ProyectCopy();
                //result.IdProject = ProyectoBusiness.Current.GetById(entity.IdProyecto).IdProyecto;
                //result.Codigo = ProyectoBusiness.Current.GetById(entity.IdProyecto).Codigo.ToString();
                //result.Rename = ProyectoBusiness.Current.GetById(entity.IdProyecto).ProyectoDenominacion;
                //result.Offset = 0;
                //result.Solapas.AlcanceGeografico = true;
                //result.Solapas.Cronograma = false;
                //result.Solapas.Evaluacion = true;
                //result.Solapas.General = true;
                //result.Solapas.Objetivos = true;
                //result.Solapas.ProductosIntermedios = true;
                //ProyectoBusiness.Current.CopyAndSave(result.IdProject, result, contextUser);
                //...Fin...
                #endregion
                if ((entity.proyecto.OldIdEstado != (int)EstadoEnum.En_Ejecucion) && (entity.proyecto.IdEstado == (int)EstadoEnum.En_Ejecucion))
                {
                    //Primero debería preguntar si quiere generar la COPIA HISTORICA.
                    //Es muy complejo preguntar en esta instancia.

                    //Genero la COPIA HISTORICA
                    SistemaReporte Report = SistemaReporteBusiness.Current.FirstOrDefault(new SistemaReporteFilter() { Codigo = "Proyecto", Activo = true });
                    if (Report != null)
                    {
                        ReportHistoryInfo rhi = new ReportHistoryInfo();

                        ProyectoFilter pf = new ProyectoFilter();

                        ProyectoPrintFilter ppf = new ProyectoPrintFilter();
                        ppf.IdProyecto = entity.proyecto.IdProyecto;
                        ppf.Adjuntos = true;
                        ppf.AlcanceGeografico = true;
                        ppf.Cronograma = true;
                        ppf.Evaluacion = true;
                        ppf.IncluyeDatosSecundarios = true;
                        ppf.IncluyeDetalleDeEtapas = true;
                        ppf.IncluyeDetallePorObjetoDelGastoYAnios = true;
                        ppf.IncluyeEvolucionDeIndicadoresEvaluacion = true;
                        ppf.IncluyeEvolucionDeIndicadoresObjetivos = true;
                        ppf.IntervencionDNIP = true;
                        ppf.Objetivos = true;
                        ppf.ProductoIntermedio = true;
                        ppf.SolapaGeneral = true;

                        pf.printFilter = ppf;

                        rhi.Comments = "Por inicio de ejecución se deja constancia de los montos totales estimados del proyecto a la fecha.";
                        ProyectoBusiness.Current.SaveHistoryReport(Report, rhi, pf, contextUser);
                    }
                }                
                //FinMatias 20170131 - Ticket #REQ571729
            }
            catch (Exception exception)
            {
                entity.proyectoDemora = copyDemora;
                entity.proyectoOrigenFinanciamiento = copyOrigenFinanciamiento;
                entity.proyectoPlan = copyPlan;
                entity.proyectoRelacion = copyRelacion;

                entity.proyectoOficinaPerfilFuncionarioEjecutor = copyProyectoOficinaPerfilFuncionarioEjecutor;
                entity.proyectoOficinaPerfilFuncionarioResponsable = copyProyectoOficinaPerfilFuncionarioFuncionario;
                entity.proyectoOficinaPerfilFuncionarioIniciador = copyProyectoOficinaPerfilFuncionarioIniciador;
                throw exception;
            }
        }
        public override void Delete(ProyectoGeneralCompose entity, IContextUser contextUser)
        {
            ProyectoBusiness.Current.Delete(entity.proyecto.IdProyecto, contextUser);
        }
        public virtual int CopyAndSaveProyecto(int oldId, ProyectCopy proyectoCopy, IContextUser contextUser)
        {
            ProyectoGeneralCompose entity = GetById(oldId);
            ProyectoGeneralCompose newEntity = Copy(entity, proyectoCopy, contextUser);
            Add(newEntity, contextUser);
            proyectoCopy.Codigo = newEntity.proyecto.CodigoString; //Matias 20140331 - Tarea 131
            return GetId(newEntity);
        }
        public virtual ProyectoGeneralCompose Copy(ProyectoGeneralCompose entity, ProyectCopy proyectoCopy, IContextUser contextUser)
        {
            ProyectoGeneralCompose newEntity = GetNew();
            newEntity.proyecto = ProyectoBusiness.Current.CopyProyecto(entity.proyecto, proyectoCopy, contextUser);
            //newEntity.proyectoDemora = ProyectoDemoraBusiness.Current.CopiesResult(entity.proyectoDemora);
            newEntity.proyectoOficinaPerfilEjecutor = ProyectoOficinaPerfilBusiness.Current.CopyResult(entity.proyectoOficinaPerfilEjecutor);
            newEntity.proyectoOficinaPerfilIniciador = ProyectoOficinaPerfilBusiness.Current.CopyResult(entity.proyectoOficinaPerfilIniciador);
            newEntity.proyectoOficinaPerfilResponsable = ProyectoOficinaPerfilBusiness.Current.CopyResult(entity.proyectoOficinaPerfilResponsable);
            newEntity.proyectoOficinaPerfilFuncionarioEjecutor = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioEjecutor);
            newEntity.proyectoOficinaPerfilFuncionarioEjecutor.ForEach(p => p.IdProyectoOficinaPerfilFuncionario = 0);
            newEntity.proyectoOficinaPerfilFuncionarioResponsable = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioResponsable);
            newEntity.proyectoOficinaPerfilFuncionarioResponsable.ForEach(p => p.IdProyectoOficinaPerfilFuncionario = 0);
            newEntity.proyectoOficinaPerfilFuncionarioIniciador = ProyectoOficinaPerfilFuncionarioBusiness.Current.CopiesResult(entity.proyectoOficinaPerfilFuncionarioIniciador);
            newEntity.proyectoOficinaPerfilFuncionarioIniciador.ForEach(p => p.IdProyectoOficinaPerfilFuncionario = 0);

            //newEntity.proyectoOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.CopiesResult(entity.proyectoOrigenFinanciamiento);
            //newEntity.proyectoPlan = ProyectoPlanBusiness.Current.CopiesResult(entity.proyectoPlan);
            //newEntity.proyectoPrioridad = ProyectoPrioridadBusiness.Current.CopiesResult(entity.proyectoPrioridad);
            //newEntity.proyectoRelacion = ProyectoRelacionBusiness.Current.CopiesResult(entity.proyectoRelacion);
            return newEntity;
        }
        #endregion

        #region Messages
        public void SendMessageCambioEstado(Proyecto proyecto, int desdeIdEstado, int hastaIdEstado, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgProyectoEstadoModificadoActive") == false) return;

            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string estadoDesde = SolutionContext.Current.EstadosCache.GetById(desdeIdEstado).Nombre;
            string estadoHasta = SolutionContext.Current.EstadosCache.GetById(hastaIdEstado).Nombre;
            string textMessage = Translate("MsgProyectoEstadoModificado", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, estadoDesde, estadoHasta, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
               "Cambio de Estado", body, proyecto.IdProyecto, contextUser);

        }

        public void SendMessagePlanNuevo(Proyecto proyecto, string plan, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgPlanNuevoActive") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgPlanNuevo", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, plan, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Cambio de Plan", body, proyecto.IdProyecto, contextUser);

        }

        public void SendMessagePlanEliminado(Proyecto proyecto, string plan, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgPlanEliminadoActive.") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgPlanEliminado", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, plan, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Plan Eliminado", body, proyecto.IdProyecto, contextUser);

        }

        public void SendMessageCambioDeProceso(Proyecto proyecto, string procesoAnterior, string procesoActual, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgProcesoModificadoActive") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgProcesoModificado", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, procesoAnterior, procesoActual, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Cambio de Proceso", body, proyecto.IdProyecto, contextUser);
        }

        public void SendMessageCambioDeDenominacion(Proyecto proyecto, string denominacionAnterior, string denominacionActual, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgProyectoDenominacionModificacionActive") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgProyectoDenominacionModificacion", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, denominacionAnterior, denominacionActual, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Cambio de Denominación", body, proyecto.IdProyecto, contextUser);
        }

        public void SendMessageNuevoProyecto(Proyecto proyecto, IContextUser contextUser)
        {
            if (SolutionContext.Current.SystemUser == null) return;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("MsgProyectoNuevoActive") == false) return;
            Programa programa = ProgramaBusiness.Current.FirstOrDefault(new ProgramaFilter() { IdSubPrograma = proyecto.IdSubPrograma });
            if (programa == null || programa.IdSectorialista.HasValue == false) return;
            string proyectoCodigo = programa.Saf.Codigo + "." + programa.Codigo + "." + proyecto.Codigo;
            string textMessage = Translate("MsgProyectoNuevo", contextUser);
            //Matias 20170223 - Ticket #ER503459
            string nombreCompleto = PersonaBusiness.Current.GetById(SolutionContext.Current.SystemUser.IdUsuario).NombreCompleto;
            //Matias 20170223 - Ticket #ER503459
            string body = string.Format(textMessage, proyectoCodigo, proyecto.ProyectoDenominacion, nombreCompleto /*SolutionContext.Current.SystemUser.Persona.NombreCompleto - Matias 20170223 - Ticket #ER503459 */, DateTime.Now);
            SolutionContext.Current.MessageManager.Send(SolutionContext.Current.SystemUser.IdUsuario, new int[] { programa.IdSectorialista.Value },
                "Nuevo Proyecto", body, proyecto.IdProyecto, contextUser);
        }

        //Matias 20170214 - Ticket #REQ512226
        private void SendMessageBajaPrestamo(ProyectoResult proyecto, ProyectoOrigenFinanciamiento deleteOrigFinanc, IContextUser contextUser)
        {
            // busco el usuario SISTEMA BAPIN para asignarlo al mensaje que voy a enviar
            UsuarioFilter filtroUsuario = new UsuarioFilter();
            filtroUsuario.NombreUsuario = "BAPIN";
            filtroUsuario.Clave = "BAPIN";

            UsuarioResult usuarioResult = UsuarioBusiness.Current.GetResult(filtroUsuario).FirstOrDefault();

            if (usuarioResult != null)
            {
                // creo el objeto Message
                Message message = new Message();
                message.IdMediaFrom = 1;
                message.IdPriority = 3;
                message.IdUserFrom = usuarioResult.IdUsuario; ;
                message.IsManual = false;
                message.Subject = "Desvinculación del Proyecto N° " + proyecto.Codigo  + " con el Préstamo N° " + deleteOrigFinanc.Prestamo.Numero;
                message.IdProyecto = proyecto.IdProyecto;
                message.StartDate = DateTime.Now;
                message.SendDate = DateTime.Now;
                message.Body = "El sistema BAPIN informa que en el día de la fecha se ha desvinculado el Préstamo del Proyecto en referencia." +
                    " La desvinculación ha sido gestionada por el usuario: " + contextUser.User.ApellidoYNombre;

                MessageBusiness.Current.Add(message, contextUser);
                int idMensaje = message.IdMessage;

                if (idMensaje > 0)
                {
                    // creo el objeto para enviar el mensaje
                    MessageSend messageSend = new MessageSend();
                    messageSend.IdMediaTo = 1;
                    messageSend.IdMessage = idMensaje;
                    messageSend.IdUserTo = proyecto.IdUsuarioModificacion; //Ultimo usuario que modifico el proyecto.
                    messageSend.IsRead = false;

                    // Envio el mensaje
                    MessageSendBusiness.Current.Add(messageSend, contextUser);
                }
            }
        }
        //FinMatias 20170214 - Ticket #REQ512226

        #endregion


        #region Validations
        public override void Validate(ProyectoGeneralCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            //Revisar y modificar nuevos valores Daniela
            base.Validate(entity, actionName, contextUser, args);
            ProyectoBusiness.Current.Validate(entity.proyecto, actionName, contextUser, args);
            
            //Matias 20170119 - Ticket #REQ377345
            //Validacion fija, el Iniciador NO puede estar vacio.
            DataHelper.Validate(entity.proyectoOficinaPerfilIniciador.IdOficina != null && entity.proyectoOficinaPerfilIniciador.IdOficina != 0, "FieldIsNull", "Oficina Iniciador");
            //FinMatias 20170119 - Ticket #REQ377345
            
            if (entity.proyecto.EvaluarValidaciones == false) return;
            
            #region Por Estado
            if (GetParameterProyectoPorEstado())
            {

                switch (entity.proyecto.IdEstado)
                {
                    case (short)EstadoEnum.Idea:
                        ValidateEstadoIdea(entity.proyecto);
                        break;
                    //prefactivilidad verifica lo mismo que los estados previos (idea,prefil)
                    case (short)EstadoEnum.PreFactibilidad:
                    case (short)EstadoEnum.Perfil:
                        ValidateEstadoPerfil(entity.proyecto);
                        break;
                    case (short)EstadoEnum.Factibilidad:
                        ValidateEstadoFactibilidad(entity.proyecto);
                        break;
                    case (short)EstadoEnum.En_Ejecucion:
                        //ValidateEstadoFactibilidad(entity.proyecto);
                        ValidateEstadoEjecucion(entity);
                        break;
                    case (short)EstadoEnum.Terminado:
                        //ValidateEstadoFactibilidad(entity.proyecto);
                        ValidateEstadoEjecucion(entity);
                        ValidateEstadoTerminado(entity.proyecto);
                        break;
                    default:
                        break;
                }

            }
            #endregion
            #region Por Plan
            //Si se desea controlar el ingreso de  una Marca de Plan
            if (GetParameterProyectoPorPlan())
            {
                //Verifico que hayan incorporado un Plant del tipo PNIP
                if (entity.proyectoPlan.Where(i => i.IdProyectoPlan < 0 && i.IdPlanTipo == GetParameterIDPlanTipoPNIP()).Count() > 0)
                {
                    //Controla que el monto de gastos estimados para el periodo seleccionado sea >0 (para la fase de ejecucion)
                    Int32 Min = entity.proyectoPlan.Where(i => i.IdProyectoPlan < 0 && i.IdPlanTipo == GetParameterIDPlanTipoPNIP()).Min(i => i.PlanPeriodo_AnioInicial);
                    Int32 Max = entity.proyectoPlan.Where(i => i.IdProyectoPlan < 0 && i.IdPlanTipo == GetParameterIDPlanTipoPNIP()).Max(i => i.PlanPeriodo_AnioFinal);
                    DataHelper.Validate(
                        ((from peep in ProyectoEtapaEstimadoPeriodoBusiness.Current.GetResult(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyecto = entity.proyecto.IdProyecto, IdFase = (int)FaseEnum.Ejecucion })
                          where peep.Periodo >= Min && peep.Periodo <= Max
                          select peep).Sum(i => i.MontoCalculado) != 0)
                    , "La sumatoria de los montos de los Gastos Estimados, para la fase de ejecución, en el trienio del Plan debe ser mayor que cero");

                    //Controla que No se encuentre en un estado inconsistente
                    DataHelper.Validate(entity.proyecto.IdEstado != (int)EstadoEnum.Idea, "El proyecto no puede estar en estado Idea");
                    DataHelper.Validate(entity.proyecto.IdEstado != (int)EstadoEnum.Terminado, "El proyecto no puede estar en estado Terminado");
                    DataHelper.Validate(entity.proyecto.IdEstado != (int)EstadoEnum.En_Operacion, "El proyecto no puede estar en estado Operacion");
                    DataHelper.Validate(entity.proyecto.IdEstado != (int)EstadoEnum.Cancelado, "El proyecto no puede estar en estado Cancelado");
                    DataHelper.Validate(entity.proyecto.IdEstado != (int)EstadoEnum.Postergado, "El proyecto no puede estar en estado Postergado");
                    //Verifica datos presupuestarios
                    //siempre y cuando el SAF sea un Organismo presupuestario
                    if (SafBusiness.Current.GetResult(new SafFilter() { IdTipoOrganismo = (int)OrganismoTipoEnum.Presupuestario }).FirstOrDefault().IdSaf == entity.proyecto.IdSAF)
                    {
                        // y que la version del plan PNIP agregado no sea Demanda
                        if (
                            (from ppr in entity.proyectoPlan
                             where ppr.IdProyectoPlan < 0 && ppr.IdPlanTipo == GetParameterIDPlanTipoPNIP() &&
                                 (from ppv in PlanVersionBusiness.Current.GetResult(new PlanVersionFilter() { Orden = 0, Orden_To = 0 })
                                  select ppv.IdPlanVersion).Contains(ppr.IdPlanVersion)
                             select ppr.IdProyectoPlan).Count() == 0)
                            //y que el año de inicio del período seleccionado posea monto
                            if ((from peepb in ProyectoEtapaEstimadoPeriodoBusiness.Current.GetResult(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyecto = entity.proyecto.IdProyecto, IdFase = (int)FaseEnum.Ejecucion })
                                 where peepb.Periodo == Min
                                 select peepb).Sum(i => i.MontoCalculado) != 0)
                            {
                                //controla que si es un proyecto, posea número de proyecto
                                DataHelper.Validate(entity.proyecto.EsProyecto.HasValue && entity.proyecto.EsProyecto.Value && entity.proyecto.NroProyecto != 0, "Debe ingresar un Nro. de Proyecto (solapa Producto Intermedio");
                                //controla que la etapa posea número de etapa
                                DataHelper.Validate(
                                (from pe in ProyectoEtapaBusiness.Current.GetResult(new ProyectoEtapaFilter() { IdProyecto = entity.proyecto.IdProyecto })
                                 where !pe.NroEtapa.HasValue || pe.NroEtapa == 0 //&& (pe.IdEtapa == GetParameterIdEtapaObra() || pe.IdEtapa == GetParameterIdEtapaBienDeUso())
                                 select pe.NroEtapa
                                     ).Count() == 0, "Debe ingresar un Nro. de Obra y/o Actividad (solapa Producto Intermedio)");
                            }
                    }
                }
            }

            #endregion
            #region Por Proceso
            //if (GetParameterIdProcesoEquipamientoBasico() == entity.proyecto.IdProceso  )
            //{

            //}
            #endregion
            
        }
        //Funciones que obtienen si se debn controlar la carga de datos por estados
        private Int32 GetParameterIDPlanTipoPNIP()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_PLAN_TIPO_PNIP");
        }

        private bool GetParameterProyectoPorEstado()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_POR_ESTADO") == "S";
        }
        private bool GetParameterValidarProyectoTipoProyecto()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_TIPOPROYECTO") == "S";
        }
        private bool GetParameterValidarProyectoFinalidadFuncion()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_FINALIDADFUNCION") == "S";
        }
        private bool GetParameterValidarProyectoProceso()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_PROCESO") == "S";
        }
        private bool GetParameterValidarProyectoDescripcion()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_DESCRIPCION") == "S";
        }
        private bool GetParameterValidarProyectoSituacionActual()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_SITUACIONACTUAL") == "S";
        }
        private bool GetParameterValidarProyectoPlan()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_PLAN") == "S";
        }

        private bool GetParameterValidarProyectoLocalizacion()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_LOCALIZACION") == "S";
        }
        private bool GetParameterValidarProyectoFines()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_FINES") == "S";
        }
        private bool GetParameterValidarProyectoProducto()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_PRODUCTO") == "S";
        }
        private bool GetParameterValidarProyectoProposito()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_PROPOSITO") == "S";
        }
        private bool GetParameterValidarProyectoProductoIntermedio()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_PRODUCTOINTERMEDIO") == "S";
        }
        private bool GetParameterValidarProyectoCronogramaEstimado()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_CRONOGRAMAESTI") == "S";
        }
        private bool GetParameterValidarProyectoCronogramaRealizado()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_CRONOGRAMAREAL") == "S";
        }
        private bool GetParameterValidarProyectoIndicadorEconomico()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_INDICADORECO") == "S";
        }
        private bool GetParameterValidarProyectoJustificacion()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_JUSTIFICACION") == "S";
        }
        private bool GetParameterValidarProyectoSituacionSin()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_SITUACIONSIN") == "S";
        }

        private bool GetParameterProyectoPorProceso()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_POR_PROCESO") == "S";
        }
        private bool GetParameterProyectoPorPlan()
        {
            return SolutionContext.Current.ParameterManager.GetStringValue("VALIDAR_PROYECTO_POR_PLAN") == "S";
        }
        private Int32 GetParameterIdProcesoEquipamientoBasico()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_PROCESO_EQ_BASICO");
        }
        private Int32 GetParameterIdEtapaObra()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_ETAPA_OBRA");
        }
        private Int32 GetParameterIdEtapaBienDeUso()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_ETAPA_BIENDEUSO");
        }

        public void ValidateEstadoIdea(ProyectoResult result)
        {

            //control obligatorio
            DataHelper.Validate(result.IdSAF != null && result.IdSAF != 0, "FieldIsNull", "Saf");
            DataHelper.Validate(result.IdPrograma != null && result.IdPrograma != 0, "FieldIsNull", "Programa");
            DataHelper.Validate(result.IdSubPrograma != null && result.IdSubPrograma != 0, "FieldIsNull", "SubPrograma ");
            DataHelper.Validate(result.ProyectoDenominacion != null && result.ProyectoDenominacion.Trim() != String.Empty, "FieldIsNull", "Denominación ");
            DataHelper.Validate(result.IdSubPrograma != null && result.IdSubPrograma != 0, "FieldIsNull", "SubPrograma ");
            //solapa general - control optativo
            if (GetParameterValidarProyectoTipoProyecto())
                DataHelper.Validate(result.IdTipoProyecto != null && result.IdTipoProyecto != 0, "FieldIsNull", "Tipo de Proyecto");
            if (GetParameterValidarProyectoFinalidadFuncion())
                DataHelper.Validate(result.IdFinalidadFuncion != null && result.IdFinalidadFuncion != 0, "FieldIsNull", "Finalidad Función");
        }
        public void ValidateEstadoPerfil(ProyectoResult result)
        {
            //Debo validar los campos de los estados anteriores
            ValidateEstadoIdea(result);

            if (GetParameterValidarProyectoProceso())
                DataHelper.Validate(result.IdProceso != null && result.IdProceso != 0, "FieldIsNull", "Proceso");
            //solap localizacion
            if (GetParameterValidarProyectoLocalizacion())
                DataHelper.Validate(ProyectoLocalizacionBusiness.Current.GetList(new ProyectoLocalizacionFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Ingresar al menos una Localización Geográfica, dentro de la solapa Localización");

            //solapa Objetivos
            //Pregunta a DIEGO me da error
            //if (GetParameterValidarProyectoProposito())
            //    DataHelper.Validate(ProyectoObjetivosComposeBusiness.Current.GetList(new ProyectoFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Seleccionar al menos un Objetivo (solapa Objetivos)");
            if (GetParameterValidarProyectoFines())
                DataHelper.Validate(ProyectoFinBusiness.Current.GetList(new ProyectoFinFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Seleccionar al menos un Fin (solapa Objetivos)");
            if (GetParameterValidarProyectoProposito())
                DataHelper.Validate(ProyectoPropositoBusiness.Current.GetList(new ProyectoPropositoFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Seleccionar al menos un Propósito (solapa Objetivos)");
            if (GetParameterValidarProyectoProducto())
                DataHelper.Validate(ProyectoProductoBusiness.Current.GetList(new ProyectoProductoFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Seleccionar al menos un Producto (solapa Objetivos)");

            //solapa Producto Intermedio
            if (GetParameterValidarProyectoProductoIntermedio())
            {
                Int32 idEtapaObra = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_ETAPA_OBRA");
                Int32 idEtapaBienDeUso = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_ETAPA_BIENDEUSO");
                DataHelper.Validate(
                     ProyectoEtapaBusiness.Current.GetList(new ProyectoEtapaFilter() { IdProyecto = result.IdProyecto, IdEtapa = idEtapaObra }).Count != 0
                     ||
                     ProyectoEtapaBusiness.Current.GetList(new ProyectoEtapaFilter() { IdProyecto = result.IdProyecto, IdEtapa = idEtapaBienDeUso }).Count != 0
                     , "Debe Seleccionar al menos una Obra y/o Actividad (solapa Productos Intermedios)");
            }
            //Solpa Cronograma
            if (GetParameterValidarProyectoCronogramaEstimado())
            {
                List<ProyectoEtapaEstimadoPeriodoResult> peep = ProyectoEtapaEstimadoPeriodoBusiness.Current.GetResult(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyecto = result.IdProyecto, IdFase = (int)FaseEnum.Ejecucion });
                //tener en cuenta que el validar espera un false para ser efectivo el error, por ende debo preguntar por lo que espero que sea correcto
                DataHelper.Validate(peep != null && peep.Sum(i => i.MontoCalculado) != 0, "La sumatoria de los montos del cronograma de gastos estimados para la fase de ejecución debe ser mayor que cero");
            }
        }

        public void ValidateEstadoFactibilidad(ProyectoResult result)
        {
            //valido por un lado los estados anteriores
            ValidateEstadoPerfil(result);
            //Si requiere dictamen valido especificamente los campos de fatibilidad
            if (result.RequiereDictamen)
            {
                if (GetParameterValidarProyectoSituacionActual())
                    DataHelper.Validate(result.ProyectoSituacionActual != String.Empty, "Debe Ingresar la Situación Actual (solapa General)");
                if (GetParameterValidarProyectoDescripcion())
                    DataHelper.Validate(result.ProyectoDescripcion != String.Empty, "Debe Ingresar la Descripción (solapa General)");
                //busco info de la solpa de evolucion
                ProyectoEvaluacionResult per = ProyectoEvaluacionBusiness.Current.GetResult(new ProyectoEvaluacionFilter() { Id_Proyecto = result.IdProyecto }).SingleOrDefault();
                if (GetParameterValidarProyectoSituacionSin())
                {
                    DataHelper.Validate(per != null, "Debe Ingresar la Situación sin Proyecto (solapa Evaluación)");
                    DataHelper.Validate(per.SituacionSinProyecto != String.Empty, "Debe Ingresar la Situación sin Proyecto (solapa Evaluación)");
                }
                if (GetParameterValidarProyectoJustificacion())
                    DataHelper.Validate(per.OpcionJustificacion != String.Empty, "Debe Ingresar la Justificación (solapa Evaluación)");

                if (GetParameterValidarProyectoIndicadorEconomico())
                    DataHelper.Validate(ProyectoIndicadorEconomicoBusiness.Current.GetList(new ProyectoIndicadorEconomicoFilter() { IdProyecto = result.IdProyecto }).Count != 0, "Debe Ingresar al menos un Indicador Económico (solapa de Evaluación)");
            }
        }

        public void ValidateEstadoEjecucion(ProyectoGeneralCompose result)
        {
            ValidateEstadoFactibilidad(result.proyecto);
            if (GetParameterValidarProyectoPlan())
            {
                //DataHelper.Validate(
                //(from pp in result.proyectoPlan
                // where pp.IdPlanTipo = GetParameterIDPlanTipoPNIP()
                // (from ppp in PlanPeriodoBusiness.Current.GetList(new PlanPeriodoFilter() { IdPlanTipo = GetParameterIDPlanTipoPNIP() }) select ppp.IdPlanPeriodo).Contains(pp.IdPlanPeriodo)
                // &&
                //       (from pv in PlanVersionBusiness.Current.GetList(new PlanVersionFilter() { IdPlanTipo = GetParameterIDPlanTipoPNIP() }) where pv.Orden > 1 select pv.IdPlanVersion).Contains(pp.IdPlanVersion)
                // select pp.IdPlanPeriodo
                //  ).Count() != 0, "Debe Seleccionar un plan del Tipo PNIP con orden mayor a 1 (solapa General)");
                
                //Matias 20170106 - Validacion DEScomentada!
                //Matias 20141121 - Tarea 176 - Validacion comentada!
                DataHelper.Validate(
                (from pp in result.proyectoPlan
                 where pp.IdPlanTipo == GetParameterIDPlanTipoPNIP() && pp.PlanVersion_Orden>1
                 select pp.IdPlanPeriodo
                  ).Count() != 0, "Debe Seleccionar un plan del Tipo PNIP con orden mayor a 1 (solapa General)");                 
                //Matias 20141121 - Tarea 176
                //FinMatias 20170106 - Validacion DEScomentada!
            }
        }
        public void ValidateEstadoTerminado(ProyectoResult result)
        {
            //Solpa Cronograma
            if (GetParameterValidarProyectoCronogramaRealizado())
                DataHelper.Validate(ProyectoEtapaRealizadoPeriodoBusiness.Current.GetResult(new ProyectoEtapaRealizadoPeriodoFilter() { IdProyecto = result.IdProyecto, IdFase = (int)FaseEnum.Ejecucion }).Sum(i => i.MontoCalculado) != 0, "La sumatoria de los montos del cronograma de gastos realizados para la fase de ejecución debe ser mayor que cero (solapa Cronograma)");
        }

        public override bool Can(ProyectoGeneralCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoBusiness.Current.Can(ProyectoBusiness.Current.ToEntity(entity.proyecto), actionName, contextUser, args);

        }
        #endregion

        #region protected Methods
        protected List<ProyectoOficinaPerfilFuncionarioResult> ToproyectoOficinaPerfilFuncionarios(List<Persona> personas)
        {
            List<ProyectoOficinaPerfilFuncionarioResult> target = new List<ProyectoOficinaPerfilFuncionarioResult>();
            foreach (Persona persona in personas)
                target.Add(ToProyectoOficinaPerfilFuncionario(persona));
            return target;
        }
        protected ProyectoOficinaPerfilFuncionarioResult ToProyectoOficinaPerfilFuncionario(Persona persona)
        {
            ProyectoOficinaPerfilFuncionarioResult target = new ProyectoOficinaPerfilFuncionarioResult();
            target.Usuario_Nombre = persona.Nombre;
            target.Usuario_Apellido = persona.Apellido;
            target.IdUsuario = persona.IdPersona;
            target.Selected = false;
            target.Usuario_MailLaboral = persona.EMailLaboral;
            target.Usuario_TelefonoLaboral = persona.TelefonoLaboral;
            return target;
        }
        #endregion

        public override bool Equals(ProyectoGeneralCompose source, ProyectoGeneralCompose target)
        {

            bool eq = source.proyecto.IdProyecto.Equals(target.proyecto.IdProyecto);
            if (eq)
            {
                bool eqPr = ProyectoBusiness.Current.Equals(source.proyecto, target.proyecto);
                if (!eqPr) return false;

                if (target.proyectoDemora.Count() != source.proyectoDemora.Count()) return false;
                bool eqDemora = true;

                foreach (ProyectoDemoraResult pdr in source.proyectoDemora)
                {
                    ProyectoDemoraResult pdrTarget = target.proyectoDemora.Where(a => a.IdProyectoDemora == pdr.IdProyectoDemora).SingleOrDefault();
                    eqDemora = ProyectoDemoraBusiness.Current.Equals(pdr, pdrTarget);
                    if (!eqDemora) return false;
                }
                if (!eqDemora) return eqDemora;


                bool eqProyectoOficinaPerfilIniciador = ProyectoOficinaPerfilBusiness.Current.Equals(source.proyectoOficinaPerfilIniciador, target.proyectoOficinaPerfilIniciador);
                if (!eqProyectoOficinaPerfilIniciador) return false;

                bool eqProyectoOficinaPerfilEjecutor = ProyectoOficinaPerfilBusiness.Current.Equals(source.proyectoOficinaPerfilEjecutor, target.proyectoOficinaPerfilEjecutor);
                if (!eqProyectoOficinaPerfilEjecutor) return false;

                bool eqProyectoOficinaPerfilResponsable = ProyectoOficinaPerfilBusiness.Current.Equals(source.proyectoOficinaPerfilResponsable, target.proyectoOficinaPerfilResponsable);
                if (!eqProyectoOficinaPerfilResponsable) return false;

                if (target.proyectoOficinaPerfilFuncionarioEjecutor.Count() != source.proyectoOficinaPerfilFuncionarioEjecutor.Count()) return false;
                bool eqProyectoOficinaPerfilFuncionario = true;

                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in source.proyectoOficinaPerfilFuncionarioEjecutor)
                {
                    if (popfr.IdProyectoOficinaPerfilFuncionario != 0)
                    {
                        ProyectoOficinaPerfilFuncionarioResult popfTarget = target.proyectoOficinaPerfilFuncionarioEjecutor.Where(a => a.IdProyectoOficinaPerfilFuncionario == popfr.IdProyectoOficinaPerfilFuncionario).SingleOrDefault();
                        eqProyectoOficinaPerfilFuncionario = ProyectoOficinaPerfilFuncionarioBusiness.Current.Equals(popfr, popfTarget);
                        if (!eqProyectoOficinaPerfilFuncionario) return false;
                    }
                }
                if (!eqProyectoOficinaPerfilFuncionario) return eqProyectoOficinaPerfilFuncionario;

                if (target.proyectoOficinaPerfilFuncionarioIniciador.Count() != source.proyectoOficinaPerfilFuncionarioIniciador.Count()) return false;
                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in source.proyectoOficinaPerfilFuncionarioIniciador)
                {
                    if (popfr.IdProyectoOficinaPerfilFuncionario != 0)
                    {
                        ProyectoOficinaPerfilFuncionarioResult popfTarget = target.proyectoOficinaPerfilFuncionarioIniciador.Where(a => a.IdProyectoOficinaPerfilFuncionario == popfr.IdProyectoOficinaPerfilFuncionario).SingleOrDefault();
                        eqProyectoOficinaPerfilFuncionario = ProyectoOficinaPerfilFuncionarioBusiness.Current.Equals(popfr, popfTarget);
                        if (!eqProyectoOficinaPerfilFuncionario) return false;
                    }
                }

                if (!eqProyectoOficinaPerfilFuncionario) return eqProyectoOficinaPerfilFuncionario;

                if (target.proyectoOficinaPerfilFuncionarioResponsable.Count() != source.proyectoOficinaPerfilFuncionarioResponsable.Count()) return false;
                foreach (ProyectoOficinaPerfilFuncionarioResult popfr in source.proyectoOficinaPerfilFuncionarioResponsable)
                {
                    if (popfr.IdProyectoOficinaPerfilFuncionario != 0)
                    {
                        ProyectoOficinaPerfilFuncionarioResult popfTarget = target.proyectoOficinaPerfilFuncionarioResponsable.Where(a => a.IdProyectoOficinaPerfilFuncionario == popfr.IdProyectoOficinaPerfilFuncionario).SingleOrDefault();
                        eqProyectoOficinaPerfilFuncionario = ProyectoOficinaPerfilFuncionarioBusiness.Current.Equals(popfr, popfTarget);
                        if (!eqProyectoOficinaPerfilFuncionario) return false;
                    }
                }
                if (!eqProyectoOficinaPerfilFuncionario) return eqProyectoOficinaPerfilFuncionario;

                if (target.proyectoOrigenFinanciamiento.Count() != source.proyectoOrigenFinanciamiento.Count()) return false;
                bool eqProyectoOrigenFinanciamiento = true;
                foreach (ProyectoOrigenFinanciamientoResult pofr in source.proyectoOrigenFinanciamiento)
                {
                    ProyectoOrigenFinanciamientoResult pofTarget = target.proyectoOrigenFinanciamiento.Where(a => a.IdProyectoOrigenFinanciamiento == pofr.IdProyectoOrigenFinanciamiento).SingleOrDefault();
                    eqProyectoOrigenFinanciamiento = ProyectoOrigenFinanciamientoBusiness.Current.Equals(pofr, pofTarget);
                    if (!eqProyectoOrigenFinanciamiento) return false;
                }

                if (!eqProyectoOrigenFinanciamiento) return eqProyectoOrigenFinanciamiento;

                if (target.proyectoPlan.Count() != source.proyectoPlan.Count()) return false;
                bool eqProyectoPlan = true;
                foreach (ProyectoPlanResult ppr in source.proyectoPlan)
                {
                    ProyectoPlanResult ppTarget = target.proyectoPlan.Where(a => a.IdProyectoPlan == ppr.IdProyectoPlan).SingleOrDefault();
                    eqProyectoPlan = ProyectoPlanBusiness.Current.Equals(ppr, ppTarget);
                    if (!eqProyectoOrigenFinanciamiento) return false;
                }

                if (!eqProyectoPlan) return eqProyectoPlan;

                if (target.proyectoPrioridad.Count() != source.proyectoPrioridad.Count()) return false;
                bool eqProyectoPrioridad = true;
                foreach (ProyectoPrioridadResult ppr in source.proyectoPrioridad)
                {
                    ProyectoPrioridadResult ppTarget = target.proyectoPrioridad.Where(a => a.IdProyectoPrioridad == ppr.IdProyectoPrioridad).SingleOrDefault();
                    eqProyectoPrioridad = ProyectoPrioridadBusiness.Current.Equals(ppr, ppTarget);
                    if (!eqProyectoPrioridad) return false;
                }
                if (!eqProyectoPrioridad) return eqProyectoPrioridad;

                if (target.proyectoRelacion.Count() != source.proyectoRelacion.Count()) return false;
                bool eqProyectoRelacion = true;
                foreach (ProyectoRelacionResult ppr in source.proyectoRelacion)
                {
                    ProyectoRelacionResult ppTarget = target.proyectoRelacion.Where(a => a.IdProyectoRelacion == ppr.IdProyectoRelacion).SingleOrDefault();
                    eqProyectoRelacion = ProyectoRelacionBusiness.Current.Equals(ppr, ppTarget);
                    if (!eqProyectoRelacion) return false;
                }
                if (!eqProyectoRelacion) return eqProyectoRelacion;

            }
            return eq;
        }

    }


}
