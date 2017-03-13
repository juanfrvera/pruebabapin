using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _GeoreferenciacionService : EntityService<nc.Georeferenciacion,nc.GeoreferenciacionFilter,nc.GeoreferenciacionResult,int>
    {        
		protected readonly GeoreferenciacionBusiness Business = new GeoreferenciacionBusiness();
        protected override IEntityBusiness<nc.Georeferenciacion,nc.GeoreferenciacionFilter,nc.GeoreferenciacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
