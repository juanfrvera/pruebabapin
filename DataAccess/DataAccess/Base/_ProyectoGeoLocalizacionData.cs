using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoGeoLocalizacionData : EntityData<ProyectoGeoLocalizacion, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int>
    {
        #region Context

        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }

        #endregion

        #region Get

        public override int GetId(nc.ProyectoGeoLocalizacion entity)
        {
            return entity.IdGeoLocalizacion;
        }

        public override ProyectoGeoLocalizacion GetByEntity(ProyectoGeoLocalizacion entity)
        {
            return this.GetById(entity.IdGeoLocalizacion);
        }

        public override ProyectoGeoLocalizacion GetById(int id)
        {
            return (from o in this.Table where o.IdGeoLocalizacion == id select o).FirstOrDefault();
        }

        #endregion

        #region Query

        protected override IQueryable<ProyectoGeoLocalizacion> Query(ProyectoGeoLocalizacionFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdGeoLocalizacion == null || filter.IdGeoLocalizacion == 0 || o.IdGeoLocalizacion == filter.IdGeoLocalizacion)
                    && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                    && (filter.TipoLocalizacion == null || filter.TipoLocalizacion.Trim() == string.Empty || filter.TipoLocalizacion.Trim() == "%" || (filter.TipoLocalizacion.EndsWith("%") && filter.TipoLocalizacion.StartsWith("%") && (o.TipoLocalizacion.Contains(filter.TipoLocalizacion.Replace("%", "")))) || (filter.TipoLocalizacion.EndsWith("%") && o.TipoLocalizacion.StartsWith(filter.TipoLocalizacion.Replace("%", ""))) || (filter.TipoLocalizacion.StartsWith("%") && o.TipoLocalizacion.EndsWith(filter.TipoLocalizacion.Replace("%", ""))) || o.TipoLocalizacion == filter.TipoLocalizacion)
                    && (filter.InfoLocalizacion == null || filter.InfoLocalizacion.Trim() == string.Empty || filter.InfoLocalizacion.Trim() == "%" || (filter.InfoLocalizacion.EndsWith("%") && filter.InfoLocalizacion.StartsWith("%") && (o.InfoLocalizacion.Contains(filter.InfoLocalizacion.Replace("%", "")))) || (filter.InfoLocalizacion.EndsWith("%") && o.InfoLocalizacion.StartsWith(filter.InfoLocalizacion.Replace("%", ""))) || (filter.InfoLocalizacion.StartsWith("%") && o.InfoLocalizacion.EndsWith(filter.InfoLocalizacion.Replace("%", ""))) || o.InfoLocalizacion == filter.InfoLocalizacion)
                   
                    select o
                    ).AsQueryable();
        }

        protected override IQueryable<ProyectoGeoLocalizacionResult> QueryResult(ProyectoGeoLocalizacionFilter filter)
        {
            return (from o in Query(filter)
                    select new ProyectoGeoLocalizacionResult()
                    {
                        IdGeoLocalizacion = o.IdGeoLocalizacion
                        ,
                        IdProyecto = o.IdProyecto
                        ,
                        TipoLocalizacion = o.TipoLocalizacion
                        ,
                        InfoLocalizacion = o.InfoLocalizacion
                    }
                      ).AsQueryable();
        }

        #endregion

        #region Copy

        public override nc.ProyectoGeoLocalizacion Copy(nc.ProyectoGeoLocalizacion entity)
        {
            nc.ProyectoGeoLocalizacion _new = new nc.ProyectoGeoLocalizacion();
            _new.IdProyecto = entity.IdProyecto;
            _new.TipoLocalizacion = entity.TipoLocalizacion;
            _new.InfoLocalizacion = entity.InfoLocalizacion;
            return _new;
        }

        public override int CopyAndSave(ProyectoGeoLocalizacion entity, string renameFormat)
        {
            ProyectoGeoLocalizacion newEntity = Copy(entity);
            newEntity.IdProyecto = newEntity.IdProyecto;
            newEntity.TipoLocalizacion = string.Format(renameFormat, newEntity.TipoLocalizacion);
            newEntity.InfoLocalizacion = string.Format(renameFormat, newEntity.InfoLocalizacion);
            Add(newEntity);
            return GetId(newEntity);
        }

        #endregion

        #region Set

        public override void SetId(ProyectoGeoLocalizacion entity, int id)
        {
            entity.IdGeoLocalizacion = id;
        }

        public override void Set(ProyectoGeoLocalizacion source, ProyectoGeoLocalizacion target, bool hadSetId)
        {
            if (hadSetId)
                target.IdGeoLocalizacion = source.IdGeoLocalizacion;
            target.IdProyecto = source.IdProyecto;
            target.TipoLocalizacion = source.TipoLocalizacion;
            target.InfoLocalizacion = source.InfoLocalizacion;

        }

        public override void Set(ProyectoGeoLocalizacionResult source, ProyectoGeoLocalizacion target, bool hadSetId)
        {
            if (hadSetId)
                target.IdGeoLocalizacion = source.IdGeoLocalizacion;
            target.IdProyecto = source.IdProyecto;
            target.TipoLocalizacion = source.TipoLocalizacion;
            target.InfoLocalizacion = source.InfoLocalizacion;

        }

        public override void Set(ProyectoGeoLocalizacion source, ProyectoGeoLocalizacionResult target, bool hadSetId)
        {
            if (hadSetId)
                target.IdGeoLocalizacion = source.IdGeoLocalizacion;
            target.IdProyecto = source.IdProyecto;
            target.TipoLocalizacion = source.TipoLocalizacion;
            target.InfoLocalizacion = source.InfoLocalizacion;

        }

        public override void Set(ProyectoGeoLocalizacionResult source, ProyectoGeoLocalizacionResult target, bool hadSetId)
        {
            if (hadSetId)
                target.IdGeoLocalizacion = source.IdGeoLocalizacion;
            target.IdProyecto = source.IdProyecto;
            target.TipoLocalizacion = source.TipoLocalizacion;
            target.InfoLocalizacion = source.InfoLocalizacion;

        }

        #endregion

        #region Equals

        public override bool Equals(ProyectoGeoLocalizacion source, ProyectoGeoLocalizacion target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdGeoLocalizacion.Equals(target.IdGeoLocalizacion)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.TipoLocalizacion == null) ? target.TipoLocalizacion != null : !((target.TipoLocalizacion == String.Empty && source.TipoLocalizacion == null) || (target.TipoLocalizacion == null && source.TipoLocalizacion == String.Empty)) && !source.TipoLocalizacion.Trim().Replace("\r", "").Equals(target.TipoLocalizacion.Trim().Replace("\r", ""))) return false;
            if ((source.InfoLocalizacion == null) ? target.InfoLocalizacion != null : !((target.InfoLocalizacion == String.Empty && source.InfoLocalizacion == null) || (target.InfoLocalizacion == null && source.InfoLocalizacion == String.Empty)) && !source.InfoLocalizacion.Trim().Replace("\r", "").Equals(target.InfoLocalizacion.Trim().Replace("\r", ""))) return false;
           
            return true;
        }

        public override bool Equals(ProyectoGeoLocalizacionResult source, ProyectoGeoLocalizacionResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdGeoLocalizacion.Equals(target.IdGeoLocalizacion)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.TipoLocalizacion == null) ? target.TipoLocalizacion != null : !((target.TipoLocalizacion == String.Empty && source.TipoLocalizacion == null) || (target.TipoLocalizacion == null && source.TipoLocalizacion == String.Empty)) && !source.TipoLocalizacion.Trim().Replace("\r", "").Equals(target.TipoLocalizacion.Trim().Replace("\r", ""))) return false;
            if ((source.InfoLocalizacion == null) ? target.InfoLocalizacion != null : !((target.InfoLocalizacion == String.Empty && source.InfoLocalizacion == null) || (target.InfoLocalizacion == null && source.InfoLocalizacion == String.Empty)) && !source.InfoLocalizacion.Trim().Replace("\r", "").Equals(target.InfoLocalizacion.Trim().Replace("\r", ""))) return false;
           
            return true;
        }

        #endregion
    }
}
