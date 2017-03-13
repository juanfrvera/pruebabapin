using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MessageMediaService : EntityService<nc.MessageMedia,nc.MessageMediaFilter,nc.MessageMediaResult,int>
    {        
		protected readonly MessageMediaBusiness Business = new MessageMediaBusiness();
        protected override IEntityBusiness<nc.MessageMedia,nc.MessageMediaFilter,nc.MessageMediaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
