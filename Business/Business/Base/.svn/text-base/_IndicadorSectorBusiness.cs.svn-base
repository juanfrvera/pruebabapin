using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _IndicadorSectorBusiness : EntityBusiness<IndicadorSector,IndicadorSectorFilter,IndicadorSectorResult,int>
    {        
		protected readonly IndicadorSectorData Data = new IndicadorSectorData();
        protected override IEntityData<IndicadorSector,IndicadorSectorFilter,IndicadorSectorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return Can(new nc.IndicadorSector() { IdIndicadorSector = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorSector entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorSector != default(int),"InvalidFiled", "IndicadorSector");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 20,"FiledInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorSector != default(int),"InvalidFiled", "IndicadorSector");

				break;
            }
        }   
		
    }	
}
