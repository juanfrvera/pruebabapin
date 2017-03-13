using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess.Base
{
    public abstract class _PrestamoProductoData : EntityData<PrestamoProducto, PrestamoProductoFilter, PrestamoProductoResult, int>
    {
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.PrestamoProducto entity)
        {
            return entity.IdPrestamoProducto;
        }
        public override PrestamoProducto GetByEntity(PrestamoProducto entity)
        {
            return this.GetById(entity.IdPrestamoProducto);
        }
        public override PrestamoProducto GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoProducto == id select o).FirstOrDefault();
        }
        #endregion
        #region Query
        protected override IQueryable<PrestamoProducto> Query(PrestamoProductoFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdPrestamoProducto == null || o.IdPrestamoProducto >= filter.IdPrestamoProducto) && (filter.IdPrestamoProducto_To == null || o.IdPrestamoProducto <= filter.IdPrestamoProducto_To)
                    && (filter.IdPrestamoComponente == null || filter.IdPrestamoComponente == 0 || o.IdPrestamoComponente == filter.IdPrestamoComponente)
                    && (filter.IdPrestamoSubComponente == null || filter.IdPrestamoSubComponente == 0 || o.IdPrestamoSubComponente == filter.IdPrestamoSubComponente)
                    && (filter.IdPrestamoSubComponenteIsNull == null || filter.IdPrestamoSubComponenteIsNull == true || o.IdPrestamoSubComponente != null) && (filter.IdPrestamoSubComponenteIsNull == null || filter.IdPrestamoSubComponenteIsNull == false || o.IdPrestamoSubComponente == null)
                    && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                    && (filter.MontoPrestamo == null || o.MontoPrestamo >= filter.MontoPrestamo) && (filter.MontoPrestamo_To == null || o.MontoPrestamo <= filter.MontoPrestamo_To)
                    && (filter.MontoContraparte == null || o.MontoContraparte >= filter.MontoContraparte) && (filter.MontoContraparte_To == null || o.MontoContraparte <= filter.MontoContraparte_To)
                    && (filter.InicioGestion == null || o.InicioGestion == filter.InicioGestion)
                    && (filter.InicioGestionIsNull == null || filter.InicioGestionIsNull == true || o.InicioGestion != null) && (filter.InicioGestionIsNull == null || filter.InicioGestionIsNull == false || o.InicioGestion == null)
                    && (filter.NegociarAutorizacion == null || o.NegociarAutorizacion == filter.NegociarAutorizacion)
                    && (filter.NegociarAutorizacionIsNull == null || filter.NegociarAutorizacionIsNull == true || o.NegociarAutorizacion != null) && (filter.NegociarAutorizacionIsNull == null || filter.NegociarAutorizacionIsNull == false || o.NegociarAutorizacion == null)
                    && (filter.Ejecucion == null || o.Ejecucion == filter.Ejecucion)
                    && (filter.EjecucionIsNull == null || filter.EjecucionIsNull == true || o.Ejecucion != null) && (filter.EjecucionIsNull == null || filter.EjecucionIsNull == false || o.Ejecucion == null)
                    && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                    && (filter.IdProyectoOrigenFinanciamiento == null || filter.IdProyectoOrigenFinanciamiento == 0 || o.IdProyectoOrigenFinanciamiento == filter.IdProyectoOrigenFinanciamiento)
                    && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == true || o.IdProyecto != null) && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == false || o.IdProyecto == null)
                    select o
                    ).AsQueryable();
        }
        protected override IQueryable<PrestamoProductoResult> QueryResult(PrestamoProductoFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t1.IdPrestamoComponente
                    join _t2 in this.Context.PrestamoSubComponentes on o.IdPrestamoSubComponente equals _t2.IdPrestamoSubComponente into tt2
                    from t2 in tt2.DefaultIfEmpty()
                    join _t3 in this.Context.Proyectos on o.IdProyecto equals _t3.IdProyecto into tt3
                    from t3 in tt3.DefaultIfEmpty()
                    select new PrestamoProductoResult()
                    {
                        IdPrestamoProducto = o.IdPrestamoProducto
                        ,
                        IdPrestamoComponente = o.IdPrestamoComponente
                        ,
                        IdPrestamoSubComponente = o.IdPrestamoSubComponente
                        ,
                        Descripcion = o.Descripcion
                        ,
                        MontoPrestamo = o.MontoPrestamo
                        ,
                        MontoContraparte = o.MontoContraparte
                        ,
                        InicioGestion = o.InicioGestion
                        ,
                        NegociarAutorizacion = o.NegociarAutorizacion
                        ,
                        Ejecucion = o.Ejecucion
                        ,
                        IdProyecto = o.IdProyecto
                        ,
                        IdProyectoOrigenFinanciamiento = o.IdProyectoOrigenFinanciamiento
                        ,
                        PrestamoComponente_IdPrestamo = t1.IdPrestamo
                        ,
                        PrestamoComponente_IdObjetivo = t1.IdObjetivo
                        ,
                        PrestamoSubComponente_IdPrestamoComponente = t2 != null ? (int?)t2.IdPrestamoComponente : null
                        ,
                        PrestamoSubComponente_Descripcion = t2 != null ? (string)t2.Descripcion : null
                        //,Proyecto_IdTipoProyecto= t3!=null?(int?)t3.IdTipoProyecto:null	
                        //,Proyecto_IdSubPrograma= t3!=null?(int?)t3.IdSubPrograma:null	
                        //,Proyecto_Codigo= t3!=null?(int?)t3.Codigo:null	
                        //,Proyecto_ProyectoDenominacion= t3!=null?(string)t3.ProyectoDenominacion:null	
                        //,Proyecto_ProyectoSituacionActual= t3!=null?(string)t3.ProyectoSituacionActual:null	
                        //,Proyecto_ProyectoDescripcion= t3!=null?(string)t3.ProyectoDescripcion:null	
                        //,Proyecto_ProyectoObservacion= t3!=null?(string)t3.ProyectoObservacion:null	
                        //,Proyecto_IdEstado= t3!=null?(int?)t3.IdEstado:null	
                        //,Proyecto_IdProceso= t3!=null?(int?)t3.IdProceso:null	
                        //,Proyecto_IdModalidadContratacion= t3!=null?(int?)t3.IdModalidadContratacion:null	
                        //,Proyecto_IdFinalidadFuncion= t3!=null?(int?)t3.IdFinalidadFuncion:null	
                        //,Proyecto_IdOrganismoPrioridad= t3!=null?(int?)t3.IdOrganismoPrioridad:null	
                        //,Proyecto_SubPrioridad= t3!=null?(int?)t3.SubPrioridad:null	
                        //,Proyecto_EsBorrador= t3!=null?(bool?)t3.EsBorrador:null	
                        //,Proyecto_EsProyecto= t3!=null?(bool?)t3.EsProyecto:null	
                        //,Proyecto_NroProyecto= t3!=null?(int?)t3.NroProyecto:null	
                        //,Proyecto_AnioCorriente= t3!=null?(int?)t3.AnioCorriente:null	
                        //,Proyecto_FechaInicioEjecucionCalculada= t3!=null?(DateTime?)t3.FechaInicioEjecucionCalculada:null	
                        //,Proyecto_FechaFinEjecucionCalculada= t3!=null?(DateTime?)t3.FechaFinEjecucionCalculada:null	
                        //,Proyecto_FechaAlta= t3!=null?(DateTime?)t3.FechaAlta:null	
                        //,Proyecto_FechaModificacion= t3!=null?(DateTime?)t3.FechaModificacion:null	
                        //,Proyecto_IdUsuarioModificacion= t3!=null?(int?)t3.IdUsuarioModificacion:null	
                        //,Proyecto_IdProyectoPlan= t3!=null?(int?)t3.IdProyectoPlan:null	
                        //,Proyecto_EvaluarValidaciones= t3!=null?(bool?)t3.EvaluarValidaciones:null	
                        //,Proyecto_Activo= t3!=null?(bool?)t3.Activo:null	
                    }
                      ).AsQueryable();
        }
        #endregion
        #region Copy
        public override nc.PrestamoProducto Copy(nc.PrestamoProducto entity)
        {
            nc.PrestamoProducto _new = new nc.PrestamoProducto();
            _new.IdPrestamoComponente = entity.IdPrestamoComponente;
            _new.IdPrestamoSubComponente = entity.IdPrestamoSubComponente;
            _new.Descripcion = entity.Descripcion;
            _new.MontoPrestamo = entity.MontoPrestamo;
            _new.MontoContraparte = entity.MontoContraparte;
            _new.InicioGestion = entity.InicioGestion;
            _new.NegociarAutorizacion = entity.NegociarAutorizacion;
            _new.Ejecucion = entity.Ejecucion;
            _new.IdProyecto = entity.IdProyecto;
            _new.IdProyectoOrigenFinanciamiento = entity.IdProyectoOrigenFinanciamiento;
            return _new;
        }
        public override int CopyAndSave(PrestamoProducto entity, string renameFormat)
        {
            PrestamoProducto newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat, newEntity.Descripcion);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(PrestamoProducto entity, int id)
        {
            entity.IdPrestamoProducto = id;
        }
        public override void Set(PrestamoProducto source, PrestamoProducto target, bool hadSetId)
        {
            if (hadSetId) target.IdPrestamoProducto = source.IdPrestamoProducto;
            target.IdPrestamoComponente = source.IdPrestamoComponente;
            target.IdPrestamoSubComponente = source.IdPrestamoSubComponente;
            target.Descripcion = source.Descripcion;
            target.MontoPrestamo = source.MontoPrestamo;
            target.MontoContraparte = source.MontoContraparte;
            target.InicioGestion = source.InicioGestion;
            target.NegociarAutorizacion = source.NegociarAutorizacion;
            target.Ejecucion = source.Ejecucion;
            target.IdProyecto = source.IdProyecto;
            target.IdProyectoOrigenFinanciamiento = source.IdProyectoOrigenFinanciamiento;

        }
        public override void Set(PrestamoProductoResult source, PrestamoProducto target, bool hadSetId)
        {
            if (hadSetId) target.IdPrestamoProducto = source.IdPrestamoProducto;
            target.IdPrestamoComponente = source.IdPrestamoComponente;
            target.IdPrestamoSubComponente = source.IdPrestamoSubComponente;
            target.Descripcion = source.Descripcion;
            target.MontoPrestamo = source.MontoPrestamo;
            target.MontoContraparte = source.MontoContraparte;
            target.InicioGestion = source.InicioGestion;
            target.NegociarAutorizacion = source.NegociarAutorizacion;
            target.Ejecucion = source.Ejecucion;
            target.IdProyecto = source.IdProyecto;
            target.IdProyectoOrigenFinanciamiento = (source.IdProyectoOrigenFinanciamiento.HasValue) ? source.IdProyectoOrigenFinanciamiento.Value : 0;

        }
        public override void Set(PrestamoProducto source, PrestamoProductoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdPrestamoProducto = source.IdPrestamoProducto;
            target.IdPrestamoComponente = source.IdPrestamoComponente;
            target.IdPrestamoSubComponente = source.IdPrestamoSubComponente;
            target.Descripcion = source.Descripcion;
            target.MontoPrestamo = source.MontoPrestamo;
            target.MontoContraparte = source.MontoContraparte;
            target.InicioGestion = source.InicioGestion;
            target.NegociarAutorizacion = source.NegociarAutorizacion;
            target.Ejecucion = source.Ejecucion;
            target.IdProyecto = source.IdProyecto;
            target.IdProyectoOrigenFinanciamiento = source.IdProyectoOrigenFinanciamiento;

        }
        public override void Set(PrestamoProductoResult source, PrestamoProductoResult target, bool hadSetId)
        {
            if (hadSetId) target.IdPrestamoProducto = source.IdPrestamoProducto;
            target.IdPrestamoComponente = source.IdPrestamoComponente;
            target.IdPrestamoSubComponente = source.IdPrestamoSubComponente;
            target.Descripcion = source.Descripcion;
            target.MontoPrestamo = source.MontoPrestamo;
            target.MontoContraparte = source.MontoContraparte;
            target.InicioGestion = source.InicioGestion;
            target.NegociarAutorizacion = source.NegociarAutorizacion;
            target.Ejecucion = source.Ejecucion;
            target.IdProyecto = source.IdProyecto;
            target.PrestamoComponente_IdPrestamo = source.PrestamoComponente_IdPrestamo;
            target.PrestamoComponente_IdObjetivo = source.PrestamoComponente_IdObjetivo;
            target.PrestamoSubComponente_IdPrestamoComponente = source.PrestamoSubComponente_IdPrestamoComponente;
            target.PrestamoSubComponente_Descripcion = source.PrestamoSubComponente_Descripcion;
            target.IdProyectoOrigenFinanciamiento = (source.IdProyectoOrigenFinanciamiento.HasValue) ? source.IdProyectoOrigenFinanciamiento.Value : 0;
            //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
            //target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
            //target.Proyecto_Codigo= source.Proyecto_Codigo;	
            //target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
            //target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
            //target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
            //target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
            //target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
            //target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
            //target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
            //target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
            //target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
            //target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
            //target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
            //target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
            //target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
            //target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
            //target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
            //target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
            //target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
            //target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
            //target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
            //target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
            //target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
            //target.Proyecto_Activo= source.Proyecto_Activo;	

        }
        #endregion
        #region Equals
        public override bool Equals(PrestamoProducto source, PrestamoProducto target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdPrestamoProducto.Equals(target.IdPrestamoProducto)) return false;
            if (!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente)) return false;
            if ((source.IdPrestamoSubComponente == null) ? (target.IdPrestamoSubComponente.HasValue && target.IdPrestamoSubComponente.Value > 0) : !source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente)) return false;
            if ((source.Descripcion == null) ? target.Descripcion != null : !((target.Descripcion == String.Empty && source.Descripcion == null) || (target.Descripcion == null && source.Descripcion == String.Empty)) && !source.Descripcion.Trim().Replace("\r", "").Equals(target.Descripcion.Trim().Replace("\r", ""))) return false;
            if (!source.MontoPrestamo.Equals(target.MontoPrestamo)) return false;
            if (!source.MontoContraparte.Equals(target.MontoContraparte)) return false;
            if ((source.InicioGestion == null) ? (target.InicioGestion.HasValue) : !source.InicioGestion.Equals(target.InicioGestion)) return false;
            if ((source.NegociarAutorizacion == null) ? (target.NegociarAutorizacion.HasValue) : !source.NegociarAutorizacion.Equals(target.NegociarAutorizacion)) return false;
            if ((source.Ejecucion == null) ? (target.Ejecucion.HasValue) : !source.Ejecucion.Equals(target.Ejecucion)) return false;
            if ((source.IdProyecto == null) ? (target.IdProyecto.HasValue && target.IdProyecto.Value > 0) : !source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.IdProyectoOrigenFinanciamiento == null) ? (target.IdProyectoOrigenFinanciamiento > 0) : !source.IdProyectoOrigenFinanciamiento.Equals(target.IdProyectoOrigenFinanciamiento)) return false;

            return true;
        }
        public override bool Equals(PrestamoProductoResult source, PrestamoProductoResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdPrestamoProducto.Equals(target.IdPrestamoProducto)) return false;
            if (!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente)) return false;
            if ((source.IdPrestamoSubComponente == null) ? (target.IdPrestamoSubComponente.HasValue && target.IdPrestamoSubComponente.Value > 0) : !source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente)) return false;
            if ((source.Descripcion == null) ? target.Descripcion != null : !((target.Descripcion == String.Empty && source.Descripcion == null) || (target.Descripcion == null && source.Descripcion == String.Empty)) && !source.Descripcion.Trim().Replace("\r", "").Equals(target.Descripcion.Trim().Replace("\r", ""))) return false;
            if (!source.MontoPrestamo.Equals(target.MontoPrestamo)) return false;
            if (!source.MontoContraparte.Equals(target.MontoContraparte)) return false;
            if ((source.InicioGestion == null) ? (target.InicioGestion.HasValue) : !source.InicioGestion.Equals(target.InicioGestion)) return false;
            if ((source.NegociarAutorizacion == null) ? (target.NegociarAutorizacion.HasValue) : !source.NegociarAutorizacion.Equals(target.NegociarAutorizacion)) return false;
            if ((source.Ejecucion == null) ? (target.Ejecucion.HasValue) : !source.Ejecucion.Equals(target.Ejecucion)) return false;
            if ((source.IdProyecto == null) ? (target.IdProyecto.HasValue && target.IdProyecto.Value > 0) : !source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.IdProyectoOrigenFinanciamiento == null) ? (target.IdProyectoOrigenFinanciamiento.HasValue && target.IdProyectoOrigenFinanciamiento.Value > 0) : !source.IdProyectoOrigenFinanciamiento.Equals(target.IdProyectoOrigenFinanciamiento)) return false;
            if (!source.PrestamoComponente_IdPrestamo.Equals(target.PrestamoComponente_IdPrestamo)) return false;
            if (!source.PrestamoComponente_IdObjetivo.Equals(target.PrestamoComponente_IdObjetivo)) return false;
            if (!source.PrestamoSubComponente_IdPrestamoComponente.Equals(target.PrestamoSubComponente_IdPrestamoComponente)) return false;
            if ((source.PrestamoSubComponente_Descripcion == null) ? target.PrestamoSubComponente_Descripcion != null : !((target.PrestamoSubComponente_Descripcion == String.Empty && source.PrestamoSubComponente_Descripcion == null) || (target.PrestamoSubComponente_Descripcion == null && source.PrestamoSubComponente_Descripcion == String.Empty)) && !source.PrestamoSubComponente_Descripcion.Trim().Replace("\r", "").Equals(target.PrestamoSubComponente_Descripcion.Trim().Replace("\r", ""))) return false;
            //   if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
            //if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
            //if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
            //if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
            //   if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
            //   if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
            //   if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
            //   if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
            //if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
            //                if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
            //                if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
            //                if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
            //                if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
            //   if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
            //if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
            //   if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
            //   if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
            //   if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
            //   if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
            //   if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
            //if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
            //if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
            //if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
            //   if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
            //if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;

            return true;
        }
        #endregion
    }
}
