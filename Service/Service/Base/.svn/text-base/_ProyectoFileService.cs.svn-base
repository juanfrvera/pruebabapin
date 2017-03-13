using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoFileService : EntityService<nc.ProyectoFile,nc.ProyectoFileFilter,nc.ProyectoFileResult,int>
    {        
		protected readonly ProyectoFileBusiness Business = new ProyectoFileBusiness();
        protected override IEntityBusiness<nc.ProyectoFile,nc.ProyectoFileFilter,nc.ProyectoFileResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
