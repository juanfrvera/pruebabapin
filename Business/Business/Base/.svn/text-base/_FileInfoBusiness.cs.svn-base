using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc = Contract;

namespace Business.Base
{
    public class _FileInfoBusiness : EntityBusiness<FileInfo, FileInfoFilter, FileInfoResult, int>
    {
        protected readonly FileInfoData Data = new FileInfoData();
        protected override IEntityData<FileInfo, FileInfoFilter, FileInfoResult, int> EntityData
        {
            get { return this.Data; }
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.FileInfo() { IdFile = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.FileInfo entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdFile != default(int), "InvalidField", "File");

                    }

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdFile != default(int), "InvalidField", "File");
                    DataHelper.ValidateForeignKey(entity.PrestamoDictamenFiles.Any(), "El registro no se puede eliminar porque tiene al menos un dictamen de prestamo asociado", "File");
                    DataHelper.ValidateForeignKey(entity.PrestamoFiles.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "File");
                    DataHelper.ValidateForeignKey(entity.ProyectoFiles.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "File");
                    DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoFiles.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de proyecto asociado", "File");

                    break;
            }
        }

    }
}
