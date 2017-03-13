using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoSeguimientoService : EntityService<nc.ProyectoSeguimiento,nc.ProyectoSeguimientoFilter,nc.ProyectoSeguimientoResult,int>
    {        
		protected readonly ProyectoSeguimientoBusiness Business = new ProyectoSeguimientoBusiness();
        protected override IEntityBusiness<nc.ProyectoSeguimiento,nc.ProyectoSeguimientoFilter,nc.ProyectoSeguimientoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
