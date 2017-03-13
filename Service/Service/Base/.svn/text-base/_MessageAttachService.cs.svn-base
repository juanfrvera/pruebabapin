using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MessageAttachService : EntityService<nc.MessageAttach,nc.MessageAttachFilter,nc.MessageAttachResult,int>
    {        
		protected readonly MessageAttachBusiness Business = new MessageAttachBusiness();
        protected override IEntityBusiness<nc.MessageAttach,nc.MessageAttachFilter,nc.MessageAttachResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
