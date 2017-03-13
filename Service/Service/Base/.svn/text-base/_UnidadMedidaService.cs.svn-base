using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _UnidadMedidaService : EntityService<nc.UnidadMedida,nc.UnidadMedidaFilter,nc.UnidadMedidaResult,int>
    {        
		protected readonly UnidadMedidaBusiness Business = new UnidadMedidaBusiness();
        protected override IEntityBusiness<nc.UnidadMedida,nc.UnidadMedidaFilter,nc.UnidadMedidaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
