using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OficinaService : EntityService<nc.Oficina,nc.OficinaFilter,nc.OficinaResult,int>
    {        
		protected readonly OficinaBusiness Business = new OficinaBusiness();
        protected override IEntityBusiness<nc.Oficina,nc.OficinaFilter,nc.OficinaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
