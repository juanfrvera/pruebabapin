using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FaseService : EntityService<nc.Fase,nc.FaseFilter,nc.FaseResult,int>
    {        
		protected readonly FaseBusiness Business = new FaseBusiness();
        protected override IEntityBusiness<nc.Fase,nc.FaseFilter,nc.FaseResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
