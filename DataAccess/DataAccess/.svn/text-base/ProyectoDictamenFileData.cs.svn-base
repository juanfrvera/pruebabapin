using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoDictamenFileData : EntityData<ProyectoDictamenFile, ProyectoDictamenFileFilter, ProyectoDictamenFileResult, int>
    {
        #region Singleton
        private static volatile ProyectoDictamenFileData current;
        private static object syncRoot = new Object();

        //private ProyectoDictamenFileData() {}
        public static ProyectoDictamenFileData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoDictamenFileData();
                    }
                }
                return current;
            }
        }
        #endregion
        public override string IdFieldName { get { return "IdProyectoDictamenFile"; } }
        public List<ProyectoDictamenFileResult> GetWithFileInfo(Int32 IdProyectoDictamen)
        {
            return (from pf in this.Table
                    join f in this.Context.FileInfos
                    on pf.IdFile equals f.IdFile
                    select new ProyectoDictamenFileResult()
                    {
                        IdFile = pf.IdFile,
                        IdProyectoDictamen = pf.IdProyectoDictamen,
                        IdProyectoDictamenFile = pf.IdProyectoDictamenFile,
                        Fecha = (DateTime)f.Date,
                        Nombre = f.FileName
                    }).ToList();
        }
        #region Context
        public DataClassesDataContext Context
        {
            get { return LinqUtility.Context; }
        }
        #endregion
        #region Get
        public override int GetId(nc.ProyectoDictamenFile entity)
        {
            return entity.IdProyectoDictamenFile;
        }
        public override ProyectoDictamenFile GetByEntity(ProyectoDictamenFile entity)
        {
            return this.GetById(entity.IdProyectoDictamenFile);
        }
        public override ProyectoDictamenFile GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoDictamenFile == id select o).FirstOrDefault();
        }
        #endregion
        #region Query
        protected override IQueryable<ProyectoDictamenFile> Query(ProyectoDictamenFileFilter filter)
        {
            return (from o in this.Table
                    where (filter.IdProyectoDictamenFile == null || o.IdProyectoDictamenFile >= filter.IdProyectoDictamenFile) && (filter.IdProyectoDictamenFile_To == null || o.IdProyectoDictamenFile <= filter.IdProyectoDictamenFile_To)
                    && (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || o.IdProyectoDictamen == filter.IdProyectoDictamen)
                    && (filter.IdFile == null || filter.IdFile == 0 || o.IdFile == filter.IdFile)
                    select o
                    ).AsQueryable();
        }
        protected override IQueryable<ProyectoDictamenFileResult> QueryResult(ProyectoDictamenFileFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.FileInfos on o.IdFile equals t1.IdFile
                    join t2 in this.Context.ProyectoDictamens on o.IdProyectoDictamen equals t2.IdProyectoDictamen
                    select new ProyectoDictamenFileResult()
                    {
                        IdProyectoDictamenFile = o.IdProyectoDictamenFile
                        ,
                        IdProyectoDictamen = o.IdProyectoDictamen
                        ,
                        IdFile = o.IdFile
                        ,
                        File_Date = t1.Date
                        ,
                        File_FileType = t1.FileType
                        ,
                        File_FileName = t1.FileName
                            //,File_Data= t1.Data	
                        ,
                        File_Checked = t1.Checked
                        ,
                        ProyectoDictamen_Denominacion = t2.Denominacion
                    }
                      ).AsQueryable();
        }
        #endregion
        #region Copy
        public override nc.ProyectoDictamenFile Copy(nc.ProyectoDictamenFile entity)
        {
            nc.ProyectoDictamenFile _new = new nc.ProyectoDictamenFile();
            _new.IdProyectoDictamen = entity.IdProyectoDictamen;
            _new.IdFile = entity.IdFile;
            return _new;
        }
        #endregion
        #region Set
        public override void SetId(ProyectoDictamenFile entity, int id)
        {
            entity.IdProyectoDictamenFile = id;
        }
        public override void Set(ProyectoDictamenFile source, ProyectoDictamenFile target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamenFile = source.IdProyectoDictamenFile;
            target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdFile = source.IdFile;

        }
        public override void Set(ProyectoDictamenFileResult source, ProyectoDictamenFile target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamenFile = source.IdProyectoDictamenFile;
            target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdFile = source.IdFile;

        }
        public override void Set(ProyectoDictamenFile source, ProyectoDictamenFileResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamenFile = source.IdProyectoDictamenFile;
            target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdFile = source.IdFile;

        }
        public override void Set(ProyectoDictamenFileResult source, ProyectoDictamenFileResult target, bool hadSetId)
        {
            if (hadSetId) target.IdProyectoDictamenFile = source.IdProyectoDictamenFile;
            target.IdProyectoDictamen = source.IdProyectoDictamen;
            target.IdFile = source.IdFile;
            target.File_Date = source.File_Date;
            target.File_FileType = source.File_FileType;
            target.File_FileName = source.File_FileName;
            //target.File_Data= source.File_Data;	
            target.File_Checked = source.File_Checked;
            target.ProyectoDictamen_Denominacion = source.ProyectoDictamen_Denominacion;
            target.ProyectoDictamen_MontoTotal = source.ProyectoDictamen_MontoTotal;
            target.ProyectoDictamen_MontoProyecto = source.ProyectoDictamen_MontoProyecto;

        }
        #endregion
        #region Equals
        public override bool Equals(ProyectoDictamenFile source, ProyectoDictamenFile target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoDictamenFile.Equals(target.IdProyectoDictamenFile)) return false;
            if (!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen)) return false;
            if (!source.IdFile.Equals(target.IdFile)) return false;

            return true;
        }
        public override bool Equals(ProyectoDictamenFileResult source, ProyectoDictamenFileResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            if (!source.IdProyectoDictamenFile.Equals(target.IdProyectoDictamenFile)) return false;
            if (!source.IdProyectoDictamen.Equals(target.IdProyectoDictamen)) return false;
            if (!source.IdFile.Equals(target.IdFile)) return false;
            if ((source.File_Date == null) ? target.File_Date != null : !source.File_Date.Equals(target.File_Date)) return false;
            if (!source.File_FileType.Equals(target.File_FileType)) return false;
            if (!source.File_FileName.Equals(target.File_FileName)) return false;
            //if((source.File_Data == null)?target.File_Data!=null:!source.File_Data.Equals(target.File_Data))return false;
            if ((source.File_Checked == null) ? target.File_Checked != null : !source.File_Checked.Equals(target.File_Checked)) return false;
            if (!source.ProyectoDictamen_Denominacion.Equals(target.ProyectoDictamen_Denominacion)) return false;
            if (!source.ProyectoDictamen_MontoTotal.Equals(target.ProyectoDictamen_MontoTotal)) return false;
            if (!source.ProyectoDictamen_MontoProyecto.Equals(target.ProyectoDictamen_MontoProyecto)) return false;
            return true;
        }
        #endregion
    }
}
