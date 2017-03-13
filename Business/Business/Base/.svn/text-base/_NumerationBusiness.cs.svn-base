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
    public class _NumerationBusiness : EntityBusiness<Numeration,NumerationFilter,NumerationResult,int>
    {        
		protected readonly NumerationData Data = new NumerationData();
        protected override IEntityData<Numeration,NumerationFilter,NumerationResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Numeration() { IdNumeration = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Numeration entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdNumeration != default(int),"InvalidField", "Numeration");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdNumeration != default(int),"InvalidField", "Numeration");

				break;
            }
        }   
		
    }	
}
