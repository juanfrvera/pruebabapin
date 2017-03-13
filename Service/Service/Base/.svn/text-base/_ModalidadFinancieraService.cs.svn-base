using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ModalidadFinancieraService : EntityService<nc.ModalidadFinanciera,nc.ModalidadFinancieraFilter,nc.ModalidadFinancieraResult,int>
    {        
		protected readonly ModalidadFinancieraBusiness Business = new ModalidadFinancieraBusiness();
        protected override IEntityBusiness<nc.ModalidadFinanciera,nc.ModalidadFinancieraFilter,nc.ModalidadFinancieraResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
