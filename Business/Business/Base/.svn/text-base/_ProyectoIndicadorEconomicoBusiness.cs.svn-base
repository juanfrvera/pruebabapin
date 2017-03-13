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
    public class _ProyectoIndicadorEconomicoBusiness : EntityBusiness<ProyectoIndicadorEconomico,ProyectoIndicadorEconomicoFilter,ProyectoIndicadorEconomicoResult,int>
    {        
		protected readonly ProyectoIndicadorEconomicoData Data = new ProyectoIndicadorEconomicoData();
        protected override IEntityData<ProyectoIndicadorEconomico,ProyectoIndicadorEconomicoFilter,ProyectoIndicadorEconomicoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoIndicadorEconomico() { IdProyectoIndicadorEconomico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoIndicadorEconomico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoIndicadorEconomico != default(int),"InvalidField", "ProyectoIndicadorEconomico");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoIndicadorEconomico != default(int),"InvalidField", "ProyectoIndicadorEconomico");

				break;
            }
        }   
		
    }	
}
