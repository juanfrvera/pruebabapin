using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaEntidadService : EntityService<nc.SistemaEntidad,nc.SistemaEntidadFilter,nc.SistemaEntidadResult,int>
    {        
		protected readonly SistemaEntidadBusiness Business = new SistemaEntidadBusiness();
        protected override IEntityBusiness<nc.SistemaEntidad,nc.SistemaEntidadFilter,nc.SistemaEntidadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
