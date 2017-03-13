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
    public class _ParameterBusiness : EntityBusiness<Parameter,ParameterFilter,ParameterResult,int>
    {        
		protected readonly ParameterData Data = new ParameterData();
        protected override IEntityData<Parameter,ParameterFilter,ParameterResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Parameter() { IdParameter = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Parameter entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdParameter != default(int),"InvalidField", "Parameter");
DataHelper.Validate(entity.IdParameterCategory != default(int),"InvalidField", "ParameterCategory");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 70,"FieldInvalidLength","Name");
DataHelper.Validate(entity.Code!=null,"FieldIsNull","Code");
DataHelper.Validate(entity.Code.Trim().Length <= 50,"FieldInvalidLength","Code");
DataHelper.Validate(entity.IdParameterCategory != default(int),"InvalidField", "ParameterCategory");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdParameter != default(int),"InvalidField", "Parameter");

				break;
            }
        }   
		
    }	
}
