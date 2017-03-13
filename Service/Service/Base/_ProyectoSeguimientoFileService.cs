using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoSeguimientoFileService : EntityService<nc.ProyectoSeguimientoFile,nc.ProyectoSeguimientoFileFilter,nc.ProyectoSeguimientoFileResult,int>
    {        
		protected readonly ProyectoSeguimientoFileBusiness Business = new ProyectoSeguimientoFileBusiness();
        protected override IEntityBusiness<nc.ProyectoSeguimientoFile,nc.ProyectoSeguimientoFileFilter,nc.ProyectoSeguimientoFileResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
