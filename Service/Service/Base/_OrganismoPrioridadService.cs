using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OrganismoPrioridadService : EntityService<nc.OrganismoPrioridad,nc.OrganismoPrioridadFilter,nc.OrganismoPrioridadResult,int>
    {        
		protected readonly OrganismoPrioridadBusiness Business = new OrganismoPrioridadBusiness();
        protected override IEntityBusiness<nc.OrganismoPrioridad,nc.OrganismoPrioridadFilter,nc.OrganismoPrioridadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
