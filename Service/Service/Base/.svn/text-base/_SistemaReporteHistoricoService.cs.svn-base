using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaReporteHistoricoService : EntityService<nc.SistemaReporteHistorico,nc.SistemaReporteHistoricoFilter,nc.SistemaReporteHistoricoResult,int>
    {        
		protected readonly SistemaReporteHistoricoBusiness Business = new SistemaReporteHistoricoBusiness();
        protected override IEntityBusiness<nc.SistemaReporteHistorico,nc.SistemaReporteHistoricoFilter,nc.SistemaReporteHistoricoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
