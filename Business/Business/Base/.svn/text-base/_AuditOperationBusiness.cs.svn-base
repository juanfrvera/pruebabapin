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
    public class _AuditOperationBusiness : EntityBusiness<AuditOperation,AuditOperationFilter,AuditOperationResult,int>
    {        
		protected readonly AuditOperationData Data = new AuditOperationData();
        protected override IEntityData<AuditOperation,AuditOperationFilter,AuditOperationResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.AuditOperation() { IdAuditOperation = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.AuditOperation entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdAuditOperation != default(int),"InvalidField", "AuditOperation");
DataHelper.Validate(entity.IdAuditSession != default(int),"InvalidField", "AuditSession");

                  }				
				DataHelper.Validate(entity.IdAuditSession != default(int),"InvalidField", "AuditSession");
DataHelper.Validate(entity.StartDate > new DateTime(1900,1,1) ,"InvalidField", "StartDate");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdAuditOperation != default(int),"InvalidField", "AuditOperation");
				break;
            }
        }   
		
    }	
}
