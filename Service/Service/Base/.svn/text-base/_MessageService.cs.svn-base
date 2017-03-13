using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MessageService : EntityService<nc.Message,nc.MessageFilter,nc.MessageResult,int>
    {        
		protected readonly MessageBusiness Business = new MessageBusiness();
        protected override IEntityBusiness<nc.Message,nc.MessageFilter,nc.MessageResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
