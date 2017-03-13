using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EstadoService : EntityService<nc.Estado,nc.EstadoFilter,nc.EstadoResult,int>
    {        
		protected readonly EstadoBusiness Business = new EstadoBusiness();
        protected override IEntityBusiness<nc.Estado,nc.EstadoFilter,nc.EstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
