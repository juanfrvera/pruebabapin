using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoRelacionService : EntityService<nc.ProyectoRelacion,nc.ProyectoRelacionFilter,nc.ProyectoRelacionResult,int>
    {        
		protected readonly ProyectoRelacionBusiness Business = new ProyectoRelacionBusiness();
        protected override IEntityBusiness<nc.ProyectoRelacion,nc.ProyectoRelacionFilter,nc.ProyectoRelacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
