using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoFileService : EntityService<nc.PrestamoFile,nc.PrestamoFileFilter,nc.PrestamoFileResult,int>
    {        
		protected readonly PrestamoFileBusiness Business = new PrestamoFileBusiness();
        protected override IEntityBusiness<nc.PrestamoFile,nc.PrestamoFileFilter,nc.PrestamoFileResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
