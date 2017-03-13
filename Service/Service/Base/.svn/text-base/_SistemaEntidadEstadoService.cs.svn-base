using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaEntidadEstadoService : EntityService<nc.SistemaEntidadEstado,nc.SistemaEntidadEstadoFilter,nc.SistemaEntidadEstadoResult,int>
    {        
		protected readonly SistemaEntidadEstadoBusiness Business = new SistemaEntidadEstadoBusiness();
        protected override IEntityBusiness<nc.SistemaEntidadEstado,nc.SistemaEntidadEstadoFilter,nc.SistemaEntidadEstadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
