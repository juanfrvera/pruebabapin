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
    public class _ProyectoFinBusiness : EntityBusiness<ProyectoFin,ProyectoFinFilter,ProyectoFinResult,int>
    {        
		protected readonly ProyectoFinData Data = new ProyectoFinData();
        protected override IEntityData<ProyectoFin,ProyectoFinFilter,ProyectoFinResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoFin() { IdProyectoFin = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoFin entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoFin != default(int),"InvalidField", "ProyectoFin");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProgramaObjetivo != default(int),"InvalidField", "ProgramaObjetivo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProgramaObjetivo != default(int),"InvalidField", "ProgramaObjetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoFin != default(int),"InvalidField", "ProyectoFin");

				break;
            }
        }   
		
    }	
}
