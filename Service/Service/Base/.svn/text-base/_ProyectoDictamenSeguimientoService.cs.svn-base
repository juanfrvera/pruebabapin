using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoDictamenSeguimientoService : EntityService<nc.ProyectoDictamenSeguimiento,nc.ProyectoDictamenSeguimientoFilter,nc.ProyectoDictamenSeguimientoResult,int>
    {        
		protected readonly ProyectoDictamenSeguimientoBusiness Business = new ProyectoDictamenSeguimientoBusiness();
        protected override IEntityBusiness<nc.ProyectoDictamenSeguimiento,nc.ProyectoDictamenSeguimientoFilter,nc.ProyectoDictamenSeguimientoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
