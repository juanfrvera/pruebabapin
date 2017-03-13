using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FinalidadFuncionTipoService : EntityService<nc.FinalidadFuncionTipo,nc.FinalidadFuncionTipoFilter,nc.FinalidadFuncionTipoResult,int>
    {        
		protected readonly FinalidadFuncionTipoBusiness Business = new FinalidadFuncionTipoBusiness();
        protected override IEntityBusiness<nc.FinalidadFuncionTipo,nc.FinalidadFuncionTipoFilter,nc.FinalidadFuncionTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
