using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;
using nc = Contract;
namespace DataAccess
{
    public class ProyectoCalidadData : EntityData<ProyectoCalidad, ProyectoCalidadFilter, ProyectoCalidadResult, int>
    {
        #region Singleton
        private static volatile ProyectoCalidadData current;
        private static object syncRoot = new Object();

        //private ProyectoCalidadData() {}
        public static ProyectoCalidadData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCalidadData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdProyectoCalidad"; } }

        #region Clase Base

        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.ProyectoCalidad entity)
        {
            return entity.IdProyectoCalidad;
        }
        public override ProyectoCalidad GetByEntity(ProyectoCalidad entity)
        {
            return this.GetById(entity.IdProyectoCalidad);
        }
        public override ProyectoCalidad GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoCalidad == id select o).FirstOrDefault();
        }
        #endregion
        #region Query
        protected override IQueryable<ProyectoCalidad> Query(ProyectoCalidadFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdProyectoCalidad == null || filter.IdProyectoCalidad == 0 || o.IdProyectoCalidad == filter.IdProyectoCalidad)
                    && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                    && (filter.DenominacionOK == null || o.DenominacionOK == filter.DenominacionOK)
                    && (filter.DenominacionSugerida == null || filter.DenominacionSugerida.Trim() == string.Empty || filter.DenominacionSugerida.Trim() == "%" || (filter.DenominacionSugerida.EndsWith("%") && filter.DenominacionSugerida.StartsWith("%") && (o.DenominacionSugerida.Contains(filter.DenominacionSugerida.Replace("%", "")))) || (filter.DenominacionSugerida.EndsWith("%") && o.DenominacionSugerida.StartsWith(filter.DenominacionSugerida.Replace("%", ""))) || (filter.DenominacionSugerida.StartsWith("%") && o.DenominacionSugerida.EndsWith(filter.DenominacionSugerida.Replace("%", ""))) || o.DenominacionSugerida == filter.DenominacionSugerida)
                    && (filter.DenominacionOriginal == null || filter.DenominacionOriginal.Trim() == string.Empty || filter.DenominacionOriginal.Trim() == "%" || (filter.DenominacionOriginal.EndsWith("%") && filter.DenominacionOriginal.StartsWith("%") && (o.DenominacionOriginal.Contains(filter.DenominacionOriginal.Replace("%", "")))) || (filter.DenominacionOriginal.EndsWith("%") && o.DenominacionOriginal.StartsWith(filter.DenominacionOriginal.Replace("%", ""))) || (filter.DenominacionOriginal.StartsWith("%") && o.DenominacionOriginal.EndsWith(filter.DenominacionOriginal.Replace("%", ""))) || o.DenominacionOriginal == filter.DenominacionOriginal)
                    && (filter.ProyectoTipoOk == null || o.ProyectoTipoOk == filter.ProyectoTipoOk)
                    && (filter.IdProyectoTipo == null || filter.IdProyectoTipo == 0 || o.IdProyectoTipo == filter.IdProyectoTipo)
                    && (filter.IdProyectoTipoIsNull == null || filter.IdProyectoTipoIsNull == true || o.IdProyectoTipo != null) && (filter.IdProyectoTipoIsNull == null || filter.IdProyectoTipoIsNull == false || o.IdProyectoTipo == null)
                    && (filter.EstadoOK == null || o.EstadoOK >= filter.EstadoOK) && (filter.EstadoOK_To == null || o.EstadoOK <= filter.EstadoOK_To)
                    && (filter.EstadoOKIsNull == null || filter.EstadoOKIsNull == true || o.EstadoOK != null) && (filter.EstadoOKIsNull == null || filter.EstadoOKIsNull == false || o.EstadoOK == null)
                    && (filter.IdEstadoSugerido == null || o.IdEstadoSugerido >= filter.IdEstadoSugerido) && (filter.IdEstadoSugerido_To == null || o.IdEstadoSugerido <= filter.IdEstadoSugerido_To)
                    && (filter.IdEstadoSugeridoIsNull == null || filter.IdEstadoSugeridoIsNull == true || o.IdEstadoSugerido != null) && (filter.IdEstadoSugeridoIsNull == null || filter.IdEstadoSugeridoIsNull == false || o.IdEstadoSugerido == null)
                    && (filter.ProcesoOk == null || o.ProcesoOk == filter.ProcesoOk)
                        //&& (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso==filter.IdProceso)
                    && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == true || o.IdProceso != null) && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == false || o.IdProceso == null)
                    && (filter.FinalidadFuncionOk == null || o.FinalidadFuncionOk == filter.FinalidadFuncionOk)
                    && (filter.IdClasificacionFuncional == null || filter.IdClasificacionFuncional == 0 || o.IdClasificacionFuncional == filter.IdClasificacionFuncional)
                    && (filter.IdClasificacionFuncionalIsNull == null || filter.IdClasificacionFuncionalIsNull == true || o.IdClasificacionFuncional != null) && (filter.IdClasificacionFuncionalIsNull == null || filter.IdClasificacionFuncionalIsNull == false || o.IdClasificacionFuncional == null)
                    && (filter.ReqDictamen == null || o.ReqDictamen == filter.ReqDictamen)
                    && (filter.Comenatrio == null || filter.Comenatrio.Trim() == string.Empty || filter.Comenatrio.Trim() == "%" || (filter.Comenatrio.EndsWith("%") && filter.Comenatrio.StartsWith("%") && (o.Comenatrio.Contains(filter.Comenatrio.Replace("%", "")))) || (filter.Comenatrio.EndsWith("%") && o.Comenatrio.StartsWith(filter.Comenatrio.Replace("%", ""))) || (filter.Comenatrio.StartsWith("%") && o.Comenatrio.EndsWith(filter.Comenatrio.Replace("%", ""))) || o.Comenatrio == filter.Comenatrio)
                        //&& (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
                    && (filter.FechaEstado == null || filter.FechaEstado == DateTime.MinValue || o.FechaEstado >= filter.FechaEstado) && (filter.FechaEstado_To == null || filter.FechaEstado_To == DateTime.MinValue || o.FechaEstado <= filter.FechaEstado_To)
                    && (filter.FechaEstadoIsNull == null || filter.FechaEstadoIsNull == true || o.FechaEstado != null) && (filter.FechaEstadoIsNull == null || filter.FechaEstadoIsNull == false || o.FechaEstado == null)
                    && (filter.LocalizacionOK == null || o.LocalizacionOK == filter.LocalizacionOK)
                    select o
                    ).AsQueryable();
        }
        //protected override IQueryable<ProyectoCalidadResult> QueryResult(ProyectoCalidadFilter filter)
        //{
        //    return (from o in Query(filter)
        //            join t1 in this.Context.Estados on o.IdEstado equals t1.IdEstado
        //            join _t2 in this.Context.FinalidadFuncions on o.IdClasificacionFuncional equals _t2.IdFinalidadFuncion into tt2
        //            from t2 in tt2.DefaultIfEmpty()
        //            join _t3 in this.Context.Procesos on o.IdProceso equals _t3.IdProceso into tt3
        //            from t3 in tt3.DefaultIfEmpty()
        //            join t4 in this.Context.Proyectos on o.IdProyecto equals t4.IdProyecto
        //            join _t5 in this.Context.ProyectoTipos on o.IdProyectoTipo equals _t5.IdProyectoTipo into tt5
        //            from t5 in tt5.DefaultIfEmpty()
        //            select new ProyectoCalidadResult()
        //            {
        //                IdProyectoCalidad = o.IdProyectoCalidad
        //                ,
        //                IdProyecto = o.IdProyecto
        //                ,
        //                DenominacionOK = o.DenominacionOK
        //                ,
        //                DenominacionSugerida = o.DenominacionSugerida
        //                ,
        //                DenominacionOriginal = o.DenominacionOriginal
        //                ,
        //                ProyectoTipoOk = o.ProyectoTipoOk
        //                ,
        //                IdProyectoTipo = o.IdProyectoTipo
        //                ,
        //                EstadoOK = o.EstadoOK
        //                ,
        //                IdEstadoSugerido = o.IdEstadoSugerido
        //                ,
        //                ProcesoOk = o.ProcesoOk
        //                ,
        //                IdProceso = o.IdProceso
        //                ,
        //                FinalidadFuncionOk = o.FinalidadFuncionOk
        //                ,
        //                IdClasificacionFuncional = o.IdClasificacionFuncional
        //                ,
        //                ReqDictamen = o.ReqDictamen
        //                ,
        //                Comenatrio = o.Comenatrio
        //                ,
        //                IdEstado = o.IdEstado
        //                ,
        //                FechaEstado = o.FechaEstado
        //                ,
        //                LocalizacionOK = o.LocalizacionOK
        //                ,
        //                Estado_Nombre = t1.Nombre
        //                ,
        //                Estado_Codigo = t1.Codigo
        //                ,
        //                Estado_Orden = t1.Orden
        //                ,
        //                Estado_Descripcion = t1.Descripcion
        //                ,
        //                Estado_Activo = t1.Activo
        //                ,
        //                ClasificacionFuncional_Codigo = t2 != null ? (string)t2.Codigo : null
        //                ,
        //                ClasificacionFuncional_Denominacion = t2 != null ? (string)t2.Denominacion : null
        //                ,
        //                ClasificacionFuncional_Activo = t2 != null ? (bool?)t2.Activo : null
        //                ,
        //                ClasificacionFuncional_IdFinalidadFunciontipo = t2 != null ? (int?)t2.IdFinalidadFunciontipo : null
        //                ,
        //                ClasificacionFuncional_IdFinalidadFuncionPadre = t2 != null ? (int?)t2.IdFinalidadFuncionPadre : null
        //                ,
        //                ClasificacionFuncional_BreadcrumbId = t2 != null ? (string)t2.BreadcrumbId : null
        //                ,
        //                ClasificacionFuncional_BreadcrumbOrden = t2 != null ? (string)t2.BreadcrumbOrden : null
        //                ,
        //                ClasificacionFuncional_Nivel = t2 != null ? (int?)t2.Nivel : null
        //                ,
        //                ClasificacionFuncional_Orden = t2 != null ? (int?)t2.Orden : null
        //                ,
        //                ClasificacionFuncional_Descripcion = t2 != null ? (string)t2.Descripcion : null
        //                ,
        //                ClasificacionFuncional_DescripcionInvertida = t2 != null ? (string)t2.DescripcionInvertida : null
        //                ,
        //                ClasificacionFuncional_Seleccionable = t2 != null ? (bool?)t2.Seleccionable : null
        //                ,
        //                ClasificacionFuncional_BreadcrumbCode = t2 != null ? (string)t2.BreadcrumbCode : null
        //                ,
        //                ClasificacionFuncional_DescripcionCodigo = t2 != null ? (string)t2.DescripcionCodigo : null
        //                ,
        //                Proceso_IdProyectoTipo = t3 != null ? (int?)t3.IdProyectoTipo : null
        //                ,
        //                Proceso_Nombre = t3 != null ? (string)t3.Nombre : null
        //                ,
        //                Proceso_Activo = t3 != null ? (bool?)t3.Activo : null
        //                ,
        //                Proyecto_IdTipoProyecto = t4.IdTipoProyecto
        //                ,
        //                Proyecto_IdSubPrograma = t4.IdSubPrograma
        //                ,
        //                Proyecto_Codigo = t4.Codigo
        //                ,
        //                Proyecto_ProyectoDenominacion = t4.ProyectoDenominacion
        //                ,
        //                Proyecto_ProyectoSituacionActual = t4.ProyectoSituacionActual
        //                ,
        //                Proyecto_ProyectoDescripcion = t4.ProyectoDescripcion
        //                ,
        //                Proyecto_ProyectoObservacion = t4.ProyectoObservacion
        //                ,
        //                Proyecto_IdEstado = t4.IdEstado
        //                ,
        //                Proyecto_IdProceso = t4.IdProceso
        //                ,
        //                Proyecto_IdModalidadContratacion = t4.IdModalidadContratacion
        //                ,
        //                Proyecto_IdFinalidadFuncion = t4.IdFinalidadFuncion
        //                ,
        //                Proyecto_IdOrganismoPrioridad = t4.IdOrganismoPrioridad
        //                ,
        //                Proyecto_SubPrioridad = t4.SubPrioridad
        //                ,
        //                Proyecto_EsBorrador = t4.EsBorrador
        //                ,
        //                Proyecto_EsProyecto = t4.EsProyecto
        //                ,
        //                Proyecto_NroProyecto = t4.NroProyecto
        //                ,
        //                Proyecto_AnioCorriente = t4.AnioCorriente
        //                ,
        //                Proyecto_FechaInicioEjecucionCalculada = t4.FechaInicioEjecucionCalculada
        //                ,
        //                Proyecto_FechaFinEjecucionCalculada = t4.FechaFinEjecucionCalculada
        //                ,
        //                Proyecto_FechaAlta = t4.FechaAlta
        //                ,
        //                Proyecto_FechaModificacion = t4.FechaModificacion
        //                ,
        //                Proyecto_IdUsuarioModificacion = t4.IdUsuarioModificacion
        //                ,
        //                Proyecto_IdProyectoPlan = t4.IdProyectoPlan
        //                ,
        //                Proyecto_EvaluarValidaciones = t4.EvaluarValidaciones
        //                ,
        //                Proyecto_Activo = t4.Activo
        //                ,
        //                ProyectoTipo_Sigla = t5 != null ? (string)t5.Sigla : null
        //                ,
        //                ProyectoTipo_Nombre = t5 != null ? (string)t5.Nombre : null
        //                ,
        //                ProyectoTipo_Activo = t5 != null ? (bool?)t5.Activo : null
        //                ,
        //                ProyectoTipo_Tipo = t5 != null ? (string)t5.Tipo : null
        //            }
        //              ).AsQueryable();
        //}
        #endregion
        #region Copy
        public override nc.ProyectoCalidad Copy(nc.ProyectoCalidad entity)
        {
            nc.ProyectoCalidad _new = new nc.ProyectoCalidad();
            _new.IdProyecto = entity.IdProyecto;
            _new.DenominacionOK = entity.DenominacionOK;
            _new.DenominacionSugerida = entity.DenominacionSugerida;
            _new.DenominacionOriginal = entity.DenominacionOriginal;
            _new.ProyectoTipoOk = entity.ProyectoTipoOk;
            _new.IdProyectoTipo = entity.IdProyectoTipo;
            _new.EstadoOK = entity.EstadoOK;
            _new.IdEstadoSugerido = entity.IdEstadoSugerido;
            _new.ProcesoOk = entity.ProcesoOk;
            _new.IdProceso = entity.IdProceso;
            _new.FinalidadFuncionOk = entity.FinalidadFuncionOk;
            _new.IdClasificacionFuncional = entity.IdClasificacionFuncional;
            _new.ReqDictamen = entity.ReqDictamen;
            _new.Comenatrio = entity.Comenatrio;
            _new.IdEstado = entity.IdEstado;
            _new.FechaEstado = entity.FechaEstado;
            _new.LocalizacionOK = entity.LocalizacionOK;
            return _new;
        }
        public override int CopyAndSave(ProyectoCalidad entity, string renameFormat)
        {
            ProyectoCalidad newEntity = Copy(entity);
            newEntity.DenominacionSugerida = string.Format(renameFormat, newEntity.DenominacionSugerida);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(ProyectoCalidad entity, int id)
        {
            entity.IdProyectoCalidad = id;
        }
        public override void Set(ProyectoCalidad source, ProyectoCalidad target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoCalidad = source.IdProyectoCalidad;
            target.IdProyecto = source.IdProyecto;
            target.DenominacionOK = source.DenominacionOK;
            target.DenominacionSugerida = source.DenominacionSugerida;
            target.DenominacionOriginal = source.DenominacionOriginal;
            target.ProyectoTipoOk = source.ProyectoTipoOk;
            target.IdProyectoTipo = source.IdProyectoTipo;
            target.EstadoOK = source.EstadoOK;
            target.IdEstadoSugerido = source.IdEstadoSugerido;
            target.ProcesoOk = source.ProcesoOk;
            target.IdProceso = source.IdProceso;
            target.FinalidadFuncionOk = source.FinalidadFuncionOk;
            target.IdClasificacionFuncional = source.IdClasificacionFuncional;
            target.ReqDictamen = source.ReqDictamen;
            target.Comenatrio = source.Comenatrio;
            target.IdEstado = source.IdEstado;
            target.FechaEstado = source.FechaEstado;
            target.LocalizacionOK = source.LocalizacionOK;

        }
        public override void Set(ProyectoCalidadResult source, ProyectoCalidad target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoCalidad = source.IdProyectoCalidad;
            target.IdProyecto = source.IdProyecto;
            target.DenominacionOK = source.DenominacionOK;
            target.DenominacionSugerida = source.DenominacionSugerida;
            target.DenominacionOriginal = source.DenominacionOriginal;
            target.ProyectoTipoOk = source.ProyectoTipoOk;
            target.IdProyectoTipo = source.IdProyectoTipo;
            target.EstadoOK = source.EstadoOK;
            target.IdEstadoSugerido = source.IdEstadoSugerido;
            target.ProcesoOk = source.ProcesoOk;
            target.IdProceso = source.IdProceso;
            target.FinalidadFuncionOk = source.FinalidadFuncionOk;
            target.IdClasificacionFuncional = source.IdClasificacionFuncional;
            target.ReqDictamen = source.ReqDictamen;
            target.Comenatrio = source.Comenatrio;
            target.IdEstado = source.IdEstado;
            target.FechaEstado = source.FechaEstado;
            target.LocalizacionOK = source.LocalizacionOK;

        }
        public override void Set(ProyectoCalidad source, ProyectoCalidadResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoCalidad = source.IdProyectoCalidad;
            target.IdProyecto = source.IdProyecto;
            target.DenominacionOK = source.DenominacionOK;
            target.DenominacionSugerida = source.DenominacionSugerida;
            target.DenominacionOriginal = source.DenominacionOriginal;
            target.ProyectoTipoOk = source.ProyectoTipoOk;
            target.IdProyectoTipo = source.IdProyectoTipo;
            target.EstadoOK = source.EstadoOK;
            target.IdEstadoSugerido = source.IdEstadoSugerido;
            target.ProcesoOk = source.ProcesoOk;
            target.IdProceso = source.IdProceso;
            target.FinalidadFuncionOk = source.FinalidadFuncionOk;
            target.IdClasificacionFuncional = source.IdClasificacionFuncional;
            target.ReqDictamen = source.ReqDictamen;
            target.Comenatrio = source.Comenatrio;
            target.IdEstado = source.IdEstado;
            target.FechaEstado = source.FechaEstado;
            target.LocalizacionOK = source.LocalizacionOK;

        }
        public override void Set(ProyectoCalidadResult source, ProyectoCalidadResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoCalidad = source.IdProyectoCalidad;
            target.IdProyecto = source.IdProyecto;
            target.DenominacionOK = source.DenominacionOK;
            target.DenominacionSugerida = source.DenominacionSugerida;
            target.DenominacionOriginal = source.DenominacionOriginal;
            target.ProyectoTipoOk = source.ProyectoTipoOk;
            target.IdProyectoTipo = source.IdProyectoTipo;
            target.EstadoOK = source.EstadoOK;
            target.IdEstadoSugerido = source.IdEstadoSugerido;
            target.ProcesoOk = source.ProcesoOk;
            target.IdProceso = source.IdProceso;
            target.FinalidadFuncionOk = source.FinalidadFuncionOk;
            target.IdClasificacionFuncional = source.IdClasificacionFuncional;
            target.ReqDictamen = source.ReqDictamen;
            target.Comenatrio = source.Comenatrio;
            target.IdEstado = source.IdEstado;
            target.FechaEstado = source.FechaEstado;
            target.LocalizacionOK = source.LocalizacionOK;
            target.Estado_Nombre = source.Estado_Nombre;
            target.Estado_Codigo = source.Estado_Codigo;
            target.Estado_Orden = source.Estado_Orden;
            target.Estado_Descripcion = source.Estado_Descripcion;
            target.Estado_Activo = source.Estado_Activo;
            target.ClasificacionFuncional_Codigo = source.ClasificacionFuncional_Codigo;
            target.ClasificacionFuncional_Denominacion = source.ClasificacionFuncional_Denominacion;
            target.ClasificacionFuncional_Activo = source.ClasificacionFuncional_Activo;
            //target.ClasificacionFuncional_IdFinalidadFunciontipo = source.ClasificacionFuncional_IdFinalidadFunciontipo;
            //target.ClasificacionFuncional_IdFinalidadFuncionPadre = source.ClasificacionFuncional_IdFinalidadFuncionPadre;
            //target.ClasificacionFuncional_BreadcrumbId = source.ClasificacionFuncional_BreadcrumbId;
            //target.ClasificacionFuncional_BreadcrumbOrden = source.ClasificacionFuncional_BreadcrumbOrden;
            //target.ClasificacionFuncional_Nivel = source.ClasificacionFuncional_Nivel;
            //target.ClasificacionFuncional_Orden = source.ClasificacionFuncional_Orden;
            //target.ClasificacionFuncional_Descripcion = source.ClasificacionFuncional_Descripcion;
            //target.ClasificacionFuncional_DescripcionInvertida = source.ClasificacionFuncional_DescripcionInvertida;
            //target.ClasificacionFuncional_Seleccionable = source.ClasificacionFuncional_Seleccionable;
            //target.ClasificacionFuncional_BreadcrumbCode = source.ClasificacionFuncional_BreadcrumbCode;
            //target.ClasificacionFuncional_DescripcionCodigo = source.ClasificacionFuncional_DescripcionCodigo;
            //target.Proceso_IdProyectoTipo = source.Proceso_IdProyectoTipo;
            //target.Proceso_Nombre = source.Proceso_Nombre;
            //target.Proceso_Activo = source.Proceso_Activo;
            //target.Proyecto_IdTipoProyecto = source.Proyecto_IdTipoProyecto;
            //target.Proyecto_IdSubPrograma = source.Proyecto_IdSubPrograma;
            target.Proyecto_Codigo = source.Proyecto_Codigo;
            target.Proyecto_ProyectoDenominacion = source.Proyecto_ProyectoDenominacion;
            //target.Proyecto_ProyectoSituacionActual = source.Proyecto_ProyectoSituacionActual;
            //target.Proyecto_ProyectoDescripcion = source.Proyecto_ProyectoDescripcion;
            //target.Proyecto_ProyectoObservacion = source.Proyecto_ProyectoObservacion;
            //target.Proyecto_IdEstado = source.Proyecto_IdEstado;
            //target.Proyecto_IdProceso = source.Proyecto_IdProceso;
            //target.Proyecto_IdModalidadContratacion = source.Proyecto_IdModalidadContratacion;
            //target.Proyecto_IdFinalidadFuncion = source.Proyecto_IdFinalidadFuncion;
            //target.Proyecto_IdOrganismoPrioridad = source.Proyecto_IdOrganismoPrioridad;
            //target.Proyecto_SubPrioridad = source.Proyecto_SubPrioridad;
            //target.Proyecto_EsBorrador = source.Proyecto_EsBorrador;
            //target.Proyecto_EsProyecto = source.Proyecto_EsProyecto;
            //target.Proyecto_NroProyecto = source.Proyecto_NroProyecto;
            //target.Proyecto_AnioCorriente = source.Proyecto_AnioCorriente;
            //target.Proyecto_FechaInicioEjecucionCalculada = source.Proyecto_FechaInicioEjecucionCalculada;
            //target.Proyecto_FechaFinEjecucionCalculada = source.Proyecto_FechaFinEjecucionCalculada;
            //target.Proyecto_FechaAlta = source.Proyecto_FechaAlta;
            //target.Proyecto_FechaModificacion = source.Proyecto_FechaModificacion;
            //target.Proyecto_IdUsuarioModificacion = source.Proyecto_IdUsuarioModificacion;
            //target.Proyecto_IdProyectoPlan = source.Proyecto_IdProyectoPlan;
            //target.Proyecto_EvaluarValidaciones = source.Proyecto_EvaluarValidaciones;
            target.Proyecto_Activo = source.Proyecto_Activo;
            //target.ProyectoTipo_Sigla = source.ProyectoTipo_Sigla;
            //target.ProyectoTipo_Nombre = source.ProyectoTipo_Nombre;
            //target.ProyectoTipo_Activo = source.ProyectoTipo_Activo;
            //target.ProyectoTipo_Tipo = source.ProyectoTipo_Tipo;

        }
        #endregion
        #region Equals
        public override bool Equals(ProyectoCalidad source, ProyectoCalidad target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if (!source.DenominacionOK.Equals(target.DenominacionOK)) return false;
            if ((source.DenominacionSugerida == null) ? target.DenominacionSugerida != null : !((target.DenominacionSugerida == String.Empty && source.DenominacionSugerida == null) || (target.DenominacionSugerida == null && source.DenominacionSugerida == String.Empty)) && !source.DenominacionSugerida.Trim().Replace("\r", "").Equals(target.DenominacionSugerida.Trim().Replace("\r", ""))) return false;
            if ((source.DenominacionOriginal == null) ? target.DenominacionOriginal != null : !((target.DenominacionOriginal == String.Empty && source.DenominacionOriginal == null) || (target.DenominacionOriginal == null && source.DenominacionOriginal == String.Empty)) && !source.DenominacionOriginal.Trim().Replace("\r", "").Equals(target.DenominacionOriginal.Trim().Replace("\r", ""))) return false;
            if (!source.ProyectoTipoOk.Equals(target.ProyectoTipoOk)) return false;
            if ((source.IdProyectoTipo == null) ? (target.IdProyectoTipo.HasValue && target.IdProyectoTipo.Value > 0) : !source.IdProyectoTipo.Equals(target.IdProyectoTipo)) return false;
            if ((source.EstadoOK == null) ? (target.EstadoOK.HasValue) : !source.EstadoOK.Equals(target.EstadoOK)) return false;
            if ((source.IdEstadoSugerido == null) ? (target.IdEstadoSugerido.HasValue) : !source.IdEstadoSugerido.Equals(target.IdEstadoSugerido)) return false;
            if (!source.ProcesoOk.Equals(target.ProcesoOk)) return false;
            if ((source.IdProceso == null) ? (target.IdProceso.HasValue && target.IdProceso.Value > 0) : !source.IdProceso.Equals(target.IdProceso)) return false;
            if (!source.FinalidadFuncionOk.Equals(target.FinalidadFuncionOk)) return false;
            if ((source.IdClasificacionFuncional == null) ? (target.IdClasificacionFuncional.HasValue && target.IdClasificacionFuncional.Value > 0) : !source.IdClasificacionFuncional.Equals(target.IdClasificacionFuncional)) return false;
            if (!source.ReqDictamen.Equals(target.ReqDictamen)) return false;
            if ((source.Comenatrio == null) ? target.Comenatrio != null : !((target.Comenatrio == String.Empty && source.Comenatrio == null) || (target.Comenatrio == null && source.Comenatrio == String.Empty)) && !source.Comenatrio.Trim().Replace("\r", "").Equals(target.Comenatrio.Trim().Replace("\r", ""))) return false;
            if (!source.IdEstado.Equals(target.IdEstado)) return false;
            if ((source.FechaEstado == null) ? (target.FechaEstado.HasValue) : !source.FechaEstado.Equals(target.FechaEstado)) return false;
            if (!source.LocalizacionOK.Equals(target.LocalizacionOK)) return false;

            return true;
        }
        public override bool Equals(ProyectoCalidadResult source, ProyectoCalidadResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if (!source.DenominacionOK.Equals(target.DenominacionOK)) return false;
            if ((source.DenominacionSugerida == null) ? target.DenominacionSugerida != null : (target.DenominacionSugerida == null) ? false : !((target.DenominacionSugerida == String.Empty && source.DenominacionSugerida == null) || (target.DenominacionSugerida == null && source.DenominacionSugerida == String.Empty)) && !source.DenominacionSugerida.Trim().Replace("\r", "").Equals(target.DenominacionSugerida.Trim().Replace("\r", ""))) return false;
            if ((source.DenominacionOriginal == null) ? target.DenominacionOriginal != null : (target.DenominacionOriginal == null)?  false : !((target.DenominacionOriginal == String.Empty && source.DenominacionOriginal == null) || (target.DenominacionOriginal == null && source.DenominacionOriginal == String.Empty)) && !source.DenominacionOriginal.Trim().Replace("\r", "").Equals(target.DenominacionOriginal.Trim().Replace("\r", ""))) return false;
            if (!source.ProyectoTipoOk.Equals(target.ProyectoTipoOk)) return false;
            if ((source.IdProyectoTipo == null) ? (target.IdProyectoTipo.HasValue && target.IdProyectoTipo.Value > 0) : !source.IdProyectoTipo.Equals(target.IdProyectoTipo)) return false;
            //if ((source.EstadoOK == null) ? (target.EstadoOK.HasValue) : !source.EstadoOK.Equals(target.EstadoOK)) return false;
            if ((source.IdEstadoSugerido == null) ? (target.IdEstadoSugerido.HasValue) : !source.IdEstadoSugerido.Equals(target.IdEstadoSugerido)) return false;
            if (!source.ProcesoOk.Equals(target.ProcesoOk)) return false;
            if ((source.IdProceso == null) ? (target.IdProceso.HasValue && target.IdProceso.Value > 0) : !source.IdProceso.Equals(target.IdProceso)) return false;
            if (!source.FinalidadFuncionOk.Equals(target.FinalidadFuncionOk)) return false;
            if ((source.IdClasificacionFuncional == null) ? (target.IdClasificacionFuncional.HasValue && target.IdClasificacionFuncional.Value > 0) : !source.IdClasificacionFuncional.Equals(target.IdClasificacionFuncional)) return false;
            if (!source.ReqDictamen.Equals(target.ReqDictamen)) return false;
            if ((source.Comenatrio == null) ? target.Comenatrio != null : !((target.Comenatrio == String.Empty && source.Comenatrio == null) || (target.Comenatrio == null && source.Comenatrio == String.Empty)) && !source.Comenatrio.Trim().Replace("\r", "").Equals(target.Comenatrio.Trim().Replace("\r", ""))) return false;
            
            //Pendiente 
            //if (!source.IdEstado.Equals(target.IdEstado)) return false;
            //if ((source.FechaEstado == null) ? (target.FechaEstado.HasValue) : !source.FechaEstado.Equals(target.FechaEstado)) return false;
            if (!source.LocalizacionOK.Equals(target.LocalizacionOK)) return false;
            if ((source.Estado_Nombre == null) ? target.Estado_Nombre != null : !((target.Estado_Nombre == String.Empty && source.Estado_Nombre == null) || (target.Estado_Nombre == null && source.Estado_Nombre == String.Empty)) && !source.Estado_Nombre.Trim().Replace("\r", "").Equals(target.Estado_Nombre.Trim().Replace("\r", ""))) return false;
            if ((source.Estado_Codigo == null) ? target.Estado_Codigo != null : !((target.Estado_Codigo == String.Empty && source.Estado_Codigo == null) || (target.Estado_Codigo == null && source.Estado_Codigo == String.Empty)) && !source.Estado_Codigo.Trim().Replace("\r", "").Equals(target.Estado_Codigo.Trim().Replace("\r", ""))) return false;
            if (!source.Estado_Orden.Equals(target.Estado_Orden)) return false;
            if ((source.Estado_Descripcion == null) ? target.Estado_Descripcion != null : !((target.Estado_Descripcion == String.Empty && source.Estado_Descripcion == null) || (target.Estado_Descripcion == null && source.Estado_Descripcion == String.Empty)) && !source.Estado_Descripcion.Trim().Replace("\r", "").Equals(target.Estado_Descripcion.Trim().Replace("\r", ""))) return false;
            if (!source.Estado_Activo.Equals(target.Estado_Activo)) return false;
            if ((source.ClasificacionFuncional_Codigo == null) ? target.ClasificacionFuncional_Codigo != null : !((target.ClasificacionFuncional_Codigo == String.Empty && source.ClasificacionFuncional_Codigo == null) || (target.ClasificacionFuncional_Codigo == null && source.ClasificacionFuncional_Codigo == String.Empty)) && !source.ClasificacionFuncional_Codigo.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_Codigo.Trim().Replace("\r", ""))) return false;
            if ((source.ClasificacionFuncional_Denominacion == null) ? target.ClasificacionFuncional_Denominacion != null : !((target.ClasificacionFuncional_Denominacion == String.Empty && source.ClasificacionFuncional_Denominacion == null) || (target.ClasificacionFuncional_Denominacion == null && source.ClasificacionFuncional_Denominacion == String.Empty)) && !source.ClasificacionFuncional_Denominacion.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_Denominacion.Trim().Replace("\r", ""))) return false;
            if (!source.ClasificacionFuncional_Activo.Equals(target.ClasificacionFuncional_Activo)) return false;
            //if ((source.ClasificacionFuncional_IdFinalidadFunciontipo == null) ? (target.ClasificacionFuncional_IdFinalidadFunciontipo.HasValue && target.ClasificacionFuncional_IdFinalidadFunciontipo.Value > 0) : !source.ClasificacionFuncional_IdFinalidadFunciontipo.Equals(target.ClasificacionFuncional_IdFinalidadFunciontipo)) return false;
            //if ((source.ClasificacionFuncional_IdFinalidadFuncionPadre == null) ? (target.ClasificacionFuncional_IdFinalidadFuncionPadre.HasValue && target.ClasificacionFuncional_IdFinalidadFuncionPadre.Value > 0) : !source.ClasificacionFuncional_IdFinalidadFuncionPadre.Equals(target.ClasificacionFuncional_IdFinalidadFuncionPadre)) return false;
            //if ((source.ClasificacionFuncional_BreadcrumbId == null) ? target.ClasificacionFuncional_BreadcrumbId != null : !((target.ClasificacionFuncional_BreadcrumbId == String.Empty && source.ClasificacionFuncional_BreadcrumbId == null) || (target.ClasificacionFuncional_BreadcrumbId == null && source.ClasificacionFuncional_BreadcrumbId == String.Empty)) && !source.ClasificacionFuncional_BreadcrumbId.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_BreadcrumbId.Trim().Replace("\r", ""))) return false;
            //if ((source.ClasificacionFuncional_BreadcrumbOrden == null) ? target.ClasificacionFuncional_BreadcrumbOrden != null : !((target.ClasificacionFuncional_BreadcrumbOrden == String.Empty && source.ClasificacionFuncional_BreadcrumbOrden == null) || (target.ClasificacionFuncional_BreadcrumbOrden == null && source.ClasificacionFuncional_BreadcrumbOrden == String.Empty)) && !source.ClasificacionFuncional_BreadcrumbOrden.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_BreadcrumbOrden.Trim().Replace("\r", ""))) return false;
            //if ((source.ClasificacionFuncional_Nivel == null) ? (target.ClasificacionFuncional_Nivel.HasValue) : !source.ClasificacionFuncional_Nivel.Equals(target.ClasificacionFuncional_Nivel)) return false;
            //if ((source.ClasificacionFuncional_Orden == null) ? (target.ClasificacionFuncional_Orden.HasValue) : !source.ClasificacionFuncional_Orden.Equals(target.ClasificacionFuncional_Orden)) return false;
            //if ((source.ClasificacionFuncional_Descripcion == null) ? target.ClasificacionFuncional_Descripcion != null : !((target.ClasificacionFuncional_Descripcion == String.Empty && source.ClasificacionFuncional_Descripcion == null) || (target.ClasificacionFuncional_Descripcion == null && source.ClasificacionFuncional_Descripcion == String.Empty)) && !source.ClasificacionFuncional_Descripcion.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_Descripcion.Trim().Replace("\r", ""))) return false;
            //if ((source.ClasificacionFuncional_DescripcionInvertida == null) ? target.ClasificacionFuncional_DescripcionInvertida != null : !((target.ClasificacionFuncional_DescripcionInvertida == String.Empty && source.ClasificacionFuncional_DescripcionInvertida == null) || (target.ClasificacionFuncional_DescripcionInvertida == null && source.ClasificacionFuncional_DescripcionInvertida == String.Empty)) && !source.ClasificacionFuncional_DescripcionInvertida.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_DescripcionInvertida.Trim().Replace("\r", ""))) return false;
            //if (!source.ClasificacionFuncional_Seleccionable.Equals(target.ClasificacionFuncional_Seleccionable)) return false;
            //if ((source.ClasificacionFuncional_BreadcrumbCode == null) ? target.ClasificacionFuncional_BreadcrumbCode != null : !((target.ClasificacionFuncional_BreadcrumbCode == String.Empty && source.ClasificacionFuncional_BreadcrumbCode == null) || (target.ClasificacionFuncional_BreadcrumbCode == null && source.ClasificacionFuncional_BreadcrumbCode == String.Empty)) && !source.ClasificacionFuncional_BreadcrumbCode.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_BreadcrumbCode.Trim().Replace("\r", ""))) return false;
            //if ((source.ClasificacionFuncional_DescripcionCodigo == null) ? target.ClasificacionFuncional_DescripcionCodigo != null : !((target.ClasificacionFuncional_DescripcionCodigo == String.Empty && source.ClasificacionFuncional_DescripcionCodigo == null) || (target.ClasificacionFuncional_DescripcionCodigo == null && source.ClasificacionFuncional_DescripcionCodigo == String.Empty)) && !source.ClasificacionFuncional_DescripcionCodigo.Trim().Replace("\r", "").Equals(target.ClasificacionFuncional_DescripcionCodigo.Trim().Replace("\r", ""))) return false;
            //if (!source.Proceso_IdProyectoTipo.Equals(target.Proceso_IdProyectoTipo)) return false;
            //if ((source.Proceso_Nombre == null) ? target.Proceso_Nombre != null : !((target.Proceso_Nombre == String.Empty && source.Proceso_Nombre == null) || (target.Proceso_Nombre == null && source.Proceso_Nombre == String.Empty)) && !source.Proceso_Nombre.Trim().Replace("\r", "").Equals(target.Proceso_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.Proceso_Activo.Equals(target.Proceso_Activo)) return false;
            //if (!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto)) return false;
            //if (!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma)) return false;
            if (!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo)) return false;
            if ((source.Proyecto_ProyectoDenominacion == null) ? target.Proyecto_ProyectoDenominacion != null : (target.Proyecto_ProyectoDenominacion == null) ? false : !((target.Proyecto_ProyectoDenominacion == String.Empty && source.Proyecto_ProyectoDenominacion == null) || (target.Proyecto_ProyectoDenominacion == null && source.Proyecto_ProyectoDenominacion == String.Empty)) && !source.Proyecto_ProyectoDenominacion.Trim().Replace("\r", "").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace("\r", ""))) return false;
            //if ((source.Proyecto_ProyectoSituacionActual == null) ? target.Proyecto_ProyectoSituacionActual != null : !((target.Proyecto_ProyectoSituacionActual == String.Empty && source.Proyecto_ProyectoSituacionActual == null) || (target.Proyecto_ProyectoSituacionActual == null && source.Proyecto_ProyectoSituacionActual == String.Empty)) && !source.Proyecto_ProyectoSituacionActual.Trim().Replace("\r", "").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace("\r", ""))) return false;
            //if ((source.Proyecto_ProyectoDescripcion == null) ? target.Proyecto_ProyectoDescripcion != null : !((target.Proyecto_ProyectoDescripcion == String.Empty && source.Proyecto_ProyectoDescripcion == null) || (target.Proyecto_ProyectoDescripcion == null && source.Proyecto_ProyectoDescripcion == String.Empty)) && !source.Proyecto_ProyectoDescripcion.Trim().Replace("\r", "").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace("\r", ""))) return false;
            //if ((source.Proyecto_ProyectoObservacion == null) ? target.Proyecto_ProyectoObservacion != null : !((target.Proyecto_ProyectoObservacion == String.Empty && source.Proyecto_ProyectoObservacion == null) || (target.Proyecto_ProyectoObservacion == null && source.Proyecto_ProyectoObservacion == String.Empty)) && !source.Proyecto_ProyectoObservacion.Trim().Replace("\r", "").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace("\r", ""))) return false;
            //if (!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado)) return false;
            //if ((source.Proyecto_IdProceso == null) ? (target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0) : !source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso)) return false;
            //if ((source.Proyecto_IdModalidadContratacion == null) ? (target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0) : !source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion)) return false;
            //if ((source.Proyecto_IdFinalidadFuncion == null) ? (target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0) : !source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion)) return false;
            //if ((source.Proyecto_IdOrganismoPrioridad == null) ? (target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0) : !source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad)) return false;
            //if ((source.Proyecto_SubPrioridad == null) ? (target.Proyecto_SubPrioridad.HasValue) : !source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad)) return false;
            //if (!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador)) return false;
            //if ((source.Proyecto_EsProyecto == null) ? (target.Proyecto_EsProyecto.HasValue) : !source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto)) return false;
            //if ((source.Proyecto_NroProyecto == null) ? (target.Proyecto_NroProyecto.HasValue) : !source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto)) return false;
            //if ((source.Proyecto_AnioCorriente == null) ? (target.Proyecto_AnioCorriente.HasValue) : !source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente)) return false;
            //if ((source.Proyecto_FechaInicioEjecucionCalculada == null) ? (target.Proyecto_FechaInicioEjecucionCalculada.HasValue) : !source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada)) return false;
            //if ((source.Proyecto_FechaFinEjecucionCalculada == null) ? (target.Proyecto_FechaFinEjecucionCalculada.HasValue) : !source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada)) return false;
            //if (!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta)) return false;
            //if (!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion)) return false;
            //if (!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion)) return false;
            //if ((source.Proyecto_IdProyectoPlan == null) ? (target.Proyecto_IdProyectoPlan.HasValue) : !source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan)) return false;
            //if (!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones)) return false;
            //if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
            //if ((source.ProyectoTipo_Sigla == null) ? target.ProyectoTipo_Sigla != null : !((target.ProyectoTipo_Sigla == String.Empty && source.ProyectoTipo_Sigla == null) || (target.ProyectoTipo_Sigla == null && source.ProyectoTipo_Sigla == String.Empty)) && !source.ProyectoTipo_Sigla.Trim().Replace("\r", "").Equals(target.ProyectoTipo_Sigla.Trim().Replace("\r", ""))) return false;
            //if ((source.ProyectoTipo_Nombre == null) ? target.ProyectoTipo_Nombre != null : !((target.ProyectoTipo_Nombre == String.Empty && source.ProyectoTipo_Nombre == null) || (target.ProyectoTipo_Nombre == null && source.ProyectoTipo_Nombre == String.Empty)) && !source.ProyectoTipo_Nombre.Trim().Replace("\r", "").Equals(target.ProyectoTipo_Nombre.Trim().Replace("\r", ""))) return false;
            //if (!source.ProyectoTipo_Activo.Equals(target.ProyectoTipo_Activo)) return false;
            //if ((source.ProyectoTipo_Tipo == null) ? target.ProyectoTipo_Tipo != null : !((target.ProyectoTipo_Tipo == String.Empty && source.ProyectoTipo_Tipo == null) || (target.ProyectoTipo_Tipo == null && source.ProyectoTipo_Tipo == String.Empty)) && !source.ProyectoTipo_Tipo.Trim().Replace("\r", "").Equals(target.ProyectoTipo_Tipo.Trim().Replace("\r", ""))) return false;

            return true;
        }
        #endregion
        #endregion


        public ProyectoCalidadResult GetCalidadActual(int idProyecto)
        {
            ProyectoCalidadResult rv = (from p in this.Context.Proyectos
                                        where p.IdProyecto == idProyecto
                                        select new ProyectoCalidadResult()
                                        {
                                            IdProyecto = p.IdProyecto,
                                            DenominacionSugerida = p.ProyectoDenominacion,
                                            IdProyectoTipo = p.IdTipoProyecto,
                                            IdEstadoSugerido = p.IdEstado,
                                            IdProceso = p.IdProceso,
                                            IdClasificacionFuncional = p.IdFinalidadFuncion
                                        }).SingleOrDefault();

            return rv;
        }

        protected override IQueryable<ProyectoCalidadResult> QueryResult(ProyectoCalidadFilter filter)
        {
            return QueryListado(filter);
        }

        public ListPaged<ProyectoCalidadResult> GetListadoExtendido(ProyectoCalidadFilter proyectoCalidadFilter)
        {
            ListPaged<ProyectoCalidadResult> rv = ListPaged<ProyectoCalidadResult>(QueryListado(proyectoCalidadFilter), proyectoCalidadFilter);

            #region Informacion a desnormalizar, necesaria para mostrar en la planilla de Excel

            List<ProyectoLocalizacion> pls = (from l in Context.ProyectoLocalizacions
                                              where (from i in rv select i.IdProyecto).Contains(l.IdProyecto)
                                              select l).ToList();

            List<ProyectoCalidadLocalizacion> pcls = (from l in Context.ProyectoCalidadLocalizacions
                                                      where (from i in rv select i.IdProyectoCalidad).Contains(l.IdProyectoCalidad)
                                                      select l).ToList();

            List<ClasificacionGeografica> cgs = (from g in Context.ClasificacionGeograficas 
                                                 where (from p in pls select p.IdClasificacionGeografica).Contains(g.IdClasificacionGeografica)
                                                    || (from c in pcls select c.IdClasificacionGeografica).Contains(g.IdClasificacionGeografica)
                                                 select g).ToList();
            
            foreach (ProyectoCalidadResult pcr in rv)
            {
                pcr.ProvinciasActual = (from l in pls
                                        join c in cgs on l.IdClasificacionGeografica equals c.IdClasificacionGeografica
                                        where l.IdProyecto == pcr.IdProyecto
                                        select new ProyectoCalidadProvinciaResult() { NombreProvincia = c.Nombre }).ToList();

                pcr.ProvinciasSugeridas = (from l in pcls
                                           join c in cgs on l.IdClasificacionGeografica equals c.IdClasificacionGeografica
                                           where l.IdProyectoCalidad == pcr.IdProyectoCalidad
                                           select new ProyectoCalidadProvinciaResult() { NombreProvincia = c.Nombre }).ToList();
            }
            #endregion

            return rv;
        }

        protected IQueryable<ProyectoCalidadResult> QueryListado(ProyectoCalidadFilter filter)
        {
            var query= (from p in this.Context.Proyectos
                    join t2 in this.Context.SubProgramas on p.IdSubPrograma equals t2.IdSubPrograma
                    join t3 in this.Context.Programas on t2.IdPrograma equals t3.IdPrograma
                    join t4 in this.Context.Safs on t3.IdSAF equals t4.IdSaf
                    //join _t5 in this.Context.ProyectoTipos on p.IdTipoProyecto equals _t5.IdProyectoTipo into tt5
                    //from t5 in tt5.DefaultIfEmpty()
                    join _t6 in this.Context.FinalidadFuncions on p.IdFinalidadFuncion equals _t6.IdFinalidadFuncion into tt6
                    from t6 in tt6.DefaultIfEmpty()
                    join _t7 in this.Context.Estados on p.IdEstado equals _t7.IdEstado into tt7
                    from t7 in tt7.DefaultIfEmpty()
                    join _t8 in this.Context.Procesos on p.IdProceso equals _t8.IdProceso into tt8
                    from t8 in tt8.DefaultIfEmpty()
                    join _t9 in this.Context.ProyectoPlans on p.IdProyectoPlan equals _t9.IdProyectoPlan into tt9
                    from t9 in tt9.DefaultIfEmpty()
                    join _t9b in this.Context.PlanPeriodos on t9.IdPlanPeriodo equals _t9b.IdPlanPeriodo into tt9b
                    from t9b in tt9b.DefaultIfEmpty()
                    join _t10 in this.Context.ProyectoCalidads on p.IdProyecto equals _t10.IdProyecto into tt10
                    from t10 in tt10.DefaultIfEmpty()
                    join _t11 in this.Context.Estados on t10.IdEstado equals _t11.IdEstado into tt11
                    from t11 in tt11.DefaultIfEmpty()
                    join _t12 in this.Context.PlanTipos on t9b.IdPlanTipo equals _t12.IdPlanTipo into tt12
                    from t12 in tt12.DefaultIfEmpty()
                    join _t13 in this.Context.PlanVersions on t9.IdPlanVersion equals _t13.IdPlanVersion into tt13
                    from t13 in tt13.DefaultIfEmpty()
                    join _t14 in this.Context.Estados on t10.IdEstadoSugerido equals _t14.IdEstado into tt14
                    from t14 in tt14.DefaultIfEmpty()
                    join _t15 in this.Context.Usuarios on t3.IdSectorialista equals _t15.IdUsuario into tt15
                    from t15 in tt15.DefaultIfEmpty()
                    join _t17 in this.Context.FinalidadFuncions on t10.IdClasificacionFuncional equals _t17.IdFinalidadFuncion into tt17
                    from t17 in tt6.DefaultIfEmpty()

                    where

                    (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == p.IdProyecto) &&
                    (filter.IdUsuarioModificacion == null || filter.IdUsuarioModificacion == t3.IdSectorialista) &&
                    (filter.IdSaf == null || filter.IdSaf == t4.IdSaf) &&
                    (filter.IdPrograma == null || filter.IdPrograma == t3.IdPrograma) &&
                    (filter.IdOrganismoTipo == null || filter.IdOrganismoTipo == t4.IdTipoOrganismo) &&
                    (filter.Estados == null || (filter.Estados != null && (filter.Estados.Count == 0 || filter.Estados.Contains(p.IdEstado)))) &&
                    (filter.Procesos == null || (filter.Procesos != null && (filter.Procesos.Count == 0 || (p.IdProceso != null && filter.Procesos.Contains((int)p.IdProceso))))) &&
                    (filter.EstadosCalidad == null || (filter.EstadosCalidad != null && (filter.EstadosCalidad.Count == 0 || filter.EstadosCalidad.Contains(t10.IdEstado)))) &&
                    (filter.IdProyectoTipo == null || filter.IdProyectoTipo == 0 || filter.IdProyectoTipo == p.IdTipoProyecto) &&
                    (filter.FechaEstado == null || t10.FechaEstado == null || filter.FechaEstado <= t10.FechaEstado) &&
                    (filter.FechaEstado_To == null || t10.FechaEstado == null || filter.FechaEstado_To >= t10.FechaEstado) &&
                    (filter.ProyectoActivo == null || filter.ProyectoActivo == p.Activo ) &&
                    (filter.ProyectoBorrador == null || filter.ProyectoBorrador == p.EsBorrador ) &&
                    (filter.Proyecto_Codigo == null || filter.Proyecto_Codigo == 0 || filter.Proyecto_Codigo == p.Codigo ) &&
                    (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || filter.IdPlanPeriodo != 0 || filter.IdPlanVersion != 0 ||
                            (from pp in this.Context.ProyectoPlans
                             where (from pt in this.Context.PlanTipos
                                    join pv in this.Context.PlanVersions on pt.IdPlanTipo equals pv.IdPlanTipo
                                    where pt.IdPlanTipo == filter.IdPlanTipo
                                    select pv.IdPlanVersion).Contains(pp.IdPlanVersion)
                             select pp.IdProyecto).Contains(p.IdProyecto) ||
                            (from pp in this.Context.ProyectoPlans
                             where (from pt in this.Context.PlanTipos
                                    join ppe in this.Context.PlanPeriodos on pt.IdPlanTipo equals ppe.IdPlanTipo
                                    where pt.IdPlanTipo == filter.IdPlanTipo
                                    select ppe.IdPlanPeriodo).Contains(pp.IdPlanPeriodo)
                             select pp.IdProyecto).Contains(p.IdProyecto)) &&
                    (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 ||
                            (from pp in this.Context.ProyectoPlans
                             where pp.IdPlanVersion == filter.IdPlanVersion
                             select pp.IdProyecto
                           ).Contains(p.IdProyecto)) &&
                    (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 ||
                            (from planPeriodo in this.Context.PlanPeriodos
                             join pp in this.Context.ProyectoPlans on planPeriodo.IdPlanPeriodo equals pp.IdPlanPeriodo
                             where planPeriodo.IdPlanPeriodo == filter.IdPlanPeriodo
                             select pp.IdProyecto
                           ).Contains(p.IdProyecto))
                    
                    orderby t4.Codigo, t3.Codigo, t2.Codigo, p.Codigo
                    select new ProyectoCalidadResult()
                    {
                        IdProyecto = p.IdProyecto
                        //,Proyecto_IdTipoProyecto = p.IdTipoProyecto
                        //,Proyecto_IdSubPrograma = p.IdSubPrograma
                        ,Proyecto_Codigo = p.Codigo
                        ,Proyecto_ProyectoDenominacion = p.ProyectoDenominacion
                        //,Proyecto_ProyectoSituacionActual = p.ProyectoSituacionActual
                        //,Proyecto_ProyectoDescripcion = p.ProyectoDescripcion
                        //,Proyecto_ProyectoObservacion = p.ProyectoObservacion
                        //,Proyecto_IdEstado = p.IdEstado
                        //,Proyecto_IdProceso = p.IdProceso
                        //,Proyecto_IdModalidadContratacion = p.IdModalidadContratacion
                        //,Proyecto_IdFinalidadFuncion = p.IdFinalidadFuncion
                        //,Proyecto_IdOrganismoPrioridad = p.IdOrganismoPrioridad
                        //,Proyecto_SubPrioridad = p.SubPrioridad
                        //,Proyecto_EsBorrador = p.EsBorrador
                        //,Proyecto_EsProyecto = p.EsProyecto
                        //,Proyecto_NroProyecto = p.NroProyecto
                        //,Proyecto_AnioCorriente = p.AnioCorriente
                        //,Proyecto_FechaInicioEjecucionCalculada = p.FechaInicioEjecucionCalculada
                        //,Proyecto_FechaFinEjecucionCalculada = p.FechaFinEjecucionCalculada
                        //,Proyecto_FechaAlta = p.FechaAlta
                        //,Proyecto_FechaModificacion = p.FechaModificacion
                        //,Proyecto_IdUsuarioModificacion = p.IdUsuarioModificacion
                        //,Proyecto_IdProyectoPlan = p.IdProyectoPlan
                        ,Estado_Descripcion = t11 != null ? t11.Nombre : EstadoEnum.Pendiente.ToString()
                        //,ProyectoTipo_Sigla = t5 != null ? (string)t5.Sigla : null
                        //,ProyectoTipo_Nombre = t5 != null ? (string)t5.Nombre : null
                        //,ProyectoTipo_Activo = t5 != null ? (bool?)t5.Activo : null
                        //,ProyectoTipo_Tipo = t5 != null ? (string)t5.Tipo : null
                        ,Proyecto_EstadoNombre = t7 != null ? (string)t7.Nombre : ""
                        ,Proyecto_FinalidadDenominacion = t6 != null ? (string)t6.Denominacion : ""
                        ,Proyecto_ProcesoNombre = t8 != null ? (string)t8.Nombre : ""
                        ,Proyecto_PlanNombre = t12 != null ? (string)t12.Sigla + "-" + t9b.Nombre + "-" + t13.Nombre : null
                        ,IdEstado = t10 != null ? t10.IdEstado : 0
                        ,IdProyectoCalidad = t10 != null ? t10.IdProyectoCalidad : 0
                        ,DenominacionSugerida = t10 != null ? t10.DenominacionSugerida : ""
                        ,DenominacionOriginal = t10 != null ? t10.DenominacionOriginal : ""
                        ,IdEstadoSugerido = t10 != null ? t10.IdEstadoSugerido : 0
                        ,IdProceso = t10 != null ? t10.IdProceso : 0
                        ,IdClasificacionFuncional = t10 != null ? t10.IdClasificacionFuncional : 0
                        ,IdProyectoTipo = t10 != null ? t10.IdProyectoTipo : 0
                        ,Comenatrio = t10 != null ? t10.Comenatrio : ""
                        ,FechaEstado = t10 != null ? t10.FechaEstado : null
                        ,ReqDictamen = t10 != null ? t10.ReqDictamen : false
                        ,DenominacionOK = t10 != null ? t10.DenominacionOK : false
                        ,FinalidadFuncionOk = t10 != null ? t10.FinalidadFuncionOk : false
                        ,ProcesoOk = t10 != null ? t10.ProcesoOk : false
                        ,EstadoSugerido = t10 != null ? t14.Nombre : ""
                        ,ProyectoTipoOk = t10 != null ? t10.ProyectoTipoOk : false
                        ,LocalizacionOK = t10 != null ? t10.LocalizacionOK : false
                        ,EstadoOK = t10 != null ? t10.EstadoOK : 0
                        //,Proceso_Nombre = t10 != null ? t16.Nombre : ""
                        ,ClasificacionFuncional_Denominacion = t10 != null ? t17.Denominacion : ""
                        ,Proyecto_Analista = t15 != null ? t15.Persona.NombreCompleto : ""
                        ,Proyecto_CodigoCompuesto = t4 != null && t3 != null && t2 != null ? t4.Codigo + "." + t3.Codigo + "." + t2.Codigo : ""
                    }
                    ).AsQueryable();
            return query;
        }

        public ProyectoCalidadResult GetCalidadSugerida(int idProyecto)
        {
            ProyectoCalidadResult rv = (from p in this.Context.Proyectos
                    join t2 in this.Context.SubProgramas on p.IdSubPrograma equals t2.IdSubPrograma
                    join t3 in this.Context.Programas on t2.IdPrograma equals t3.IdPrograma
                    join t4 in this.Context.Safs on t3.IdSAF equals t4.IdSaf
                    join _t5 in this.Context.ProyectoTipos on p.IdTipoProyecto equals _t5.IdProyectoTipo into tt5
                    from t5 in tt5.DefaultIfEmpty()
                    join _t6 in this.Context.FinalidadFuncions on p.IdFinalidadFuncion equals _t6.IdFinalidadFuncion into tt6
                    from t6 in tt6.DefaultIfEmpty()
                    join _t7 in this.Context.Estados on p.IdEstado equals _t7.IdEstado into tt7
                    from t7 in tt7.DefaultIfEmpty()
                    join _t8 in this.Context.Procesos on p.IdProceso equals _t8.IdProceso into tt8
                    from t8 in tt8.DefaultIfEmpty()
                    join _t9 in this.Context.ProyectoPlans on p.IdProyectoPlan equals _t9.IdProyectoPlan into tt9
                    from t9 in tt9.DefaultIfEmpty()
                    join _t9b in this.Context.PlanPeriodos on t9.IdPlanPeriodo equals _t9b.IdPlanPeriodo into tt9b
                    from t9b in tt9b.DefaultIfEmpty()
                    join _t10 in this.Context.ProyectoCalidads on p.IdProyecto equals _t10.IdProyecto into tt10
                    from t10 in tt10.DefaultIfEmpty()
                    join _t11 in this.Context.Estados on t10.IdEstado equals _t11.IdEstado into tt11
                    from t11 in tt11.DefaultIfEmpty()
                    join _t12 in this.Context.PlanTipos on t9b.IdPlanTipo equals _t12.IdPlanTipo into tt12
                    from t12 in tt12.DefaultIfEmpty()
                    join _t13 in this.Context.PlanVersions on t9.IdPlanVersion equals _t13.IdPlanVersion into tt13
                    from t13 in tt13.DefaultIfEmpty()

                    where p.IdProyecto == idProyecto

                    orderby t4.Codigo, t3.Codigo, t2.Codigo, p.Codigo
                    select new ProyectoCalidadResult()
                    {
                        IdProyecto = p.IdProyecto
                        //,Proyecto_IdTipoProyecto = p.IdTipoProyecto
                        //,Proyecto_IdSubPrograma = p.IdSubPrograma
                        ,Proyecto_Codigo = p.Codigo
                        ,Proyecto_ProyectoDenominacion = p.ProyectoDenominacion
                        //,Proyecto_ProyectoSituacionActual = p.ProyectoSituacionActual
                        //,Proyecto_ProyectoDescripcion = p.ProyectoDescripcion
                        //,Proyecto_ProyectoObservacion = p.ProyectoObservacion
                        //,Proyecto_IdEstado = p.IdEstado
                        //,Proyecto_IdProceso = p.IdProceso
                        //,Proyecto_IdModalidadContratacion = p.IdModalidadContratacion
                        //,Proyecto_IdFinalidadFuncion = p.IdFinalidadFuncion
                        //,Proyecto_IdOrganismoPrioridad = p.IdOrganismoPrioridad
                        //,Proyecto_SubPrioridad = p.SubPrioridad
                        //,Proyecto_EsBorrador = p.EsBorrador
                        //,Proyecto_EsProyecto = p.EsProyecto
                        //,Proyecto_NroProyecto = p.NroProyecto
                        //,Proyecto_AnioCorriente = p.AnioCorriente
                        //,Proyecto_FechaInicioEjecucionCalculada = p.FechaInicioEjecucionCalculada
                        //,Proyecto_FechaFinEjecucionCalculada = p.FechaFinEjecucionCalculada
                        //,Proyecto_FechaAlta = p.FechaAlta
                        //,Proyecto_FechaModificacion = p.FechaModificacion
                        //,Proyecto_IdUsuarioModificacion = p.IdUsuarioModificacion
                        //,Proyecto_IdProyectoPlan = p.IdProyectoPlan
                        ,Estado_Descripcion = t11 != null ? t11.Nombre : EstadoEnum.Pendiente.ToString()
                        //,ProyectoTipo_Sigla = t5 != null ? (string)t5.Sigla : null
                        //,ProyectoTipo_Nombre = t5 != null ? (string)t5.Nombre : null
                        //,ProyectoTipo_Activo = t5 != null ? (bool?)t5.Activo : null
                        //,ProyectoTipo_Tipo = t5 != null ? (string)t5.Tipo : null
                        ,Proyecto_EstadoNombre = t7 != null ? (string)t7.Nombre : ""
                        ,Proyecto_FinalidadDenominacion = t6 != null ? (string)t6.Denominacion : ""
                        ,Proyecto_ProcesoNombre = t8 != null ? (string)t8.Nombre : ""
                        ,Proyecto_PlanNombre = t12 != null ? (string)t12.Sigla + "-" + t9b.Nombre + "-" + t13.Nombre : null
                        ,IdEstado = t10 != null ? t10.IdEstado : 0
                        ,IdProyectoCalidad = t10 != null ? t10.IdProyectoCalidad : 0
                        ,DenominacionSugerida = t10 != null ? t10.DenominacionSugerida : ""
                        ,DenominacionOriginal = t10 != null ? t10.DenominacionOriginal : ""
                        ,IdEstadoSugerido = t10 != null ? t10.IdEstadoSugerido : 0
                        ,IdProceso = t10 != null ? t10.IdProceso : 0
                        ,IdClasificacionFuncional = t10 != null ? t10.IdClasificacionFuncional : 0
                        ,IdProyectoTipo = t10 != null ? t10.IdProyectoTipo : 0
                        ,Comenatrio = t10 != null ? t10.Comenatrio : ""
                        ,FechaEstado = t10 != null ? t10.FechaEstado : null
                        ,ReqDictamen = t10 != null ? t10.ReqDictamen : false
                        ,DenominacionOK = t10 != null ? t10.DenominacionOK : false
                        ,FinalidadFuncionOk = t10 != null ? t10.FinalidadFuncionOk : false
                        ,ProcesoOk = t10 != null ? t10.ProcesoOk : false
                        ,ProyectoTipoOk = t10 != null ? t10.ProyectoTipoOk : false
                        ,LocalizacionOK = t10 != null ? t10.LocalizacionOK : false
                        ,EstadoOK = t10 != null ? t10.EstadoOK : 0
                        ,Proyecto_CodigoCompuesto = t4 != null && t3 != null && t2 != null ? t4.Codigo + "." + t3.Codigo + "." + t2.Codigo : ""
                    }
                    ).SingleOrDefault();

            return rv;
        }

        public void CargarDatosExtra(ref DetalleCalidadCompose compose)
        {
            Int32 idProyecto = compose.IdProyecto;
            //Obtiene el ultimo plan - 1 del proyecto
            //Ojo revisar caso de uso
            var infoPlan = (from p in Context.Proyectos
                                  join pp in Context.ProyectoPlans on p.IdProyectoPlan equals pp.IdProyectoPlan
                                  join pe in Context.PlanPeriodos on pp.IdPlanPeriodo equals pe.IdPlanPeriodo
                                  join pv in Context.PlanVersions on pp.IdPlanVersion equals pv.IdPlanVersion
                                  join pt in Context.PlanTipos on pv.IdPlanTipo equals pt.IdPlanTipo                                  
                                  where p.IdProyecto == idProyecto
                                  select new 
                                  {
                                      Sigla = pt.Sigla,
                                      Plan = pt.Nombre, 
                                      Periodo = pe.Nombre,
                                      IdPlan = pp.IdProyectoPlan,
                                      Activo = pv.Activo,
                                      PlanPeriodo = pe.IdPlanPeriodo,
                                      Version = pv.Nombre

                                  }).ToList();
            Int32 idPlan = 0;
            if (infoPlan.Count > 0)
            {
                compose.UltimoPlan = infoPlan[0].Sigla + "-" + infoPlan[0].Periodo + "-" + infoPlan[0].Version;
                compose.ActivoUltimoPlan = infoPlan[0].Activo;
                compose.IdPeriodoUltimoPlan = infoPlan[0].PlanPeriodo;
                idPlan = infoPlan[0].IdPlan != 0 ? (int)infoPlan[0].IdPlan : 0;
            }

            var infoOrga = (from o in Context.Proyectos
                            where o.IdProyecto == idProyecto
                            select new 
                            {
                                Prioridad = o.OrganismoPrioridad.Nombre,
                                Subprioridad = o.SubPrioridad
                            }).ToList();

            if (infoOrga.Count > 0)
            {
                compose.PrioridadOrganismo = infoOrga[0].Prioridad;
                compose.SubPrioridad = infoOrga[0].Subprioridad.ToString();
            }
            
            // ultimo dictamen
            int enumDictaminado = (int)EstadoEnum.Dictaminado;
            var infodictamen = (from c in Context.ProyectoCalificacions
                                join d in Context.ProyectoDictamens on c.IdProyectoCalificacion equals d.IdProyectoCalificacion
                                join pds in Context.ProyectoDictamenSeguimientos on d.IdProyectoDictamen equals pds.IdProyectoDictamen
                                join psp in Context.ProyectoSeguimientoProyectos on pds.IdProyectoSeguimiento equals psp.IdProyectoSeguimiento
                                join e in Context.ProyectoDictamenEstados on d.IdProyectoDictamenEstadoUltimo equals e.IdProyectoDictamenEstado
                                join p in Context.PlanPeriodos on d.IdPlanPeriodo equals p.IdPlanPeriodo
                                //join l in Context.ProyectoPlans on p.IdPlanPeriodo equals l.IdPlanPeriodo
                                where psp.IdProyecto == idProyecto  && (d.FechaRepuesta != null || e.IdEstado== enumDictaminado) 
                                //&& l.IdProyectoPlan == idPlan
                                orderby p.AnioInicial descending
                                select new
                                {
                                    Nombre = c.Nombre,
                                    Numero = d.Numero
                                }).Take(1).ToList();

            if (infodictamen.Count > 0 && infodictamen[0].Nombre != "" &&  infodictamen[0].Numero != "")
                compose.Dictamen = infodictamen[0].Nombre + " [" + infodictamen[0].Numero + "]";

            // ultima Prioridades
            //Toma la prioridad del plan periodo mas actual.
            var infoprioridad = (from c in Context.ProyectoPrioridads
                                 join p in Context.PlanPeriodos on c.IdPlanPeriodo equals p.IdPlanPeriodo
                                 //join l in Context.ProyectoPlans on p.IdPlanPeriodo equals l.IdPlanPeriodo
                                 join d in Context.Prioridads on c.IdPrioridad equals d.IdPrioridad
                                 where c.IdProyecto == idProyecto //&& 
                                       //l.IdProyectoPlan == idPlan &&
                                       //c.IdProyecto == idProyecto 
                                 orderby p.AnioInicial descending
                                 select new
                                 {
                                     Sigla = d.Sigla,
                                     Nombre = d.Nombre,
                                     Art15 = c.ReqArt15,
                                     Periodo=p.Sigla
                                 }).Take (1).ToList();

            if (infoprioridad.Count > 0)
            {
                compose.UltPriorizacion = infoprioridad[0].Sigla + " " + infoprioridad[0].Nombre + "";
                compose.Art15 = infoprioridad[0].Art15 != null ? (bool)infoprioridad[0].Art15 : false;
                compose.UltPrioPeriodo = infoprioridad[0].Periodo ;
            }
        }
    }
}