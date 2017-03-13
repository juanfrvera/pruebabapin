using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoShapeFileService : EntityService<nc.ProyectoShapeFile, nc.ProyectoShapeFileFilter, nc.ProyectoShapeFileResult, int>
    {
        protected readonly ProyectoShapeFileBusiness Business = new ProyectoShapeFileBusiness();

        protected override IEntityBusiness<nc.ProyectoShapeFile, nc.ProyectoShapeFileFilter, nc.ProyectoShapeFileResult, int> EntityBusiness
        {
            get { return this.Business; }
        }

    }
}
