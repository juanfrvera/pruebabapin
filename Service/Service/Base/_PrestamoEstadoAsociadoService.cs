using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoEstadoAsociadoService : EntityService<nc.PrestamoEstadoAsociado,nc.PrestamoEstadoAsociadoFilter,nc.PrestamoEstadoAsociadoResult,int>
    {        
		protected readonly PrestamoEstadoAsociadoBusiness Business = new PrestamoEstadoAsociadoBusiness();
        protected override IEntityBusiness<nc.PrestamoEstadoAsociado,nc.PrestamoEstadoAsociadoFilter,nc.PrestamoEstadoAsociadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
