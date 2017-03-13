using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoFaseProyectoEtapaService : EntityService<nc.ProyectoFaseProyectoEtapa,nc.ProyectoFaseProyectoEtapaFilter,nc.ProyectoFaseProyectoEtapaResult,int>
    {        
		protected readonly ProyectoFaseProyectoEtapaBusiness Business = new ProyectoFaseProyectoEtapaBusiness();
        protected override IEntityBusiness<nc.ProyectoFaseProyectoEtapa,nc.ProyectoFaseProyectoEtapaFilter,nc.ProyectoFaseProyectoEtapaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
