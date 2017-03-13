using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoDictamenEstadoService : EntityService<nc.PrestamoDictamenEstado,nc.PrestamoDictamenEstadoFilter,nc.PrestamoDictamenEstadoResult,int>
    {        
		protected readonly PrestamoDictamenEstadoBusiness Business = new PrestamoDictamenEstadoBusiness();
        protected override IEntityBusiness<nc.PrestamoDictamenEstado,nc.PrestamoDictamenEstadoFilter,nc.PrestamoDictamenEstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
