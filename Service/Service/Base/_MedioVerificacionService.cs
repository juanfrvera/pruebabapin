using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MedioVerificacionService : EntityService<nc.MedioVerificacion,nc.MedioVerificacionFilter,nc.MedioVerificacionResult,int>
    {        
		protected readonly MedioVerificacionBusiness Business = new MedioVerificacionBusiness();
        protected override IEntityBusiness<nc.MedioVerificacion,nc.MedioVerificacionFilter,nc.MedioVerificacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
