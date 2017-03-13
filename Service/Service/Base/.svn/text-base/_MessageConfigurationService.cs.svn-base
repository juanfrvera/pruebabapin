using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nc = Contract;

namespace Service.Base
{
    public class _MessageConfigurationService : EntityService<nc.MessageConfiguration, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int>
    {
        protected readonly MessageConfigurationBusiness Business = new MessageConfigurationBusiness();

        protected override IEntityBusiness<nc.MessageConfiguration, nc.MessageConfigurationFilter, nc.MessageConfigurationResult, int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
