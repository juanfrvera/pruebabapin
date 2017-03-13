using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoEstadoService : EntityService<nc.PrestamoEstado,nc.PrestamoEstadoFilter,nc.PrestamoEstadoResult,int>
    {        
		protected readonly PrestamoEstadoBusiness Business = new PrestamoEstadoBusiness();
        protected override IEntityBusiness<nc.PrestamoEstado,nc.PrestamoEstadoFilter,nc.PrestamoEstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
