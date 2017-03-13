using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoCalificacionService : EntityService<nc.ProyectoCalificacion,nc.ProyectoCalificacionFilter,nc.ProyectoCalificacionResult,int>
    {        
		protected readonly ProyectoCalificacionBusiness Business = new ProyectoCalificacionBusiness();
        protected override IEntityBusiness<nc.ProyectoCalificacion,nc.ProyectoCalificacionFilter,nc.ProyectoCalificacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
