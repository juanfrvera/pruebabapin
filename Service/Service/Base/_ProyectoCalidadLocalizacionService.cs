using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoCalidadLocalizacionService : EntityService<nc.ProyectoCalidadLocalizacion,nc.ProyectoCalidadLocalizacionFilter,nc.ProyectoCalidadLocalizacionResult,int>
    {        
		protected readonly ProyectoCalidadLocalizacionBusiness Business = new ProyectoCalidadLocalizacionBusiness();
        protected override IEntityBusiness<nc.ProyectoCalidadLocalizacion,nc.ProyectoCalidadLocalizacionFilter,nc.ProyectoCalidadLocalizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
