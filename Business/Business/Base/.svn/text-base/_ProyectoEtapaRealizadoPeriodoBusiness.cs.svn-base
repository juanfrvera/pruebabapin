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
    public class _ProyectoEtapaRealizadoPeriodoBusiness : EntityBusiness<ProyectoEtapaRealizadoPeriodo,ProyectoEtapaRealizadoPeriodoFilter,ProyectoEtapaRealizadoPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaRealizadoPeriodoData Data = new ProyectoEtapaRealizadoPeriodoData();
        protected override IEntityData<ProyectoEtapaRealizadoPeriodo,ProyectoEtapaRealizadoPeriodoFilter,ProyectoEtapaRealizadoPeriodoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaRealizadoPeriodo() { IdProyectoEtapaRealizadoPeriodo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaRealizadoPeriodo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaRealizadoPeriodo != default(int),"InvalidField", "ProyectoEtapaRealizadoPeriodo");
DataHelper.Validate(entity.IdProyectoEtapaRealizado != default(int),"InvalidField", "ProyectoEtapaRealizado");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapaRealizado != default(int),"InvalidField", "ProyectoEtapaRealizado");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaRealizadoPeriodo != default(int),"InvalidField", "ProyectoEtapaRealizadoPeriodo");

				break;
            }
        }   
		
    }	
}
