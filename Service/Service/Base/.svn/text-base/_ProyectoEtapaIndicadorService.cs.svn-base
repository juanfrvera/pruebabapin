using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaIndicadorService : EntityService<nc.ProyectoEtapaIndicador,nc.ProyectoEtapaIndicadorFilter,nc.ProyectoEtapaIndicadorResult,int>
    {        
		protected readonly ProyectoEtapaIndicadorBusiness Business = new ProyectoEtapaIndicadorBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaIndicador,nc.ProyectoEtapaIndicadorFilter,nc.ProyectoEtapaIndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
