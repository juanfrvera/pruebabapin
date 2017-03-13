using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaRealizadoService : EntityService<nc.ProyectoEtapaRealizado,nc.ProyectoEtapaRealizadoFilter,nc.ProyectoEtapaRealizadoResult,int>
    {        
		protected readonly ProyectoEtapaRealizadoBusiness Business = new ProyectoEtapaRealizadoBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaRealizado,nc.ProyectoEtapaRealizadoFilter,nc.ProyectoEtapaRealizadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
