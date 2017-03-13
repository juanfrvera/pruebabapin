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
    public class _AuditOperationDetailBusiness : EntityBusiness<AuditOperationDetail,AuditOperationDetailFilter,AuditOperationDetailResult,int>
    {        
		protected readonly AuditOperationDetailData Data = new AuditOperationDetailData();
        protected override IEntityData<AuditOperationDetail,AuditOperationDetailFilter,AuditOperationDetailResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.AuditOperationDetail() { IdOperationDetail = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.AuditOperationDetail entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOperationDetail != default(int),"InvalidField", "OperationDetail");
DataHelper.Validate(entity.IdAuditOperation != default(int),"InvalidField", "AuditOperation");

                  }				
				DataHelper.Validate(entity.IdAuditOperation != default(int),"InvalidField", "AuditOperation");
DataHelper.Validate(entity.StartDate > new DateTime(1900,1,1) ,"InvalidField", "StartDate");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOperationDetail != default(int),"InvalidField", "OperationDetail");

				break;
            }
        }   
		
    }	
}
