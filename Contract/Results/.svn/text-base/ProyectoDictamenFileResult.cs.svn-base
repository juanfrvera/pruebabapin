using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;

namespace Contract
{
    [Serializable]
    public class ProyectoDictamenFileResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoDictamenFile; } }
        public int IdProyectoDictamenFile { get; set; }
        public int IdProyectoDictamen { get; set; }
        public int IdFile { get; set; }

        public DateTime? File_Date { get; set; }
        public string File_FileType { get; set; }
        public string File_FileName { get; set; }
        public bool? File_Checked { get; set; }
        public string ProyectoDictamen_Denominacion { get; set; }
        public decimal ProyectoDictamen_MontoTotal { get; set; }
        public decimal ProyectoDictamen_MontoProyecto { get; set; }

        public virtual ProyectoDictamenFile ToEntity()
        {
            ProyectoDictamenFile _ProyectoDictamenFile = new ProyectoDictamenFile();
            _ProyectoDictamenFile.IdProyectoDictamenFile = this.IdProyectoDictamenFile;
            _ProyectoDictamenFile.IdProyectoDictamen = this.IdProyectoDictamen;
            _ProyectoDictamenFile.IdFile = this.IdFile;

            return _ProyectoDictamenFile;
        }
        public virtual void Set(ProyectoDictamenFile entity)
        {
            this.IdProyectoDictamenFile = entity.IdProyectoDictamenFile;
            this.IdProyectoDictamen = entity.IdProyectoDictamen;
            this.IdFile = entity.IdFile;

        }
        public virtual bool Equals(ProyectoDictamenFile entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoDictamenFile.Equals(this.IdProyectoDictamenFile)) return false;
            if (!entity.IdProyectoDictamen.Equals(this.IdProyectoDictamen)) return false;
            if (!entity.IdFile.Equals(this.IdFile)) return false;

            return true;
        }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Order
        {
            get
            {
                return ((DateTime)Fecha).Year.ToString() +
                       ((DateTime)Fecha).Month.ToString() +
                       (((DateTime)Fecha).Day < 10 ? "0" + ((DateTime)Fecha).Day.ToString() :
                                                           ((DateTime)Fecha).Day.ToString())
                       + Nombre;
            }
        }

        public bool Comparar(ProyectoDictamenFileResult target)
        {
            return this.IdProyectoDictamenFile == target.IdProyectoDictamenFile &&
                   this.IdProyectoDictamen == target.IdProyectoDictamen &&
                   this.IdFile == target.IdFile;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
