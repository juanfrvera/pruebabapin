using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaCommandService : EntityService<nc.SistemaCommand,nc.SistemaCommandFilter,nc.SistemaCommandResult,int>
    {        
		protected readonly SistemaCommandBusiness Business = new SistemaCommandBusiness();
        protected override IEntityBusiness<nc.SistemaCommand,nc.SistemaCommandFilter,nc.SistemaCommandResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
