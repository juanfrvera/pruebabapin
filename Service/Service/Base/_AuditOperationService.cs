using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _AuditOperationService : EntityService<nc.AuditOperation,nc.AuditOperationFilter,nc.AuditOperationResult,int>
    {        
		protected readonly AuditOperationBusiness Business = new AuditOperationBusiness();
        protected override IEntityBusiness<nc.AuditOperation,nc.AuditOperationFilter,nc.AuditOperationResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
