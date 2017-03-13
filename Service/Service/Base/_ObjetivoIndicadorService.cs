using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ObjetivoIndicadorService : EntityService<nc.ObjetivoIndicador,nc.ObjetivoIndicadorFilter,nc.ObjetivoIndicadorResult,int>
    {        
		protected readonly ObjetivoIndicadorBusiness Business = new ObjetivoIndicadorBusiness();
        protected override IEntityBusiness<nc.ObjetivoIndicador,nc.ObjetivoIndicadorFilter,nc.ObjetivoIndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
