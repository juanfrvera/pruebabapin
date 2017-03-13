using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PerfilActividadService : EntityService<nc.PerfilActividad,nc.PerfilActividadFilter,nc.PerfilActividadResult,int>
    {        
		protected readonly PerfilActividadBusiness Business = new PerfilActividadBusiness();
        protected override IEntityBusiness<nc.PerfilActividad,nc.PerfilActividadFilter,nc.PerfilActividadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
