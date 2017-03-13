using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _AnioService : EntityService<nc.Anio,nc.AnioFilter,nc.AnioResult,int>
    {        
		protected readonly AnioBusiness Business = new AnioBusiness();
        protected override IEntityBusiness<nc.Anio,nc.AnioFilter,nc.AnioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
