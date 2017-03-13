using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoSeguimientoEstadoService : EntityService<nc.ProyectoSeguimientoEstado,nc.ProyectoSeguimientoEstadoFilter,nc.ProyectoSeguimientoEstadoResult,int>
    {        
		protected readonly ProyectoSeguimientoEstadoBusiness Business = new ProyectoSeguimientoEstadoBusiness();
        protected override IEntityBusiness<nc.ProyectoSeguimientoEstado,nc.ProyectoSeguimientoEstadoFilter,nc.ProyectoSeguimientoEstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
