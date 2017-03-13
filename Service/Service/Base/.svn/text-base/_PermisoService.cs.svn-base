using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PermisoService : EntityService<nc.Permiso,nc.PermisoFilter,nc.PermisoResult,int>
    {        
		protected readonly PermisoBusiness Business = new PermisoBusiness();
        protected override IEntityBusiness<nc.Permiso,nc.PermisoFilter,nc.PermisoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
