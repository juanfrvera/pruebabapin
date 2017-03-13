using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OficinaSafProgramaService : EntityService<nc.OficinaSafPrograma,nc.OficinaSafProgramaFilter,nc.OficinaSafProgramaResult,int>
    {        
		protected readonly OficinaSafProgramaBusiness Business = new OficinaSafProgramaBusiness();
        protected override IEntityBusiness<nc.OficinaSafPrograma,nc.OficinaSafProgramaFilter,nc.OficinaSafProgramaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
