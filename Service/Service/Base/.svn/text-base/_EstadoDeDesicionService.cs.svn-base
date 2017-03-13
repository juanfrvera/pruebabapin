using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EstadoDeDesicionService : EntityService<nc.EstadoDeDesicion,nc.EstadoDeDesicionFilter,nc.EstadoDeDesicionResult,int>
    {        
		protected readonly EstadoDeDesicionBusiness Business = new EstadoDeDesicionBusiness();
        protected override IEntityBusiness<nc.EstadoDeDesicion,nc.EstadoDeDesicionFilter,nc.EstadoDeDesicionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
