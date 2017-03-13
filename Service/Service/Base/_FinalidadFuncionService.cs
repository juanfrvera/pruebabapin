using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FinalidadFuncionService : EntityService<nc.FinalidadFuncion,nc.FinalidadFuncionFilter,nc.FinalidadFuncionResult,int>
    {        
		protected readonly FinalidadFuncionBusiness Business = new FinalidadFuncionBusiness();
        protected override IEntityBusiness<nc.FinalidadFuncion,nc.FinalidadFuncionFilter,nc.FinalidadFuncionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
