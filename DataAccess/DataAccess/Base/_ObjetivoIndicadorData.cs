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
    public abstract class _ObjetivoIndicadorData : EntityData<ObjetivoIndicador, ObjetivoIndicadorFilter, ObjetivoIndicadorResult, int>
    {
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.ObjetivoIndicador entity)
        {
            return entity.IdObjetivoIndicador;
        }
        public override ObjetivoIndicador GetByEntity(ObjetivoIndicador entity)
        {
            return this.GetById(entity.IdObjetivoIndicador);
        }
        public override ObjetivoIndicador GetById(int id)
        {
            return (from o in this.Table where o.IdObjetivoIndicador == id select o).FirstOrDefault();
        }
        #endregion
        #region Query
        protected override IQueryable<ObjetivoIndicador> Query(ObjetivoIndicadorFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdObjetivoIndicador == null || o.IdObjetivoIndicador >= filter.IdObjetivoIndicador) && (filter.IdObjetivoIndicador_To == null || o.IdObjetivoIndicador <= filter.IdObjetivoIndicador_To)
                    && (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo == filter.IdObjetivo)
                    && (filter.IdIndicadorClase == null || filter.IdIndicadorClase == 0 || o.IdIndicadorClase == filter.IdIndicadorClase)
                    && (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador == filter.IdIndicador)
                    select o
                    ).AsQueryable();
        }
        protected override IQueryable<ObjetivoIndicadorResult> QueryResult(ObjetivoIndicadorFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.Indicadors on o.IdIndicador equals t1.IdIndicador
                    join t2 in this.Context.IndicadorClases on o.IdIndicadorClase equals t2.IdIndicadorClase
                    join t3 in this.Context.Objetivos on o.IdObjetivo equals t3.IdObjetivo
                    select new ObjetivoIndicadorResult()
                    {
                        IdObjetivoIndicador = o.IdObjetivoIndicador
                        ,
                        IdObjetivo = o.IdObjetivo
                        ,
                        IdIndicadorClase = o.IdIndicadorClase
                        ,
                        IdIndicador = o.IdIndicador
                        ,
                        Indicador_IdMedioVerificacion = t1.IdMedioVerificacion
                        ,
                        Indicador_Observacion = t1.Observacion
                        ,
                        IndicadorClase_IdIndicadorTipo = t2.IdIndicadorTipo
                        ,
                        IndicadorClase_Sigla = t2.Sigla
                        ,
                        IndicadorClase_Nombre = t2.Nombre
                        ,
                        IndicadorClase_IdUnidad = t2.IdUnidad
                        ,
                        IndicadorClase_RangoInicial = t2.RangoInicial
                        ,
                        IndicadorClase_RangoFinal = t2.RangoFinal
                        ,
                        IndicadorClase_Activo = t2.Activo
                        ,
                        Objetivo_Nombre = t3.Nombre
                    }
                      ).AsQueryable();
        }
        #endregion
        #region Copy
        public override nc.ObjetivoIndicador Copy(nc.ObjetivoIndicador entity)
        {
            nc.ObjetivoIndicador _new = new nc.ObjetivoIndicador();
            _new.IdObjetivo = entity.IdObjetivo;
            _new.IdIndicadorClase = entity.IdIndicadorClase;
            _new.IdIndicador = entity.IdIndicador;
            return _new;
        }
        public override int CopyAndSave(ObjetivoIndicador entity, string renameFormat)
        {
            ObjetivoIndicador newEntity = Copy(entity);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #region Set
        public override void SetId(ObjetivoIndicador entity, int id)
        {
            entity.IdObjetivoIndicador = id;
        }
        public override void Set(ObjetivoIndicador source, ObjetivoIndicador target, bool hadSetId)
        {
            if (hadSetId) target.IdObjetivoIndicador = source.IdObjetivoIndicador;
            target.IdObjetivo = source.IdObjetivo;
            target.IdIndicadorClase = source.IdIndicadorClase;
            target.IdIndicador = source.IdIndicador;

        }
        public override void Set(ObjetivoIndicadorResult source, ObjetivoIndicador target, bool hadSetId)
        {
            if (hadSetId) target.IdObjetivoIndicador = source.IdObjetivoIndicador;
            target.IdObjetivo = source.IdObjetivo;
            target.IdIndicadorClase = source.IdIndicadorClase;
            target.IdIndicador = source.IdIndicador;

        }
        public override void Set(ObjetivoIndicador source, ObjetivoIndicadorResult target, bool hadSetId)
        {
            if (hadSetId) target.IdObjetivoIndicador = source.IdObjetivoIndicador;
            target.IdObjetivo = source.IdObjetivo;
            target.IdIndicadorClase = source.IdIndicadorClase;
            target.IdIndicador = source.IdIndicador;

        }
        public override void Set(ObjetivoIndicadorResult source, ObjetivoIndicadorResult target, bool hadSetId)
        {
            if (hadSetId) target.IdObjetivoIndicador = source.IdObjetivoIndicador;
            target.IdObjetivo = source.IdObjetivo;
            target.IdIndicadorClase = source.IdIndicadorClase;
            target.IdIndicador = source.IdIndicador;
            target.Indicador_IdMedioVerificacion = source.Indicador_IdMedioVerificacion;
            target.IdIndicadorRubro = source.IdIndicadorRubro;
            target.DetalleMedioVerificacion = source.DetalleMedioVerificacion;
            target.Indicador_Observacion = source.Indicador_Observacion;
            target.IndicadorClase_IdIndicadorTipo = source.IndicadorClase_IdIndicadorTipo;
            target.IndicadorClase_Sigla = source.IndicadorClase_Sigla;
            target.IndicadorClase_Nombre = source.IndicadorClase_Nombre;
            target.IndicadorClase_IdUnidad = source.IndicadorClase_IdUnidad;
            target.IndicadorClase_RangoInicial = source.IndicadorClase_RangoInicial;
            target.IndicadorClase_RangoFinal = source.IndicadorClase_RangoFinal;
            target.IndicadorClase_Activo = source.IndicadorClase_Activo;
            target.Objetivo_Nombre = source.Objetivo_Nombre;

        }
        #endregion
        #region Equals
        public override bool Equals(ObjetivoIndicador source, ObjetivoIndicador target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdObjetivoIndicador.Equals(target.IdObjetivoIndicador)) return false;
            if (!source.IdObjetivo.Equals(target.IdObjetivo)) return false;
            if (!source.IdIndicadorClase.Equals(target.IdIndicadorClase)) return false;
            if (!source.IdIndicador.Equals(target.IdIndicador)) return false;

            return true;
        }
        public override bool Equals(ObjetivoIndicadorResult source, ObjetivoIndicadorResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdObjetivoIndicador.Equals(target.IdObjetivoIndicador)) return false;
            if (!source.IdObjetivo.Equals(target.IdObjetivo)) return false;
            if (!source.IdIndicadorClase.Equals(target.IdIndicadorClase)) return false;
            if (!source.IdIndicador.Equals(target.IdIndicador)) return false;
            if ((source.Indicador_IdMedioVerificacion == null) ? (target.Indicador_IdMedioVerificacion.HasValue && target.Indicador_IdMedioVerificacion.Value > 0) : !source.Indicador_IdMedioVerificacion.Equals(target.Indicador_IdMedioVerificacion)) return false;
            if ((source.Indicador_Observacion == null) ? target.Indicador_Observacion != null : !((target.Indicador_Observacion == String.Empty && source.Indicador_Observacion == null) || (target.Indicador_Observacion == null && source.Indicador_Observacion == String.Empty)) && !source.Indicador_Observacion.Trim().Replace("\r", "").Equals(target.Indicador_Observacion.Trim().Replace("\r", ""))) return false;
            if (!source.IndicadorClase_IdIndicadorTipo.Equals(target.IndicadorClase_IdIndicadorTipo)) return false;
            if ((source.IndicadorClase_Sigla == null) ? target.IndicadorClase_Sigla != null : !((target.IndicadorClase_Sigla == String.Empty && source.IndicadorClase_Sigla == null) || (target.IndicadorClase_Sigla == null && source.IndicadorClase_Sigla == String.Empty)) && !source.IndicadorClase_Sigla.Trim().Replace("\r", "").Equals(target.IndicadorClase_Sigla.Trim().Replace("\r", ""))) return false;
            if ((source.IndicadorClase_Nombre == null) ? target.IndicadorClase_Nombre != null : !((target.IndicadorClase_Nombre == String.Empty && source.IndicadorClase_Nombre == null) || (target.IndicadorClase_Nombre == null && source.IndicadorClase_Nombre == String.Empty)) && !source.IndicadorClase_Nombre.Trim().Replace("\r", "").Equals(target.IndicadorClase_Nombre.Trim().Replace("\r", ""))) return false;
            if (!source.IndicadorClase_IdUnidad.Equals(target.IndicadorClase_IdUnidad)) return false;
            if ((source.IndicadorClase_RangoInicial == null) ? (target.IndicadorClase_RangoInicial.HasValue) : !source.IndicadorClase_RangoInicial.Equals(target.IndicadorClase_RangoInicial)) return false;
            if ((source.IndicadorClase_RangoFinal == null) ? (target.IndicadorClase_RangoFinal.HasValue) : !source.IndicadorClase_RangoFinal.Equals(target.IndicadorClase_RangoFinal)) return false;
            if (!source.IndicadorClase_Activo.Equals(target.IndicadorClase_Activo)) return false;
            if ((source.Objetivo_Nombre == null) ? target.Objetivo_Nombre != null : !((target.Objetivo_Nombre == String.Empty && source.Objetivo_Nombre == null) || (target.Objetivo_Nombre == null && source.Objetivo_Nombre == String.Empty)) && !source.Objetivo_Nombre.Trim().Replace("\r", "").Equals(target.Objetivo_Nombre.Trim().Replace("\r", ""))) return false;

            return true;
        }
        #endregion
    }
}
