using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorMedioVerificacionService : EntityService<nc.IndicadorMedioVerificacion,nc.IndicadorMedioVerificacionFilter,nc.IndicadorMedioVerificacionResult,int>
    {        
		protected readonly IndicadorMedioVerificacionBusiness Business = new IndicadorMedioVerificacionBusiness();
        protected override IEntityBusiness<nc.IndicadorMedioVerificacion,nc.IndicadorMedioVerificacionFilter,nc.IndicadorMedioVerificacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
