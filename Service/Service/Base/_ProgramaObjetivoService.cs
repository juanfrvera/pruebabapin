using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProgramaObjetivoService : EntityService<nc.ProgramaObjetivo,nc.ProgramaObjetivoFilter,nc.ProgramaObjetivoResult,int>
    {        
		protected readonly ProgramaObjetivoBusiness Business = new ProgramaObjetivoBusiness();
        protected override IEntityBusiness<nc.ProgramaObjetivo,nc.ProgramaObjetivoFilter,nc.ProgramaObjetivoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
