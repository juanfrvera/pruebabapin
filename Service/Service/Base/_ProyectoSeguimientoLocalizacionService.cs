using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoSeguimientoLocalizacionService : EntityService<nc.ProyectoSeguimientoLocalizacion,nc.ProyectoSeguimientoLocalizacionFilter,nc.ProyectoSeguimientoLocalizacionResult,int>
    {        
		protected readonly ProyectoSeguimientoLocalizacionBusiness Business = new ProyectoSeguimientoLocalizacionBusiness();
        protected override IEntityBusiness<nc.ProyectoSeguimientoLocalizacion,nc.ProyectoSeguimientoLocalizacionFilter,nc.ProyectoSeguimientoLocalizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
