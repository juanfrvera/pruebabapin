using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoDictamenFileService : EntityService<nc.PrestamoDictamenFile,nc.PrestamoDictamenFileFilter,nc.PrestamoDictamenFileResult,int>
    {        
		protected readonly PrestamoDictamenFileBusiness Business = new PrestamoDictamenFileBusiness();
        protected override IEntityBusiness<nc.PrestamoDictamenFile,nc.PrestamoDictamenFileFilter,nc.PrestamoDictamenFileResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
