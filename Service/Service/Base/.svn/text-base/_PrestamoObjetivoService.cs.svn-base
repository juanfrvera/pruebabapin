using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoObjetivoService : EntityService<nc.PrestamoObjetivo,nc.PrestamoObjetivoFilter,nc.PrestamoObjetivoResult,int>
    {        
		protected readonly PrestamoObjetivoBusiness Business = new PrestamoObjetivoBusiness();
        protected override IEntityBusiness<nc.PrestamoObjetivo,nc.PrestamoObjetivoFilter,nc.PrestamoObjetivoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
