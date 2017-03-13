using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EvaluacionAspectoService : EntityService<nc.EvaluacionAspecto,nc.EvaluacionAspectoFilter,nc.EvaluacionAspectoResult,int>
    {        
		protected readonly EvaluacionAspectoBusiness Business = new EvaluacionAspectoBusiness();
        protected override IEntityBusiness<nc.EvaluacionAspecto,nc.EvaluacionAspectoFilter,nc.EvaluacionAspectoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
