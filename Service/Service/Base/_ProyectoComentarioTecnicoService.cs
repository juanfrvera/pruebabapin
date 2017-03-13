using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoComentarioTecnicoService : EntityService<nc.ProyectoComentarioTecnico,nc.ProyectoComentarioTecnicoFilter,nc.ProyectoComentarioTecnicoResult,int>
    {        
		protected readonly ProyectoComentarioTecnicoBusiness Business = new ProyectoComentarioTecnicoBusiness();
        protected override IEntityBusiness<nc.ProyectoComentarioTecnico,nc.ProyectoComentarioTecnicoFilter,nc.ProyectoComentarioTecnicoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
