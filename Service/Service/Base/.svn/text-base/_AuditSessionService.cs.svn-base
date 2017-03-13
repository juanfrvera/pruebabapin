using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _AuditSessionService : EntityService<nc.AuditSession,nc.AuditSessionFilter,nc.AuditSessionResult,int>
    {        
		protected readonly AuditSessionBusiness Business = new AuditSessionBusiness();
        protected override IEntityBusiness<nc.AuditSession,nc.AuditSessionFilter,nc.AuditSessionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
