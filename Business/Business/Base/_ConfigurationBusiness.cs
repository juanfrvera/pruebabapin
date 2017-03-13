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
    public class _ConfigurationBusiness : EntityBusiness<Configuration,ConfigurationFilter,ConfigurationResult,int>
    {        
		protected readonly ConfigurationData Data = new ConfigurationData();
        protected override IEntityData<Configuration,ConfigurationFilter,ConfigurationResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Configuration() { IdConfiguration = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Configuration entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdConfiguration != default(int),"InvalidField", "Configuration");
DataHelper.Validate(entity.IdConfigurationCategory != default(int),"InvalidField", "ConfigurationCategory");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 70,"FieldInvalidLength","Name");
DataHelper.Validate(entity.Code!=null,"FieldIsNull","Code");
DataHelper.Validate(entity.Code.Trim().Length <= 50,"FieldInvalidLength","Code");
DataHelper.Validate(entity.IdConfigurationCategory != default(int),"InvalidField", "ConfigurationCategory");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdConfiguration != default(int),"InvalidField", "Configuration");

				break;
            }
        }   
		
    }	
}
