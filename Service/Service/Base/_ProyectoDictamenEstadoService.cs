using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoDictamenEstadoService : EntityService<nc.ProyectoDictamenEstado,nc.ProyectoDictamenEstadoFilter,nc.ProyectoDictamenEstadoResult,int>
    {        
		protected readonly ProyectoDictamenEstadoBusiness Business = new ProyectoDictamenEstadoBusiness();
        protected override IEntityBusiness<nc.ProyectoDictamenEstado,nc.ProyectoDictamenEstadoFilter,nc.ProyectoDictamenEstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
