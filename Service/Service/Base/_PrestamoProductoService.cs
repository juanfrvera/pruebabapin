using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoProductoService : EntityService<nc.PrestamoProducto,nc.PrestamoProductoFilter,nc.PrestamoProductoResult,int>
    {        
		protected readonly PrestamoProductoBusiness Business = new PrestamoProductoBusiness();
        protected override IEntityBusiness<nc.PrestamoProducto,nc.PrestamoProductoFilter,nc.PrestamoProductoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
