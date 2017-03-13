using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoFileResult : IResult<int> //_PrestamoFileResult
    {
        public virtual int ID { get { return IdPrestamoFile; } }
        public int IdPrestamoFile { get; set; }
        public int IdPrestamo { get; set; }
        public int IdFile { get; set; }

        public DateTime? File_Date { get; set; }
        public string File_FileType { get; set; }
        public string File_FileName { get; set; }        
        public bool? File_Checked { get; set; }
        public int Prestamo_IdPrograma { get; set; }
        public int Prestamo_Numero { get; set; }
        public string Prestamo_Denominacion { get; set; }
        public string Prestamo_Descripcion { get; set; }
        public string Prestamo_Observacion { get; set; }
        public DateTime Prestamo_FechaAlta { get; set; }
        public DateTime Prestamo_FechaModificacion { get; set; }
        public int Prestamo_IdUsuarioModificacion { get; set; }
        public int? Prestamo_IdEstadoActual { get; set; }

        public virtual PrestamoFile ToEntity()
        {
            PrestamoFile _PrestamoFile = new PrestamoFile();
            _PrestamoFile.IdPrestamoFile = this.IdPrestamoFile;
            _PrestamoFile.IdPrestamo = this.IdPrestamo;
            _PrestamoFile.IdFile = this.IdFile;

            return _PrestamoFile;
        }
        public virtual void Set(PrestamoFile entity)
        {
            this.IdPrestamoFile = entity.IdPrestamoFile;
            this.IdPrestamo = entity.IdPrestamo;
            this.IdFile = entity.IdFile;

        }
        public virtual bool Equals(PrestamoFile entity)
        {
            if (entity == null) return false;
            if (!entity.IdPrestamoFile.Equals(this.IdPrestamoFile)) return false;
            if (!entity.IdPrestamo.Equals(this.IdPrestamo)) return false;
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

        public bool Comparar(PrestamoFileResult target)
        {
            return this.IdPrestamoFile == target.IdPrestamoFile &&
                   this.IdPrestamo == target.IdPrestamo &&
                   this.IdFile == target.IdFile;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
