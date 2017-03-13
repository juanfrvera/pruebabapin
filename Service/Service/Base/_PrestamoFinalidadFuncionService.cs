using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoFinalidadFuncionService : EntityService<nc.PrestamoFinalidadFuncion,nc.PrestamoFinalidadFuncionFilter,nc.PrestamoFinalidadFuncionResult,int>
    {        
		protected readonly PrestamoFinalidadFuncionBusiness Business = new PrestamoFinalidadFuncionBusiness();
        protected override IEntityBusiness<nc.PrestamoFinalidadFuncion,nc.PrestamoFinalidadFuncionFilter,nc.PrestamoFinalidadFuncionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
