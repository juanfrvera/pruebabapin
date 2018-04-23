using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoIndicadorObjetivosGobiernoService : EntityService<nc.ProyectoIndicadorObjetivosGobierno,nc.ProyectoIndicadorObjetivosGobiernoFilter,nc.ProyectoIndicadorObjetivosGobiernoResult,int>
    {        
		protected readonly ProyectoIndicadorObjetivosGobiernoBusiness Business = new ProyectoIndicadorObjetivosGobiernoBusiness();
        protected override IEntityBusiness<nc.ProyectoIndicadorObjetivosGobierno,nc.ProyectoIndicadorObjetivosGobiernoFilter,nc.ProyectoIndicadorObjetivosGobiernoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
