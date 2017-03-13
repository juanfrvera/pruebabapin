using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _ProyectoDictamenFileBusiness : EntityBusiness<ProyectoDictamenFile, ProyectoDictamenFileFilter, ProyectoDictamenFileResult, int>
    {
        protected readonly ProyectoDictamenFileData Data = new ProyectoDictamenFileData();
        protected override IEntityData<ProyectoDictamenFile, ProyectoDictamenFileFilter, ProyectoDictamenFileResult, int> EntityData
        {
            get { return this.Data; }
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoDictamenFile() { IdProyectoDictamenFile = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.ProyectoDictamenFile entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdProyectoDictamenFile != default(int), "InvalidField", "ProyectoDictamenFile");
                        DataHelper.Validate(entity.IdProyectoDictamen != default(int), "InvalidField", "ProyectoDictamen");
                        DataHelper.Validate(entity.IdFile != default(int), "InvalidField", "File");

                    }
                    DataHelper.Validate(entity.IdProyectoDictamen != default(int), "InvalidField", "ProyectoDictamen");
                    DataHelper.Validate(entity.IdFile != default(int), "InvalidField", "File");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdProyectoDictamenFile != default(int), "InvalidField", "ProyectoDictamenFile");

                    break;
            }
        }
    }
}
