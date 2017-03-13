using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoProductoService : EntityService<nc.ProyectoProducto,nc.ProyectoProductoFilter,nc.ProyectoProductoResult,int>
    {        
		protected readonly ProyectoProductoBusiness Business = new ProyectoProductoBusiness();
        protected override IEntityBusiness<nc.ProyectoProducto,nc.ProyectoProductoFilter,nc.ProyectoProductoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
