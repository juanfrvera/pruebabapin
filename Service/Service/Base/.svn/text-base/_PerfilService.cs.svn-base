using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PerfilService : EntityService<nc.Perfil,nc.PerfilFilter,nc.PerfilResult,int>
    {        
		protected readonly PerfilBusiness Business = new PerfilBusiness();
        protected override IEntityBusiness<nc.Perfil,nc.PerfilFilter,nc.PerfilResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
