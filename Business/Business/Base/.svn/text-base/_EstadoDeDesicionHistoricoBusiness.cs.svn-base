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
    public class _EstadoDeDesicionHistoricoBusiness : EntityBusiness<EstadoDeDesicionHistorico, EstadoDeDesicionHistoricoFilter, EstadoDeDesicionHistoricoResult, int>
    {
        protected readonly EstadoDeDesicionHistoricoData Data = new EstadoDeDesicionHistoricoData();
        protected override IEntityData<EstadoDeDesicionHistorico, EstadoDeDesicionHistoricoFilter, EstadoDeDesicionHistoricoResult, int> EntityData
        {
            get { return this.Data; }
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EstadoDeDesicionHistorico() { IdEstadoDeDesicionHistorico = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.EstadoDeDesicionHistorico entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdEstadoDeDesicionHistorico != default(int), "InvalidField", "EstadoDeDesicionHistorico");
                        DataHelper.Validate(entity.IdEstadoDeDesicion != default(int), "InvalidField", "EstadoDeDesicion");
                        DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");
                        DataHelper.Validate(entity.IdUsuario != default(int), "InvalidField", "Usuario");

                    }
                    DataHelper.Validate(entity.IdEstadoDeDesicion != default(int), "InvalidField", "EstadoDeDesicion");
                    DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");
                    DataHelper.Validate(entity.Fecha > new DateTime(1900, 1, 1), "InvalidField", "Fecha");
                    DataHelper.Validate(entity.IdUsuario != default(int), "InvalidField", "Usuario");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdEstadoDeDesicionHistorico != default(int), "InvalidField", "EstadoDeDesicionHistorico");

                    break;
            }
        }

    }
}
