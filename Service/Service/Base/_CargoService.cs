using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _CargoService : EntityService<nc.Cargo,nc.CargoFilter,nc.CargoResult,int>
    {        
		protected readonly CargoBusiness Business = new CargoBusiness();
        protected override IEntityBusiness<nc.Cargo,nc.CargoFilter,nc.CargoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
