using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EtapaService : EntityService<nc.Etapa,nc.EtapaFilter,nc.EtapaResult,int>
    {        
		protected readonly EtapaBusiness Business = new EtapaBusiness();
        protected override IEntityBusiness<nc.Etapa,nc.EtapaFilter,nc.EtapaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
