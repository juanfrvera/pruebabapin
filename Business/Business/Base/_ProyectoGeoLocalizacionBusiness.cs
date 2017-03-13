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
    public class _ProyectoGeoLocalizacionBusiness : EntityBusiness<ProyectoGeoLocalizacion, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int>
    {

        protected readonly ProyectoGeoLocalizacionData Data = new ProyectoGeoLocalizacionData();
       
        protected override IEntityData<ProyectoGeoLocalizacion, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int> EntityData
        {
            get { return this.Data; }
        }

        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoGeoLocalizacion() { IdGeoLocalizacion = id }, actionName, contextUser, args);
        }

        public override void Validate(nc.ProyectoGeoLocalizacion entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdGeoLocalizacion != default(int), "InvalidField", "ProyectoGeoLocalizacion");
                        DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "ProyectoGeoLocalizacion");

                    }
                    DataHelper.Validate(entity.TipoLocalizacion != null, "FieldIsNull", "TipoLocalizacion");
                    DataHelper.Validate(entity.TipoLocalizacion.Trim().Length <= 25, "FieldInvalidLength", "TipoLocalizacion");
                     DataHelper.Validate(entity.InfoLocalizacion != null, "FieldIsNull", "TipoLocalizacion");
                     DataHelper.Validate(entity.InfoLocalizacion.Trim().Length <= 1000, "FieldInvalidLength", "TipoLocalizacion");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdGeoLocalizacion != default(int), "InvalidField", "ProyectoGeoLocalizacion");
                  
                    break;
            }
        }

    }
}
