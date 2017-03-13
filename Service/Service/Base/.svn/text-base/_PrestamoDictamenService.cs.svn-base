using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoDictamenService : EntityService<nc.PrestamoDictamen,nc.PrestamoDictamenFilter,nc.PrestamoDictamenResult,int>
    {        
		protected readonly PrestamoDictamenBusiness Business = new PrestamoDictamenBusiness();
        protected override IEntityBusiness<nc.PrestamoDictamen,nc.PrestamoDictamenFilter,nc.PrestamoDictamenResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
