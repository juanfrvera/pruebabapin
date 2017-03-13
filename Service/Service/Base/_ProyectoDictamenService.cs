using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoDictamenService : EntityService<nc.ProyectoDictamen,nc.ProyectoDictamenFilter,nc.ProyectoDictamenResult,int>
    {        
		protected readonly ProyectoDictamenBusiness Business = new ProyectoDictamenBusiness();
        protected override IEntityBusiness<nc.ProyectoDictamen,nc.ProyectoDictamenFilter,nc.ProyectoDictamenResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
