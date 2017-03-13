using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ObjetivoSupuestoService : EntityService<nc.ObjetivoSupuesto,nc.ObjetivoSupuestoFilter,nc.ObjetivoSupuestoResult,int>
    {        
		protected readonly ObjetivoSupuestoBusiness Business = new ObjetivoSupuestoBusiness();
        protected override IEntityBusiness<nc.ObjetivoSupuesto,nc.ObjetivoSupuestoFilter,nc.ObjetivoSupuestoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
