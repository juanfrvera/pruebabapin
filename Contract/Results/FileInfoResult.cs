using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class FileInfoResult : IResult<int>
    {
        public virtual int ID { get { return IdFile; } }
        public int IdFile { get; set; }
        public DateTime? Date { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        //public byte[] Data { get; set; }
        public bool? Checked { get; set; }


        public virtual FileInfo ToEntity()
        {
            FileInfo _FileInfo = new FileInfo();
            _FileInfo.IdFile = this.IdFile;
            _FileInfo.Date = this.Date;
            _FileInfo.FileType = this.FileType;
            _FileInfo.FileName = this.FileName;
            //_FileInfo.Data = this.Data;
            _FileInfo.Checked = this.Checked;

            return _FileInfo;
        }
        public virtual void Set(FileInfo entity)
        {
            this.IdFile = entity.IdFile;
            this.Date = entity.Date;
            this.FileType = entity.FileType;
            this.FileName = entity.FileName;
            //this.Data= entity.Data ;
            this.Checked = entity.Checked;

        }
        public virtual bool Equals(FileInfo entity)
        {
            if (entity == null) return false;
            if (!entity.IdFile.Equals(this.IdFile)) return false;
            if ((entity.Date == null) ? this.Date != null : !entity.Date.Equals(this.Date)) return false;
            if ((entity.FileType == null) ? this.FileType != null : !entity.FileType.Equals(this.FileType)) return false;
            if ((entity.FileName == null) ? this.FileName != null : !entity.FileName.Equals(this.FileName)) return false;
            //if((entity.Data == null)?this.Data!=null:!entity.Data.Equals(this.Data))return false;
            if ((entity.Checked == null) ? this.Checked != null : !entity.Checked.Equals(this.Checked)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
