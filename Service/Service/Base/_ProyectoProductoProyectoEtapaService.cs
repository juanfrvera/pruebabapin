using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoProductoProyectoEtapaService : EntityService<nc.ProyectoProductoProyectoEtapa,nc.ProyectoProductoProyectoEtapaFilter,nc.ProyectoProductoProyectoEtapaResult,int>
    {        
		protected readonly ProyectoProductoProyectoEtapaBusiness Business = new ProyectoProductoProyectoEtapaBusiness();
        protected override IEntityBusiness<nc.ProyectoProductoProyectoEtapa,nc.ProyectoProductoProyectoEtapaFilter,nc.ProyectoProductoProyectoEtapaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
