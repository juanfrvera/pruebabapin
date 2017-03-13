using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EstadoDeDesicionHistoricoService : EntityService<nc.EstadoDeDesicionHistorico,nc.EstadoDeDesicionHistoricoFilter,nc.EstadoDeDesicionHistoricoResult,int>
    {        
		protected readonly EstadoDeDesicionHistoricoBusiness Business = new EstadoDeDesicionHistoricoBusiness();
        protected override IEntityBusiness<nc.EstadoDeDesicionHistorico,nc.EstadoDeDesicionHistoricoFilter,nc.EstadoDeDesicionHistoricoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
