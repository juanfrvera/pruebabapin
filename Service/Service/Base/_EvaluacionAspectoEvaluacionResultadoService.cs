using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EvaluacionAspectoEvaluacionResultadoService : EntityService<nc.EvaluacionAspectoEvaluacionResultado,nc.EvaluacionAspectoEvaluacionResultadoFilter,nc.EvaluacionAspectoEvaluacionResultadoResult,int>
    {        
		protected readonly EvaluacionAspectoEvaluacionResultadoBusiness Business = new EvaluacionAspectoEvaluacionResultadoBusiness();
        protected override IEntityBusiness<nc.EvaluacionAspectoEvaluacionResultado,nc.EvaluacionAspectoEvaluacionResultadoFilter,nc.EvaluacionAspectoEvaluacionResultadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
