using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoPropositoService : EntityService<nc.ProyectoProposito,nc.ProyectoPropositoFilter,nc.ProyectoPropositoResult,int>
    {        
		protected readonly ProyectoPropositoBusiness Business = new ProyectoPropositoBusiness();
        protected override IEntityBusiness<nc.ProyectoProposito,nc.ProyectoPropositoFilter,nc.ProyectoPropositoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
