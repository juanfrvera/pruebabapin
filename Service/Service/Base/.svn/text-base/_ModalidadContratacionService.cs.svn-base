using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ModalidadContratacionService : EntityService<nc.ModalidadContratacion,nc.ModalidadContratacionFilter,nc.ModalidadContratacionResult,int>
    {        
		protected readonly ModalidadContratacionBusiness Business = new ModalidadContratacionBusiness();
        protected override IEntityBusiness<nc.ModalidadContratacion,nc.ModalidadContratacionFilter,nc.ModalidadContratacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
