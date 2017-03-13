using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoBeneficioIndicadorService : EntityService<nc.ProyectoBeneficioIndicador,nc.ProyectoBeneficioIndicadorFilter,nc.ProyectoBeneficioIndicadorResult,int>
    {        
		protected readonly ProyectoBeneficioIndicadorBusiness Business = new ProyectoBeneficioIndicadorBusiness();
        protected override IEntityBusiness<nc.ProyectoBeneficioIndicador,nc.ProyectoBeneficioIndicadorFilter,nc.ProyectoBeneficioIndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
