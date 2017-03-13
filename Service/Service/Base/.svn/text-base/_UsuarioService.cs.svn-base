using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _UsuarioService : EntityService<nc.Usuario,nc.UsuarioFilter,nc.UsuarioResult,int>
    {        
		protected readonly UsuarioBusiness Business = new UsuarioBusiness();
        protected override IEntityBusiness<nc.Usuario,nc.UsuarioFilter,nc.UsuarioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
