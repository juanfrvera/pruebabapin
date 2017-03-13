using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ObjetivoService : EntityService<nc.Objetivo,nc.ObjetivoFilter,nc.ObjetivoResult,int>
    {        
		protected readonly ObjetivoBusiness Business = new ObjetivoBusiness();
        protected override IEntityBusiness<nc.Objetivo,nc.ObjetivoFilter,nc.ObjetivoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
