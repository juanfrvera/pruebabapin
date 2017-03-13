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
    public class ProyectoCalidadComposeBusiness : EntityComposeBusiness<ProyectoCalidadCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoCalidadComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoCalidadComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCalidadComposeBusiness();
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

        protected override IEntityData<ProyectoCalidadCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }

        protected const string ID_PROYECTOCALIDAD_ESTADO_CONTROLADO = "ID_PROYECTOCALIDAD_ESTADO_CONTROLADO";
        protected const string ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR = "ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR";

        #region Gets
        public override ProyectoCalidadCompose GetNew(ProyectoResult example)
        {
            ProyectoCalidadCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.CalidadActual = new ProyectoCalidadResult();
            compose.CalidadSugerida = new ProyectoCalidadResult();
            return compose;
        }
        public override ProyectoCalidadCompose GetNew()
        {
            ProyectoCalidadCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.CalidadActual = new ProyectoCalidadResult();
            compose.CalidadSugerida = new ProyectoCalidadResult();
            return compose;
        }
        public override int GetId(ProyectoCalidadCompose entity)
        {
            return entity.IdProyecto;
        }
        public override ProyectoCalidadCompose GetById(int id)
        {
            // Informacion para editar
            ProyectoCalidadCompose compose = new ProyectoCalidadCompose();
            compose.Proyecto = ProyectoBusiness.Current.GetResultWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            compose.CalidadActual = ProyectoCalidadBusiness.Current.GetCalidadActual(id);
            compose.localizacionesActual = ProyectoLocalizacionBusiness.Current.GetResult(new ProyectoLocalizacionFilter() { IdProyecto = id });
            compose.CalidadSugerida = ProyectoCalidadBusiness.Current.GetCalidadSugerida(id);
            if (compose.CalidadSugerida != null && compose.CalidadSugerida.IdProyectoCalidad > 0)
            {
                compose.localizacionesSugerida = ProyectoCalidadLocalizacionBusiness.Current.GetResult(new ProyectoCalidadLocalizacionFilter() { IdProyectoCalidad = compose.CalidadSugerida.IdProyectoCalidad });
                compose.Estado = EstadoBusiness.Current.GetResult(new EstadoFilter() { IdEstado = compose.CalidadSugerida.IdEstado }).SingleOrDefault();
                compose.HabilitadoParaCambios = compose.Estado.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR);
            }
            else
            {
                compose.CalidadSugerida = new ProyectoCalidadResult();
                compose.Estado = new EstadoResult();
                compose.HabilitadoParaCambios = false;
            }
            compose.ProyectoPrioridad = ProyectoPrioridadBusiness.Current.GetUltimaPrioridad(id);

            return compose;
        }
        public DetalleCalidadCompose GetDetalleCalidad(int idProyecto)
        {
            DetalleCalidadCompose compose = new DetalleCalidadCompose();
            compose.IdProyecto = idProyecto;
            Int32 idFase = (Int32)FaseEnum.Ejecucion;
            compose.Etapas = ProyectoEtapaBusiness.Current.GetEtapas(new ProyectoEtapaFilter() { IdProyecto = idProyecto, IdFase = idFase });
            compose.EtapasEstimadas = ProyectoEtapaEstimadoBusiness.Current.GetEtapasEstimadas(new ProyectoEtapaFilter() { IdProyecto = idProyecto, IdFase = idFase });
            compose.EtapasRealizadas = ProyectoEtapaRealizadoBusiness.Current.GetEtapasRealizadas(new ProyectoEtapaFilter() { IdProyecto = idProyecto, IdFase = idFase });
            compose.Prioridades = ProyectoIndicadorPriorizacionBusiness.Current.GetResult(new ProyectoIndicadorPriorizacionFilter() { IdProyecto = idProyecto }).ToList();

            // Carga de datos adicionales
            ProyectoCalidadData.Current.CargarDatosExtra(ref compose);

            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoCalidadCompose entity, IContextUser contextUser)
        {
            try
            {
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override void Update(ProyectoCalidadCompose entity, IContextUser contextUser)
        {
            try
            {
                if (entity.AdministrandoCalidad)
                {
                    #region ACTUALIZACION PARA ADMINISTRADORES DE CALIDAD

                    
                    entity.CalidadSugerida.IdProyecto = entity.IdProyecto;
                    ProyectoCalidad pc = entity.CalidadSugerida.ToEntity();

                    if (pc.LocalizacionOK)
                        if (entity.localizacionesSugerida.Count == 0)
                            throw new Exception("No se puede tildar OK si no hay ningun provincia seleccionada");

                    if (pc.IdProyectoCalidad <= 0)
                    {
                        pc.IdProyectoCalidad = 0;
                        ProyectoCalidadBusiness.Current.Add(pc, contextUser);
                        entity.CalidadSugerida.IdProyectoCalidad = pc.IdProyectoCalidad;
                    }
                    else
                        ProyectoCalidadBusiness.Current.Update(pc, contextUser);

                    // Elimina las localicaciones que ya no estan
                    List<int> actualIds = (from o in entity.localizacionesSugerida where o.IdProyectoCalidadLocalizacion > 0 select o.IdProyectoCalidadLocalizacion).ToList();
                    List<ProyectoCalidadLocalizacion> oldDetail = ProyectoCalidadLocalizacionBusiness.Current.GetList(new ProyectoCalidadLocalizacionFilter() { IdProyectoCalidad = entity.CalidadSugerida.IdProyectoCalidad });
                    List<ProyectoCalidadLocalizacion> deletes = (from o in oldDetail where !actualIds.Contains(o.IdProyectoCalidadLocalizacion) select o).ToList();
                    ProyectoCalidadLocalizacionBusiness.Current.Delete(deletes, contextUser);

                    foreach (ProyectoCalidadLocalizacionResult pclr in entity.localizacionesSugerida)
                    {
                        pclr.IdProyectoCalidad = entity.CalidadSugerida.IdProyectoCalidad;
                        ProyectoCalidadLocalizacion pcl = pclr.ToEntity();
                        if (pcl.IdProyectoCalidadLocalizacion <= 0)
                        {
                            pcl.IdProyectoCalidadLocalizacion = 0;
                            ProyectoCalidadLocalizacionBusiness.Current.Add(pcl, contextUser);
                            pclr.IdProyectoCalidadLocalizacion = pcl.IdProyectoCalidadLocalizacion;
                        }
                        else
                        {
                            ProyectoCalidadLocalizacionBusiness.Current.Update(pcl, contextUser);
                        }
                    }

                    #endregion
                }
                else if (entity.AdministrandoPriorizacion)
                {
                    #region ACTUALIZACION PARA ADMINISTRADORES DE PRIORIZACION

                    ProyectoPrioridad pp = entity.ProyectoPrioridad.ToEntity();

                    if (pp.IdProyectoPrioridad == 0)
                        ProyectoPrioridadBusiness.Current.Add(pp, contextUser);
                    else
                        ProyectoPrioridadBusiness.Current.Update(pp, contextUser);

                    entity.ProyectoPrioridad.IdProyectoPrioridad = pp.IdProyectoPrioridad;

                    #endregion
                }
                else if (entity.HabilitadoParaCambios && entity.SugerenciaAceptada)
                {
                    #region ACTUALIZACION PARA USUARIOS DE CALIDAD

                    if (entity.AceptadoDenominacion || entity.AceptadoEstado || entity.AceptadoFinalidad ||
                        entity.AceptadoProceso || entity.AceptadoTipoProyecto)
                    {
                        // Actualiza el proyecto
                        #region Proyecto
                        Proyecto p = ProyectoBusiness.Current.GetById(entity.IdProyecto);

                        if (entity.AceptadoDenominacion)
                            p.ProyectoDenominacion = entity.CalidadSugerida.DenominacionSugerida;

                        if (entity.AceptadoTipoProyecto && entity.CalidadSugerida.IdProyectoTipo != null)
                            p.IdTipoProyecto = (int)entity.CalidadSugerida.IdProyectoTipo;

                        if (entity.AceptadoEstado && entity.CalidadSugerida.IdEstadoSugerido != null)
                            p.IdEstado = (int)entity.CalidadSugerida.IdEstadoSugerido;

                        if (entity.AceptadoProceso)
                            p.IdProceso = entity.CalidadSugerida.IdProceso;

                        if (entity.AceptadoFinalidad)
                            p.IdFinalidadFuncion = entity.CalidadSugerida.IdClasificacionFuncional;

                        ProyectoBusiness.Current.Update(p, contextUser);
                        #endregion Proyecto
                    }

                    // Actualizar Localizacion
                    if (entity.AceptadoLocalizacion)
                    {
                        #region Agrega los que no estan
                        foreach (ProyectoCalidadLocalizacionResult pclr in entity.localizacionesSugerida)
                        {
                            if ((from i in entity.localizacionesActual where i.IdClasificacionGeografica == pclr.IdClasificacionGeografica select i).Count() == 0)
                            {
                                ProyectoLocalizacion plNew = new ProyectoLocalizacion();
                                plNew.IdProyecto = entity.IdProyecto;
                                plNew.IdClasificacionGeografica = pclr.IdClasificacionGeografica;
                                ProyectoLocalizacionBusiness.Current.Add(plNew, contextUser);
                            }
                        }
                        #endregion
                        #region Elimina recursivamente
                        foreach (ProyectoLocalizacionResult plr in entity.localizacionesActual.Where(l => l.ClasificacionGeografica_Nivel == 0))
                        {
                            if ((from i in entity.localizacionesSugerida where i.IdClasificacionGeografica == plr.IdClasificacionGeografica select i).Count() == 0)
                            {
                                ProyectoLocalizacionBusiness.Current.DeleteBranch(entity.IdProyecto, plr.IdClasificacionGeografica);
                            }
                        }
                        #endregion
                    }

                    // Actualizacion estado Proyecto Calidad
                    ProyectoCalidad pc = ProyectoCalidadBusiness.Current.GetById(entity.CalidadSugerida.IdProyectoCalidad);
                    pc.IdEstado = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_CONTROLADO);
                    pc.FechaEstado = DateTime.Now;
                    ProyectoCalidadBusiness.Current.Update(pc, contextUser);

                    #endregion
                }
                //Matias 20131106 - Tarea 80
                ProyectoBusiness.Current.updateFechaUltimaModificacion(entity.IdProyecto, contextUser);
                //FinMatias 20131106 - Tarea 80

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Delete(ProyectoCalidadCompose entity, IContextUser contextUser)
        {
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(ProyectoCalidadCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            //DataHelper.Validate(entity.CalidadSugerida.IdProceso != 0, "InvalidField", "Proceso Sugerido");
            //DataHelper.Validate(entity.CalidadSugerida.IdProyectoTipo != 0, "InvalidField", "Tipo Proyecto Sugerido");

            if (entity.CalidadSugerida.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_CONTROLADO))//(Int32)EstadoEnum.A_Corregir)
            {
                DataHelper.Validate(entity.CalidadSugerida.DenominacionSugerida != null &&
                                    entity.CalidadSugerida.DenominacionSugerida != "", "InvalidField", "Denominación Sugerida");

                DataHelper.Validate(entity.CalidadSugerida.IdEstadoSugerido != 0, "InvalidField", "Estado Sugerido");

                DataHelper.Validate(entity.CalidadActual.IdClasificacionFuncional == null ||
                                   (entity.CalidadSugerida.IdClasificacionFuncional != null &&
                                    entity.CalidadSugerida.IdClasificacionFuncional != 0), "InvalidField", "Finalidad Función Sugerida");
            }
            if (entity.CalidadSugerida.IdEstado == (int)EstadoEnum.A_Corregir)
            {
                DataHelper.Validate(entity.CalidadSugerida.DenominacionSugerida != null && entity.CalidadSugerida.DenominacionSugerida != "", "InvalidField", "Denominación Sugerida");
                DataHelper.Validate(entity.CalidadSugerida.IdProyectoTipo > 0 || entity.CalidadSugerida.ProyectoTipoOk, "InvalidField", "Tipo Proyecto");
                DataHelper.Validate(entity.CalidadSugerida.IdEstado > 0 || entity.CalidadSugerida.EstadoSugeridoOK, "InvalidField", "Estado");
                DataHelper.Validate(entity.CalidadSugerida.IdProceso > 0 || entity.CalidadSugerida.ProcesoOk, "InvalidField", "Proceso");
                DataHelper.Validate(entity.CalidadSugerida.IdClasificacionFuncional > 0 || entity.CalidadSugerida.FinalidadFuncionOk, "InvalidField", "Finalidad Función");
                DataHelper.Validate((entity.localizacionesSugerida != null && entity.localizacionesSugerida.Count > 0) || entity.CalidadSugerida.LocalizacionOK, "InvalidField", "Provincias");
            }
            if (actionName == "UPDATE" || actionName == "CREATE")
            {
                DataHelper.Validate(entity.ProyectoPrioridad.IdClasificacion != 0, "Falta seleccionar una clasificación");
            }
        }

        public override bool Can(ProyectoCalidadCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            bool retval = true;
            return retval;
        }

        public override bool Equals(ProyectoCalidadCompose source, ProyectoCalidadCompose target)
        {
            //Matias 20141027 - Tarea 179
            ProyectoCalidad pc = ProyectoCalidadBusiness.Current.GetById(source.CalidadSugerida.IdProyectoCalidad /*entity.CalidadSugerida.IdProyectoCalidad*/ );
            if (pc != null)
                if (pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_CONTROLADO)) return true;
            //FinMatias 20141027 - Tarea 179 

            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            //if(!source.AdministrandoCalidad.Equals(target.AdministrandoCalidad))return false;
            if (!source.AdministrandoPriorizacion.Equals(target.AdministrandoPriorizacion)) return false;
            if (!source.HabilitadoParaCambios.Equals(target.HabilitadoParaCambios)) return false;
            if (!source.AceptadoDenominacion.Equals(target.AceptadoDenominacion)) return false;
            if (!source.AceptadoTipoProyecto.Equals(target.AceptadoTipoProyecto)) return false;
            if (!source.AceptadoEstado.Equals(target.AceptadoEstado)) return false;
            if (!source.AceptadoProceso.Equals(target.AceptadoProceso)) return false;
            if (!source.AceptadoFinalidad.Equals(target.AceptadoFinalidad)) return false;
            if (!source.AceptadoLocalizacion.Equals(target.AceptadoLocalizacion)) return false;
            if (!ProyectoCalidadData.Current.Equals(source.CalidadActual, target.CalidadActual)) return false;
            if (!ProyectoCalidadData.Current.Equals(source.CalidadSugerida, target.CalidadSugerida)) return false;

            return true;
        }
        #endregion
    }
}

