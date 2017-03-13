using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionService : EntityService<nc.Clasificacion,nc.ClasificacionFilter,nc.ClasificacionResult,int>
    {        
		protected readonly ClasificacionBusiness Business = new ClasificacionBusiness();
        protected override IEntityBusiness<nc.Clasificacion,nc.ClasificacionFilter,nc.ClasificacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
