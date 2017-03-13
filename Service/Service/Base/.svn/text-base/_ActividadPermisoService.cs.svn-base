using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ActividadPermisoService : EntityService<nc.ActividadPermiso,nc.ActividadPermisoFilter,nc.ActividadPermisoResult,int>
    {        
		protected readonly ActividadPermisoBusiness Business = new ActividadPermisoBusiness();
        protected override IEntityBusiness<nc.ActividadPermiso,nc.ActividadPermisoFilter,nc.ActividadPermisoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
