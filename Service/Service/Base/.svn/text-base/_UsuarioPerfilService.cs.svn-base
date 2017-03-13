using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _UsuarioPerfilService : EntityService<nc.UsuarioPerfil,nc.UsuarioPerfilFilter,nc.UsuarioPerfilResult,int>
    {        
		protected readonly UsuarioPerfilBusiness Business = new UsuarioPerfilBusiness();
        protected override IEntityBusiness<nc.UsuarioPerfil,nc.UsuarioPerfilFilter,nc.UsuarioPerfilResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
