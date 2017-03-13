using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrioridadService : EntityService<nc.Prioridad,nc.PrioridadFilter,nc.PrioridadResult,int>
    {        
		protected readonly PrioridadBusiness Business = new PrioridadBusiness();
        protected override IEntityBusiness<nc.Prioridad,nc.PrioridadFilter,nc.PrioridadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
