using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoDemoraService : EntityService<nc.ProyectoDemora,nc.ProyectoDemoraFilter,nc.ProyectoDemoraResult,int>
    {        
		protected readonly ProyectoDemoraBusiness Business = new ProyectoDemoraBusiness();
        protected override IEntityBusiness<nc.ProyectoDemora,nc.ProyectoDemoraFilter,nc.ProyectoDemoraResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
