using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoOficinaPerfilService : EntityService<nc.PrestamoOficinaPerfil,nc.PrestamoOficinaPerfilFilter,nc.PrestamoOficinaPerfilResult,int>
    {        
		protected readonly PrestamoOficinaPerfilBusiness Business = new PrestamoOficinaPerfilBusiness();
        protected override IEntityBusiness<nc.PrestamoOficinaPerfil,nc.PrestamoOficinaPerfilFilter,nc.PrestamoOficinaPerfilResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
