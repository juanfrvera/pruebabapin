using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EvaluacionResultadoService : EntityService<nc.EvaluacionResultado,nc.EvaluacionResultadoFilter,nc.EvaluacionResultadoResult,int>
    {        
		protected readonly EvaluacionResultadoBusiness Business = new EvaluacionResultadoBusiness();
        protected override IEntityBusiness<nc.EvaluacionResultado,nc.EvaluacionResultadoFilter,nc.EvaluacionResultadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
