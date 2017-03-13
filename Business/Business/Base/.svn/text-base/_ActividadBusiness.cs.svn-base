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
    public class _ActividadBusiness : EntityBusiness<Actividad, ActividadFilter, ActividadResult, int>
    {
        protected readonly ActividadData Data = new ActividadData();
        protected override IEntityData<Actividad, ActividadFilter, ActividadResult, int> EntityData
        {
            get { return this.Data; }
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Actividad() { IdActividad = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.Actividad entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdActividad != default(int), "InvalidField", "Actividad");

                    }
                    DataHelper.Validate(entity.Nombre != null, "FieldIsNull", "Nombre");
                    DataHelper.Validate(entity.Nombre.Trim().Length <= 50, "FieldInvalidLength", "Nombre");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdActividad != default(int), "InvalidField", "Actividad");
                    DataHelper.ValidateForeignKey(entity.ActividadPermisos.Any(), "El registro no se puede eliminar porque tiene al menos un permiso asociado", "Actividad");
                    DataHelper.ValidateForeignKey(entity.PerfilActividads.Any(), "El registro no se puede eliminar porque tiene al menos un perfil asociado", "Actividad");

                    break;
            }
        }

    }
}
