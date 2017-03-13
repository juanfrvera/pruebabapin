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
    public class _AuditSessionBusiness : EntityBusiness<AuditSession,AuditSessionFilter,AuditSessionResult,int>
    {        
		protected readonly AuditSessionData Data = new AuditSessionData();
        protected override IEntityData<AuditSession,AuditSessionFilter,AuditSessionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.AuditSession() { IdAuditSession = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.AuditSession entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdAuditSession != default(int),"InvalidField", "AuditSession");

                  }				
				DataHelper.Validate(entity.UserName!=null,"FieldIsNull","UserName");
DataHelper.Validate(entity.UserName.Trim().Length <= 100,"FieldInvalidLength","UserName");
DataHelper.Validate(entity.SessionId!=null,"FieldIsNull","Session");
DataHelper.Validate(entity.SessionId.Trim().Length <= 50,"FieldInvalidLength","Session");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdAuditSession != default(int),"InvalidField", "AuditSession");

				break;
            }
        }   
		
    }	
}
