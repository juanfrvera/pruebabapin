using Contract;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nc = Contract;

namespace Business.Base
{
    public class _ProyectoShapeFileBusiness : EntityBusiness<ProyectoShapeFile, ProyectoShapeFileFilter, ProyectoShapeFileResult, int>
    {
        protected readonly ProyectoShapeFileData Data = new ProyectoShapeFileData();

        protected override IEntityData<ProyectoShapeFile, ProyectoShapeFileFilter, ProyectoShapeFileResult, int> EntityData
        {
            get { return this.Data; }
        }

        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoShapeFile() { IdProyectoShapeFile = id }, actionName, contextUser, args);
        }

        public override void Validate(nc.ProyectoShapeFile entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdProyectoShapeFile != default(int), "InvalidField", "ProyectoShapeFile");
                        DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "ProyectoShapeFile");

                    }
                    DataHelper.Validate(entity.RutaArchivo != null, "FieldIsNull", "TipoLocalizacion");
                    DataHelper.Validate(entity.RutaArchivo.Trim().Length <= 1000, "FieldInvalidLength", "TipoLocalizacion");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdProyectoShapeFile != default(int), "InvalidField", "ProyectoShapeFile");

                    break;
            }
        }

    }
}
