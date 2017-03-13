using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class PrestamoBusiness : _PrestamoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoBusiness() {}
	   public static PrestamoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public virtual ListPaged<PrestamoResult> GetResultWithOfficePerfil(PrestamoFilter filter)
       {
           return Data.GetResultWithOfficePerfil(filter);
       }

       public virtual PrestamoResult GetResultById(int id)
       {
           return GetResult(new PrestamoFilter() { IdPrestamo = id }).FirstOrDefault();
       }

       public override void Add(Prestamo entity, IContextUser contextUser)
       {
           entity.FechaAlta = DateTime.Now;
           entity.FechaModificacion = DateTime.Now;
           int nroPrestamo = NumerationBusiness.Current.GetNext(NumerationConfig.PRESTAMO_NRO);
           entity.Numero = nroPrestamo;
           entity.IdUsuarioModificacion = contextUser.User.IdUsuario;
           base.Add(entity, contextUser);
       }
       public override void Update(Prestamo entity, IContextUser contextUser)
       {
           entity.FechaModificacion = DateTime.Now;
           entity.IdUsuarioModificacion = contextUser.User.IdUsuario;
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }
      
       public override void Delete(int id, IContextUser contextUser)
       {
           Prestamo prestamo = PrestamoBusiness.Current.GetById(id);
           prestamo.Activo = false;
           PrestamoBusiness.Current.Update(prestamo, contextUser);

       }
       public override bool Can(PrestamoResult result, string actionName, IContextUser contextUser, Hashtable args)
       {
           switch (actionName)
           {
               case ActionConfig.DELETE:
               case ActionConfig.UPDATE:
                   if (!result.Activo) return false;
                   break;
               default:
                   break;
           }
           return base.Can(result, actionName, contextUser, args);
       }


        #region Reportes
        public List<PrestamoObjetivoReportResult> GetPrestamoObjetivo(PrestamoFilter filter)
        {
           return PrestamoData.Current.GetPrestamoObjetivo(filter);
        }
        public List<PrestamoObjetivoReportResult> GetPrestamoObjetivosEspecificos(PrestamoFilter filter)
        {
            return PrestamoData.Current.GetPrestamoObjetivosEspecificos(filter);
        }
        public List<PrestamoComponentesReportResult> GetPrestamoComponentes(PrestamoFilter filter)
        {
            return PrestamoData.Current.GetPrestamoComponentes(filter);
        }


        private void Imprimir(ReportInfo reportInfo, PrestamoReportInfo filter)
        {
            Int32 IdPrestamo = filter.IdPrestamo ;

            List<PrestamoResult> prestamoResult = GetResult(new PrestamoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoFinalidadFuncionResult> prestamoFinalidadFuncionResult = PrestamoFinalidadFuncionBusiness.Current.GetResult(new PrestamoFinalidadFuncionFilter { IdPrestamo = IdPrestamo });
            List<PrestamoEstadoResult> prestamoEstadoResult = PrestamoEstadoBusiness.Current.GetResult ( new PrestamoEstadoFilter{IdPrestamo = IdPrestamo } );
            List<PrestamoOficinaPerfilResult> prestamoOficinaPerfil = PrestamoOficinaPerfilBusiness.Current.GetResult(new PrestamoOficinaPerfilFilter { IdPrestamo = IdPrestamo });
            List<PrestamoAlcanceGeograficoResult> prestamoAlcanceGeografico = PrestamoAlcanceGeograficoBusiness.Current.GetResult(new PrestamoAlcanceGeograficoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoObjetivoResult> prestamoObjetivo = PrestamoObjetivoBusiness.Current.GetResult(new PrestamoObjetivoFilter { IdPrestamo = IdPrestamo });

            List<ObjetivoSupuestoResult> objetivoSupuesto = new List<ObjetivoSupuestoResult>();
            if (prestamoObjetivo != null && prestamoObjetivo.Count() > 0)
            {
               objetivoSupuesto = ObjetivoSupuestoBusiness.Current.GetResult(new ObjetivoSupuestoFilter { IdsObjetivos = prestamoObjetivo.Select(i => i.IdObjetivo).ToList() });
            }
            List<PrestamoConvenioResult> prestamoConvenio = PrestamoConvenioBusiness.Current.GetResult(new PrestamoConvenioFilter { IdPrestamo = IdPrestamo });
            List<PrestamoSubConvenioResult> prestamoSubConvenio = new List<PrestamoSubConvenioResult>();
            if (prestamoConvenio != null && prestamoConvenio.Count() > 0)
            {
               prestamoSubConvenio = PrestamoSubConvenioBusiness.Current.GetResult(new PrestamoSubConvenioFilter { IdsPrestamoConvenio = prestamoConvenio.Select(i => i.IdPrestamoConvenio).ToList() });
            }
            List<PrestamoProductoResult> prestamoProducto = PrestamoProductoBusiness.Current.GetResult(new PrestamoProductoFilter { IdPrestamo = IdPrestamo }); 
            List<PrestamoDictamenResult> prestamoDictamen = PrestamoDictamenBusiness.Current.GetResult(new PrestamoDictamenFilter { IdPrestamo = IdPrestamo });
            List<PrestamoFileResult> prestamoFile = PrestamoFileBusiness.Current.GetResult (new PrestamoFileFilter { IdPrestamo = IdPrestamo });
            List<PrestamoObjetivoReportResult> prestamoObjetivoReport = GetPrestamoObjetivo(new PrestamoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoObjetivoReportResult> prestamoObjetivoEspecificosReport = GetPrestamoObjetivosEspecificos(new PrestamoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoComponentesReportResult> prestamoComponentesReport = GetPrestamoComponentes(new PrestamoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoDesembolsoResult> prestamoDesembolso = PrestamoDesembolsoBusiness.Current.GetResult(new PrestamoDesembolsoFilter { IdPrestamo = IdPrestamo });
            List<PrestamoOficinaFuncionarioResult> prestamoOficinaFuncionario = PrestamoOficinaFuncionarioBusiness.Current.GetResult(new PrestamoOficinaFuncionarioFilter { IdPrestamo = IdPrestamo });

            Programa programa = ProgramaBusiness.Current.GetById(prestamoResult.First().IdPrograma);
            Persona persona = PersonaBusiness.Current.GetList(new PersonaFilter() { IdPersona = programa.IdSectorialista }).FirstOrDefault();
            String sectorialista = String.Format("{0} {1} | {2} | {3}", persona.Nombre, persona.Apellido, persona.TelefonoLaboral, persona.EMailLaboral);
            

            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoResult", prestamoResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoFinalidadFuncionResult", prestamoFinalidadFuncionResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoEstadoResult", prestamoEstadoResult));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoOficinaPerfilResult", prestamoOficinaPerfil));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoAlcanceGeograficoResult", prestamoAlcanceGeografico));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoObjetivoResult", prestamoObjetivo));
            reportInfo.DataSources.Add(new ReportInfoDataSource("ObjetivoSupuestoResult", objetivoSupuesto));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoConvenioResult", prestamoConvenio));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoSubConvenioResult", prestamoSubConvenio));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoProductoResult", prestamoProducto));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoDictamenResult", prestamoDictamen));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoFileResult", prestamoFile));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoObjetivoReportResult", prestamoObjetivoReport));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoObjetivoEspecificosReportResult", prestamoObjetivoEspecificosReport));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoComponentesReportResult", prestamoComponentesReport));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoDesembolsoResult", prestamoDesembolso));
            reportInfo.DataSources.Add(new ReportInfoDataSource("PrestamoOficinaFuncionarioResult", prestamoOficinaFuncionario));

          
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "SolapaGeneral", Value = filter.SolapaGeneral.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "AlcanceGeografico", Value = filter.AlcanceGeografico.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Objetivos", Value = filter.Objetivos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IncluyeEvolucionDeIndicadoresObjetivos", Value = filter.IncluyeEvolucionDeIndicadoresObjetivos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Convenio", Value = filter.Convenio.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Componente", Value = filter.Componente.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Producto", Value = filter.Producto.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "IntervencionDNIP", Value = filter.IntervencionDNIP.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Adjuntos", Value = filter.Adjuntos.ToString() });
            reportInfo.Parameters.Add(new ReportInfoParameter() { Name = "Sectorialista", Value = sectorialista });
               
        }
        public  ReportInfo GetReport(SistemaReporte reporte, PrestamoReportInfo  prestamoReportInfo)
        {
            ReportInfo reportInfo = new ReportInfo();
            reportInfo.ReportFileName = reporte.FileName;
            reportInfo.Title = reporte.Nombre;

            switch (reporte.Codigo)
            {
            
                case "Prestamo":
                    Imprimir(reportInfo, prestamoReportInfo);
                    break;
            }
            return reportInfo;
        }

        public ReportInfo GetReport(int idReporte, PrestamoReportInfo prestamoReportInfo)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.GetById(idReporte);
            return GetReport(reporte, prestamoReportInfo);
        }






        #endregion
    }

    public class PrestamoGeneralComposeBusiness : EntityComposeBusiness<PrestamoGeneralCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoGeneralComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoGeneralComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoGeneralComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }

        #region Gets
        public override PrestamoGeneralCompose GetNew(PrestamoResult example)
        {
            PrestamoGeneralCompose compose = base.GetNew();
            compose.Prestamo = example;
            compose.Prestamo.Activo = true;
            compose.Estados = new List<PrestamoEstadoResult>();
            compose.Oficinas = new List<PrestamoOficinaPerfilResult>();
            compose.Clasificaciones = new List<PrestamoFinalidadFuncionResult>();

            Perfil perfilResponsable = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "RESP" });
            if (perfilResponsable != null)
            {
                compose.Responsable = new PrestamoOficinaPerfilResult() { IdPerfil = perfilResponsable.IdPerfil, IdOficina = example.IdOficina_Usuario };
            }

            compose.Funcionarios = ToPrestamoOficinaFuncionario(PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = example.IdOficina_Usuario }));

            PrestamoOficinaFuncionarioResult prestamoOficinaPerfilFuncionarioResponsable = compose.Funcionarios.Find(i => i.IdUsuario == example.IdUsuario);
            if (prestamoOficinaPerfilFuncionarioResponsable != null) prestamoOficinaPerfilFuncionarioResponsable.Selected = true;

            return compose;
        }
        public override PrestamoGeneralCompose GetNew()
        {
            PrestamoResult example = new PrestamoResult();
            PrestamoBusiness.Current.Set(PrestamoBusiness.Current.GetNew(), example);
            example.Activo = true;
            return GetNew(example);
        }
        public override int GetId(PrestamoGeneralCompose entity)
        {
            return entity.Prestamo.IdPrestamo;
        }
        public override PrestamoGeneralCompose GetById(int id)
        {
            PrestamoGeneralCompose compose = new PrestamoGeneralCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultWithOfficePerfil (new PrestamoFilter() { IdPrestamo = id }).FirstOrDefault();
            compose.Estados = PrestamoEstadoBusiness.Current.GetResult(new PrestamoEstadoFilter { IdPrestamo = id });
            compose.Oficinas = PrestamoOficinaPerfilBusiness.Current.GetResult(new PrestamoOficinaPerfilFilter { IdPrestamo = id });
            compose.Clasificaciones = PrestamoFinalidadFuncionBusiness.Current.GetResult(new PrestamoFinalidadFuncionFilter { IdPrestamo = id });

            List<PrestamoOficinaPerfilResult> prestamoOficinaPerfiles = PrestamoOficinaPerfilBusiness.Current.GetResult(new PrestamoOficinaPerfilFilter() { IdPrestamo = id });

            compose.Responsable = (from o in prestamoOficinaPerfiles where o.Perfil_Codigo == "RESP" select o).FirstOrDefault();
            if (compose.Responsable == null)
                compose.Responsable = new PrestamoOficinaPerfilResult();


            #region Querys
            //obtiene los permisos asociados y los que no estan asociados            
            List<PrestamoOficinaFuncionarioResult> perfilFuncionarios = PrestamoOficinaFuncionarioBusiness.Current.GetResult(new PrestamoOficinaFuncionarioFilter()
            {
                IdPrestamoOficinaPerfil = compose.Responsable.IdPrestamoOficinaPerfil
            });

            List<Persona> personas = PersonaBusiness.Current.GetList(new PersonaFilter()
            {
                IdOficina = compose.Responsable.IdOficina
            });
            #endregion

            #region Responsable
            List<PrestamoOficinaFuncionarioResult> unselected = new List<PrestamoOficinaFuncionarioResult>();
            unselected = (from a in personas
                          where !(from pa in perfilFuncionarios
                                  where pa.IdPrestamoOficinaPerfil == compose.Responsable.IdPrestamoOficinaPerfil
                                  select pa.IdUsuario).Contains(a.IdPersona)
                          && a.IdOficina == compose.Responsable.IdOficina
                          select ToPrestamoOficinaFuncionario(a)).ToList();
            compose.Funcionarios = new List<PrestamoOficinaFuncionarioResult>();
            compose.Funcionarios.AddRange((from o in perfilFuncionarios where o.PrestamoOficinaPerfil_IdOficina == compose.Responsable.IdOficina && o.PrestamoOficinaPerfil_IdPerfil == compose.Responsable.IdPerfil select o).ToArray());
            compose.Funcionarios.AddRange(unselected);

            #endregion		            



            //ActualizarFuncionarios(compose);
            
            return compose;
        }
        public void ActualizarFuncionarios(PrestamoGeneralCompose compose)
        {
            if (compose.Responsable != null && compose.Responsable.IdPrestamoOficinaPerfil > 0)
            {
                UsuarioResult usuario = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { IdUsuario = compose.Prestamo.IdUsuarioModificacion }).SingleOrDefault();
                List<PrestamoOficinaFuncionarioResult> popfResponsable = PrestamoOficinaFuncionarioBusiness.Current.GetResult(new PrestamoOficinaFuncionarioFilter() { IdPrestamoOficinaPerfil = compose.Responsable.IdPrestamoOficinaPerfil });
                List<Persona> personas = PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = compose.Responsable.IdOficina });

                List<PrestamoOficinaFuncionarioResult> popfResponsableDeOficina = (from r in popfResponsable
                                                                                   where (from p in personas select p.IdPersona).Contains(r.IdUsuario)
                                                                                   select r).ToList();

                List<PrestamoOficinaFuncionarioResult> unselected = (from a in personas
                                                                     where !(from pa in popfResponsable select pa.IdUsuario).Contains(a.IdPersona)
                                                                     select ToPrestamoOficinaFuncionario(a)).ToList();
                compose.Funcionarios = popfResponsableDeOficina;
                compose.Funcionarios.AddRange(unselected);
            }
        }
        #endregion

        #region Actions
        public override void Add(PrestamoGeneralCompose entity, IContextUser contextUser)
        {
            try
            {
                //Crea el Prestamo
                Prestamo Prestamo = entity.Prestamo.ToEntity();
                this.SetEstadoActual(entity);
                PrestamoBusiness.Current.Add(Prestamo, contextUser);
                entity.Prestamo.IdPrestamo = Prestamo.IdPrestamo;
                entity.Prestamo.Numero = Prestamo.Numero;

                #region Estados
                foreach (PrestamoEstadoResult per in entity.Estados)
                {
                    PrestamoEstado pe = per.ToEntity();
                    pe.IdPrestamo = entity.Prestamo.IdPrestamo;
                    pe.IdPrestamoEstado = 0;
                    PrestamoEstadoBusiness.Current.Add(pe, contextUser);
                    per.IdPrestamoEstado = pe.IdPrestamoEstado;
                }
                #endregion

                #region  Oficinas
                foreach (PrestamoOficinaPerfilResult por in entity.Oficinas)
                {
                    PrestamoOficinaPerfil po = por.ToEntity();
                    po.IdPrestamo = entity.Prestamo.IdPrestamo;
                    po.IdPrestamoOficinaPerfil = 0;
                    PrestamoOficinaPerfilBusiness.Current.Add(po, contextUser);
                    por.IdPrestamoOficinaPerfil = po.IdPrestamoOficinaPerfil;
                }
                #endregion

                #region  Clasificaciones
                foreach (PrestamoFinalidadFuncionResult pcr in entity.Clasificaciones)
                {
                    PrestamoFinalidadFuncion pc = pcr.ToEntity();
                    pc.IdPrestamo = entity.Prestamo.IdPrestamo;
                    pc.IdPrestamoFinalidadFuncion = 0;
                    PrestamoFinalidadFuncionBusiness.Current.Add(pc, contextUser);
                    pcr.IdPrestamoFinalidadFuncion = pc.IdPrestamoFinalidadFuncion;
                }
                #endregion
                
                entity.Responsable.IdPrestamo = entity.Prestamo.IdPrestamo;
                PrestamoOficinaPerfil responsable = entity.Responsable.ToEntity();
                PrestamoOficinaPerfilBusiness.Current.Add(responsable, contextUser);

                #region  Funcionario

                foreach (PrestamoOficinaFuncionarioResult popfr in entity.Funcionarios)
                {
                    if (popfr.Selected && popfr.IdPrestamoOficinaPerfilFuncionario < 1)
                    {
                        popfr.IdPrestamoOficinaPerfil = responsable.IdPrestamoOficinaPerfil;
                        PrestamoOficinaFuncionarioBusiness.Current.Add(popfr.ToEntity(), contextUser);
                    }
                }


                #endregion
            }
            catch (Exception exception)
            {
                entity.Prestamo.IdPrestamo = 0;
                throw exception;
            }
        }
        public override void Update(PrestamoGeneralCompose entity, IContextUser contextUser)
        {
            try
            {
                // Prestamo
                Prestamo Prestamo = PrestamoBusiness.Current.GetById(entity.Prestamo.IdPrestamo);
                this.SetEstadoActual(entity);
                PrestamoBusiness.Current.Set(entity.Prestamo, Prestamo);
                PrestamoBusiness.Current.Update(Prestamo, contextUser);

                #region Estados
                List<int> actualIdsEst = (from o in entity.Estados where o.IdPrestamoEstado > 0 select o.IdPrestamoEstado).ToList();
                List<PrestamoEstado> oldDetailEst = PrestamoEstadoBusiness.Current.GetList(new PrestamoEstadoFilter() { IdPrestamo = entity.Prestamo.IdPrestamo });
                List<PrestamoEstado> deletesEst = (from o in oldDetailEst where !actualIdsEst.Contains(o.IdPrestamoEstado) select o).ToList();
                PrestamoEstadoBusiness.Current.Delete(deletesEst, contextUser);

                foreach (PrestamoEstadoResult per in entity.Estados)
                {
                    PrestamoEstado pe = per.ToEntity();
                    pe.IdPrestamo = entity.Prestamo.IdPrestamo;
                    if (per.IdPrestamoEstado <= 0)
                    {
                        pe.IdPrestamoEstado = 0;
                        PrestamoEstadoBusiness.Current.Add(pe, contextUser);
                    }
                    else
                        PrestamoEstadoBusiness.Current.Update(pe, contextUser);
                  
                    per.IdPrestamoEstado = pe.IdPrestamoEstado;
                }
                #endregion 

                #region  Oficinas
                List<int> actualIdsOfis = (from o in entity.Oficinas where o.IdPrestamoOficinaPerfil > 0 select o.IdPrestamoOficinaPerfil).ToList();
                List<PrestamoOficinaPerfil> oldDetailOfis = PrestamoOficinaPerfilBusiness.Current.GetList(new PrestamoOficinaPerfilFilter() { IdPrestamo = entity.Prestamo.IdPrestamo });
                List<PrestamoOficinaPerfil> deletesOfis = (from o in oldDetailOfis where !actualIdsOfis.Contains(o.IdPrestamoOficinaPerfil) select o).ToList();
                PrestamoOficinaPerfilBusiness.Current.Delete(deletesOfis, contextUser);

                foreach (PrestamoOficinaPerfilResult por in entity.Oficinas)
                {
                    PrestamoOficinaPerfil po = por.ToEntity();
                    po.IdPrestamo = entity.Prestamo.IdPrestamo;
                    if (por.IdPrestamoOficinaPerfil <= 0)
                    {
                        po.IdPrestamoOficinaPerfil = 0;
                        PrestamoOficinaPerfilBusiness.Current.Add(po, contextUser);
                    }
                    else
                        PrestamoOficinaPerfilBusiness.Current.Update(po, contextUser);
                    por.IdPrestamoOficinaPerfil = po.IdPrestamoOficinaPerfil;
                }
                #endregion

                #region  Clasificaciones
                List<int> actualIdsClas = (from o in entity.Clasificaciones where o.IdPrestamoFinalidadFuncion > 0 select o.IdPrestamoFinalidadFuncion).ToList();
                List<PrestamoFinalidadFuncion> oldDetailClas = PrestamoFinalidadFuncionBusiness.Current.GetList(new PrestamoFinalidadFuncionFilter() { IdPrestamo = entity.Prestamo.IdPrestamo });
                List<PrestamoFinalidadFuncion> deletesClas = (from o in oldDetailClas where !actualIdsClas.Contains(o.IdPrestamoFinalidadFuncion) select o).ToList();
                PrestamoFinalidadFuncionBusiness.Current.Delete(deletesClas, contextUser);

                foreach (PrestamoFinalidadFuncionResult pcr in entity.Clasificaciones)
                {
                    PrestamoFinalidadFuncion pc = pcr.ToEntity();
                    pc.IdPrestamo = entity.Prestamo.IdPrestamo;
                    if (pcr.IdPrestamoFinalidadFuncion <= 0)
                    {
                        pc.IdPrestamoFinalidadFuncion = 0;
                        PrestamoFinalidadFuncionBusiness.Current.Add(pc, contextUser);
                    }
                    else
                        PrestamoFinalidadFuncionBusiness.Current.Update(pc, contextUser);
                    pcr.IdPrestamoFinalidadFuncion = pc.IdPrestamoFinalidadFuncion;
                }
                #endregion

                #region Responsable
                PrestamoOficinaPerfilResult proyectoPerfilResponsableResult = PrestamoOficinaPerfilBusiness.Current.GetResult(new PrestamoOficinaPerfilFilter() { IdPrestamo = entity.Prestamo.IdPrestamo, CodigoPerfil = "RESP" }).DefaultIfEmpty().SingleOrDefault();
                if (entity.Responsable != null && entity.Responsable.IdOficina > 0)
                {
                    if (proyectoPerfilResponsableResult != null)
                    {
                        PrestamoOficinaPerfil proyectoPerfilResponsable = proyectoPerfilResponsableResult.ToEntity();
                        if (!entity.Responsable.Equals(proyectoPerfilResponsable))
                        {
                            PrestamoOficinaFuncionarioBusiness.Current.Delete(new PrestamoOficinaFuncionarioFilter() { IdPrestamoOficinaPerfil = proyectoPerfilResponsable.IdPrestamoOficinaPerfil }, contextUser);
                            PrestamoOficinaPerfilBusiness.Current.Delete(proyectoPerfilResponsable.IdPrestamoOficinaPerfil, contextUser);
                            if (entity.Responsable.IdOficina != 0)
                            {
                                PrestamoOficinaPerfil pop = entity.Responsable.ToEntity();
                                entity.Responsable.IdPrestamo = entity.Prestamo.IdPrestamo;
                                PrestamoOficinaPerfilBusiness.Current.Add(pop, contextUser);
                                entity.Responsable.IdPrestamoOficinaPerfil = pop.IdPrestamoOficinaPerfil;
                            }
                        }
                    }
                    else
                    {
                        Perfil perfilResponsable = PerfilBusiness.Current.FirstOrDefault(new PerfilFilter() { Codigo = "RESP" });

                        entity.Responsable.IdPrestamo = entity.Prestamo.IdPrestamo;
                        entity.Responsable.IdPerfil = perfilResponsable.IdPerfil;
                        PrestamoOficinaPerfil responsable = entity.Responsable.ToEntity();
                        PrestamoOficinaPerfilBusiness.Current.Add(responsable, contextUser);
                        entity.Responsable.IdPrestamoOficinaPerfil = responsable.IdPrestamoOficinaPerfil;
                    }

                    foreach (PrestamoOficinaFuncionarioResult popfr in entity.Funcionarios)
                    {
                        if (popfr.Selected && popfr.IdPrestamoOficinaPerfilFuncionario < 1)
                        {
                            popfr.IdPrestamoOficinaPerfil = entity.Responsable.IdPrestamoOficinaPerfil;
                            PrestamoOficinaFuncionario popf = popfr.ToEntity();
                            PrestamoOficinaFuncionarioBusiness.Current.Add(popf, contextUser);
                            popfr.IdPrestamoOficinaPerfilFuncionario = popf.IdPrestamoOficinaPerfilFuncionario;
                        }
                        if (!popfr.Selected && popfr.IdPrestamoOficinaPerfilFuncionario > 1)
                        {
                            PrestamoOficinaFuncionario popf = PrestamoOficinaFuncionarioBusiness.Current.GetById(popfr.IdPrestamoOficinaPerfilFuncionario);
                            if (popf != null)
                                PrestamoOficinaFuncionarioBusiness.Current.Delete(popf, contextUser);
                        }
                    }
                }
                else
                {
                    if (proyectoPerfilResponsableResult != null && proyectoPerfilResponsableResult.IdPrestamoOficinaPerfil > 0)
                    {
                        PrestamoOficinaFuncionarioBusiness.Current.Delete(new PrestamoOficinaFuncionarioFilter() { IdPrestamoOficinaPerfil = proyectoPerfilResponsableResult.IdPrestamoOficinaPerfil }, contextUser);
                        PrestamoOficinaPerfilBusiness.Current.Delete(proyectoPerfilResponsableResult.IdPrestamoOficinaPerfil, contextUser);
                    }
                }
                #endregion             


            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Delete(PrestamoGeneralCompose entity, IContextUser contextUser) 
        {
            PrestamoBusiness.Current.Delete(entity.Prestamo.IdPrestamo, contextUser); 
        }
        public void SetEstadoActual(PrestamoGeneralCompose entity)
        {
            if (entity.Estados.Count > 0)
            {
                entity.Prestamo.IdEstadoActual = (from e in entity.Estados
                                                  where e.FechaEstimada == (from e1 in entity.Estados select e1.FechaEstimada).Max()
                                                  select e).Take(1).Single().IdEstado;
            }
            else
                entity.Prestamo.IdEstadoActual = null;
        }
        #endregion

        #region Validations
        public override void Validate(PrestamoGeneralCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            PrestamoBusiness.Current.Validate(PrestamoBusiness.Current.ToEntity(entity.Prestamo), actionName, contextUser, args);
            DataHelper.Validate(entity.Estados.Count() > 0, "El prestamo debe tener un estado inicial.");
            //Matias 20131111 - Tarea 13
            //DataHelper.Validate(entity.Oficinas.Where(c => c.IdOficina == entity.Responsable.IdOficina).Count() == 0, "La oficina responsable no puede esta en la lista de oficinas asociadas."); // Sentencia original.
            DataHelper.Validate(entity.OficinasSinResponsable.Where(c => c.IdOficina == entity.Responsable.IdOficina).Count() == 0, "La oficina responsable no puede estar en la lista de oficinas asociadas.");
            //FinMatias 20131111 - Tarea 13

        }

        public override bool Can(PrestamoGeneralCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoBusiness.Current.Can(PrestamoBusiness.Current.ToEntity(entity.Prestamo), actionName, contextUser, args);
        }
        public override bool Equals(PrestamoGeneralCompose source, PrestamoGeneralCompose target)
        {
            bool eq = source.Prestamo.Equals(target.Prestamo);                            

            if (eq)
            {
                #region Estados

                if (source.Estados.Count() != target.Estados.Count()) return false;
                bool eqEs = true;

                foreach(PrestamoEstadoResult estado in source.Estados)
                {
                    PrestamoEstadoResult e = estado;
                    if (target.Estados.Where(p => p.IdPrestamoEstado == e.IdPrestamoEstado).Count() == 1)
                    {
                        PrestamoEstadoResult b = target.Estados.Where(p => p.IdPrestamoEstado == e.IdPrestamoEstado).SingleOrDefault();
                        eqEs = e.IdPrestamo == b.IdPrestamo &&
                                       e.IdEstado == b.IdEstado &&
                                       e.FechaEstimada == b.FechaEstimada &&
                                       e.FechaRealizada == b.FechaRealizada;
                    }
                    else
                        eqEs = false;
                }
                #endregion

                #region Oficina funcionario

                if (source.Funcionarios.Count() != target.Funcionarios.Count()) return false;
                bool eqFun = true;
                foreach (PrestamoOficinaFuncionarioResult funci in source.Funcionarios)
                {
                    PrestamoOficinaFuncionarioResult e = funci;
                    if (target.Funcionarios.Where(p => p.IdPrestamoOficinaPerfilFuncionario == e.IdPrestamoOficinaPerfilFuncionario &&
                                                       p.IdUsuario == e.IdUsuario).Count() == 1)
                    {
                        PrestamoOficinaFuncionarioResult b = target.Funcionarios.Where(p => p.IdPrestamoOficinaPerfilFuncionario == e.IdPrestamoOficinaPerfilFuncionario &&
                                                         p.IdUsuario == e.IdUsuario).SingleOrDefault();
                        eqFun =  e.IdPrestamoOficinaPerfil == b.IdPrestamoOficinaPerfil &&
                                         e.IdUsuario == b.IdUsuario &&
                                         e.Selected == b.Selected;
                    }
                    else
                        eqFun = false;
                }
                #endregion

                #region Perfil

                if (source.Oficinas.Count() != target.Oficinas.Count()) return false;
                bool eqPer = true;
                foreach (PrestamoOficinaPerfilResult per in source.Oficinas)
                {
                    PrestamoOficinaPerfilResult e = per;
                    if (target.Oficinas.Where(p => p.IdPrestamoOficinaPerfil == e.IdPrestamoOficinaPerfil).Count() == 1)
                    {
                        PrestamoOficinaPerfilResult b = target.Oficinas.Where(p => p.IdPrestamoOficinaPerfil == e.IdPrestamoOficinaPerfil).SingleOrDefault();
                        eqPer = PrestamoOficinaPerfilBusiness.Current.Equals(b, e);
                        
                        //eqPer = e.IdPrestamo == b.IdPrestamo &&
                        //                 e.IdOficina == b.IdOficina &&
                        //                 e.IdPerfil == b.IdPerfil;
                    }
                    else
                        eqPer = false;
                }
                #endregion

                #region Clasificaciones

                if (source.Clasificaciones.Count() != target.Clasificaciones.Count()) return false;
                bool eqCla =true;
                foreach (PrestamoFinalidadFuncionResult fin in source.Clasificaciones)
                {
                    PrestamoFinalidadFuncionResult e = fin;
                    if (target.Clasificaciones.Where(p => p.IdPrestamoFinalidadFuncion == e.IdPrestamoFinalidadFuncion).Count() == 1)
                    {
                        PrestamoFinalidadFuncionResult b = target.Clasificaciones.Where(p => p.IdPrestamoFinalidadFuncion == e.IdPrestamoFinalidadFuncion).SingleOrDefault();
                        eqCla = e.IdPrestamo == b.IdPrestamo &&
                                         e.IdFinalidadFuncion == b.IdFinalidadFuncion;
                    }
                    else
                        eqCla = false;
                }
                #endregion

                eq = eqEs && eqFun && eqPer && eqCla;
            }
        
            return eq;
        }

        #endregion

        #region protected Methods
        protected List<PrestamoOficinaFuncionarioResult> ToPrestamoOficinaFuncionario(List<Persona> personas)
        {
            List<PrestamoOficinaFuncionarioResult> target = new List<PrestamoOficinaFuncionarioResult>();
            foreach (Persona persona in personas)
                target.Add(ToPrestamoOficinaFuncionario(persona));
            return target;
        }
        protected PrestamoOficinaFuncionarioResult ToPrestamoOficinaFuncionario(Persona persona)
        {
            PrestamoOficinaFuncionarioResult target = new PrestamoOficinaFuncionarioResult();
            target.Usuario_Nombre = persona.Nombre;
            target.Usuario_Apellido = persona.Apellido;
            target.IdUsuario = persona.IdPersona;
            target.Selected = false;
            target.Usuario_MailLaboral = persona.EMailLaboral;
            target.Usuario_TelefonoLaboral = persona.TelefonoLaboral;
            return target;
        }
        #endregion


        public List<PrestamoOficinaFuncionarioResult> GetPrestamoOficinaPerfilFuncionarioResult(Int32 IdOficina)
        {
            List<Persona> personas = PersonaBusiness.Current.GetList(new PersonaFilter() { IdOficina = IdOficina });
            List<PrestamoOficinaFuncionarioResult> unselected = (from a in personas select ToPrestamoOficinaFuncionario(a)).ToList();
            List<PrestamoOficinaFuncionarioResult> popfr = new List<PrestamoOficinaFuncionarioResult>();
            popfr.AddRange(unselected);
            return popfr;
        }
    }
}
