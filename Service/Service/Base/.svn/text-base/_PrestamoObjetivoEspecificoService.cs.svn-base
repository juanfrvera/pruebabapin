using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoObjetivoEspecificoService : EntityService<nc.PrestamoObjetivoEspecifico,nc.PrestamoObjetivoEspecificoFilter,nc.PrestamoObjetivoEspecificoResult,int>
    {        
		protected readonly PrestamoObjetivoEspecificoBusiness Business = new PrestamoObjetivoEspecificoBusiness();
        protected override IEntityBusiness<nc.PrestamoObjetivoEspecifico,nc.PrestamoObjetivoEspecificoFilter,nc.PrestamoObjetivoEspecificoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
