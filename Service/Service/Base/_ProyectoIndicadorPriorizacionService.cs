using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoIndicadorPriorizacionService : EntityService<nc.ProyectoIndicadorPriorizacion,nc.ProyectoIndicadorPriorizacionFilter,nc.ProyectoIndicadorPriorizacionResult,int>
    {        
		protected readonly ProyectoIndicadorPriorizacionBusiness Business = new ProyectoIndicadorPriorizacionBusiness();
        protected override IEntityBusiness<nc.ProyectoIndicadorPriorizacion,nc.ProyectoIndicadorPriorizacionFilter,nc.ProyectoIndicadorPriorizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
