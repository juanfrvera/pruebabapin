using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MessageSendService : EntityService<nc.MessageSend,nc.MessageSendFilter,nc.MessageSendResult,int>
    {        
		protected readonly MessageSendBusiness Business = new MessageSendBusiness();
        protected override IEntityBusiness<nc.MessageSend,nc.MessageSendFilter,nc.MessageSendResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
