using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoOficinaPerfilFuncionarioService : EntityService<nc.ProyectoOficinaPerfilFuncionario,nc.ProyectoOficinaPerfilFuncionarioFilter,nc.ProyectoOficinaPerfilFuncionarioResult,int>
    {        
		protected readonly ProyectoOficinaPerfilFuncionarioBusiness Business = new ProyectoOficinaPerfilFuncionarioBusiness();
        protected override IEntityBusiness<nc.ProyectoOficinaPerfilFuncionario,nc.ProyectoOficinaPerfilFuncionarioFilter,nc.ProyectoOficinaPerfilFuncionarioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
