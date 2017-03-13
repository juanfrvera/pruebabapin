using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoAlcanceGeograficoService : EntityService<nc.PrestamoAlcanceGeografico,nc.PrestamoAlcanceGeograficoFilter,nc.PrestamoAlcanceGeograficoResult,int>
    {        
		protected readonly PrestamoAlcanceGeograficoBusiness Business = new PrestamoAlcanceGeograficoBusiness();
        protected override IEntityBusiness<nc.PrestamoAlcanceGeografico,nc.PrestamoAlcanceGeograficoFilter,nc.PrestamoAlcanceGeograficoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
