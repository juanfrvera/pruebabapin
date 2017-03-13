using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaReporteService : EntityService<nc.SistemaReporte,nc.SistemaReporteFilter,nc.SistemaReporteResult,int>
    {        
		protected readonly SistemaReporteBusiness Business = new SistemaReporteBusiness();
        protected override IEntityBusiness<nc.SistemaReporte,nc.SistemaReporteFilter,nc.SistemaReporteResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
