using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaService : EntityService<nc.ProyectoEtapa,nc.ProyectoEtapaFilter,nc.ProyectoEtapaResult,int>
    {        
		protected readonly ProyectoEtapaBusiness Business = new ProyectoEtapaBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapa,nc.ProyectoEtapaFilter,nc.ProyectoEtapaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
