using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionGeograficaTipoService : EntityService<nc.ClasificacionGeograficaTipo,nc.ClasificacionGeograficaTipoFilter,nc.ClasificacionGeograficaTipoResult,int>
    {        
		protected readonly ClasificacionGeograficaTipoBusiness Business = new ClasificacionGeograficaTipoBusiness();
        protected override IEntityBusiness<nc.ClasificacionGeograficaTipo,nc.ClasificacionGeograficaTipoFilter,nc.ClasificacionGeograficaTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
