using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoGeoreferenciacionService : EntityService<nc.ProyectoGeoreferenciacion,nc.ProyectoGeoreferenciacionFilter,nc.ProyectoGeoreferenciacionResult,int>
    {        
		protected readonly ProyectoGeoreferenciacionBusiness Business = new ProyectoGeoreferenciacionBusiness();
        protected override IEntityBusiness<nc.ProyectoGeoreferenciacion,nc.ProyectoGeoreferenciacionFilter,nc.ProyectoGeoreferenciacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
