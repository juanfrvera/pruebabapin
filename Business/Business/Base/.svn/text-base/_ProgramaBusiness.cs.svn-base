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
    public class _ProgramaBusiness : EntityBusiness<Programa, ProgramaFilter, ProgramaResult, int>
    {
        protected readonly ProgramaData Data = new ProgramaData();
        protected override IEntityData<Programa, ProgramaFilter, ProgramaResult, int> EntityData
        {
            get { return this.Data; }
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Programa() { IdPrograma = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.Programa entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdPrograma != default(int), "InvalidField", "Programa");
                        DataHelper.Validate(entity.IdSAF != default(int), "InvalidField", "SAF");

                    }
                    DataHelper.Validate(entity.IdSAF != default(int), "InvalidField", "SAF");
                    DataHelper.Validate(entity.Codigo != null, "FieldIsNull", "Codigo");
                    DataHelper.Validate(entity.Codigo.Trim().Length <= 3, "FieldInvalidLength", "Codigo");
                    DataHelper.Validate(entity.Nombre != null, "FieldIsNull", "Nombre");
                    DataHelper.Validate(entity.Nombre.Trim().Length <= 255, "FieldInvalidLength", "Nombre");
                    DataHelper.Validate(entity.FechaAlta > new DateTime(1900, 1, 1), "InvalidField", "FechaAlta");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdPrograma != default(int), "InvalidField", "Programa");
                    DataHelper.ValidateForeignKey(entity.SubProgramas.Any(), "El programa no se puede eliminar porque tiene al menos un sub programa asociado", "Programa");
                    DataHelper.ValidateForeignKey(entity.OficinaSafProgramas.Any(), "El programa no se puede eliminar porque tiene al menos un saf asociado", "Programa");
                    DataHelper.ValidateForeignKey(entity.Prestamos.Any(), "El programa no se puede eliminar porque tiene al menos un prestamo asociado", "Programa");
                    DataHelper.ValidateForeignKey(entity.ProgramaObjetivos.Any(), "El programa no se puede eliminar porque tiene al menos un objetivo asociado", "Programa");

                    break;
            }
        }

    }
}
