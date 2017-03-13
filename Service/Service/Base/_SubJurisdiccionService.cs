using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SubJurisdiccionService : EntityService<nc.SubJurisdiccion,nc.SubJurisdiccionFilter,nc.SubJurisdiccionResult,int>
    {        
		protected readonly SubJurisdiccionBusiness Business = new SubJurisdiccionBusiness();
        protected override IEntityBusiness<nc.SubJurisdiccion,nc.SubJurisdiccionFilter,nc.SubJurisdiccionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
