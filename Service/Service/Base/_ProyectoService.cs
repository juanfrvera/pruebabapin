using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoService : EntityService<nc.Proyecto,nc.ProyectoFilter,nc.ProyectoResult,int>
    {        
		protected readonly ProyectoBusiness Business = new ProyectoBusiness();
        protected override IEntityBusiness<nc.Proyecto,nc.ProyectoFilter,nc.ProyectoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
