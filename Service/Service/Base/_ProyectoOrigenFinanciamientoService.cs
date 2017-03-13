using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoOrigenFinanciamientoService : EntityService<nc.ProyectoOrigenFinanciamiento,nc.ProyectoOrigenFinanciamientoFilter,nc.ProyectoOrigenFinanciamientoResult,int>
    {        
		protected readonly ProyectoOrigenFinanciamientoBusiness Business = new ProyectoOrigenFinanciamientoBusiness();
        protected override IEntityBusiness<nc.ProyectoOrigenFinanciamiento,nc.ProyectoOrigenFinanciamientoFilter,nc.ProyectoOrigenFinanciamientoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
