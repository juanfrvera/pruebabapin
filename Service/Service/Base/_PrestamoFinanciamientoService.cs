using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoFinanciamientoService : EntityService<nc.PrestamoFinanciamiento,nc.PrestamoFinanciamientoFilter,nc.PrestamoFinanciamientoResult,int>
    {        
		protected readonly PrestamoFinanciamientoBusiness Business = new PrestamoFinanciamientoBusiness();
        protected override IEntityBusiness<nc.PrestamoFinanciamiento,nc.PrestamoFinanciamientoFilter,nc.PrestamoFinanciamientoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
