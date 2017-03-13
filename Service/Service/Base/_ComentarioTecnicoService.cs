using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ComentarioTecnicoService : EntityService<nc.ComentarioTecnico,nc.ComentarioTecnicoFilter,nc.ComentarioTecnicoResult,int>
    {        
		protected readonly ComentarioTecnicoBusiness Business = new ComentarioTecnicoBusiness();
        protected override IEntityBusiness<nc.ComentarioTecnico,nc.ComentarioTecnicoFilter,nc.ComentarioTecnicoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
