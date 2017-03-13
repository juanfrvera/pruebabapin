using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PersonaService : EntityService<nc.Persona,nc.PersonaFilter,nc.PersonaResult,int>
    {        
		protected readonly PersonaBusiness Business = new PersonaBusiness();
        protected override IEntityBusiness<nc.Persona,nc.PersonaFilter,nc.PersonaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
