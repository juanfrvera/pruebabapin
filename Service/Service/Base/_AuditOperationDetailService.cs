using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _AuditOperationDetailService : EntityService<nc.AuditOperationDetail,nc.AuditOperationDetailFilter,nc.AuditOperationDetailResult,int>
    {        
		protected readonly AuditOperationDetailBusiness Business = new AuditOperationDetailBusiness();
        protected override IEntityBusiness<nc.AuditOperationDetail,nc.AuditOperationDetailFilter,nc.AuditOperationDetailResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
