using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract.Base
{
    [Serializable]
    public abstract class _ProyectoDictamenFileResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoDictamenFile; } }
        public int IdProyectoDictamenFile { get; set; }
        public int IdProyectoDictamen { get; set; }
        public int IdFile { get; set; }

        public DateTime? File_Date { get; set; }
        public string File_FileType { get; set; }
        public string File_FileName { get; set; }
        public byte[] File_Data { get; set; }
        public bool? File_Checked { get; set; }
        public string ProyectoDictamen_Expediente { get; set; }
        public int ProyectoDictamen_IDOrganismo { get; set; }
        public string ProyectoDictamen_OrganismoDetalle { get; set; }
        public string ProyectoDictamen_Denominacion { get; set; }
        public int ProyectoDictamen_IdGestionTipo { get; set; }
        public int ProyectoDictamen_IdOrganismoFinanciero { get; set; }
        public decimal? ProyectoDictamen_MontoTotal { get; set; }
        public decimal? ProyectoDictamen_MontoProyecto { get; set; }
        public decimal? ProyectoDictamen_MontoContraparteLocal { get; set; }
        public decimal? ProyectoDictamen_MontoOtros { get; set; }
        public int? ProyectoDictamen_IdAnalista { get; set; }
        public int? ProyectoDictamen_IdProyecto { get; set; }
        public int? ProyectoDictamen_IdProyectoDictamenRelacionado { get; set; }
        public string ProyectoDictamen_Comentario { get; set; }
        public int? ProyectoDictamen_IDProyectoCalificacion { get; set; }
        public DateTime? ProyectoDictamen_CalificacionFecha { get; set; }
        public string ProyectoDictamen_CalificacionITecnico { get; set; }
        public DateTime? ProyectoDictamen_CalificacionITFecha { get; set; }
        public string ProyectoDictamen_CalificacionNotaDNIP { get; set; }
        public string ProyectoDictamen_CalificacionObservacion { get; set; }
        public string ProyectoDictamen_CalificacionRecomendacion { get; set; }
        public DateTime ProyectoDictamen_FechaAlta { get; set; }
        public DateTime ProyectoDictamen_FechaModificacion { get; set; }
        public int ProyectoDictamen_IDUsuarioModificacion { get; set; }
        public int? ProyectoDictamen_IdEstado { get; set; }
        public DateTime? ProyectoDictamen_FechaEstado { get; set; }

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

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoDictamenFile", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("ProyectoDictamen","ProyectoDictamen_Expediente")
			,new DataColumnMapping("File","FileInfo_FileType")
			}));
        }
    }
}
