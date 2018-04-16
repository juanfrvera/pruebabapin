using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract;

namespace DataAccess
{
    public class ProyectoData : EntityData<Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoData current;
        private static object syncRoot = new Object();

        //private ProyectoData() {}
        public static ProyectoData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdProyecto"; } }
        #region ClaseBase
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.Proyecto entity)
        {
            return entity.IdProyecto;
        }
        public override Proyecto GetByEntity(Proyecto entity)
        {
            return this.GetById(entity.IdProyecto);
        }
        public override Proyecto GetById(int id)
        {
            return (from o in this.Table where o.IdProyecto == id select o).FirstOrDefault();
        }
        #endregion
        #region Copy
        public override nc.Proyecto Copy(nc.Proyecto entity)
        {
            nc.Proyecto _new = new nc.Proyecto();
            _new.IdTipoProyecto = entity.IdTipoProyecto;
            _new.IdSubPrograma = entity.IdSubPrograma;
            _new.Codigo = entity.Codigo;
            _new.ProyectoDenominacion = entity.ProyectoDenominacion;
            _new.ProyectoSituacionActual = entity.ProyectoSituacionActual;
            _new.ProyectoDescripcion = entity.ProyectoDescripcion;
            _new.ProyectoObservacion = entity.ProyectoObservacion;
            _new.IdEstado = entity.IdEstado;
            _new.IdProceso = entity.IdProceso;
            _new.IdModalidadContratacion = entity.IdModalidadContratacion;
            _new.IdFinalidadFuncion = entity.IdFinalidadFuncion;
            _new.IdOrganismoPrioridad = entity.IdOrganismoPrioridad;
            _new.SubPrioridad = entity.SubPrioridad;
            _new.EsBorrador = entity.EsBorrador;
            _new.EsProyecto = entity.EsProyecto;
            _new.NroProyecto = entity.NroProyecto;
            _new.AnioCorriente = entity.AnioCorriente;
            _new.AnioCorrienteEstimado = entity.AnioCorrienteEstimado;
            _new.AnioCorrienteRealizado = entity.AnioCorrienteRealizado;
            _new.FechaInicioEjecucionCalculada = entity.FechaInicioEjecucionCalculada;
            _new.FechaFinEjecucionCalculada = entity.FechaFinEjecucionCalculada;
            _new.FechaAlta = entity.FechaAlta;
            _new.FechaModificacion = entity.FechaModificacion;
            _new.IdUsuarioModificacion = entity.IdUsuarioModificacion;
            _new.IdProyectoPlan = entity.IdProyectoPlan;
            _new.EvaluarValidaciones = entity.EvaluarValidaciones;
            _new.Activo = entity.Activo;
            _new.IdEstadoDeDesicion = entity.IdEstadoDeDesicion;
            _new.EsPPP = entity.EsPPP;
            _new.NroActividad = entity.NroActividad;
            _new.NroObra = entity.NroObra;
            _new.NroProyectoEjecucion = entity.NroProyectoEjecucion;
            _new.NroActividadEjecucion = entity.NroActividadEjecucion;
            _new.NroObraEjecucion = entity.NroObraEjecucion;
            return _new;
        }
        public override int CopyAndSave(Proyecto entity, string renameFormat)
        {
            Proyecto newEntity = Copy(entity);
            newEntity.ProyectoDenominacion = string.Format(renameFormat, newEntity.ProyectoDenominacion);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(Proyecto entity, int id)
        {
            entity.IdProyecto = id;
        }
        public override void Set(Proyecto source, Proyecto target, bool hadSetId)
        {
            if (hadSetId) target.IdProyecto = source.IdProyecto;
            target.IdTipoProyecto = source.IdTipoProyecto;
            target.IdSubPrograma = source.IdSubPrograma;
            target.Codigo = source.Codigo;
            target.ProyectoDenominacion = source.ProyectoDenominacion;
            target.ProyectoSituacionActual = source.ProyectoSituacionActual;
            target.ProyectoDescripcion = source.ProyectoDescripcion;
            target.ProyectoObservacion = source.ProyectoObservacion;
            target.IdEstado = source.IdEstado;
            target.IdProceso = source.IdProceso;
            target.IdModalidadContratacion = source.IdModalidadContratacion;
            target.IdFinalidadFuncion = source.IdFinalidadFuncion;
            target.IdOrganismoPrioridad = source.IdOrganismoPrioridad;
            target.SubPrioridad = source.SubPrioridad;
            target.EsBorrador = source.EsBorrador;
            target.EsProyecto = source.EsProyecto;
            target.NroProyecto = source.NroProyecto;
            target.AnioCorriente = source.AnioCorriente;
            target.AnioCorrienteEstimado = source.AnioCorrienteEstimado;
            target.AnioCorrienteRealizado = source.AnioCorrienteRealizado;
            target.FechaInicioEjecucionCalculada = source.FechaInicioEjecucionCalculada;
            target.FechaFinEjecucionCalculada = source.FechaFinEjecucionCalculada;
            target.FechaAlta = source.FechaAlta;
            target.FechaModificacion = source.FechaModificacion;
            target.IdUsuarioModificacion = source.IdUsuarioModificacion;
            target.IdProyectoPlan = source.IdProyectoPlan;
            target.EvaluarValidaciones = source.EvaluarValidaciones;
            target.Activo = source.Activo;
            target.IdEstadoDeDesicion = source.IdEstadoDeDesicion;
            target.EsPPP = source.EsPPP;
            target.NroActividad = source.NroActividad;
            target.NroObra = source.NroObra;
            target.NroProyectoEjecucion = source.NroProyectoEjecucion;
            target.NroActividadEjecucion = source.NroActividadEjecucion;
            target.NroObraEjecucion = source.NroObraEjecucion;

        }
        public override void Set(ProyectoResult source, Proyecto target, bool hadSetId)
        {
            if (hadSetId) target.IdProyecto = source.IdProyecto;
            target.IdTipoProyecto = source.IdTipoProyecto;
            target.IdSubPrograma = source.IdSubPrograma;
            target.Codigo = source.Codigo;
            target.ProyectoDenominacion = source.ProyectoDenominacion;
            target.ProyectoSituacionActual = source.ProyectoSituacionActual;
            target.ProyectoDescripcion = source.ProyectoDescripcion;
            target.ProyectoObservacion = source.ProyectoObservacion;
            target.IdEstado = source.IdEstado;
            target.IdProceso = source.IdProceso;
            target.IdModalidadContratacion = source.IdModalidadContratacion;
            target.IdFinalidadFuncion = source.IdFinalidadFuncion;
            target.IdOrganismoPrioridad = source.IdOrganismoPrioridad;
            target.SubPrioridad = source.SubPrioridad;
            target.EsBorrador = source.EsBorrador;
            target.EsProyecto = source.EsProyecto;
            target.NroProyecto = source.NroProyecto;
            target.AnioCorriente = source.AnioCorriente;
            target.AnioCorrienteEstimado = source.AnioCorrienteEstimado;
            target.AnioCorrienteRealizado = source.AnioCorrienteRealizado;
            target.FechaInicioEjecucionCalculada = source.FechaInicioEjecucionCalculada;
            target.FechaFinEjecucionCalculada = source.FechaFinEjecucionCalculada;
            target.FechaAlta = source.FechaAlta;
            target.FechaModificacion = source.FechaModificacion;
            target.IdUsuarioModificacion = source.IdUsuarioModificacion;
            target.IdProyectoPlan = source.IdProyectoPlan;
            target.EvaluarValidaciones = source.EvaluarValidaciones;
            target.Activo = source.Activo;
            target.IdEstadoDeDesicion = source.IdEstadoDeDesicion;
            target.EsPPP = source.EsPPP;
            target.NroActividad = source.NroActividad;
            target.NroObra = source.NroObra;
            target.NroProyectoEjecucion = source.NroProyectoEjecucion;
            target.NroActividadEjecucion = source.NroActividadEjecucion;
            target.NroObraEjecucion = source.NroObraEjecucion;

        }
        public override void Set(Proyecto source, ProyectoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyecto = source.IdProyecto;
            target.IdTipoProyecto = source.IdTipoProyecto;
            target.IdSubPrograma = source.IdSubPrograma;
            target.Codigo = source.Codigo;
            target.ProyectoDenominacion = source.ProyectoDenominacion;
            target.ProyectoSituacionActual = source.ProyectoSituacionActual;
            target.ProyectoDescripcion = source.ProyectoDescripcion;
            target.ProyectoObservacion = source.ProyectoObservacion;
            target.IdEstado = source.IdEstado;
            target.IdProceso = source.IdProceso;
            target.IdModalidadContratacion = source.IdModalidadContratacion;
            target.IdFinalidadFuncion = source.IdFinalidadFuncion;
            target.IdOrganismoPrioridad = source.IdOrganismoPrioridad;
            target.SubPrioridad = source.SubPrioridad;
            target.EsBorrador = source.EsBorrador;
            target.EsProyecto = source.EsProyecto;
            target.NroProyecto = source.NroProyecto;
            target.AnioCorriente = source.AnioCorriente;
            target.AnioCorrienteEstimado = source.AnioCorrienteEstimado;
            target.AnioCorrienteRealizado = source.AnioCorrienteRealizado;
            target.FechaInicioEjecucionCalculada = source.FechaInicioEjecucionCalculada;
            target.FechaFinEjecucionCalculada = source.FechaFinEjecucionCalculada;
            target.FechaAlta = source.FechaAlta;
            target.FechaModificacion = source.FechaModificacion;
            target.IdUsuarioModificacion = source.IdUsuarioModificacion;
            target.IdProyectoPlan = source.IdProyectoPlan;
            target.EvaluarValidaciones = source.EvaluarValidaciones;
            target.Activo = source.Activo;
            target.IdEstadoDeDesicion = source.IdEstadoDeDesicion;
            target.EsPPP = source.EsPPP;
            target.NroActividad = source.NroActividad;
            target.NroObra = source.NroObra;
            target.NroProyectoEjecucion = source.NroProyectoEjecucion;
            target.NroActividadEjecucion = source.NroActividadEjecucion;
            target.NroObraEjecucion = source.NroObraEjecucion;
        }
        public override void Set(ProyectoResult source, ProyectoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyecto = source.IdProyecto;
            target.IdTipoProyecto = source.IdTipoProyecto;
            target.IdSubPrograma = source.IdSubPrograma;
            target.Codigo = source.Codigo;
            target.ProyectoDenominacion = source.ProyectoDenominacion;
            target.ProyectoSituacionActual = source.ProyectoSituacionActual;
            target.ProyectoDescripcion = source.ProyectoDescripcion;
            target.ProyectoObservacion = source.ProyectoObservacion;
            target.IdEstado = source.IdEstado;
            target.IdProceso = source.IdProceso;
            target.IdModalidadContratacion = source.IdModalidadContratacion;
            target.IdFinalidadFuncion = source.IdFinalidadFuncion;
            target.IdOrganismoPrioridad = source.IdOrganismoPrioridad;
            target.SubPrioridad = source.SubPrioridad;
            target.EsBorrador = source.EsBorrador;
            target.EsProyecto = source.EsProyecto;
            target.NroProyecto = source.NroProyecto;
            target.AnioCorriente = source.AnioCorriente;
            target.AnioCorrienteEstimado = source.AnioCorrienteEstimado;
            target.AnioCorrienteRealizado = source.AnioCorrienteRealizado;
            target.FechaInicioEjecucionCalculada = source.FechaInicioEjecucionCalculada;
            target.FechaFinEjecucionCalculada = source.FechaFinEjecucionCalculada;
            target.FechaAlta = source.FechaAlta;
            target.FechaModificacion = source.FechaModificacion;
            target.IdUsuarioModificacion = source.IdUsuarioModificacion;
            target.IdProyectoPlan = source.IdProyectoPlan;
            target.EvaluarValidaciones = source.EvaluarValidaciones;
            target.Activo = source.Activo;
            target.IdEstadoDeDesicion = source.IdEstadoDeDesicion;
            target.EsPPP = source.EsPPP;
            target.NroActividad = source.NroActividad;
            target.NroObra = source.NroObra;
            target.NroProyectoEjecucion = source.NroProyectoEjecucion;
            target.NroActividadEjecucion = source.NroActividadEjecucion;
            target.NroObraEjecucion = source.NroObraEjecucion;
            target.Estado_Nombre = source.Estado_Nombre;
            //target.Estado_Codigo = source.Estado_Codigo;
            //target.Estado_Orden = source.Estado_Orden;
            //target.Estado_Descripcion = source.Estado_Descripcion;
            //target.Estado_Activo = source.Estado_Activo;
            //target.EstadoDeDesicion_Nombre = source.EstadoDeDesicion_Nombre;
            //target.EstadoDeDesicion_Codigo = source.EstadoDeDesicion_Codigo;
            //target.EstadoDeDesicion_Orden = source.EstadoDeDesicion_Orden;
            //target.EstadoDeDesicion_Descripcion = source.EstadoDeDesicion_Descripcion;
            //target.EstadoDeDesicion_Activo = source.EstadoDeDesicion_Activo;
            //target.FinalidadFuncion_Codigo = source.FinalidadFuncion_Codigo;
            //target.FinalidadFuncion_Denominacion = source.FinalidadFuncion_Denominacion;
            //target.FinalidadFuncion_Activo = source.FinalidadFuncion_Activo;
            //target.FinalidadFuncion_IdFinalidadFunciontipo = source.FinalidadFuncion_IdFinalidadFunciontipo;
            //target.FinalidadFuncion_IdFinalidadFuncionPadre = source.FinalidadFuncion_IdFinalidadFuncionPadre;
            //target.FinalidadFuncion_BreadcrumbId = source.FinalidadFuncion_BreadcrumbId;
            //target.FinalidadFuncion_BreadcrumbOrden = source.FinalidadFuncion_BreadcrumbOrden;
            //target.FinalidadFuncion_Nivel = source.FinalidadFuncion_Nivel;
            //target.FinalidadFuncion_Orden = source.FinalidadFuncion_Orden;
            //target.FinalidadFuncion_Descripcion = source.FinalidadFuncion_Descripcion;
            //target.FinalidadFuncion_DescripcionInvertida = source.FinalidadFuncion_DescripcionInvertida;
            //target.FinalidadFuncion_Seleccionable = source.FinalidadFuncion_Seleccionable;
            //target.FinalidadFuncion_BreadcrumbCode = source.FinalidadFuncion_BreadcrumbCode;
            //target.FinalidadFuncion_DescripcionCodigo = source.FinalidadFuncion_DescripcionCodigo;
            //target.ModalidadContratacion_Nombre = source.ModalidadContratacion_Nombre;
            //target.ModalidadContratacion_Activo = source.ModalidadContratacion_Activo;
            //target.OrganismoPrioridad_Nombre = source.OrganismoPrioridad_Nombre;
            //target.OrganismoPrioridad_Activo = source.OrganismoPrioridad_Activo;
            //target.Proceso_IdProyectoTipo = source.Proceso_IdProyectoTipo;
            //target.Proceso_Nombre = source.Proceso_Nombre;
            //target.Proceso_Activo = source.Proceso_Activo;
            //target.TipoProyecto_Sigla = source.TipoProyecto_Sigla;
            target.TipoProyecto_Nombre = source.TipoProyecto_Nombre;
            //target.TipoProyecto_Activo = source.TipoProyecto_Activo;
            //target.TipoProyecto_Tipo = source.TipoProyecto_Tipo;
            //target.SubPrograma_IdPrograma = source.SubPrograma_IdPrograma;
            target.SubPrograma_Codigo = source.SubPrograma_Codigo;
            //target.SubPrograma_Nombre = source.SubPrograma_Nombre;
            //target.SubPrograma_FechaAlta = source.SubPrograma_FechaAlta;
            //target.SubPrograma_FechaBaja = source.SubPrograma_FechaBaja;
            //target.SubPrograma_Activo = source.SubPrograma_Activo;

        }
        #endregion
        #region Equals
        public override bool Equals(Proyecto source, Proyecto target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if (!source.IdTipoProyecto.Equals(target.IdTipoProyecto)) return false;
            if (!source.IdSubPrograma.Equals(target.IdSubPrograma)) return false;
            if (!source.Codigo.Equals(target.Codigo)) return false;
            if ((source.ProyectoDenominacion == null) ? target.ProyectoDenominacion != null : !((target.ProyectoDenominacion == String.Empty && source.ProyectoDenominacion == null) || (target.ProyectoDenominacion == null && source.ProyectoDenominacion == String.Empty)) && !source.ProyectoDenominacion.Trim().Replace("\r", "").Equals(target.ProyectoDenominacion.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoSituacionActual == null) ? target.ProyectoSituacionActual != null : !((target.ProyectoSituacionActual == String.Empty && source.ProyectoSituacionActual == null) || (target.ProyectoSituacionActual == null && source.ProyectoSituacionActual == String.Empty)) && !source.ProyectoSituacionActual.Trim().Replace("\r", "").Equals(target.ProyectoSituacionActual.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoDescripcion == null) ? target.ProyectoDescripcion != null : !((target.ProyectoDescripcion == String.Empty && source.ProyectoDescripcion == null) || (target.ProyectoDescripcion == null && source.ProyectoDescripcion == String.Empty)) && !source.ProyectoDescripcion.Trim().Replace("\r", "").Equals(target.ProyectoDescripcion.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoObservacion == null) ? target.ProyectoObservacion != null : !((target.ProyectoObservacion == String.Empty && source.ProyectoObservacion == null) || (target.ProyectoObservacion == null && source.ProyectoObservacion == String.Empty)) && !source.ProyectoObservacion.Trim().Replace("\r", "").Equals(target.ProyectoObservacion.Trim().Replace("\r", ""))) return false;
            if (!source.IdEstado.Equals(target.IdEstado)) return false;
            if ((source.IdProceso == null) ? (target.IdProceso.HasValue && target.IdProceso.Value > 0) : !source.IdProceso.Equals(target.IdProceso)) return false;
            if ((source.IdModalidadContratacion == null) ? (target.IdModalidadContratacion.HasValue && target.IdModalidadContratacion.Value > 0) : !source.IdModalidadContratacion.Equals(target.IdModalidadContratacion)) return false;
            if ((source.IdFinalidadFuncion == null) ? (target.IdFinalidadFuncion.HasValue && target.IdFinalidadFuncion.Value > 0) : !source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion)) return false;
            if ((source.IdOrganismoPrioridad == null) ? (target.IdOrganismoPrioridad.HasValue && target.IdOrganismoPrioridad.Value > 0) : !source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad)) return false;
            if ((source.SubPrioridad == null) ? (target.SubPrioridad.HasValue) : !source.SubPrioridad.Equals(target.SubPrioridad)) return false;
            if (!source.EsBorrador.Equals(target.EsBorrador)) return false;
            if ((source.EsProyecto == null) ? (target.EsProyecto.HasValue) : !source.EsProyecto.Equals(target.EsProyecto)) return false;
            if ((source.NroProyecto == null) ? (target.NroProyecto.HasValue) : !source.NroProyecto.Equals(target.NroProyecto)) return false;
            if ((source.AnioCorriente == null) ? (target.AnioCorriente.HasValue) : !source.AnioCorriente.Equals(target.AnioCorriente)) return false;
            if ((source.AnioCorrienteEstimado == null) ? (target.AnioCorrienteEstimado.HasValue) : !source.AnioCorrienteEstimado.Equals(target.AnioCorrienteEstimado)) return false;
            if ((source.AnioCorrienteRealizado == null) ? (target.AnioCorrienteRealizado.HasValue) : !source.AnioCorrienteRealizado.Equals(target.AnioCorrienteRealizado)) return false;
            if ((source.FechaInicioEjecucionCalculada == null) ? (target.FechaInicioEjecucionCalculada.HasValue) : !source.FechaInicioEjecucionCalculada.Equals(target.FechaInicioEjecucionCalculada)) return false;
            if ((source.FechaFinEjecucionCalculada == null) ? (target.FechaFinEjecucionCalculada.HasValue) : !source.FechaFinEjecucionCalculada.Equals(target.FechaFinEjecucionCalculada)) return false;
            if (!source.FechaAlta.Equals(target.FechaAlta)) return false;
            if (!source.FechaModificacion.Equals(target.FechaModificacion)) return false;
            if (!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion)) return false;
            if ((source.IdProyectoPlan == null) ? (target.IdProyectoPlan.HasValue) : !source.IdProyectoPlan.Equals(target.IdProyectoPlan)) return false;
            if (!source.EvaluarValidaciones.Equals(target.EvaluarValidaciones)) return false;
            if (!source.Activo.Equals(target.Activo)) return false;
            if ((source.IdEstadoDeDesicion == null) ? (target.IdEstadoDeDesicion.HasValue && target.IdEstadoDeDesicion.Value > 0) : !source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion)) return false;
            if ((source.EsPPP == null) ? (target.EsPPP.HasValue) : !source.EsPPP.Equals(target.EsPPP)) return false;
            if ((source.NroActividad == null) ? (target.NroActividad.HasValue) : !source.NroActividad.Equals(target.NroActividad)) return false;
            if ((source.NroObra == null) ? (target.NroObra.HasValue) : !source.NroObra.Equals(target.NroObra)) return false;
            if ((source.NroProyectoEjecucion == null) ? (target.NroProyectoEjecucion.HasValue) : !source.NroProyectoEjecucion.Equals(target.NroProyectoEjecucion)) return false;
            if ((source.NroActividadEjecucion == null) ? (target.NroActividadEjecucion.HasValue) : !source.NroActividadEjecucion.Equals(target.NroActividadEjecucion)) return false;
            if ((source.NroObraEjecucion == null) ? (target.NroObraEjecucion.HasValue) : !source.NroObraEjecucion.Equals(target.NroObraEjecucion)) return false;
            return true;
        }
        public override bool Equals(ProyectoResult source, ProyectoResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            //if (!source.IdTipoProyecto.Equals(target.IdTipoProyecto)) return false;
            if (!source.IdSubPrograma.Equals(target.IdSubPrograma)) return false;
            if (!source.Codigo.Equals(target.Codigo)) return false;
            if ((source.ProyectoDenominacion == null) ? target.ProyectoDenominacion != null : !((target.ProyectoDenominacion == String.Empty && source.ProyectoDenominacion == null) || (target.ProyectoDenominacion == null && source.ProyectoDenominacion == String.Empty)) && !source.ProyectoDenominacion.Trim().Replace("\r", "").Equals(target.ProyectoDenominacion.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoSituacionActual == null) ? target.ProyectoSituacionActual != null : !((target.ProyectoSituacionActual == String.Empty && source.ProyectoSituacionActual == null) || (target.ProyectoSituacionActual == null && source.ProyectoSituacionActual == String.Empty)) && !source.ProyectoSituacionActual.Trim().Replace("\r", "").Equals(target.ProyectoSituacionActual.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoDescripcion == null) ? target.ProyectoDescripcion != null : !((target.ProyectoDescripcion == String.Empty && source.ProyectoDescripcion == null) || (target.ProyectoDescripcion == null && source.ProyectoDescripcion == String.Empty)) && !source.ProyectoDescripcion.Trim().Replace("\r", "").Equals(target.ProyectoDescripcion.Trim().Replace("\r", ""))) return false;
            if ((source.ProyectoObservacion == null) ? target.ProyectoObservacion != null : !((target.ProyectoObservacion == String.Empty && source.ProyectoObservacion == null) || (target.ProyectoObservacion == null && source.ProyectoObservacion == String.Empty)) && !source.ProyectoObservacion.Trim().Replace("\r", "").Equals(target.ProyectoObservacion.Trim().Replace("\r", ""))) return false;
            if (!source.IdEstado.Equals(target.IdEstado)) return false;
            if ((source.IdProceso == null) ? (target.IdProceso.HasValue && target.IdProceso.Value > 0) : !source.IdProceso.Equals(target.IdProceso)) return false;
            if ((source.IdModalidadContratacion == null) ? (target.IdModalidadContratacion.HasValue && target.IdModalidadContratacion.Value > 0) : !source.IdModalidadContratacion.Equals(target.IdModalidadContratacion)) return false;
            if ((source.IdFinalidadFuncion == null) ? (target.IdFinalidadFuncion.HasValue && target.IdFinalidadFuncion.Value > 0) : !source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion)) return false;
            if ((source.IdOrganismoPrioridad == null) ? (target.IdOrganismoPrioridad.HasValue && target.IdOrganismoPrioridad.Value > 0) : !source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad)) return false;
            if ((source.SubPrioridad == null) ? (target.SubPrioridad.HasValue) : !source.SubPrioridad.Equals(target.SubPrioridad)) return false;
            if (!source.EsBorrador.Equals(target.EsBorrador)) return false;
            if ((source.EsProyecto == null) ? (target.EsProyecto.HasValue) : !source.EsProyecto.Equals(target.EsProyecto)) return false;
            if ((source.NroProyecto == null) ? (target.NroProyecto.HasValue) : !source.NroProyecto.Equals(target.NroProyecto)) return false;
            if ((source.AnioCorriente == null) ? (target.AnioCorriente.HasValue) : !source.AnioCorriente.Equals(target.AnioCorriente)) return false;
            if ((source.AnioCorrienteEstimado == null) ? (target.AnioCorrienteEstimado.HasValue) : !source.AnioCorrienteEstimado.Equals(target.AnioCorrienteEstimado)) return false;
            if ((source.AnioCorrienteRealizado == null) ? (target.AnioCorrienteRealizado.HasValue) : !source.AnioCorrienteRealizado.Equals(target.AnioCorrienteRealizado)) return false;
            if ((source.FechaInicioEjecucionCalculada == null) ? (target.FechaInicioEjecucionCalculada.HasValue) : !source.FechaInicioEjecucionCalculada.Equals(target.FechaInicioEjecucionCalculada)) return false;
            if ((source.FechaFinEjecucionCalculada == null) ? (target.FechaFinEjecucionCalculada.HasValue) : !source.FechaFinEjecucionCalculada.Equals(target.FechaFinEjecucionCalculada)) return false;
            if (!source.FechaAlta.Equals(target.FechaAlta)) return false;
            if (!source.FechaModificacion.Equals(target.FechaModificacion)) return false;
            if (!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion)) return false;
            if ((source.IdProyectoPlan == null) ? (target.IdProyectoPlan.HasValue) : !source.IdProyectoPlan.Equals(target.IdProyectoPlan)) return false;
            if (!source.EvaluarValidaciones.Equals(target.EvaluarValidaciones)) return false;
            if (!source.Activo.Equals(target.Activo)) return false;
            if ((source.IdEstadoDeDesicion == null) ? (target.IdEstadoDeDesicion.HasValue && target.IdEstadoDeDesicion.Value > 0) : !source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion)) return false;
            if ((source.EsPPP == null) ? (target.EsPPP.HasValue) : !(source.EsPPP.Equals(target.EsPPP))) return false;
            if ((source.NroActividad == null) ? (target.NroActividad.HasValue) : !source.NroActividad.Equals(target.NroActividad)) return false;
            if ((source.NroObra == null) ? (target.NroObra.HasValue) : !source.NroObra.Equals(target.NroObra)) return false;
            if ((source.NroProyectoEjecucion == null) ? (target.NroProyectoEjecucion.HasValue) : !source.NroProyectoEjecucion.Equals(target.NroProyectoEjecucion)) return false;
            if ((source.NroActividadEjecucion == null) ? (target.NroActividadEjecucion.HasValue) : !source.NroActividadEjecucion.Equals(target.NroActividadEjecucion)) return false;
            if ((source.NroObraEjecucion == null) ? (target.NroObraEjecucion.HasValue) : !source.NroObraEjecucion.Equals(target.NroObraEjecucion)) return false;

            if ((source.Estado_Nombre == null) ? target.Estado_Nombre != null : !((target.Estado_Nombre == String.Empty && source.Estado_Nombre == null) || (target.Estado_Nombre == null && source.Estado_Nombre == String.Empty)) && !source.Estado_Nombre.Trim().Replace("\r", "").Equals(target.Estado_Nombre.Trim().Replace("\r", ""))) return false;
            //if ((source.Estado_Codigo == null) ? target.Estado_Codigo != null : !((target.Estado_Codigo == String.Empty && source.Estado_Codigo == null) || (target.Estado_Codigo == null && source.Estado_Codigo == String.Empty)) && !source.Estado_Codigo.Trim().Replace("\r", "").Equals(target.Estado_Codigo.Trim().Replace("\r", ""))) return false;
            //if (!source.Estado_Orden.Equals(target.Estado_Orden)) return false;
            //if ((source.Estado_Descripcion == null) ? target.Estado_Descripcion != null : !((target.Estado_Descripcion == String.Empty && source.Estado_Descripcion == null) || (target.Estado_Descripcion == null && source.Estado_Descripcion == String.Empty)) && !source.Estado_Descripcion.Trim().Replace("\r", "").Equals(target.Estado_Descripcion.Trim().Replace("\r", ""))) return false;
            //if (!source.Estado_Activo.Equals(target.Estado_Activo)) return false;
            //if ((source.EstadoDeDesicion_Nombre == null) ? target.EstadoDeDesicion_Nombre != null : !((target.EstadoDeDesicion_Nombre == String.Empty && source.EstadoDeDesicion_Nombre == null) || (target.EstadoDeDesicion_Nombre == null && source.EstadoDeDesicion_Nombre == String.Empty)) && !source.EstadoDeDesicion_Nombre.Trim().Replace("\r", "").Equals(target.EstadoDeDesicion_Nombre.Trim().Replace("\r", ""))) return false;
            //if ((source.EstadoDeDesicion_Codigo == null) ? target.EstadoDeDesicion_Codigo != null : !((target.EstadoDeDesicion_Codigo == String.Empty && source.EstadoDeDesicion_Codigo == null) || (target.EstadoDeDesicion_Codigo == null && source.EstadoDeDesicion_Codigo == String.Empty)) && !source.EstadoDeDesicion_Codigo.Trim().Replace("\r", "").Equals(target.EstadoDeDesicion_Codigo.Trim().Replace("\r", ""))) return false;
            //if (!source.EstadoDeDesicion_Orden.Equals(target.EstadoDeDesicion_Orden)) return false;
            //if ((source.EstadoDeDesicion_Descripcion == null) ? target.EstadoDeDesicion_Descripcion != null : !((target.EstadoDeDesicion_Descripcion == String.Empty && source.EstadoDeDesicion_Descripcion == null) || (target.EstadoDeDesicion_Descripcion == null && source.EstadoDeDesicion_Descripcion == String.Empty)) && !source.EstadoDeDesicion_Descripcion.Trim().Replace("\r", "").Equals(target.EstadoDeDesicion_Descripcion.Trim().Replace("\r", ""))) return false;
            //if (!source.EstadoDeDesicion_Activo.Equals(target.EstadoDeDesicion_Activo)) return false;
            //if ((source.FinalidadFuncion_Codigo == null) ? target.FinalidadFuncion_Codigo != null : !((target.FinalidadFuncion_Codigo == String.Empty && source.FinalidadFuncion_Codigo == null) || (target.FinalidadFuncion_Codigo == null && source.FinalidadFuncion_Codigo == String.Empty)) && !source.FinalidadFuncion_Codigo.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_Codigo.Trim().Replace("\r", ""))) return false;
            //if ((source.FinalidadFuncion_Denominacion == null) ? target.FinalidadFuncion_Denominacion != null : !((target.FinalidadFuncion_Denominacion == String.Empty && source.FinalidadFuncion_Denominacion == null) || (target.FinalidadFuncion_Denominacion == null && source.FinalidadFuncion_Denominacion == String.Empty)) && !source.FinalidadFuncion_Denominacion.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_Denominacion.Trim().Replace("\r", ""))) return false;
            //if (!source.FinalidadFuncion_Activo.Equals(target.FinalidadFuncion_Activo)) return false;
            //if ((source.FinalidadFuncion_IdFinalidadFunciontipo == null) ? (target.FinalidadFuncion_IdFinalidadFunciontipo.HasValue && target.FinalidadFuncion_IdFinalidadFunciontipo.Value > 0) : !source.FinalidadFuncion_IdFinalidadFunciontipo.Equals(target.FinalidadFuncion_IdFinalidadFunciontipo)) return false;
            //if ((source.FinalidadFuncion_IdFinalidadFuncionPadre == null) ? (target.FinalidadFuncion_IdFinalidadFuncionPadre.HasValue && target.FinalidadFuncion_IdFinalidadFuncionPadre.Value > 0) : !source.FinalidadFuncion_IdFinalidadFuncionPadre.Equals(target.FinalidadFuncion_IdFinalidadFuncionPadre)) return false;
            //if ((source.FinalidadFuncion_BreadcrumbId == null) ? target.FinalidadFuncion_BreadcrumbId != null : !((target.FinalidadFuncion_BreadcrumbId == String.Empty && source.FinalidadFuncion_BreadcrumbId == null) || (target.FinalidadFuncion_BreadcrumbId == null && source.FinalidadFuncion_BreadcrumbId == String.Empty)) && !source.FinalidadFuncion_BreadcrumbId.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_BreadcrumbId.Trim().Replace("\r", ""))) return false;
            //if ((source.FinalidadFuncion_BreadcrumbOrden == null) ? target.FinalidadFuncion_BreadcrumbOrden != null : !((target.FinalidadFuncion_BreadcrumbOrden == String.Empty && source.FinalidadFuncion_BreadcrumbOrden == null) || (target.FinalidadFuncion_BreadcrumbOrden == null && source.FinalidadFuncion_BreadcrumbOrden == String.Empty)) && !source.FinalidadFuncion_BreadcrumbOrden.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_BreadcrumbOrden.Trim().Replace("\r", ""))) return false;
            //if ((source.FinalidadFuncion_Nivel == null) ? (target.FinalidadFuncion_Nivel.HasValue) : !source.FinalidadFuncion_Nivel.Equals(target.FinalidadFuncion_Nivel)) return false;
            //if ((source.FinalidadFuncion_Orden == null) ? (target.FinalidadFuncion_Orden.HasValue) : !source.FinalidadFuncion_Orden.Equals(target.FinalidadFuncion_Orden)) return false;
            //if ((source.FinalidadFuncion_Descripcion == null) ? target.FinalidadFuncion_Descripcion != null : !((target.FinalidadFuncion_Descripcion == String.Empty && source.FinalidadFuncion_Descripcion == null) || (target.FinalidadFuncion_Descripcion == null && source.FinalidadFuncion_Descripcion == String.Empty)) && !source.FinalidadFuncion_Descripcion.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_Descripcion.Trim().Replace("\r", ""))) return false;
            //if ((source.FinalidadFuncion_DescripcionInvertida == null) ? target.FinalidadFuncion_DescripcionInvertida != null : !((target.FinalidadFuncion_DescripcionInvertida == String.Empty && source.FinalidadFuncion_DescripcionInvertida == null) || (target.FinalidadFuncion_DescripcionInvertida == null && source.FinalidadFuncion_DescripcionInvertida == String.Empty)) && !source.FinalidadFuncion_DescripcionInvertida.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_DescripcionInvertida.Trim().Replace("\r", ""))) return false;
            //if (!source.FinalidadFuncion_Seleccionable.Equals(target.FinalidadFuncion_Seleccionable)) return false;
            //if ((source.FinalidadFuncion_BreadcrumbCode == null) ? target.FinalidadFuncion_BreadcrumbCode != null : !((target.FinalidadFuncion_BreadcrumbCode == String.Empty && source.FinalidadFuncion_BreadcrumbCode == null) || (target.FinalidadFuncion_BreadcrumbCode == null && source.FinalidadFuncion_BreadcrumbCode == String.Empty)) && !source.FinalidadFuncion_BreadcrumbCode.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_BreadcrumbCode.Trim().Replace("\r", ""))) return false;
            //if ((source.FinalidadFuncion_DescripcionCodigo == null) ? target.FinalidadFuncion_DescripcionCodigo != null : !((target.FinalidadFuncion_DescripcionCodigo == String.Empty && source.FinalidadFuncion_DescripcionCodigo == null) || (target.FinalidadFuncion_DescripcionCodigo == null && source.FinalidadFuncion_DescripcionCodigo == String.Empty)) && !source.FinalidadFuncion_DescripcionCodigo.Trim().Replace("\r", "").Equals(target.FinalidadFuncion_DescripcionCodigo.Trim().Replace("\r", ""))) return false;
            //if ((source.ModalidadContratacion_Nombre == null) ? target.ModalidadContratacion_Nombre != null : !((target.ModalidadContratacion_Nombre == String.Empty && source.ModalidadContratacion_Nombre == null) || (target.ModalidadContratacion_Nombre == null && source.ModalidadContratacion_Nombre == String.Empty)) && !source.ModalidadContratacion_Nombre.Trim().Replace("\r", "").Equals(target.ModalidadContratacion_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.ModalidadContratacion_Activo.Equals(target.ModalidadContratacion_Activo)) return false;
            //if ((source.OrganismoPrioridad_Nombre == null) ? target.OrganismoPrioridad_Nombre != null : !((target.OrganismoPrioridad_Nombre == String.Empty && source.OrganismoPrioridad_Nombre == null) || (target.OrganismoPrioridad_Nombre == null && source.OrganismoPrioridad_Nombre == String.Empty)) && !source.OrganismoPrioridad_Nombre.Trim().Replace("\r", "").Equals(target.OrganismoPrioridad_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.OrganismoPrioridad_Activo.Equals(target.OrganismoPrioridad_Activo)) return false;
            //if (!source.Proceso_IdProyectoTipo.Equals(target.Proceso_IdProyectoTipo)) return false;
            //if ((source.Proceso_Nombre == null) ? target.Proceso_Nombre != null : !((target.Proceso_Nombre == String.Empty && source.Proceso_Nombre == null) || (target.Proceso_Nombre == null && source.Proceso_Nombre == String.Empty)) && !source.Proceso_Nombre.Trim().Replace("\r", "").Equals(target.Proceso_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.Proceso_Activo.Equals(target.Proceso_Activo)) return false;
            //if ((source.TipoProyecto_Sigla == null) ? target.TipoProyecto_Sigla != null : !((target.TipoProyecto_Sigla == String.Empty && source.TipoProyecto_Sigla == null) || (target.TipoProyecto_Sigla == null && source.TipoProyecto_Sigla == String.Empty)) && !source.TipoProyecto_Sigla.Trim().Replace("\r", "").Equals(target.TipoProyecto_Sigla.Trim().Replace("\r", ""))) return false;
            if ((source.TipoProyecto_Nombre == null) ? target.TipoProyecto_Nombre != null : !((target.TipoProyecto_Nombre == String.Empty && source.TipoProyecto_Nombre == null) || (target.TipoProyecto_Nombre == null && source.TipoProyecto_Nombre == String.Empty)) && !source.TipoProyecto_Nombre.Trim().Replace("\r", "").Equals(target.TipoProyecto_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.TipoProyecto_Activo.Equals(target.TipoProyecto_Activo)) return false;
            //if ((source.TipoProyecto_Tipo == null) ? target.TipoProyecto_Tipo != null : !((target.TipoProyecto_Tipo == String.Empty && source.TipoProyecto_Tipo == null) || (target.TipoProyecto_Tipo == null && source.TipoProyecto_Tipo == String.Empty)) && !source.TipoProyecto_Tipo.Trim().Replace("\r", "").Equals(target.TipoProyecto_Tipo.Trim().Replace("\r", ""))) return false;
            //if (!source.SubPrograma_IdPrograma.Equals(target.SubPrograma_IdPrograma)) return false;
            if ((source.SubPrograma_Codigo == null) ? target.SubPrograma_Codigo != null : !((target.SubPrograma_Codigo == String.Empty && source.SubPrograma_Codigo == null) || (target.SubPrograma_Codigo == null && source.SubPrograma_Codigo == String.Empty)) && !source.SubPrograma_Codigo.Trim().Replace("\r", "").Equals(target.SubPrograma_Codigo.Trim().Replace("\r", ""))) return false;
            //if ((source.SubPrograma_Nombre == null) ? target.SubPrograma_Nombre != null : !((target.SubPrograma_Nombre == String.Empty && source.SubPrograma_Nombre == null) || (target.SubPrograma_Nombre == null && source.SubPrograma_Nombre == String.Empty)) && !source.SubPrograma_Nombre.Trim().Replace("\r", "").Equals(target.SubPrograma_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.SubPrograma_FechaAlta.Equals(target.SubPrograma_FechaAlta)) return false;
            //if ((source.SubPrograma_FechaBaja == null) ? (target.SubPrograma_FechaBaja.HasValue) : !source.SubPrograma_FechaBaja.Equals(target.SubPrograma_FechaBaja)) return false;
            //if (!source.SubPrograma_Activo.Equals(target.SubPrograma_Activo)) return false;

            return true;
        }
        #endregion

        #endregion
        #region Constantes
        protected const string ID_PROYECTOCALIDAD_ESTADO_CONTROLADO = "ID_PROYECTOCALIDAD_ESTADO_CONTROLADO";
        protected const string ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR = "ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR";
        #endregion
        #region Query
        /*
        public int QueryCountSP(ProyectoFilter filter)
        {
            int? codigoBapin;
            int? idJurisdiccion;
            int? idSaf;
            int? idPrograma;
            int? idSubprograma;
            string proyectoDenominacion;
            bool? esBorrador;
            DateTime? fechaModificacionDesde;
            DateTime? fechaModificacionHasta;
            string idEstados;
            bool? activo;
            int? idPlanTipo;
            int? idPlanPeriodo;
            int? idPlanVersion;
            int? idOficina;
            string oficina;



            codigoBapin = filter.Codigo;
            idJurisdiccion = filter.IdJurisdiccion;
            idSaf = filter.IdSaf;
            idPrograma = filter.IdPrograma;
            idSubprograma = filter.IdSubPrograma;
            proyectoDenominacion = filter.ProyectoDenominacion == String.Empty ? null : filter.ProyectoDenominacion;
            esBorrador = filter.EsBorrador;
            fechaModificacionDesde = filter.FechaModificacion;
            fechaModificacionHasta = filter.FechaModificacion_To;
            idEstados = String.Join(",", filter.IdsEstado.Select(x => x.ToString()).ToArray());
            idEstados = idEstados == String.Empty ? null : idEstados;
            activo = filter.Activo;
            idPlanTipo = filter.IdPlanTipo == 0 ? null : filter.IdPlanTipo;
            idPlanPeriodo = filter.IdPlanPeriodo == 0 ? null : filter.IdPlanTipo;
            idPlanVersion = filter.IdPlanVersion == 0 ? null : filter.IdPlanVersion;
            idOficina = filter.IdOficina == 0 ? null : filter.IdOficina;
            oficina = filter.IdOficina.HasValue ? "." + filter.IdOficina.Value.ToString() + "." : null;



            int result = this.Context.sp_Proyectos_Count(
                    codigoBapin,
                    idJurisdiccion,
                    idSaf,
                    idPrograma,
                    idSubprograma,
                    proyectoDenominacion,
                    esBorrador,
                    fechaModificacionDesde,
                    fechaModificacionHasta,
                    idEstados,
                    activo,
                    idPlanTipo,
                    idPlanPeriodo,
                    idPlanVersion,
                    idOficina,
                    oficina);



           
            return result;
        }
        
        public ListPaged<ProyectoResult> QuerySP(ProyectoFilter filter)
        {
            int? codigoBapin;
            int? idJurisdiccion;
            int? idSaf;
            int? idPrograma;
            int? idSubprograma;
            string proyectoDenominacion;
            bool? esBorrador;
            DateTime? fechaModificacionDesde;
            DateTime? fechaModificacionHasta;
            string idEstados;
            bool? activo;
            int? idPlanTipo;
            int? idPlanPeriodo;
            int? idPlanVersion;
            int? idOficina;
            string oficina;
            int desde;
            int hasta;

            int? totalRows = null;
            if (filter.GetTotaRowsCount)
            {
                totalRows = this.QueryCountSP(filter);
                if (totalRows.HasValue)
                {
                    if (filter.PageNumber * filter.PageSize >= totalRows + filter.PageSize)
                        filter.PageNumber = 1;
                }
            }

            desde = filter.PageSize * (filter.PageNumber - 1);
            hasta = filter.PageSize;
 

            codigoBapin = filter.Codigo;
            idJurisdiccion = filter.IdJurisdiccion;
            idSaf = filter.IdSaf;
            idPrograma = filter.IdPrograma;
            idSubprograma = filter.IdSubPrograma;
            proyectoDenominacion = filter.ProyectoDenominacion == String.Empty ? null : filter.ProyectoDenominacion;
            esBorrador = filter.EsBorrador;
            fechaModificacionDesde = filter.FechaModificacion;
            fechaModificacionHasta = filter.FechaModificacion_To;
            idEstados = String.Join(",", filter.IdsEstado.Select(x => x.ToString()).ToArray());
            idEstados = idEstados == String.Empty ? null : idEstados;
            activo = filter.Activo;
            idPlanTipo = filter.IdPlanTipo == 0 ? null : filter.IdPlanTipo;
            idPlanPeriodo = filter.IdPlanPeriodo == 0 ? null : filter.IdPlanTipo;
            idPlanVersion = filter.IdPlanVersion == 0 ? null : filter.IdPlanVersion;
            idOficina = filter.IdOficina == 0 ? null : filter.IdOficina;
            oficina = filter.IdOficina.HasValue ? "." + filter.IdOficina.Value.ToString() + "." : null;


            List<sp_Proyectos_ListResult> result = this.Context.sp_Proyectos_List(
                    codigoBapin,
                    idJurisdiccion,
                    idSaf,
                    idPrograma,
                    idSubprograma,
                    proyectoDenominacion,
                    esBorrador,
                    fechaModificacionDesde,
                    fechaModificacionHasta,
                    idEstados,
                    activo,
                    idPlanTipo,
                    idPlanPeriodo,
                    idPlanVersion,
                    idOficina,
                    oficina,
                    desde,
                    hasta).ToList();

            List<ProyectoResult> results = new List<ProyectoResult>();

            foreach (sp_Proyectos_ListResult res in result)
            {
                ProyectoResult proyectoResult = new ProyectoResult()
                          {
                              IdProyecto = res.IdProyecto,
                              IdTipoProyecto = res.IdTipoProyecto,
                              IdSubPrograma = res.IdSubPrograma,
                              Codigo = res.Codigo,
                              ProyectoDenominacion = res.ProyectoDenominacion,
                              ProyectoSituacionActual = res.ProyectoSituacionActual,
                              ProyectoDescripcion = res.ProyectoDescripcion,
                              ProyectoObservacion = res.ProyectoObservacion,
                              IdEstado = res.IdEstado,
                              IdProceso = res.IdProceso,
                              IdModalidadContratacion = res.IdModalidadContratacion,
                              ModalidadContratacion_Nombre = res.ModalidadContratacion_Nombre,
                              IdFinalidadFuncion = res.IdFinalidadFuncion,
                              FinalidadFuncion_BreadcrumbCode = res.FinalidadFuncion_BreadcrumbCode,
                              FinalidadFuncion_DescripcionInvertida = res.FinalidadFuncion_DescripcionInvertida,
                              IdOrganismoPrioridad = res.IdOrganismoPrioridad,
                              OrganismoPrioridad_Nombre = res.OrganismoPrioridad_Nombre,
                              SubPrioridad = res.SubPrioridad,
                              EsBorrador = res.EsBorrador,
                              EsProyecto = res.EsProyecto,
                              NroProyecto = res.NroProyecto,
                              AnioCorriente = res.AnioCorriente,
                              FechaInicioEjecucionCalculada = res.FechaInicioEjecucionCalculada,
                              FechaFinEjecucionCalculada = res.FechaFinEjecucionCalculada,
                              FechaAlta = res.FechaAlta,
                              FechaModificacion = res.FechaModificacion,
                              IdUsuarioModificacion = res.IdUsuarioModificacion,
                              IdProyectoPlan = res.IdProyectoPlan,
                              IdEstadoDeDesicion = res.IdEstadoDeDesicion,
                              Estado_Nombre = res.Estado_Nombre,
                              EvaluarValidaciones = res.EvaluarValidaciones,
                              Proceso_Nombre = res.Proceso_Nombre,
                              TipoProyecto_Nombre = res.TipoProyecto_Nombre,
                              SubPrograma_Codigo = res.SubPrograma_Codigo,
                              SubPrograma_Nombre = res.SubPrograma_Nombre,
                              IdSAF = res.IdSAF,
                              IdPrograma = res.IdPrograma,
                              Programa_Codigo = res.Programa_Codigo,
                              Programa_Nombre = res.Programa_Nombre,
                              Saf_Nombre = res.Saf_Nombre,
                              Saf_Codigo = res.Saf_Codigo,
                              Jurisdiccion_Codigo = res.Jurisdiccion_Codigo,
                              Jurisdiccion_Nombre = res.Jurisdiccion_Nombre,
                              RequiereDictamen = res.RequiereDictamen.HasValue ? Convert.ToBoolean(res.RequiereDictamen.Value) : false,
                              Plan_Ultimo =res.Plan_Ultimo,
                              Apertura = res.Apertura,
                              Activo = res.Activo,
                              Saf_SectorNombre = res.Saf_SectorNombre,
                              Saf_AdministracionTipoNombre = res.Saf_AdministracionTipoNombre,
                              Saf_EntidadTipoNombre = res.Saf_EntidadTipoNombre,
                              Color = res.EsBorrador ? (System.Drawing.Color.Red) :
                                                res.value9 != 0 ? (System.Drawing.Color.Blue) : (System.Drawing.Color.Black),
                              CalidadACorregir = res.CalidadACorregir != null? Convert.ToBoolean(res.CalidadACorregir.Value) : false
                              //Aca se modifica el Color!
                              //http://devnet.asna.com/documentation/Help_Files/AVR72/AVR72_web/avrlrfSettingColors.htm
                          };
                results.Add(proyectoResult);
            }
            ListPaged<ProyectoResult> list = new ListPaged<ProyectoResult>(results);
            list.TotalRows = totalRows;
            return list;
        }
        */
        protected override IQueryable<Proyecto> Query(ProyectoFilter filter)
        {
            string strIdParent = filter.IdOficina.HasValue ? "." + filter.IdOficina.Value.ToString() + "." : string.Empty;

            string strIdFinalidadFuncion = filter.IdFinalidadFuncion.HasValue ? "." + filter.IdFinalidadFuncion.Value.ToString() + "." : string.Empty;

            string strIdClasificacionGeografica = filter.IdClasificacionGeografica.HasValue ? "." + filter.IdClasificacionGeografica.Value.ToString() + "." : string.Empty;

            IQueryable<Proyecto> query = (from o in this.Table
                                          where

                                          (
                                               (filter.Codigo != null && filter.UnicamentePorCodigo != null && filter.UnicamentePorCodigo == true && o.Codigo == filter.Codigo)
                                               &&
                                              //filtra los proyectos por las oficinas del usuario   
                                               (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 || (from pop in this.Context.ProyectoOficinaPerfils where filter.IdsOficinaByUsuario.Contains(pop.IdOficina) select pop.IdProyecto).Contains(o.IdProyecto))

                                          )

                                          ||

                                          (
                                              
                                           #region Filter
                                              (filter.Codigo == null || filter.Codigo == o.Codigo)
                                              && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                                              && (filter.IdTipoProyecto == null || filter.IdTipoProyecto == 0 || o.IdTipoProyecto == filter.IdTipoProyecto)
                                              && (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || o.IdSubPrograma == filter.IdSubPrograma)
                                              && (filter.ProyectoDenominacion == null || filter.ProyectoDenominacion.Trim() == string.Empty || filter.ProyectoDenominacion.Trim() == "%" || (filter.ProyectoDenominacion.EndsWith("%") && filter.ProyectoDenominacion.StartsWith("%") && (o.ProyectoDenominacion.Contains(filter.ProyectoDenominacion.Replace("%", "")))) || (filter.ProyectoDenominacion.EndsWith("%") && o.ProyectoDenominacion.StartsWith(filter.ProyectoDenominacion.Replace("%", ""))) || (filter.ProyectoDenominacion.StartsWith("%") && o.ProyectoDenominacion.EndsWith(filter.ProyectoDenominacion.Replace("%", ""))) || o.ProyectoDenominacion == filter.ProyectoDenominacion)
                                              && (filter.ProyectoSituacionActual == null || filter.ProyectoSituacionActual.Trim() == string.Empty || filter.ProyectoSituacionActual.Trim() == "%" || (filter.ProyectoSituacionActual.EndsWith("%") && filter.ProyectoSituacionActual.StartsWith("%") && (o.ProyectoSituacionActual.Contains(filter.ProyectoSituacionActual.Replace("%", "")))) || (filter.ProyectoSituacionActual.EndsWith("%") && o.ProyectoSituacionActual.StartsWith(filter.ProyectoSituacionActual.Replace("%", ""))) || (filter.ProyectoSituacionActual.StartsWith("%") && o.ProyectoSituacionActual.EndsWith(filter.ProyectoSituacionActual.Replace("%", ""))) || o.ProyectoSituacionActual == filter.ProyectoSituacionActual)

                                              && (filter.ProyectoDescripcion == null || filter.ProyectoDescripcion.Trim() == string.Empty || filter.ProyectoDescripcion.Trim() == "%" || (filter.ProyectoDescripcion.EndsWith("%") && filter.ProyectoDescripcion.StartsWith("%") && (o.ProyectoDescripcion.Contains(filter.ProyectoDescripcion.Replace("%", "")))) || (filter.ProyectoDescripcion.EndsWith("%") && o.ProyectoDescripcion.StartsWith(filter.ProyectoDescripcion.Replace("%", ""))) || (filter.ProyectoDescripcion.StartsWith("%") && o.ProyectoDescripcion.EndsWith(filter.ProyectoDescripcion.Replace("%", ""))) || o.ProyectoDescripcion == filter.ProyectoDescripcion)

                                              /*&& (filter.ProyectoDescripcion == null || filter.ProyectoDescripcion.Trim() == string.Empty || filter.ProyectoDescripcion.Trim() == "%" ||
                                              ((filter.ProyectoDescripcion.StartsWith("%") == false || filter.ProyectoDescripcion.EndsWith("%") == false || o.ProyectoDescripcion.Contains(filter.ProyectoDescripcion.Replace("%", "")))
                                              && (filter.ProyectoDescripcion.StartsWith("%") == true || filter.ProyectoDescripcion.EndsWith("%") == false || o.ProyectoDescripcion.StartsWith(filter.ProyectoDescripcion.Replace("%", "")))
                                              && (filter.ProyectoDescripcion.StartsWith("%") == false || filter.ProyectoDescripcion.EndsWith("%") == true || o.ProyectoDescripcion.EndsWith(filter.ProyectoDescripcion.Replace("%", "")))
                                              && (filter.ProyectoDescripcion.StartsWith("%") == true || filter.ProyectoDescripcion.EndsWith("%") == true || o.ProyectoDescripcion == filter.ProyectoDescripcion))
                                              )*/

                                              && (filter.ProyectoObservacion == null || filter.ProyectoObservacion.Trim() == string.Empty || filter.ProyectoObservacion.Trim() == "%" || (filter.ProyectoObservacion.EndsWith("%") && filter.ProyectoObservacion.StartsWith("%") && (o.ProyectoObservacion.Contains(filter.ProyectoObservacion.Replace("%", "")))) || (filter.ProyectoObservacion.EndsWith("%") && o.ProyectoObservacion.StartsWith(filter.ProyectoObservacion.Replace("%", ""))) || (filter.ProyectoObservacion.StartsWith("%") && o.ProyectoObservacion.EndsWith(filter.ProyectoObservacion.Replace("%", ""))) || o.ProyectoObservacion == filter.ProyectoObservacion)
                                              && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado == filter.IdEstado)
                                              && (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso == filter.IdProceso)
                                              && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == true || o.IdProceso != null) && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == false || o.IdProceso == null)
                                              && (filter.IdModalidadContratacion == null || filter.IdModalidadContratacion == 0 || o.IdModalidadContratacion == filter.IdModalidadContratacion)
                                              && (filter.IdModalidadContratacionIsNull == null || filter.IdModalidadContratacionIsNull == true || o.IdModalidadContratacion != null) && (filter.IdModalidadContratacionIsNull == null || filter.IdModalidadContratacionIsNull == false || o.IdModalidadContratacion == null)

                                              && (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || filter.IncluirFinalidadFunInteriores == true || o.IdFinalidadFuncion == filter.IdFinalidadFuncion)
                                              && (filter.IdFinalidadFuncionIsNull == null || filter.IdFinalidadFuncionIsNull == true || o.IdFinalidadFuncion != null) && (filter.IdFinalidadFuncionIsNull == null || filter.IdFinalidadFuncionIsNull == false || o.IdFinalidadFuncion == null)
                                              && (filter.IncluirFinalidadFunInteriores == null || filter.IncluirFinalidadFunInteriores == false || filter.IdFinalidadFuncion == null || strIdFinalidadFuncion == string.Empty
                                                 || (from ff in this.Context.FinalidadFuncions where ff.BreadcrumbId.Contains(strIdFinalidadFuncion) select ff.IdFinalidadFuncion).Contains(o.IdFinalidadFuncion.Value))


                                              && (filter.IdOrganismoPrioridad == null || filter.IdOrganismoPrioridad == 0 || o.IdOrganismoPrioridad == filter.IdOrganismoPrioridad)
                                              && (filter.IdOrganismoPrioridadIsNull == null || filter.IdOrganismoPrioridadIsNull == true || o.IdOrganismoPrioridad != null) && (filter.IdOrganismoPrioridadIsNull == null || filter.IdOrganismoPrioridadIsNull == false || o.IdOrganismoPrioridad == null)
                                              && (filter.SubPrioridad == null || o.SubPrioridad >= filter.SubPrioridad) && (filter.SubPrioridad_To == null || o.SubPrioridad <= filter.SubPrioridad_To)
                                              && (filter.SubPrioridadIsNull == null || filter.SubPrioridadIsNull == true || o.SubPrioridad != null) && (filter.SubPrioridadIsNull == null || filter.SubPrioridadIsNull == false || o.SubPrioridad == null)
                                              && (filter.EsBorrador == null || o.EsBorrador == filter.EsBorrador)
                                              && (filter.EsProyecto == null || o.EsProyecto == filter.EsProyecto)
                                              && (filter.EsProyectoIsNull == null || filter.EsProyectoIsNull == true || o.EsProyecto != null) && (filter.EsProyectoIsNull == null || filter.EsProyectoIsNull == false || o.EsProyecto == null)
                                              && (filter.NroProyecto == null || o.NroProyecto >= filter.NroProyecto) && (filter.NroProyecto_To == null || o.NroProyecto <= filter.NroProyecto_To)
                                              && (filter.NroProyectoIsNull == null || filter.NroProyectoIsNull == true || o.NroProyecto != null) && (filter.NroProyectoIsNull == null || filter.NroProyectoIsNull == false || o.NroProyecto == null)
                                              && (filter.AnioCorriente == null || o.AnioCorriente >= filter.AnioCorriente) && (filter.AnioCorriente_To == null || o.AnioCorriente <= filter.AnioCorriente_To)
                                              && (filter.AnioCorrienteIsNull == null || filter.AnioCorrienteIsNull == true || o.AnioCorriente != null) && (filter.AnioCorrienteIsNull == null || filter.AnioCorrienteIsNull == false || o.AnioCorriente == null)

                                              && (filter.AnioCorrienteEstimado == null || o.AnioCorrienteEstimado >= filter.AnioCorrienteEstimado) && (filter.AnioCorrienteEstimado_To == null || o.AnioCorrienteEstimado <= filter.AnioCorrienteEstimado_To)
                                              && (filter.AnioCorrienteEstimadoIsNull == null || filter.AnioCorrienteEstimadoIsNull == true || o.AnioCorrienteEstimado != null) && (filter.AnioCorrienteEstimadoIsNull == null || filter.AnioCorrienteEstimadoIsNull == false || o.AnioCorrienteEstimado == null)

                                              && (filter.AnioCorrienteRealizado == null || o.AnioCorrienteRealizado >= filter.AnioCorrienteRealizado) && (filter.AnioCorrienteRealizado_To == null || o.AnioCorrienteRealizado <= filter.AnioCorrienteRealizado_To)
                                              && (filter.AnioCorrienteRealizadoIsNull == null || filter.AnioCorrienteRealizadoIsNull == true || o.AnioCorrienteRealizado != null) && (filter.AnioCorrienteRealizadoIsNull == null || filter.AnioCorrienteRealizadoIsNull == false || o.AnioCorrienteRealizado == null)

                                              && (filter.FechaInicioEjecucionCalculada == null || filter.FechaInicioEjecucionCalculada == DateTime.MinValue || o.FechaInicioEjecucionCalculada >= filter.FechaInicioEjecucionCalculada) && (filter.FechaInicioEjecucionCalculada_To == null || filter.FechaInicioEjecucionCalculada_To == DateTime.MinValue || o.FechaInicioEjecucionCalculada <= filter.FechaInicioEjecucionCalculada_To)
                                              && (filter.FechaInicioEjecucionCalculadaIsNull == null || filter.FechaInicioEjecucionCalculadaIsNull == true || o.FechaInicioEjecucionCalculada != null) && (filter.FechaInicioEjecucionCalculadaIsNull == null || filter.FechaInicioEjecucionCalculadaIsNull == false || o.FechaInicioEjecucionCalculada == null)
                                              && (filter.FechaFinEjecucionCalculada == null || filter.FechaFinEjecucionCalculada == DateTime.MinValue || o.FechaFinEjecucionCalculada >= filter.FechaFinEjecucionCalculada) && (filter.FechaFinEjecucionCalculada_To == null || filter.FechaFinEjecucionCalculada_To == DateTime.MinValue || o.FechaFinEjecucionCalculada <= filter.FechaFinEjecucionCalculada_To)
                                              && (filter.FechaFinEjecucionCalculadaIsNull == null || filter.FechaFinEjecucionCalculadaIsNull == true || o.FechaFinEjecucionCalculada != null) && (filter.FechaFinEjecucionCalculadaIsNull == null || filter.FechaFinEjecucionCalculadaIsNull == false || o.FechaFinEjecucionCalculada == null)
                                              && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >= filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
                                              && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >= filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
                                              && (filter.IdUsuarioModificacion == null || o.IdUsuarioModificacion >= filter.IdUsuarioModificacion) && (filter.IdUsuarioModificacion_To == null || o.IdUsuarioModificacion <= filter.IdUsuarioModificacion_To)

                                              && (filter.IdsEstado == null || filter.IdsEstado.Count == 0 || filter.IdsEstado.Contains(o.IdEstado))
                                              && (filter.Anio == null || filter.Anio == 0 ||

                                                (from pd in this.Context.ProyectoDictamens
                                                 join pds in this.Context.ProyectoDictamenSeguimientos on pd.IdProyectoDictamen equals pds.IdProyectoDictamen
                                                 join psp in this.Context.ProyectoSeguimientoProyectos on pds.IdProyectoSeguimiento equals psp.IdProyectoSeguimiento
                                                 join pde in this.Context.ProyectoDictamenEstados on pd.IdProyectoDictamenEstadoUltimo equals pde.IdProyectoDictamenEstado
                                                 where filter.Anio == pd.Fecha.Value.Year && (pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.Terminado || pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.EnEsperaRespuesta || pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.Migracion ) /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
                                                 select psp.IdProyecto).Contains(o.IdProyecto)
                                                 )

                                              && (filter.IdsCalificacionDictamen == null || filter.IdsCalificacionDictamen.Count == 0 ||

                                                        (from pd in this.Context.ProyectoDictamens
                                                         join pds in this.Context.ProyectoDictamenSeguimientos on pd.IdProyectoDictamen equals pds.IdProyectoDictamen
                                                         join psp in this.Context.ProyectoSeguimientoProyectos on pds.IdProyectoSeguimiento equals psp.IdProyectoSeguimiento
                                                         join pde in this.Context.ProyectoDictamenEstados on pd.IdProyectoDictamenEstadoUltimo equals pde.IdProyectoDictamenEstado
                                                         where filter.IdsCalificacionDictamen.Contains(pd.IdProyectoCalificacion.Value) && (pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.Terminado || pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.EnEsperaRespuesta || pde.IdEstado == (int)ProyectoDicatamenEstadoEnum.Migracion ) /*Estado utilizado unicamente para la migración inicial - Matias - DictamenMigracion - 20160930 */
                                                         select psp.IdProyecto).Contains(o.IdProyecto)
                                              )

                                              && (filter.IdSectorialista == null || filter.IdSectorialista == 0 || (from sp in this.Context.SubProgramas where (from pr in this.Context.Programas where pr.IdSectorialista == filter.IdSectorialista select pr.IdPrograma).Contains(sp.IdPrograma) select sp.IdSubPrograma).Contains(o.IdSubPrograma))

                                              && (filter.Activo == null || filter.Activo == o.Activo)
                                              && (filter.IdEstadoDeDesicion == null || filter.IdEstadoDeDesicion == 0 || o.IdEstadoDeDesicion == filter.IdEstadoDeDesicion)
                                              && (filter.EsPPP == null || o.EsPPP == filter.EsPPP)
                                              //&& (filter.NroActividad == null || o.NroActividad >= filter.NroActividad) && (filter.NroActividad_To == null || o.NroActividad <= filter.NroActividad_To)
                                              //&& (filter.NroObra == null || o.NroObra >= filter.NroObra) && (filter.NroObra_To == null || o.NroObra <= filter.NroObra_To)
                                              //&& (filter.NroProyectoEjecucion == null || o.NroProyectoEjecucion >= filter.NroProyectoEjecucion) && (filter.NroProyectoEjecucion_To == null || o.NroProyectoEjecucion <= filter.NroProyectoEjecucion_To)
                                              //&& (filter.NroActividadEjecucion == null || o.NroActividadEjecucion >= filter.NroActividadEjecucion) && (filter.NroActividadEjecucion_To == null || o.NroActividadEjecucion <= filter.NroActividadEjecucion_To)
                                              //&& (filter.NroObraEjecucion == null || o.NroObraEjecucion >= filter.NroObraEjecucion) && (filter.NroObraEjecucion_To == null || o.NroObraEjecucion <= filter.NroObraEjecucion_To)
                                              && (filter.IdEstadoDeDesicionIsNull == null || filter.IdEstadoDeDesicionIsNull == true || o.IdEstadoDeDesicion != null) && (filter.IdEstadoDeDesicionIsNull == null || filter.IdEstadoDeDesicionIsNull == false || o.IdEstadoDeDesicion == null)

                                              && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || (filter.IdSaf != null && filter.IdSaf != 0) || (from sp in this.Context.SubProgramas where (from p in this.Context.Programas where (from s in this.Context.Safs where s.IdJurisdiccion == filter.IdJurisdiccion select s.IdSaf).Contains(p.IdSAF) select p.IdPrograma).Contains(sp.IdPrograma) select sp.IdSubPrograma).Contains(o.IdSubPrograma))
                                              && (filter.IdSaf == null || filter.IdSaf == 0 || (filter.IdPrograma != null && filter.IdPrograma != 0) || (from sp in this.Context.SubProgramas where (from p in this.Context.Programas where p.IdSAF == filter.IdSaf select p.IdPrograma).Contains(sp.IdPrograma) select sp.IdSubPrograma).Contains(o.IdSubPrograma))
                                              && (filter.IdPrograma == null || filter.IdPrograma == 0 || (filter.IdSubPrograma != null && filter.IdSubPrograma != 0) || (from sp in this.Context.SubProgramas where sp.IdPrograma == filter.IdPrograma select sp.IdSubPrograma).Contains(o.IdSubPrograma))
                                              && (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || (from sp in this.Context.SubProgramas where sp.IdSubPrograma == filter.IdSubPrograma select sp.IdSubPrograma).Contains(o.IdSubPrograma))

                                              && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || filter.IncluirClasificacionGeoInteriores == true || (from pl in this.Context.ProyectoLocalizacions where pl.IdClasificacionGeografica == filter.IdClasificacionGeografica select pl.IdProyecto).Contains(o.IdProyecto))
                                              && (filter.IncluirClasificacionGeoInteriores == null || filter.IncluirClasificacionGeoInteriores == false || filter.IdClasificacionGeografica == null || strIdClasificacionGeografica == string.Empty
                                                 || (from pl in this.Context.ProyectoLocalizacions where (from cg in this.Context.ClasificacionGeograficas where cg.BreadcrumbId.Contains(strIdClasificacionGeografica) select cg.IdClasificacionGeografica).Contains(pl.IdClasificacionGeografica) select pl.IdProyecto).Contains(o.IdProyecto))

                                              && (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 ||
                                                   (
                                                       (
                                                           from pv in this.Context.PlanVersions
                                                           join pp in this.Context.ProyectoPlans on pv.IdPlanVersion equals pp.IdPlanVersion
                                                           where pv.IdPlanTipo == filter.IdPlanTipo
                                                           select pp.IdProyecto
                                                       ).Contains(o.IdProyecto)

                                                       && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || (

                                                           (
                                                               from pperiodo in this.Context.PlanPeriodos
                                                               join pp in this.Context.ProyectoPlans on pperiodo.IdPlanPeriodo equals pp.IdPlanPeriodo
                                                               where pperiodo.IdPlanTipo == filter.IdPlanTipo && pp.IdPlanPeriodo == filter.IdPlanPeriodo
                                                               select pp.IdProyecto
                                                           ).Contains(o.IdProyecto)
                                                           && (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || (
                                                                    from pv in this.Context.PlanVersions
                                                                    join pp in this.Context.ProyectoPlans on pv.IdPlanVersion equals pp.IdPlanVersion
                                                                    where pv.IdPlanTipo == filter.IdPlanTipo && pp.IdPlanPeriodo == filter.IdPlanPeriodo && pv.IdPlanVersion == filter.IdPlanVersion
                                                                    select pp.IdProyecto
                                                                    ).Contains(o.IdProyecto))
                                                           )
                                                           )

                                               ))

                                              && (filter.RequiereArt15 == null || filter.RequiereArt15 == false ||
                                                       (from proyectoPrioridad in this.Context.ProyectoPrioridads
                                                        where proyectoPrioridad.ReqArt15 == filter.RequiereArt15
                                                        select proyectoPrioridad.IdProyecto
                                                      ).Contains(o.IdProyecto))
                                              && (filter.CalidadPendiente == null || filter.CalidadPendiente == false ||
                                                      (from pc in this.Context.ProyectoCalidads where pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR") select pc.IdProyecto).Contains(o.IdProyecto))
                                              && (filter.RequiereDictamen == null || filter.RequiereDictamen == false ||
                                                      (from pc in this.Context.ProyectoCalidads where pc.ReqDictamen == filter.RequiereDictamen select pc.IdProyecto).Contains(o.IdProyecto))
                                          
                                             #region filtra los proyectos por las oficinas del usuario
                                             && (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 || filter.IdsOficinaPropiaByUsuario == null || filter.IdsOficinaPropiaByUsuario.Count == 0
                                                    || (from pop in this.Context.ProyectoOficinaPerfils where filter.IdsOficinaPropiaByUsuario.Contains(pop.IdOficina) select pop.IdProyecto).Contains(o.IdProyecto)
                                                    || (o.EsBorrador == false &&
                                                       (from pop in this.Context.ProyectoOficinaPerfils where filter.IdsOficinaByUsuario.Contains(pop.IdOficina) select pop.IdProyecto).Contains(o.IdProyecto)
                                                       )
                                                  )
                                             #endregion
                                             && (filter.IdOficina == null || filter.IdOficina == 0 || filter.IncluirOficinasInteriores == true ||
                                                      ((filter.IdRol == null || filter.IdRol == 0) &&
                                                       (from pop in this.Context.ProyectoOficinaPerfils where filter.IdOficina == pop.IdOficina select pop.IdProyecto).Contains(o.IdProyecto))
                                                       ||
                                                       (filter.IdRol != null && filter.IdRol != 0 &&
                                                       (from pop in this.Context.ProyectoOficinaPerfils where filter.IdOficina == pop.IdOficina && filter.IdRol == pop.IdPerfil select pop.IdProyecto).Contains(o.IdProyecto)))
                                             && (filter.IncluirOficinasInteriores == null || filter.IncluirOficinasInteriores == false || filter.IdOficina == null || strIdParent == string.Empty
                                                    ||
                                                    ((filter.IdRol == null || filter.IdRol == 0) &&
                                                    (from pop in this.Context.ProyectoOficinaPerfils join of in this.Context.Oficinas on pop.IdOficina equals of.IdOficina where of.BreadcrumbId.Contains(strIdParent) select pop.IdProyecto).Contains(o.IdProyecto))
                                                    ||
                                                    (filter.IdRol != null && filter.IdRol != 0 &&
                                                    (from pop in this.Context.ProyectoOficinaPerfils join of in this.Context.Oficinas on pop.IdOficina equals of.IdOficina where of.BreadcrumbId.Contains(strIdParent) && pop.IdPerfil == filter.IdRol select pop.IdProyecto).Contains(o.IdProyecto)))

                                             && (filter.IdProyectoSeguimiento == 0 || filter.IdProyectoSeguimiento == null ||
                                                (from psp in this.Context.ProyectoSeguimientoProyectos
                                                where psp.IdProyectoSeguimiento == filter.IdProyectoSeguimiento
                                                select psp.IdProyecto).Contains(o.IdProyecto))

                                             && (filter.IdPrioridad == null || filter.IdPrioridad == 0 ||
                                                    (from pp in this.Context.ProyectoPrioridads
                                                    where pp.IdPrioridad == filter.IdPrioridad
                                                    select pp.IdProyecto).Contains(o.IdProyecto)
                                                    )
                                             && (filter.Ids == null || filter.Ids.Count == 0 || filter.Ids.Contains(o.IdProyecto))

                                          #endregion
                                            
                                          )
                                          
                                          select o
                    ).AsQueryable();
            return query;
        }


        public ProyectoResult QueryResultIdProyecto(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         join t6 in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo
                         join t7 in this.Context.SubProgramas on o.IdSubPrograma equals t7.IdSubPrograma
                         join programa in this.Context.Programas on t7.IdPrograma equals programa.IdPrograma
                         join saf in this.Context.Safs on programa.IdSAF equals saf.IdSaf
                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto,
                             IdSAF = saf.IdSaf
                         }

                      ).FirstOrDefault();
            return query;
        }

        //Matias 20140512 - Tarea 133
        public IQueryable<ProyectoResult> QueryResultGraficos(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         join t1 in this.Context.Estados on o.IdEstado equals t1.IdEstado
                         //join _t2 in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals _t2.IdFinalidadFuncion into tt2
                         //from t2 in tt2.DefaultIfEmpty()
                         //join _t3  in this.Context.ModalidadContratacions on o.IdModalidadContratacion equals _t3.IdModalidadContratacion into tt3 from t3 in tt3.DefaultIfEmpty()
                         //join _t4 in this.Context.OrganismoPrioridads on o.IdOrganismoPrioridad equals _t4.IdOrganismoPrioridad into tt4
                         //from t4 in tt4.DefaultIfEmpty()
                         //join _t5 in this.Context.Procesos on o.IdProceso equals _t5.IdProceso into tt5
                         //from t5 in tt5.DefaultIfEmpty()
                         join _calidad in this.Context.ProyectoCalidads on o.IdProyecto equals _calidad.IdProyecto into calidad
                         from tcalidad in calidad.DefaultIfEmpty()
                         join t6 in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo
                         join t7 in this.Context.SubProgramas on o.IdSubPrograma equals t7.IdSubPrograma
                         join programa in this.Context.Programas on t7.IdPrograma equals programa.IdPrograma
                         join saf in this.Context.Safs on programa.IdSAF equals saf.IdSaf
                         join _sector in this.Context.Sectors on saf.IdSector equals _sector.IdSector into tsector
                         from sector in tsector.DefaultIfEmpty()
                         join _at in this.Context.AdministracionTipos on saf.IdAdministracionTipo equals _at.IdAdministracionTipo into tat
                         from at in tat.DefaultIfEmpty()
                         join _et in this.Context.EntidadTipos on saf.IdEntidadTipo equals _et.IdEntidadTipo into tet
                         from et in tet.DefaultIfEmpty()
                         join _t8 in this.Context.ProyectoPlans on o.IdProyectoPlan equals _t8.IdProyectoPlan into tt8
                         from t8 in tt8.DefaultIfEmpty()
                         join _t9 in this.Context.PlanPeriodos on t8.IdPlanPeriodo equals _t9.IdPlanPeriodo into tt9
                         from t9 in tt9.DefaultIfEmpty()
                         join _t10 in this.Context.PlanTipos on t9.IdPlanTipo equals _t10.IdPlanTipo into tt10
                         from t10 in tt10.DefaultIfEmpty()
                         join _t11 in this.Context.PlanVersions on t8.IdPlanVersion equals _t11.IdPlanVersion into tt11
                         from t11 in tt11.DefaultIfEmpty()
                         //join _ed in this.Context.EstadoDeDesicions on o.IdEstadoDeDesicion equals _ed.IdEstadoDeDesicion into ted
                         //from ed in ted.DefaultIfEmpty()

                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto
                             ,
                             IdTipoProyecto = o.IdTipoProyecto
                             ,
                             IdSubPrograma = o.IdSubPrograma
                             ,
                             Codigo = o.Codigo
                             ,
                             ProyectoDenominacion = o.ProyectoDenominacion
                             ,
                             ProyectoSituacionActual = o.ProyectoSituacionActual
                             ,
                             ProyectoDescripcion = o.ProyectoDescripcion
                             ,
                             ProyectoObservacion = o.ProyectoObservacion
                             ,
                             IdEstado = o.IdEstado
                             ,
                             IdProceso = o.IdProceso
                             ,
                             IdModalidadContratacion = o.IdModalidadContratacion
                             ,
                             IdFinalidadFuncion = o.IdFinalidadFuncion
                             ,
                             IdOrganismoPrioridad = o.IdOrganismoPrioridad
                             ,
                             SubPrioridad = o.SubPrioridad
                             ,
                             EsBorrador = o.EsBorrador
                             ,
                             EsProyecto = o.EsProyecto
                             ,
                             NroProyecto = o.NroProyecto
                             ,
                             AnioCorriente = o.AnioCorriente
                             ,
                             AnioCorrienteEstimado = o.AnioCorrienteEstimado
                             ,
                             AnioCorrienteRealizado = o.AnioCorrienteRealizado
                             ,
                             FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                             ,
                             FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                             ,
                             FechaAlta = o.FechaAlta
                             ,
                             FechaModificacion = o.FechaModificacion
                             ,
                             IdUsuarioModificacion = o.IdUsuarioModificacion
                             ,
                             IdProyectoPlan = o.IdProyectoPlan
                             ,
                             IdEstadoDeDesicion = o.IdEstadoDeDesicion
                             ,
                             Estado_Nombre = t1.Nombre
                                 //,FinalidadFuncion_Denominacion = t2 != null ? (string)t2.Denominacion : null
                                 //,FinalidadFuncion_BreadcrumbCode = t2 != null ? (string)t2.BreadcrumbCode : null
                                 //,FinalidadFuncion_DescripcionInvertida = t2 != null ? (string)t2.DescripcionInvertida : null
                                 //,EstadoDeDesicion_Nombre = ed != null ? (string)ed.Nombre : null
                                 //,EstadoDeDesicion_Codigo = ed != null ? (string)ed.Codigo : null
                             ,
                             EvaluarValidaciones = o.EvaluarValidaciones
                                 //#region Old
                                 //    //,Estado_Codigo= t1.Codigo	
                                 //    //,Estado_Orden= t1.Orden	
                                 //    //,Estado_Descripcion= t1.Descripcion	
                                 //    //,Estado_Activo= t1.Activo	
                                 //    //,FinalidadFuncion_Codigo= t2!=null?(string)t2.Codigo:null	

                             ////,FinalidadFuncion_Activo= t2!=null?(bool?)t2.Activo:null	
                                 //    //,FinalidadFuncion_IdFinalidadFunciontipo= t2!=null?(int?)t2.IdFinalidadFunciontipo:null	
                                 //    //,FinalidadFuncion_IdFinalidadFuncionPadre= t2!=null?(int?)t2.IdFinalidadFuncionPadre:null	
                                 //    //,ModalidadContratacion_Nombre= t3!=null?(string)t3.Nombre:null	
                                 //    //,ModalidadContratacion_Activo= t3!=null?(bool?)t3.Activo:null	
                                 //    //,OrganismoPrioridad_Nombre= t4!=null?(string)t4.Nombre:null	
                                 //    //,OrganismoPrioridad_Activo= t4!=null?(bool?)t4.Activo:null	
                                 //    //,TipoProyecto_Sigla= t6.Sigla	
                                 //    //,TipoProyecto_Activo= t6.Activo	
                                 //    //,TipoProyecto_Tipo= t6.Tipo
                                 //    //,SubPrograma_IdPrograma= t7.IdPrograma	
                                 //    //,SubPrograma_FechaAlta= t7.FechaAlta	
                                 //    //,SubPrograma_FechaBaja= t7.FechaBaja	
                                 //    //,SubPrograma_Activo= t7.Activo	
                                 //    //,Programa_IdSectorialista = programa.IdSectioralista
                                 //    //,IdPrioridad = 
                                 //    //,Apertura= t10!=null?(string)t10.Sigla+"-"+t9.Nombre+"-"+t11.Nombre:null
                                 //#endregion
                                 //,Proceso_IdProyectoTipo = t5 != null ? (int?)t5.IdProyectoTipo : null
                                 //,Proceso_Nombre = t5 != null ? (string)t5.Nombre : null
                                 //,Proceso_Activo = t5 != null ? (bool?)t5.Activo : null
                             ,
                             TipoProyecto_Nombre = t6.Nombre
                             ,
                             SubPrograma_Codigo = t7.Codigo
                                 //,SubPrograma_Nombre = t7.Nombre
                             ,
                             IdSAF = saf.IdSaf
                             ,
                             IdPrograma = programa.IdPrograma
                             ,
                             Programa_Codigo = programa.Codigo
                             ,
                             Programa_Nombre = programa.Nombre
                             ,
                             Saf_Nombre = saf.Denominacion
                             ,
                             Saf_Codigo = saf.Codigo
                             ,
                             Jurisdiccion_Codigo = saf.Jurisdiccion.Codigo
                             ,
                             Jurisdiccion_Nombre = saf.Jurisdiccion.Nombre
                             ,
                             RequiereDictamen = tcalidad != null ? tcalidad.ReqDictamen : false
                             ,
                             Plan_Ultimo = t10 != null ? (string)t10.Sigla + "-" + t9.Nombre + "-" + t11.Nombre : null
                             ,
                             Apertura = (from ap in
                                             (
                                              from pe in this.Context.ProyectoEtapas
                                              join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                              join f in this.Context.Fases on e.IdFase equals f.IdFase
                                              where pe.IdProyecto == o.IdProyecto
                                              select new
                                              {
                                                  IdProyecto = pe.IdProyecto
                                              ,
                                                  Actividad = e.Codigo == "AC" && pe.NroEtapa.HasValue ? pe.NroEtapa.Value : 0
                                              ,
                                                  Obra = e.Codigo == "OB" && pe.NroEtapa.HasValue ? pe.NroEtapa.Value : 0
                                              }
                                              )
                                         group ap by ap.IdProyecto into g
                                         select o.NroProyecto.ToString().PadLeft(2, '0') + "."
                                             + g.Max(p => p.Actividad).ToString().PadLeft(2, '0') + "."
                                             + g.Max(p => p.Obra).ToString().PadLeft(2, '0')
                                        ).FirstOrDefault()
                                 //((from pe in this.Context.ProyectoEtapas
                                 //       join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                 //       join f in this.Context.Fases on e.IdFase equals f.IdFase
                                 //       where pe.IdProyecto == o.IdProyecto
                                 //       && f.Codigo == ((int)FaseEnum.Ejecucion).ToString()
                                 //       select e.Codigo).Count() > 0 
                                 //?                            
                                 //   (o.NroProyecto.HasValue ? o.NroProyecto.Value.ToString().PadLeft(2,'0') : "00") + "." +
                                 //   (
                                 //       from pe in this.Context.ProyectoEtapas
                                 //       join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                 //       join f in this.Context.Fases on e.IdFase equals f.IdFase
                                 //       where pe.IdProyecto == o.IdProyecto
                                 //       && f.Codigo == ((int)FaseEnum.Ejecucion).ToString()
                                 //       orderby pe.IdProyectoEtapa
                                 //       select e.Codigo == "OB" ? "00" + "." + (pe.NroEtapa.HasValue ? pe.NroEtapa.Value.ToString().PadLeft(2, '0') : "00") : e.Codigo == "AC" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString().PadLeft(2, '0') : "00") + "." + "00" : ""
                                 //   ).FirstOrDefault() 
                                 //: (o.NroProyecto.HasValue ? o.NroProyecto.Value.ToString().PadLeft(2, '0') : "00") + "." + "00.00")
                             ,
                             Activo = o.Activo
                             ,
                             Saf_SectorNombre = sector != null ? sector.Nombre : ""
                             ,
                             Saf_AdministracionTipoNombre = at != null ? at.Nombre : ""
                             ,
                             Saf_EntidadTipoNombre = et != null ? et.Nombre : ""
                             ,
                             Color = o.EsBorrador ? (System.Drawing.Color.Red) :
                                               (from pc in this.Context.ProyectoCalidads
                                                where pc.IdProyecto == o.IdProyecto
                                                && pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR)

                                                select pc.IdProyecto).Count() != 0 ? (System.Drawing.Color.Blue) : (System.Drawing.Color.Black)
                             ,
                             CalidadACorregir =
                                               (from pc in this.Context.ProyectoCalidads
                                                where pc.IdProyecto == o.IdProyecto
                                                && pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR)
                                                select pc.IdProyecto).Count() != 0
                                 //Aca se modifica el Color!
                                 //http://devnet.asna.com/documentation/Help_Files/AVR72/AVR72_web/avrlrfSettingColors.htm
                                 //Matias 20140512 - Tarea 133
                             ,
                             Localizacion = (from pl in this.Context.ProyectoLocalizacions
                                             join e in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals e.IdClasificacionGeografica

                                             where pl.IdProyecto == o.IdProyecto
                                             select e.Descripcion).Count() == 0 ? "Sin Localizacion" : (from pl in this.Context.ProyectoLocalizacions
                                                                                                        join e in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals e.IdClasificacionGeografica

                                                                                                        where pl.IdProyecto == o.IdProyecto
                                                                                                        select e.Descripcion).FirstOrDefault()
                             ,
                             Proceso = (from pl in this.Context.Procesos
                                        where pl.IdProceso == Convert.ToInt32(o.IdProceso)
                                        select pl.Nombre).Count() == 0 ? "Sin Proceso" : (from pl in this.Context.Procesos
                                                                                          where pl.IdProceso == Convert.ToInt32(o.IdProceso)
                                                                                          select pl.Nombre).FirstOrDefault()
                            ,
                             FinalidadFuncion = (from pl in this.Context.FinalidadFuncions
                                                 where pl.IdFinalidadFuncion == Convert.ToInt32(o.IdFinalidadFuncion)
                                                 select pl.Descripcion).Count() == 0 ? "Sin Finalidad" : (from pl in this.Context.FinalidadFuncions
                                                                                                          where pl.IdFinalidadFuncion == Convert.ToInt32(o.IdFinalidadFuncion)
                                                                                                          select pl.Descripcion).FirstOrDefault()
                             ,
                             ModalidadContratacion = (from pl in this.Context.ModalidadContratacions
                                                      where pl.IdModalidadContratacion == Convert.ToInt32(o.IdModalidadContratacion)
                                                      select pl.Nombre).Count() == 0 ? "Sin Modalidad Contratacion" : (from pl in this.Context.ModalidadContratacions
                                                                                                                       where pl.IdModalidadContratacion == Convert.ToInt32(o.IdModalidadContratacion)
                                                                                                                       select pl.Nombre).FirstOrDefault()
                                 /*,Plan = (from pv in this.Context.PlanVersions
                                                                join pp in this.Context.ProyectoPlans on pv.IdPlanVersion equals pp.IdPlanVersion
                                                                where pv.IdPlanTipo == filter.IdPlanTipo && pp.IdProyecto == o.IdProyecto
                                                                select pv.Nombre).Count() == 0 ? "Sin Plan" : 
                                                                         (from pv in this.Context.PlanVersions
                                                                join pp in this.Context.ProyectoPlans on pv.IdPlanVersion equals pp.IdPlanVersion
                                                                where pv.IdPlanTipo == filter.IdPlanTipo && pp.IdProyecto == o.IdProyecto
                                                                select pv.Nombre).FirstOrDefault()*/
                            ,
                             Plan = t10 != null ? (string)t10.Sigla + "-" + t9.Nombre + "-" + t11.Nombre : "Sin Plan"
                             //FinMatias 20140512 - Tarea 133
                         }

                      ).AsQueryable();
            return query;
        }

        public IQueryable<ProyectoResult> QueryResultGraficosLocalizacion(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         from pl in this.Context.ProyectoLocalizacions
                         join e in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals e.IdClasificacionGeografica
                         where pl.IdProyecto == o.IdProyecto

                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto
                             ,
                             Localizacion = e.Descripcion.Replace("Buenos Aires", "Bs.As.")
                         }

                      ).AsQueryable();
            return query;
        }

        public IQueryable<ProyectoResult> QueryResultGraficosLocalizacionPartido(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         from pl in this.Context.ProyectoLocalizacions
                         join e in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals e.IdClasificacionGeografica
                         where pl.IdProyecto == o.IdProyecto

                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto
                             ,
                             Localizacion = (e.IdClasificacionGeograficaTipo == 3 ? (e.Descripcion.Substring(0, e.Descripcion.LastIndexOf('/') - 1)).Replace("Buenos Aires", "Bs.As.") : e.Descripcion.Replace("Buenos Aires", "Bs.As."))
                             //Localizacion = (Convert.ToInt32(e.IdClasificacionGeograficaTipo) == 3 ? e.Descripcion : e.Descripcion)
                         }

                      ).AsQueryable();
            return query;
        }

        public IQueryable<ProyectoResult> QueryResultGraficosPrestamos(ProyectoFilter filter)
        {
            //Nuevo query modificado por Matias - 20140506
            /*
            var queryOrigenFinanciamiento = (from o in Query(filter)
                                             from pl in this.Context.ProyectoOrigenFinanciamientos
                                             join e in this.Context.FuenteFinanciamientos on pl.IdFuenteFinanciamiento equals e.IdFuenteFinanciamiento
                                             where pl.IdProyecto == o.IdProyecto

                                             select new ProyectoResult()
                                             {
                                                 IdProyecto = o.IdProyecto
                                                 ,
                                                 Prestamo = e.Descripcion
                                             }

                      ).AsQueryable();

            */
            var queryEstimados = (from o in Query(filter)
                                  from pe in this.Context.ProyectoEtapas
                                  join pl in this.Context.ProyectoEtapaEstimados on pe.IdProyectoEtapa equals pl.IdProyectoEtapa
                                  join e in this.Context.FuenteFinanciamientos on pl.IdFuenteFinanciamiento equals e.IdFuenteFinanciamiento
                                  where pe.IdProyecto == o.IdProyecto

                                  select new ProyectoResult()
                                  {
                                      IdProyecto = o.IdProyecto,
                                      Prestamo = e.Descripcion
                                  }

                      ).AsQueryable();

            var queryRealizados = (from o in Query(filter)
                                   from pe in this.Context.ProyectoEtapas
                                   join per in this.Context.ProyectoEtapaRealizados on pe.IdProyectoEtapa equals per.IdProyectoEtapa
                                   join e in this.Context.FuenteFinanciamientos on per.IdFuenteFinanciamiento equals e.IdFuenteFinanciamiento
                                   where pe.IdProyecto == o.IdProyecto

                                   select new ProyectoResult()
                                   {
                                       IdProyecto = o.IdProyecto,
                                       Prestamo = e.Descripcion
                                   }

                      ).AsQueryable();

            queryEstimados.Union(queryRealizados);

            return queryEstimados;
        }
        //FinMatias 20140512 - Tarea 133

        //Matias 20141014 - Tarea 158
        public IQueryable<ProyectoResult> QueryResultGraficosProvincia(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         from pl in this.Context.ProyectoLocalizacions
                         join e in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals e.IdClasificacionGeografica
                         where pl.IdProyecto == o.IdProyecto

                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto
                             ,
                             //Localizacion = e.Descripcion.Substring(0, e.Descripcion.IndexOf('/') - 1)
                             Localizacion = (e.IdClasificacionGeograficaTipo == 1 ? (e.Descripcion) : (e.Descripcion.Substring(0, e.Descripcion.IndexOf('/') - 1)))

                             //Localizacion = (e.IdClasificacionGeograficaTipo == 1 ? (e.Descripcion.Substring(0, e.Descripcion.LastIndexOf('/') - 1)) : e.Descripcion)
                             //Localizacion = (Convert.ToInt32(e.IdClasificacionGeograficaTipo) == 3 ? e.Descripcion : e.Descripcion)
                         }

                      ).AsQueryable();
            return query;
        }
        //FinMatias 20141014 - Tarea 158


        protected override IQueryable<ProyectoResult> QueryResult(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         join t1 in this.Context.Estados on o.IdEstado equals t1.IdEstado
                         //join _t2 in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals _t2.IdFinalidadFuncion into tt2
                         //from t2 in tt2.DefaultIfEmpty()
                         //join _t3  in this.Context.ModalidadContratacions on o.IdModalidadContratacion equals _t3.IdModalidadContratacion into tt3 from t3 in tt3.DefaultIfEmpty()
                         /*Matias 20170302 - Ticket #REQ792885*/
                         join _t4 in this.Context.OrganismoPrioridads on o.IdOrganismoPrioridad equals _t4.IdOrganismoPrioridad into tt4
                         from t4 in tt4.DefaultIfEmpty()
                         /*Matias 20170302 - Ticket #REQ792885*/
                         join _t5 in this.Context.Procesos on o.IdProceso equals _t5.IdProceso into tt5 //Matias 20170125 - Ticket TP y Pr
                         //join t5 in this.Context.Procesos on o.IdProceso equals t5.IdProceso //Matias 20170125 - Ticket TP y Pr
                         from t5 in tt5.DefaultIfEmpty() //Matias 20170125 - Ticket TP y Pr
                         join _calidad in this.Context.ProyectoCalidads on o.IdProyecto equals _calidad.IdProyecto into calidad
                         from tcalidad in calidad.DefaultIfEmpty()
                         join t6 in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo
                         join t7 in this.Context.SubProgramas on o.IdSubPrograma equals t7.IdSubPrograma
                         join programa in this.Context.Programas on t7.IdPrograma equals programa.IdPrograma
                         join saf in this.Context.Safs on programa.IdSAF equals saf.IdSaf
                         join _sector in this.Context.Sectors on saf.IdSector equals _sector.IdSector into tsector
                         from sector in tsector.DefaultIfEmpty()
                         join _at in this.Context.AdministracionTipos on saf.IdAdministracionTipo equals _at.IdAdministracionTipo into tat
                         from at in tat.DefaultIfEmpty()
                         /*Matias 20170302 - Ticket #REQ792885*/
                         join _mc in this.Context.ModalidadContratacions on o.IdModalidadContratacion equals _mc.IdModalidadContratacion into tmc
                         from mc in tmc.DefaultIfEmpty()
                         join _ff in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals _ff.IdFinalidadFuncion into tff
                         from ff in tff.DefaultIfEmpty()
                         /*FinMatias 20170302 - Ticket #REQ792885*/
                         join _et in this.Context.EntidadTipos on saf.IdEntidadTipo equals _et.IdEntidadTipo into tet
                         from et in tet.DefaultIfEmpty()
                         join _t8 in this.Context.ProyectoPlans on o.IdProyectoPlan equals _t8.IdProyectoPlan into tt8
                         from t8 in tt8.DefaultIfEmpty()
                         join _t9 in this.Context.PlanPeriodos on t8.IdPlanPeriodo equals _t9.IdPlanPeriodo into tt9
                         from t9 in tt9.DefaultIfEmpty()
                         join _t10 in this.Context.PlanTipos on t9.IdPlanTipo equals _t10.IdPlanTipo into tt10
                         from t10 in tt10.DefaultIfEmpty()
                         join _t11 in this.Context.PlanVersions on t8.IdPlanVersion equals _t11.IdPlanVersion into tt11
                         from t11 in tt11.DefaultIfEmpty()
                         //join _ed in this.Context.EstadoDeDesicions on o.IdEstadoDeDesicion equals _ed.IdEstadoDeDesicion into ted
                         //from ed in ted.DefaultIfEmpty()


                         select new ProyectoResult()
                         {
                             IdProyecto = o.IdProyecto
                             ,
                             IdTipoProyecto = o.IdTipoProyecto
                             ,
                             IdSubPrograma = o.IdSubPrograma
                             ,
                             Codigo = o.Codigo
                             ,
                             ProyectoDenominacion = o.ProyectoDenominacion
                             ,
                             ProyectoSituacionActual = o.ProyectoSituacionActual
                             ,
                             ProyectoDescripcion = o.ProyectoDescripcion
                             ,
                             ProyectoObservacion = o.ProyectoObservacion
                             ,
                             IdEstado = o.IdEstado
                             ,
                             IdProceso = o.IdProceso
                             ,
                             IdModalidadContratacion = o.IdModalidadContratacion
                             ,
                             ModalidadContratacion_Nombre = mc != null ? (string) mc.Nombre : null /*Matias 20170302 - Ticket #REQ792885*/
                             ,
                             IdFinalidadFuncion = o.IdFinalidadFuncion
                             ,
                             FinalidadFuncion_BreadcrumbCode = ff != null ? (string)ff.BreadcrumbCode : null /*Matias 20170302 - Ticket #REQ792885*/
                             ,
                             FinalidadFuncion_DescripcionInvertida = ff != null ? (string)ff.DescripcionInvertida : null /*Matias 20170302 - Ticket #REQ792885*/
                             ,
                             IdOrganismoPrioridad = o.IdOrganismoPrioridad
                             ,
                             OrganismoPrioridad_Nombre = t4 != null ? (string)t4.Nombre : null /*Matias 20170302 - Ticket #REQ792885*/
                             ,
                             SubPrioridad = o.SubPrioridad
                             ,
                             EsBorrador = o.EsBorrador
                             ,
                             EsProyecto = o.EsProyecto
                             ,
                             NroProyecto = o.NroProyecto
                             ,
                             AnioCorriente = o.AnioCorriente
                             ,
                             AnioCorrienteEstimado = o.AnioCorrienteEstimado
                             ,
                             AnioCorrienteRealizado = o.AnioCorrienteRealizado
                             ,
                             FechaInicioEjecucionCalculada = o.FechaInicioEjecucionCalculada
                             ,
                             FechaFinEjecucionCalculada = o.FechaFinEjecucionCalculada
                             ,
                             FechaAlta = o.FechaAlta
                             ,
                             FechaModificacion = o.FechaModificacion
                             ,
                             IdUsuarioModificacion = o.IdUsuarioModificacion
                             ,
                             IdProyectoPlan = o.IdProyectoPlan
                             ,
                             IdEstadoDeDesicion = o.IdEstadoDeDesicion
                             ,
                             EsPPP = o.EsPPP
                             ,
                             NroActividad = o.NroActividad
                             ,
                             NroObra = o.NroObra
                             ,
                             NroProyectoEjecucion = o.NroProyectoEjecucion
                             ,
                             NroActividadEjecucion = o.NroActividadEjecucion
                             ,
                             NroObraEjecucion = o.NroObraEjecucion
                             ,
                             Estado_Nombre = t1.Nombre
                                 //,FinalidadFuncion_Denominacion = t2 != null ? (string)t2.Denominacion : null
                                 //,FinalidadFuncion_BreadcrumbCode = t2 != null ? (string)t2.BreadcrumbCode : null
                                 //,FinalidadFuncion_DescripcionInvertida = t2 != null ? (string)t2.DescripcionInvertida : null
                                 //,EstadoDeDesicion_Nombre = ed != null ? (string)ed.Nombre : null
                                 //,EstadoDeDesicion_Codigo = ed != null ? (string)ed.Codigo : null
                             ,
                             EvaluarValidaciones = o.EvaluarValidaciones
                                 //#region Old
                                 //    //,Estado_Codigo= t1.Codigo	
                                 //    //,Estado_Orden= t1.Orden	
                                 //    //,Estado_Descripcion= t1.Descripcion	
                                 //    //,Estado_Activo= t1.Activo	
                                 //    //,FinalidadFuncion_Codigo= t2!=null?(string)t2.Codigo:null	

                             ////,FinalidadFuncion_Activo= t2!=null?(bool?)t2.Activo:null	
                                 //    //,FinalidadFuncion_IdFinalidadFunciontipo= t2!=null?(int?)t2.IdFinalidadFunciontipo:null	
                                 //    //,FinalidadFuncion_IdFinalidadFuncionPadre= t2!=null?(int?)t2.IdFinalidadFuncionPadre:null	
                                 //    //,ModalidadContratacion_Nombre= t3!=null?(string)t3.Nombre:null	
                                 //    //,ModalidadContratacion_Activo= t3!=null?(bool?)t3.Activo:null	
                                 //    //,OrganismoPrioridad_Nombre= t4!=null?(string)t4.Nombre:null	
                                 //    //,OrganismoPrioridad_Activo= t4!=null?(bool?)t4.Activo:null	
                                 //    //,TipoProyecto_Sigla= t6.Sigla	
                                 //    //,TipoProyecto_Activo= t6.Activo	
                                 //    //,TipoProyecto_Tipo= t6.Tipo
                                 //    //,SubPrograma_IdPrograma= t7.IdPrograma	
                                 //    //,SubPrograma_FechaAlta= t7.FechaAlta	
                                 //    //,SubPrograma_FechaBaja= t7.FechaBaja	
                                 //    //,SubPrograma_Activo= t7.Activo	
                                 //    //,Programa_IdSectorialista = programa.IdSectioralista
                                 //    //,IdPrioridad = 
                                 //    //,Apertura= t10!=null?(string)t10.Sigla+"-"+t9.Nombre+"-"+t11.Nombre:null
                                 //#endregion
                                 //,Proceso_IdProyectoTipo = t5 != null ? (int?)t5.IdProyectoTipo : null
                                 //,Proceso_Nombre = t5 != null ? (string)t5.Nombre : null
                                 //,Proceso_Activo = t5 != null ? (bool?)t5.Activo : null

                             ,
                             Proceso_Nombre = t5 != null ? (string)t5.Nombre : null
                             ,
                             TipoProyecto_Nombre = t6.Nombre
                             ,
                             SubPrograma_Codigo = t7.Codigo
                             ,
                             SubPrograma_Nombre = t7.Nombre /*Matias 20170302 - Ticket #REQ792885*/
                             ,
                             IdSAF = saf.IdSaf
                             ,
                             IdPrograma = programa.IdPrograma
                             ,
                             Programa_Codigo = programa.Codigo
                             ,
                             Programa_Nombre = programa.Nombre
                             ,
                             Saf_Nombre = saf.Denominacion
                             ,
                             Saf_Codigo = saf.Codigo
                             ,
                             Jurisdiccion_Codigo = saf.Jurisdiccion.Codigo
                             ,
                             Jurisdiccion_Nombre = saf.Jurisdiccion.Nombre
                             ,
                             RequiereDictamen = tcalidad != null ? tcalidad.ReqDictamen : false
                             ,
                             Plan_Ultimo = t10 != null ? (string)t10.Sigla + "-" + t9.Nombre + "-" + t11.Nombre : null
                             ,
                             Apertura = (from ap in
                                             (
                                              from pe in this.Context.ProyectoEtapas
                                              join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                              join f in this.Context.Fases on e.IdFase equals f.IdFase
                                              where pe.IdProyecto == o.IdProyecto
                                              select new
                                              {
                                                  IdProyecto = pe.IdProyecto
                                              ,
                                                  Actividad = e.Codigo == "AC" && pe.NroEtapa.HasValue ? pe.NroEtapa.Value : 0
                                              ,
                                                  Obra = e.Codigo == "OB" && pe.NroEtapa.HasValue ? pe.NroEtapa.Value : 0
                                              }
                                              )
                                         group ap by ap.IdProyecto into g
                                         select o.NroProyecto.ToString().PadLeft(2, '0') + "."
                                             + g.Max(p => p.Actividad).ToString().PadLeft(2, '0') + "."
                                             + g.Max(p => p.Obra).ToString().PadLeft(2, '0')
                                        ).FirstOrDefault()
                                 //((from pe in this.Context.ProyectoEtapas
                                 //       join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                 //       join f in this.Context.Fases on e.IdFase equals f.IdFase
                                 //       where pe.IdProyecto == o.IdProyecto
                                 //       && f.Codigo == ((int)FaseEnum.Ejecucion).ToString()
                                 //       select e.Codigo).Count() > 0 
                                 //?                            
                                 //   (o.NroProyecto.HasValue ? o.NroProyecto.Value.ToString().PadLeft(2,'0') : "00") + "." +
                                 //   (
                                 //       from pe in this.Context.ProyectoEtapas
                                 //       join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                 //       join f in this.Context.Fases on e.IdFase equals f.IdFase
                                 //       where pe.IdProyecto == o.IdProyecto
                                 //       && f.Codigo == ((int)FaseEnum.Ejecucion).ToString()
                                 //       orderby pe.IdProyectoEtapa
                                 //       select e.Codigo == "OB" ? "00" + "." + (pe.NroEtapa.HasValue ? pe.NroEtapa.Value.ToString().PadLeft(2, '0') : "00") : e.Codigo == "AC" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString().PadLeft(2, '0') : "00") + "." + "00" : ""
                                 //   ).FirstOrDefault() 
                                 //: (o.NroProyecto.HasValue ? o.NroProyecto.Value.ToString().PadLeft(2, '0') : "00") + "." + "00.00")
                             ,
                             Activo = o.Activo
                             ,
                             Saf_SectorNombre = sector != null ? sector.Nombre : ""
                             ,
                             Saf_AdministracionTipoNombre = at != null ? at.Nombre : ""
                             ,
                             Saf_EntidadTipoNombre = et != null ? et.Nombre : ""
                             ,
                             Color = o.EsBorrador ? (System.Drawing.Color.Red) :
                                               (from pc in this.Context.ProyectoCalidads
                                                where pc.IdProyecto == o.IdProyecto
                                                && pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR)

                                                select pc.IdProyecto).Count() != 0 ? (System.Drawing.Color.Blue) : (System.Drawing.Color.Black)
                             ,
                             CalidadACorregir =
                                               (from pc in this.Context.ProyectoCalidads
                                                where pc.IdProyecto == o.IdProyecto
                                                && pc.IdEstado == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROYECTOCALIDAD_ESTADO_PARACONTROLAR)
                                                select pc.IdProyecto).Count() != 0
                             //Aca se modifica el Color!
                             //http://devnet.asna.com/documentation/Help_Files/AVR72/AVR72_web/avrlrfSettingColors.htm
                         }

                      ).AsQueryable();
            return query;
        }
        #region Reportes
        private IQueryable<ProyectoReportResult> GetReportBase(ProyectoFilter filter)
        {
            var query = (from o in Query(filter)
                         join t1 in this.Context.Estados on o.IdEstado equals t1.IdEstado
                         //join t6  in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo   
                         join _t8 in this.Context.ProyectoPlans on o.IdProyectoPlan equals _t8.IdProyectoPlan into tt8
                         from t8 in tt8.DefaultIfEmpty()
                         join _t9 in this.Context.PlanPeriodos on t8.IdPlanPeriodo equals _t9.IdPlanPeriodo into tt9
                         from t9 in tt9.DefaultIfEmpty()
                         join _t10 in this.Context.PlanTipos on t9.IdPlanTipo equals _t10.IdPlanTipo into tt10
                         from t10 in tt10.DefaultIfEmpty()
                         join _t11 in this.Context.PlanVersions on t8.IdPlanVersion equals _t11.IdPlanVersion into tt11
                         from t11 in tt11.DefaultIfEmpty()
                         join _pe in
                             (
                                from pe in this.Context.ProyectoEtapas
                                join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                select new
                                {
                                    IdProyecto = pe.IdProyecto
                                    ,
                                    IdEtapa = e.IdEtapa
                                    ,
                                    Codigo = e.Codigo
                                    ,
                                    NroEtapa = pe.NroEtapa
                                }
                             ) on o.IdProyecto equals _pe.IdProyecto into tpe
                         from pe in tpe.DefaultIfEmpty()

                         group pe by new
                         {
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
                             Estado_Nombre = t1.Nombre
                             ,
                             IdTipoProyecto = o.IdTipoProyecto
                             ,
                             IdProceso = o.IdProceso
                             ,
                             Plan_Nombre = (t10 != null ? (string)t10.Sigla : null) + "-" + (t9 != null ? (string)t9.Sigla : null) + "-" + (t11 != null ? (string)t11.Nombre : null)
                             //,NroEtapa = pe.NroEtapa 
                         } into groupQuery
                         select new ProyectoReportResult()
                         {
                             IdProyecto = groupQuery.Key.IdProyecto
                             ,
                             IdSubPrograma = groupQuery.Key.IdSubPrograma
                             ,
                             IdFinalidadFuncion = groupQuery.Key.IdFinalidadFuncion
                             ,
                             Codigo = groupQuery.Key.Codigo
                             ,
                             ProyectoDenominacion = groupQuery.Key.ProyectoDenominacion
                             ,
                             IdEstado = groupQuery.Key.IdEstado
                             ,
                             NroProyecto = groupQuery.Key.NroProyecto
                             ,
                             FechaInicioEjecucionCalculada = groupQuery.Key.FechaInicioEjecucionCalculada
                             ,
                             FechaFinEjecucionCalculada = groupQuery.Key.FechaFinEjecucionCalculada
                             ,
                             Estado_Nombre = groupQuery.Key.Estado_Nombre
                             ,
                             Plan_Nombre = groupQuery.Key.Plan_Nombre
                             ,
                             NroProyectoPresupuestario = groupQuery.Key.NroProyecto
                                 //,NroBienUso = e != null ? (e.Codigo == "AC" ? pe.NroEtapa : null) : null
                                 //,NroObra = e != null ? (e.Codigo == "OB" ? pe.NroEtapa : null) : null
                             ,
                             NroBienUso = (from gq in groupQuery where gq.Codigo == "AC" select gq.NroEtapa).FirstOrDefault()
                             ,
                             NroObra = (from gq in groupQuery where gq.Codigo == "OB" select gq.NroEtapa).FirstOrDefault()
                             ,
                             IdTipoProyecto = groupQuery.Key.IdTipoProyecto
                             ,
                             IdProceso = groupQuery.Key.IdProceso
                         }
                  ).AsQueryable();
            return query;
        }

        //Matias 20131107 - Tarea 72
        public List<ProyectoReportEstimadoRealizado> GetTotalizado(ProyectoReportFilter filter)
        {
            var query = (from t in
                             ((
                              from o in this.Context.ProyectoEtapas
                              join pee in this.Context.ProyectoEtapaEstimados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                              join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado
                              join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                              where filter.IdFase == null || filter.IdFase == 0 || filter.IdFase == e.IdFase
                              group peep by new { Id = o.IdProyecto, Tipo = "E" } into groupQuery
                              select new ProyectoReportEstimadoRealizado
                              {

                                  SaldoPrevioEstimado = groupQuery.Where(i => i.Periodo < filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDelAnioEstimado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDelAnioSiguienteEstimado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDosAniosFuturosEstimado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoAniosFuturosEstimado = groupQuery.Where(i => i.Periodo > filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoPrevioRealizado = 0
                                  ,
                                  SaldoDelAnioRealizado = 0
                                  ,
                                  SaldoDelAnioSiguienteRealizado = 0
                                  ,
                                  SaldoDosAniosFuturosRealizado = 0
                                  ,
                                  SaldoAniosFuturosRealizado = 0
                                  ,
                                  IdProyecto = groupQuery.Key.Id
                                  ,
                                  Tipo = groupQuery.Key.Tipo
                              }
                                 ).Union(
                              from o in this.Context.ProyectoEtapas
                              join pee in this.Context.ProyectoEtapaRealizados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                              join peep in this.Context.ProyectoEtapaRealizadoPeriodos on pee.IdProyectoEtapaRealizado equals peep.IdProyectoEtapaRealizado
                              join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                              where filter.IdFase == null || filter.IdFase == 0 || filter.IdFase == e.IdFase
                              group peep by new { Id = o.IdProyecto, Tipo = "R" } into groupQuery
                              select new ProyectoReportEstimadoRealizado
                              {

                                  SaldoPrevioRealizado = groupQuery.Where(i => i.Periodo < filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDelAnioRealizado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDelAnioSiguienteRealizado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoDosAniosFuturosRealizado = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoAniosFuturosRealizado = groupQuery.Where(i => i.Periodo > filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                  ,
                                  SaldoPrevioEstimado = 0
                                  ,
                                  SaldoDelAnioEstimado = 0
                                  ,
                                  SaldoDelAnioSiguienteEstimado = 0
                                  ,
                                  SaldoDosAniosFuturosEstimado = 0
                                  ,
                                  SaldoAniosFuturosEstimado = 0
                                  ,
                                  IdProyecto = groupQuery.Key.Id
                                  ,
                                  Tipo = groupQuery.Key.Tipo
                              }))

                         group t by new { Id = t.IdProyecto } into groupQuery
                         select new ProyectoReportEstimadoRealizado
                         {
                             SaldoPrevioRealizado = groupQuery.Sum(t => t.SaldoPrevioRealizado),
                             SaldoDelAnioRealizado = groupQuery.Sum(t => t.SaldoDelAnioRealizado),
                             SaldoDelAnioSiguienteRealizado = groupQuery.Sum(t => t.SaldoDelAnioSiguienteRealizado),
                             SaldoDosAniosFuturosRealizado = groupQuery.Sum(t => t.SaldoDosAniosFuturosRealizado),
                             SaldoAniosFuturosRealizado = groupQuery.Sum(t => t.SaldoAniosFuturosRealizado),
                             SaldoPrevioEstimado = groupQuery.Sum(t => t.SaldoPrevioEstimado),
                             SaldoDelAnioEstimado = groupQuery.Sum(t => t.SaldoDelAnioEstimado),
                             SaldoDelAnioSiguienteEstimado = groupQuery.Sum(t => t.SaldoDelAnioSiguienteEstimado),
                             SaldoDosAniosFuturosEstimado = groupQuery.Sum(t => t.SaldoDosAniosFuturosEstimado),
                             SaldoAniosFuturosEstimado = groupQuery.Sum(t => t.SaldoAniosFuturosEstimado),
                             IdProyecto = groupQuery.Key.Id,
                             Tipo = "E" //fruta por ahora
                         }

                             ).AsQueryable();
            return query.ToList();
        }
        //FinMatias 20131107 - Tarea 72

        public List<ProyectoReportEstimadoRealizado> GetEstimado(ProyectoReportFilter filter)
        {
            return (from o in this.Context.ProyectoEtapas
                    join pee in this.Context.ProyectoEtapaEstimados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                    join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado
                    join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                    where filter.IdFase == null || filter.IdFase == 0 || filter.IdFase == e.IdFase
                    group peep by new { Id = o.IdProyecto, Tipo = "E" } into groupQuery

                    select new ProyectoReportEstimadoRealizado
                    {
                        Periodo = filter.AnioInicialCronograma,
                        SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000,
                        SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000,
                        IdProyecto = groupQuery.Key.Id,
                        Tipo = groupQuery.Key.Tipo

                    }).ToList();
        }
        public List<ProyectoReportEstimadoRealizado> GetRealizado(ProyectoReportFilter filter)
        {
            return (from o in this.Context.ProyectoEtapas
                    join pee in this.Context.ProyectoEtapaRealizados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                    join peep in this.Context.ProyectoEtapaRealizadoPeriodos on pee.IdProyectoEtapaRealizado equals peep.IdProyectoEtapaRealizado
                    join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                    where filter.IdFase == null || filter.IdFase == 0 || filter.IdFase == e.IdFase
                    group peep by new { Id = o.IdProyecto, Tipo = "R" } into groupQuery

                    select new ProyectoReportEstimadoRealizado
                    {
                        Periodo = filter.AnioInicialCronograma,
                        SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000,
                        SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000,
                        SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000,
                        IdProyecto = groupQuery.Key.Id,
                        Tipo = groupQuery.Key.Tipo

                    }).ToList();
        }
        public List<ProyectoReportJurisdiccionResult> GetReportJurisdiccion(ProyectoFilter filter)
        {
            var query = (from o in GetReportBase(filter)
                         join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                         join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                         join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                         join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                         from j in tj.DefaultIfEmpty()
                         select new ProyectoReportJurisdiccionResult()
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
,
                             SubPrograma_Codigo = sp.Codigo
                             ,
                             SubPrograma_Nombre = sp.Nombre
                             ,
                             IdPrograma = p.IdPrograma
                             ,
                             Programa_Codigo = p.Codigo
                             ,
                             Programa_Nombre = p.Nombre
                             ,
                             IdSaf = p.IdSAF
                             ,
                             Saf_Codigo = s.Codigo
                             ,
                             Saf_Denominacion = s.Denominacion
                             ,
                             IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                             ,
                             Jurisdiccion_Codigo = j != null ? j.Codigo : null
                             ,
                             Jurisdiccion_Nombre = j != null ? j.Nombre : null
                         }
                 ).OrderBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).ToList();
            return query.ToList();
        }
        //Matias 20131107 - Tarea 72
        public List<ProyectoReportFuenteFinanciamientoResult> GetReportFuenteFinanciamientoPorTipo(ProyectoFilter filter)
        {
            return (from o in GetReportBase(filter)
                    join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                    join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                    join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                    join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                    from j in tj.DefaultIfEmpty()
                    join mee in
                        (
                             from t in
                                 ((
                                     from pe in this.Context.ProyectoEtapas
                                     join pee in this.Context.ProyectoEtapaEstimados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                                     join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado
                                     join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                     join ff in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento
                                     where filter.reportFilter.IdFase == null || filter.reportFilter.IdFase == 0 || filter.reportFilter.IdFase == e.IdFase
                                     group peep by new { Id = pe.IdProyecto, Fuente_ID = pee.IdFuenteFinanciamiento, Fuente_Codigo = ff.BreadcrumbCode, Fuente_Nombre = ff.Descripcion, Tipo = "E" } into groupQuery
                                     select new ProyectoReportFuenteEstimadoRealizado
                                     {

                                         SaldoPrevioEstimado = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                         ,
                                         SaldoDelAnioEstimado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                         ,
                                         SaldoDelAnioSiguienteEstimado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                         ,
                                         SaldoDosAniosFuturosEstimado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                         ,
                                         SaldoAniosFuturosEstimado = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                         ,
                                         SaldoPrevioRealizado = 0
                                         ,
                                         SaldoDelAnioRealizado = 0
                                         ,
                                         SaldoDelAnioSiguienteRealizado = 0
                                         ,
                                         SaldoDosAniosFuturosRealizado = 0
                                         ,
                                         SaldoAniosFuturosRealizado = 0
                                         ,
                                         IdProyecto = groupQuery.Key.Id
                                         ,
                                         Fuente_Id = groupQuery.Key.Fuente_ID
                                         ,
                                         Fuente_Codigo = groupQuery.Key.Fuente_Codigo
                                         ,
                                         Fuente_Nombre = groupQuery.Key.Fuente_Nombre
                                         ,
                                         Tipo = groupQuery.Key.Tipo
                                     }
                                     ).Union(
                                  from pe in this.Context.ProyectoEtapas
                                  join pee in this.Context.ProyectoEtapaRealizados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                                  join peep in this.Context.ProyectoEtapaRealizadoPeriodos on pee.IdProyectoEtapaRealizado equals peep.IdProyectoEtapaRealizado
                                  join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                  join ff in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento
                                  where filter.reportFilter.IdFase == null || filter.reportFilter.IdFase == 0 || filter.reportFilter.IdFase == e.IdFase
                                  group peep by new { Id = pe.IdProyecto, Fuente_ID = pee.IdFuenteFinanciamiento, Fuente_Codigo = ff.BreadcrumbCode, Fuente_Nombre = ff.Descripcion, Tipo = "R" } into groupQuery
                                  select new ProyectoReportFuenteEstimadoRealizado
                                  {

                                      SaldoPrevioRealizado = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                      ,
                                      SaldoDelAnioRealizado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                      ,
                                      SaldoDelAnioSiguienteRealizado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                      ,
                                      SaldoDosAniosFuturosRealizado = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                      ,
                                      SaldoAniosFuturosRealizado = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                      ,
                                      SaldoPrevioEstimado = 0
                                      ,
                                      SaldoDelAnioEstimado = 0
                                      ,
                                      SaldoDelAnioSiguienteEstimado = 0
                                      ,
                                      SaldoDosAniosFuturosEstimado = 0
                                      ,
                                      SaldoAniosFuturosEstimado = 0
                                      ,
                                      IdProyecto = groupQuery.Key.Id
                                      ,
                                      Fuente_Id = groupQuery.Key.Fuente_ID
                                      ,
                                      Fuente_Codigo = groupQuery.Key.Fuente_Codigo
                                      ,
                                      Fuente_Nombre = groupQuery.Key.Fuente_Nombre
                                      ,
                                      Tipo = groupQuery.Key.Tipo
                                  }))

                             group t by new { Id = t.IdProyecto, Fuente_ID = t.Fuente_Id, Fuente_Codigo = t.Fuente_Codigo, Fuente_Nombre = t.Fuente_Nombre } into groupQuery
                             select new ProyectoReportFuenteEstimadoRealizado
                             {
                                 SaldoPrevioRealizado = groupQuery.Sum(t => t.SaldoPrevioRealizado),
                                 SaldoDelAnioRealizado = groupQuery.Sum(t => t.SaldoDelAnioRealizado),
                                 SaldoDelAnioSiguienteRealizado = groupQuery.Sum(t => t.SaldoDelAnioSiguienteRealizado),
                                 SaldoDosAniosFuturosRealizado = groupQuery.Sum(t => t.SaldoDosAniosFuturosRealizado),
                                 SaldoAniosFuturosRealizado = groupQuery.Sum(t => t.SaldoAniosFuturosRealizado),
                                 SaldoPrevioEstimado = groupQuery.Sum(t => t.SaldoPrevioEstimado),
                                 SaldoDelAnioEstimado = groupQuery.Sum(t => t.SaldoDelAnioEstimado),
                                 SaldoDelAnioSiguienteEstimado = groupQuery.Sum(t => t.SaldoDelAnioSiguienteEstimado),
                                 SaldoDosAniosFuturosEstimado = groupQuery.Sum(t => t.SaldoDosAniosFuturosEstimado),
                                 SaldoAniosFuturosEstimado = groupQuery.Sum(t => t.SaldoAniosFuturosEstimado),
                                 IdProyecto = groupQuery.Key.Id,
                                 Fuente_Id = groupQuery.Key.Fuente_ID,
                                 Fuente_Codigo = groupQuery.Key.Fuente_Codigo,
                                 Fuente_Nombre = groupQuery.Key.Fuente_Nombre,
                                 Tipo = "A" // "A" ==> Ambos - estimados & realizados.
                             }
                                    )


                             on o.IdProyecto equals mee.IdProyecto
                    /*where (filter.reportFilter.SoloEstimados == true && mee.Tipo == "E") ||
                          (filter.reportFilter.SoloEstimados == false && mee.Tipo == "R") ||
                          (filter.reportFilter.SoloEstimados == null)*/

                    select new ProyectoReportFuenteFinanciamientoResult()
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
                        ,
                        SubPrograma_Codigo = sp.Codigo
                        ,
                        SubPrograma_Nombre = sp.Nombre
                        ,
                        IdPrograma = p.IdPrograma
                        ,
                        Programa_Codigo = p.Codigo
                        ,
                        Programa_Nombre = p.Nombre
                        ,
                        IdSaf = p.IdSAF
                        ,
                        Saf_Codigo = s.Codigo
                        ,
                        Saf_Denominacion = s.Denominacion
                        ,
                        IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                        ,
                        Jurisdiccion_Codigo = j != null ? j.Codigo : null
                        ,
                        Jurisdiccion_Nombre = j != null ? j.Nombre : null
                        ,
                        SaldoPrevioEstimado = mee == null ? 1 : mee.SaldoPrevioEstimado == null ? 0 : mee.SaldoPrevioEstimado
                        ,
                        SaldoDelAnioEstimado = mee == null ? 1 : mee.SaldoDelAnioEstimado == null ? 0 : mee.SaldoDelAnioEstimado
                        ,
                        SaldoDelAnioSiguienteEstimado = mee == null ? 0 : mee.SaldoDelAnioSiguienteEstimado == null ? 0 : mee.SaldoDelAnioSiguienteEstimado
                        ,
                        SaldoDosAniosFuturosEstimado = mee == null ? 0 : mee.SaldoDosAniosFuturosEstimado == null ? 0 : mee.SaldoDosAniosFuturosEstimado
                        ,
                        SaldoAniosFuturosEstimado = mee == null ? 0 : mee.SaldoAniosFuturosEstimado == null ? 0 : mee.SaldoDosAniosFuturosEstimado
                        ,
                        SaldoPrevioRealizado = mee == null ? 0 : mee.SaldoPrevioRealizado == null ? 0 : mee.SaldoPrevioRealizado
                        ,
                        SaldoDelAnioRealizado = mee == null ? 0 : mee.SaldoDelAnioRealizado == null ? 0 : mee.SaldoDelAnioRealizado
                        ,
                        SaldoDelAnioSiguienteRealizado = mee == null ? 0 : mee.SaldoDelAnioSiguienteRealizado == null ? 0 : mee.SaldoDelAnioSiguienteRealizado
                        ,
                        SaldoDosAniosFuturosRealizado = mee == null ? 0 : mee.SaldoDosAniosFuturosRealizado == null ? 0 : mee.SaldoDosAniosFuturosRealizado
                        ,
                        SaldoAniosFuturosRealizado = mee == null ? 0 : mee.SaldoAniosFuturosRealizado == null ? 0 : mee.SaldoAniosFuturosRealizado
                        ,
                        Tipo = mee == null ? String.Empty : mee.Tipo
                        ,
                        Fuente_Id = mee.Fuente_Id
                        ,
                        Fuente_Codigo = mee == null ? String.Empty : mee.Fuente_Codigo
                        ,
                        Fuente_Nombre = mee == null ? String.Empty : mee.Fuente_Nombre
                        #endregion
                    }
                 ).OrderBy(i => i.Fuente_Codigo).ThenBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).ToList();
        }
        //FinMatias 20131107 - Tarea 72
        public List<ProyectoReportFuenteFinanciamientoResult> GetReportFuenteFinanciamiento(ProyectoFilter filter)
        {
            return (from o in GetReportBase(filter)
                    join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                    join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                    join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                    join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                    from j in tj.DefaultIfEmpty()
                    join mee in
                        (
                            from pe in this.Context.ProyectoEtapas
                            join pee in this.Context.ProyectoEtapaEstimados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                            join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado
                            join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                            join ff in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento
                            where filter.reportFilter.IdFase == null || filter.reportFilter.IdFase == 0 || filter.reportFilter.IdFase == e.IdFase
                            group peep by new { Id = pe.IdProyecto, Fuente_ID = pee.IdFuenteFinanciamiento, Fuente_Codigo = ff.BreadcrumbCode, Fuente_Nombre = ff.Descripcion, Tipo = "E" } into groupQuery
                            select new ProyectoReportFuenteEstimadoRealizado
                            {
                                //Matias 20131104 - Tarea 38
                                /*
                                SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.Monto) / 1000
                                ,SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.Monto) / 1000
                                ,SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.Monto) / 1000
                                ,SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.Monto) / 1000
                                ,SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.Monto) / 1000
                                 */
                                SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                ,
                                SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                ,
                                SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                ,
                                SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                ,
                                SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                    //FinMatias 20131104 - Tarea 38
                                ,
                                IdProyecto = groupQuery.Key.Id
                                ,
                                Fuente_Id = groupQuery.Key.Fuente_ID
                                ,
                                Fuente_Codigo = groupQuery.Key.Fuente_Codigo
                                ,
                                Fuente_Nombre = groupQuery.Key.Fuente_Nombre
                                ,
                                Tipo = groupQuery.Key.Tipo
                            }
                            ).Union(
                                from pe in this.Context.ProyectoEtapas
                                join pee in this.Context.ProyectoEtapaRealizados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                                join peep in this.Context.ProyectoEtapaRealizadoPeriodos on pee.IdProyectoEtapaRealizado equals peep.IdProyectoEtapaRealizado
                                join e in this.Context.Etapas on pe.IdEtapa equals e.IdEtapa
                                join ff in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento
                                where filter.reportFilter.IdFase == null || filter.reportFilter.IdFase == 0 || filter.reportFilter.IdFase == e.IdFase
                                group peep by new { Id = pe.IdProyecto, Fuente_ID = pee.IdFuenteFinanciamiento, Fuente_Codigo = ff.BreadcrumbCode, Fuente_Nombre = ff.Descripcion, Tipo = "R" } into groupQuery
                                select new ProyectoReportFuenteEstimadoRealizado
                                {
                                    //Matias 20131104 - Tarea 38
                                    /*
                                    SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.Monto) / 1000
                                    ,SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.Monto) / 1000
                                    ,SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.Monto) / 1000
                                    ,SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.Monto) / 1000
                                    ,SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.Monto) / 1000
                                     */
                                    SaldoPrevio = groupQuery.Where(i => i.Periodo < filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                    ,
                                    SaldoDelAnio = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma).Sum(i => i.MontoCalculado) / 1000
                                    ,
                                    SaldoDelAnioSiguiente = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 1).Sum(i => i.MontoCalculado) / 1000
                                    ,
                                    SaldoDosAniosFuturos = groupQuery.Where(i => i.Periodo == filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                    ,
                                    SaldoAniosFuturos = groupQuery.Where(i => i.Periodo > filter.reportFilter.AnioInicialCronograma + 2).Sum(i => i.MontoCalculado) / 1000
                                        //FinMatias 20131104 - Tarea 38
                                    ,
                                    IdProyecto = groupQuery.Key.Id
                                    ,
                                    Fuente_Id = groupQuery.Key.Fuente_ID
                                    ,
                                    Fuente_Codigo = groupQuery.Key.Fuente_Codigo
                                    ,
                                    Fuente_Nombre = groupQuery.Key.Fuente_Nombre
                                    ,
                                    Tipo = groupQuery.Key.Tipo
                                })
                             on o.IdProyecto equals mee.IdProyecto
                    where (filter.reportFilter.SoloEstimados == true && mee.Tipo == "E") ||
                          (filter.reportFilter.SoloEstimados == false && mee.Tipo == "R") ||
                          (filter.reportFilter.SoloEstimados == null)

                    select new ProyectoReportFuenteFinanciamientoResult()
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
,
                        SubPrograma_Codigo = sp.Codigo
                        ,
                        SubPrograma_Nombre = sp.Nombre
                        ,
                        IdPrograma = p.IdPrograma
                        ,
                        Programa_Codigo = p.Codigo
                        ,
                        Programa_Nombre = p.Nombre
                        ,
                        IdSaf = p.IdSAF
                        ,
                        Saf_Codigo = s.Codigo
                        ,
                        Saf_Denominacion = s.Denominacion
                        ,
                        IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                        ,
                        Jurisdiccion_Codigo = j != null ? j.Codigo : null
                        ,
                        Jurisdiccion_Nombre = j != null ? j.Nombre : null
                        ,
                        SaldoPrevio = mee == null ? 0 : mee.SaldoPrevio
                        ,
                        SaldoDelAnio = mee == null ? 0 : mee.SaldoDelAnio
                        ,
                        SaldoDelAnioSiguiente = mee == null ? 0 : mee.SaldoDelAnioSiguiente
                        ,
                        SaldoDosAniosFuturos = mee == null ? 0 : mee.SaldoDosAniosFuturos
                        ,
                        SaldoAniosFuturos = mee == null ? 0 : mee.SaldoAniosFuturos
                        ,
                        Tipo = mee == null ? String.Empty : mee.Tipo
                        ,
                        Fuente_Id = mee.Fuente_Id
                        ,
                        Fuente_Codigo = mee == null ? String.Empty : mee.Fuente_Codigo
                        ,
                        Fuente_Nombre = mee == null ? String.Empty : mee.Fuente_Nombre
                    }
                 ).OrderBy(i => i.Fuente_Codigo).ThenBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).ToList();
        }
        public List<ProyectoReportFinalidadFuncionResult> GetReportFinalidadFuncion(ProyectoFilter filter)
        {
            var query = (from o in GetReportBase(filter)
                         join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                         join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                         join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                         join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                         from j in tj.DefaultIfEmpty()
                         join ff in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals ff.IdFinalidadFuncion
                         select new ProyectoReportFinalidadFuncionResult()
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
,
                             SubPrograma_Codigo = sp.Codigo
                             ,
                             SubPrograma_Nombre = sp.Nombre
                             ,
                             IdPrograma = p.IdPrograma
                             ,
                             Programa_Codigo = p.Codigo
                             ,
                             Programa_Nombre = p.Nombre
                             ,
                             IdSaf = p.IdSAF
                             ,
                             Saf_Codigo = s.Codigo
                             ,
                             Saf_Denominacion = s.Denominacion
                             ,
                             IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                             ,
                             Jurisdiccion_Codigo = j != null ? j.Codigo : null
                             ,
                             Jurisdiccion_Nombre = j != null ? j.Nombre : null
                             ,
                             FinalidadFuncion_Denominacion = ff.Denominacion
                             ,
                             FinalidadFuncion_Codigo = ff.BreadcrumbCode
                         }
                 ).OrderBy(i => i.FinalidadFuncion_Codigo).ThenBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).ToList();

            return query.ToList();
        }
        public List<ProyectoReportTipoProyectoResult> GetReportTipoProyecto(ProyectoFilter filter)
        {
            var query = (from o in GetReportBase(filter)
                         join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                         join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                         join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                         join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                         from j in tj.DefaultIfEmpty()
                         join t6 in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo
                         join proceso in this.Context.Procesos on o.IdProceso equals proceso.IdProceso into tproceso
                         from proceso in tproceso.DefaultIfEmpty()
                         select new ProyectoReportTipoProyectoResult()
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
,
                             SubPrograma_Codigo = sp.Codigo
                             ,
                             SubPrograma_Nombre = sp.Nombre
                             ,
                             IdPrograma = p.IdPrograma
                             ,
                             Programa_Codigo = p.Codigo
                             ,
                             Programa_Nombre = p.Nombre
                             ,
                             IdSaf = p.IdSAF
                             ,
                             Saf_Codigo = s.Codigo
                             ,
                             Saf_Denominacion = s.Denominacion
                             ,
                             IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                             ,
                             Jurisdiccion_Codigo = j != null ? j.Codigo : null
                             ,
                             Jurisdiccion_Nombre = j != null ? j.Nombre : null
                             ,
                             TipoProyecto_Nombre = t6.Nombre
                             ,
                             IdTipoProyecto = t6.IdProyectoTipo
                             ,
                             Proceso_Nombre = proceso != null ? proceso.Nombre : null
                         }
                  ).OrderBy(i => i.TipoProyecto_Nombre).ThenBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).ToList();
            return query.ToList();
        }
        public List<ProyectoReportProvinciaResult> GetReportProvincia(ProyectoFilter filter)
        {
            var query = (from o in GetReportBase(filter)
                         join sp in this.Context.SubProgramas on o.IdSubPrograma equals sp.IdSubPrograma
                         join p in this.Context.Programas on sp.IdPrograma equals p.IdPrograma
                         join s in this.Context.Safs on p.IdSAF equals s.IdSaf
                         join _j in this.Context.Jurisdiccions on s.IdJurisdiccion equals _j.IdJurisdiccion into tj
                         from j in tj.DefaultIfEmpty()
                         join pl in this.Context.ProyectoLocalizacions on o.IdProyecto equals pl.IdProyecto
                         join cg in this.Context.ClasificacionGeograficas on pl.IdClasificacionGeografica equals cg.IdClasificacionGeografica
                         select new ProyectoReportProvinciaResult()
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
,
                             SubPrograma_Codigo = sp.Codigo
                             ,
                             SubPrograma_Nombre = sp.Nombre
                             ,
                             IdPrograma = p.IdPrograma
                             ,
                             Programa_Codigo = p.Codigo
                             ,
                             Programa_Nombre = p.Nombre
                             ,
                             IdSaf = p.IdSAF
                             ,
                             Saf_Codigo = s.Codigo
                             ,
                             Saf_Denominacion = s.Denominacion
                             ,
                             IdJurisdiccion = j != null ? s.IdJurisdiccion : null
                             ,
                             Jurisdiccion_Codigo = j != null ? j.Codigo : null
                             ,
                             Jurisdiccion_Nombre = j != null ? j.Nombre : null
                             ,
                             IdProvincia = cg.IdClasificacionGeografica
                             ,
                             Provincia_Codigo = cg.BreadcrumbCode
                             ,
                             Provincia_Denominacion = cg.Descripcion
                         }
                 ).OrderBy(i => i.Provincia_Codigo).ThenBy(i => i.Jurisdiccion_Codigo).ThenBy(i => i.Saf_Codigo).ThenBy(i => i.Programa_Codigo).ThenBy(i => i.SubPrograma_Codigo).ThenBy(i => i.Codigo).AsQueryable();

            return query.ToList();
        }
        public List<ProyectoReportResult> GetReport(ProyectoFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.Estados on o.IdEstado equals t1.IdEstado
                    join t6 in this.Context.ProyectoTipos on o.IdTipoProyecto equals t6.IdProyectoTipo
                    join _t8 in this.Context.ProyectoPlans on o.IdProyectoPlan equals _t8.IdProyectoPlan into tt8
                    from t8 in tt8.DefaultIfEmpty()
                    join _t9 in this.Context.PlanPeriodos on t8.IdPlanPeriodo equals _t9.IdPlanPeriodo into tt9
                    from t9 in tt9.DefaultIfEmpty()
                    join _t10 in this.Context.PlanTipos on t9.IdPlanTipo equals _t10.IdPlanTipo into tt10
                    from t10 in tt10.DefaultIfEmpty()
                    select new ProyectoReportResult()
                    {
                        IdProyecto = o.IdProyecto
                        ,
                        IdSubPrograma = o.IdSubPrograma
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
                        Estado_Nombre = t1.Nombre
                        ,
                        Plan_Nombre = t10 != null ? (string)t10.Nombre : null
                    }
                    ).ToList();


        }

        private enum EstimadoRealizado
        {
            Estimado = 1
           , Realizado = 2
        }
        public List<ProyectoCronogramaReportResult> GetCronograma(ProyectoFilter filter)
        {
            var query = (

                from o in
                    (
                     from o in this.Context.Proyectos
                     join pe in this.Context.ProyectoEtapas on o.IdProyecto equals pe.IdProyecto
                     join et in this.Context.Etapas on pe.IdEtapa equals et.IdEtapa
                     join fa in this.Context.Fases on et.IdFase equals fa.IdFase
                     join pee in this.Context.ProyectoEtapaEstimados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa //into tpee from pee in tpee.DefaultIfEmpty()
                     join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado //into tpeep from peep in tpeep.DefaultIfEmpty()
                     join _cg in this.Context.ClasificacionGastos on pee.IdClasificacionGasto equals _cg.IdClasificacionGasto into tcg
                     from cg in tcg.DefaultIfEmpty()
                     join _ffe in this.Context.FuenteFinanciamientos on pee.IdFuenteFinanciamiento equals _ffe.IdFuenteFinanciamiento into tffe
                     from ffe in tffe.DefaultIfEmpty()
                     join _e in this.Context.Estados on pe.IdEstado equals _e.IdEstado into te
                     from e in te.DefaultIfEmpty()
                     where (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == o.IdProyecto)
                     && (peep == null || (peep != null && peep.Periodo != null))
                     select new ProyectoCronogramaReportResult()
                     {
                         IdProyectoEtapa = pe.IdProyectoEtapa
                         ,
                         Nombre = pe != null ? pe.Nombre : String.Empty
                         ,
                         FechaInicioEstimada = pe != null ? pe.FechaInicioEstimada : null
                         ,
                         FechaFinEstimada = pe != null ? pe.FechaFinEstimada : null
                         ,
                         FechaInicioRealizada = pe != null ? pe.FechaInicioRealizada : null
                         ,
                         FechaFinRealizada = pe != null ? pe.FechaFinRealizada : null
                         ,
                         Estado_Nombre = e != null ? e.Nombre : String.Empty
                         ,
                         Estimado = peep != null ? peep.MontoCalculado : 0
                         ,
                         Realizado = 0
                             //Daniela, modifique el codigo x el codigo completo
                         ,
                         ClasificacionGasto_Codigo = cg != null ? cg.BreadcrumbCode : String.Empty
                         ,
                         ClasificacionGasto_Nombre = cg != null ? cg.Nombre : String.Empty
                             //Daniela, modifique el codigo x el codigo completo
                         ,
                         FuenteFinanciamiento_Codigo = ffe != null ? ffe.BreadcrumbCode : String.Empty
                         ,
                         FuenteFinanciamiento_Nombre = ffe != null ? ffe.Nombre : String.Empty
                         ,
                         Periodo = peep.Periodo
                         ,
                         Obra = et.Codigo == "OB" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00"
                         ,
                         Actividad = et.Codigo == "AC" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00"
                         ,
                         Proyecto_Nro = o.NroProyecto.HasValue ? o.NroProyecto.ToString() : "00"
                         ,
                         IdFase = et.IdFase
                         ,
                         Fase_Nombre = fa.Nombre
                         ,
                         Fase_Orden = fa.Orden
                         ,
                         Etapa_Orden = et.Orden
                         ,
                         AnioCorriente = o.AnioCorriente
                             ,
                         AnioCorrienteEstimado = o.AnioCorrienteEstimado
                             ,
                         AnioCorrienteRealizado = o.AnioCorrienteRealizado
                     }
                 ).Union
                 (
                     from o in this.Context.Proyectos
                     join pe in this.Context.ProyectoEtapas on o.IdProyecto equals pe.IdProyecto
                     join et in this.Context.Etapas on pe.IdEtapa equals et.IdEtapa
                     join fa in this.Context.Fases on et.IdFase equals fa.IdFase
                     join per in this.Context.ProyectoEtapaRealizados on pe.IdProyectoEtapa equals per.IdProyectoEtapa
                     join perp in this.Context.ProyectoEtapaRealizadoPeriodos on per.IdProyectoEtapaRealizado equals perp.IdProyectoEtapaRealizado
                     join _cg in this.Context.ClasificacionGastos on per.IdClasificacionGasto equals _cg.IdClasificacionGasto into tcg
                     from cg in tcg.DefaultIfEmpty()
                     join _ffe in this.Context.FuenteFinanciamientos on per.IdFuenteFinanciamiento equals _ffe.IdFuenteFinanciamiento into tffe
                     from ffe in tffe.DefaultIfEmpty()
                     join _e in this.Context.Estados on pe.IdEstado equals _e.IdEstado into te
                     from e in te.DefaultIfEmpty()
                     where (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == o.IdProyecto)
                     && (perp == null || (perp != null && perp.Periodo != null))
                     select new ProyectoCronogramaReportResult()
                     {
                         IdProyectoEtapa = pe.IdProyectoEtapa
                         ,
                         Nombre = pe != null ? pe.Nombre : String.Empty
                         ,
                         FechaInicioEstimada = pe != null ? pe.FechaInicioEstimada : null
                         ,
                         FechaFinEstimada = pe != null ? pe.FechaFinEstimada : null
                         ,
                         FechaInicioRealizada = pe != null ? pe.FechaInicioRealizada : null
                         ,
                         FechaFinRealizada = pe != null ? pe.FechaFinRealizada : null
                         ,
                         Estado_Nombre = e != null ? e.Nombre : String.Empty
                         ,
                         Estimado = 0
                         ,
                         Realizado = perp != null ? perp.MontoCalculado : 0
                             //Daniela, modifique el codigo x el codigo completo
                         ,
                         ClasificacionGasto_Codigo = cg != null ? cg.BreadcrumbCode : String.Empty
                         ,
                         ClasificacionGasto_Nombre = cg != null ? cg.Nombre : String.Empty
                             //Daniela, modifique el codigo x el codigo completo
                         ,
                         FuenteFinanciamiento_Codigo = ffe != null ? ffe.BreadcrumbCode : String.Empty
                         ,
                         FuenteFinanciamiento_Nombre = ffe != null ? ffe.Nombre : String.Empty
                         ,
                         Periodo = perp.Periodo
                         ,
                         Obra = et.Codigo == "OB" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00"
                         ,
                         Actividad = et.Codigo == "AC" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00"
                         ,
                         Proyecto_Nro = o.NroProyecto.HasValue ? o.NroProyecto.Value.ToString() : "00"
                         ,
                         IdFase = et.IdFase
                         ,
                         Fase_Nombre = fa.Nombre
                         ,
                         Fase_Orden = fa.Orden
                         ,
                         Etapa_Orden = et.Orden
                         ,
                         AnioCorriente = o.AnioCorriente
                             ,
                         AnioCorrienteEstimado = o.AnioCorrienteEstimado
                             ,
                         AnioCorrienteRealizado = o.AnioCorrienteRealizado
                     }
                 )
                group o by new
                {
                    IdProyectoEtapa = o.IdProyectoEtapa
                    ,
                    Nombre = o.Nombre
                    ,
                    FechaInicioEstimada = o.FechaInicioEstimada
                    ,
                    FechaFinEstimada = o.FechaFinEstimada
                    ,
                    FechaInicioRealizada = o.FechaInicioRealizada
                    ,
                    FechaFinRealizada = o.FechaFinRealizada
                    ,
                    Estado_Nombre = o.Estado_Nombre
                    ,
                    ClasificacionGasto_Codigo = o.ClasificacionGasto_Codigo
                    ,
                    ClasificacionGasto_Nombre = o.ClasificacionGasto_Nombre
                    ,
                    FuenteFinanciamiento_Codigo = o.FuenteFinanciamiento_Codigo
                    ,
                    FuenteFinanciamiento_Nombre = o.FuenteFinanciamiento_Nombre
                    ,
                    Periodo = o.Periodo
                    ,
                    Obra = o.Obra
                    ,
                    Actividad = o.Actividad
                    ,
                    Proyecto_Nro = o.Proyecto_Nro
                    ,
                    IdFase = o.IdFase
                    ,
                    Fase_Nombre = o.Fase_Nombre
                    ,
                    Fase_Orden = o.Etapa_Orden
                    ,
                    Etapa_Orden = o.Etapa_Orden
                    ,
                    AnioCorriente = o.AnioCorriente
                             ,
                    AnioCorrienteEstimado = o.AnioCorrienteEstimado
                             ,
                    AnioCorrienteRealizado = o.AnioCorrienteRealizado
                } into groupQuery
                orderby groupQuery.Key.Fase_Orden, groupQuery.Key.Periodo, groupQuery.Key.Etapa_Orden, groupQuery.Key.IdProyectoEtapa, groupQuery.Key.ClasificacionGasto_Codigo, groupQuery.Key.FuenteFinanciamiento_Codigo
                select new ProyectoCronogramaReportResult()
                {
                    IdProyectoEtapa = groupQuery.Key.IdProyectoEtapa
                    ,
                    Nombre = groupQuery.Key.Nombre
                    ,
                    FechaInicioEstimada = groupQuery.Key.FechaInicioEstimada
                    ,
                    FechaFinEstimada = groupQuery.Key.FechaFinEstimada
                    ,
                    FechaInicioRealizada = groupQuery.Key.FechaInicioRealizada
                    ,
                    FechaFinRealizada = groupQuery.Key.FechaFinRealizada
                    ,
                    Estado_Nombre = groupQuery.Key.Estado_Nombre
                    ,
                    ClasificacionGasto_Codigo = groupQuery.Key.ClasificacionGasto_Codigo
                    ,
                    ClasificacionGasto_Nombre = groupQuery.Key.ClasificacionGasto_Nombre
                    ,
                    FuenteFinanciamiento_Codigo = groupQuery.Key.FuenteFinanciamiento_Codigo
                    ,
                    FuenteFinanciamiento_Nombre = groupQuery.Key.FuenteFinanciamiento_Nombre
                    ,
                    Periodo = groupQuery.Key.Periodo
                    ,
                    Obra = groupQuery.Key.Obra
                    ,
                    Actividad = groupQuery.Key.Actividad
                    ,
                    Proyecto_Nro = groupQuery.Key.Proyecto_Nro
                    ,
                    IdFase = groupQuery.Key.IdFase
                    ,
                    Fase_Nombre = groupQuery.Key.Fase_Nombre
                    ,
                    Fase_Orden = groupQuery.Key.Fase_Orden
                    ,
                    Etapa_Orden = groupQuery.Key.Etapa_Orden
                    ,
                    AnioCorriente = groupQuery.Key.AnioCorriente
                             ,
                    AnioCorrienteEstimado = groupQuery.Key.AnioCorrienteEstimado
                             ,
                    AnioCorrienteRealizado = groupQuery.Key.AnioCorrienteRealizado
                    ,
                    Estimado = groupQuery.Sum(i => i.Estimado)
                    ,
                    Realizado = groupQuery.Sum(i => i.Realizado)

                }
           ).AsQueryable();
            return query.ToList();
        }

        public List<ProyectoObjetivoReportResult> GetProyectoObjetivo(ProyectoFilter filter)
        {
            var query = (
                from o in
                    (
                        from p in Query(filter)
                        join pp in this.Context.ProyectoPropositos on p.IdProyecto equals pp.IdProyecto
                        join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
                        join os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals os.IdObjetivo
                        //obligo a que no encuentre nada, comparando el idobjetivo a 0
                        //porque no me permite campos definidos en el select en blanco 
                        join _oi in this.Context.ObjetivoIndicadors on 0 equals _oi.IdObjetivo into toi
                        from oi in toi.DefaultIfEmpty()
                        join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
                        from ic in tic.DefaultIfEmpty()
                        join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
                        from um in tum.DefaultIfEmpty()
                        join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
                        from i in ti.DefaultIfEmpty()
                        join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                        from mv in tmv.DefaultIfEmpty()
                        join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                        from ie in tie.DefaultIfEmpty()
                        join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                        from iei in tiei.DefaultIfEmpty()
                        join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                        from cg in tcg.DefaultIfEmpty()
                        select new ProyectoObjetivoReportResult()
                        {
                            ProyectoObjetivo_ID = o.IdObjetivo
                            ,
                            ProyectoObjetivo_Nombre = o.Nombre
                            ,
                            ObjetivoSupuesto_Id = os.IdObjetivoSupuesto
                            ,
                            ObjetivoSupuesto_Descripcion = os.Descripcion
                            ,
                            IdIndicador = oi != null ? oi.IdObjetivoIndicador : 0
                            ,
                            Indicador_Sigla = ic != null ? ic.Sigla : string.Empty
                            ,
                            Indicador_Descripcion = ic != null ? ic.Nombre : string.Empty
                            ,
                            Unidad_Sigla = um != null ? um.Sigla : string.Empty
                            ,
                            Unidad_Descripcion = um != null ? um.Nombre : string.Empty
                            ,
                            MedioVerificacion_Sigla = mv != null ? mv.Sigla : string.Empty
                            ,
                            MedioVerificacion_Nombre = mv != null ? mv.Nombre : string.Empty
                            ,
                            Indicador_Observacion = i != null ? i.Observacion : string.Empty
                            ,
                            ClasificacionGeografica_ID = cg != null ? cg.IdClasificacionGeografica : 0
                            ,
                            ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : string.Empty
                            ,
                            IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : string.Empty
                            ,
                            FechaEstimada = ie.FechaEstimada
                            ,
                            CantidadEstimada = ie != null ? ie.CantidadEstimada : 0
                            ,
                            FechaReal = ie.FechaReal
                            ,
                            CantidadReal = ie != null ? ie.CantidadReal : 0
                        }
                        ).Union(
                        from p in this.Query(filter)
                        join pp in this.Context.ProyectoPropositos on p.IdProyecto equals pp.IdProyecto
                        join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
                        //obligo a que no encuentre supuestos, comparando el idobjetivosupuesto a 0
                        //porque no me permite campos definidos en el select en blanco 
                        join _os in this.Context.ObjetivoSupuestos on 0 equals _os.IdObjetivo into tos
                        from os in tos.DefaultIfEmpty()
                        join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo equals _oi.IdObjetivo into toi
                        from oi in toi.DefaultIfEmpty()
                        join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
                        from ic in tic.DefaultIfEmpty()
                        join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
                        from um in tum.DefaultIfEmpty()
                        join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
                        from i in ti.DefaultIfEmpty()
                        join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                        from mv in tmv.DefaultIfEmpty()
                        join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                        from ie in tie.DefaultIfEmpty()
                        join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                        from iei in tiei.DefaultIfEmpty()
                        join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                        from cg in tcg.DefaultIfEmpty()
                        select new ProyectoObjetivoReportResult()
                        {
                            ProyectoObjetivo_ID = o.IdObjetivo
                            ,
                            ProyectoObjetivo_Nombre = o.Nombre
                            ,
                            ObjetivoSupuesto_Id = os != null ? os.IdObjetivoSupuesto : 999999999
                            ,
                            ObjetivoSupuesto_Descripcion = os != null ? os.Descripcion : string.Empty
                            ,
                            IdIndicador = oi != null ? oi.IdObjetivoIndicador : 0
                            ,
                            Indicador_Sigla = ic != null ? ic.Sigla : string.Empty
                            ,
                            Indicador_Descripcion = ic != null ? ic.Nombre : string.Empty
                            ,
                            Unidad_Sigla = um != null ? um.Sigla : string.Empty
                            ,
                            Unidad_Descripcion = um != null ? um.Nombre : string.Empty
                            ,
                            MedioVerificacion_Sigla = mv != null ? mv.Sigla : string.Empty
                            ,
                            MedioVerificacion_Nombre = mv != null ? mv.Nombre : string.Empty
                            ,
                            Indicador_Observacion = i != null ? i.Observacion : string.Empty
                            ,
                            ClasificacionGeografica_ID = cg != null ? cg.IdClasificacionGeografica : 0
                            ,
                            ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : string.Empty
                            ,
                            IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : string.Empty
                            ,
                            FechaEstimada = ie.FechaEstimada
                            ,
                            CantidadEstimada = ie != null ? ie.CantidadEstimada : 0
                            ,
                            FechaReal = ie.FechaReal
                            ,
                            CantidadReal = ie != null ? ie.CantidadReal : 0
                        }
                        )
                orderby o.ProyectoObjetivo_ID, o.ObjetivoSupuesto_Id, o.IdIndicador, o.ClasificacionGeografica_ID, o.FechaEstimada
                select o
                ).AsQueryable();

            return query.ToList();

        }

        public List<ProyectoObjetivoReportResult> GetProyectoObjetivoFines(ProyectoFilter filter)
        {
            var query = (
                from p in this.Context.Proyectos
                join subprog in this.Context.SubProgramas on p.IdSubPrograma equals subprog.IdSubPrograma
                join prog in this.Context.Programas on subprog.IdPrograma equals prog.IdPrograma
                join po in this.Context.ProgramaObjetivos on prog.IdPrograma equals po.IdPrograma
                join obj in this.Context.Objetivos on po.IDObjetivo equals obj.IdObjetivo
                join pfin in this.Context.ProyectoFins on new { IdProyecto = p.IdProyecto, IdProgramaObjetivo = po.IdProgramaObjetivo } equals new { IdProyecto = pfin.IdProyecto, IdProgramaObjetivo = pfin.IdProgramaObjetivo }
                where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto
                select new ProyectoObjetivoReportResult()
                {
                    ProgramaObjetivo_Nombre = obj.Nombre
                }
           );
            return query.ToList();
        }
        public List<ProyectoObjetivoReportResult> GetProyectoProducto(ProyectoFilter filter)
        {
            var query = (
    from o in
        (
            from p in Query(filter)
            join pp in this.Context.ProyectoProductos on p.IdProyecto equals pp.IdProyecto
            join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
            join os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals os.IdObjetivo
            //obligo a que no encuentre nada, comparando el idobjetivo a 0
            //porque no me permite campos definidos en el select en blanco 
            join _oi in this.Context.ObjetivoIndicadors on 0 equals _oi.IdObjetivo into toi
            from oi in toi.DefaultIfEmpty()
            join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
            from ic in tic.DefaultIfEmpty()
            join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
            from um in tum.DefaultIfEmpty()
            join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
            from i in ti.DefaultIfEmpty()
            join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
            from mv in tmv.DefaultIfEmpty()
            join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
            from ie in tie.DefaultIfEmpty()
            join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
            from iei in tiei.DefaultIfEmpty()
            join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
            from cg in tcg.DefaultIfEmpty()
            select new ProyectoObjetivoReportResult()
            {
                ProyectoObjetivo_ID = o.IdObjetivo
                ,
                ProyectoObjetivo_Nombre = o.Nombre
                ,
                ObjetivoSupuesto_Id = os.IdObjetivoSupuesto
                ,
                ObjetivoSupuesto_Descripcion = os.Descripcion
                ,
                IdIndicador = oi != null ? oi.IdObjetivoIndicador : 0
                ,
                Indicador_Sigla = ic != null ? ic.Sigla : string.Empty
                ,
                Indicador_Descripcion = ic != null ? ic.Nombre : string.Empty
                ,
                Unidad_Sigla = um != null ? um.Sigla : string.Empty
                ,
                Unidad_Descripcion = um != null ? um.Nombre : string.Empty
                ,
                MedioVerificacion_Sigla = mv != null ? mv.Sigla : string.Empty
                ,
                MedioVerificacion_Nombre = mv != null ? mv.Nombre : string.Empty
                ,
                Indicador_Observacion = i != null ? i.Observacion : string.Empty
                ,
                ClasificacionGeografica_ID = cg != null ? cg.IdClasificacionGeografica : 0
                ,
                ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : string.Empty
                ,
                IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : string.Empty
                ,
                FechaEstimada = ie.FechaEstimada
                ,
                CantidadEstimada = ie != null ? ie.CantidadEstimada : 0
                ,
                FechaReal = ie.FechaReal
                ,
                CantidadReal = ie != null ? ie.CantidadReal : 0
            }
            ).Union(
            from p in this.Query(filter)
            join pp in this.Context.ProyectoProductos on p.IdProyecto equals pp.IdProyecto
            join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
            //obligo a que no encuentre supuestos, comparando el idobjetivosupuesto a 0
            //porque no me permite campos definidos en el select en blanco 
            join _os in this.Context.ObjetivoSupuestos on 0 equals _os.IdObjetivo into tos
            from os in tos.DefaultIfEmpty()
            join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo equals _oi.IdObjetivo into toi
            from oi in toi.DefaultIfEmpty()
            join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
            from ic in tic.DefaultIfEmpty()
            join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
            from um in tum.DefaultIfEmpty()
            join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
            from i in ti.DefaultIfEmpty()
            join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
            from mv in tmv.DefaultIfEmpty()
            join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
            from ie in tie.DefaultIfEmpty()
            join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
            from iei in tiei.DefaultIfEmpty()
            join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
            from cg in tcg.DefaultIfEmpty()
            select new ProyectoObjetivoReportResult()
            {
                ProyectoObjetivo_ID = o.IdObjetivo
                ,
                ProyectoObjetivo_Nombre = o.Nombre
                ,
                ObjetivoSupuesto_Id = os != null ? os.IdObjetivoSupuesto : 999999999
                ,
                ObjetivoSupuesto_Descripcion = os != null ? os.Descripcion : string.Empty
                ,
                IdIndicador = oi != null ? oi.IdObjetivoIndicador : 0
                ,
                Indicador_Sigla = ic != null ? ic.Sigla : string.Empty
                ,
                Indicador_Descripcion = ic != null ? ic.Nombre : string.Empty
                ,
                Unidad_Sigla = um != null ? um.Sigla : string.Empty
                ,
                Unidad_Descripcion = um != null ? um.Nombre : string.Empty
                ,
                MedioVerificacion_Sigla = mv != null ? mv.Sigla : string.Empty
                ,
                MedioVerificacion_Nombre = mv != null ? mv.Nombre : string.Empty
                ,
                Indicador_Observacion = i != null ? i.Observacion : string.Empty
                ,
                ClasificacionGeografica_ID = cg != null ? cg.IdClasificacionGeografica : 0
                ,
                ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : string.Empty
                ,
                IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : string.Empty
                ,
                FechaEstimada = ie.FechaEstimada
                ,
                CantidadEstimada = ie != null ? ie.CantidadEstimada : 0
                ,
                FechaReal = ie.FechaReal
                ,
                CantidadReal = ie != null ? ie.CantidadReal : 0
            }
            )
    orderby o.ProyectoObjetivo_ID, o.ObjetivoSupuesto_Id, o.IdIndicador, o.ClasificacionGeografica_ID, o.FechaEstimada
    select o
    ).AsQueryable();
            #region old
            //var query = (
            //     from p in this.Context.Proyectos
            //     join pp in Context.ProyectoProductos on p.IdProyecto equals pp.IdProyecto
            //     join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
            //     join _os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals _os.IdObjetivo into tos
            //     from os in tos.DefaultIfEmpty()
            //     join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo equals _oi.IdObjetivo into toi
            //     from oi in toi.DefaultIfEmpty()
            //     join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
            //     from i in ti.DefaultIfEmpty()
            //     join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
            //     from ie in tie.DefaultIfEmpty()
            //     join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
            //     from mv in tmv.DefaultIfEmpty()
            //     join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
            //     from cg in tcg.DefaultIfEmpty()
            //     join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
            //     from iei in tiei.DefaultIfEmpty()
            //     join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
            //     from ic in tic.DefaultIfEmpty()
            //     join _u in this.Context.UnidadMedidas on ic.IdUnidad equals _u.IdUnidadMedida into tu
            //     from u in tu.DefaultIfEmpty()

            //     where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto
            //     //faltaria los supuestos
            //     orderby o.IdObjetivo, i.IdIndicador, cg.IdClasificacionGeografica, ie.FechaEstimada
            //     select new ProyectoObjetivoReportResult()
            //     {
            //         ProyectoObjetivo_ID=o.IdObjetivo
            //         ,ProyectoObjetivo_Nombre = o.Nombre
            //         ,ObjetivoSupuesto_Descripcion = os != null ? os.Descripcion : String.Empty
            //         ,Indicador_Sigla=ic.Sigla
            //         ,Indicador_Descripcion=ic.Nombre
            //         ,Unidad_Sigla=u.Sigla
            //         ,Unidad_Descripcion=u.Nombre
            //         ,Indicador_Observacion = i != null ? i.Observacion : String.Empty
            //         ,MedioVerificacion_Sigla = mv != null ? mv.Sigla : String.Empty
            //         ,MedioVerificacion_Nombre = mv != null ? mv.Nombre : String.Empty
            //         ,ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : String.Empty
            //         ,ClasificacionGeografica_ID = cg != null ? ie.IdClasificacionGeografica : 0
            //         ,IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : String.Empty
            //         ,IndicadorEvolucionInstancia_ID = iei != null ? iei.IdIndicadorEvolucionInstancia : 0
            //         ,FechaEstimada = ie.FechaEstimada
            //         ,CantidadEstimada = ie != null ? ie.CantidadEstimada : null
            //         ,FechaReal = ie.FechaReal
            //         ,CantidadReal = ie.CantidadReal
            //         ,IdIndicadorEvolucion = ie != null ? ie.IdIndicadorEvolucion : 0
            //         ,IdIndicador = i != null ? i.IdIndicador : 0
            //     }
            // );
            #endregion
            return query.ToList();
        }
        public List<ProyectoEtapaReportResult> GetProyectoEtapa(ProyectoFilter filter)
        {
            var query = (
                 from p in this.Context.Proyectos
                 join pe in Context.ProyectoEtapas on p.IdProyecto equals pe.IdProyecto
                 join e in Context.Etapas on pe.IdEtapa equals e.IdEtapa
                 join _pei in this.Context.ProyectoEtapaIndicadors on pe.IdProyectoEtapa equals _pei.IdProyectoEtapa into tpei
                 from pei in tpei.DefaultIfEmpty()
                 join _i in this.Context.Indicadors on pei.IdIndicador equals _i.IdIndicador into ti
                 from i in ti.DefaultIfEmpty()
                 join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                 from ie in tie.DefaultIfEmpty()
                 join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                 from mv in tmv.DefaultIfEmpty()
                 join _mo in this.Context.Monedas on pei.IdMoneda equals _mo.IdMoneda into tmo
                 from mo in tmo.DefaultIfEmpty()
                 join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                 from cg in tcg.DefaultIfEmpty()
                 join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                 from iei in tiei.DefaultIfEmpty()
                 join _es in this.Context.Estados on ie.IdCertificadoEstado equals _es.IdEstado into tes
                 from es in tes.DefaultIfEmpty()
                 join _u in this.Context.UnidadMedidas on pei.IdUnidadMedia equals _u.IdUnidadMedida into tu
                 from u in tu.DefaultIfEmpty()
                 where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto && (e.IdFase == (Int32)FaseEnum.Ejecucion)
                 //--&& (e.Codigo == "AC" || e.Codigo == "OB"))
                 orderby e.Orden, pe.IdProyectoEtapa, i.IdIndicador, cg.IdClasificacionGeografica, ie.FechaEstimada, ie.CertificadoNumero
                 select new ProyectoEtapaReportResult()
                 {
                     //Datos de Proyecto Etapa
                     Etapa_Nombre = e.Nombre
                     ,
                     Etapa_Orden = e.Orden
                     ,
                     ProyectoEtapa_ID = pe.IdProyectoEtapa
                     ,
                     ProyectoEtapa_Nombre = pe.Nombre
                     ,
                     Proyecto_Nro = p.Codigo
                     ,
                     NroEtapa = pe.NroEtapa
                     ,
                     CodigoVinculacion = pe.CodigoVinculacion
                         //Estructura de la Apertura= Py + AC + OB con formato (00.00.00)
                     ,
                     Apertura = (p.NroProyecto.HasValue ? p.NroProyecto.Value.ToString() : "00") + "." +
                                (e.Codigo == "AC" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00") + "." +
                                (e.Codigo == "OB" ? (pe.NroEtapa.HasValue ? pe.NroEtapa.ToString() : "00") : "00")
                         //Datos de Detalle de una Etapa
                     ,
                     IdIndicador = i != null ? i.IdIndicador : 0
                     ,
                     Descripcion = pei.Descripcion
                     ,
                     Unidad_Nombre = u != null ? u.Nombre : ""
                     ,
                     NroExpediente = pei.NroExpediente
                     ,
                     FechaLicitacion = pei.FechaLicitacion
                     ,
                     FechaContratacion = pei.FechaContratacion
                     ,
                     Contratista = pei.Contratista
                     ,
                     FechaInicioObra = pei.FechaInicioObra
                     ,
                     PlazoEjecucion = pei.PlazoEjecucion
                     ,
                     MonedaNombre = mo.Nombre
                     ,
                     Magnitud = pei != null ? pei.Magnitud : null
                     ,
                     MontoContrato = pei != null ? pei.MontoContrato : null
                     ,
                     MontoVigente = pei != null ? pei.MontoVigente : null
                     ,
                     Indicador_Observacion = i != null ? i.Observacion : String.Empty
                     ,
                     MedioVerificacion_Sigla = mv != null ? mv.Sigla : String.Empty
                     ,
                     MedioVerificacion_Nombre = mv != null ? mv.Nombre : String.Empty

                     //Datos de la Evolucion de un Detalle de una Etapa
                     ,
                     IdIndicadorEvolucion = ie != null ? ie.IdIndicadorEvolucion : 0
                     ,
                     ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : String.Empty
                     ,
                     ClasificacionGeografica_ID = cg != null ? cg.IdClasificacionGeografica : 0
                     ,
                     IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : String.Empty
                     ,
                     IndicadorEvolucionInstancia_ID = iei != null ? iei.IdIndicadorEvolucionInstancia : 0
                     ,
                     FechaEstimada = ie.FechaEstimada
                     ,
                     CantidadEstimada = ie != null ? ie.CantidadEstimada : null
                     ,
                     PrecioUnitarioEstimado = ie != null ? ie.PrecioUnitarioEstimado : null
                     ,
                     FechaReal = ie.FechaReal
                     ,
                     CantidadReal = ie.CantidadReal
                     ,
                     PrecioUnitarioReal = ie != null ? ie.PrecioUnitarioReal : null
                     ,
                     CertificadoNumero = ie != null ? ie.CertificadoNumero : ""
                     ,
                     CertificadoFecha = ie.CertificadoFechaPago
                     ,
                     CertificadoVto = ie.CertificadoFechaVencimiento
                     ,
                     CertificadoEstado_Nombre = es != null ? es.Nombre : ""

                     ,
                     CantidadAcumuladaEstimada = ie != null ? ie.CantidadAcumuladaEstimada : null
                     ,
                     CantidadAcumuladaRealizada = ie != null ? ie.CantidadAcumuladaRealizada : null
                     ,
                     MontoEstimado = ie != null ? ie.MontoEstimado : null
                     ,
                     MontoRealizado = ie != null ? ie.MontoRealizado : null
                     ,
                     EvolucionObservacion = iei != null ? ie.Observacion : String.Empty
                     ,
                     Cotizacion = ie != null ? ie.Cotizacion : null
                     ,
                     EvolucionNroDesembolso = iei != null ? ie.NumeroDesembolso : String.Empty
                     ,
                     EvolucionNroExpediente = iei != null ? ie.NroExpediente : String.Empty
                 }
             );
            return query.ToList();
        }
        public List<ProyectoBeneficiosReportResult> GetProyectoBeneficio(ProyectoFilter filter)
        {
            var query = (
                 from p in this.Context.Proyectos
                 join pbi in this.Context.ProyectoBeneficioIndicadors on p.IdProyecto equals pbi.IdProyecto
                 join _ic in this.Context.IndicadorClases on pbi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
                 from ic in tic.DefaultIfEmpty()
                 join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
                 from um in tum.DefaultIfEmpty()
                 join _i in this.Context.Indicadors on pbi.IdIndicador equals _i.IdIndicador into ti
                 from i in ti.DefaultIfEmpty()
                 join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                 from ie in tie.DefaultIfEmpty()
                 join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                 from mv in tmv.DefaultIfEmpty()
                 join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                 from cg in tcg.DefaultIfEmpty()
                 join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                 from iei in tiei.DefaultIfEmpty()

                 where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto
                 select new ProyectoBeneficiosReportResult()
                 {
                     IndicadorClase_Sigla = ic != null ? ic.Sigla : String.Empty
                     ,
                     IndicadorClase_Nombre = ic != null ? ic.Nombre : String.Empty
                     ,
                     IndicadorClase_Unidad = um != null ? um.Nombre : String.Empty
                     ,
                     Indirecto = pbi != null ? pbi.Indirecto : false
                     ,
                     Indicador_MedioVerificacion = mv != null ? mv.Nombre : String.Empty
                     ,
                     ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : String.Empty
                     ,
                     IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : String.Empty
                     ,
                     FechaEstimada = ie.FechaEstimada
                     ,
                     CantidadEstimada = ie != null ? ie.CantidadEstimada : null
                     ,
                     FechaReal = ie.FechaReal
                     ,
                     CantidadReal = ie.CantidadReal
                     ,
                     IdIndicadorEvolucion = ie != null ? ie.IdIndicadorEvolucion : 0
                     ,
                     IdIndicador = i != null ? i.IdIndicador : 0
                 }
             );
            return query.ToList();
        }
        public List<ProyectoBeneficiarioReportResult> GetProyectoBeneficiario(ProyectoFilter filter)
        {
            var query = (
                 from p in this.Context.Proyectos
                 join pbi in this.Context.ProyectoBeneficiarioIndicadors on p.IdProyecto equals pbi.IdProyecto
                 join _i in this.Context.Indicadors on pbi.IdIndicador equals _i.IdIndicador into ti
                 from i in ti.DefaultIfEmpty()
                 join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                 from ie in tie.DefaultIfEmpty()
                 join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                 from mv in tmv.DefaultIfEmpty()
                 join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                 from cg in tcg.DefaultIfEmpty()
                 join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                 from iei in tiei.DefaultIfEmpty()

                 where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto
                 select new ProyectoBeneficiarioReportResult()
                 {
                     Descripcion = pbi.Beneficiario
                     ,
                     ClasificacionGeografica_Descripcion = cg != null ? cg.Descripcion : String.Empty
                     ,
                     IndicadorEvolucionInstancia_Nombre = iei != null ? iei.Nombre : String.Empty
                     ,
                     FechaEstimada = ie.FechaEstimada
                     ,
                     CantidadEstimada = ie != null ? ie.CantidadEstimada : null
                     ,
                     FechaReal = ie.FechaReal
                     ,
                     CantidadReal = ie.CantidadReal
                     ,
                     IdIndicadorEvolucion = ie != null ? ie.IdIndicadorEvolucion : 0
                     ,
                     IdIndicador = i != null ? i.IdIndicador : 0
                 }
             );
            return query.ToList();
        }
        #endregion



        /// <summary>
        /// Retorna el result de los proyectos con sus PerfilesPorOficina
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>     
        //public virtual ListPaged<ProyectoResult> GetResultWithOfficePerfil(ProyectoFilter filter)
        //{  
        //    ListPaged<ProyectoResult> result = GetResult(filter);
        //    List<int> ids = (from o in result select o.IdProyecto).ToList();
        //    List<ProyectoOficinaPerfilResult> proyectoOficinaPerfiles = ProyectoOficinaPerfilData.Current.GetResult(new ProyectoOficinaPerfilFilter() { IdsProyecto = ids });
        //    result.ForEach(p => p.PerfilOficinas = (from o in proyectoOficinaPerfiles where o.IdProyecto == p.IdProyecto select new PerfilOficina() { IdOficina = o.IdOficina, IdPerfil = o.IdPerfil, Oficina_BreadcrumbId = o.Oficina_BreadcrumbId }).ToList());
        //    return result;
        //}

        #endregion
        #region Public Methods
        public override ListPaged<SimpleResult<int>> GetSimpleList(ProyectoFilter filter)
        {
            return ListPaged<SimpleResult<int>>((from o in QueryResult(filter) select new SimpleResult<int> { ID = o.IdProyecto, Text = o.ProyectoDenominacion }).AsQueryable(), filter);
        }
        public bool GetMarcaPlanProyecto(int IdProyecto)
        {
            return (from p in this.Context.ProyectoPlans
                    join v in this.Context.PlanVersions on p.IdPlanVersion equals v.IdPlanVersion
                    join t in this.Context.PlanTipos on v.IdPlanTipo equals t.IdPlanTipo
                    where p.IdProyecto == IdProyecto && t.Orden == 0
                    select p).Count() > 0;
        }
        public List<CronogramaTotalPorAnio> GetTotalEstimadoPorAnio(ProyectoFilter filter)
        {
            var query = (from o in this.Context.ProyectoEtapas
                         join pee in this.Context.ProyectoEtapaEstimados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                         join peep in this.Context.ProyectoEtapaEstimadoPeriodos on pee.IdProyectoEtapaEstimado equals peep.IdProyectoEtapaEstimado
                         join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                         join f in this.Context.Fases on e.IdFase equals f.IdFase
                         where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == o.IdProyecto
                         group peep by new { Id = o.IdProyecto, Periodo = peep.Periodo, NombreFase = f.Nombre } into groupQuery
                         select new CronogramaTotalPorAnio()
                         {
                             Anio = groupQuery.Key.Periodo
                            ,
                             Estimado = groupQuery.Sum(i => i.MontoCalculado)
                            ,
                             NombreFase = groupQuery.Key.NombreFase
                         }
                   ).AsQueryable();
            return query.ToList();
        }
        public List<CronogramaTotalPorAnio> GetTotalRealizadoPorAnio(ProyectoFilter filter)
        {
            var query = (
                   from o in this.Context.ProyectoEtapas
                   join pee in this.Context.ProyectoEtapaRealizados on o.IdProyectoEtapa equals pee.IdProyectoEtapa
                   join peep in this.Context.ProyectoEtapaRealizadoPeriodos on pee.IdProyectoEtapaRealizado equals peep.IdProyectoEtapaRealizado
                   join e in this.Context.Etapas on o.IdEtapa equals e.IdEtapa
                   join f in this.Context.Fases on e.IdFase equals f.IdFase
                   where filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == o.IdProyecto
                   group peep by new { Id = o.IdProyecto, Periodo = peep.Periodo, NombreFase = f.Nombre } into groupQuery
                   select new CronogramaTotalPorAnio()
                   {
                       Anio = groupQuery.Key.Periodo
                       ,
                       Realizado = groupQuery.Sum(i => i.MontoCalculado)
                       ,
                       NombreFase = groupQuery.Key.NombreFase
                   }
               ).AsQueryable();
            return query.ToList();
        }
        public List<Int32> AniosEstimadosRealizados(ProyectoFilter filter)
        {
            var query = (
                (from perp in this.Context.ProyectoEtapaRealizadoPeriodos
                 join per in this.Context.ProyectoEtapaRealizados on perp.IdProyectoEtapaRealizado equals per.IdProyectoEtapaRealizado
                 join pe in this.Context.ProyectoEtapas on per.IdProyectoEtapa equals pe.IdProyectoEtapa
                 where (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == pe.IdProyecto)
                 && perp.MontoCalculado > 0
                 select perp.Periodo
                 ).Union(
                    from peep in this.Context.ProyectoEtapaEstimadoPeriodos
                    join per in this.Context.ProyectoEtapaEstimados on peep.IdProyectoEtapaEstimado equals per.IdProyectoEtapaEstimado
                    join pe in this.Context.ProyectoEtapas on per.IdProyectoEtapa equals pe.IdProyectoEtapa
                    where (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == pe.IdProyecto)
                    && peep.MontoCalculado > 0
                    select peep.Periodo)
                    ).Distinct();
            return query.ToList();
        }

        //Matias 20131106 - Tarea 80
        public void updateFechaUltimaModificacion(int id, IContextUser contextUser)
        {
            Proyecto entity = ProyectoData.Current.GetById(id);
            entity.FechaModificacion = DateTime.Now;
            entity.IdUsuarioModificacion = contextUser.User.IdUsuario;
            ProyectoData.Current.Update(entity);
        }
        //FinMatias 20131106 - Tarea 80

        #endregion
    }
}

