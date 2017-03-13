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
    public class _ParameterCategoryBusiness : EntityBusiness<ParameterCategory,ParameterCategoryFilter,ParameterCategoryResult,int>
    {        
		protected readonly ParameterCategoryData Data = new ParameterCategoryData();
        protected override IEntityData<ParameterCategory,ParameterCategoryFilter,ParameterCategoryResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ParameterCategory() { IdParameterCategoty = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ParameterCategory entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdParameterCategoty != default(int),"InvalidField", "ParameterCategoty");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 70,"FieldInvalidLength","Name");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdParameterCategoty != default(int),"InvalidField", "ParameterCategoty");

				break;
            }
        }   
		
    }	
}
