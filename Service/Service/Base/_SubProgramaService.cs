using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SubProgramaService : EntityService<nc.SubPrograma,nc.SubProgramaFilter,nc.SubProgramaResult,int>
    {        
		protected readonly SubProgramaBusiness Business = new SubProgramaBusiness();
        protected override IEntityBusiness<nc.SubPrograma,nc.SubProgramaFilter,nc.SubProgramaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
