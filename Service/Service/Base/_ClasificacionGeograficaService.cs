using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionGeograficaService : EntityService<nc.ClasificacionGeografica,nc.ClasificacionGeograficaFilter,nc.ClasificacionGeograficaResult,int>
    {        
		protected readonly ClasificacionGeograficaBusiness Business = new ClasificacionGeograficaBusiness();
        protected override IEntityBusiness<nc.ClasificacionGeografica,nc.ClasificacionGeograficaFilter,nc.ClasificacionGeograficaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
