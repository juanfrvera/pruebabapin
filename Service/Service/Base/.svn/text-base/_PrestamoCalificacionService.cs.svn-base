using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoCalificacionService : EntityService<nc.PrestamoCalificacion,nc.PrestamoCalificacionFilter,nc.PrestamoCalificacionResult,int>
    {        
		protected readonly PrestamoCalificacionBusiness Business = new PrestamoCalificacionBusiness();
        protected override IEntityBusiness<nc.PrestamoCalificacion,nc.PrestamoCalificacionFilter,nc.PrestamoCalificacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
