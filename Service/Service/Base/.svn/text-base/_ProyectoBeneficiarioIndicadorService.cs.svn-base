using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoBeneficiarioIndicadorService : EntityService<nc.ProyectoBeneficiarioIndicador,nc.ProyectoBeneficiarioIndicadorFilter,nc.ProyectoBeneficiarioIndicadorResult,int>
    {        
		protected readonly ProyectoBeneficiarioIndicadorBusiness Business = new ProyectoBeneficiarioIndicadorBusiness();
        protected override IEntityBusiness<nc.ProyectoBeneficiarioIndicador,nc.ProyectoBeneficiarioIndicadorFilter,nc.ProyectoBeneficiarioIndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
