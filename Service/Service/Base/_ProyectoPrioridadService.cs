using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoPrioridadService : EntityService<nc.ProyectoPrioridad,nc.ProyectoPrioridadFilter,nc.ProyectoPrioridadResult,int>
    {        
		protected readonly ProyectoPrioridadBusiness Business = new ProyectoPrioridadBusiness();
        protected override IEntityBusiness<nc.ProyectoPrioridad,nc.ProyectoPrioridadFilter,nc.ProyectoPrioridadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
