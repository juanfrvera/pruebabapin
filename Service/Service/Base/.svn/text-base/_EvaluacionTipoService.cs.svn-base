using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EvaluacionTipoService : EntityService<nc.EvaluacionTipo,nc.EvaluacionTipoFilter,nc.EvaluacionTipoResult,int>
    {        
		protected readonly EvaluacionTipoBusiness Business = new EvaluacionTipoBusiness();
        protected override IEntityBusiness<nc.EvaluacionTipo,nc.EvaluacionTipoFilter,nc.EvaluacionTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
