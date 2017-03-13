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
    public class _ConfigurationCategoryBusiness : EntityBusiness<ConfigurationCategory,ConfigurationCategoryFilter,ConfigurationCategoryResult,int>
    {        
		protected readonly ConfigurationCategoryData Data = new ConfigurationCategoryData();
        protected override IEntityData<ConfigurationCategory,ConfigurationCategoryFilter,ConfigurationCategoryResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ConfigurationCategory() { IdConfigurationCategory = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ConfigurationCategory entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdConfigurationCategory != default(int),"InvalidField", "ConfigurationCategory");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdConfigurationCategory != default(int),"InvalidField", "ConfigurationCategory");
                DataHelper.ValidateForeignKey(entity.Configurations.Any(), "El registro no se puede eliminar porque tiene al menos una configuración asociada", "ConfigurationCategory");

				break;
            }
        }   
		
    }	
}
