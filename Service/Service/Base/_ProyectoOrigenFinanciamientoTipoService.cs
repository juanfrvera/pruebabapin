using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoOrigenFinanciamientoTipoService : EntityService<nc.ProyectoOrigenFinanciamientoTipo,nc.ProyectoOrigenFinanciamientoTipoFilter,nc.ProyectoOrigenFinanciamientoTipoResult,int>
    {        
		protected readonly ProyectoOrigenFinanciamientoTipoBusiness Business = new ProyectoOrigenFinanciamientoTipoBusiness();
        protected override IEntityBusiness<nc.ProyectoOrigenFinanciamientoTipo,nc.ProyectoOrigenFinanciamientoTipoFilter,nc.ProyectoOrigenFinanciamientoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
