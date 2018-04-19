using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaInformacionPresupuestariaService : EntityService<nc.ProyectoEtapaInformacionPresupuestaria,nc.ProyectoEtapaInformacionPresupuestariaFilter,nc.ProyectoEtapaInformacionPresupuestariaResult,int>
    {        
		protected readonly ProyectoEtapaInformacionPresupuestariaBusiness Business = new ProyectoEtapaInformacionPresupuestariaBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaInformacionPresupuestaria,nc.ProyectoEtapaInformacionPresupuestariaFilter,nc.ProyectoEtapaInformacionPresupuestariaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
