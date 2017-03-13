using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionGastoRubroService : EntityService<nc.ClasificacionGastoRubro,nc.ClasificacionGastoRubroFilter,nc.ClasificacionGastoRubroResult,int>
    {        
		protected readonly ClasificacionGastoRubroBusiness Business = new ClasificacionGastoRubroBusiness();
        protected override IEntityBusiness<nc.ClasificacionGastoRubro,nc.ClasificacionGastoRubroFilter,nc.ClasificacionGastoRubroResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
