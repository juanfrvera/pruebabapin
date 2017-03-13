using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoDictamenFileResult :  IResult<int>//_PrestamoDictamenFileResult
    {
        public virtual int ID { get { return IdPrestamoDictamenFile; } }
        public int IdPrestamoDictamenFile { get; set; }
        public int IdPrestamoDictamen { get; set; }
        public int IdFile { get; set; }

        public DateTime? File_Date { get; set; }
        public string File_FileType { get; set; }
        public string File_FileName { get; set; }
        public bool? File_Checked { get; set; }
        public string PrestamoDictamen_Expediente { get; set; }
        public int PrestamoDictamen_IDOrganismo { get; set; }
        public string PrestamoDictamen_OrganismoDetalle { get; set; }
        public string PrestamoDictamen_Denominacion { get; set; }
        public int PrestamoDictamen_IdGestionTipo { get; set; }
        public int PrestamoDictamen_IdOrganismoFinanciero { get; set; }
        public decimal PrestamoDictamen_MontoTotal { get; set; }
        public decimal PrestamoDictamen_MontoPrestamo { get; set; }
        public int? PrestamoDictamen_IdAnalista { get; set; }
        public int? PrestamoDictamen_IdPrestamo { get; set; }
        public int? PrestamoDictamen_IdPrestamoDictamenRelacionado { get; set; }
        public string PrestamoDictamen_Comentario { get; set; }
        public int? PrestamoDictamen_IDPrestamoCalificacion { get; set; }
        public DateTime? PrestamoDictamen_CalificacionFecha { get; set; }
        public string PrestamoDictamen_CalificacionITecnico { get; set; }
        public DateTime? PrestamoDictamen_CalificacionITFecha { get; set; }
        public string PrestamoDictamen_CalificacionNotaDNIP { get; set; }
        public string PrestamoDictamen_CalificacionObservacion { get; set; }
        public string PrestamoDictamen_CalificacionRecomendacion { get; set; }
        public DateTime PrestamoDictamen_FechaAlta { get; set; }
        public DateTime PrestamoDictamen_FechaModificacion { get; set; }
        public int PrestamoDictamen_IDUsuarioModificacion { get; set; }

        public virtual PrestamoDictamenFile ToEntity()
        {
            PrestamoDictamenFile _PrestamoDictamenFile = new PrestamoDictamenFile();
            _PrestamoDictamenFile.IdPrestamoDictamenFile = this.IdPrestamoDictamenFile;
            _PrestamoDictamenFile.IdPrestamoDictamen = this.IdPrestamoDictamen;
            _PrestamoDictamenFile.IdFile = this.IdFile;

            return _PrestamoDictamenFile;
        }
        public virtual void Set(PrestamoDictamenFile entity)
        {
            this.IdPrestamoDictamenFile = entity.IdPrestamoDictamenFile;
            this.IdPrestamoDictamen = entity.IdPrestamoDictamen;
            this.IdFile = entity.IdFile;

        }
        public virtual bool Equals(PrestamoDictamenFile entity)
        {
            if (entity == null) return false;
            if (!entity.IdPrestamoDictamenFile.Equals(this.IdPrestamoDictamenFile)) return false;
            if (!entity.IdPrestamoDictamen.Equals(this.IdPrestamoDictamen)) return false;
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

        public bool Comparar(PrestamoDictamenFileResult target)
        {
            return this.IdPrestamoDictamenFile == target.IdPrestamoDictamenFile &&
                   this.IdPrestamoDictamen == target.IdPrestamoDictamen &&
                   this.IdFile == target.IdFile;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
