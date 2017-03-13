using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FileInfoService : EntityService<nc.FileInfo,nc.FileInfoFilter,nc.FileInfoResult,int>
    {        
		protected readonly FileInfoBusiness Business = new FileInfoBusiness();
        protected override IEntityBusiness<nc.FileInfo,nc.FileInfoFilter,nc.FileInfoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
