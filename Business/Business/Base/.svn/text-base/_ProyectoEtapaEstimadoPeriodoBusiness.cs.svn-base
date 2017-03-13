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
    public class _ProyectoEtapaEstimadoPeriodoBusiness : EntityBusiness<ProyectoEtapaEstimadoPeriodo,ProyectoEtapaEstimadoPeriodoFilter,ProyectoEtapaEstimadoPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaEstimadoPeriodoData Data = new ProyectoEtapaEstimadoPeriodoData();
        protected override IEntityData<ProyectoEtapaEstimadoPeriodo,ProyectoEtapaEstimadoPeriodoFilter,ProyectoEtapaEstimadoPeriodoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaEstimadoPeriodo() { IdProyectoEtapaEstimadoPeriodo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaEstimadoPeriodo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaEstimadoPeriodo != default(int),"InvalidField", "ProyectoEtapaEstimadoPeriodo");
DataHelper.Validate(entity.IdProyectoEtapaEstimado != default(int),"InvalidField", "ProyectoEtapaEstimado");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapaEstimado != default(int),"InvalidField", "ProyectoEtapaEstimado");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaEstimadoPeriodo != default(int),"InvalidField", "ProyectoEtapaEstimadoPeriodo");

				break;
            }
        }   
		
    }	
}
