using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoCalidadService : EntityService<nc.ProyectoCalidad,nc.ProyectoCalidadFilter,nc.ProyectoCalidadResult,int>
    {        
		protected readonly ProyectoCalidadBusiness Business = new ProyectoCalidadBusiness();
        protected override IEntityBusiness<nc.ProyectoCalidad,nc.ProyectoCalidadFilter,nc.ProyectoCalidadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
