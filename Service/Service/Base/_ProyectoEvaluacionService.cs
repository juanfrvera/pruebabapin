using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEvaluacionService : EntityService<nc.ProyectoEvaluacion,nc.ProyectoEvaluacionFilter,nc.ProyectoEvaluacionResult,int>
    {        
		protected readonly ProyectoEvaluacionBusiness Business = new ProyectoEvaluacionBusiness();
        protected override IEntityBusiness<nc.ProyectoEvaluacion,nc.ProyectoEvaluacionFilter,nc.ProyectoEvaluacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
