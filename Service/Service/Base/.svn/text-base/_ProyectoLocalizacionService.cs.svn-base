using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoLocalizacionService : EntityService<nc.ProyectoLocalizacion,nc.ProyectoLocalizacionFilter,nc.ProyectoLocalizacionResult,int>
    {        
		protected readonly ProyectoLocalizacionBusiness Business = new ProyectoLocalizacionBusiness();
        protected override IEntityBusiness<nc.ProyectoLocalizacion,nc.ProyectoLocalizacionFilter,nc.ProyectoLocalizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
