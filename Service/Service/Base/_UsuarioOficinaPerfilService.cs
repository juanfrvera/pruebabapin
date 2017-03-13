using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _UsuarioOficinaPerfilService : EntityService<nc.UsuarioOficinaPerfil,nc.UsuarioOficinaPerfilFilter,nc.UsuarioOficinaPerfilResult,int>
    {        
		protected readonly UsuarioOficinaPerfilBusiness Business = new UsuarioOficinaPerfilBusiness();
        protected override IEntityBusiness<nc.UsuarioOficinaPerfil,nc.UsuarioOficinaPerfilFilter,nc.UsuarioOficinaPerfilResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
