using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ActividadService : EntityService<nc.Actividad,nc.ActividadFilter,nc.ActividadResult,int>
    {        
		protected readonly ActividadBusiness Business = new ActividadBusiness();
        protected override IEntityBusiness<nc.Actividad,nc.ActividadFilter,nc.ActividadResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
