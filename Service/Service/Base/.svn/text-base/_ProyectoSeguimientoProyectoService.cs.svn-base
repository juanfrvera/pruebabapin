using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoSeguimientoProyectoService : EntityService<nc.ProyectoSeguimientoProyecto,nc.ProyectoSeguimientoProyectoFilter,nc.ProyectoSeguimientoProyectoResult,int>
    {        
		protected readonly ProyectoSeguimientoProyectoBusiness Business = new ProyectoSeguimientoProyectoBusiness();
        protected override IEntityBusiness<nc.ProyectoSeguimientoProyecto,nc.ProyectoSeguimientoProyectoFilter,nc.ProyectoSeguimientoProyectoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
