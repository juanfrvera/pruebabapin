using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProgramaService : EntityService<nc.Programa,nc.ProgramaFilter,nc.ProgramaResult,int>
    {        
		protected readonly ProgramaBusiness Business = new ProgramaBusiness();
        protected override IEntityBusiness<nc.Programa,nc.ProgramaFilter,nc.ProgramaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
