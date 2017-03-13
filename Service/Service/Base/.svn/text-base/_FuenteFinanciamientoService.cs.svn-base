using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FuenteFinanciamientoService : EntityService<nc.FuenteFinanciamiento,nc.FuenteFinanciamientoFilter,nc.FuenteFinanciamientoResult,int>
    {        
		protected readonly FuenteFinanciamientoBusiness Business = new FuenteFinanciamientoBusiness();
        protected override IEntityBusiness<nc.FuenteFinanciamiento,nc.FuenteFinanciamientoFilter,nc.FuenteFinanciamientoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
