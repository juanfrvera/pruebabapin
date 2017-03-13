using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _JurisdiccionService : EntityService<nc.Jurisdiccion,nc.JurisdiccionFilter,nc.JurisdiccionResult,int>
    {        
		protected readonly JurisdiccionBusiness Business = new JurisdiccionBusiness();
        protected override IEntityBusiness<nc.Jurisdiccion,nc.JurisdiccionFilter,nc.JurisdiccionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
