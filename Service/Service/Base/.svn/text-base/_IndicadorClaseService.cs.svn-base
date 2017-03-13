using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorClaseService : EntityService<nc.IndicadorClase,nc.IndicadorClaseFilter,nc.IndicadorClaseResult,int>
    {        
		protected readonly IndicadorClaseBusiness Business = new IndicadorClaseBusiness();
        protected override IEntityBusiness<nc.IndicadorClase,nc.IndicadorClaseFilter,nc.IndicadorClaseResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
