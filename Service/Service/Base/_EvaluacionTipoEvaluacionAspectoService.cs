using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EvaluacionTipoEvaluacionAspectoService : EntityService<nc.EvaluacionTipoEvaluacionAspecto,nc.EvaluacionTipoEvaluacionAspectoFilter,nc.EvaluacionTipoEvaluacionAspectoResult,int>
    {        
		protected readonly EvaluacionTipoEvaluacionAspectoBusiness Business = new EvaluacionTipoEvaluacionAspectoBusiness();
        protected override IEntityBusiness<nc.EvaluacionTipoEvaluacionAspecto,nc.EvaluacionTipoEvaluacionAspectoFilter,nc.EvaluacionTipoEvaluacionAspectoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
