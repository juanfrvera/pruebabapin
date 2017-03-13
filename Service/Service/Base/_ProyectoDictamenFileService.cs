using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Business;


namespace Service.Base
{

    public class _ProyectoDictamenFileService : EntityService<nc.ProyectoDictamenFile, nc.ProyectoDictamenFileFilter, nc.ProyectoDictamenFileResult, int>
    {
        protected readonly ProyectoDictamenFileBusiness Business = new ProyectoDictamenFileBusiness();
        protected override IEntityBusiness<nc.ProyectoDictamenFile, nc.ProyectoDictamenFileFilter, nc.ProyectoDictamenFileResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
    }

}
