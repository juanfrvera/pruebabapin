using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nc = Contract;
using nd = DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoShapeFileData : EntityData<ProyectoShapeFile, ProyectoShapeFileFilter, ProyectoShapeFileResult, int>
    {

        #region Context

        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }

        #endregion

        #region Get

        public override int GetId(nc.ProyectoShapeFile entity)
        {
            return entity.IdProyectoShapeFile;
        }

        public override ProyectoShapeFile GetByEntity(ProyectoShapeFile entity)
        {
            return this.GetById(entity.IdProyectoShapeFile);
        }

        public override ProyectoShapeFile GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoShapeFile == id select o).FirstOrDefault();
        }

        #endregion

        #region Query

        protected override IQueryable<ProyectoShapeFile> Query(ProyectoShapeFileFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdProyectoShapeFile == null || filter.IdProyectoShapeFile == 0 || o.IdProyectoShapeFile == filter.IdProyectoShapeFile)
                    && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                    && (filter.RutaArchivo == null || filter.RutaArchivo.Trim() == string.Empty || filter.RutaArchivo.Trim() == "%" || (filter.RutaArchivo.EndsWith("%") && filter.RutaArchivo.StartsWith("%") && (o.RutaArchivo.Contains(filter.RutaArchivo.Replace("%", "")))) || (filter.RutaArchivo.EndsWith("%") && o.RutaArchivo.StartsWith(filter.RutaArchivo.Replace("%", ""))) || (filter.RutaArchivo.StartsWith("%") && o.RutaArchivo.EndsWith(filter.RutaArchivo.Replace("%", ""))) || o.RutaArchivo == filter.RutaArchivo)
                    select o
                    ).AsQueryable();
        }

        protected override IQueryable<ProyectoShapeFileResult> QueryResult(ProyectoShapeFileFilter filter)
        {
            return (from o in Query(filter)
                    select new ProyectoShapeFileResult()
                    {
                        IdProyectoShapeFile = o.IdProyectoShapeFile
                        ,
                        IdProyecto = o.IdProyecto
                        ,
                        RutaArchivo = o.RutaArchivo

                    }
                      ).AsQueryable();
        }

        #endregion

        #region Copy

        public override nc.ProyectoShapeFile Copy(nc.ProyectoShapeFile entity)
        {
            nc.ProyectoShapeFile _new = new nc.ProyectoShapeFile();
            _new.IdProyecto = entity.IdProyecto;
            _new.RutaArchivo = entity.RutaArchivo;
            return _new;
        }

        public override int CopyAndSave(ProyectoShapeFile entity, string renameFormat)
        {
            ProyectoShapeFile newEntity = Copy(entity);
            newEntity.IdProyecto = newEntity.IdProyecto;
            newEntity.RutaArchivo = string.Format(renameFormat, newEntity.RutaArchivo);
            Add(newEntity);
            return GetId(newEntity);
        }

        #endregion

        #region Set

        public override void SetId(ProyectoShapeFile entity, int id)
        {
            entity.IdProyectoShapeFile = id;
        }

        public override void Set(ProyectoShapeFile source, ProyectoShapeFile target, bool hadSetId)
        {
            if (hadSetId)
                target.IdProyectoShapeFile = source.IdProyectoShapeFile;
            target.IdProyecto = source.IdProyecto;
            target.RutaArchivo = source.RutaArchivo;

        }

        public override void Set(ProyectoShapeFileResult source, ProyectoShapeFile target, bool hadSetId)
        {
            if (hadSetId)
                target.IdProyectoShapeFile = source.IdProyectoShapeFile;
            target.IdProyecto = source.IdProyecto;
            target.RutaArchivo = source.RutaArchivo;

        }

        public override void Set(ProyectoShapeFile source, ProyectoShapeFileResult target, bool hadSetId)
        {
            if (hadSetId)
                target.IdProyectoShapeFile = source.IdProyectoShapeFile;
            target.IdProyecto = source.IdProyecto;
            target.RutaArchivo = source.RutaArchivo;

        }

        public override void Set(ProyectoShapeFileResult source, ProyectoShapeFileResult target, bool hadSetId)
        {
            if (hadSetId)
                target.IdProyectoShapeFile = source.IdProyectoShapeFile;
            target.IdProyecto = source.IdProyecto;
            target.RutaArchivo = source.RutaArchivo;

        }

        #endregion

        #region Equals

        public override bool Equals(ProyectoShapeFile source, ProyectoShapeFile target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoShapeFile.Equals(target.IdProyectoShapeFile)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.RutaArchivo == null) ? target.RutaArchivo != null : !((target.RutaArchivo == String.Empty && source.RutaArchivo == null) || (target.RutaArchivo == null && source.RutaArchivo == String.Empty)) && !source.RutaArchivo.Trim().Replace("\r", "").Equals(target.RutaArchivo.Trim().Replace("\r", ""))) return false;
           
            return true;
        }

        public override bool Equals(ProyectoShapeFileResult source, ProyectoShapeFileResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoShapeFile.Equals(target.IdProyectoShapeFile)) return false;
            if (!source.IdProyecto.Equals(target.IdProyecto)) return false;
            if ((source.RutaArchivo == null) ? target.RutaArchivo != null : !((target.RutaArchivo == String.Empty && source.RutaArchivo == null) || (target.RutaArchivo == null && source.RutaArchivo == String.Empty)) && !source.RutaArchivo.Trim().Replace("\r", "").Equals(target.RutaArchivo.Trim().Replace("\r", ""))) return false;
            
            return true;
        }

        #endregion

    }
}
